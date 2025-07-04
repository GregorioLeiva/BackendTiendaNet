using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal_TiendaNet.Auth.Model.Dto;
using ProyectoFinal_TiendaNet.Auth.Model;
using ProyectoFinal_TiendaNet.Auth.Services;
using ProyectoFinal_TiendaNet.Enums;
using ProyectoFinal_TiendaNet.Rol.Services;
using ProyectoFinal_TiendaNet.Utils.Encoder;
using ProyectoFinal_TiendaNet.Utils.Exceptions;
using System.Net;
using ProyectoFinal_TiendaNet.Usuario.Services;
using ProyectoFinal_TiendaNet.Carrito.Services;
using ProyectoFinal_TiendaNet.Usuario.Model.Dto;

namespace ProyectoFinal_TiendaNet.Auth.Controller
{
	[Route("api/auth")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly AuthServices _authServices;
		private readonly UsuarioServices _userServices;
		private readonly RolServices _roleServices;
		private readonly IEncoderServices _encoderServices;
		private readonly IMapper _mapper;
		private readonly CarritoServices _cartServices;

		public AuthController(AuthServices authServices, UsuarioServices userServices, RolServices roleServices, IMapper mapper, IEncoderServices encoderServices, CarritoServices cartServices)
		{
			_authServices = authServices;
			_userServices = userServices;
			_roleServices = roleServices;
			_mapper = mapper;
			_encoderServices = encoderServices;
			_cartServices = cartServices;
		}

		[HttpPost("login")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(CustomMessage), StatusCodes.Status400BadRequest)]
		[ProducesResponseType(typeof(CustomMessage), StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<LoginResponseDTO>> Login([FromBody] Login login)
		{
			try
			{
				var user = await _userServices.GetOneByUsernameOrEmail(login.Username, login.Email);

				// Si no existe el usuario, lanzar un error específico
				if (user == null)
				{
					throw new CustomHttpException("No se encontró una cuenta con ese correo o nombre de usuario", HttpStatusCode.BadRequest);
				}

				var passwordMatch = _encoderServices.Verify(login.Contraseña, user.Contraseña);

				if (!passwordMatch)
				{
					throw new CustomHttpException("Invalid Credentials", HttpStatusCode.BadRequest);
				}

				var token = _authServices.GenerateJwtToken(user);

				var userMapped = _mapper.Map<UsuarioLoginResponseDTO>(user);

				return Ok(new LoginResponseDTO { Token = token, Usuario = userMapped });
			}
			catch (CustomHttpException ex)
			{
				return StatusCode((int)ex.StatusCode, new CustomMessage(ex.Message));
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new CustomMessage(ex.Message));
			}
		}

		[HttpPost("register")]
		[ProducesResponseType(typeof(CustomMessage), StatusCodes.Status201Created)]
		[ProducesResponseType(typeof(CustomMessage), StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<ActionResult<UsuarioDTO>> Register([FromBody] CreateUsuarioDTO register)
		{
			try
			{
				// Verificar si el usuario ya existe
				var user = await _userServices.GetOneByUsernameOrEmail(register.Username, register.Email);
				if (user != null)
				{
					return BadRequest(new CustomMessage("El usuario ya existe."));
				}

				// Crear el usuario
				var userCreated = await _userServices.CreateOne(register);

				return Ok(userCreated);
			}
			catch (CustomHttpException ex)
			{
				return StatusCode((int)ex.StatusCode, new CustomMessage(ex.Message));
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new CustomMessage(ex.ToString()));
			}


		}
	}
}
