namespace ProyectoFinal_TiendaNet.Tienda.Model.Dto
{
	public class UpdateTiendaDTO
	{
		public string? NombreTienda { get; set; }

		//Relacion con lista de categorias de tienda
		public List<CategoriaTienda.Model.CategoriaTienda>? CategoriasTienda { get; set; }

		//Relacion con Personalizacion
		public int? PersonalizacionId { get; set; }
		public DateTime? FechaEliminacion { get; set; }

		//No deberia definir los estados en una tabla adicional y poner el EstadoId?
		public int? EstadoTiendaId { get; set; }

		public string? Direccion { get; set; }
	}
}
