using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using core10_mssql.Services;
using core10_mssql.Helpers;
using core10_mssql.Models;

namespace core10_mssql.Controllers.Products;

[ApiExplorerSettings(GroupName = "Search Product Description")]
[ApiController]
[Route("[controller]")]
public class SearchController : ControllerBase {

        private IProductService _productService;

        private IMapper _mapper;
        private readonly IConfiguration _configuration;  

        private readonly IWebHostEnvironment _env;

        private readonly ILogger<SearchController> _logger;

        public SearchController(
            IConfiguration configuration,
            IWebHostEnvironment env,
            IProductService productService,
            IMapper mapper,
            ILogger<SearchController> logger
            )
        {
            _configuration = configuration;  
            _productService = productService;
            _mapper = mapper;
            _logger = logger;
            _env = env;        
        }  

        [HttpGet("/api/products/search/{page}/{key}")]
        public IActionResult SearchProducts(int page, string key)
        {
        try {                
                int totalpage = _productService.TotPageSearch(page, key);
                var products = _productService.SearchAll(page, key);
                if (products == null || !products.Any()) {
                    return NotFound(new { message="No Data found."});
                }

                var model = _mapper.Map<IList<ProductModel>>(products);
                return Ok(new {totpage = totalpage, page = page,  products=model});
            
        } catch(AppException ex) {
            return BadRequest(new {modelessage = ex.Message});
        }        
    }
}    
