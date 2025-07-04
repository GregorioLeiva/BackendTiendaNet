using AutoMapper;
using ProyectoFinal_TiendaNet.Carrito.Model.Dto;
using ProyectoFinal_TiendaNet.Carrito.Repository;
using ProyectoFinal_TiendaNet.CategoriaProducto.Model.Dto;
using ProyectoFinal_TiendaNet.CategoriaProducto.Repository;
using ProyectoFinal_TiendaNet.Config;
using ProyectoFinal_TiendaNet.Utils.Exceptions;
using System.Net;

namespace ProyectoFinal_TiendaNet.Carrito.Services
{
	public class CarritoServices
	{
		private readonly IMapper _mapper;
		private readonly ICarritoRepository _carritoRepository;
		private readonly ApplicationDbContext _dbContext;
		public CarritoServices(IMapper mapper, ICarritoRepository carritoRepository, ApplicationDbContext dbContext)
		{
			_mapper = mapper;
			_carritoRepository = carritoRepository;
			_dbContext = dbContext;
		}
		private async Task<Carrito.Model.Carrito> GetOneByIdOrException(int id)
		{
			var carrito = await _carritoRepository.GetOne(c => c.Id == id);
			if (carrito == null)
			{
				throw new CustomHttpException($"No se encontro el carrito con Id = {id}", HttpStatusCode.NotFound);
			}
			return carrito;
		}

		public async Task<Carrito.Model.Carrito> GetOneById(int id)
		{
			var carrito = await GetOneByIdOrException(id);
			return _mapper.Map<Carrito.Model.Carrito>(carrito);
		}

		public async Task<Carrito.Model.Carrito> CreateOne(CreateCarritoDTO createCarritoDto)
		{
			var carrito = _mapper.Map<Carrito.Model.Carrito>(createCarritoDto);

			await _carritoRepository.Add(carrito);
			return carrito;
		}

		public async Task<Carrito.Model.Carrito> UpdateOneById(int id, UpdateCarritoDTO updateCarritoDto)
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
