using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Hidal.MusicApp.ImageAppService.Dtos;

namespace Hidal.MusicApp.ImageAppService
{
    public interface IImageAppService: ITransientDependency
    {
        Task<CreateUpdateImageStoreDto> UploadPerformanceMusicFileAsync(IFormFile formFile);
    }
}
