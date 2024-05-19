using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenTI.DataAccess.Entities
{
    public class ClientArticle
    {
        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public Client Client { get; set; }

        [ForeignKey("Article")]
        public int ArticleId { get; set; }
        public Article Article { get; set; }

        public DateTime Date { get; set; }
    }
}
