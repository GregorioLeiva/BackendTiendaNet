namespace ProyectoFinal_TiendaNet.Producto.Model.Dto
{
	public class CreateProductoDTO
	{

		public string NombreProducto { get; set; } = null!;

		public int Stock { get; set; }

		public decimal PrecioUnitario { get; set; }

		public string? Descripcion { get; set; }

		public string Imagen { get; set; } = null!;

		public List<CategoriaProducto.Model.CategoriaProducto> Categorias { get; set; } = null!;

		public int TiendaId { get; set; }
	}
}
