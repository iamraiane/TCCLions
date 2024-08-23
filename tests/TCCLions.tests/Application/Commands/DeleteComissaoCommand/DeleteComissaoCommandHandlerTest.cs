using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCLions.API.Application.Commands.ComissaoCommands.DeleteComissaoCommand;
using TCCLions.Domain.Data.Models;
using TCCLions.Domain.Data.Repositories;

namespace TCCLions.tests.Application.Commands.DeleteComissao
{
    public class DeleteComissaoCommandHandlerTest
    {
        [Fact]
        public async Task ShouldDelete_ReturnTrue_When_HandleIsCalled()
        {
            var mockComissaoRepository = new Mock<IComissaoRepository>();
            var comissao = new Comissao(new Guid());
            var request = new DeleteComissaoCommand { Id = new Guid() };

            mockComissaoRepository.Setup(repo => repo.Get(It.IsAny<Guid>())).Returns(comissao);
            mockComissaoRepository.Setup(repo => repo.SaveChangesAsync()).ReturnsAsync(true);

            var handler = new DeleteComissaoCommandHandler(mockComissaoRepository.Object);

            var result = await handler.Handle(request, CancellationToken.None);

            Assert.True(result);
            mockComissaoRepository.Verify(repo => repo.Get(request.Id), Times.Once);
            mockComissaoRepository.Verify(repo => repo.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task ShouldDelete_ReturnThrowException_When_HandleIsCalled()
        {
            var mockComissaoRepository = new Mock<IComissaoRepository>();
            var handler = new DeleteComissaoCommandHandler(mockComissaoRepository.Object);

            await Assert.ThrowsAsync<ArgumentNullException>(() => handler.Handle(null, CancellationToken.None));
        }
    }
}
