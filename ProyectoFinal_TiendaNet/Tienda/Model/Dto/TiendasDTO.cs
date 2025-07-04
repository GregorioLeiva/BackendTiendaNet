namespace ProyectoFinal_TiendaNet.Tienda.Model.Dto
{
	public class TiendasDTO
	{
		public int Id { get; set; }

		public int VendedorId { get; set; }

		public string NombreTienda { get; set; }

		//Relacion con lista de categorias de tienda
		public List<CategoriaTienda.Model.CategoriaTienda> CategoriasTienda { get; set; }

		public string Direccion { get; set; }
	}
}
