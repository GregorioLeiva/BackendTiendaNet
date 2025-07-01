using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal_TiendaNet.Admin.Model
{
    public class Admin
    {
		//Poner que se genera Automáticamente
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		//Relacion con tabla de Usuario
		public int UsuarioID { get; set; }

		public Usuario.Model.Usuario Usuario { get; set; }

	}
}
