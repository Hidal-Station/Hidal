using Hidal.MusicApp.SingerAppService.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Hidal.MusicApp.SongAppService
{
    public interface ISongAppService : ICrudAppService<
          SingerDto,
          Guid,
          PagedAndSortedResultRequestDto,
          SingerDto
          >
    {

    }
}
