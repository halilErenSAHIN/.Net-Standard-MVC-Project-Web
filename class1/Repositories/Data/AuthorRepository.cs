using Core.Abstracts.Repositories.Data;
using Core.Concrates.Entities.Data;
using System.Data.Entity;
using ToolBox.DataTools;

namespace Data.Repositories.Data
{
    public class AuthorRepository : GenericRepository<AuthorEntity>, IAuthorRepository
    {
        public AuthorRepository(DbContext context) : base(context)
        {
        }
    }
}
