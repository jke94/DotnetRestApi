namespace DotnetRestApi.WebApi.Controllers
{
    using DotnetRestApi.Abstractions.Application;
    using DotnetRestApi.Entities;
    using DotnetRestApi.WebApi.DTOs;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class FootballTeamController : ControllerBase
    {
        private IApplication<FootballTeam> _football;

        public FootballTeamController(IApplication<FootballTeam> football)
        {
            _football = football;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_football.GetAll());
        }

        [HttpPost]
        public IActionResult Save(FootballTeamDto dto)
        {
            var element = new FootballTeam()
            {
                Name = dto.Name,
                Score = dto.Score,
                Manager = dto.Manager
            };

            return Ok(_football.Save(element));
        }
    }
}
