using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Hidal.MusicApp.PerformanceMusics.Dtos
{
    public class PerformanceMusicDto : FullAuditedEntityDto<Guid>
    {

        public string Description { get; set; }
        public string Image { get; set; }
        public string MusicFile { get; set; }
    }
}