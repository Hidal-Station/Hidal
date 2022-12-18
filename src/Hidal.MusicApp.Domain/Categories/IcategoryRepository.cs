using Hidal.MusicApp.DbMigrator.Categories;
using Hidal.MusicApp.DbMigrator.Singers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Hidal.MusicApp.Categories
{
    public interface IcategoryRepository : IRepository<Category, Guid>
    {
    }
}
