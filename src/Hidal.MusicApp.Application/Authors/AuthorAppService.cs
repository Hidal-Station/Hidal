using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Hidal.MusicApp.DbMigrator.Authors;
using Hidal.MusicApp.Authors.Dtos;
using Volo.Abp.Domain.Repositories;

namespace Hidal.MusicApp.Authors
{
    public class AuthorAppService :
        CrudAppService<
            Author,
            AuthorDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateAuthorDto
            >, IAuthorAppService
    {

        public AuthorAppService(IRepository<Author, Guid> repository) : base(repository)
        {
        }
    }
}