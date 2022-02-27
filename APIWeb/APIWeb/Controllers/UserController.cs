using APIWeb.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        List<UserModel> users = new List<UserModel>()
        {
            new UserModel (1, "John", "Doe", "john.doe@test.com", "Password1"),
            new UserModel (2, "John", "Skeet", "john.Skeet@test.com", "Password2"),
            new UserModel (3, "Mark", "Seeman", "mark.Seeman@test.com", "Password3"),
            new UserModel (4, "Bob", "Martin", "bob.Martin@test.com", "Password3")
        };
        // GET: api/<UserController>
        [HttpGet]
        public List<UserModel> Get()
        {
            return users;
        }

        //Login API
        [HttpPost("{login}")]
        public bool Login(string email, string password)
        {
            return users.Where(x => x.Email == email && x.Password == password).Any();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public UserModel Get(int id)
        {
            UserModel user = users.FirstOrDefault(a => a.Id == id);

            return user;
        }

        // POST api/<UserController>
        [HttpPost]
        public List<UserModel> Post([FromBody] UserModel userModel)
        {
            users.Add(userModel);
            return users;
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public List<UserModel> Put(int id, [FromBody] UserModel userModel)
        {
            UserModel userToUpdate = users.Find(a => a.Id == id);
            int index = users.IndexOf(userToUpdate);

            users[index].FirstName = userModel.FirstName;
            users[index].LastName = userModel.LastName;
            users[index].Email = userModel.Email;
            users[index].Password = userModel.Password;

            return users;

        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public List<UserModel> Delete(int id)
        {
            UserModel user = users.Find(a=>a.Id == id);
            users.Remove(user);
            return users;
        }
    }
}
