namespace ProyectoFinal_TiendaNet.Comprador.Model
{
    public class Comprador
    {
		//Poner que se genera Automáticamente
		public int Id { get; set; }

		//Relacion con tabla de Usuario
		public int UsuarioId { get; set; }

		public int DNI { get; set; }

		public int Telefono { get; set; }

		public string Direccion { get; set; }

		//Relacion con tabla de Compras
		public List<Compra.Model.Compra> Compras { get; set; }

	}
}
