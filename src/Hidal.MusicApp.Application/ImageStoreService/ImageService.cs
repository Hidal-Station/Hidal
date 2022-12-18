using AutoMapper;
using AutoMapper.Internal.Mappers;
using Hidal.MusicApp.ImageAppService;
using Hidal.MusicApp.ImageAppService.Dtos;
using Hidal.MusicApp.PerformanceMusics;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.BlobStoring;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;

namespace Hidal.MusicApp.ImageStoreService
{
    public class ImageService
    {
        private readonly IBlobContainer _blobPerformanceMusicContainer;
        private readonly IBlobContainer _blobSingerContainer;
        private readonly IBlobContainer _blobUserContainer;
        private readonly IBlobContainer _blobAuthorContainer;
        private readonly IGuidGenerator _guidGenerator;
        private readonly IPerformanceMusicRepository _performanceMusicRepository;

        public ImageService()
        {
        }

        public ImageService(IPerformanceMusicRepository performanceMusicRepository, IBlobContainerFactory blobPerformanceMusicContainer, IBlobContainerFactory blobSingerContainer, IBlobContainerFactory blobUserContainer, IBlobContainerFactory blobAuthorContainer, IGuidGenerator guidGenerator)
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
                    await _blobPerformanceMusicContainer.SaveAsync("dwa", memoryStream);
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
