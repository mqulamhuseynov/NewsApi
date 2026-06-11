using NewsAPI.Entities;
using NewsAPI.Repository.Interfaces;
using NewsAPI.Service.DTOs;
using NewsAPI.Service.Interfaces;

namespace NewsAPI.Service.Implementations
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository _newsRepository;
        public NewsService(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task<ArticleDetailDTO> GetArticleDetail(int id)
        {
            var article = await _newsRepository.GetArticleDetail(id);
            if (article == null) throw new KeyNotFoundException($"Article with ID-{id} not found");

            return new ArticleDetailDTO
            {
             Id = article.Id,
             Title = article.Title,
             ShortDescription = article.ShortDescription,
             ImageUrl = article.ImageUrl,
             Content = article.Content,
             CreatedAt = article.CreatedAt,
             ReadTimeMinutes = article.ReadTimeMinutes,
             IsTrending = article.IsTrending,
             IsBreaking = article.IsBreaking,
             IsLive = article.IsLive,
                Category = new CategoryDTO
                {
                    Id = article.Category.Id,
                    Name = article.Category.Name,
                    Slug = article.Category.Slug,
                    BadgeColor = article.Category.BadgeColor
                },
                Author = new ArticleDetailAuthorDTO
                {
                    Id = article.Author.Id,
                    Name = article.Author.Name,
                    Bio = article.Author.Bio,
                    AvatarUrl = article.Author.AvatarUrl,
                    TwitterHandle = article.Author.TwitterHandle

                },
                Stats = new ArticleDetailStatsDTO
                {
                    LikesCount = article.ArticleStats.Likes,
                    CommentsCount = article.ArticleStats.Comments,
                    BookmarksCount = article.ArticleStats.Bookmarks,
                    SharesCount = article.ArticleStats.Shares
                }
            };

        }
        public async Task<(IEnumerable<ArticleListItemDTO> Items, int TotalCount)> GetArticles(string tab, int page, int limit)
        {
            if(page < 1) throw new ArgumentException("Page number must be greater than 0", nameof(page));

            if(limit < 1 || limit >= 20) throw new ArgumentException("Limit must be between (1,21]", nameof(limit));

            var (articles, totalCount) = await _newsRepository.GetArticlesAsync(tab, page, limit);
            return (articles.Select(a => new ArticleListItemDTO
            {
                Id = a.Id,
                Title = a.Title,
                ShortDescription = a.ShortDescription,
                ImageUrl = a.ImageUrl,
                CreatedAt = a.CreatedAt,
                ReadTimeMinutes = a.ReadTimeMinutes,
                Category = new CategoryDTO
                {
                    Id = a.Category.Id,
                    Name = a.Category.Name,
                    Slug = a.Category.Slug,
                    BadgeColor = a.Category.BadgeColor
                },
                Author = new AuthorDTO
                {
                    Id = a.Author.Id,
                    Name = a.Author.Name
                },
                Stats = new StatsDTO
                {
                    LikesCount = a.ArticleStats.Likes,
                    CommentsCount = a.ArticleStats.Comments,
                    BookmarksCount = a.ArticleStats.Bookmarks
                }
            }), totalCount);    
        }

        public async Task<IEnumerable<BreakingArticleDTO>> GetBreaking()
        {
            var article = await _newsRepository.GetBreakingAsync();

            if (article == null)
            {
                throw new Exception("Breaking news not found");
            }

            return article.Select(a => new BreakingArticleDTO
            {
                Id = a.Id,
                Title = a.Title
            });
        }

        public async Task<IEnumerable<EditorPickDTO>> GetEditorPick()
        {
            var articles = await _newsRepository.GetEditorsPicksAsync();

            if(articles == null) throw new Exception("Editor picks not found");

            return articles.Select(a => new EditorPickDTO
            {
               Id= a.Id,
               Title = a.Title,
               ImageUrl = a.ImageUrl,
               Category = new EditorPickCategoryDTO
               {
                   Id = a.Category.Id,
                   Name = a.Category.Name,
                   BadgeColor = a.Category.BadgeColor
               },
               Stats = new StatsDTO
                {
                     LikesCount = a.ArticleStats.Likes,
                     CommentsCount = a.ArticleStats.Comments,
                     BookmarksCount = a.ArticleStats.Bookmarks
               }
            });
        }

        public async Task<FeaturedArticleDTO> GetFeatured()
        {
            var article = await _newsRepository.GetFeaturedAsync();

            if(article == null) throw new Exception("Featured article not found");

            return new FeaturedArticleDTO
            {
                Id = article.Id,
                Title = article.Title,
                ShortDescription = article.ShortDescription,
                ImageUrl = article.ImageUrl,
                CreatedAt = article.CreatedAt,
                ReadTimeMinutes = article.ReadTimeMinutes,
                IsTrending = article.IsTrending,
                Category = new CategoryDTO
                {
                    Id = article.Category.Id,
                    Name = article.Category.Name,
                    Slug = article.Category.Slug,
                    BadgeColor = article.Category.BadgeColor
                },
                Author = new AuthorDTO
                {
                    Id = article.Author.Id,
                    Name = article.Author.Name
                },
                Stats = new StatsDTO
                {
                    LikesCount = article.ArticleStats.Likes,
                    CommentsCount = article.ArticleStats.Comments,
                    BookmarksCount = article.ArticleStats.Bookmarks
                }
            };
        }

        public async Task<LiveArticleDTO> GetLiveArticle()
        {
            var article = await _newsRepository.GetLiveAsync();

            if (article == null)
            {
                throw new Exception("Live article not found");
            }

            return new LiveArticleDTO
            {
                Id = article.Id,
                Title = article.Title,
                ImageUrl = article.ImageUrl,
                Category = new LiveCategoryDTO
                {
                    Name = article.Category.Name
                }
            };
        }

        public async Task<IEnumerable<RelatedArticleDTO>> GetRelatedArticles(int id, int limit = 5)
        {
            var article = await _newsRepository.GetArticleDetail(id);
            if (article == null) throw new KeyNotFoundException($"Article with ID-{id} not found");

            var relatedArticles = await _newsRepository.GetRelatedArticles(article.CategoryId, id, limit);

            return relatedArticles.Select(a => new RelatedArticleDTO
            {
                Id = a.Id,
                Title = a.Title,
                ShortDescription = a.ShortDescription,
                ImageUrl = a.ImageUrl,
                Category = new RelatedCategoryDTO
                {
                    Id = a.Category.Id,
                    Name = a.Category.Name,
                    BadgeColor = a.Category.BadgeColor
                },
                Stats = new StatsDTO
                {
                    LikesCount = a.ArticleStats.Likes,
                    CommentsCount = a.ArticleStats.Comments,
                    BookmarksCount = a.ArticleStats.Bookmarks
                }

            });
        }
    }
}
