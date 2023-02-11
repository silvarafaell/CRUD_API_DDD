using AutoMapper;
using CRUD.Application.Extensions;
using CRUD.Application.Interfaces;
using CRUD.Domain.Interfaces;
using CRUD.Domain.Models;
using System.Net;

namespace CRUD.Application.Services
{
    public class EmpregadoService : Service, IEmpregadoService
    {
        private readonly IEmpregadoRepository _repository;

        public EmpregadoService(IEmpregadoRepository repository, IMapper mapper) : base(mapper)
            => _repository = repository;

        public async Task<OperationResult> CreateEmpregado(Empregado empregado)
        {
            if (empregado is null)
                return Error(ErrorMessages.IdNotFoundError(), HttpStatusCode.NotFound);

            await _repository.InsertAsync(empregado);

            return Success();
        }

        public async Task<OperationResult> FindAll()
        {
            var empregado = await _repository.GetAllAsync();

            if (!empregado.Any())
                return Error(ErrorMessages.IdNotFoundError(), HttpStatusCode.NotFound);

            return Success(empregado);
        }

        public async Task<OperationResult> FindByMatricula(int matricula)
        {
            var empregado = await _repository.GetByMatriculaAsync(matricula);

            if (empregado is null)
                return Error(ErrorMessages.MatriculaNotFoundError(), HttpStatusCode.NotFound);

            return Success(empregado);
        }

        public async Task<OperationResult> Delete(int matricula)
        {
            var empregado = await _repository.GetByMatriculaAsync(matricula);

            if (empregado is null)
                return Error(ErrorMessages.MatriculaNotFoundError(), HttpStatusCode.NotFound);

            await _repository.DeleteAsync(empregado);

            return Success(empregado);
        }

        public async Task<OperationResult> Update (int matricula)
        {
            var empregado = await _repository.GetByMatriculaAsync(matricula);

            if (empregado is null)
                return Error(ErrorMessages.MatriculaNotFoundError(), HttpStatusCode.NotFound);

            await _repository.UpdateAsync(empregado);

            return Success(empregado);
        }
    }
}
