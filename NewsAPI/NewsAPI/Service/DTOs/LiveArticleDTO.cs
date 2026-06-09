namespace NewsAPI.Service.DTOs
{
    public class LiveArticleDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public LiveCategoryDTO Category { get; set; }
    }
}
