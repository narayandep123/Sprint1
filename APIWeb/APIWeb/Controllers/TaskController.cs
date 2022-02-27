using APIWeb.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        List<TaskModel> tasks = new List<TaskModel>()
        {
            new TaskModel (1, 1, 2, 1, "This ia test Task", DateTime.Parse("2022-01-13")),
            new TaskModel (2, 1, 3, 2, "This ia test Task", DateTime.Parse("2022-01-13")),
            new TaskModel (3, 2, 4, 2, "This ia test Task", DateTime.Parse("2022-01-13"))
        };
        // GET: api/<TaskController>
        [HttpGet]
        public List<TaskModel> Get()
        {
            return tasks;
        }

        // GET api/<TaskController>/5
        [HttpGet("{id}")]
        public TaskModel Get(int id)
        {
            TaskModel task = tasks.FirstOrDefault(a => a.Id == id);
            return task;
        }

        // POST api/<TaskController>
        [HttpPost]
        public List<TaskModel> Post([FromBody] TaskModel value)
        {
            tasks.Add(value);
            return tasks;
        }

        // PUT api/<TaskController>/5
        [HttpPut("{id}")]
        public List<TaskModel> Put(int id, [FromBody] TaskModel value)
        {
            TaskModel taskToUpdate = tasks.Find(a => a.Id == id);
            int index = tasks.IndexOf(taskToUpdate);

            tasks[index].ProjectId = value.ProjectId;
            tasks[index].Status = value.Status;
            tasks[index].AssignedToUserID = value.AssignedToUserID;
            tasks[index].Detail = value.Detail;
            tasks[index].CreatedOn = value.CreatedOn;

            return tasks;
        }

        // DELETE api/<TaskController>/5
        [HttpDelete("{id}")]
        public List<TaskModel> Delete(int id)
        {
            TaskModel task = tasks.Find(a => a.Id == id);
            tasks.Remove(task);
            return tasks;
        }
    }
}
