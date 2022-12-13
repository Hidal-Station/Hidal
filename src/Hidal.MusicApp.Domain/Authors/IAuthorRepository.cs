using Hidal.MusicApp.DbMigrator.Authors;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Hidal.MusicApp.Authors
{
    public interface IAuthorRepository : IRepository<Author, Guid>
    {
    }
}