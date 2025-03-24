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
    
}