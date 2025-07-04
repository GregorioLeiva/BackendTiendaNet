using ProyectoFinal_TiendaNet.Config;
using ProyectoFinal_TiendaNet.Utils.Repository;

namespace ProyectoFinal_TiendaNet.Carrito.Repository
{
	public interface ICarritoRepository : IRepository<Carrito.Model.Carrito> { }
	public class CarritoRepository : Repository<Carrito.Model.Carrito>, ICarritoRepository
	{
		public CarritoRepository(ApplicationDbContext db) : base(db)
		{
		}
	}
}
