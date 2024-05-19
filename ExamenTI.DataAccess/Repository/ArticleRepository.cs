using ExamenTI.DataAccess.Entities;
using ExamenTI.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ExamenTI.DataAccess.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly AppDbContext _db;

        public ArticleRepository(AppDbContext db)
        {
            _db = db;
        }
        public Article AddArticle(Article Article)
        {
            _db.tblArticle.Add(Article);
            _db.SaveChanges();
            return Article;
        }

        public bool DeleteArticle(Article Article)
        {
            if (_db.Entry(Article).State == EntityState.Detached)
            {
                _db.tblArticle.Attach(Article);
            }
            _db.tblArticle.Remove(Article);
            return Save();
        }

        public bool ExistArticleByCode(string Code)
        {
            return _db.tblArticle.Any(x => x.Code.ToLower().Trim() == Code.ToLower().Trim());
        }

        public bool ExistArticleById(int ArticleId)
        {
            return _db.tblArticle.Any(x => x.Id == ArticleId);
        }

        public ICollection<Article> GetAllArticles()
        {
            return _db.tblArticle.OrderBy(x => x.Code).ToList();
        }

        public Article? GetArticleById(int ArticleId)
        {
            return _db.tblArticle.FirstOrDefault(x => x.Id == ArticleId);
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0;
        }

        public Article UpdateArticle(Article Article)
        {
            _db.tblArticle.Update(Article);
            _db.SaveChanges();
            return Article;
        }
    }
}
