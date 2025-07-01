using ProyectoFinal_TiendaNet.Config;
using ProyectoFinal_TiendaNet.Utils.Repository;

namespace ProyectoFinal_TiendaNet.MetodoPago.Repository
{
	public interface IMetodoPagoRepository : IRepository<MetodoPago.Model.MetodoPago> { }
	public class MetodoPagoRepository : Repository<MetodoPago.Model.MetodoPago>, IMetodoPagoRepository
	{
		public MetodoPagoRepository(ApplicationDbContext db) : base(db)
		{
		}
	}
}
