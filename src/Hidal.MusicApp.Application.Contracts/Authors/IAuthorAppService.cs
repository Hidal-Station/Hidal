using Hidal.MusicApp.Authors.Dtos;
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