using MedicalManagementSystem.Api.Base;
using MedicalManagementSystem.Api.Helper;
using MedicalManagementSystem.Application.Features.Doctors.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicalManagementSystem.Api.Controllers
{
    public class DoctorsController : AppControllerBase
    {

        [HttpPost, Route("Doctor")]
        public async Task<IActionResult> Create(CreateDoctor command) => NewResult(await Mediator.Send(command));

        [HttpPut, Route("Doctor")]
        public async Task<IActionResult> Update(UpdateDoctor command) => NewResult(await Mediator.Send(command));

        [HttpDelete, Route("Doctor")]
        public async Task<IActionResult> Delete(DeleteDoctor command) => NewResult(await Mediator.Send(command));

        [HttpGet, Route("Doctors/{id}")]
        public async Task<IActionResult> Get(int id) => NewResult(await Mediator.Send(new GetDoctorDetails(id)));

        [HttpGet, Route("Doctors")]
        [Cache(180)]
        public async Task<IActionResult> GetAll() => NewResult(await Mediator.Send(new GetDoctorList()));

        [HttpGet, Route("Paginated")]
        public async Task<IActionResult> Paginated([FromQuery] GetDoctorPaginatedList query) => Ok(await Mediator.Send(query));
    }
}
