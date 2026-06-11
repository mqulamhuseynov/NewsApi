namespace NewsAPI.Service.DTOs
{
    public class ArticleDetailDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } 
        public string ShortDescription { get; set; }
        public string ImageUrl { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ReadTimeMinutes { get; set; }
        public bool IsTrending { get; set; }
        public bool IsBreaking { get; set; }
        public bool IsLive { get; set; }
       public CategoryDTO Category { get; set; }
        public ArticleDetailAuthorDTO Author { get; set; }
        public ArticleDetailStatsDTO Stats { get; set; }
    }
}
