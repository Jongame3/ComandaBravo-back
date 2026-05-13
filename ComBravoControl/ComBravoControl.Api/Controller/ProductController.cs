using ComBravo.BusinessLogic.Interface;
using ComBravo.Domains.Models.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComBravo.Api.Controller
{
    [Route("api/product")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private IProductActions _product;

        public ProductController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _product = bl.GetProductActions();
        }

        [HttpGet("getAll")]
        [AllowAnonymous]
        public IActionResult GetAllProducts()
        {
            var product = _product.GetAllProductAction();
            return Ok(product);
        }
        [HttpGet("get Product by ID")]
        [AllowAnonymous]
        public IActionResult GetProductById(int id)
        {
            var product = _product.GetProudctByIdAction(id);
            return Ok(product);
        }
        [HttpPut]
        [Authorize(Roles = "Vet")]
        public IActionResult UpdateProduct([FromBody] ProductDto product)
        {
            var response = _product.ResponseProductUpdateAction(product);
            return Ok(response);
        }
        [HttpPost]
        [Authorize(Roles = "Vet")]
        public IActionResult CreateProduct([FromBody] ProductDto product)
        {
            var response = _product.ResponseProductCreateAction(product);
            return Ok(response);
        }
        [HttpDelete]
        [Authorize(Roles = "Vet")]
        public IActionResult DeleteProductById(int id) 
        { 
            var response = _product.ResponseProductDeleteAction(id);
            return Ok(response);
        }
    }
}
