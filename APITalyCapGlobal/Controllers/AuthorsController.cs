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
//cambio 3
namespace APITalyCapGlobal.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly ApiDBContext _context;

        public AuthorsController(ApiDBContext context)
        {
            _context = context;
        }

        // GET: api/Authors
        [HttpGet("/GetAuthorTable")]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthorTable()
        {

            return await _context.Author.ToListAsync();
        }

        // GET: api/Authors
        [HttpGet("/GetAuthorsList")]
        public async Task<ActionResult<IEnumerable<AuthorsList>>> GetAuthorsList()
        {

            List<AuthorsList> response = await _context.AuthorsList.FromSqlRaw("[dbo].[GetAuthors]").ToListAsync();
            return response;
        }

    }
}
