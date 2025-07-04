using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal_TiendaNet.DetalleCompra.Model
{
    public class DetalleCompra
    {
		//Poner que se genera Automáticamente
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		//Relacion con tabla de Compra
		public int CompraId { get; set; }

		public Compra.Model.Compra Compra { get; set; } = null!;

		//relacion con tabla de Producto
		public int ProductoId { get; set; }

		public Producto.Model.Producto Producto { get; set; } = null!;

		public int Cantidad { get; set; }

		public decimal Subtotal { get {
				if (Producto != null)
				{
					return Producto.PrecioUnitario * Cantidad;
				}
				return 0;
			} }

	}
}
