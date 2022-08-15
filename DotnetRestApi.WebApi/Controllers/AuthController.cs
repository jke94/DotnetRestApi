namespace DotnetRestApi.WebApi.Controllers
{
    using DotnetRestApi.Services;
    using DotnetRestApi.WebApi.Configuration;
    using DotnetRestApi.WebApi.DTOs;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        private readonly ITokenHandlerService _tokenHandlerService;

        public AuthController(UserManager<IdentityUser> userManager, ITokenHandlerService service)
        {
            _userManager = userManager;
            _tokenHandlerService = service;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequestDTO registerUserRequestDTO)
        {
            if (ModelState.IsValid) // Todos los campor requeridos de RegisterUserRequestDTO son validdos.
            {
                var user = await _userManager.FindByEmailAsync(registerUserRequestDTO.Email);

                if(user != null) // No ha encontrado ningún usario con el mismo mail.
                {
                    return BadRequest("El email usado para registrarse ya existe.");
                }

                var isCreated = await _userManager.CreateAsync( new IdentityUser()
                {
                    Email = registerUserRequestDTO.Email,
                    UserName = registerUserRequestDTO.Email, // Se usará también el mismo email para el nombre
                }, registerUserRequestDTO.Password);

                if (isCreated.Succeeded)
                {
                    return Ok();
                }
                else
                {

                    return BadRequest(isCreated.Errors.Select( x => x.Description).ToList());
                }
            }
            else
            {
                return BadRequest("Se produjo algún error al registrar el usuario.");
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequestDTO user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _userManager.FindByEmailAsync(user.Email);

                if (existingUser == null)
                {
                    return BadRequest(new UserLoginResponseDTO
                    {
                        Login = false,
                        Errors = new List<string>()
                        {
                            "Usuario o contraseña incorrecta!"
                        }
                    });
                }

                var isCorrect = await _userManager.CheckPasswordAsync(existingUser, user.Password);

                if (isCorrect)
                {
                    var parameters = new TokenParameters()
                    {
                        Id = existingUser.Id,
                        PasswordHash = existingUser.PasswordHash,
                        UserName = existingUser.UserName
                    };

                    var jwtToken = _tokenHandlerService.GenerateJwtToken(parameters);

                    return Ok(new UserLoginResponseDTO()
                    {
                        Login = true,
                        Token = jwtToken
                    });
                }
                else
                {
                    return BadRequest(new UserLoginResponseDTO
                    {
                        Login = false,
                        Errors = new List<string>()
                        {
                            "Usuario o contraseña incorrecta!"
                        }
                    });
                }
            }
            else
            {
                return BadRequest(new UserLoginResponseDTO
                {
                    Login = false,
                    Errors = new List<string>()
                        {
                            "Usuario o contraseña incorrecta!"
                        }
                });
            }
        }
    }
}
