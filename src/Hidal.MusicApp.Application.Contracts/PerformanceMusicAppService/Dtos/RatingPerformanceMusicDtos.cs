using System;
using Volo.Abp.Application.Dtos;
using System.Collections.Generic;
using System.Text;

namespace Hidal.MusicApp.PerformanceMusics.Dtos
{
    public class RatingPerformanceMusicDtos
    {
        public Guid Id { get; set; }
        public int Score { get; set; }
    }
}
