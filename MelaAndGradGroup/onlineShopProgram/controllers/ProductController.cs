using MelaAndGradGroup.onlineShopProgram.services;
using Microsoft.AspNetCore.Http.HttpResults;
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
        // var products = await productService.findAll();
        return Ok("products");
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        // var product = await productService.findByID(id);
        // if (product == null) return NotFound();
        return Ok("product");
    }
}