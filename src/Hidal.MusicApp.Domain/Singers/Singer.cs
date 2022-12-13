using Hidal.MusicApp.DbMigrator.PerformanceMusics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hidal.MusicApp.DbMigrator.Singers
{
    public class Singer : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Story { get; set; }

        public string Image { get; set; }

        public ICollection<PerformanceMusic> PerformanceMusics { get; set; }
    
    }
}
