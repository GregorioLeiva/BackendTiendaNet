using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal_TiendaNet.Usuario.Model.Dto
{
	public class CreateUsuarioDTO
	{
		public string Nombre { get; set; } = null!;
		public string Apellido { get; set; } = null!;

		[EmailAddress]
		public string Email { get; set; } = null!;
		public string Username { get; set; } = null!;
		public string Contraseña { get; set; } = null!;

		public int RolId { get; set; }
	}
}
