using Microsoft.EntityFrameworkCore;
using NewsAPI.Data;
using NewsAPI.Entities;
using NewsAPI.Repository.Interfaces;
using NewsAPI.Service.DTOs;

namespace NewsAPI.Repository.Implementations
{
    public class NewsRepository : INewsRepository
    {
        private readonly AppDbContext _context;

        public NewsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Article> GetFeaturedAsync()
        {
            return await _context.Articles
                .Include(a => a.Category)
                .Include(a => a.Author)
                .Include(a => a.ArticleStats)
                .Where(a => a.IsFeatured)
                .OrderByDescending(a => a.CreatedAt)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Article>> GetBreakingAsync()
        {
            return await _context.Articles
                .Where(a => a.IsBreaking)
                .ToListAsync();
        }

        public async Task<(IEnumerable<Article> Items, int TotalCount)> GetArticlesAsync(
            string tab, int page, int limit)
        {
            var query = _context.Articles
                .Include(a => a.Category)
                .Include(a => a.Author)
                .Include(a => a.ArticleStats)
                .AsQueryable();

            if (tab != "latest")
                query = query.Where(a => a.Category.Slug == tab);

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(a => a.CreatedAt)
                .Skip((page - 1) * limit)
                .Take(limit)
                .ToListAsync();

            return (items, totalCount);
        }

        public async Task<Article> GetLiveAsync()
        {
            return await _context.Articles
                .Include(a => a.Category)
                .Where(a => a.IsLive)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Article>> GetEditorsPicksAsync()
        {
            return await _context.Articles
                .Include(a => a.Category)
                .Include(a => a.ArticleStats)
                .Where(a => a.IsEditorsPick)
                .ToListAsync();
        }

    }
}
