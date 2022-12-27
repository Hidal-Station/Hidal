using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hidal.MusicApp.PerformanceMusics.Dtos
{
    public class UploadFileMusicDto
    {
        public IFormFile Music { get; set; }
        public IFormFile Image { get; set; }
    }
}
