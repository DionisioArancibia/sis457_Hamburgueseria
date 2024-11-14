using CadHamburgueseria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnHamburgueseria
{
    public class CategoriaCln
    {
        public static int insertar(Categoria categoria)
        {
            using (var context = new LabHamburgueseriaEntities())
            {
                context.Categoria.Add(categoria);
                context.SaveChanges();
                return categoria.IdCategoria;
            }
        }

        public static int actualizar(Categoria categoria)
        {
            using (var context = new LabHamburgueseriaEntities())
            {
                var existente = context.Categoria.Find(categoria.IdCategoria);
                existente.descripcion = categoria.descripcion;
                existente.UsuarioRegistro = categoria.UsuarioRegistro;
                return context.SaveChanges();
            }
        }

        public static int eliminar(int id, string usuario)
        {
            using (var context = new LabHamburgueseriaEntities())
            {
                var categoria = context.Categoria.Find(id);
                categoria.estado = -1;
                categoria.UsuarioRegistro = usuario;
                return context.SaveChanges();
            }
        }

        public static Categoria obtenerUno(int id)
        {
            using (var context = new LabHamburgueseriaEntities())
            {
                return context.Categoria.Find(id);
            }
        }

        public static List<Categoria> listar()
        {
            using (var context = new LabHamburgueseriaEntities())
            {
                return context.Categoria.Where(x => x.estado != -1).ToList();
            }
        }

        public static List<paCategoriaListar_Result> listarPa(string parametro)
        {
            using (var context = new LabHamburgueseriaEntities())
            {
                return context.paCategoriaListar(parametro).ToList();
            }
        }

        public static bool ExisteDescripcion(string descripcion)
        {
            using (var context = new LabHamburgueseriaEntities())
            {
                return context.Categoria.Any(c => c.descripcion.Equals(descripcion, StringComparison.OrdinalIgnoreCase) && c.estado != -1);
            }
        }
    }
}
