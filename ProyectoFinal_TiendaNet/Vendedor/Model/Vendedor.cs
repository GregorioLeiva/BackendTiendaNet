namespace ProyectoFinal_TiendaNet.Vendedor.Model
{
    public class Vendedor
    {
		//Poner que se genera Automáticamente
		public int Id { get; set; }

		//Relacion con Usuario
		public int UsuarioID { get; set; }

		public int CUIT { get; set; }

		//Deberia traer las tiendas? 

		//Relacion con listado de tiendas
		public List<Tienda.Model.Tienda> Tiendas { get; set; }
	}
}
