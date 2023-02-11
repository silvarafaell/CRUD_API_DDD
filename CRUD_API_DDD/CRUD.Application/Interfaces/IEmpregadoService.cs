using CRUD.Application.Extensions;
using CRUD.Domain.Models;

namespace CRUD.Application.Interfaces
{
    public interface IEmpregadoService
    {
        Task<OperationResult> CreateEmpregado(Empregado empregado);

        Task<OperationResult> FindAll();

        Task<OperationResult> FindByMatricula(int matricula);

        Task<OperationResult> Delete(int matricula);

        Task<OperationResult> Update(int matricula);

    }
}
