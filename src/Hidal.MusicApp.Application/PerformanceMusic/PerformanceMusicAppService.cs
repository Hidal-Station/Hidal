using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Hidal.MusicApp.DbMigrator.PerformanceMusics;
using Hidal.MusicApp.PerformanceMusics.Dtos;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Volo.Abp.BlobStoring;
using Hidal.MusicApp.ImageAppService.Dtos;
using Volo.Abp.Guids;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Volo.Abp;
using Hidal.MusicApp.Singers;
using Hidal.MusicApp.DbMigrator.Singers;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<PerformanceMusicDto>> GetMusicAsync()
        {
            var query = await _performanceMusicRepository.GetQueryableAsync();
            var listMusic = await query.Include(x => x.Singer).ToListAsync();
            var listMusic1 = ObjectMapper.Map<List<PerformanceMusic>, List<PerformanceMusicDto>>(listMusic);
            return ObjectMapper.Map<List<PerformanceMusic>,List<PerformanceMusicDto>>(listMusic);


        }

        public async Task<CreateUpdateImageStoreDto> UploadPerformanceMusicFileAsync(IFormFile file)
        {
            try
            {
                var arrFile = file.FileName.Split(".");
                string fileType = arrFile[arrFile.Length - 1];
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                int distance = 0;
                int end = 0;
                string fileName1 = fileName;
                string fileName2 = fileName;
                string songName = "";
                string singerName = "";

                for (int i =0; i < fileName1.Length; i++)
                {
                    if (fileName[i] == '-')
                    {
                        distance = i;
                        continue;
                    }
                    if(fileName[i] == '.')
                    {
                        end = i;
                        break;
                    }
                }
                songName = fileName1.Substring(0, distance);
                singerName = fileName1.Substring(end + 1);


                CreateUpdateImageStoreDto newItem = new CreateUpdateImageStoreDto();
                newItem.FileName = file.FileName;
                newItem.FileType = file.ContentType;
                newItem.Size = file.Length;
                newItem.FullName = file.FileName;
                newItem.Id = Guid.NewGuid();
                newItem.SongName = songName;
                newItem.SingerName = singerName;

                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    newItem.Url = "/UploadFile/host/music/" + fileName + "-" + newItem.Id.ToString() + '.' + fileType;
                    await _blobPerformanceMusicContainer.SaveAsync(fileName + "-" + newItem.Id.ToString() + '.' + fileType, memoryStream);
                }
                return newItem;

            }
            catch (Exception)
            {
                throw new BusinessException("Error");
            }
        }

        public async Task<CreateUpdateImageStoreDto> UploadPerformanceMusicMainFileAsync(IFormFile data)
        {
            var ImageStoreDto = await UploadPerformanceMusicFileAsync(data);
            Singer singer = new Singer();
            PerformanceMusic performance = new PerformanceMusic();
            singer.Name = ImageStoreDto.SingerName;
            var singerReturn = await _singerRepository.InsertAsync(singer);
            performance.SingerId = singerReturn.Id;
            performance.MusicFile = ImageStoreDto.Url;
            performance.SongName = ImageStoreDto.SongName;
            await _performanceMusicRepository.InsertAsync(performance);
            return ImageStoreDto;
        }
    }
}