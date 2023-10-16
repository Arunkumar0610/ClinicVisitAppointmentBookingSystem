using BusinessLogicLayer.Services.IServices;
using DataAccessLayer.Models;
using DataAccessLayer.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace UserMicroservice.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UsersController> logger;
        public UsersController(IUserService Repo, ILogger<UsersController> logger)
        {
            _userService = Repo;
            this.logger = logger;
        }
        //User apis
        //api/Users/all
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<PatientDto>>> GetAll()
        {
                logger.LogInformation("Reteriving all registered users");
                var users = await _userService.GetAll();
                if (users.Count == 0)
                {
                    logger.LogError("No Users Found");
                    return NotFound("No Users Found");
                }
                logger.LogInformation("Reterived all registered users Successfully");
                return Ok(users);
        }
        //api/Users/<id>
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientDto>> GetById(string id)
        {
            logger.LogInformation("Retrieving user by id");
            var user = await _userService.GetByIdAsync(id);
            if (user.UserName==null)
            {
                logger.LogError($"User with Id ={id} not found");
                return NotFound($"User with Id={id} not found");
            }
            logger.LogInformation($"Retrieved user by id={id} Successfully");
            return Ok(user);
        }
        //api/Users/search/<username>
        [HttpGet("search/{username}")]
        public ActionResult<List<PatientDto>> GetByUsername(string username)
        {
            logger.LogInformation("Searching for a List of users by username");
            var user =  _userService.GetByUsername(username);
            if (user.Count == 0)
            {
                logger.LogError("No Users Found");
                return NotFound("No Users Found");
            }
            logger.LogInformation("List of Users Found successfully");
            return Ok(user);
        }
        // api/Users/register
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<PatientDto>> Register(PatientRegisterDto user)
        {
            logger.LogInformation("Register a user");
            var item = await _userService.Register(user);
            if (item == null)
            {
                logger.LogError("User Already exists with EmailId or Username");
                return BadRequest("UserName or Email already exists");
            }
            if( item.UserName == null)
            {
                logger.LogError("Password is InValid");
                return BadRequest("Password must be between 8 and 15 characters and contain atleast one uppercase,lowercase,number and special character.");
            }
            logger.LogInformation("Registered Successfully");
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }
        //api/Users/login
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginRequestDto loginReq)
        {
            logger.LogInformation("Login User");
            var logResponse = await _userService.Login(loginReq);
            if (logResponse.userName==null)
            {
                logger.LogError("Login Failed Due to username or password are incorrect");
                return Unauthorized("Username or password are incorrect");
            }
            return Ok(logResponse);
        }
    }
}
