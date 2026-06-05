
namespace NewsAPI.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Slug { get; set; }
        public string BadgeColor { get; set; }

        //relation
        public ICollection<Article> Articles { get; set; }

    }
}
