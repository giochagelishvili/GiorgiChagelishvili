using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDo.API.Infrastructure.Models.Subtasks;
using ToDo.Application.Subtasks.Interfaces;
using ToDo.Application.Subtasks.Requests;
using ToDo.Domain.BaseEntities;

namespace ToDo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SubtaskController : ControllerBase
    {
        private readonly ISubtaskService _service;

        public SubtaskController(ISubtaskService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task Post(CancellationToken cancellationToken, SubtaskRequestPostModel subtask)
        {
            int.TryParse(User.FindFirst("Id")?.Value, out int ownerId);

            await _service.CreateAsync(cancellationToken, subtask, ownerId);
        }

        [HttpPut("{id}")]
        public async Task Put(CancellationToken cancellationToken, SubtaskPutModel subtask, int id)
        {
            int.TryParse(User.FindFirst("Id")?.Value, out int ownerId);

            var request = subtask.Adapt<SubtaskRequestPutModel>();

            request.Id = id;

            await _service.UpdateAsync(cancellationToken, request, ownerId);
        }

        [HttpDelete("{id}")]
        public async Task Delete(CancellationToken cancellationToken, int id)
        {
            int.TryParse(User.FindFirst("Id")?.Value, out int ownerId);

            await _service.DeleteAsync(cancellationToken, id, ownerId);
        }

        [HttpPatch("{id}")]
        public async Task Patch(CancellationToken cancellationToken, Status status, int id)
        {
            int.TryParse(User.FindFirst("Id")?.Value, out int ownerId);

            await _service.UpdateStatusAsync(cancellationToken, status, id, ownerId);
        }
    }
}
