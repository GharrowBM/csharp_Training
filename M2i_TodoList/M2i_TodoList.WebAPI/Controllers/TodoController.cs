using M2i_TodoList.Classes;
using M2i_TodoList.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace M2i_TodoList.WebAPI.Controllers;

[EnableCors("allConnections")]
[Route("todos")]
public class TodoController : ControllerBase
{
    private IRepository<Todo> _todoRepository;

    public TodoController(IRepository<Todo> todoRepository)
    {
        _todoRepository = todoRepository;
    }
    
    [HttpGet]
    public IActionResult GetList()
    {
        return new JsonResult(_todoRepository.GetAll());
    }

    [HttpGet("/{todoId}")]
    public IActionResult GetOne(int todoId)
    {
        return new JsonResult(_todoRepository.Get(todoId));
    }

    [HttpDelete("/{todoId}")]
    public IActionResult Delete(int todoId)
    {
        if (_todoRepository.Remove(todoId))
        {
            return Ok(new {message = "Deletion successful!"});
        }

        return NotFound(new {message = "Deletion failed..."});
    }

    [HttpPut]
    public IActionResult Update(int id, [FromBody] Todo newTodo)
    {
        if (_todoRepository.Update(id, newTodo))
        {
            return Ok(new {message = "Update successful!"});
        }

        return NotFound(new {message = "Update failed..."});
    }

    [HttpPost]
    public IActionResult Add([FromBody] Todo newTodo)
    {
        if (_todoRepository.Add(newTodo))
        {
            return Ok(new {message = "Todo added with success!"});
        }

        return NotFound(new {message = "Addition failed..."});
    }
}