using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using locusnine.Data;
using locusnine.Models;
using locusnine.Interfaces;


namespace locusnine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUser _userService;
        static List<Users> users = new List<Users>();
        public UsersController(IUser userService)
        {

            _userService = userService;
        }
        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            List<Users> users = await _userService.GetUsers();
            return Ok(users);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUser(string id)
        {
            var user = await _userService.GetUser(id);
            if (user == null)
                return NotFound(id);
            return Ok(user);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers(string id, Users users)
        {
            if (id != users.Id)
            {
                return BadRequest("Id required");
            }
            await _userService.Edit(id, users);
            return Ok();
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<Users>> PostUsers(Users users)
        {
            users.Id = Guid.NewGuid().ToString();

            if (!ModelState.IsValid)
                return BadRequest();

            await _userService.Add(users);

            return Created("User Created :", new { id = users.Id });
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task DeleteUsers(string id)
        {
            await _userService.Delete(id);
            return;
        }
    }
}
