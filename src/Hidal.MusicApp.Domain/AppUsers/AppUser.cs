using Hidal.MusicApp.DbMigrator.Comments;
using Hidal.MusicApp.DbMigrator.Favourites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hidal.MusicApp.DbMigrator.AppUsers
{
    public class AppUser : FullAuditedAggregateRoot<Guid>

    {
        public string UserName { get; set; }

        public int Rule { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Image { get; set; }

        public ICollection<Favourite> Favourites { get; set; }

        public ICollection<Comment> Comments { get; set; }

    }
}
