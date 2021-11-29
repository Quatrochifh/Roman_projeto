﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RomanDesafioWebAPI.Domains;
using RomanDesafioWebAPI.Interfaces;
using RomanDesafioWebAPI.Repositories;
using RomanDesafioWebAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RomanDesafioWebAPI.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }
        [HttpPost]

        public IActionResult Logar(LoginViewModel login)
        {
            try
            {



                Usuario usuarioBuscado = _usuarioRepository.Logar(login.email, login.senha);

                if (usuarioBuscado == null)
                {
                    return NotFound("Email ou senha invalidos!");
                }

                var claims = new[]
                {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email) ,
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.Id.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.IdTipousuario.ToString()),
                new Claim("role", usuarioBuscado.IdTipousuario.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, usuarioBuscado.NomeUsu)
            };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("roman-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                        issuer: "Roman.webApi",
                        audience: "Roman.webApi",
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(20),
                        signingCredentials: creds
                    );
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)

                });
            }
            catch (Exception codErro)
            {

                return BadRequest(codErro); ;
            }
        }
    }
}
