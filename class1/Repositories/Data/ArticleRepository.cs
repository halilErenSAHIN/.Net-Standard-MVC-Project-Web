using Core.Abstracts.Repositories.Data;
using Core.Concrates.Entities.Data;
using System.Data.Entity;
using ToolBox.DataTools;

namespace class1.Repositories.Data
{
    public class ArticleRepository : GenericRepository<ArticleEntity>, IArticleRepository
    {
        public ArticleRepository(DbContext context) : base(context)
        {
        }
    }
}
