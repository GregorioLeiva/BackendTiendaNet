using ProyectoFinal_TiendaNet.Config;
using ProyectoFinal_TiendaNet.Utils.Repository;

namespace ProyectoFinal_TiendaNet.Rol.Repository
{
	public interface IRolRepository : IRepository<Rol.Model.Rol> { }
	public class RolRepository : Repository<Rol.Model.Rol>, IRolRepository
	{
		public RolRepository(ApplicationDbContext db) : base(db)
		{
		}
	}
}
