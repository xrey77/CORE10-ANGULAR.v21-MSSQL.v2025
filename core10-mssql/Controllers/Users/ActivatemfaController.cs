using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Google.Authenticator;
using Microsoft.AspNetCore.Authorization;
using core10_mssql.Models;
using core10_mssql.Services;

namespace core10_mssql.Controllers.Users;

[ApiExplorerSettings(GroupName = "Enable or Disable 2-Factor Authentication")]
[Authorize]
[ApiController]
[Route("[controller]")]
public class ActivatemfaController : ControllerBase {

    private IUserService _userService;

    private IMapper _mapper;
    private readonly IConfiguration _configuration;  

    private readonly IWebHostEnvironment _env;

    private readonly ILogger<ActivatemfaController> _logger;

    public ActivatemfaController(
        IConfiguration configuration,
        IWebHostEnvironment env,
        IUserService userService,
        IMapper mapper,
        ILogger<ActivatemfaController> logger
        )
    {
        _configuration = configuration;  
        _userService = userService;
        _mapper = mapper;
        _logger = logger;
        _env = env;        
    }  

        [HttpPatch("/api/mfa/activate/{id}")]
        public IActionResult EnableMFA(int id,MfaModel model) {
            if (model.TwoFactorEnabled == true) {
                var user = _userService.GetById(id);
                if(user != null) {
                    // QRCode qrimageurl = new();
                    var fullname = "Apple Inc.";
                    TwoFactorAuthenticator twoFactor = new();
                    var setupInfo = twoFactor.GenerateSetupCode(fullname, user.Email, user.Secretkey, false, 3);
                    var imageUrl = setupInfo.QrCodeSetupImageUrl;
                    _userService.ActivateMfa(id, true, imageUrl);
                    return Ok(new {
                        qrcodeurl = imageUrl,
                        message="Multi-Factor Authenticator has been enabled."});
                } else {
                    return NotFound(new {message="User not found."});
                }

            } else {
                _userService.ActivateMfa(id, false, null);
                return Ok(new {message="Multi-Factor Authenticator has been disabled."});
            }
        }
}    
