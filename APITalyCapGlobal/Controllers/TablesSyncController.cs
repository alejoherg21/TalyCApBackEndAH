using APITalyCapGlobal.Entities;
using APITalyCapGlobal.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
//cambio 3
namespace APITalyCapGlobal.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TablesSyncController : ControllerBase
    {
        private readonly IServiceAPI _serviceAPI;
        private readonly ApiDBContext _context;

        public TablesSyncController(IServiceAPI serviceAPI, ApiDBContext context)
        {
            _serviceAPI = serviceAPI;
            _context = context;
        }

        [HttpGet("/GetAuthors")]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            List<Author> AuthorsList = await _serviceAPI.GetAuthorsList();

            _context.Author.RemoveRange(_context.Author.ToList());
            _context.SaveChanges();

            foreach (var item in AuthorsList)
            {
                await PutAuthor(item);
            }
            return Ok(new { Message = "Success" });
        }

        [HttpGet("/GetBooks")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            List<Book> BooksList = await _serviceAPI.GetBooksList();
            _context.Book.RemoveRange(_context.Book.ToList());
            _context.SaveChanges();

            foreach (var item in BooksList)
            {
                await PutBook(item);
            }
            return Ok(new { Message = "Success" });
        }

        [HttpGet("/GetUsers")]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            List<Users> UsersList = await _serviceAPI.GetUsersList();
            _context.Book.RemoveRange(_context.Book.ToList());
            _context.SaveChanges();

            foreach (var item in UsersList)
            {
                await PutUser(item);
            }
            return Ok(new { Message = "Success" });
        }

        private async Task<bool> PutAuthor(Author author)
        {
            _context.Author.Add(author);
            await _context.SaveChangesAsync();
            return true;
        }

        private async Task<bool> PutBook(Book book)
        {
            _context.Book.Add(book);
            await _context.SaveChangesAsync();
            return true;
        }

        private async Task<bool> PutUser(Users user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
