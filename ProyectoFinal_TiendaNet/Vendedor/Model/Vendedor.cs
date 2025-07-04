using ProyectoFinal_TiendaNet.Usuario.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal_TiendaNet.Vendedor.Model
{
    public class Vendedor
    {
		//Poner que se genera Automáticamente
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		//Relacion con Usuario
		public int UsuarioID { get; set; }

		public Usuario.Model.Usuario Usuario { get; set; }

		public int CUIT { get; set; }

		public List<Tienda.Model.Tienda> Tiendas { get; set; }
	}
}
