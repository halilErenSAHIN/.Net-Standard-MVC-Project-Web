using Core.Concrates.Enums;
using System;

namespace Core.Concrates.DTOs.Data
{
    public class ArticleListDTO
    {

        public string Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public DateTime PublishDate { get; set; }
        public ArticleTypes ArticleType { get; set; }
        public string FeatureMedia { get; set; }
        public string AuthorName { get; set; }
        public string AuthorId { get; set; }
    }
}
