using Microsoft.AspNetCore.Mvc;
using core10_mssql.Services;
using AutoMapper;
using core10_mssql.Helpers;
using Microsoft.AspNetCore.Authorization;
using core10_mssql.Models;

namespace core10_mssql.Controllers.Users;

[ApiExplorerSettings(GroupName = "List All Users")]
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class GetallController : ControllerBase {
       

    private IUserService _userService;

    private IMapper _mapper;
    private readonly IConfiguration _configuration;  

    private readonly IWebHostEnvironment _env;

    private readonly ILogger<GetallController> _logger;
    private IAuthService _authService;

    public GetallController(
        IConfiguration configuration,
        IWebHostEnvironment env,
        IUserService userService,
        IAuthService authService,        
        IMapper mapper,
        ILogger<GetallController> logger
        )
    {
        _configuration = configuration;  
        _userService = userService;
        _mapper = mapper;
        _authService = authService;
        _logger = logger;
        _env = env;        
    }  

        [HttpGet]
        public IActionResult getAllusers() {
            try {                
                var user = _userService.GetAll();
                var model = _mapper.Map<IList<UserModel>>(user);
                var role = _authService.getRolename(model[0].RolesId);
                model[0].Roles = role.Name;
                return Ok(model);
            } catch(AppException ex) {
               return BadRequest(new {Message = ex.Message});
            }
        }
}
    
