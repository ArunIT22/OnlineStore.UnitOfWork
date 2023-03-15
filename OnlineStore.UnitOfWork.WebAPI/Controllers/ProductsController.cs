using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<IActionResult> GetAll()
        {
            var products = await _unitOfWork.ProductRepository.GetAllAsync();
            if (products == null)
            {
                return Problem("No Product found");
            }
            return Ok(products);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Product))]
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
            return Ok(product);
        }

        [HttpGet("/ProductByCategory/{id}")]
        public async Task<IActionResult> GetProductByCategory(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetProductsByCategory(id);
            if (product.Any())
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            if (product == null)
            {
                return BadRequest(product);
            }
            if (!ModelState.IsValid)
            {
                return ValidationProblem("Please enter the valid product details");
            }

            await _unitOfWork.ProductRepository.AddNewAsync(product);
            await _unitOfWork.SaveAsync();

            return CreatedAtAction("GetById", new { product.Id }, product);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(Product))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Product))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            if (product == null)
            {
                return BadRequest(product);
            }
            if (!ModelState.IsValid)
            {
                return ValidationProblem("Please enter the valid product details");
            }
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
