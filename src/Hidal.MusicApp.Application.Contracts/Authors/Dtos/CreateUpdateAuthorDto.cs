using System;
using Volo.Abp.Application.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Hidal.MusicApp.Authors.Dtos
{
    public class CreateUpdateAuthorDto
    {
        [Required]
        public string Image { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
    }
}