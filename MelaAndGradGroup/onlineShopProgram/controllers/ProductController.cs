using MelaAndGradGroup.onlineShopProgram.services;
using Microsoft.AspNetCore.Mvc;

namespace MelaAndGradGroup.onlineShopProgram.controllers;

[ApiController]
[Route("api/V1/[controller]")]
public class ProductController : ControllerBase
{
    private readonly ProductService productService;

    public ProductController(ProductService productService)
    {
        this.productService = productService;
    }

    
    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        return Ok(productService.findAll());
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        return Ok("product");
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductDTO productDTO)
    {
        return Ok(productService.AddProduct(productDTO));
        //productService.AddProduct(productDTO);
        //return Ok();
    }
}