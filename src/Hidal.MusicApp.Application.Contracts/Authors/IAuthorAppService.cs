using Hidal.MusicApp.Authors.Dtos;
using Hidal.MusicApp.ImageAppService.Dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Hidal.MusicApp.Authors
{
    public interface IAuthorAppService :
       ICrudAppService<
          AuthorDto,
          Guid,
          PagedAndSortedResultRequestDto,
          CreateUpdateAuthorDto
          >
    {
    }
}