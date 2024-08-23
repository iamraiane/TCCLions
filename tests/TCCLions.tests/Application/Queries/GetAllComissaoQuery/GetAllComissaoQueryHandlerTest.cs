using Moq;
using TCCLions.API.Application.Commands.ComissaoCommands.UpdateComissaoCommand;
using TCCLions.API.Application.Models.DTOs;
using TCCLions.API.Application.Queries.ComissaoQueries.GetAllComissaoQuery;
using TCCLions.Domain.Data.Models;
using TCCLions.Domain.Data.Repositories;

namespace TCCLions.tests.Application.Queries.GetAllComissaoQuery;

public class GetAllComissaoQueryHandlerTest
{
    private readonly Mock<IComissaoRepository> _comissaoRepositoryMock;
    private readonly GetAllComissaoQueryHandler _handler;

    public GetAllComissaoQueryHandlerTest()
    {
        _comissaoRepositoryMock = new Mock<IComissaoRepository>();
        _handler = new GetAllComissaoQueryHandler(_comissaoRepositoryMock.Object);
    }

    [Fact]
    public void Should_ThrowArgumentNullException_When_RepositoryIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => new GetAllComissaoQueryHandler(null));
    }

    [Fact]
    public async void Should_ThrowArgumentNullException_When_RequestIsNull()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(null, CancellationToken.None));
    }

    [Fact]
    public async void Should_ReturnAListOfComissaoDTO_When_HandleIsCalled()
    {
        _comissaoRepositoryMock.Setup(x => x.GetAll()).Returns([]);

        var result = await _handler.Handle(new API.Application.Queries.ComissaoQueries.GetAllComissaoQuery.GetAllComissaoQuery(), CancellationToken.None);

        Assert.IsAssignableFrom<IEnumerable<ComissaoDTO>>(result);
    }
}
