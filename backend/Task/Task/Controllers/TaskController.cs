using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task.Contexts;
using Task.Models;

namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private AppDbContext _Context;
        public TaskController(AppDbContext Context)
        {
            _Context = Context;
        }
        [HttpGet]
        [Route("GetUsers")]
        public ActionResult<List<Users>> GetUsers()
        {
            return Ok( _Context.Users.ToList());
        }
        [HttpPost]
        public ActionResult<Users> Create(Users User)
        {
            _Context.Add(User);
             _Context.SaveChanges();
            return Ok(User);
        }
        [HttpPut("{id}")]
        public  ActionResult<Users> Update(int id, Users User)
        {
            if (id != User.ID)
            {
                return BadRequest();
            }
            _Context.Entry(User).State = EntityState.Modified;
             _Context.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public  ActionResult Delete(int id)
        {
            var item = _Context.Users.Find(id);
            if (item == null) return NotFound();
            _Context.Users.Remove(item);
            _Context.SaveChanges();
            return Ok();
        }
    }
}
