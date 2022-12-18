using Hidal.MusicApp.DbMigrator.Singers;
using Hidal.MusicApp.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hidal.MusicApp.Singers
{
    public class SingerRepository : EfCoreRepository<MusicAppDbContext, Singer, Guid>, ISingerRepository
    {
        public SingerRepository(IDbContextProvider<MusicAppDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
