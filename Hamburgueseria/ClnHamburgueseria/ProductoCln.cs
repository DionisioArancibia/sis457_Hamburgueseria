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

            using (var context = new LabHamburgueseriaEntities())
            {
                context.Producto.Add(producto);
                context.SaveChanges();
                return producto.IdProducto;
            }

        }
            public static int actualizar(Producto producto)
        {
            using (var context = new LabHamburgueseriaEntities())
            {
                            
                    var existente = context.Producto.Find(producto.IdProducto);
                    existente.Codigo = producto.Codigo;
                    existente.Nombre = producto.Nombre;
                    existente.Descripcion = producto.Descripcion;
                    existente.IdCategoria = producto.IdCategoria;
                    existente.Stock = producto.Stock;
                    existente.PrecioCompra = producto.PrecioCompra;
                    existente.PrecioVenta = producto.PrecioVenta;
                    return context.SaveChanges();
               
              }
        }


        public static int eliminar(int id, string usuario)
        {
            using (var context = new LabHamburgueseriaEntities())
            {
                var producto = context.Producto.Find(id);
                
                    producto.estado = -1; // Eliminación lógica
                    return context.SaveChanges();
               
               
            }
        }

        public static Producto obtenerUno(int id)
        {
            using (var context = new LabHamburgueseriaEntities())
            {
                return context.Producto.Find(id);
            }
        }

        public static List<Producto> listar()
        {
            using (var context = new LabHamburgueseriaEntities())
            {
                return context.Producto.Where(x => x.estado != -1).ToList();
            }
        }

        public static List<paProductoListar_Result> listarPa(string parametro)
        {
            using (var context = new LabHamburgueseriaEntities())
            {
                // Llamamos al procedimiento almacenado que acepta el parámetro
                return context.paProductoListar(parametro).ToList();
            }
        }

    }
}
