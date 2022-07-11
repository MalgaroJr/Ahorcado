namespace ClasesAhorcado
{
    public class Juego
    {
        private string letrasUsadas = "";
        public string LetrasUsadas { get; set; }
        public string Palabra{get; set;}
        public int vidas { get; set;}
        private Resultados resultadoFinal;
        public Resultados ResultadoFinal { 
            get
            {
                if(resultadoFinal==Resultados.Ganaste)
                {
                    return resultadoFinal;
                }
                if (vidas==0)
                {
                    resultadoFinal=Resultados.Perdiste;
                    return resultadoFinal;
                }
                return Resultados.Acierto;
            } 
            set
            {
                resultadoFinal=value;
            }}
        public char[] estado { get; set; }

        public Juego(string palabra)
        {
            Palabra=palabra.ToLower();
            vidas = 7;
            estado=palabra.ToCharArray();
            for(int i=0; i < estado.Length; i++)
            {
                estado[i] = '_';
            }
        }
        
        public bool LeerLetra(char input)
        {
            input = char.ToLower(input);
            if (LetrasUsadas.Contains(input))
            {
                return false;
            }
            else
            {
                LetrasUsadas += input;
                return true;
            }
        }
        public bool verificarVidas()
        {
            if(vidas == 0)
            {
                return false;
            }
            return true;
        }
        public Resultados verificar(char input)
        {
            input = char.ToLower(input);            

            if (verificarVidas())
            {
                if (LeerLetra(input) && Palabra.Contains(input))
                {
                    fillEstado(input);
                    string a = new string(estado);
                    if (Palabra.Equals(a))
                    {
                        resultadoFinal = Resultados.Ganaste;
                        return Resultados.Ganaste;
                    }
                    return Resultados.Acierto; 
                }
                vidas -= 1;
                return Resultados.Error;
            }
            resultadoFinal = Resultados.Perdiste;
            return resultadoFinal;
        }

        private void fillEstado(char input)
        {
            for (int i = 0; i < estado.Length; i++)
            {
                if(Palabra[i] == input) 
                {
                    estado[i] = input;
                }
            }
        }
    }
    public enum Resultados
    {
        Acierto,
        Error,
        Perdiste,
        Ganaste,
    }
}