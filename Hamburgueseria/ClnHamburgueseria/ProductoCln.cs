using CadHamburgueseria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnHamburgueseria
{
    public class ProductoCln
    {
        public static int insertar(Producto producto)
        {
            using (var context = new HamburgueseriaEntities())
            {
                context.Producto.Add(producto);
                context.SaveChanges();
                return producto.id;
            }
        }

        public static int actualizar(Producto producto)
        {
            using (var context = new HamburgueseriaEntities())
            {
                var existente = context.Producto.Find(producto.id);
                if (existente != null)
                {
                    existente.codigo = producto.codigo;
                    existente.descripcion = producto.descripcion;
                    existente.unidadMedida = producto.unidadMedida;
                    existente.saldo = producto.saldo;
                    existente.precioVenta = producto.precioVenta;
                    existente.usuarioRegistro = producto.usuarioRegistro;
                    return context.SaveChanges();
                }
                return 0;
            }
        }

        public static int eliminar(int id, string usuario)
        {
            using (var context = new HamburgueseriaEntities())
            {
                var producto = context.Producto.Find(id);
                if (producto != null)
                {
                    producto.estado = -1;
                    producto.usuarioRegistro = usuario;
                    return context.SaveChanges();
                }
                return 0;
            }
        }

        public static Producto obtenerUno(int id)
        {
            using (var context = new HamburgueseriaEntities())
            {
                return context.Producto.Find(id);
            }
        }

        public static List<Producto> listar()
        {
            using (var context = new HamburgueseriaEntities())
            {
                return context.Producto.Where(x => x.estado != -1).ToList();
            }
        }

        public static List<paProductoListar_Result> listarPa(string parametro)
        {
            using (var context = new HamburgueseriaEntities())
            {
                return context.paProductoListar(parametro).ToList();
            }
        }
    }
}
