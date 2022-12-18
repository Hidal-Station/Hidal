using Hidal.MusicApp.DbMigrator.Authors;
using Hidal.MusicApp.DbMigrator.PerformanceMusics;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Hidal.MusicApp.PerformanceMusics
{
    public interface IPerformanceMusicRepository : IRepository<PerformanceMusic, Guid>
    {

    }
}