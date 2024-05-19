using AutoMapper;
using ExamenTI.Business.DTOs;
using ExamenTI.Business.Interfaces;
using ExamenTI.DataAccess.Entities;
using ExamenTI.DataAccess.Repository;
using ExamenTI.DataAccess.Repository.IRepository;

namespace ExamenTI.Business.Services
{
    public class ArticleServices : IArticleServices
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IMapper _mapper;

        public ArticleServices(IArticleRepository articleRepository, IMapper mapper)
        {
            _articleRepository = articleRepository;
            _mapper = mapper;
        }

        public ArticleDto AddArticle(CreateArticleDto ArticleDto)
        {
            var Article = _mapper.Map<Article>(ArticleDto);
            return _mapper.Map<ArticleDto>(_articleRepository.AddArticle(Article));
        }

        public bool DeleteArticle(ArticleDto ArticleDto)
        {
            var article = _articleRepository.GetArticleById(ArticleDto.Id);
            if (article == null) {
                return false;
            }

            return _articleRepository.DeleteArticle(article);
        }

        public bool ExistArticleById(int ArticleId)
        {
            return _articleRepository.ExistArticleById(ArticleId);
        }

        public bool ExistArticleByName(string Code)
        {
            return _articleRepository.ExistArticleByCode(Code);
        }

        public ICollection<ArticleDto> GetAllArticles()
        {
            var article = _articleRepository.GetAllArticles();
            return _mapper.Map<ICollection<ArticleDto>>(article);
        }

        public ArticleDto? GetArticleById(int ArticleId)
        {
            var Article = _articleRepository.GetArticleById(ArticleId);
            return _mapper.Map<ArticleDto>(Article);
        }

        public ArticleDto UpdateArticle(ArticleDto ArticleDto)
        {
            var Article = _mapper.Map<Article>(ArticleDto);
            return _mapper.Map<ArticleDto>(_articleRepository.UpdateArticle(Article));
        }
    }
}
