using Core.Abstracts.Repositories.Data;
using Core.Concrates.DTOs.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ToolBox;

namespace Core.Abstracts.Services.Data
{
    public interface IArticleService
    {
        IArticleRepository ArticleRepository { get; }
        IAuthorRepository AuthorRepository { get; }
        IGalleryRepository GalleryRepository { get; }
        IMediaRepository MediaRepository { get; }

        Task<IEnumerable<ArticleListDTO>> GetArticles();
        Task<Pagination<ArticleListDTO>> GetPagedArticles(int page, int per_page);
        Task<ArticleDetailDTO> GetArticle(string id);
        Task AddAuthor(AuthorDTO author, string uid);

        void LikeArticle(string id, string user_id);
        void DislikeArticle(string id, string user_id);
        void MakeComment(string id, string user_id);
        void RemoveComment(string comment_id, string user_id);
        void ReportComment(string comment_id, string user_id);
        IEnumerable<ArticleListDTO> GetArticles(Expression<Func<ArticleListDTO, bool>> expression = null);
    }
}
