using CadHamburgueseria;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnHamburgueseria
{
    public class UsuarioCln
    {
        public static Usuario obtenerUno(int id)
        {
            using (var context = new LabHamburgueseriaEntities())
            {
                return context.Usuario
                    .Include(e => e.Empleado)
                    .Where(e => e.IdUsuario == id)
                    .FirstOrDefault();
            }
        }

        public static Usuario validar(string usuario, string clave)
        {
            using (var context = new LabHamburgueseriaEntities())
            {
                return context.Usuario
                    .Where(x => x.estado == 1 && x.usuario1 == usuario && x.clave == clave)
                    .FirstOrDefault();
            }
        }
    }
}
