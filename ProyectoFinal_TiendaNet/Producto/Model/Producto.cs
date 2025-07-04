using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal_TiendaNet.Producto.Model
{
    public class Producto
    {
		//Poner que se genera Automáticamente
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public string NombreProducto { get; set; } = null!;

		public int Stock { get; set; }

		public decimal PrecioUnitario { get; set; }

		public string? Descripcion { get; set; }

		public string Imagen { get; set; } = null!;

		public DateTime FechaCreacion { get; set; }

		public DateTime FechaModificacion { get; set; }

		//Listado de categorias del producto

		public List<CategoriaProducto.Model.CategoriaProducto> Categorias { get; set; } = null!;

		//Relacion con Tienda

		public int TiendaId { get; set; }

		public Tienda.Model.Tienda Tienda { get; set; } = null!;

	}
}
