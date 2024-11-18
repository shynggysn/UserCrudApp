using CrudApp.Data;
using CrudApp.Models;
using CrudApp.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public UsersController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = dbContext.Users.ToList();
            return Ok(users);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetUserById(Guid id)
        {
            var user = dbContext.Users.Find(id);
            if (user is null)
            {
                return NotFound();
            }
            return Ok(user);
        }


        [HttpPost]
        public IActionResult AddNewUser(AddUserDto dto)
        {
            var userEntity = new User()
            {
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone,
                Age = dto.Age
            };

            dbContext.Users.Add(userEntity);
            dbContext.SaveChanges();

            return Ok(userEntity);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateUser(Guid id, UpdateUserDto dto)
        {
            var user = dbContext.Users.Find(id);

            if (user is null)
            {
                return NotFound();
            }

            user.Name = dto.Name;
            user.Email = dto.Email;
            user.Phone = dto.Phone;
            user.Age = dto.Age;

            dbContext.SaveChanges();

            return Ok(user);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteUser(Guid id)
        {
            var user = dbContext.Users.Find(id);

            if (user is null)
            {
                return NotFound();
            }
            
            dbContext.Users.Remove(user);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
