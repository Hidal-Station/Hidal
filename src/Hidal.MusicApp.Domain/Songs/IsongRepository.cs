using Hidal.MusicApp.DbMigrator.Singers;
using Hidal.MusicApp.DbMigrator.Songs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Hidal.MusicApp.Songs
{
    public interface IsongRepository : IRepository<Song, Guid>
    {
    }
}
