using System;
using Volo.Abp.Application.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Hidal.MusicApp.PerformanceMusics.Dtos
{
    public class CreateUpdatePerformanceMusicDto
    {
        public string Description { get; set; }
        [Required]
        public string ImageMusic { get; set; }
        [Required]
        public string MusicFile { get; set; }

        [Required]
        public string SingerImage { get; set; }

        public string SingerName { get; set; }

        public string SingerStory { get; set; }

        public string SongName { get; set; }

        public string SongDescription { get; set; }

        public string AuthorImage { get; set; }

        public string AuthorName { get; set; }

        public string AuthorAge{ get; set; }

    }
}