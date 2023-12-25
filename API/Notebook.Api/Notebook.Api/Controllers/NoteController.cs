using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Notebook.Api.Domain;
using Notebook.Api.DTO;
using Notebook.Api.Services.IServices;

namespace Notebook.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteService _service;

        public NoteController(INoteService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNote([FromBody] NoteDto request)
        {
            await _service.CreateAsync(request);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNotes()
        {
            var response = await _service.GetAllAsync();
            return Ok(response);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await _service.GetById(id);
            return Ok(response);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateNote([FromRoute] int id, UpdateNoteRequestDto request)
        {
            var response = await _service.Update(id, request);

            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteNote([FromRoute] int id)
        {
            await _service.Delete(id);
            return Ok();
        }
    }

}
