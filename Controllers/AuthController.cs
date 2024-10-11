using GerenciamentoFinanceiroAPI.DTOs;
using GerenciamentoFinanceiroAPI.Models;
using GerenciamentoFinanceiroAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GerenciamentoFinanceiroAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UsuarioDto usuarioDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_context.Usuarios.Any(u => u.Email == usuarioDto.Email))
            {
                return BadRequest("Este E-mail já está em uso.");
            }

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(usuarioDto.Password);

            var usuario = new Usuario
            {
                Name = usuarioDto.Name,
                Email = usuarioDto.Email,
                PasswordHash = passwordHash
            };

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return Ok("Usuário registrado com sucesso");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UsuarioLoginDto usuarioLoginDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usuario = _context.Usuarios.SingleOrDefault(u => u.Email == usuarioLoginDto.Email);

            if (usuario == null || !BCrypt.Net.BCrypt.Verify(usuarioLoginDto.Password, usuario.PasswordHash))
            {
                return Unauthorized("Credenciais inválidas");
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, usuario.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var secretKey = _configuration.GetValue<string>("JwtSettings:SecretKey");

            if (string.IsNullOrEmpty(secretKey))
            {
                throw new InvalidOperationException("Chave secreta JWT não está configurada.");
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var issuer = _configuration.GetValue<string>("JwtSettings:Issuer");
            var audience = _configuration.GetValue<string>("JwtSettings:Audience");

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: creds);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}

