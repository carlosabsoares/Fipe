using Api.Jaar.Application.Commands.AppFipe;
using System.Collections.Generic;
using Xunit;

namespace Api.Jaar.XUnitTest.Application.AppFipe.PostConsultaFipeBrasilApi
{
    public class PostConsultaFipeBrasilApiCommandTest
    {
        [Fact]
        public void Verificar_PostConsultaFipeBrasilApiCommand_Valido()
        {
            PostConsultaFipeBrasilApiCommand validateCommand = new PostConsultaFipeBrasilApiCommand();

            validateCommand.AnoModelo = 1986;
            validateCommand.CodigoFipe = 123215;

            validateCommand.Validate();

            Assert.True(validateCommand.Valid);
            Assert.False(validateCommand.Invalid);

            Assert.True(((List<Flunt.Notifications.Notification>)validateCommand.Notifications).Count == 0);

            Assert.Equal(1986, validateCommand.AnoModelo);
            Assert.Equal(123215, validateCommand.CodigoFipe);
        }

        [Theory]
        [InlineData(0, 1234)]
        [InlineData(1234, 0)]
        [InlineData(0, 0)]
        public void Verificar_PostConsultaFipeBrasilApiCommand_InValido(int param1, int param2)
        {
            PostConsultaFipeBrasilApiCommand validateCommand = new PostConsultaFipeBrasilApiCommand();

            validateCommand.AnoModelo = param1;
            validateCommand.CodigoFipe = param2;

            validateCommand.Validate();

            Assert.False(validateCommand.Valid);
            Assert.True(validateCommand.Invalid);
            Assert.Equal(param1, validateCommand.AnoModelo);
            Assert.Equal(param2, validateCommand.CodigoFipe);

            if (param1 == 0 && param2 > 0)
            {
                Assert.True(((List<Flunt.Notifications.Notification>)validateCommand.Notifications).Count == 1);

                var _notification = (List<Flunt.Notifications.Notification>)validateCommand.Notifications;
                Assert.Equal("AnoModelo", _notification[0].Property);
                Assert.Equal("Ano deve ser maior que zero", _notification[0].Message);
            }
            else if (param1 > 0 && param2 == 0)
            {
                Assert.True(((List<Flunt.Notifications.Notification>)validateCommand.Notifications).Count == 1);

                var _notification = (List<Flunt.Notifications.Notification>)validateCommand.Notifications;
                Assert.Equal("CodigoFipe", _notification[0].Property);
                Assert.Equal("Código Fipe deve ser maior que zero", _notification[0].Message);
            }
            else
            {
                Assert.True(((List<Flunt.Notifications.Notification>)validateCommand.Notifications).Count == 2);

                var _notification = (List<Flunt.Notifications.Notification>)validateCommand.Notifications;
                Assert.Equal("AnoModelo", _notification[0].Property);
                Assert.Equal("Ano deve ser maior que zero", _notification[0].Message);

                Assert.Equal("CodigoFipe", _notification[1].Property);
                Assert.Equal("Código Fipe deve ser maior que zero", _notification[1].Message);
            }
        }
    }
}