namespace ClasesAhorcado
{
    public class Juego
    {
        public string letrasUsadas = "";
        public string Palabra{get; set;}

        public Juego(string palabra)
        {
            Palabra=palabra;
        }
        
        public bool LeerLetra(char input)
        {
            if (letrasUsadas.Contains(input))
            {
                return false;
            }
            else
            {
                letrasUsadas += input;
                return true;
            }
        }

        public bool verificar(char input)
        {
            if(LeerLetra(input))
            {
                if (Palabra.Contains(input))
                {
                    return true;
                }
            }
            return false;
        }
    }
}