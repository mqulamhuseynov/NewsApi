namespace NewsAPI.Service.DTOs
{
    public class FeaturedArticleDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ReadTimeMinutes { get; set; }
        public bool IsTrending { get; set; }
        public CategoryDTO Category { get; set; }
        public AuthorDTO Author { get; set; }
        public StatsDTO Stats { get; set; }
    }
}
