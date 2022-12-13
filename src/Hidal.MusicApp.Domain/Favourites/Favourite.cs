using Hidal.MusicApp.DbMigrator.AppUsers;
using Hidal.MusicApp.DbMigrator.PerformanceMusics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hidal.MusicApp.DbMigrator.Favourites
{
    public class Favourite : FullAuditedAggregateRoot<Guid>
    {
        public bool Like { get; set; }

        public Guid AppUserId { get; set; }
        public Guid PerformanceMusicId { get; set; }

        public AppUser AppUser { get; set; }
        public PerformanceMusic PerformanceMusic { get; set; }
    }
}
