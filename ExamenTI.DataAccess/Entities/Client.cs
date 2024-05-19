using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenTI.DataAccess.Entities
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Firstname { get; set; }

        [Required]
        [MaxLength(50)]
        public string Surname { get; set; }

        [MaxLength(255)]
        public string Address { get; set; }

        public ICollection<ClientArticle> ClientArticles { get; set; }
    }
}
