using AutoMapper;
using ProyectoFinal_TiendaNet.CategoriaTienda.Model.Dto;
using ProyectoFinal_TiendaNet.CategoriaTienda.Repository;
using ProyectoFinal_TiendaNet.Config;
using ProyectoFinal_TiendaNet.MetodoPago.Model.Dto;
using ProyectoFinal_TiendaNet.MetodoPago.Repository;
using ProyectoFinal_TiendaNet.Utils.Exceptions;
using System.Net;

namespace ProyectoFinal_TiendaNet.MetodoPago.Services
{
	public class MetodoPagoServices
	{
		private readonly IMapper _mapper;
		private readonly IMetodoPagoRepository _metodopagoRepository;
		private readonly ApplicationDbContext _dbContext;
		public MetodoPagoServices(IMapper mapper, IMetodoPagoRepository metodopagoRepository, ApplicationDbContext dbContext)
		{
			_mapper = mapper;
			_metodopagoRepository = metodopagoRepository;
			_dbContext = dbContext;
		}
		private async Task<MetodoPago.Model.MetodoPago> GetOneByIdOrException(int id)
		{
			var metodo = await _metodopagoRepository.GetOne(mp => mp.Id == id);
			if (metodo == null)
			{
				throw new CustomHttpException($"No se encontro el metodo de pago con Id = {id}", HttpStatusCode.NotFound);
			}
			return metodo;
		}

		public async Task<MetodoPago.Model.MetodoPago> GetOneById(int id)
		{
			var metodo = await GetOneByIdOrException(id);
			return _mapper.Map<MetodoPago.Model.MetodoPago>(metodo);
		}
		public async Task<List<MetodosPagoDTO>> GetAll()
		{
			var metodos = await _metodopagoRepository.GetAll();
			return _mapper.Map<List<MetodosPagoDTO>>(metodos);
		}

		public async Task<MetodoPago.Model.MetodoPago> CreateOne(CreateMetodoPagoDTO createMetodoPagoDto)
		{
			var metodo = _mapper.Map<MetodoPago.Model.MetodoPago>(createMetodoPagoDto);

			await _metodopagoRepository.Add(metodo);
			return metodo;
		}

		public async Task<MetodoPago.Model.MetodoPago> UpdateOneById(int id, UpdateMetodoPagoDTO updateMetodoPagoDto)
		{
			var metodo = await GetOneByIdOrException(id);

			var userMapped = _mapper.Map(updateMetodoPagoDto, metodo);

			await _metodopagoRepository.Update(userMapped);

			return userMapped;
		}

		public async Task DeleteOneById(int id)
		{
			var metodoPago = await GetOneByIdOrException(id);

			await _metodopagoRepository.Delete(metodoPago);
		}
	}
}
