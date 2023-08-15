using Api.Jaar.Application.Commands.AppFipe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Assert.Equal(1986, validateCommand.AnoModelo);
            Assert.Equal(123215, validateCommand.CodigoFipe);
        }

        [Theory]
        [InlineData(0,1234)]
        [InlineData(1234, 0)]
        [InlineData(0,0)]
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
        }

    }
}
