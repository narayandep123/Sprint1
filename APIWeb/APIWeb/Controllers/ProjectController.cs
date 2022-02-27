using APIWeb.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        List<ProjectModel> projects = new List<ProjectModel>()
        {
            new ProjectModel (1, "TestProject1", "This is a test project", DateTime.Parse("2022-01-13")),
            new ProjectModel (2, "TestProject1", "This is a test project", DateTime.Parse("2022-01-13")),
            new ProjectModel (3, "TestProject1", "This is a test project", DateTime.Parse("2022-01-13")),
            new ProjectModel (4, "TestProject1", "This is a test project", DateTime.Parse("2022-01-13"))
        };
        // GET: api/<ProjectController>
        [HttpGet]
        public List<ProjectModel> Get()
        {
            return projects;
        }

        // GET api/<ProjectController>/5
        [HttpGet("{id}")]
        public ProjectModel Get(int id)
        {
            ProjectModel project = projects.FirstOrDefault(a => a.Id == id);

            return project;
        }

        // POST api/<ProjectController>
        [HttpPost]
        public List<ProjectModel> Post([FromBody] ProjectModel value)
        {
            projects.Add(value);
            return projects;
        }

        // PUT api/<ProjectController>/5
        [HttpPut("{id}")]
        public List<ProjectModel> Put(int id, [FromBody] ProjectModel value)
        {
            ProjectModel projectToUpdate = projects.Find(a => a.Id == id);
            int index = projects.IndexOf(projectToUpdate);

            projects[index].Name = value.Name;
            projects[index].Detail = value.Detail;
            projects[index].CreatedOn = value.CreatedOn;

            return projects;
        }

        // DELETE api/<ProjectController>/5
        [HttpDelete("{id}")]
        public List<ProjectModel> Delete(int id)
        {
            ProjectModel project = projects.Find(a => a.Id == id);
            projects.Remove(project);
            return projects;
        }
    }
}
