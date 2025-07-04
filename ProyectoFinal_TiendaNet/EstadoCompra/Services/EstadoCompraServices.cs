using ProyectoFinal_TiendaNet.EstadoCompra.Repository;
using ProyectoFinal_TiendaNet.EstadoTienda.Repository;
using ProyectoFinal_TiendaNet.Utils.Exceptions;
using System.Net;

namespace ProyectoFinal_TiendaNet.EstadoCompra.Services
{
	public class EstadoCompraServices
	{
		private readonly IEstadoCompraRepository _estadoRepository;

		public EstadoCompraServices(IEstadoCompraRepository estadoRepository)
		{
			_estadoRepository = estadoRepository;
		}

		public async Task<EstadoCompra.Model.EstadoCompra> GetOneByName(string name)
		{
			var estado = await _estadoRepository.GetOne(e => e.Nombre == name);
			if (estado == null)
			{
				throw new CustomHttpException(
					$"No se encontro el estado de compra con el nombre : {name}", HttpStatusCode.NotFound);
			}

			return estado;
		}
	}
}
