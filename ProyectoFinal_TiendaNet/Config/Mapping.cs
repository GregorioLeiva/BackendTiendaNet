﻿using AutoMapper;
using ProyectoFinal_TiendaNet.Comprador.Model;
using ProyectoFinal_TiendaNet.Usuario.Model.Dto;

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
			CreateMap<Usuario.Model.Usuario, UsuarioLoginResponseDTO>().ReverseMap();

			//Me falta el Update, Antonio me tenia que recomendar algo

			//Carrito
			CreateMap<Carrito.Model.Carrito, Carrito.Model.Dto.CarritoDTO>().ReverseMap();
			CreateMap<Carrito.Model.Carrito, Carrito.Model.Dto.CreateCarritoDTO>().ReverseMap();
			//Me falta el Update, Antonio me tenia que recomendar algo

			//CarritoProducto
			CreateMap<CarritoProducto.Model.CarritoProducto, CarritoProducto.Model.Dto.CarritoProductoDTO>().ReverseMap();
			CreateMap<CarritoProducto.Model.CarritoProducto, CarritoProducto.Model.Dto.CreateCarritoProductoDTO>().ReverseMap();
			CreateMap<CarritoProducto.Model.CarritoProducto, CarritoProducto.Model.Dto.CarritosProductosDTO>().ReverseMap();
			//Me falta el Update, Antonio me tenia que recomendar algo

			//CategoriaProducto
			CreateMap<CategoriaProducto.Model.CategoriaProducto, CategoriaProducto.Model.Dto.CategoriaProductoDTO>().ReverseMap();
			CreateMap<CategoriaProducto.Model.CategoriaProducto, CategoriaProducto.Model.Dto.CategoriasProductoDTO>().ReverseMap();
			CreateMap<CategoriaProducto.Model.CategoriaProducto, CategoriaProducto.Model.Dto.CreateCategoriaProductoDTO>().ReverseMap();
			//Me falta el Update, Antonio me tenia que recomendar algo

			//CategoriaTienda
			CreateMap<CategoriaTienda.Model.CategoriaTienda, CategoriaTienda.Model.Dto.CategoriaTiendaDTO>().ReverseMap();
			CreateMap<CategoriaTienda.Model.CategoriaTienda, CategoriaTienda.Model.Dto.CategoriasTiendaDTO>().ReverseMap();
			CreateMap<CategoriaTienda.Model.CategoriaTienda, CategoriaTienda.Model.Dto.CreateCategoriaTiendaDTO>().ReverseMap();
			//Me falta el Update, Antonio me tenia que recomendar algo

			//Compra
			CreateMap<Compra.Model.Compra, Compra.Model.Dto.CompraDTO>().ReverseMap();
			CreateMap<Compra.Model.Compra, Compra.Model.Dto.ComprasDTO>().ReverseMap();
			CreateMap<Compra.Model.Compra, Compra.Model.Dto.CreateCompraDTO>().ReverseMap();
			// Me falta el Update, Antonio me tenia que recomendar algo

			//Comprador
			CreateMap<Comprador.Model.Comprador, Comprador.Model.Dto.CompradorDTO>().ReverseMap();
			CreateMap<Comprador.Model.Comprador, Comprador.Model.Dto.CompradoresDTO>().ReverseMap();
			CreateMap<Comprador.Model.Comprador, Comprador.Model.Dto.CreateCompradorDTO>().ReverseMap();
			//Me falta el Update, Antonio me tenia que recomendar algo

			//DetalleCompra
			CreateMap<DetalleCompra.Model.DetalleCompra, DetalleCompra.Model.Dto.DetalleCompraDTO>().ReverseMap();
			CreateMap<DetalleCompra.Model.DetalleCompra, DetalleCompra.Model.Dto.CreateDetalleCompraDTO>().ReverseMap();
			CreateMap<DetalleCompra.Model.DetalleCompra, DetalleCompra.Model.Dto.DetallesComprasDTO>().ReverseMap();
			//Me falta el Update, Antonio me tenia que recomendar algo

			//MetodoPago
			CreateMap<MetodoPago.Model.MetodoPago, MetodoPago.Model.Dto.MetodoPagoDTO>().ReverseMap();
			CreateMap<MetodoPago.Model.MetodoPago, MetodoPago.Model.Dto.MetodosPagoDTO>().ReverseMap();
			CreateMap<MetodoPago.Model.MetodoPago, MetodoPago.Model.Dto.CreateMetodoPagoDTO>().ReverseMap();
			//Me falta el Update, Antonio me tenia que recomendar algo

			//Personalizacion
			CreateMap<Personalizacion.Model.Personalizacion, Personalizacion.Model.Dto.PersonalizacionDTO>().ReverseMap();
			CreateMap<Personalizacion.Model.Personalizacion, Personalizacion.Model.Dto.PersonalizacionesDTO>().ReverseMap();
			CreateMap<Personalizacion.Model.Personalizacion, Personalizacion.Model.Dto.CreatePersonalizacionDTO>().ReverseMap();
			//Me falta el Update, Antonio me tenia que recomendar algo

			//Plantilla
			CreateMap<Plantilla.Model.Plantilla, Plantilla.Model.Dto.PlantillaDTO>().ReverseMap();
			CreateMap<Plantilla.Model.Plantilla, Plantilla.Model.Dto.PlantillasDTO>().ReverseMap();
			CreateMap<Plantilla.Model.Plantilla, Plantilla.Model.Dto.CreatePlantillaDTO>().ReverseMap();
			//Me falta el Update, Antonio me tenia que recomendar algo

			//Producto
			CreateMap<Producto.Model.Producto, Producto.Model.Dto.ProductoDTO>().ReverseMap();
			CreateMap<Producto.Model.Producto, Producto.Model.Dto.ProductosDTO>().ReverseMap();
			CreateMap<Producto.Model.Producto, Producto.Model.Dto.CreateProductoDTO>().ReverseMap();
			//Me falta el Update, Antonio me tenia que recomendar algo

			//Tienda
			CreateMap<Tienda.Model.Tienda, Tienda.Model.Dto.TiendaDTO>().ReverseMap();
			CreateMap<Tienda.Model.Tienda, Tienda.Model.Dto.TiendasDTO>().ReverseMap();
			CreateMap<Tienda.Model.Tienda, Tienda.Model.Dto.CreateTiendaDTO>().ReverseMap();
			//Me falta el Update, Antonio me tenia que recomendar algo

			//Admin
			CreateMap<Admin.Model.Admin, Admin.Model.Dto.AdminDTO>().ReverseMap();
			CreateMap<Admin.Model.Admin, Admin.Model.Dto.AdminsDTO>().ReverseMap();
			CreateMap<Admin.Model.Admin, Admin.Model.Dto.CreateAdminDTO>().ReverseMap();
			

			//Vendedor
			CreateMap<Vendedor.Model.Vendedor, Vendedor.Model.Dto.VendedorDTO>().ReverseMap();
			CreateMap<Vendedor.Model.Vendedor, Vendedor.Model.Dto.VendedoresDTO>().ReverseMap();
			CreateMap<Vendedor.Model.Vendedor, Vendedor.Model.Dto.CreateVendedorDTO>().ReverseMap();
			//Me falta el Update, Antonio me tenia que recomendar algo

			//Auth

		}
	}
}
