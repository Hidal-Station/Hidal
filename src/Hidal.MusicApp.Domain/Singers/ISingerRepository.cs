using Hidal.MusicApp.DbMigrator.Authors;
using Hidal.MusicApp.DbMigrator.Singers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Hidal.MusicApp.Singers
{
  public interface ISingerRepository : IRepository<Singer, Guid>
  {

  }
}
