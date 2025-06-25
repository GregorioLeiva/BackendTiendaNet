namespace ProyectoFinal_TiendaNet.Tienda.Model
{
    public class Tienda
    {
		//Poner que se genera Automáticamente
		public int Id { get; set; }

		public string NombreTienda { get; set; }

		//Relacion con lista de categorias de tienda
		public List<CategoriaTienda.Model.CategoriaTienda> CategoriasTienda { get; set; }

		//Relacion con Personalizacion
		public int PersonalizacionId { get; set; }

		public DateTime FechaCreacion { get; set; }

		//Para definir cuando se eliminara la tienda? 
		public DateTime FechaEliminacion { get; set; }

		//No deberia definir los estados en una tabla adicional y poner el EstadoId?
		public string Estado { get; set; }

		public string Direccion { get; set; }

	}
}
