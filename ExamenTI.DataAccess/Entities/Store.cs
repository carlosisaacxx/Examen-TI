using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenTI.DataAccess.Entities
{
    public class Store
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Branch {  get; set; }

        [Required]
        [MaxLength(255)]
        public string Address { get; set; }

        public ICollection<ArticleStore> ArticleStores { get; set; }
    }
}
