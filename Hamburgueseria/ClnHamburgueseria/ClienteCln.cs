using CadHamburgueseria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnHamburgueseria
{
    public class ClienteCln
    {
        public static int insertar(Cliente cliente)
        {
            using (var context = new LabHamburgueseriaEntities())
            {
                context.Cliente.Add(cliente);
                context.SaveChanges();
                return cliente.id;
            }
        }

        public static int actualizar(Cliente cliente)
        {
            using (var context = new LabHamburgueseriaEntities())
            {
                var existente = context.Cliente.Find(cliente.id);
                if (existente != null)
                {
                    existente.documento = cliente.documento;
                    existente.nombreCompleto = cliente.nombreCompleto;
                    existente.correo = cliente.correo;
                    existente.telefono = cliente.telefono; 
                    existente.UsuarioRegistro = cliente.UsuarioRegistro;
                    return context.SaveChanges();
                }
                return 0;
            }
        }

        public static int eliminar(int id, string usuario)
        {
            using (var context = new LabHamburgueseriaEntities())
            {
                var cliente = context.Cliente.Find(id);
                if (cliente != null)
                {
                    cliente.estado = -1;
                    cliente.UsuarioRegistro = usuario;
                    return context.SaveChanges();
                }
                return 0;
            }
        }

        public static Cliente obtenerUno(int id)
        {
            using (var context = new LabHamburgueseriaEntities())
            {
                return context.Cliente.Find(id);
            }
        }

        public static List<Cliente> listar()
        {
            using (var context = new LabHamburgueseriaEntities())
            {
                return context.Cliente.Where(x => x.estado != -1).ToList();
            }
        }

        public static List<paClienteListar_Result> listarPa(string parametro)
        {
            using (var context = new LabHamburgueseriaEntities())
            {
                return context.paClienteListar(parametro).ToList();
            }
        }
    }
}
