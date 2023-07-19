using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Security.Protos;
using System.Drawing;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Security.Services
{
    public class JwtService : IJwtService
    {

        public string GenerateToken(string userid)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("ABNM YE KJLK FD OPIL KLM AERIFY ERT OOKENS, REPLACE AB POIN YOUN OWN SECRET, IT HTR PO RET STWINC");
            var encrytionKey = Encoding.UTF8.GetBytes("qwsadfrewtyh4532");
            var encryptingCredentials = new EncryptingCredentials(new SymmetricSecurityKey(encrytionKey), SecurityAlgorithms.Aes128KW, SecurityAlgorithms.Aes128CbcHmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                IssuedAt = DateTime.Now,
                NotBefore = DateTime.Now,
                Expires = DateTime.Now.AddMinutes(20),
                EncryptingCredentials = encryptingCredentials,
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("userid",userid)
                }),

        
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
