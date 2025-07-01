using AutoMapper;
using ProyectoFinal_TiendaNet.Admin.Model.Dto;
using ProyectoFinal_TiendaNet.Admin.Repository;
using ProyectoFinal_TiendaNet.Comprador.Model.Dto;
using ProyectoFinal_TiendaNet.Comprador.Repository;
using ProyectoFinal_TiendaNet.Config;
using ProyectoFinal_TiendaNet.Utils.Exceptions;
using System.Net;

namespace ProyectoFinal_TiendaNet.Admin.Services
{
	public class AdminServices
	{
		private readonly IMapper _mapper;
		private readonly IAdminRepository _adminRepository;
		private readonly ApplicationDbContext _dbContext;
		public AdminServices(IMapper mapper, IAdminRepository adminRepository, ApplicationDbContext dbContext)
		{
			_mapper = mapper;
			_adminRepository = adminRepository;
			_dbContext = dbContext;
		}
		private async Task<Admin.Model.Admin> GetOneByIdOrException(int id)
		{
			var admin = await _adminRepository.GetOne(a => a.Id == id);
			if (admin == null)
			{
				throw new CustomHttpException($"No se encontro el admin con Id = {id}", HttpStatusCode.NotFound);
			}
			return admin;
		}

		public async Task<Admin.Model.Admin> GetOneById(int id)
		{
			var admin = await GetOneByIdOrException(id);
			return _mapper.Map<Admin.Model.Admin>(admin);
		}
		public async Task<List<AdminsDTO>> GetAll()
		{
			var admins = await _adminRepository.GetAll();
			return _mapper.Map<List<AdminsDTO>>(admins);
		}

		public async Task<Admin.Model.Admin> CreateOne(CreateAdminDTO createAdminDto)
		{
			var admin = _mapper.Map<Admin.Model.Admin>(createAdminDto);

			await _adminRepository.Add(admin);
			return admin;
		}

		public async Task DeleteOneById(int id)
		{
			var admin = await GetOneByIdOrException(id);

			await _adminRepository.Delete(admin);
		}
	}

}
