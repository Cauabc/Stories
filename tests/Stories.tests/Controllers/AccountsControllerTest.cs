﻿using Microsoft.AspNetCore.Mvc;
using Moq;
using Stories.API.Controllers;
using Stories.Services.DTOs;
using Stories.Services.Services.Account;

namespace Stories.tests.Controllers;

public class AccountsControllerTest
{
    private readonly Mock<IAccountService> _service;
    private readonly AccountsController _controller;
    public AccountsControllerTest()
    {
        _service = new Mock<IAccountService>();
        _controller = new AccountsController(_service.Object);
    }

    [Fact]
    public void GetAll_HasData_ReturnsOkObject()
    {
        _service.Setup(s => s.GetAll()).Returns(new List<AccountDTO>() { new() });

        var result = _controller.Get();

        _service.Verify(s => s.GetAll(), Times.Once());

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public void GetAll_HasNoData_ReturnsNoContent()
    {
        _service.Setup(s => s.GetAll()).Returns(new List<AccountDTO>());

        var result = _controller.Get();

        _service.Verify(s => s.GetAll(), Times.Once());

        Assert.IsType<NoContentResult>(result);
    }
}