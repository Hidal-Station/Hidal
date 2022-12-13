using System;
using System.Collections.Generic;
using Hidal.MusicApp.DbMigrator.Authors;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Hidal.MusicApp.DbMigrator.Categories;
using Hidal.MusicApp.DbMigrator.PerformanceMusics;

namespace Hidal.MusicApp.DbMigrator.Songs
{
    public class Song : FullAuditedAggregateRoot<Guid>

    {
        public string Description { get; set; }
        public string Name { get; set; }

        public Guid AuthorId { get; set; }
        public Guid CategoryId { get; set; }
        public Author Author { get; set; }

        public Category Category { get; set; }

        public ICollection<PerformanceMusic> PerformanceMusics { get; set; }
    }
}
