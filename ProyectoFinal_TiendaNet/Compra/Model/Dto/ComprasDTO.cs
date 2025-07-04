namespace ProyectoFinal_TiendaNet.Compra.Model.Dto
{
	public class ComprasDTO
	{
		public class CompraDTO
		{
			public int Id { get; set; }

			public DateTime FechaCompra { get; set; }

			public int CompradorId { get; set; }

			public Comprador.Model.Comprador Comprador { get; set; } = null!;
			public int EstadoId { get; set; }
			public EstadoCompra.Model.EstadoCompra EstadoCompra { get; set; } = null!;
			public int MetodoPagoId { get; set; }

			public MetodoPago.Model.MetodoPago MetodoPago { get; set; } = null!;
			public List<DetalleCompra.Model.DetalleCompra> Detalles { get; set; } = null!;
			public decimal Total
			{
				get
				{
					decimal total = 0;
					if (Detalles != null)
					{
						foreach (var detalle in Detalles)
						{
							total += detalle.Subtotal;
						}
					}
					return total;
				}
			}
		}
	}
}
