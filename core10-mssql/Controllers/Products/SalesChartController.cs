using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using core10_mssql.Services;
using core10_mssql.Helpers;
using QuestPDF.Fluent;

namespace core10_mssql.Controllers.Products;

[ApiController]
[Route("[controller]")]
public class SalesChartController : ControllerBase {

        private IProductService _productService;
        private IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<ListController> _logger;

        public SalesChartController(
            IWebHostEnvironment env,
            IProductService productService,
            IMapper mapper,
            ILogger<ListController> logger
            )
        {
            _productService = productService;
            _mapper = mapper;
            _logger = logger;
            _env = env;        
        }  

        [HttpGet("/sales/chart")]
        public async Task<IActionResult> SalesChartReport() 
        {
            var sales = await _productService.SalesDataAsync();
            var model = new SalesReportModel { SalesData = sales.ToList() };            
            var document = new SalesChartDocument(_env, model);
            
            byte[] pdfBytes = document.GeneratePdf();
            
            // string fileName = $"SalesChartReport_{DateTime.Now.Ticks}.pdf";
            // return File(pdfBytes, "application/pdf", fileName);                 
            var reportId = DateTime.Now.Ticks; 
            return File(pdfBytes, "application/pdf", $"SalesChartReport_{reportId}.pdf");            
        }
}