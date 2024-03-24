using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDo.API.Infrastructure.Models.ToDoItems;
using ToDo.Application.ToDos.Interfaces;
using ToDo.Application.ToDos.Requests;
using ToDo.Application.ToDos.Responses;
using ToDo.Domain.BaseEntities;

namespace ToDo.API.Controllers
{
    [Route("v1/todos")]
    [ApiController]
    [Authorize]
    public class ToDoItemController : ControllerBase
    {
        private readonly IToDoItemService _service;

        public ToDoItemController(IToDoItemService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<ToDoItemResponseModel>> GetAll(CancellationToken cancellationToken, Status? status = null)
        {
            int.TryParse(User.FindFirst("Id")?.Value, out int ownerId);

            if (status != null)
                return await _service.GetAllAsync(cancellationToken, ownerId, status);

            return await _service.GetAllAsync(cancellationToken, ownerId);
        }

        [HttpGet("{id}")]
        public async Task<ToDoItemResponseModel> Get(CancellationToken cancellationToken, int id)
        {
            int.TryParse(User.FindFirst("Id")?.Value, out int ownerId);

            return await _service.GetAsync(cancellationToken, id, ownerId);
        }

        [HttpPost]
        public async Task Post(CancellationToken cancellationToken, ToDoItemRequestPostModel toDoItem)
        {
            int.TryParse(User.FindFirst("Id")?.Value, out int ownerId);

            await _service.CreateAsync(cancellationToken, toDoItem, ownerId);
        }

        [HttpPut("{id}")]
        public async Task Put(CancellationToken cancellationToken, ToDoItemPutModel toDoItem, int id)
        {
            int.TryParse(User.FindFirst("Id")?.Value, out int ownerId);

            var requestModel = toDoItem.Adapt<ToDoItemRequestPutModel>();

            requestModel.Id = id;
            requestModel.OwnerId = ownerId;

            await _service.UpdateAsync(cancellationToken, requestModel);
        }

        [HttpPatch("{id}")]
        public async Task Patch(CancellationToken cancellationToken, ToDoItemPatchModel toDoItem, int id)
        {
            int.TryParse(User.FindFirst("Id")?.Value, out int ownerId);

            var request = toDoItem.Adapt<ToDoItemRequestPutModel>();

            request.Id = id;
            request.OwnerId = ownerId;

            await _service.UpdateAsync(cancellationToken, request);
        }

        [HttpPatch("{id}/done")]
        public async Task Patch(CancellationToken cancellationToken, Status status, int id)
        {
            int.TryParse(User.FindFirst("Id")?.Value, out int ownerId);

            await _service.UpdateStatusAsync(cancellationToken, status, id, ownerId);
        }


        [HttpDelete("{id}")]
        public async Task Delete(CancellationToken cancellationToken, int id)
        {
            int.TryParse(User.FindFirst("Id")?.Value, out int ownerId);

            await _service.DeleteAsync(cancellationToken, id, ownerId);
        }
    }
}
