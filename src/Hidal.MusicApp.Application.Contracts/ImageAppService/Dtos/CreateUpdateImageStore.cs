using System;
using System.ComponentModel.DataAnnotations;

namespace Hidal.MusicApp.ImageAppService.Dtos;

public class CreateUpdateImageStoreDto
{
    public Guid Id { get; set; }

    public string FileName { get; set; }
    public string Url { get; set; }

    public string FileType { get; set; }

    public decimal? Size { get; set; }

    public string FullName { get; set; }


}