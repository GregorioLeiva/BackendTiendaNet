using AutoMapper;
using ProyectoFinal_TiendaNet.Config;
using ProyectoFinal_TiendaNet.Producto.Model.Dto;
using ProyectoFinal_TiendaNet.Producto.Repository;
using ProyectoFinal_TiendaNet.Tienda.Model.Dto;
using ProyectoFinal_TiendaNet.Tienda.Repository;
using ProyectoFinal_TiendaNet.Utils.Exceptions;
using System.Net;

namespace ProyectoFinal_TiendaNet.Producto.Services
{
	public class ProductoServices
	{
		private readonly IMapper _mapper;
		private readonly IProductoRepository _productorepository;
		private readonly ApplicationDbContext _dbContext;
		public ProductoServices(IMapper mapper, IProductoRepository productoRepository, ApplicationDbContext dbContext)
		{
			_mapper = mapper;
			_productorepository = productoRepository;
			_dbContext = dbContext;
		}

		private async Task<Producto.Model.Producto> GetOneByIdOrException(int id)
		{
			var producto = await _productorepository.GetOne(p => p.Id == id);
			if (producto == null)
			{
				throw new CustomHttpException($"No se encontro el producto con Id = {id}", HttpStatusCode.NotFound);
			}
			return producto;
		}

		public async Task<Producto.Model.Producto> GetOneById(int id)
		{
			var producto = await GetOneByIdOrException(id);
			return _mapper.Map<Producto.Model.Producto>(producto);
		}
		public async Task<List<ProductosDTO>> GetAll()
		{
			var producto = await _productorepository.GetAll();
			return _mapper.Map<List<ProductosDTO>>(producto);
		}

		public async Task<Producto.Model.Producto> CreateOne(CreateProductoDTO createproductoDto)
		{
			var producto = _mapper.Map<Producto.Model.Producto>(createproductoDto);

			producto.FechaCreacion = DateTime.UtcNow;

			await _productorepository.Add(producto);
			return producto;
		}

		public async Task<Producto.Model.Producto> UpdateOneById(int id, UpdateProductoDTO updateproductoDto)
		{
			var producto = await GetOneByIdOrException(id);

			//Deberia ver si la fecha modificacion es null, si es null, comparo la fecha creacion con la de ahora
			//Si es mayor a 15 dias puedo cambiar el precio, sino, no puedo cambiar 

			var userMapped = _mapper.Map(updateproductoDto, producto);

			await _productorepository.Update(userMapped);

			return userMapped;
		}

		public async Task DeleteOneById(int id)
		{
			var producto = await GetOneByIdOrException(id);

			await _productorepository.Delete(producto);
		}
	}
}
