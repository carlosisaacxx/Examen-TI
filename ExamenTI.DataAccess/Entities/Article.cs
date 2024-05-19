using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenTI.DataAccess.Entities
{
    public class Article
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Code { get; set; }

        [Required]
        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        public string Image { get; set; }

        [Required]
        public int Stock { get; set; }

        public ICollection<ArticleStore> ArticleStores { get; set; }
        public ICollection<ClientArticle> ClientArticles { get; set; }
    }
}
