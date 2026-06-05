namespace NewsAPI.Entities
{
    public class ArticleStats
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public int Likes { get; set; }
        public int Bookmarks { get; set; }
        public int Shares { get; set; }
        public int Comments { get; set; }

        public Article Article { get; set; }
    }
}
