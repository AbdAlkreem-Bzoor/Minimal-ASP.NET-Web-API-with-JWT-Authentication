using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinimalAPI___JWT_Authentication.Entities;
using MinimalAPI___JWT_Authentication.Repositories;
using MinimalAPI___JWT_Authentication.Services;

namespace MinimalAPI___JWT_Authentication.Controllers
{
    [Route("api/users")]
    [Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;   
        private readonly IRepository _repository;
        public UserController(IRepository repository, 
            ILogger<UserController> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsersAsync()
        {
            return Ok(await _repository.GetUsers());
        }
        [HttpGet("{userName}")]
        public async Task<ActionResult<User>> GetUserAsync(string? userName)
        {
            var user = await _repository.GetUserAsync(userName);
            if (user is null)
            {
                _logger.LogInformation($"User doesn't exists ({userName}).");
                return NotFound();
            }
            return Ok(user);
        }
        [HttpGet("weatherforcasts")]
        public ActionResult<IEnumerable<WeatherForecast>> GetWeatherForecasts()
        {
            return Ok(WeatherForecastController.GetWeatherForecasts());
        }
        [HttpGet("todayweatherforcast")]
        public ActionResult<WeatherForecast> GetTodayWeatherForecast()
        {
            return Ok(WeatherForecastController.GetTodayWeatherForecast());
        }
        [HttpPost]
        public async Task<ActionResult<bool>> AddUserAsync(User user)
        {
            var result = await _repository.AddUserAsync(user);
            if (!result)
            {
                _logger.LogInformation($"Username already exists.");
                return Conflict();
            }
            await _repository.SaveChangesAsync();
            return Ok(result);
        }
        [HttpPut("{userName}")]
        public async Task<ActionResult<bool>> UpdateUserAsync(string? userName, User updatedUser)
        {
            var user = await _repository.GetUserAsync(userName);
            if (user is null)
            {
                _logger.LogInformation($"User doesn't exists ({userName}).");
                return NotFound();
            }
            var result = await _repository.UpdateUserAsync(userName, updatedUser);
            await _repository.SaveChangesAsync();
            return Ok(result);
        }
        [HttpDelete("{userName}")]
        public async Task<ActionResult<bool>> DeleteUserAsync(string? userName)
        {
            var result = await _repository.DeleteUserAsync(userName);
            if (!result)
            {
                _logger.LogInformation($"User doesn't exists ({userName}).");
                return NotFound();
            }
            await _repository.SaveChangesAsync();
            return Ok(result);
        }
    }
}
