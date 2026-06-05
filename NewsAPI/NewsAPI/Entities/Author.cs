namespace NewsAPI.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string AvatarUrl { get; set; }
        public string TwitterHandle { get; set; }
        //relation
        public ICollection<Article> Articles { get; set; }
    }
}
