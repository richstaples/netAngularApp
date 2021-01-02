using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        /// <summary>
        /// Controller to provide user functions
        /// </summary>
        /// <param name="context"></param>
        public UsersController(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all Users defined in the Users table of the Application Database
        /// </summary>
        /// <returns>A list of users in the format of Id,Name</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        /// <summary>
        /// Gets a User specified by the Id
        /// </summary>
        /// <param name="id">Id of the User</param>
        /// <returns> User in the format of Id,Name</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<bool>> UpdateUserFirstName(int id, string firstname)
        {
            //retrieve the user
            var user = new AppUser()
            {
                Id = id,
                Firstname = firstname
            };

            await using (var context = _context)
            {
                try
                {
                    context.Update(user);
                    await context.SaveChangesAsync();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return false;
                    //throw;
                }
            }
        }
    }
}