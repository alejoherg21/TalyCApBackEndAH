using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITalyCapGlobal.Entities
{
    public class BookFilter
    {
        public int idAuthor { get; set; }
        public DateTime InitialpublishDate { get; set; }
        public DateTime FinalpublishDate { get; set; }        
    }
        
    [Microsoft.EntityFrameworkCore.Keyless]
    public class BookFilterResult
    {
        public int idAuthor { get; set; }
        public int idBook { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int pageCount { get; set; }
        public string excerpt { get; set; }
        public DateTime publishDate { get; set; }
    }
}
