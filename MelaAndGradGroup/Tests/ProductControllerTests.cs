using MelaAndGradGroup.onlineShopProgram.controllers;
using MelaAndGradGroup.onlineShopProgram.services;
using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;

public class ProductControllerTests
{
    private readonly Mock<IProductService> _productServiceMock;
    private readonly ProductController _productController;

    public ProductControllerTests()
    {
        _productServiceMock = new Mock<IProductService>();
        _productController = new ProductController(_productServiceMock.Object);
    }

    [Fact]
    public async Task GetAllProducts_ShouldReturnOkWithProducts()
    {
        // Arrange
        var products = new List<Product> { new Product("Test", 10, 1, "Description") };
        _productServiceMock.Setup(s => s.findAll()).ReturnsAsync(products);

        // Act
        var result = await _productController.GetProducts();

        // Assert
        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<List<Product>>(okResult.Value);
        Assert.Equal(products, returnValue);
    }

    [Fact]
    public async Task GetProductById_ShouldReturnOkWithProduct()
    {
        // Arrange
        var product = new Product("Test", 10, 1, "Description");
        _productServiceMock.Setup(s => s.findById(It.IsAny<int>())).ReturnsAsync(product);

        // Act
        var result = await _productController.GetProduct(1);

        // Assert

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<Product>(okResult.Value);
        Assert.Equal(product, returnValue);
    }

    [Fact]
    public async Task GetProductById_ShouldReturnNotFound()
    {
        // Arrange
        _productServiceMock.Setup(s => s.findById(It.IsAny<int>())).ReturnsAsync((Product)null);

        // Act
        var result = await _productController.GetProduct(1);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task AddProduct_ShouldReturnCreatedAtAction()
    {
        // Arrange
        var productDTO = new ProductDTO("Test", 10, 1, "Description");
        _productServiceMock.Setup(s => s.AddProduct(productDTO)).ReturnsAsync(new Product("Test", 10, 1, "Description"));

        // Act
        var result = await _productController.CreateProduct(productDTO);

        // Assert
        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
        Assert.Equal(nameof(_productController.GetProduct), createdAtActionResult.ActionName);
    }
}