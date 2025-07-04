namespace ProyectoFinal_TiendaNet.Tienda.Model.Dto
{
	public class CreateTiendaDTO
	{

		public int VendedorId { get; set; }
		public string NombreTienda { get; set; }

		//Relacion con lista de categorias de tienda
		public List<CategoriaTienda.Model.CategoriaTienda> CategoriasTienda { get; set; }

		public int PersonalizacionId { get; set; }

		public int EstadoTiendaId { get; set; }

		public string Direccion { get; set; }
	}
}
