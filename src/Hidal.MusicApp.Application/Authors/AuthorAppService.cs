using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Hidal.MusicApp.DbMigrator.Authors;
using Hidal.MusicApp.Authors.Dtos;
using Volo.Abp.Domain.Repositories;
using System.Threading.Tasks;
using Hidal.MusicApp.ImageAppService.Dtos;
using Microsoft.AspNetCore.Http;
using Hidal.MusicApp.ImageAppService;
using Hidal.MusicApp.ImageStoreService;
using Hidal.MusicApp.PerformanceMusics;

namespace Hidal.MusicApp.Authors
{
    public class AuthorAppService :
        CrudAppService<
            Author,
            AuthorDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateAuthorDto
            >, IAuthorAppService
    {
        private readonly IPerformanceMusicAppService _performanceMusicApp;
        public AuthorAppService(IAuthorRepository repository, IPerformanceMusicAppService performanceMusicAppService) : base(repository)
        {
            _performanceMusicApp = performanceMusicAppService;
        }

        public async Task<CreateUpdateImageStoreDto> uploadTest(IFormFile file)
        {
            return await _performanceMusicApp.UploadPerformanceMusicFileAsync(file);
        }
    }
}