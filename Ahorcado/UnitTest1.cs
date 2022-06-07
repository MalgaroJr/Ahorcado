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
        public void TestNoPertenece()
        {
            Juego j = new Juego("psicologo");
            Resultados b = j.verificar('ñ');

            Assert.AreEqual(Resultados.Error, b);
        }
        [Test]
        public void TestPertenece()
        {
            Juego j = new Juego("psicologo");
            Resultados b = j.verificar('p');

            Assert.AreEqual(Resultados.Acierto, b);
        }

        [Test]
        public void TestVidas()
        {
            Juego j = new Juego("psicologo");
            j.verificar('ñ');
            Assert.AreEqual(6, j.vidas);
        }
        [Test]
        public void TestJuegoPerdido()
        {
            Juego j = new Juego("psicologo");
            j.verificar('a');
            j.verificar('e');
            j.verificar('u');
            j.verificar('ñ');
            j.verificar('b');
            j.verificar('r');
            j.verificar('t');
            Assert.AreEqual(Resultados.Perdiste, j.ResultadoFinal);
        }
        [Test]
        public void TestJuegoPerdido2()
        {
            Juego j = new Juego("psicologo");
            j.verificar('a');
            j.verificar('e');
            j.verificar('u');
            j.verificar('ñ');
            j.verificar('b');
            j.verificar('r');
            j.verificar('w');
            j.verificar('t');
            Assert.AreEqual(Resultados.Perdiste, j.ResultadoFinal);
        }

        [Test]
        public void TestdeEstado()
        {
            Juego j = new Juego("skere");
            j.verificar('a');
            j.verificar('s');
            j.verificar('e');
            Assert.AreEqual("s_e_e".ToCharArray(), j.estado);
        }

        [Test]
        public void TestGana()
        {
            Juego j = new Juego("skere");
            j.verificar('a');
            j.verificar('s');
            j.verificar('e');
            j.verificar('r');
            j.verificar('k');
            Assert.AreEqual(Resultados.Ganaste, j.ResultadoFinal);
        }

        [Test]
        public void TestNuevoUsuario()
        {
            Usuario u = new Usuario();
            Assert.AreEqual(1, 1);
        }

        [Test]
        public void TestUsuarioJuego()
        {
            Usuario u = new Usuario();
            u.nuevoJuego("skere");
            Assert.AreEqual(1, u.Juegos.Count);
        }
        [Test]
        public void TestUsuarioGana()
        {
            Usuario u = new Usuario();
            u.nuevoJuego("skere");
            u.Ingresar('k');
            u.Ingresar('s');
            u.Ingresar('e');
            Resultados r=u.Ingresar('r');
            Assert.AreEqual(Resultados.Ganaste, r);
            
        }

        [Test]
        public void TestcantUsuarios()
        {
            Mesa m = new Mesa();
            m.nuevoUsuario(new Usuario());
            m.nuevoUsuario(new Usuario());
            Assert.AreEqual(2, m.CantUsuarios);
        }
        [Test]
        public void TestEliminarUsuarios()
        {
            Mesa m = new Mesa();
            m.nuevoUsuario(new Usuario());
            m.nuevoUsuario(new Usuario());
            m.eliminarUsuario(1);
            Assert.AreEqual(1, m.CantUsuarios);
        }
        [Test]
        public void TestCantUsuariosHoy()
        {
            Mesa m = new Mesa();
            m.nuevoUsuario(new Usuario());
            m.nuevoUsuario(new Usuario());
            Assert.AreEqual(2, m.CantUsuariosHoy);
        }
        [Test]
        public void TestEliminarUsuariosHoy()
        {
            Mesa m = new Mesa();
            m.nuevoUsuario(new Usuario());
            m.nuevoUsuario(new Usuario());
            m.eliminarUsuario(1);
            Assert.AreEqual(1, m.CantElimHoy);
        }
        
        [Test]
        public void TestCantGanadasxUsuario()
        {
            Mesa m = new Mesa();
            Usuario u = new Usuario();
            m.nuevoUsuario(u);
            for (int i = 0; i < 9; i++)
            {
                u.nuevoJuego("skere");
                u.Ingresar('k');
                u.Ingresar('s');
                u.Ingresar('e');
                u.Ingresar('r');
            }
            Assert.AreEqual(9, m.VictoriasUsuario(1));     
        }
        [Test]
        public void TestCantPerdidasxUsuario()
        {
            Mesa m = new Mesa();
            Usuario u = new Usuario();
            m.nuevoUsuario(u);
            for (int i = 0; i < 9; i++)
            {
                u.nuevoJuego("skere");
                u.Ingresar('a');
                u.Ingresar('b');
                u.Ingresar('c');
                u.Ingresar('d');
                u.Ingresar('f');
                u.Ingresar('g');
                u.Ingresar('h');
            }
            Assert.AreEqual(9, m.DerrotasUsuario(1));
        }
        [Test]
        public void PartidasUsuario()
        {
            Mesa m = new Mesa();
            Usuario u = new Usuario();
            m.nuevoUsuario(u);
            for (int i = 0; i < 10; i++)
            {
                u.nuevoJuego("skere");
            }
            Assert.AreEqual(10, m.PartidasUsuario(1));
        }
    }
}