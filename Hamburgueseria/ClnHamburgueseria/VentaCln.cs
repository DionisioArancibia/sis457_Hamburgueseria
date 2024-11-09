using CadHamburgueseria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnHamburgueseria
{
    public class VentaCln
    {
        public static int Insertar(Venta venta)
        {
            using (var context = new LabHamburgueseriaEntities())
            {
                context.Venta.Add(venta);
                context.SaveChanges();
                return venta.id;
            }
        }

        public static int Actualizar(Venta venta)
        {
            using (var context = new LabHamburgueseriaEntities())
            {
                var existente = context.Venta.Find(venta.id);
                if (existente != null)
                {
                    existente.idCliente = venta.idCliente;
                    existente.idUsuario = venta.idUsuario;
                    existente.fechaVenta = venta.fechaVenta;
                    existente.total = venta.total;
                    existente.metodoPago = venta.metodoPago; // Actualizar método de pago si es necesario
                    existente.estado = venta.estado; // Actualizar estado si es necesario
                    existente.usuarioRegistro = venta.usuarioRegistro;
                    return context.SaveChanges();
                }
                return 0; // Manejar caso donde no se encuentra la venta
            }
        }

        public static int Eliminar(int id, string usuario)
        {
            using (var context = new LabHamburgueseriaEntities())
            {
                var venta = context.Venta.Find(id);
                if (venta != null)
                {
                    venta.estado = -1; // Marcar como eliminado
                    venta.usuarioRegistro = usuario;
                    return context.SaveChanges();
                }
                return 0; // Manejar caso donde no se encuentra la venta
            }
        }

        public static Venta ObtenerUno(int id)
        {
            using (var context = new LabHamburgueseriaEntities())
            {
                return context.Venta.Find(id);
            }
        }

        public static List<Venta> Listar()
        {
            using (var context = new LabHamburgueseriaEntities())
            {
                return context.Venta.Where(x => x.estado != -1).ToList();
            }
        }
    }
}
