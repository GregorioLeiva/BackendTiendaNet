using ProyectoFinal_TiendaNet.Config;
using ProyectoFinal_TiendaNet.Utils.Repository;

namespace ProyectoFinal_TiendaNet.Comprador.Repository
{
	public interface ICompradorRepository : IRepository<Comprador.Model.Comprador> { }
	public class CompradorRepository : Repository<Comprador.Model.Comprador>, ICompradorRepository
	{
		public CompradorRepository(ApplicationDbContext db) : base(db)
		{ }
	}
}
