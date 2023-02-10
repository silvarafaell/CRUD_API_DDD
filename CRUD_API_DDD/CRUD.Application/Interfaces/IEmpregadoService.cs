using CRUD.Application.Extensions;
using CRUD.Domain.Models;

namespace CRUD.Application.Interfaces
{
    public interface IEmpregadoService
    {
        Task<OperationResult> CreateAgency(Empregado empregado);

        Task<OperationResult> FindAll();

        Task<OperationResult> FindById(int id);

    }
}
