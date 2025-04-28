using MelaAndGradGroup.onlineShopProgram.controllers;
using MelaAndGradGroup.onlineShopProgram.services;
using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Assert = Xunit.Assert;
using MelaAndGradGroup.onlineShopProgram.entities;
using System.Collections.Generic;

public class UserControllerTests
{
    private readonly Mock<IUserService> _userServiceMock;
    private readonly UserController _userController;

    public UserControllerTests()
    {
        _userServiceMock = new Mock<IUserService>();
        _userController = new UserController(_userServiceMock.Object);
    }

    [Fact]
    public async Task GetAllUsers_ShouldReturnOkWithUsers()
    {
        // Arrange
        var users = new List<User> { new User("testuser", "password") };
        _userServiceMock.Setup(s => s.FindAll()).ReturnsAsync(users);

        // Act
        var result = await _userController.GetAllUsers();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnValue = Assert.IsType<List<User>>(okResult.Value);
        Assert.Equal(users, returnValue);
    }

    [Fact]
    public async Task Register_ShouldReturnCreatedAtAction()
    {
        // Arrange
        var userDTO = new UserDTO("testuser", "password");
        var createdUser = new User("testuser", "password") { id = 1 };
        _userServiceMock.Setup(s => s.Register(userDTO)).ReturnsAsync(createdUser);

        // Act
        var result = await _userController.Register(userDTO);

        // Assert
        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
        Assert.Equal(nameof(_userController.Register), createdAtActionResult.ActionName);
        Assert.Equal(1, ((User)createdAtActionResult.Value).id);
    }

    [Fact]
    public async Task Login_ShouldReturnOk_WhenAuthenticated()
    {
        // Arrange
        var userDTO = new UserDTO("testuser", "password");
        _userServiceMock.Setup(s => s.Login(userDTO.username, userDTO.password)).ReturnsAsync(true);

        // Act
        var result = await _userController.Login(userDTO);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal("Login successful.", okResult.Value);
    }

    [Fact]
    public async Task Login_ShouldReturnUnauthorized_WhenInvalidCredentials()
    {
        // Arrange
        var userDTO = new UserDTO("testuser", "wrongpassword");
        _userServiceMock.Setup(s => s.Login(userDTO.username, userDTO.password)).ReturnsAsync(false);

        // Act
        var result = await _userController.Login(userDTO);

        // Assert
        var unauthorizedResult = Assert.IsType<UnauthorizedObjectResult>(result);
        Assert.Equal("Invalid username or password.", unauthorizedResult.Value);
    }
}
