

namespace ProyectoFinal_TiendaNet.CarritoProducto.Model
{
    public class CarritoProducto
    {
		//Poner que se genera Automáticamente
		public int Id { get; set; }

		//Relacion con la tabla de Carrito
		public int CarritoId { get; set; }

		//Relacion con la tabla de Producto
		public int ProductoId { get; set; }

		public Producto.Model.Producto Producto { get; set; }

		public int Cantidad { get; set; }
		//Derivado
		public decimal Subtotal { get; set; }

	}
}
