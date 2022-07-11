using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesAhorcado
{
    public class Mesa
    {
        readonly List<Usuario>  usuarios = new List<Usuario>();
        readonly List<Usuario> bajaUsuarios = new List<Usuario>();
        public void nuevoUsuario(Usuario u)
        {
            usuarios.Add(u);
        }
        public void eliminarUsuario(int id)
        {
            Usuario u = getUsuario(id);
            if (u != null)
            {
                u.fechaEliminacion = DateTime.Today;
                bajaUsuarios.Add(u);
                usuarios.Remove(u);
            }
        }
        public Usuario getUsuario(int id)
        {
            foreach (Usuario u in usuarios)
            {
                if (u.Id == id)
                {
                    return u;
                }
            }
            throw new ArgumentNullException("no hay usuario con ese ID");
        }
        public int CantUsuarios{get{return usuarios.Count;} }
        public int CantUsuariosHoy { get { return usuarios.Count(u => u.fechaCreacion == DateTime.Today);} }

        public int CantElimHoy { get { return bajaUsuarios.Count(u => u.fechaEliminacion == DateTime.Today); } }

        public int VictoriasUsuario(int id)
        {
            Usuario u = getUsuario(id);
            if (u != null)
            {
                return u.Juegos.Count(j => j.ResultadoFinal == Resultados.Ganaste);
            }
            return -1;
        }

        public int DerrotasUsuario(int id)
        {
            Usuario u = getUsuario(id);
            if (u != null)
            {
                return u.Juegos.Count(j => j.ResultadoFinal == Resultados.Perdiste);
            }
            return -1;
        }
        public int PartidasUsuario(int id)
        {
            Usuario u = getUsuario(id);
            if (u != null)
            {
                return u.Juegos.Count;
            }
            return -1;
        }
    }
}
