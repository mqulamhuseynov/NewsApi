namespace NewsAPI.Service.DTOs
{
    public class PaginationDTO
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
        public int Limit  { get; set; }
    }
}
