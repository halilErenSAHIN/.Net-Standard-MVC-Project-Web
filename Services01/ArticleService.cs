
using class1.Repositories.Data;
using Core.Abstracts.Repositories.Data;
using Core.Abstracts.Services.Data;
using Core.Concrates.DTOs.Data;
using Core.Concrates.Entities.Data;
using Data;
using Data.Repositories.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ToolBox;



namespace Services01
{
    public class ArticleService : IArticleService
    {
        private DataContext _context;
        private ArticleRepository article;
        private AuthorRepository author;
        private GalleryRepository gallery;
        private MediaRepository media;
        private static IArticleService articleService;

        public ArticleService()
        {
            _context = DataContext.Create();
        }
        public ArticleService(DataContext context)
        {
            _context = context;
        }
        public static IArticleService Create()
        {
            if (articleService == null)
            {
                articleService = new ArticleService();
            }
            return articleService;
        }



        public IArticleRepository ArticleRepository
        {
            get
            {
                article = article ?? new ArticleRepository(_context);
                return article;

            }
        }

        public IAuthorRepository AuthorRepository => author = author ?? new AuthorRepository(_context);

        public IGalleryRepository GalleryRepository => gallery = gallery ?? new GalleryRepository(_context);

        public IMediaRepository MediaRepository => media = media ?? new MediaRepository(_context);
        public void DislikeArticle(string id, string user_id)
        {
            throw new NotImplementedException();
        }
        public async Task<ArticleDetailDTO> GetArticle(string id)
        {
            var a = await ArticleRepository.FindAsync(id);
            if (a != null)
            {
                var result = new ArticleDetailDTO()
                {
                    Id = a.Id,
                    Title = a.Title,
                    SubTitle = a.SubTitle,
                    ArticleType = a.ArticleType,
                    AuthorName = a.Author.Title,
                    AuthorId = a.AuthorId,
                    FeatureMedia = a.FeatureMedia,
                    PublishDate = (DateTime)a.PublishDate,
                    Description = a.Description,
                };

                result.Gallery = from m in await MediaRepository.FindAsync(x => x.GalleryId == a.ContentId && x.Active && !x.Deleted)
                                 select new MediaDTO()
                                 {
                                     Path = m.Path,
                                     Type = m.MediaType
                                 };
                return result;


            }
            return null;

        }
        public async Task<IEnumerable<ArticleListDTO>> GetArticles()
        {
            var article_data = await ArticleRepository.FindAsync(x => x.Active && !x.Deleted && !x.Draft && x.PublishDate != null, "Author");

            var result = from a in article_data
                         select new ArticleListDTO


                         {
                             Id = a.Id,
                             Title = a.Title,
                             SubTitle = a.SubTitle,
                             ArticleType = a.ArticleType,
                             AuthorName = a.Author.Title,
                             AuthorId = a.AuthorId,
                             FeatureMedia = a.FeatureMedia,
                             PublishDate = (DateTime)a.PublishDate,

                         };
            return result;
        }


        public void LikeArticle(string id, string user_id)
        {
            throw new NotImplementedException();
        }

        public void MakeComment(string id, string user_id)
        {
            throw new NotImplementedException();
        }

        public void RemoveComment(string comment_id, string user_id)
        {
            throw new NotImplementedException();
        }

        public void ReportComment(string comment_id, string user_id)
        {
            throw new NotImplementedException();
        }

        public async Task AddAuthor(AuthorDTO author, string uid)
        {
            AuthorEntity entity = new AuthorEntity
            {
                Title = author.Name,
                UserId = uid
            };
            await AuthorRepository.CreateAsync(entity); //yanlış kütüphaneden alıyor sanırım ama çözemedim.
            await CommitAsync();
        }

        private async Task CommitAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                _context.Dispose();
            }

        }

        public IEnumerable<ArticleListDTO> GetArticles(Expression<Func<ArticleListDTO, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public async Task<Pagination<ArticleListDTO>> GetPagedArticles(int page, int per_page)
        {
            IQueryable<ArticleListDTO> data = (await GetArticles()).AsQueryable();
            return new Pagination<ArticleListDTO>(data, page, per_page);
        }
    }
    
}
