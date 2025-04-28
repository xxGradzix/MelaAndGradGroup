using MelaAndGradGroup.onlineShopProgram.services;
using Microsoft.AspNetCore.Mvc;

namespace MelaAndGradGroup.onlineShopProgram.controllers;

[ApiController]
[Route("api/V1/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService productService;

    public ProductController(IProductService productService)
    {
        this.productService = productService;
    }

    
    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        return Ok(await productService.FindAll());
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        var product = await productService.FindById(id);
        if (product == null)
        {
            return NoContent();
        }
        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductDTO productDTO)
    {
        Product product = await productService.AddProduct(productDTO);
        return CreatedAtAction(nameof(GetProductById), new { id = product.id }, product);
    }

    [HttpGet("test")]
    public async Task<IActionResult> GetProductByRequestParam([FromQuery(Name = "id")] int id)
    {
        var product = await productService.FindById(id);
        if (product == null)
        {
            return NoContent();
        }
        return Ok(product);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveProduct(int id)
    {
        var result = await productService.DeleteProductById(id);
        if (!result)
        {
            return NotFound("Product with ID " + id + " not found.");
        }
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> ModifyProduct(int id, [FromBody] ProductDTO productDTO)
    {
        try
        {
            Product product = await productService.UpdateProductById(id, productDTO);
            return Ok(product);
        }
        catch (KeyNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    //[HttpPost("sell")]
    //public async Task<IActionResult> SellProduct([FromBody] dynamic request)
    //{
    //    try
    //    {
    //        var productId = Convert.ToInt32(request.id);
    //        var quantity = Convert.ToInt32(request.quantity);

    //        var updatedProduct = await productService.SellProduct(productId, quantity);

    //        return Ok(updatedProduct);
    //    }
    //    catch (Exception ex)
    //    {
    //        return BadRequest(ex.Message);
    //    }
    //}

    //get all products
    //get all products by name
    //get all products by id
    //get all products by price
    //get all products by quantity


}