using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsAPI.Service.DTOs;
using NewsAPI.Service.Interfaces;

namespace NewsAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetArticles([FromQuery] string tab = "latest", [FromQuery] int page = 1, [FromQuery] int limit = 4)
        {
            try
            {
                var (items, totalCount) = await _newsService.GetArticles(tab, page, limit);

                var pagination = new PaginationDTO
                {
                    TotalItems = totalCount,
                    Limit = limit,
                    CurrentPage = page,
                    TotalPages = (int)Math.Ceiling(totalCount / (double)limit)
                };

                return Ok(ApiResponse<IEnumerable<ArticleListItemDTO>>.Ok(items, pagination));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ApiResponse<IEnumerable<ArticleListItemDTO>>.Fail(ex.Message));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetBreakingArticle()
        {
            try
            {
                var data = await _newsService.GetBreaking();
                return Ok(ApiResponse<IEnumerable<BreakingArticleDTO>>.Ok(data));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<IEnumerable<BreakingArticleDTO>>.Fail(ex.Message));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetFeatured()
        {
            try
            {
                var data = await _newsService.GetFeatured();
                return Ok(ApiResponse<FeaturedArticleDTO>.Ok(data));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<FeaturedArticleDTO>.Fail(ex.Message));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetEditorsPick()
        {
            try
            {
                var data = await _newsService.GetEditorPick();
                return Ok(ApiResponse<IEnumerable<EditorPickDTO>>.Ok(data));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<IEnumerable<EditorPickDTO>>.Fail(ex.Message));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetLiveArticle()
        {
            try
            {
                var data = await _newsService.GetLiveArticle();
                return Ok(ApiResponse<LiveArticleDTO>.Ok(data));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<LiveArticleDTO>.Fail(ex.Message));
            }
        }
    }
}
