using API_Produtos.Interface;
using API_Produtos.Models;
using API_Produtos.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Produtos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
       private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Authorize(Roles = "Dono")]
        public IActionResult AddUser(UserDTO userDTO)
        {
            return Ok(_userService.addUser(userDTO));
        }


        [HttpDelete("id:int")]
        [Authorize(Roles = "Dono")]
        public IActionResult Delete(int id)
        {
            var user = _userService.removeUser(id);

            if (user == null) return NotFound();

            return Ok(user);
        }

        [HttpPut]
        [Authorize(Roles = "Dono,Gerente")]
        public IActionResult Update(int id, UserDTO userDTO)
        {
            var user = _userService.updateUser(userDTO, id);

            if (user == null) return NotFound();

            return Ok(user);
        }
    }
}
