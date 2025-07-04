using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProyectoFinal_TiendaNet.Auth.Services
{
	public class AuthServices
	{
			private string secretKey;

			public AuthServices(IConfiguration config)
			{
				secretKey = config.GetSection("jwtSettings").GetSection("secretKey").ToString() ?? null!;
			}

			public string GenerateJwtToken(Usuario.Model.Usuario usuario)
			{
				var claims = new ClaimsIdentity();
				claims.AddClaim(new Claim("id", usuario.Id.ToString()));

				if (usuario.Rol != null)
				{
					claims.AddClaim(new Claim(ClaimTypes.Role, usuario.Rol.Nombre));
				}

				var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
				var credentials = new SigningCredentials(
					symmetricKey,
					SecurityAlgorithms.HmacSha256Signature
				);

				var tokenDescriptor = new SecurityTokenDescriptor()
				{
					Subject = claims,
					Expires = DateTime.UtcNow.AddDays(1),
					SigningCredentials = credentials
				};

				var tokenHandler = new JwtSecurityTokenHandler();
				var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);
				string token = tokenHandler.WriteToken(tokenConfig);
				return token;
			}
	}
}
