using Moq;
using TCCLions.API.Application.Commands.ComissaoCommands.UpdateComissaoCommand;
using TCCLions.API.Application.Models.DTOs;
using TCCLions.API.Application.Queries.ComissaoQueries.GetAllComissaoQuery;
using TCCLions.API.Application.Queries.ComissaoQueries.GetComissaoQuery;
using TCCLions.Domain.Data.Models;
using TCCLions.Domain.Data.Repositories;

namespace TCCLions.tests.Application.Queries.GetComissaoQuery;

public class GetComissaoQueryHandlerTest
{
    private readonly Mock<IComissaoRepository> _comissaoRepositoryMock;
    private readonly GetComissaoQueryHandler _handler;

    public GetComissaoQueryHandlerTest()
    {
        _comissaoRepositoryMock = new Mock<IComissaoRepository>();
        _handler = new GetComissaoQueryHandler(_comissaoRepositoryMock.Object);
    }

    [Fact]
    public void Should_ThrowArgumentNullException_When_RepositoryIsNull()
    {
        Assert.Throws<ArgumentNullException>(() => new GetComissaoQueryHandler(null));
    }

    [Fact]
    public async void Should_ThrowArgumentNullException_When_RequestIsNull()
    {
        await Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(null, CancellationToken.None));
    }

    [Fact]
    public async void Should_ReturnAComissaoDTO_When_HandleIsCalled()
    {
        _comissaoRepositoryMock.Setup(x => x.Get(It.IsAny<Guid>())).Returns(new Comissao(Guid.NewGuid()));

        var result = await _handler.Handle(new API.Application.Queries.ComissaoQueries.GetAllComissaoQuery.GetComissaoQuery(), CancellationToken.None);

        Assert.IsAssignableFrom<ComissaoDTO>(result);
    }
}
