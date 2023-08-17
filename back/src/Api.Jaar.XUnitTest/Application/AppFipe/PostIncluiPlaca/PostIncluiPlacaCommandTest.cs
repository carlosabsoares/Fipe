using Api.Jaar.Application.Commands.AppFipe;
using System.Collections.Generic;
using Xunit;

namespace Api.Jaar.XUnitTest.Application.AppFipe.PostIncluiPlaca
{
    public class PostIncluiPlacaCommandTest
    {
        [Fact]
        public void Verificar_PostIncluiPlacaCommand_Valido()
        {
            PostIncluiPlacaCommand validateCommand = new PostIncluiPlacaCommand();

            validateCommand.AnoModelo = 1986;
            validateCommand.CodigoFipe = 123215;
            validateCommand.Placa = "ABC123";

            validateCommand.Validate();

            Assert.True(validateCommand.Valid);
            Assert.False(validateCommand.Invalid);

            Assert.True(((List<Flunt.Notifications.Notification>)validateCommand.Notifications).Count == 0);

            Assert.Equal(1986, validateCommand.AnoModelo);
            Assert.Equal(123215, validateCommand.CodigoFipe);
            Assert.Equal("ABC123", validateCommand.Placa);
        }

        [Theory]
        [InlineData(0, 1234, "ABC123")]
        [InlineData(0, 0, "ABC123")]
        [InlineData(1234, 0, "ABC123")]
        [InlineData(1234, 1234, "ABC1231235")]
        [InlineData(1234, 1234, "A")]
        [InlineData(1234, 1234, "")]
        public void Verificar_PostIncluiPlacaCommand_InValido(int param1, int param2, string param3)
        {
            PostIncluiPlacaCommand validateCommand = new PostIncluiPlacaCommand();

            validateCommand.AnoModelo = param1;
            validateCommand.CodigoFipe = param2;

            string parameter3 = string.Empty;

            if (!string.IsNullOrEmpty(param3))
                parameter3 = param3;

            validateCommand.Placa = parameter3;

            validateCommand.Validate();

            Assert.False(validateCommand.Valid);
            Assert.True(validateCommand.Invalid);
            Assert.Equal(param1, validateCommand.AnoModelo);
            Assert.Equal(param2, validateCommand.CodigoFipe);
            Assert.Equal(param3, param3 == null ? null : validateCommand.Placa);

            if (param1 == 0 && param2 > 0 && (parameter3.Length > 2 && parameter3.Length < 9))
            {
                Assert.True(((List<Flunt.Notifications.Notification>)validateCommand.Notifications).Count == 1);

                var _notification = (List<Flunt.Notifications.Notification>)validateCommand.Notifications;
                Assert.Equal("AnoModelo", _notification[0].Property);
                Assert.Equal("Ano deve ser maior que zero", _notification[0].Message);
            }
            else if (param1 == 0 && param2 > 0 && (parameter3.Length > 2 && parameter3.Length < 9))
            {
                Assert.True(((List<Flunt.Notifications.Notification>)validateCommand.Notifications).Count == 1);

                var _notification = (List<Flunt.Notifications.Notification>)validateCommand.Notifications;
                Assert.Equal("CodigoFipe", _notification[0].Property);
                Assert.Equal("Código Fipe deve ser maior que zero", _notification[0].Message);
            }
            else if (param1 == 0 && param2 == 0 && (parameter3.Length > 2 && parameter3.Length < 9))
            {
                Assert.True(((List<Flunt.Notifications.Notification>)validateCommand.Notifications).Count == 2);

                var _notification = (List<Flunt.Notifications.Notification>)validateCommand.Notifications;
                Assert.Equal("AnoModelo", _notification[0].Property);
                Assert.Equal("Ano deve ser maior que zero", _notification[0].Message);
                Assert.Equal("CodigoFipe", _notification[1].Property);
                Assert.Equal("Código Fipe deve ser maior que zero", _notification[1].Message);
            }
            else if (param1 > 0 && param2 > 0 && (parameter3.Length < 2 && parameter3 != ""))
            {
                Assert.True(((List<Flunt.Notifications.Notification>)validateCommand.Notifications).Count == 1);

                var _notification = (List<Flunt.Notifications.Notification>)validateCommand.Notifications;
                Assert.Equal("Placa", _notification[0].Property);
                Assert.Equal("Placa não pode ter menos que 2 dígitos", _notification[0].Message);
            }
            else if (param1 > 0 && param2 > 0 && (parameter3.Length > 8 && parameter3 != ""))
            {
                Assert.True(((List<Flunt.Notifications.Notification>)validateCommand.Notifications).Count == 1);

                var _notification = (List<Flunt.Notifications.Notification>)validateCommand.Notifications;
                Assert.Equal("Placa", _notification[0].Property);
                Assert.Equal("Placa não pode ter mais que 8 dígitos", _notification[0].Message);
            }
            else if (param1 > 0 && param2 > 0 && (parameter3 == ""))
            {
                Assert.True(((List<Flunt.Notifications.Notification>)validateCommand.Notifications).Count == 2);

                var _notification = (List<Flunt.Notifications.Notification>)validateCommand.Notifications;
                Assert.Equal("Placa", _notification[0].Property);
                Assert.Equal("Placa não pode ser nula ou vazia", _notification[0].Message);

                Assert.Equal("Placa", _notification[1].Property);
                Assert.Equal("Placa não pode ter menos que 2 dígitos", _notification[1].Message);
            }
        }
    }
}