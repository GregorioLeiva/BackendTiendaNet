

using ProyectoFinal_TiendaNet.Producto.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal_TiendaNet.CarritoProducto.Model
{
    public class CarritoProducto
    {
		//Poner que se genera Automáticamente
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		//Relacion con la tabla de Carrito
		public int CarritoId { get; set; }

		public Carrito.Model.Carrito Carrito { get; set; }

		//Relacion con la tabla de Producto
		public int ProductoId { get; set; }

		public Producto.Model.Producto Producto { get; set; }

		public int Cantidad { get; set; }
		//Derivado
		public decimal Subtotal { 
			get {
				return Producto != null ? Producto.PrecioUnitario * Cantidad : 0;
			} 
		}

	}
}
