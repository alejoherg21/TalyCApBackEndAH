using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using APITalyCapGlobal.Entities;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace APITalyCapGlobal.Services
{
    public class Jwt
    {
        public string SecretKey { get; set; }
    }
}
