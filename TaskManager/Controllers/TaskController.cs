using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Entities;
using TaskManager.Repositories;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TaskController : Controller
    {
        private readonly TaskRepository _taskRepository;

        public TaskController(TaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public ActionResult GetTasks()
        {
            return Ok(_taskRepository.GetAll());
        }

        [HttpGet("id")]

            public ActionResult GetTask(int id)
        {
            TaskItem task= _taskRepository.GetAll().FirstOrDefault(x => x.Id == id); 
            if (task==null)
                return NotFound();
            return Ok(task);


        }

        [HttpPost]
        public ActionResult CreateTask(TaskItem task)
        {
            _taskRepository.CreateTask(task);
            return Ok();
        }

        [HttpPut("id")]
            public ActionResult UpdateTask(int id, TaskItem task)
            {
                var existingTask = _taskRepository.Get(id);
                if (existingTask == null)
                    return NotFound();

                existingTask.Title = task.Title;
                existingTask.Description = task.Description;
                existingTask.DueDate = task.DueDate;
                existingTask.Status = task.Status;

                _taskRepository.Update(existingTask);
                return Ok();
            }
        

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var existingTask = _taskRepository.Get(id);
            if (existingTask == null)
                return NotFound();

            _taskRepository.Delete(id);
            return Ok();
        }
    }
}
