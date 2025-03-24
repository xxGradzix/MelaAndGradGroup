using MelaAndGradGroup.onlineShopProgram.services;
using MelaAndGradGroup.onlineShopProgram.repositories;
using Moq;
using Xunit;
using System.Threading.Tasks;

public class ProductServiceTests
{
    private readonly Mock<IProductRepository> _repositoryMock;
    private readonly ProductService _productService;

    public ProductServiceTests()
    {
        _repositoryMock = new Mock<IProductRepository>();
        _productService = new ProductService(_repositoryMock.Object);
    }

    [Fact]
    public async Task AddProduct_ShouldCallRepositorySave()
    {
        // Arrange
        var productDTO = new ProductDTO("Test", 10, 1, "Description");

        // Act
        await _productService.AddProduct(productDTO);

        // Assert
        _repositoryMock.Verify(r => r.save(It.IsAny<Product>()), Times.Once);
    }

    [Fact]
    public async Task FindAll_ShouldCallRepositoryFindAll()
    {
        // Arrange
        var products = new List<Product> { new Product("Test", 10, 1, "Description") };
        _repositoryMock.Setup(r => r.findAll()).ReturnsAsync(products);

        // Act
        var result = await _productService.findAll();

        // Assert
        _repositoryMock.Verify(r => r.findAll(), Times.Once);
        Assert.Equal(products, result);
    }

    [Fact]
    public async Task FindById_ShouldCallRepositoryFindById()
    {
        // Arrange
        var product = new Product("Test", 10, 1, "Description");
        _repositoryMock.Setup(r => r.findByID(It.IsAny<int>())).ReturnsAsync(product);

        // Act
        var result = await _productService.findById(1);

        // Assert
        _repositoryMock.Verify(r => r.findByID(1), Times.Once);
        Assert.Equal(product, result);
    }
}