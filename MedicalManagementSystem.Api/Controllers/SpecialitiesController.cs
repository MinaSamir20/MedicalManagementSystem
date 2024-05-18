using MedicalManagementSystem.Api.Base;
using MedicalManagementSystem.Api.Helper;
using MedicalManagementSystem.Application.Features.Specialities.Models;
using Microsoft.AspNetCore.Mvc;

namespace MedicalManagementSystem.Api.Controllers
{
    public class SpecialitiesController : AppControllerBase
    {
        [HttpPost, Route("Speciality")]
        public async Task<IActionResult> Create(CreateSpeciality command) => NewResult(await Mediator.Send(command));

        [HttpPut, Route("Speciality")]
        public async Task<IActionResult> Update(UpdateSpeciality command) => NewResult(await Mediator.Send(command));

        [HttpDelete, Route("Speciality")]
        public async Task<IActionResult> Delete(DeleteSpeciality command) => NewResult(await Mediator.Send(command));

        [HttpGet, Route("Specialities/{id}")]
        public async Task<IActionResult> Get(int id) => NewResult(await Mediator.Send(new GetSpecialityDetails(id)));

        [HttpGet, Route("Specialities")]
        [Cache(180)]
        public async Task<IActionResult> GetAll() => NewResult(await Mediator.Send(new GetSpecialityList()));

        [HttpGet, Route("Paginated")]
        public async Task<IActionResult> Paginated([FromQuery] GetSpecialityPaginatedList query) => Ok(await Mediator.Send(query));
    }
}
