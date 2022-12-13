using Hidal.MusicApp.DbMigrator.Songs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hidal.MusicApp.DbMigrator.Authors
{
    public class Author : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Image { get; set; }

        public ICollection<Song> Songs { get; set; }

    }
}
