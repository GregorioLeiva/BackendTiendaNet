using AutoMapper;
using ProyectoFinal_TiendaNet.Carrito.Model.Dto;
using ProyectoFinal_TiendaNet.Carrito.Repository;
using ProyectoFinal_TiendaNet.Compra.Model.Dto;
using ProyectoFinal_TiendaNet.Compra.Repository;
using ProyectoFinal_TiendaNet.Config;
using ProyectoFinal_TiendaNet.Utils.Exceptions;
using System.Net;

namespace ProyectoFinal_TiendaNet.Compra.Services
{
	public class CompraServices
	{
		private readonly IMapper _mapper;
		private readonly ICompraRepository _compraRepository;
		private readonly ApplicationDbContext _dbContext;
		public CompraServices(IMapper mapper, ICompraRepository compraRepository, ApplicationDbContext dbContext)
		{
			_mapper = mapper;
			_compraRepository = compraRepository;
			_dbContext = dbContext;
		}
		private async Task<Compra.Model.Compra> GetOneByIdOrException(int id)
		{
			var compra = await _compraRepository.GetOne(c => c.Id == id);
			if (compra == null)
			{
				throw new CustomHttpException($"No se encontro la compra con Id = {id}", HttpStatusCode.NotFound);
			}
			return compra;
		}

		public async Task<Compra.Model.Compra> GetOneById(int id)
		{
			var carrito = await GetOneByIdOrException(id);
			return _mapper.Map<Compra.Model.Compra>(carrito);
		}

		public async Task<List<ComprasDTO>> GetAll()
		{
			var compras = await _compraRepository.GetAll();
			return _mapper.Map<List<ComprasDTO>>(compras);
		}

		public async Task<Compra.Model.Compra> CreateOne(CreateCompraDTO createCompraDto)
		{
			var compra = _mapper.Map<Compra.Model.Compra>(createCompraDto);

			compra.FechaCompra = DateTime.UtcNow;

			await _compraRepository.Add(compra);
			return compra;
		}

		public async Task<Compra.Model.Compra> UpdateOneById(int id, UpdateCompraDTO updateCompraDto)
		{
			var compra = await GetOneByIdOrException(id);

			var userMapped = _mapper.Map(updateCompraDto, compra);

			await _compraRepository.Update(userMapped);

			return userMapped;
		}

		public async Task DeleteOneById(int id)
		{
			var compra = await GetOneByIdOrException(id);

			await _compraRepository.Delete(compra);
		}
	}
}
