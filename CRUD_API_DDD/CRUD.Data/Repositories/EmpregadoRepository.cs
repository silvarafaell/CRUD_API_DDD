using CRUD.Domain.Interfaces;
using CRUD.Domain.Models;

namespace CRUD.Data.Repositories
{
    public class EmpregadoRepository : Repository<Empregado>, IEmpregadoRepository
    {
        public EmpregadoRepository(FactoryContext context) : base(context)
        {
        }
    }
}
