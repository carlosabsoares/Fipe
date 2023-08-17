using Api.Jaar.Application.Commands.AppFipe;
using Api.Jaar.Domain.Responses;
using Api.Jaar.Domain.Servicos;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Api.Jaar.XUnitTest.Application.AppFipe.PostConsultaFipeBrasilApi
{
    public class PostConsultaFipeBrasilApiHandleTest
    {
        private readonly Mock<IServiceBrasilApi> mockService = new();

        [Fact]
        public async Task Verifica_PostCampanhaHandler_Valido()
        {
            PostConsultaFipeBrasilApiCommand command = new PostConsultaFipeBrasilApiCommand()
            {
                AnoModelo = 1986,
                CodigoFipe = 30201
            };

            List<BrasilApiResponse> returns = new List<BrasilApiResponse>();

            BrasilApiResponse brasilApiResponse = new BrasilApiResponse()
            {
                AnoModelo = 1986,
                Marca = "Ford",
                Modelo = "Belina L 1.8/ 1.6",
                Valor = "R$ 3.037,00",
                Combustivel = "Gasolina",
                CodigoFipe = "003020-1",
                DataConsulta = "quinta-feira, 17 de agosto de 2023 15:21",
                MesReferencia = "agosto de 2023 ",
                SiglaCombustivel = "G",
                TipoVeiculo = 1
            };

            returns.Add(brasilApiResponse);

            //mockService.Setup(x=> x.BrasilApiPreco(It.IsAny<int>(), It.IsAny<int>())).Returns(brasilApiResponse);

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