
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ProyectoFinal_TiendaNet.Admin.Repository;
using ProyectoFinal_TiendaNet.Comprador.Repository;
using ProyectoFinal_TiendaNet.Config;
using ProyectoFinal_TiendaNet.Rol.Repository;
using ProyectoFinal_TiendaNet.Usuario.Repository;
using ProyectoFinal_TiendaNet.Utils.Encoder;
using ProyectoFinal_TiendaNet.Utils.Filters;
using ProyectoFinal_TiendaNet.Vendedor.Repository;
using System.Text;

namespace ProyectoFinal_TiendaNet
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v1", new OpenApiInfo
				{
					Version = "v1",
					Title = "Un e-commerce",
					//poner una descripcion y titulo como corresponde
					Description = "Es una API para un e-commerce de Proyecto Final",
				});
				options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					BearerFormat = "JWT",
					Description = "Ingrese el token JWT",
					Name = "Authorization",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.Http,
					Scheme = "bearer"
				});
				options.OperationFilter<AuthOperationFilter>();
			});

			// Services: Agregamos los servicios al scope para utilizar Inyección de Depndencias.
			builder.Services.AddScoped<IEncoderServices, EncoderServices>();
			builder.Services.AddScoped<Usuario.Services.UsuarioServices>();
			builder.Services.AddScoped<Rol.Services.RolServices>();
			builder.Services.AddScoped<Comprador.Services.CompradorServices>();
			builder.Services.AddScoped<Vendedor.Services.VendedorServices>();
			builder.Services.AddScoped<Admin.Services.AdminServices>();

			//Repositorios
			builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
			builder.Services.AddScoped<IRolRepository, RolRepository>();
			builder.Services.AddScoped<ICompradorRepository, CompradorRepository>();
			builder.Services.AddScoped<IVendedorRepository, VendedorRepository>();
			builder.Services.AddScoped<IAdminRepository, AdminRepository>();

			//AutoMapper
			builder.Services.AddAutoMapper(typeof(Mapping));

			//SQL
			builder.Services.AddDbContext<ApplicationDbContext>(options =>
			{
				options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection"));
			});

			//Secret Key
			var secretKey = builder.Configuration.GetSection("jwtSettings").GetSection("secretKey").ToString();

			//JWT
			builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options =>
				{
					options.SaveToken = true;
					options.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuerSigningKey = true,
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
						ValidateIssuer = false,
						ValidateAudience = false,
						ValidateLifetime = true
					};


				});

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}
			//cors
			app.UseCors(options =>
			{
				options.AllowAnyHeader();
				options.AllowAnyMethod();
				options.AllowAnyOrigin();
			});

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
