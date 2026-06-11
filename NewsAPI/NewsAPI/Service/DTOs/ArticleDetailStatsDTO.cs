namespace NewsAPI.Service.DTOs
{
    public class ArticleDetailStatsDTO
    {
        public int LikesCount { get; set; }
        public int CommentsCount { get; set; }
        public int BookmarksCount { get; set; }
        public int SharesCount { get; set; }
    }
}
