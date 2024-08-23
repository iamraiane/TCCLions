using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TCCLions.API.Application.Commands.ComissaoCommands.DeleteComissaoCommand;
using TCCLions.API.Application.Commands.ComissaoCommands.UpdateComissaoCommand;
using TCCLions.API.Application.Models.DTOs;
using TCCLions.API.Application.Models.Requests.Comissao;
using TCCLions.API.Application.Models.Requests.Comissao.Filters;
using TCCLions.API.Application.Queries.ComissaoQueries.GetAllComissaoQuery;
using TCCLions.API.Controllers;
using Xunit;

namespace TCCLions.tests.Controllers;

public class ComissaoControllerTest
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly ComissaoController _controller;

    public ComissaoControllerTest()
    {
        _mediatorMock = new Mock<IMediator>();
        _controller = new ComissaoController(_mediatorMock.Object);
    }

    [Fact]
    public void GetAll_Should_ThrowArgumentNullException_When_MediatorIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => new ComissaoController(null));
    }

    [Fact]
    public async void GetAll_ShouldReturnNoContent_When_MediatorReturnsEmptyArray()
    {
        _mediatorMock.Setup(_ => _.Send(It.IsAny<GetAllComissaoQuery>(), CancellationToken.None)).ReturnsAsync([]);

        var result = await _controller.GetAll(new ComissaoFilterRequest());

        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async void GetAll_ShouldReturnOkWithData_When_MediatorReturnsAnArray()
    {
        _mediatorMock.Setup(_ => _.Send(It.IsAny<GetAllComissaoQuery>(), CancellationToken.None)).ReturnsAsync([new()]);

        var result = await _controller.GetAll(new ComissaoFilterRequest());

        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async void ShouldUpdate_ReturnOk_When_MediatorReturnsTrue()
    {
        _mediatorMock.Setup(_ => _.Send(It.IsAny<UpdateComissaoCommand>(), CancellationToken.None)).ReturnsAsync(true);

        UpdateComissaoRequest updateComissaoRequest = new()
        {
            TipoComissaoId = Guid.NewGuid(),
        };

        var result = await _controller.Update(It.IsAny<Guid>(), updateComissaoRequest);

        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public async void ShouldUpdate_ReturnOk_When_MediatorReturnsFalse()
    {
        _mediatorMock.Setup(_ => _.Send(It.IsAny<UpdateComissaoCommand>(), CancellationToken.None)).ReturnsAsync(false);

        UpdateComissaoRequest updateComissaoRequest = new()
        {
            TipoComissaoId = Guid.NewGuid(),
        };

        var result = await _controller.Update(It.IsAny<Guid>(), updateComissaoRequest);

        Assert.IsType<BadRequestResult>(result);
    }

    [Fact]
    public async void ShouldRemove_ReturnOk_When_MediatorReturnsTrue()
    {
        _mediatorMock.Setup(_ => _.Send(It.IsAny<DeleteComissaoCommand>(), CancellationToken.None)).ReturnsAsync(true);

        var result = await _controller.Delete(It.IsAny<Guid>());

        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public async void ShouldRemove_ReturnOk_When_MediatorReturnsFalse()
    {
        _mediatorMock.Setup(_ => _.Send(It.IsAny<DeleteComissaoCommand>(), CancellationToken.None)).ReturnsAsync(false);

        var result = await _controller.Delete(It.IsAny<Guid>());

        Assert.IsType<BadRequestResult>(result);
    }

    [Fact]
    public async void GetById_ShouldReturnNotFound_When_MediatorReturnsNull()
    {
        _mediatorMock.Setup(_ => _.Send(It.IsAny<GetComissaoQuery>(), CancellationToken.None)).ReturnsAsync(() => null);

        var result = await _controller.Get(It.IsAny<Guid>());

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async void GetById_ShouldReturnOkWithData_When_MediatorReturnsAComissao()
    {
        _mediatorMock.Setup(_ => _.Send(It.IsAny<GetComissaoQuery>(), CancellationToken.None)).ReturnsAsync(new ComissaoDTO { Id = Guid.NewGuid(), TipoComissao = "asd"});

        var result = await _controller.Get(It.IsAny<Guid>());

        Assert.IsType<OkObjectResult>(result);
    }
}
