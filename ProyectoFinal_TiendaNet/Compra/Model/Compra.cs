
using ProyectoFinal_TiendaNet.Producto.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProyectoFinal_TiendaNet.Compra.Model
{

    public class Compra
    {
		//Poner que se genera Automáticamente
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		public DateTime FechaCompra { get; set; }

		//Relacion con tabla de Comprador

		public int CompradorId { get; set; }

		public Comprador.Model.Comprador Comprador { get; set; } = null!;

		//Deberia definir los estados en una tabla extra y poner el EstadoId? [Pendiente, En preparacion, Finalizada, Cancelada]
		public int EstadoId { get; set; }
		public EstadoCompra.Model.EstadoCompra EstadoCompra { get; set; } = null!;

		//Relacion con tabla de MetodoPago
		public int MetodoPagoId { get; set; }

		public MetodoPago.Model.MetodoPago MetodoPago { get; set; } = null!;
		public List<DetalleCompra.Model.DetalleCompra> Detalles { get; set; } = null!;

		//Propiedad derivada
		public decimal Total { get {
				decimal total = 0;
				if (Detalles != null)
				{
					foreach (var detalle in Detalles)
					{
						total += detalle.Subtotal;
					}
				}
				return total;
			} }
	}
}
