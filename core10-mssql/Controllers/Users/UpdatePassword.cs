using core10_mssql.Entities;
using core10_mssql.Helpers;
using core10_mssql.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using core10_mssql.Models;

namespace core10_mssql.Controllers.Users;

[ApiExplorerSettings(GroupName = "Update User")]
[Authorize]
[ApiController]
[Route("[controller]")]
public class UpdatePasswordController : ControllerBase {
        
    private IUserService _userService;

    private IMapper _mapper;
    private readonly IConfiguration _configuration;  

    private readonly IWebHostEnvironment _env;

    private readonly ILogger<UpdatePasswordController> _logger;

    public UpdatePasswordController(
        IConfiguration configuration,
        IWebHostEnvironment env,
        IUserService userService,
        IMapper mapper,
        ILogger<UpdatePasswordController> logger
        )
    {
        _configuration = configuration;  
        _userService = userService;
        _mapper = mapper;
        _logger = logger;
        _env = env;        
    }  

        [HttpPatch("/api/changepassword/{id}")]        
        public IActionResult updateUserPassword(int id, [FromBody]UserPasswordUpdate model) {
            var user = _mapper.Map<User>(model);
            user.Id = id;
            try
            {
                _userService.UpdatePassword(user, model.Password);
                return Ok(new {message="Your profile password has been updated.",user = model});
            }
            catch (AppException ex)
            {
                return BadRequest(new {message = ex.Message });
            }
        }
}
