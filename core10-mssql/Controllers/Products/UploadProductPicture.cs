using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp;
using core10_mssql.Services;
using core10_mssql.Models;

namespace core10_mssql.Controllers.Products;

[ApiExplorerSettings(GroupName = "Upload Product Picture")]
[ApiController]
[Route("[controller]")]
public class UploadProductPicture : ControllerBase {
    private IProductService _productService;
    private IMapper _mapper;
    private readonly IConfiguration _configuration;  
    private readonly IWebHostEnvironment _env;
    private readonly ILogger<UploadProductPicture> _logger;

    public UploadProductPicture(
        IConfiguration configuration,
        IWebHostEnvironment env,
        IProductService productService,
        IMapper mapper,
        ILogger<UploadProductPicture> logger
        )
    {
        _configuration = configuration;  
        _productService = productService;
        _mapper = mapper;
        _logger = logger;
        _env = env;        
    }  

    [HttpPatch("/api/uploadproductpicture/{id}")]
    public IActionResult ProdupdatePicture(UploadProductpicModel model) {
            if (model.ProductPicture.FileName != null)
            {
                try
                {
                    string ext= Path.GetExtension(model.ProductPicture.FileName);
                    var folderName = Path.Combine("wwwroot", "products/");
                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                    var newFilename =pathToSave + "00" + model.Id + ".jpg";

                    using var image = SixLabors.ImageSharp.Image.Load(model.ProductPicture.OpenReadStream());
                    image.Mutate(x => x.Resize(100, 100));
                    image.Save(newFilename);
                    string file = "00"+model.Id.ToString()+".jpg";
                    if (model.ProductPicture != null)
                    {
                        _productService.UpdateProdPicture(model.Id, file);                            
                    }
                    return Ok(new { 
                        message = "Product Picture has been updated.",
                        productpic = file});                        
                }
                catch (Exception ex)
                {
                    return BadRequest(new {message =ex.Message});
                }
            }
            return NotFound(new {message = "Profile Picture not found."});
    }
}    
