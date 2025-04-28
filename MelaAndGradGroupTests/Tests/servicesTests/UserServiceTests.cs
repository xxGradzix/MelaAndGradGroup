using MelaAndGradGroup.onlineShopProgram.services;
using MelaAndGradGroup.onlineShopProgram.repositories;
using Moq;
using Xunit;
using System.Threading.Tasks;
using Assert = Xunit.Assert;
using MelaAndGradGroup.onlineShopProgram.entities;
using System.Collections.Generic;

public class UserServiceTests
{
    private readonly Mock<IUserRepository> _repositoryMock;
    private readonly UserService _userService;

    public UserServiceTests()
    {
        _repositoryMock = new Mock<IUserRepository>();
        _userService = new UserService(_repositoryMock.Object);
    }

    [Fact]
    public async Task Register_ShouldCallRepositorySave()
    {
        // Arrange
        var userDTO = new UserDTO("testUser", "testPassword");
        var user = new User("testUser", "testPassword");

        _repositoryMock.Setup(r => r.Save(It.IsAny<User>())).ReturnsAsync(user);

        // Act
        var result = await _userService.Register(userDTO);

        // Assert
        _repositoryMock.Verify(r => r.Save(It.IsAny<User>()), Times.Once);
        Assert.Equal(user, result);
    }

    [Fact]
    public async Task FindAll_ShouldCallRepositoryFindAll()
    {
        // Arrange
        var users = new List<User> { new User("testUser", "testPassword") };
        _repositoryMock.Setup(r => r.FindAll()).ReturnsAsync(users);

        // Act
        var result = await _userService.FindAll();

        // Assert
        _repositoryMock.Verify(r => r.FindAll(), Times.Once);
        Assert.Equal(users, result);
    }

    [Fact]
    public async Task Login_ShouldReturnTrue_WhenCredentialsAreCorrect()
    {
        // Arrange
        var username = "testUser";
        var password = "testPassword";
        var user = new User("testUser", "testPassword");

        _repositoryMock.Setup(r => r.FindByUsername(It.IsAny<string>())).ReturnsAsync(user);

        // Act
        var result = await _userService.Login(username, password);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task Login_ShouldReturnFalse_WhenUserNotFound()
    {
        // Arrange
        var username = "testUser";
        var password = "testPassword";

        _repositoryMock.Setup(r => r.FindByUsername(It.IsAny<string>())).ReturnsAsync((User)null);

        // Act
        var result = await _userService.Login(username, password);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public async Task Login_ShouldReturnFalse_WhenPasswordIsIncorrect()
    {
        // Arrange
        var username = "testUser";
        var correctPassword = "correctPassword";
        var wrongPassword = "wrongPassword";
        var user = new User("testUser", correctPassword);

        _repositoryMock.Setup(r => r.FindByUsername(It.IsAny<string>())).ReturnsAsync(user);

        // Act
        var result = await _userService.Login(username, wrongPassword);

        // Assert
        Assert.False(result);
    }
}
