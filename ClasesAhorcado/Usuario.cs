using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesAhorcado
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public List<Juego> Juegos { get; set; }
        private static int C = 0;
        public DateTime fechaCreacion { get; set; }
        public DateTime fechaEliminacion { get; set; }

        public Usuario()
        {
            Id = genId();
            Juegos = new List<Juego>();
            fechaCreacion = DateTime.Today;
        }

        public Usuario(string n, string p) : base()
        {
            Password = p;
            Name = n;
        }

        private static int genId()
        {
            C += 1;
            return C;
        }

        public void nuevoJuego(string palabra)
        {
            Juego j = new Juego(palabra);
            Juegos.Add(j);

        }

        public Resultados Ingresar(char v)
        {
            Juego j = Juegos.Last();
            return j.verificar(v);
        }
        public string getEstado()
        {
            Juego j = Juegos.Last();
            string est = "";
            for (int i = 0; i < j.estado.Length; i++)
            {
                est += j.estado[i] + " ";
            }
            return est;
        }
        public string getLetras()
        {
            Juego j = Juegos.Last();
            string letras = "";
            for (int i = 0; i < j.letrasUsadas.Length; i++)
            {
                letras += j.letrasUsadas[i] + " - ";
            }
            return letras;
        }
        public int getVidas()
        {
            Juego j = Juegos.Last();
            return j.vidas;
        }
        public static void Reset()
        {
            C = 0;
        }
    }
}
