using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using core10_mssql.Entities;
using core10_mssql.Services;
using core10_mssql.Models.dto;
using core10_mssql.Helpers;

namespace core10_mssql.Controllers.Users;

[ApiExplorerSettings(GroupName = "Forgot User Password")]
[ApiController]
[Route("[controller]")]
public class ForgotPwdController : ControllerBase {

    private IMapper _mapper;
    private IUserService _userService;
    private EmailService _emailService;    
    private readonly IConfiguration _configuration;  
    private readonly IWebHostEnvironment _env;
    private readonly ILogger<ForgotPwdController> _logger;

    public ForgotPwdController(
        IConfiguration configuration,
        IWebHostEnvironment env,
        IMapper mapper,
        IUserService userService,
        EmailService emailService,
        ILogger<ForgotPwdController> logger
        )
    {
        _configuration = configuration;  
        _logger = logger;
        _mapper = mapper;
        _userService = userService;
        _emailService = emailService;
        _env = env;        
    }  

        //Forgot Password
        [HttpPut("/api/resetpassword/{email}")]
        public IActionResult ResetPassword(string email, [FromBody]ForgotPassword model)
        {
           model.Email = email;
           var user = _mapper.Map<User>(model);
            try
            {
                _userService.ChangePassword(user);
                return Ok(new {statuscode = 200, message = "Password successfully changed.." });
            }
            catch (AppException ex)
            {
                return BadRequest(new { statuscode = 400, message = ex.Message });
            }
        }

        [HttpPost("/api/emailtoken")]
        public IActionResult EmailToken([FromBody]MailTokenModel model)
        {
           try {
             int etoken = _userService.SendEmailToken(model.Email);             
             _emailService.sendMailToken(model.Email,"Mail Token","Please copy or enter this token in forgot password option. " + etoken.ToString());
            return Ok(new { etoken = etoken});
           }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }
}    
