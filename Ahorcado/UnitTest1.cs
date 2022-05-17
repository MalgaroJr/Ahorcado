using NUnit.Framework;
using ClasesAhorcado;

namespace Ahorcado
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void TestNoRepite()
        {
            Juego j = new Juego("");
            j.LeerLetra('p');
            bool resultado = j.LeerLetra('p');
            Assert.AreEqual(false, resultado);
        }

        [Test]
        public void TestPertenece()
        {
            Juego j = new Juego("psicologo");
            bool b=j.verificar('ñ');

            Assert.AreEqual(false, b);
        }
    }
}