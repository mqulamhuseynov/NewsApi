using NewsAPI.Entities;
using NewsAPI.Service.DTOs;

namespace NewsAPI.Repository.Interfaces
{
    public interface INewsRepository
    {
        Task<Article> GetFeaturedAsync();
        Task<IEnumerable<Article>> GetBreakingAsync();
        Task<(IEnumerable<Article> Items, int TotalCount)> GetArticlesAsync(string tab, int page, int limit);
        Task<Article> GetLiveAsync();
        Task<IEnumerable<Article>> GetEditorsPicksAsync();
    }
}
