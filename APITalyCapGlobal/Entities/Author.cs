using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//cambio 5
namespace APITalyCapGlobal.Entities
{
    public class Author
    {
        public int id { get; set; }
        public int idBook { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }        
    }

    public class AuthorsList
    {
        public int id { get; set; }
        public string AuthorName { get; set; }
    }
}
