using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.UnitOfWork.WebAPI.DTO;
using OnlineStore.UnitOfWork.WebAPI.Interfaces;
using OnlineStore.UnitOfWork.WebAPI.Models;
using System.Net;

namespace OnlineStore.UnitOfWork.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase, IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Dispose()
        {
            if (_unitOfWork != null)
            {
                GC.SuppressFinalize(this);
                _unitOfWork.Dispose();
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductDto))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<IActionResult> GetAll()
        {
            var products = await _unitOfWork.ProductRepository.GetAllAsync();
            if (products == null)
            {
                return Problem("No Product found");
            }

            //var productDto = products.Select(x => new ProductDto
            //{
            //    Product_Name = x.ProductName,
            //    CategoryName = x.Category.CategoryName,
            //    SellingPrice = x.SellingPrice,
            //    ListPrice = x.ListPrice,
            //    Discount = x.Discount,
            //}).ToList();

            var productDto = _mapper.Map<List<ProductDto>>(products);

            return Ok(productDto);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
            {
                return ValidationProblem("Id cannot be zero or less");
            }
            var product = await _unitOfWork.ProductRepository.GetAsync(id);
            if (product == null)
            {
                return NotFound($"No Product found for the id : {id}");
            }

            //ProductDto productDto = new();
            //productDto.Product_Name = product.ProductName;
            //productDto.ListPrice = product.ListPrice;
            //productDto.Discount = product.Discount;
            //productDto.SellingPrice = product.SellingPrice;
            //productDto.CategoryName = product.Category.CategoryName;

            var productDto = _mapper.Map<ProductDto>(product);

            return Ok(productDto);
        }

        [HttpGet("/ProductByCategory/{id}")]
        public async Task<IActionResult> GetProductByCategory(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetProductsByCategory(id);
            if (product.Any())
            {
                return Ok(product);
            }
            return NotFound();
        }

        [HttpGet("CategoryList")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Category))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _unitOfWork.ProductRepository.GetCategories();
            if (categories.Any())
            {
                return Ok(categories);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(AddOrUpdateProductDto productDto)
        {
            if (productDto == null)
            {
                return BadRequest(productDto);
            }
            if (!ModelState.IsValid)
            {
                return ValidationProblem("Please enter the valid product details");
            }
            //Product product = new()
            //{
            //    ProductName = productDto.Product_Name,
            //    ListPrice = productDto.ListPrice,
            //    SellingPrice = productDto.SellingPrice,
            //    Discount = productDto.Discount,
            //    CategoryId = productDto.CategoryId,
            //};
            var product = _mapper.Map<Product>(productDto);
            await _unitOfWork.ProductRepository.AddNewAsync(product);
            await _unitOfWork.SaveAsync();

            return CreatedAtAction("GetById", new { product.Id }, product);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(Product))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Product))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        public async Task<IActionResult> UpdateProduct(AddOrUpdateProductDto productDto)
        {
            if (productDto == null)
            {
                return BadRequest(productDto);
            }
            if (!ModelState.IsValid)
            {
                return ValidationProblem("Please enter the valid product details");
            }
            var product = _mapper.Map<Product>(productDto);
            var result = await _unitOfWork.ProductRepository.UpdateAsync(product);
            if (result)
            {
                await _unitOfWork.SaveAsync();
                return NoContent();
            }
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (id <= 0)
            {
                return ValidationProblem("Id cannot be zero or less");
            }

            var result = await _unitOfWork.ProductRepository.DeleteAsync(id);
            if (result)
            {
                await _unitOfWork.SaveAsync();
                return Ok();
            }
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }
}
