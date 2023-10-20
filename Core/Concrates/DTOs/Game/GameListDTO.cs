using Core.Concrates.Enums;
using System.Collections.Generic;

namespace Core.Concrates.DTOs.Game
{
    public class GameListDTO
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string FeatureMedia { get; set; }
        public string Logo { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public IEnumerable<string> PlatformIcons { get; set; }
        public Ratings Rating { get; set; }
        public Status Status { get; set; }

    }

    public class GameDetailDTO
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string FeaturedMedia { get; set; }
        public string Logo { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public ICollection<string> Platforms { get; set; }
        public Ratings Rating { get; set; }
        public Status Status { get; set; }
        public ICollection<string> Genres { get; set; }

    }
}
