using ProyectoFinal_TiendaNet.Config;
using ProyectoFinal_TiendaNet.Utils.Repository;

namespace ProyectoFinal_TiendaNet.CarritoProducto.Repository
{
	public interface ICarritoProductoRepository : IRepository<CarritoProducto.Model.CarritoProducto> { }
	public class CarritoProductoRepository : Repository<CarritoProducto.Model.CarritoProducto>, ICarritoProductoRepository
	{
		public CarritoProductoRepository(ApplicationDbContext db) : base(db)
		{
		}
	}
}
