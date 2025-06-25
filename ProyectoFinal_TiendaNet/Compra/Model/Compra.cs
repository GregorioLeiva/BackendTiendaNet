
using ProyectoFinal_TiendaNet.Producto.Model;
namespace ProyectoFinal_TiendaNet.Compra.Model
{

    public class Compra
    {
		//Poner que se genera Automáticamente
		public int Id { get; set; }

		public DateTime FechaCompra { get; set; }

		//Relacion con tabla de Comprador

		public int CompradorId { get; set; }

		//Deberia definir los estados en una tabla extra y poner el EstadoId?
		public string Estado { get; set; }

		//Relacion con tabla de MetodoPago
		public int MetodoPagoId { get; set; }

		//Propiedad derivada
		public decimal Total { get {
				decimal total = 0;
				if (Productos != null)
				{
					foreach (var producto in Productos)
					{
						total += producto.Precio;
					}
				}
				return total;
			} }

		private List<Producto.Model.Producto> Productos { get; set; }

	}
}
