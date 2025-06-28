namespace ProyectoFinal_TiendaNet.Usuario.Model.Dto
{
	public class UsuarioDTO
	{
		public int Id { get; set; }
		public string Nombre { get; set; } = null!;
		public string Apellido { get; set; } = null!;
		public string Email { get; set; } = null!;
		public DateTime FechaRegistro { get; set; }
		public string Rol { get; set; } = null!;
	}
}
