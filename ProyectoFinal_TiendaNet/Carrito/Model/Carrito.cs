using ProyectoFinal_TiendaNet.CarritoProducto.Model;

namespace ProyectoFinal_TiendaNet.Carrito.Model
{
    public class Carrito
    {
		//Poner que se genera Automáticamente
		public int Id { get; set; }

		//Relacion con la tabla de Usuario? Asi lo venga buscando desde otros lados
		public int UsuarioId { get; set; }

		public Usuario.Model.Usuario Usuario { get; set; }

		//Poner estado, pendiente de compra, vacio

		public  List<CarritoProducto.Model.CarritoProducto> Productos { get; set; }

		//Sumar subtotales de productos

		public decimal Total
		{
			get
			{
				decimal total = 0;
				if (Productos != null)
				{
					foreach (var producto in Productos)
					{
						total += producto.Subtotal;
					}
				}
				return total;
			}
		}

	}
}
