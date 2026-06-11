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
        Task<Article> GetArticleDetail(int id);
        Task<IEnumerable<Article>> GetRelatedArticles(int categoryId, int excludeId, int limit);
    }
}
