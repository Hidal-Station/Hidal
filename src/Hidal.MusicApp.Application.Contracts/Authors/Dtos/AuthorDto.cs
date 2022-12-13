using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Hidal.MusicApp.Authors.Dtos
{
    public class AuthorDto : FullAuditedEntityDto<Guid>
    {

        public string Image { get; set; }
        public string Name { get; set; }
        public int age { get; set; }
    }
}