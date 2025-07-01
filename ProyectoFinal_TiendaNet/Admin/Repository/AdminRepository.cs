using ProyectoFinal_TiendaNet.Config;
using ProyectoFinal_TiendaNet.Utils.Repository;

namespace ProyectoFinal_TiendaNet.Admin.Repository
{
	public interface IAdminRepository : IRepository<Admin.Model.Admin> { }
	public class AdminRepository : Repository<Admin.Model.Admin>, IAdminRepository
	{
		public AdminRepository(ApplicationDbContext db) : base(db)
		{ }
	}
}
