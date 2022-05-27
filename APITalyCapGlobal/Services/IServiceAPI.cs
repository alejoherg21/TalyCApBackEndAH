using APITalyCapGlobal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APITalyCapGlobal.Services
{
    public interface IServiceAPI
    {
        Task<List<Author>> GetAuthorsList();
        Task<List<Book>> GetBooksList();
        Task<List<Users>> GetUsersList();
    }
}
