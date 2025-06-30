using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal_TiendaNet.Comprador.Model
{
    public class Comprador
    {
		//Poner que se genera Automáticamente
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		//Relacion con tabla de Usuario
		public int UsuarioId { get; set; }

		public Usuario.Model.Usuario Usuario { get; set; }

		public int DNI { get; set; }

		public string Telefono { get; set; }

		public string Direccion { get; set; }

		//Relacion con tabla de Compras
		public List<Compra.Model.Compra> Compras { get; set; }

	}
}
