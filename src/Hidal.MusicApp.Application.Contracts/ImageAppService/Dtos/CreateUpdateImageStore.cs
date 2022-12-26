using System;
using System.ComponentModel.DataAnnotations;

namespace Hidal.MusicApp.ImageAppService.Dtos;

public class CreateUpdateImageStoreDto
{
    public Guid IdMusic { get; set; }

    public Guid IdImage { get; set; }

    public string FileNameMusic { get; set; }

    public string SingerName { get; set; }

    public string SongName { get; set; }
    public string UrlImage { get; set; }
    public string Url { get; set; }

    public string FileTypeImage { get; set; }

    public decimal? SizeImage { get; set; }

    public string FullNameImage { get; set; }

    public string FileNameImage { get; set; }

    public string FileTypeMusic { get; set; }

    public decimal? SizeMusic { get; set; }

    public string FullNameMusic { get; set; }

}