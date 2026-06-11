using NewsAPI.Service.DTOs;

namespace NewsAPI.Service.Interfaces
{
    public interface INewsService
    {
        Task<FeaturedArticleDTO> GetFeatured();
        Task<IEnumerable<BreakingArticleDTO>> GetBreaking();
        Task<IEnumerable<EditorPickDTO>> GetEditorPick();
        Task<LiveArticleDTO> GetLiveArticle();
        Task<(IEnumerable<ArticleListItemDTO> Items, int TotalCount)> GetArticles(string tab, int page, int limit);
        Task<ArticleDetailDTO> GetArticleDetail(int id);
        Task<IEnumerable<RelatedArticleDTO>> GetRelatedArticles(int id, int limit);
    }
}
