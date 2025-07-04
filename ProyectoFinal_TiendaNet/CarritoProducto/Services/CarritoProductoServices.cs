using AutoMapper;
using ProyectoFinal_TiendaNet.Carrito.Model.Dto;
using ProyectoFinal_TiendaNet.Carrito.Repository;
using ProyectoFinal_TiendaNet.CarritoProducto.Model.Dto;
using ProyectoFinal_TiendaNet.CarritoProducto.Repository;
using ProyectoFinal_TiendaNet.Config;
using ProyectoFinal_TiendaNet.Utils.Exceptions;
using System.Net;

namespace ProyectoFinal_TiendaNet.CarritoProducto.Services
{
	public class CarritoProductoServices
	{
		private readonly IMapper _mapper;
		private readonly ICarritoProductoRepository _carritoRepository;
		private readonly ApplicationDbContext _dbContext;
		public CarritoProductoServices(IMapper mapper, ICarritoProductoRepository carritoRepository, ApplicationDbContext dbContext)
		{
			_mapper = mapper;
			_carritoRepository = carritoRepository;
			_dbContext = dbContext;
		}
		private async Task<CarritoProducto.Model.CarritoProducto> GetOneByIdOrException(int id)
		{
			var carrito = await _carritoRepository.GetOne(c => c.Id == id);
			if (carrito == null)
			{
				throw new CustomHttpException($"No se encontro el carrito-producto con Id = {id}", HttpStatusCode.NotFound);
			}
			return carrito;
		}

		public async Task<CarritoProducto.Model.CarritoProducto> GetOneById(int id)
		{
			var carrito = await GetOneByIdOrException(id);
			return _mapper.Map<CarritoProducto.Model.CarritoProducto>(carrito);
		}

		public async Task<List<CarritosProductosDTO>> GetAll()
		{
			var carrito = await _carritoRepository.GetAll();
			return _mapper.Map<List<CarritosProductosDTO>>(carrito);
		}

		public async Task<CarritoProducto.Model.CarritoProducto> CreateOne(CreateCarritoProductoDTO createCarritoDto)
		{
			var carrito = _mapper.Map<CarritoProducto.Model.CarritoProducto>(createCarritoDto);

			await _carritoRepository.Add(carrito);
			return carrito;
		}

		public async Task<CarritoProducto.Model.CarritoProducto> UpdateOneById(int id, UpdateCarritoProductoDTO updateCarritoDto)
		{
			var carrito = await GetOneByIdOrException(id);

			var userMapped = _mapper.Map(updateCarritoDto, carrito);

			await _carritoRepository.Update(userMapped);

			return userMapped;
		}

		public async Task DeleteOneById(int id)
		{
			var carrito = await GetOneByIdOrException(id);

			await _carritoRepository.Delete(carrito);
		}
	}
}
