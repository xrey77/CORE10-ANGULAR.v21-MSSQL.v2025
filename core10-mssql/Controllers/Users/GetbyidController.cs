using Microsoft.AspNetCore.Mvc;
using core10_mssql.Services;
using AutoMapper;
using core10_mssql.Helpers;
using Microsoft.AspNetCore.Authorization;
using core10_mssql.Models;

namespace core10_mssql.Controllers.Users;

[ApiExplorerSettings(GroupName = "Retrieve User ID")]
[Authorize]    
[ApiController]
[Route("[controller]")]
public class GetbyidController : ControllerBase
{

    private IUserService _userService;

    private IMapper _mapper;
    private readonly IConfiguration _configuration;  

    private readonly IWebHostEnvironment _env;

    private readonly ILogger<GetbyidController> _logger;

    public GetbyidController(
        IConfiguration configuration,
        IWebHostEnvironment env,
        IUserService userService,
        IMapper mapper,
        ILogger<GetbyidController> logger
        )
    {
        _configuration = configuration;  
        _userService = userService;
        _mapper = mapper;
        _logger = logger;
        _env = env;        
    }  

        [HttpGet("/api/getuserbyid/{id}")]
        public IActionResult getByuserid(int id) {
            try {
                var user = _userService.GetById(id);
                var model = _mapper.Map<UserModel>(user);
                return Ok(new {
                    message = "User found, please wait.",
                    user = model
                });

            } catch(AppException ex) {
                return NotFound(new {
                    message = ex.Message
                });

            }
        }
}
    
