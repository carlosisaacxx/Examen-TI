using ExamenTI.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenTI.DataAccess.Repository.IRepository
{
    public interface IArticleRepository
    {
        ICollection<Article> GetAllArticles();
        Article? GetArticleById(int ArticleId);
        bool ExistArticleByCode(string Code);
        bool ExistArticleById(int ArticleId);
        Article AddArticle(Article Article);
        Article UpdateArticle(Article Article);
        bool DeleteArticle(Article Article);
        bool Save();
    }
}
