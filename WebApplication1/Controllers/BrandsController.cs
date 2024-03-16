using Business.Abstracts;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpPost]
        public IActionResult Add(CreateBrandRequest createBrandRequest)
        {
            CreatedBrandResponse createdBrandResponse = _brandService.Add(createBrandRequest);
            return Ok(createdBrandResponse);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_brandService.GetAll());
        }
    }
}
