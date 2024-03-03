using API_Produtos.Interface;
using API_Produtos.Models;
using API_Produtos.Models.Token;
using API_Produtos.Token;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_Produtos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("/api/v1/auth")]
        public async Task<IActionResult> Auth([FromBody] LoginToken login)
        {
            try
            {
                var userExists = _userService.GetByEmail(login);

                if (userExists == null)
                    return BadRequest(new { Message = "Email e/ou senha está(ão) inválido(s)." });

                var token = JwtAuth.GenerateToken(userExists);

                return Ok(new
                {
                    Token = token                
                });

            }
            catch (Exception)
            {
                return BadRequest(new { Message = "Ocorreu algum erro interno na aplicação, por favor tente novamente." });
            }
        }
    }
}
