using ComBravoControl.BusinessLogic.Interface;
using ComBravoControl.Domains.Models.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ComBravoControl.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductActions _product;

        public ProductController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _product = bl.GetProductActions();
        }

        [HttpGet("getAll")]
        public IActionResult GetAllProducts()
        {
            var product = _product.GetAllProductAction();
            return Ok(product);
        }
        [HttpGet("get Product by ID")]
        public IActionResult GetProductById(int id)
        {
            var product = _product.GetProudctByIdAction(id);
            return Ok(product);
        }
        [HttpPut]
        public IActionResult UpdateProduct([FromBody] ProductDto product)
        {
            var response = _product.ResponseProductUpdateAction(product);
            return Ok(response);
        }
        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductDto product)
        {
            var response = _product.ResponseProductCreateAction(product);
            return Ok(response);
        }
        [HttpDelete]
        public IActionResult DeleteProductById(int id) 
        { 
            var response = _product.ResponseProductDeleteAction(id);
            return Ok(response);
        }
    }
}
