using ProyectoFinal_TiendaNet.Rol.Repository;
using ProyectoFinal_TiendaNet.Utils.Exceptions;
using System.Net;

namespace ProyectoFinal_TiendaNet.Rol.Services
{
	public class RolServices
	{
		private readonly IRolRepository _roleRepository;

		public RolServices(IRolRepository roleRepository)
		{
			_roleRepository = roleRepository;
		}

		public async Task<Rol.Model.Rol> GetOneByName(string name)
		{
			var role = await _roleRepository.GetOne(r => r.Nombre == name);
			if (role == null)
			{
				throw new CustomHttpException(
					$"No se encontro el rol con el nombre : {name}", HttpStatusCode.NotFound);
			}

			return role;
		}
	}
}
