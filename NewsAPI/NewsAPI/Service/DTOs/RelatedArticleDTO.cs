namespace NewsAPI.Service.DTOs
{
    public class RelatedArticleDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string ImageUrl { get; set; }
        public RelatedCategoryDTO Category { get; set; }
        public StatsDTO Stats { get; set; }
    }
}
