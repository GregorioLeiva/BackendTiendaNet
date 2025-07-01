using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal_TiendaNet.CategoriaProducto.Model
{
    public class CategoriaProducto
    {
		//Poner que se genera Automáticamente
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[Required]
		public string Nombre { get; set; }

	}
}
