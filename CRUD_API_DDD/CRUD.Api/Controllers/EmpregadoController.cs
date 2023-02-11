using CRUD.Application.Interfaces;
using CRUD.Application.ViewModels;
using CRUD.Domain.Models;
using CRUD_API_DDD.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Api.Controllers
{
    [Route("api/empregado")]
    [ApiController]
    public class EmpregadoController : ApiController
    {
        private readonly IEmpregadoService _service;

        public EmpregadoController(IEmpregadoService service)
        => _service = service;

        [HttpPost]
        [ProducesResponseType(typeof(Empregado), 200)]
        [ProducesResponseType(typeof(ErrorViewModel), 404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult> PostEmpregado(Empregado empregado)
         => CustomResponse(await _service.CreateEmpregado(empregado));

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Empregado>), 200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<Empregado>>> Get()
            => CustomResponse(await _service.FindAll());

        [HttpGet("{matricula}")]
        [ProducesResponseType(typeof(Empregado), 200)]
        [ProducesResponseType(typeof(ErrorViewModel), 404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Empregado>> Get(int matricula)
            => CustomResponse(await _service.FindByMatricula(matricula));

        [HttpDelete("{matricula}")]
        [ProducesResponseType(typeof(Empregado), 200)]
        [ProducesResponseType(typeof(ErrorViewModel), 404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Empregado>> Delete(int matricula)
            => CustomResponse(await _service.Delete(matricula));

        [HttpPut("{matricula}")]
        [ProducesResponseType(typeof(Empregado), 200)]
        [ProducesResponseType(typeof(ErrorViewModel), 404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Empregado>> Update(int matricula)
           => CustomResponse(await _service.Update(matricula));
    }
}
