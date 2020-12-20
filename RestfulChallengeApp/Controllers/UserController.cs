using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestfulChallengeApp.Data;
using RestfulChallengeApp.Models;
using RestSharp;
using Swashbuckle.AspNetCore.Annotations;

namespace RestfulChallengeApp.Controllers
{
    [Route("Usuarios/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private UserDbContext _userDbContext;
        public UserController(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }
        [SwaggerOperation(Summary = "Muestra todos los usuarios", Description = "Devuelve un json con la informacion de todos los usuarios.")]
        [HttpGet]
        public IActionResult GetUsers()
        {
        return Ok(_userDbContext.Users);

        }
        [SwaggerOperation(Summary = "Muestra la informacion de un usuario", Description = "Recibe el id y devuelve el usuario con el id especificado")]
        // GET: UserController/Details/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var user = _userDbContext.Users.Find(id);
            if(user == null)
            {
              return NotFound("No user found with this id");
            }
              return Ok(user);
        }
        //POST para crear un nuevo usuario.
        [SwaggerOperation(Summary = "Alta de usuario", Description = "POST para crear un nuevo usuario.")]

        [HttpPost]
        public void Post([FromBody] User user)
        {
            _userDbContext.Users.Add(user);
            _userDbContext.SaveChanges();
        }
        //PUT para actualizar el usuario.
        [SwaggerOperation(Summary = "Actualizar usuario", Description = "PUT para modificar los valores de un usuario.")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            //Checkeo si el usuario con el id indicado existe.
            var entity = _userDbContext.Users.Find(id);
            if(entity == null)
            {
                return NotFound("No user found with this id");
            } 
            entity.Nombre = user.Nombre;
            entity.Apellido = user.Apellido;
            entity.Email = user.Email;
            entity.Password = user.Password;
            _userDbContext.SaveChanges();
            return Ok("User modified");
        }
        //DELETE para eliminar un usuario. En caso de que no exista un usuario con el id indicado, se devuelve un error indicandolo.
        [SwaggerOperation(Summary = "Eliminar un usuario", Description = "DELETE para eliminar un usuario segun su id")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var user = _userDbContext.Users.Find(id);
            if (user == null)
            {
                return NotFound("No record found againts this id....");
            }
            _userDbContext.Users.Remove(user);
            _userDbContext.SaveChanges();
            return Ok("Quote deleted...");
        }


    }
}
