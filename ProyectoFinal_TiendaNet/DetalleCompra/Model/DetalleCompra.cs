namespace ProyectoFinal_TiendaNet.DetalleCompra.Model
{
    public class DetalleCompra
    {
		//Poner que se genera Automáticamente
		public int Id { get; set; }

		//Relacion con tabla de Compra
		public int CompraId { get; set; }

		//relacion con tabla de Producto
		public int ProductoId { get; set; }

		public int Cantidad { get; set; }

		//Relacion con tabla CarritoProducto
		public int CarritoProductoId { get; set; }

		public decimal Subtotal { get; set; }

	}
}
