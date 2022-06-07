using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesAhorcado
{
    public class Mesa
    {
        List<Usuario> usuarios = new List<Usuario>();
        List<Usuario> bajaUsuarios = new List<Usuario>();
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
            return null;
        }
        public int CantUsuarios{get{return usuarios.Count();} }
        public int CantUsuariosHoy { get { return usuarios.Where(u => u.fechaCreacion == DateTime.Today).Count();} }

        public int CantElimHoy { get { return bajaUsuarios.Where(u => u.fechaEliminacion == DateTime.Today).Count(); } }

        public int VictoriasUsuario(int id)
        {
            Usuario u = getUsuario(id);
            if (u != null)
            {
                return u.Juegos.Where(j => j.ResultadoFinal == Resultados.Ganaste).Count();
            }
            return -1;
        }

        public int DerrotasUsuario(int id)
        {
            Usuario u = getUsuario(id);
            if (u != null)
            {
                return u.Juegos.Where(j => j.ResultadoFinal == Resultados.Perdiste).Count();
            }
            return -1;
        }
    }
}
