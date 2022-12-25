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

        Task<CreateUpdateImageStoreDto> UploadPerformanceMusicMainFileAsync(IFormFile data);

        Task<List<PerformanceMusicDto>> GetMusicAsync();

        Task<PerformanceMusicDto> RatingAsync(RatingPerformanceMusicDtos ratingDto);

        Task IncreaseViewAsync(Guid id);

        void ViewMusicAsync(Guid id);
    }
}