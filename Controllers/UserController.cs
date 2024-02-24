using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sqliteCRUD.Data;
using sqliteCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace sqliteCRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext appDbContext;

        public UserController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<ActionResult<List<User>>> AddUser(User newUser)
        {
            if (newUser != null)
            {
                appDbContext.Users.Add(newUser);
                await appDbContext.SaveChangesAsync();
                return Ok(await appDbContext.Users.ToListAsync());

            }
            return BadRequest("no object is created");

        }
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUser()
        {

            return Ok(await appDbContext.Users.ToListAsync());
        }

        [HttpGet("id;int")]
        public async Task<ActionResult<User>> GetUser(int id)
        {

            var user1=await appDbContext.Users.ToListAsync();
            var res=user1.Where(n=>n.Id==id).FirstOrDefault();
            return Ok(res);
            
        }
    }
}