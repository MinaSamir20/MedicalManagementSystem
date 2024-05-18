using MedicalManagementSystem.Api.Base;
using MedicalManagementSystem.Application.Features.Patients.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicalManagementSystem.Api.Controllers
{
    public class PatientsController : AppControllerBase
    {
        [HttpPost("Pateint")]
        public async Task<IActionResult> Create(CreatePatient command) => NewResult(await Mediator.Send(command));

        [HttpPut, Route("Pateint")]
        public async Task<IActionResult> Update(UpdatePatient command) => NewResult(await Mediator.Send(command));

        [HttpDelete, Route("Pateint")]
        public async Task<IActionResult> Delete(DeletePatient command) => NewResult(await Mediator.Send(command));

        [HttpGet, Route("Patients/{id}")]
        public async Task<IActionResult> Get(int id) => NewResult(await Mediator.Send(new GetPatientDetails(id)));

        [HttpGet, Route("Patients")]
        public async Task<IActionResult> GetAll() => NewResult(await Mediator.Send(new GetPatientList()));

        [HttpGet, Route("Paginated")]
        public async Task<IActionResult> Paginated([FromQuery] GetPatientPaginatedList query) => Ok(await Mediator.Send(query));
    }
}
