using ExamenTI.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenTI.Business.Interfaces
{
    public interface IArticleServices
    {
        ICollection<ArticleDto> GetAllArticles();
        ArticleDto? GetArticleById(int ArticleId);
        bool ExistArticleByName(string Code);
        bool ExistArticleById(int ArticleId);
        ArticleDto AddArticle(CreateArticleDto ArticleDto);
        ArticleDto UpdateArticle(ArticleDto ArticleDto);
        bool DeleteArticle(ArticleDto ArticleDto);
    }
}
