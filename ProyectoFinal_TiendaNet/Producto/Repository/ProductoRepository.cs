using ProyectoFinal_TiendaNet.Config;
using ProyectoFinal_TiendaNet.Utils.Repository;

namespace ProyectoFinal_TiendaNet.Producto.Repository
{
	public interface IProductoRepository : IRepository<Producto.Model.Producto> { }
	public class ProductoRepository : Repository<Producto.Model.Producto>, IProductoRepository
	{
		public ProductoRepository(ApplicationDbContext db) : base(db)
		{
		}
	}
}
