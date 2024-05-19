using ExamenTI.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExamenTI.DataAccess;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Client> tblClient { get; set; }
    public DbSet<Store> tblStore { get; set; }
    public DbSet<Article> tblArticle { get; set; }
    public DbSet<ArticleStore> tblArticleStore { get; set; }
    public DbSet<ClientArticle> tblClientArticle { get; set; }
    public DbSet<User> tblUser { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuración de la relación ArticleStore
        modelBuilder.Entity<ArticleStore>()
            .HasKey(ar => new { ar.ArticleId, ar.StoreId });

        modelBuilder.Entity<ArticleStore>()
            .HasOne(ar => ar.Article)
            .WithMany(a => a.ArticleStores)
            .HasForeignKey(ar => ar.ArticleId);

        modelBuilder.Entity<ArticleStore>()
            .HasOne(ar => ar.Store)
            .WithMany(s => s.ArticleStores)
            .HasForeignKey(ar => ar.StoreId);

        // Configuración de la relación ClientArticle
        modelBuilder.Entity<ClientArticle>()
            .HasKey(ca => new { ca.ClientId, ca.ArticleId });

        modelBuilder.Entity<ClientArticle>()
            .HasOne(ca => ca.Client)
            .WithMany(c => c.ClientArticles)
            .HasForeignKey(ca => ca.ClientId);

        modelBuilder.Entity<ClientArticle>()
            .HasOne(ca => ca.Article)
            .WithMany(a => a.ClientArticles)
            .HasForeignKey(ca => ca.ArticleId);
    }
}
