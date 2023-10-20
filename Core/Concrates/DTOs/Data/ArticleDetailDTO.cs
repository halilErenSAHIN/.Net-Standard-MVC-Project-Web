using Core.Concrates.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concrates.DTOs.Data
{
    public class ArticleDetailDTO
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }
        public ArticleTypes ArticleType { get; set; }
        public string FeatureMedia { get; set; }
        public string AuthorName { get; set; }
        public string AuthorId { get; set; }
        public IEnumerable<MediaDTO> Gallery { get; set; }




    }
}
