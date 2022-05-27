using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APITalyCapGlobal.Entities;
using APITalyCapGlobal.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Data.SqlClient;
using System.Data;

namespace APITalyCapGlobal.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ApiDBContext _context;

        public BooksController(ApiDBContext context)
        {
            _context = context;
        }


        // GET: api/Books
        [HttpPost("/GetBookFilter")]
        public async Task<ActionResult<IEnumerable<BookFilterResult>>> GetBookFilter(BookFilter bookFilter)
        {
            var parameters = new[]
            {
                new SqlParameter { ParameterName = "@idAuthor", DbType = DbType.Int32, Direction = ParameterDirection.Input, Value = bookFilter.idAuthor },
                new SqlParameter { ParameterName = "@InitialpublishDate", DbType = DbType.DateTime, Direction = ParameterDirection.Input, Value = bookFilter.InitialpublishDate},
                new SqlParameter { ParameterName = "@FinalpublishDate", DbType = DbType.DateTime, Direction = ParameterDirection.Input, Value = bookFilter.FinalpublishDate},
            };

            List<BookFilterResult> response = await _context.BookFilterResult.FromSqlRaw("[dbo].[GetBooks] @idAuthor,@InitialpublishDate,@FinalpublishDate", parameters).ToListAsync();
            return response;
        }

    }
}
