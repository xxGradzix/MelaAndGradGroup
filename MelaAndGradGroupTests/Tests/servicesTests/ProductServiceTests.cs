using MelaAndGradGroup.onlineShopProgram.services;
using MelaAndGradGroup.onlineShopProgram.repositories;
using Moq;
using Xunit;
using System.Threading.Tasks;
using Assert = Xunit.Assert;

public class ProductServiceTests
{
    private readonly Mock<IProductRepository> _repositoryMock;
    private readonly Mock<IProductEventRepository> _eventRepositoryMock;
    private readonly ProductService _productService;

    public ProductServiceTests()
    {
        _repositoryMock = new Mock<IProductRepository>();
        _eventRepositoryMock = new Mock<IProductEventRepository>();
        _productService = new ProductService(_repositoryMock.Object, _eventRepositoryMock.Object);
    }

    [Fact]
    public async Task AddProduct_ShouldCallRepositorySave()
    {
        // Arrange
        var productDTO = new ProductDTO("Test", 10, 1, "Description");

        // Act
        await _productService.AddProduct(productDTO);

        // Assert
        _repositoryMock.Verify(r => r.Save(It.IsAny<Product>()), Times.Once);
    }

    [Fact]
    public async Task FindAll_ShouldCallRepositoryFindAll()
    {
        // Arrange
        var products = new List<Product> { new Product("Test", 10, 1, "Description") };
        _repositoryMock.Setup(r => r.FindAll()).ReturnsAsync(products);

        // Act
        var result = await _productService.FindAll();

        // Assert
        _repositoryMock.Verify(r => r.FindAll(), Times.Once);
        Assert.Equal(products, result);
    }

    [Fact]
    public async Task FindById_ShouldCallRepositoryFindById()
    {
        // Arrange
        var product = new Product("Test", 10, 1, "Description");
        _repositoryMock.Setup(r => r.FindByID(It.IsAny<int>())).ReturnsAsync(product);

        // Act
        var result = await _productService.FindById(1);

        // Assert
        _repositoryMock.Verify(r => r.FindByID(1), Times.Once);
        Assert.Equal(product, result);
    }
}