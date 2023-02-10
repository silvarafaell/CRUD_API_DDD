using CRUD.Application.Interfaces;
using CRUD.Application.ViewModels;
using CRUD.Domain.Models;
using CRUD_API_DDD.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static CRUD.Domain.Models.Empregado;

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
        public async Task<ActionResult> PostAgency(Empregado agency)
         => CustomResponse(await _service.CreateAgency(agency));

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Empregado>), 200)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<IEnumerable<Empregado>>> Get()
            => CustomResponse(await _service.FindAll());

        [HttpGet("{matricula}")]
        [ProducesResponseType(typeof(Empregado), 200)]
        [ProducesResponseType(typeof(ErrorViewModel), 404)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<Promocoes>> Get(int matricula)
            => CustomResponse(await _service.FindById(matricula));
    }
}
