using Api.Jaar.Domain.Servicos;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Api.Jaar.XUnitTest.Application.AppFipe.PostConsultaFipeBrasilApi
{
    public class PostConsultaFipeBrasilApiHandleTest
    {
        private readonly Mock<IServiceBrasilApi> mockService = new();

        [Fact]
        public async Task Verifica_PostCampanhaHandler_Command_Invalido()
        {
            //PostConsultaFipeBrasilApiCommand command = new PostConsultaFipeBrasilApiCommand()
            //{
            //    AnoModelo = 1986,
            //    CodigoFipe = 30201
            //};

            //BrasilApiResponse brasilApiResponse = new BrasilApiResponse()
            //{
            //    AnoModelo = 1986,
            //    Marca = "Ford",
            //    Modelo = "Belina L 1.8/ 1.6",
            //    Valor = "R$ 3.037,00",
            //    Combustivel = "0",
            //    CodigoFipe = "0"

            //}

            //mockService.Setup(x=> x.BrasilApiPreco()).Returns(command);

            //var handlerDemo = new PostConsultaFipeBrasilApiHandle(mockService.Object);
            //var result = await handlerDemo.Handle(command, new CancellationToken(true));

            //Assert.False(result.Success);
            //var _notification = (List<Flunt.Notifications.Notification>)result.Data;

            //Assert.True(_notification.Count == 1);
            //Assert.Equal("Nome não pode ser nulo.", _notification[0].Message);
            //Assert.Equal("Nome", _notification[0].Property);

            //mockCalculos.Verify(x => x.HorasTrabalhadas(It.IsAny<int>(), It.IsAny<int>()), Times.Never);
            //mockRepository.Verify(x => x.AddAsync<Campanha>(It.IsAny<Campanha>()), Times.Never);
        }
    }
}