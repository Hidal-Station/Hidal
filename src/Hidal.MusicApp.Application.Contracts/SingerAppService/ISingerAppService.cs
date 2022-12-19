using Hidal.MusicApp.SingerAppService.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Hidal.MusicApp.SingerAppService
{
    public interface ISingerAppService: ICrudAppService<
          SingerDto,
          Guid,
          PagedAndSortedResultRequestDto,
          SingerDto
          >
    {
    }
}
