using Hidal.MusicApp.DbMigrator.Songs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hidal.MusicApp.DbMigrator.Categories
{
    public class Category : FullAuditedAggregateRoot<Guid>

    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Song> Songs { get; set; }
    }
}
