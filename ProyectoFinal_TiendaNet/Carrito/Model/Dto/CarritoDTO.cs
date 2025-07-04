namespace ProyectoFinal_TiendaNet.Carrito.Model.Dto
{
	public class CarritoDTO
	{
		public int Id { get; set; }

		public int UsuarioId { get; set; }

		public bool Vacio { get; set; }

		public List<CarritoProducto.Model.CarritoProducto> Productos { get; set; }

		public decimal TotalProductos
		{
			get
			{
				return Productos != null ? Productos.Sum(p => p.Cantidad) : 0;
			}
		}
	}
}
