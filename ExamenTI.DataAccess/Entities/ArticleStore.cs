using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenTI.DataAccess.Entities
{
    public class ArticleStore
    {
        public int ArticleId { get; set; }
        public Article Article { get; set; }

        public int StoreId { get; set; }
        public Store Store { get; set; }

        public DateTime Date { get; set; }
    }

}
