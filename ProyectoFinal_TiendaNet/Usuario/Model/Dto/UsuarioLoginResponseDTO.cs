namespace ProyectoFinal_TiendaNet.Usuario.Model.Dto
{
    public class UsuarioLoginResponseDTO
    {
		public int Id { get; set; }

		public string? Email { get; set; }

		public string UserName { get; set; } = null!;

		public int RolId { get; set; }
	}
}
