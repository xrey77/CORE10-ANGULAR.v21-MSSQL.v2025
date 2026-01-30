using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using core10_mssql.Services;
using core10_mssql.Entities;
using core10_mssql.Models;
using core10_mssql.Helpers;

namespace core10_mssql.Controllers.Products;

[ApiExplorerSettings(GroupName = "Add Product")]
[Authorize]
[ApiController]
[Route("[controller]")]
public class AddProduct : ControllerBase {
    private IProductService _productService;
    private IMapper _mapper;
    private readonly IConfiguration _configuration;  
    private readonly IWebHostEnvironment _env;
    private readonly ILogger<AddProduct> _logger;

    public AddProduct(
        IConfiguration configuration,
        IWebHostEnvironment env,
        IProductService productService,
        IMapper mapper,
        ILogger<AddProduct> logger
        )
    {
        _configuration = configuration;  
        _productService = productService;
        _mapper = mapper;
        _logger = logger;
        _env = env;        
    }  

    [HttpPost("/api/addproduct")]
    public IActionResult AddProducts(ProductModel model) {
        try {                
            DateTime now = DateTime.Now;
            var prods = _mapper.Map<Product>(model);
            prods.Category = model.Category;
            prods.Descriptions = model.Descriptions;
            prods.Qty = model.Qty;
            prods.Unit = model.Unit;
            prods.CostPrice = model.CostPrice;
            prods.SellPrice = model.SellPrice;
            prods.SalePrice = model.SalePrice;
            prods.AlertStocks = model.AlertStocks;
            prods.CriticalStocks = model.CriticalStocks;
            prods.CreatedAt = now;
            _productService.CreateProduct(prods);                
            return Ok(new { message = "New product has been added to the database."});
        } catch(AppException ex) {
            return BadRequest(new {message = ex.Message});
        }
    }
}    
