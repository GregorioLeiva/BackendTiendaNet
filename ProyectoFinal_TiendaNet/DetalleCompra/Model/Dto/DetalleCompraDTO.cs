namespace ProyectoFinal_TiendaNet.DetalleCompra.Model.Dto
{
	public class DetalleCompraDTO
	{
		public int Id { get; set; }
		public int CompraId { get; set; }

		public Compra.Model.Compra Compra { get; set; } = null!;
		public int ProductoId { get; set; }

		public Producto.Model.Producto Producto { get; set; } = null!;

		public int Cantidad { get; set; }
	}
}
