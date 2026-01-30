using Microsoft.AspNetCore.Mvc;
using core10_mssql.Models;
using AutoMapper;
using core10_mssql.Services;
using Microsoft.AspNetCore.Authorization;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp;

namespace core10_mssql.Controllers.Users;

[ApiExplorerSettings(GroupName = "Upload User Image")]
[Authorize]
[ApiController]
[Route("[controller]")]
[System.Runtime.Versioning.SupportedOSPlatform("windows")]
public class UploadpictureController : ControllerBase {

    private IUserService _userService;

    private IMapper _mapper;
    private readonly IConfiguration _configuration;  

    private readonly IWebHostEnvironment _env;

    private readonly ILogger<UploadpictureController> _logger;

    public UploadpictureController(
        IConfiguration configuration,
        IWebHostEnvironment env,
        IUserService userService,
        IMapper mapper,
        ILogger<UploadpictureController> logger
        )
    {
        _configuration = configuration;  
        _userService = userService;
        _mapper = mapper;
        _logger = logger;
        _env = env;        
    }  
        [HttpPatch("/api/uploadpicture/{id}")]
        public IActionResult uploadPicture(int id, [FromForm]UploadfileModel model) {
                if (model.Profilepic.FileName != null)
                {
                    try
                    {
                        string ext= Path.GetExtension(model.Profilepic.FileName);

                        var folderName = Path.Combine("wwwroot", "users/");
                        var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                        var newFilename =pathToSave + "00" + id.ToString() + "." + ext;

                        using var image = SixLabors.ImageSharp.Image.Load(model.Profilepic.OpenReadStream());
                        image.Mutate(x => x.Resize(100, 100));
                        image.Save(newFilename);
                        string file = null;
                        if (model.Profilepic != null)
                        {
                            file = "00"+id.ToString()+"." + ext;
                            _userService.UpdatePicture(id, file);                            
                        }
                        return Ok(new { profilepic = file, message = "Profile Picture has been updated."});
                        
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(new { message =ex.Message});
                    }

                }
                return NotFound(new { message = "Profile Picture not found."});

        }
}
    
