using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace email.Test
{
    public class EmailUnitTest
    {
        //[Fact]
        //public void VerificarEmail ()
        //{
        //    string emailCriado = "kaua@email.com";

        //    string email = Email.CriarEmail(emailCriado);

        //    bool verificacao = email.Contains("@");
        //    bool verificacao2 = email.Contains(".");

        //    Assert.True(verificacao && verificacao2);



        //}

        [Fact]
        public void VerificarEmail_Valido()
        {
            // Arrange
            string emailCriado = "kaua@email.com";

            // Act
            bool resultado = Email.ValidarEmail(emailCriado);

            // Assert
            Assert.True(resultado);
        }
    }
}
