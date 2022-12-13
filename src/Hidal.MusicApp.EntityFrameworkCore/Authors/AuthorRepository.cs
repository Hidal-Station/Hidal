using System;
using Hidal.MusicApp.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Hidal.MusicApp.DbMigrator.Authors;

namespace Hidal.MusicApp.Authors
{
    public class AuthorRepository : EfCoreRepository<MusicAppDbContext, Author, Guid>, IAuthorRepository
    {
        public AuthorRepository(IDbContextProvider<MusicAppDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}