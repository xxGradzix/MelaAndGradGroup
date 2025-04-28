using MelaAndGradGroup.onlineShopProgram.controllers;
using MelaAndGradGroup.onlineShopProgram.services;
using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Assert = Xunit.Assert;
using MelaAndGradGroup.onlineShopProgram.entities;

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
        _productServiceMock.Setup(s => s.FindAll()).ReturnsAsync(products);

        // Act
        var result = await _productController.GetAllProducts();

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
        _productServiceMock.Setup(s => s.FindById(It.IsAny<int>())).ReturnsAsync(product);

        // Act
        var result = await _productController.GetProductById(1);

        // Assert

        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<Product>(okResult.Value);
        Assert.Equal(product, returnValue);
    }

    [Fact]
    public async Task GetProductById_ShouldReturnNotFound()
    {
        // Arrange
        _productServiceMock.Setup(s => s.FindById(It.IsAny<int>())).ReturnsAsync((Product)null);

        // Act
        var result = await _productController.GetProductById(1);

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
        Assert.Equal(nameof(_productController.GetProductById), createdAtActionResult.ActionName);
    }

    [Fact]
    public async Task SellProduct_ShouldReturnOkWithUpdatedProduct()
    {
        // Arrange
        var productId = 1;
        var quantity = 2;
        var product = new Product("Test", 10, 10, "Description") { id = productId };
        var updatedProduct = new Product("Test", 10, 8, "Description") { id = productId };

        // Setup mock for SellProduct
        _productServiceMock.Setup(s => s.SellProduct(productId, quantity)).ReturnsAsync(updatedProduct);

        var request = new SellProductRequest { id = productId, quantity = quantity };

        // Act
        var result = await _productController.SellProduct(request);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<Product>(okResult.Value);
        Assert.Equal(updatedProduct.id, returnValue.id);
        Assert.Equal(updatedProduct.quantity, returnValue.quantity);
    }
}