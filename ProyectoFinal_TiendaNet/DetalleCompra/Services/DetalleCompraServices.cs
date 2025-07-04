using AutoMapper;
using ProyectoFinal_TiendaNet.CarritoProducto.Model.Dto;
using ProyectoFinal_TiendaNet.CarritoProducto.Repository;
using ProyectoFinal_TiendaNet.Config;
using ProyectoFinal_TiendaNet.DetalleCompra.Model.Dto;
using ProyectoFinal_TiendaNet.DetalleCompra.Repository;
using ProyectoFinal_TiendaNet.Utils.Exceptions;
using System.Net;

namespace ProyectoFinal_TiendaNet.DetalleCompra.Services
{
	public class DetalleCompraServices
	{
		private readonly IMapper _mapper;
		private readonly IDetalleCompraRepository _detalleRepository;
		private readonly ApplicationDbContext _dbContext;
		public DetalleCompraServices(IMapper mapper, IDetalleCompraRepository detalleRepository, ApplicationDbContext dbContext)
		{
			_mapper = mapper;
			_detalleRepository = detalleRepository;
			_dbContext = dbContext;
		}
		private async Task<DetalleCompra.Model.DetalleCompra> GetOneByIdOrException(int id)
		{
			var detalle = await _detalleRepository.GetOne(c => c.Id == id);
			if (detalle == null)
			{
				throw new CustomHttpException($"No se encontro el detalle de compra con Id = {id}", HttpStatusCode.NotFound);
			}
			return detalle;
		}

		public async Task<DetalleCompra.Model.DetalleCompra> GetOneById(int id)
		{
			var detalle = await GetOneByIdOrException(id);
			return _mapper.Map<DetalleCompra.Model.DetalleCompra>(detalle);
		}

		public async Task<List<DetallesComprasDTO>> GetAll()
		{
			var detalle = await _detalleRepository.GetAll();
			return _mapper.Map<List<DetallesComprasDTO>>(detalle);
		}

		public async Task<DetalleCompra.Model.DetalleCompra> CreateOne(CreateDetalleCompraDTO createdetalleDto)
		{
			var detalle = _mapper.Map<DetalleCompra.Model.DetalleCompra>(createdetalleDto);

			await _detalleRepository.Add(detalle);
			return detalle;
		}

		public async Task<DetalleCompra.Model.DetalleCompra> UpdateOneById(int id, UpdateDetalleCompraDTO updateDetalleDto)
		{
			var detalle = await GetOneByIdOrException(id);

			var userMapped = _mapper.Map(updateDetalleDto, detalle);

			await _detalleRepository.Update(userMapped);

			return userMapped;
		}

		public async Task DeleteOneById(int id)
		{
			var detalle = await GetOneByIdOrException(id);

			await _detalleRepository.Delete(detalle);
		}
	}
}
