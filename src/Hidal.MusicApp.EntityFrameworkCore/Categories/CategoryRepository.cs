using Hidal.MusicApp.Authors;
using Hidal.MusicApp.DbMigrator.Authors;
using Hidal.MusicApp.DbMigrator.Categories;
using Hidal.MusicApp.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hidal.MusicApp.Categories
{
    public class CategoryRepository : EfCoreRepository<MusicAppDbContext, Category, Guid>, IcategoryRepository
    {
        public CategoryRepository(IDbContextProvider<MusicAppDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
