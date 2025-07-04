namespace ProyectoFinal_TiendaNet.Producto.Model.Dto
{
	public class UpdateProductoDTO
	{

		public string NombreProducto { get; set; } = null!;

		public int Stock { get; set; }

		public decimal PrecioUnitario { get; set; }

		public string? Descripcion { get; set; }

		public string Imagen { get; set; } = null!;

		//Listado de categorias del producto

		public List<CategoriaProducto.Model.CategoriaProducto> Categorias { get; set; } = null!;
	}
}
