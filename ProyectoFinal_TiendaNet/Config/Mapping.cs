using AutoMapper;
using ProyectoFinal_TiendaNet.Comprador.Model;

namespace ProyectoFinal_TiendaNet.Config
{
	public class Mapping : Profile
	{
		public Mapping()
		{
			// Para no convertir los atributos 'int?' a 0 en la conversion de los 'null'
			// valor defecto int -> 0
			CreateMap<int?, int>().ConvertUsing((src, dest) => src ?? dest);

			// Aqui es necesario hacer esto con bool? ya que tampoco devuelve el tipo 'null'.
			// valor defecto bool -> false
			CreateMap<bool?, bool>().ConvertUsing((src, dest) => src ?? dest);

			//PD: Esta solución hay que aplicarla para todos aquellos tipos que no tengan como valor por defecto 'null'

			// Usuarios
			CreateMap<Usuario.Model.Usuario, Usuario.Model.Dto.UsuarioDTO>().ReverseMap();
			CreateMap<Usuario.Model.Usuario, Usuario.Model.Dto.UsuariosDTO>().ReverseMap();
			CreateMap<Usuario.Model.Usuario, Usuario.Model.Dto.CreateUsuarioDTO>().ReverseMap();
			//Me falta el Update, Antonio me tenia que recomendar algo

			//Carrito
			//CarritoProducto
			//CategoriaProducto
			//CategoriaTienda
			//Compra

			//Comprador
			CreateMap<Comprador.Model.Comprador, Comprador.Model.Dto.CompradorDTO>().ReverseMap();
			CreateMap<Comprador.Model.Comprador, Comprador.Model.Dto.CompradoresDTO>().ReverseMap();
			CreateMap<Comprador.Model.Comprador, Comprador.Model.Dto.CreateCompradorDTO>().ReverseMap();
			//Me falta el Update, Antonio me tenia que recomendar algo

			//DetalleCompra
			//MetodoPago
			//Personalizacion
			//Plantilla
			//Producto
			//Tienda
			//Vendedor
			CreateMap<Vendedor.Model.Vendedor, Vendedor.Model.Dto.VendedorDTO>().ReverseMap();
			CreateMap<Vendedor.Model.Vendedor, Vendedor.Model.Dto.VendedoresDTO>().ReverseMap();
			CreateMap<Vendedor.Model.Vendedor, Vendedor.Model.Dto.CreateVendedorDTO>().ReverseMap();
			//Me falta el Update, Antonio me tenia que recomendar algo
		}
	}
}
