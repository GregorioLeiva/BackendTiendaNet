using ProyectoFinal_TiendaNet.Usuario.Model.Dto;

namespace ProyectoFinal_TiendaNet.Auth.Model.Dto
{
	public class LoginResponseDTO
	{
		public string Token { get; set; } = null!;

		public UsuarioLoginResponseDTO Usuario { get; set; } = null!;
	}
}
