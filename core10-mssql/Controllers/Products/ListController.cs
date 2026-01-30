using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using core10_mssql.Helpers;
using core10_mssql.Models;
using core10_mssql.Services;

namespace core10_mssql.Controllers.Products;

[ApiExplorerSettings(GroupName = "List All Products")]
[ApiController]
[Route("[controller]")]
public class ListController : ControllerBase {

        private IProductService _productService;

        private IMapper _mapper;
        private readonly IConfiguration _configuration;  

        private readonly IWebHostEnvironment _env;

        private readonly ILogger<ListController> _logger;

        public ListController(
            IConfiguration configuration,
            IWebHostEnvironment env,
            IProductService productService,
            IMapper mapper,
            ILogger<ListController> logger
            )
        {
            _configuration = configuration;  
            _productService = productService;
            _mapper = mapper;
            _logger = logger;
            _env = env;        
        }  

        [HttpGet("/api/products/list/{page}")]
        public IActionResult ListProducts(int page) {
            try {                
                int totalpage = _productService.TotPage();
                int totrecs = _productService.TotalRecords();
                var products = _productService.ListAll(page);
                if (products == null || !products.Any()) {
                    return NotFound(new { message="No Data found."});
                }
                
                var model = _mapper.Map<IList<ProductModel>>(products);
                return Ok(new {totpage = totalpage, page = page, totalrecords = totrecs, products=model});

            } catch(AppException ex) {
               return BadRequest(new {message = ex.Message});
            }
        }
    }    
