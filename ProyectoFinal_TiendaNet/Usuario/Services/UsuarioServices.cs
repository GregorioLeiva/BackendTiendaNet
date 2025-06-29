using AutoMapper;
using ProyectoFinal_TiendaNet.Config;
using ProyectoFinal_TiendaNet.Usuario.Repository;
using ProyectoFinal_TiendaNet.Utils.Encoder;
using ProyectoFinal_TiendaNet.Utils.Exceptions;
using System.Net;
using ProyectoFinal_TiendaNet.Usuario.Model.Dto;

namespace ProyectoFinal_TiendaNet.Usuario.Services
{
	public class UsuarioServices
	{
		private readonly IMapper _mapper;
		private readonly IUsuarioRepository _usuariorepository;
		private readonly IEncoderServices _encoderServices;
		private readonly ApplicationDbContext _dbContext;
		public UsuarioServices(IMapper mapper, IUsuarioRepository usuarioRepository, IEncoderServices encoderServices, ApplicationDbContext dbContext)
		{
			_mapper = mapper;
			_usuariorepository = usuarioRepository;
			_encoderServices = encoderServices;
			_dbContext = dbContext;
		}

		private async Task<Usuario.Model.Usuario> GetOneByIdOrException(int id)
		{
			var usuario = await _usuariorepository.GetOne(x => x.Id == id);
			if (usuario == null)
			{
				throw new CustomHttpException($"No se encontro el usuario con Id = {id}", HttpStatusCode.NotFound);
			}
			return usuario;
		}

		public async Task<Usuario.Model.Usuario> GetOneById(int id)
		{
			var usuario = await GetOneByIdOrException(id);
			return _mapper.Map<Usuario.Model.Usuario>(usuario);
		}
		public async Task<List<UsuariosDTO>> GetAll()
		{
			var usuarios = await _usuariorepository.GetAll();
			return _mapper.Map<List<UsuariosDTO>>(usuarios);
		}

		public async Task<Usuario.Model.Usuario> CreateOne(CreateUsuarioDTO createUserDto)
		{
			var user = _mapper.Map<Usuario.Model.Usuario>(createUserDto);

			user.FechaRegistro = DateTime.UtcNow;

			// Hasheo de la contraseña del usuario
			user.Contraseña = _encoderServices.Encode(user.Contraseña);

			await _usuariorepository.Add(user);
			return user;
		}

		public async Task<Usuario.Model.Usuario> UpdateOneById(int id, UpdateUsuarioDTO updateUserDto)
		{
			var user = await GetOneByIdOrException(id);

			var userMapped = _mapper.Map(updateUserDto, user);

			await _usuariorepository.Update(userMapped);

			return userMapped;
		}

		public async Task DeleteOneById(int id)
		{
			var user = await GetOneByIdOrException(id);

			await _usuariorepository.Delete(user);
		}

		public async Task<Usuario.Model.Usuario> GetOneByUsernameOrEmail(string? username, string? email)
		{
			try
			{
				Usuario.Model.Usuario user;
				if (email == null && username == null)
				{
					throw new CustomHttpException("Invalid Credentials", HttpStatusCode.BadRequest);
				}

				user = email != null
				   ? await _usuariorepository.GetOne(u => u.Email == email, "Roles")
					 : await _usuariorepository.GetOne(u => u.Username == username, "Roles");
				return user;
			}
			catch (CustomHttpException ex)
			{
				throw new CustomHttpException(ex.Message, ex.StatusCode);
			}
			catch (Exception ex)
			{
				throw new CustomHttpException("An unexpected error occurred", HttpStatusCode.InternalServerError);
			}

		}
	}
	
}
