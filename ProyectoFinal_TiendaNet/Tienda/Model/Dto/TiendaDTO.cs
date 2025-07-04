namespace ProyectoFinal_TiendaNet.Tienda.Model.Dto
{
	public class TiendaDTO
	{
		public int Id { get; set; }

		public int VendedorId { get; set; }

		public Vendedor.Model.Vendedor Vendedor { get; set; }

		public string NombreTienda { get; set; }

		//Relacion con lista de categorias de tienda
		public List<CategoriaTienda.Model.CategoriaTienda> CategoriasTienda { get; set; }

		//Relacion con Personalizacion
		public int PersonalizacionId { get; set; }

		public Personalizacion.Model.Personalizacion Personalizacion { get; set; }

		public DateTime FechaCreacion { get; set; }
		public DateTime FechaEliminacion { get; set; }
		public int EstadoTiendaId { get; set; }

		public EstadoTienda.Model.EstadoTienda EstadoTienda { get; set; }
		public string Direccion { get; set; }
	}
}
