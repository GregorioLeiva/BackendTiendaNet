using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal_TiendaNet.Auth.Model
{
	public class Login
	{
		public string? Username { get; set; }

		[EmailAddress]
		public string? Email { get; set; }

		[Required]
		public string Contraseña { get; set; } = null!;
	}
}
