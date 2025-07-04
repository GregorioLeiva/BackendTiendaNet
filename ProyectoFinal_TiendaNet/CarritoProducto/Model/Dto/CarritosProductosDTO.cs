namespace ProyectoFinal_TiendaNet.CarritoProducto.Model.Dto
{
	public class CarritosProductosDTO
	{
		public int Id { get; set; }
		public int CarritoId { get; set; }

		//Relacion con la tabla de Producto
		public int ProductoId { get; set; }

		public Producto.Model.Producto Producto { get; set; }

		public int Cantidad { get; set; }
		//Derivado
		public decimal Subtotal
		{
			get
			{
				return Producto != null ? Producto.PrecioUnitario * Cantidad : 0;
			}
		}
	}
}
