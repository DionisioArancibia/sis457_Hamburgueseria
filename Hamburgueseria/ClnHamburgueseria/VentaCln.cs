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
                return venta.IdVenta;
            }
        }

        public static int Actualizar(Venta venta)
        {
            using (var context = new LabHamburgueseriaEntities())
            {
                var existente = context.Venta.Find(venta.IdVenta);
                if (existente != null)
                {
                    existente.IdUsuario = venta.IdUsuario;
                    existente.TipoDocumento = venta.TipoDocumento;
                    existente.DocumentoCliente = venta.DocumentoCliente;
                    existente.NombreCliente = venta.NombreCliente;
                    existente.MontoPago = venta.MontoPago;
                    existente.MontoCambio = venta.MontoCambio;
                    existente.MontoTotal = venta.MontoTotal;
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
                    venta.estado = -1; // Cambia el estado para indicar eliminación lógica
                    return context.SaveChanges();
                }
                return 0; // Manejar caso donde no se encuentra la venta
            }
        }

        public static Venta ObtenerVentaConDetalle(int idVenta)
        {
            using (var context = new LabHamburgueseriaEntities())
            {
                var venta = context.Venta.Include("VentaDetalle") // Carga los detalles relacionados
                                         .FirstOrDefault(v => v.IdVenta == idVenta);

                if (venta != null)
                {
                    // Opcional: Puedes cargar manualmente la lista de detalles
                    venta.VentaDetalle = context.VentaDetalle
                                                .Where(d => d.IdVenta == idVenta)
                                                .ToList();
                }

                return venta;
            }
        }

        public static List<Venta> Listar()
        {
            using (var context = new LabHamburgueseriaEntities())
            {
                return context.Venta.Where(x => x.estado != -1).ToList();
            }
        }

        public static List<paVentaListar_Result> listarPa(string parametro)
        {
            using (var context = new LabHamburgueseriaEntities())
            {
                // Llamamos al procedimiento almacenado que acepta el parámetro
                return context.paVentaListar(parametro).ToList();
            }
        }

        public static List<VentaDetalle> ObtenerDetalleVenta(int idVenta)
        {
            using (var context = new LabHamburgueseriaEntities())
            {
                return context.VentaDetalle
                              .Where(d => d.IdVenta == idVenta)
                              .ToList();
            }
        }
     


    }
}
