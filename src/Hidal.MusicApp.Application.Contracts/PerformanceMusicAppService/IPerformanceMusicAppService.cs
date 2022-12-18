using Hidal.MusicApp.Authors.Dtos;
using Hidal.MusicApp.ImageAppService.Dtos;
using Hidal.MusicApp.PerformanceMusics.Dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Hidal.MusicApp.PerformanceMusics
{
    public interface IPerformanceMusicAppService :
       ICrudAppService<
          PerformanceMusicDto,
          Guid,
          PagedAndSortedResultRequestDto,
          CreateUpdatePerformanceMusicDto
          >
    {
        Task<CreateUpdateImageStoreDto> UploadPerformanceMusicFileAsync(IFormFile file);
        
    }
}