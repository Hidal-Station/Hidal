using AutoMapper;
using Hidal.MusicApp.Authors.Dtos;
using Hidal.MusicApp.DbMigrator.Authors;
using Hidal.MusicApp.DbMigrator.PerformanceMusics;
using Hidal.MusicApp.PerformanceMusics.Dtos;

namespace Hidal.MusicApp;

public class MusicAppApplicationAutoMapperProfile : Profile
{
    public MusicAppApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Author, AuthorDto>();
        CreateMap<CreateUpdateAuthorDto, Author>();
        CreateMap<PerformanceMusic, PerformanceMusicDto>()
        .ForMember(x => x.SingerName, y => y.MapFrom(src => src.Singer.Name));
    }
}
