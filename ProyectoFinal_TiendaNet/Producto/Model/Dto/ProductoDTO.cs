namespace ProyectoFinal_TiendaNet.Producto.Model.Dto
{
	public class ProductoDTO
	{
		public int Id { get; set; }

		public string NombreProducto { get; set; } = null!;

		public int Stock { get; set; }

		public decimal PrecioUnitario { get; set; }

		public string? Descripcion { get; set; }

		public string Imagen { get; set; } = null!;

		//Listado de categorias del producto

		public List<CategoriaProducto.Model.CategoriaProducto> Categorias { get; set; } = null!;

		//Relacion con Tienda

		public int TiendaId { get; set; }

		public Tienda.Model.Tienda Tienda { get; set; } = null!;
	}
}
