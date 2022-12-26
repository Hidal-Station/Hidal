using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Hidal.MusicApp.DbMigrator.PerformanceMusics;
using Hidal.MusicApp.PerformanceMusics.Dtos;
using System.Threading.Tasks;
using Volo.Abp.BlobStoring;
using Hidal.MusicApp.ImageAppService.Dtos;
using Volo.Abp.Guids;
using System.IO;
using Volo.Abp;
using Hidal.MusicApp.Singers;
using Hidal.MusicApp.DbMigrator.Singers;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Hidal.MusicApp.PerformanceMusics
{
    public class PerformanceMusicAppService :
        CrudAppService<
            PerformanceMusic,
            PerformanceMusicDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdatePerformanceMusicDto
            >, IPerformanceMusicAppService
    {
        private readonly IBlobContainer _blobPerformanceMusicContainer;
        private readonly IBlobContainer _blobSingerContainer;
        private readonly IBlobContainer _blobUserContainer;
        private readonly IBlobContainer _blobAuthorContainer;
        private readonly IGuidGenerator _guidGenerator;
        private readonly IPerformanceMusicRepository _performanceMusicRepository;
        private readonly ISingerRepository _singerRepository;

        public PerformanceMusicAppService(ISingerRepository singerRepository,IPerformanceMusicRepository performanceMusicRepository, IBlobContainerFactory blobPerformanceMusicContainer, IBlobContainerFactory blobSingerContainer, IBlobContainerFactory blobUserContainer, IBlobContainerFactory blobAuthorContainer, IGuidGenerator guidGenerator) : base(performanceMusicRepository)
        {
            _blobPerformanceMusicContainer = blobPerformanceMusicContainer.Create("music");
            _blobSingerContainer = blobSingerContainer.Create("Singer");
            _blobUserContainer = blobUserContainer.Create("User");
            _blobAuthorContainer = blobAuthorContainer.Create("Author");
            _guidGenerator = guidGenerator;
            _performanceMusicRepository = performanceMusicRepository;
            _singerRepository = singerRepository;
        }

        public async Task<List<PerformanceMusicDto>> GetMusicAsync(string keyword = "")
        {
            var query = await _performanceMusicRepository.GetQueryableAsync();
            var listMusic = await query.Include(x => x.Singer).Where(x => x.SongName.Contains(keyword)).ToListAsync();
            var listMusic1 = ObjectMapper.Map<List<PerformanceMusic>, List<PerformanceMusicDto>>(listMusic);
            return ObjectMapper.Map<List<PerformanceMusic>,List<PerformanceMusicDto>>(listMusic);
        }

        public async Task IncreaseViewAsync(Guid id)
        {
            var performanceMusic = await _performanceMusicRepository.GetAsync(id);
            if (performanceMusic == null)
            {
                throw new BusinessException("Error");
            }
            performanceMusic.Viewed += 1;
            await _performanceMusicRepository.UpdateAsync(performanceMusic);
        }

        public async Task<PerformanceMusicDto> RatingAsync(RatingPerformanceMusicDtos ratingDto)
        {
            var performanceMusic = await _performanceMusicRepository.GetAsync(ratingDto.Id);
            if (performanceMusic == null)
            {
                throw new BusinessException("Error");
            }
            var numberOfRating = performanceMusic.NumberOfRating + 1;
            var  ratingAverage = (performanceMusic.ratingAverage*performanceMusic.NumberOfRating + ratingDto.Score)/(numberOfRating);
            performanceMusic.ratingAverage = ratingAverage;
            performanceMusic.NumberOfRating = numberOfRating;
            var newPerformanceMusic = await _performanceMusicRepository.UpdateAsync(performanceMusic);
            return ObjectMapper.Map<PerformanceMusic, PerformanceMusicDto>(newPerformanceMusic);
        }

        public async Task<CreateUpdateImageStoreDto> UploadPerformanceMusicFileAsync(IFormFile fileMusic)
        {
            try
            {
                var arrFileMusic = fileMusic.FileName.Split(".");
                string fileTypeMusic = arrFileMusic[arrFileMusic.Length - 1];
                var fileNameMusic = Path.GetFileNameWithoutExtension(fileMusic.FileName);


                int distance = 0;
                string songName = "";
                string singerName = "";
                distance = fileNameMusic.IndexOf("-");
                songName = fileNameMusic.Remove(distance);
                singerName = fileNameMusic.Remove(0, distance + 1);

                CreateUpdateImageStoreDto newItem = new CreateUpdateImageStoreDto();
                newItem.FileNameMusic = fileMusic.FileName;
                newItem.FileTypeMusic = fileMusic.ContentType;
                newItem.SizeMusic = fileMusic.Length;
                newItem.FullNameMusic = fileMusic.FileName;
                newItem.IdMusic = Guid.NewGuid();
                newItem.SongName = songName;
                newItem.SingerName = singerName;

                using (var memoryStream = new MemoryStream())
                {
                    await fileMusic.CopyToAsync(memoryStream);
                    newItem.Url = "/UploadFile/host/music/" + fileNameMusic + "-" + newItem.IdMusic.ToString() + '.' + fileTypeMusic;
                    await _blobPerformanceMusicContainer.SaveAsync(fileNameMusic + "-" + newItem.IdMusic.ToString() + '.' + fileTypeMusic, memoryStream);
                }
                return newItem;

            }
            catch (Exception)
            {
                throw new BusinessException("Error");
            }
        }

        public async Task<CreateUpdateImageStoreDto> UploadPerformanceImageFileAsync(IFormFile fileImage)
        {
            var arrFileImage = fileImage.FileName.Split(".");
            string fileTypeImage = arrFileImage[arrFileImage.Length - 1];
            var fileNameImage = Path.GetFileNameWithoutExtension(fileImage.FileName);

            CreateUpdateImageStoreDto newItem = new CreateUpdateImageStoreDto();
            newItem.FileNameImage = fileImage.FileName;
            newItem.FileTypeImage = fileImage.ContentType;
            newItem.SizeImage = fileImage.Length;
            newItem.FullNameImage = fileImage.FileName;
            newItem.IdImage = Guid.NewGuid();

            using (var memoryStream1 = new MemoryStream())
            {
                await fileImage.CopyToAsync(memoryStream1);
                newItem.UrlImage = "/UploadFile/host/music/" + fileNameImage + "-" + newItem.IdImage.ToString() + '.' + fileTypeImage;
                await _blobPerformanceMusicContainer.SaveAsync(fileNameImage + "-" + newItem.IdImage.ToString() + '.' + fileTypeImage, memoryStream1);
            }

            return newItem;
        }

        public async Task<CreateUpdateImageStoreDto> UploadPerformanceMusicMainFileAsync(IFormFile music,IFormFile image = null)
        {
            var ImageStoreDto = await UploadPerformanceMusicFileAsync(music);
            if(image != null)
            {
                var ImageOfMusic = await UploadPerformanceImageFileAsync(image);
                ImageStoreDto.FileNameImage = ImageOfMusic.FileNameImage;
                ImageStoreDto.FileTypeImage = ImageOfMusic.FileTypeImage;
                ImageStoreDto.SizeImage = ImageOfMusic.SizeImage;
                ImageStoreDto.FullNameImage = ImageOfMusic.FullNameImage;
                ImageStoreDto.UrlImage = ImageOfMusic.UrlImage;
            }
            Singer singer = new Singer();
            PerformanceMusic performance = new PerformanceMusic();
            singer.Name = ImageStoreDto.SingerName;
            var singerReturn = await _singerRepository.InsertAsync(singer);
            performance.SingerId = singerReturn.Id;
            performance.MusicFile = ImageStoreDto.Url;
            performance.SongName = ImageStoreDto.SongName;
            performance.Image = ImageStoreDto.UrlImage;
            await _performanceMusicRepository.InsertAsync(performance);
            return ImageStoreDto;
        }

        public async void UploadViewPerformanceMusicAsync(Guid id)
        {
            var performanceMusic = await _performanceMusicRepository.GetAsync(id);
            if (performanceMusic == null)
            {
                throw new BusinessException("Error");
            }
            performanceMusic.Viewed += 1;
            await _performanceMusicRepository.UpdateAsync(performanceMusic);
        }

    }
}