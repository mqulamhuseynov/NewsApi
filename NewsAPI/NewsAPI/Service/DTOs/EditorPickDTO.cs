namespace NewsAPI.Service.DTOs
{
    public class EditorPickDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public EditorPickCategoryDTO Category { get; set; }
        public StatsDTO Stats { get; set; }
    }
}
