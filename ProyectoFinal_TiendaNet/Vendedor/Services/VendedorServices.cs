using AutoMapper;
using ProyectoFinal_TiendaNet.Comprador.Model.Dto;
using ProyectoFinal_TiendaNet.Comprador.Repository;
using ProyectoFinal_TiendaNet.Config;
using ProyectoFinal_TiendaNet.Utils.Exceptions;
using ProyectoFinal_TiendaNet.Vendedor.Model;
using ProyectoFinal_TiendaNet.Vendedor.Model.Dto;
using ProyectoFinal_TiendaNet.Vendedor.Repository;
using System.Net;

namespace ProyectoFinal_TiendaNet.Vendedor.Services
{
	public class VendedorServices
	{
		private readonly IMapper _mapper;
		private readonly IVendedorRepository _vendedorRepository;
		private readonly ApplicationDbContext _dbContext;
		public VendedorServices(IMapper mapper, IVendedorRepository vendedorRepository, ApplicationDbContext dbContext)
		{
			_mapper = mapper;
			_vendedorRepository = vendedorRepository;
			_dbContext = dbContext;
		}
		private async Task<Vendedor.Model.Vendedor> GetOneByIdOrException(int id)
		{
			var vendedor = await _vendedorRepository.GetOne(c => c.Id == id);
			if (vendedor == null)
			{
				throw new CustomHttpException($"No se encontro el vendedor con Id = {id}", HttpStatusCode.NotFound);
			}
			return vendedor;
		}

		public async Task<Vendedor.Model.Vendedor> GetOneById(int id)
		{
			var vendedor = await GetOneByIdOrException(id);
			return _mapper.Map<Vendedor.Model.Vendedor>(vendedor);
		}
		public async Task<List<VendedoresDTO>> GetAll()
		{
			var vendedores = await _vendedorRepository.GetAll();
			return _mapper.Map<List<VendedoresDTO>>(vendedores);
		}

		public async Task<Vendedor.Model.Vendedor> CreateOne(CreateVendedorDTO createVendedorDto)
		{
			var vendedor = _mapper.Map<Vendedor.Model.Vendedor>(createVendedorDto);

			await _vendedorRepository.Add(vendedor);
			return vendedor;
		}

		public async Task<Vendedor.Model.Vendedor> UpdateOneById(int id, UpdateVendedorDTO updateVendedorDto)
		{
			var vendedor = await GetOneByIdOrException(id);

			var userMapped = _mapper.Map(updateVendedorDto, vendedor);

			await _vendedorRepository.Update(userMapped);

			return userMapped;
		}

		public async Task DeleteOneById(int id)
		{
			var vendedor = await GetOneByIdOrException(id);

			await _vendedorRepository.Delete(vendedor);
		}
	}
}
