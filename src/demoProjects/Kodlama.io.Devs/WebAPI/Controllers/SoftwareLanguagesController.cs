using Application.Features.SoftwareLanguages.Command.CreateSoftwareLanguage;
using Application.Features.SoftwareLanguages.Command.DeleteSoftwareLanguage;
using Application.Features.SoftwareLanguages.Command.UpdateSoftwareLanguage;
using Application.Features.SoftwareLanguages.Dtos.SoftwareLanguage;
using Application.Features.SoftwareLanguages.Models;
using Application.Features.SoftwareLanguages.Queries.GetByIdSoftwareLanguage;
using Application.Features.SoftwareLanguages.Queries.GetListSoftwareLanguage;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoftwareLanguagesController : BaseController
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> Add([FromBody] CreateSoftwareLanguageCommand createSoftwareLanguageCommand)
        {
            CreatedSoftwareLanguageDto result = await Mediator.Send(createSoftwareLanguageCommand);
            return Created("", result);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateSoftwareLanguageCommand updateSoftwareLanguageCommand)
        {
            UpdatedSoftwareLanguageDto result = await Mediator.Send(updateSoftwareLanguageCommand);
            return Created("", result);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete([FromBody] DeleteSoftwareLanguageCommand deleteSoftwareLanguageCommand)
        {
            DeletedSoftwareLanguageDto result = await Mediator.Send(deleteSoftwareLanguageCommand);
            return Created("", result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListSoftwareLanguageQuery getListSoftwareLanguageQuery = new() { PageRequest = pageRequest };

            SoftwareLanguageListModel result = await Mediator.Send(getListSoftwareLanguageQuery);

            return Ok(result);
        }

        [HttpGet("[action]{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdSoftwareLanguageQuery getByIdSoftwareLanguageQuery)
        {

            SoftwareLanguageGetByIdDto result = await Mediator.Send(getByIdSoftwareLanguageQuery);

            return Ok(result);
        }
    }
}
