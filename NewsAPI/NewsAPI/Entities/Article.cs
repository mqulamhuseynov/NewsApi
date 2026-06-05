namespace NewsAPI.Entities
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public int ReadTimeMinutes { get; set; }
        public bool IsTrending { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsBreaking { get; set; }
        public bool IsEditorsPick { get; set; }
        public bool IsLive  { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        //relation
        public Category Category { get; set; }

        public ArticleStats ArticleStats { get; set; }
        public Author Author { get; set; }
    }
}
