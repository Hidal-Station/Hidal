using Hidal.MusicApp.DbMigrator.Singers;
using Hidal.MusicApp.DbMigrator.Songs;
using Hidal.MusicApp.EntityFrameworkCore;
using Hidal.MusicApp.Singers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hidal.MusicApp.Songs
{
    public class SongRepository : EfCoreRepository<MusicAppDbContext, Song, Guid>,IsongRepository
    {
        public SongRepository(IDbContextProvider<MusicAppDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
