using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal_TiendaNet.User.Model
{
    public class Usuario
    {
		//Poner que se genera Automáticamente
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string Nombre { get; set; }

		public string Apellido { get; set; }

		public string Email { get; set; }

		[Required]
		[MinLength(6)]
		public string Contraseña { get; set; } = null!;

		public string Username { get; set; }

		public DateTime FechaRegistro { get; set; }

		//Relacion con tabla de Rol
		public string Rol { get; set; }

	}
}
