namespace ProyectoFinal_TiendaNet.Usuario.Model.Dto
{
	public class UsuariosDTO
	{
		public int Id { get; set; }
		public string Nombre { get; set; } = null!;
		public string Apellido { get; set; } = null!;
		public string Rol { get; set; } = null!;
	}
}
