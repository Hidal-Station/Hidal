using System;
using Hidal.MusicApp.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Hidal.MusicApp.DbMigrator.PerformanceMusics;
using Hidal.MusicApp.PerformanceMusics;

namespace Hidal.MusicApp.Authors
{
    public class PerformanceMusicRepository : EfCoreRepository<MusicAppDbContext, PerformanceMusic, Guid>, IPerformanceMusicRepository
    {
        public PerformanceMusicRepository(IDbContextProvider<MusicAppDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}