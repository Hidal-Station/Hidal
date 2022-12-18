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
        public PerformanceMusicAppService(IPerformanceMusicRepository  performanceMusicRepository, IBlobContainerFactory blobPerformanceMusicContainer, IBlobContainerFactory blobSingerContainer, IBlobContainerFactory blobUserContainer, IBlobContainerFactory blobAuthorContainer, IGuidGenerator guidGenerator) : base(performanceMusicRepository)
        {
            _blobPerformanceMusicContainer = blobPerformanceMusicContainer.Create("music");
            _blobSingerContainer = blobSingerContainer.Create("Singer");
            _blobUserContainer = blobUserContainer.Create("User");
            _blobAuthorContainer = blobAuthorContainer.Create("Author");
            _guidGenerator = guidGenerator;
            _performanceMusicRepository = performanceMusicRepository;
        }


        public async Task<CreateUpdateImageStoreDto> UploadPerformanceMusicFileAsync(IFormFile file)
        {
            try
            {
                var arrFile = file.FileName.Split(".");
                string fileType = arrFile[arrFile.Length - 1];
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);

                CreateUpdateImageStoreDto newItem = new CreateUpdateImageStoreDto();
                newItem.FileName = file.FileName;
                newItem.FileType = file.ContentType;
                newItem.Size = file.Length;
                newItem.FullName = file.FileName;
                newItem.Id = Guid.NewGuid();

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



    }
}