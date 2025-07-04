using ProyectoFinal_TiendaNet.EstadoTienda.Repository;
using ProyectoFinal_TiendaNet.Rol.Repository;
using ProyectoFinal_TiendaNet.Utils.Exceptions;
using System.Net;

namespace ProyectoFinal_TiendaNet.EstadoTienda.Services
{
	public class EstadoTiendaServices
	{
		private readonly IEstadoTiendaRepository _estadoRepository;

		public EstadoTiendaServices(IEstadoTiendaRepository estadoRepository)
		{
			_estadoRepository = estadoRepository;
		}

		public async Task<EstadoTienda.Model.EstadoTienda> GetOneByName(string name)
		{
			var estado = await _estadoRepository.GetOne(e => e.Nombre == name);
			if (estado == null)
			{
				throw new CustomHttpException(
					$"No se encontro el estado de tienda con el nombre : {name}", HttpStatusCode.NotFound);
			}

			return estado;
		}
	}
}
