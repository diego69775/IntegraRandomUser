using IntegraRandomUser.Data;
using IntegraRandomUser.DTOs;
using IntegraRandomUser.Interfaces;
using IntegraRandomUser.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntegraRandomUser.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly AppDbContext _context;

        public UserController(IUserService userService, AppDbContext context)
        {
            _userService = userService;
            _context = context;
        }

        // GET -> Consulta na Random Users
        [HttpGet]
        public async Task<ActionResult<UserDTO?>> GetUser()
        {
            var result = await _userService.GetUserAsync();
            if (result == null)
                return NotFound(new { message = "User não encontrado na RandomUser." });
            return Ok(result);
        }
        //public async Task<IActionResult> GetUser()
        //{
        //var result = await _userService.GetUserAsync();
        //if (result == null)
        //return NotFound("No user found from external API.");

        //return Ok(result);
        //}

        // POST -> Consulta na Random User e salva no banco
        [HttpPost]
        public async Task<IActionResult> CreateUser()
        {
            var apiResult = await _userService.GetUserAsync();
            if (apiResult == null)
                return NotFound(new { message = "User não encontrado na RandomUser." });

            var entity = new User
            {
                FirstName = apiResult.FirstName,
                LastName = apiResult.LastName,
                Email = apiResult.Email,
                Username = apiResult.Username,
                Gender = apiResult.Gender,
                City = apiResult.City,
                State = apiResult.State,
                Country = apiResult.Country
            };

            _context.Users.Add(entity);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
        }

        //GET -> Lista todos os Users salvos no banco
        [HttpGet("db")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        // GET -> Buscar por Id no banco
        [HttpGet("db/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound(new { message = "User not found in the database." });

            return Ok(user);
        }

        // PUT -> Atualiza User no banco
        [HttpPut("db/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] User updateUser)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound(new { message = "User not found in the database." });

            user.FirstName = updateUser.FirstName;
            user.LastName = updateUser.LastName;
            user.Email = updateUser.Email;
            user.Username = updateUser.Username;
            user.Gender = updateUser.Gender;
            user.City = updateUser.City;
            user.State = updateUser.State;
            user.Country = updateUser.Country;

            await _context.SaveChangesAsync();
            return Ok(user);
        }
    }
}
