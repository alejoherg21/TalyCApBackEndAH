using APITalyCapGlobal.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace APITalyCapGlobal.Services
{
    public class ExternalAPI: IServiceAPI
    {
        static HttpClient client = new HttpClient();
        static IConfiguration conf = (new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build());

        public async Task<List<Author>> GetAuthorsList()
        {
            List<Author> Author = null;
            string path = conf["ExternalAPI:Authors"].ToString();
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                Author = await response.Content.ReadAsAsync<List<Author>>();
            }
            return Author;
        }

        public async Task<List<Book>> GetBooksList()
        {
            List<Book> Books = null;
            string path = conf["ExternalAPI:Books"].ToString();
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                Books = await response.Content.ReadAsAsync<List<Book>>();
            }
            return Books;
        }

        public async Task<List<Users>> GetUsersList()
        {
            List<Users> Users = null;
            string path = conf["ExternalAPI:Users"].ToString();
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                Users = await response.Content.ReadAsAsync<List<Users>>();
            }
            return Users;
        }
    }
}
