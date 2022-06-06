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
            foreach(Usuario u in usuarios)
            {
                if(u.Id==id)
                {
                    u.fechaEliminacion = DateTime.Today;
                    bajaUsuarios.Add(u);
                    usuarios.Remove(u);
                    break;
                }
            }

        }
        public int CantUsuarios{get{return usuarios.Count();} }
        public int CantUsuariosHoy { get { return usuarios.Where(u => u.fechaCreacion == DateTime.Today).Count();} }

        public double CantElimHoy { get { return bajaUsuarios.Where(u => u.fechaEliminacion == DateTime.Today).Count(); } }
    }
}
