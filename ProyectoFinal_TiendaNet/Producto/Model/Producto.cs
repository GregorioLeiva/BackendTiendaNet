namespace ProyectoFinal_TiendaNet.Producto.Model
{
    public class Producto
    {
		//Poner que se genera Automáticamente
		public int Id { get; set; }

		public string NombreProducto { get; set; }

		public int Stock { get; set; }

		public decimal PrecioUnitario { get; set; }

		public string Descripcion { get; set; }
		
		//El producto puede tener un estado de activo o inactivo

		public int EstadoId { get; set; }

		public string Imagen { get; set; }

		//Listado de categorias del producto

		public List<CategoriaProducto.Model.CategoriaProducto> Categorias { get; set; }

		//Relacion con Tienda

		public int TiendaId { get; set; }

	}
}
