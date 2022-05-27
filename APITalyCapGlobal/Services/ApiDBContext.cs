using APITalyCapGlobal.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITalyCapGlobal.Services
{
    public class ApiDBContext: DbContext
    {
        public ApiDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<BookFilterResult> BookFilterResult { get; set; }
        public DbSet<AuthorsList> AuthorsList { get; set; }        

    }
}
