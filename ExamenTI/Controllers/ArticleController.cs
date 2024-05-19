using ExamenTI.Business.DTOs;
using ExamenTI.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExamenTI.Controllers
{
    [Route("api/Article")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleServices _articleServices;
        public ArticleController(IArticleServices articleServices) { 
            _articleServices = articleServices;
        }

        [AllowAnonymous]
        [ResponseCache(CacheProfileName = "Default20seconds")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("GetAllArticle/")]
        public IActionResult GetAllArticle()
        {
            var response = _articleServices.GetAllArticles();
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpGet("GetArticleById/{articleId:int}", Name = "GetArticleById")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetArticleById(int articleId)
        {
            var response = _articleServices.GetArticleById(articleId);
            return Ok(response);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("AddArticle/")]
        [ProducesResponseType(201, Type = typeof(ArticleDto))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AddArticle([FromBody] CreateArticleDto createArticleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (createArticleDto == null)
            {
                return BadRequest(ModelState);
            }

            if (_articleServices.ExistArticleByName(createArticleDto.Code))
            {
                ModelState.AddModelError("", "Exist already Article's Name same");
                return StatusCode(404, ModelState);
            }

            var Article = _articleServices.AddArticle(createArticleDto);
            if (Article == null)
            {
                ModelState.AddModelError("", $"Ocurrio un problema al guardar el Article{createArticleDto.Code}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetArticleById", new { articleId = Article.Id }, Article);
        }

        [Authorize(Roles = "admin")]
        [HttpPatch("UpdatePatchArticle/{articleId:int}", Name = "UpdatePatchArticle")]
        [ProducesResponseType(201, Type = typeof(ArticleDto))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePatchArticle(int articleId, [FromBody] ArticleDto ArticleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (ArticleDto == null || articleId != ArticleDto.Id)
            {
                return BadRequest(ModelState);
            }

            var Article = _articleServices.UpdateArticle(ArticleDto);
            if (Article == null)
            {
                ModelState.AddModelError("", $"Ocurrio un problema en actualizar el Article{ArticleDto.Code}");
            }

            return NoContent();
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("DeleteArticle/{ArticleId:int}", Name = "DeleteArticle")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteArticle(int ArticleId)
        {
            if (!_articleServices.ExistArticleById(ArticleId))
            {
                return NotFound();
            }

            var Article = _articleServices.GetArticleById(ArticleId);
            if (Article != null && !_articleServices.DeleteArticle(Article))
            {
                ModelState.AddModelError("", $"Ocurrio un problema al borrar el Articlee{Article.Code}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
