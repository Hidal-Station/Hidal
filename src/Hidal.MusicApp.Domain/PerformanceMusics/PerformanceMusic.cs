using Hidal.MusicApp.DbMigrator.Comments;
using Hidal.MusicApp.DbMigrator.Favourites;
using Hidal.MusicApp.DbMigrator.Singers;
using Hidal.MusicApp.DbMigrator.Songs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.BlobStoring.Database;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Modularity;

namespace Hidal.MusicApp.DbMigrator.PerformanceMusics
{
    public class PerformanceMusic : FullAuditedAggregateRoot<Guid>
    {
        public string Description { get; set; }
        public string Image { get; set; }
        public string MusicFile { get; set; }

        public DateTime DebutDay { get; set; }

        public Guid SingerId { get; set; }
        public Guid SongId { get; set; }
        public Singer Singer { get; set; }
        public Song Song { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Favourite> Favourites { get; set; }
    }
}
