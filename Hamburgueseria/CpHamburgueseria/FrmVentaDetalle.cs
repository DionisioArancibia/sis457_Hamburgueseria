using CadHamburgueseria;
using ClnHamburgueseria;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CpHamburgueseria
{
    public partial class FrmVentaDetalle : Form
    {
        private FrmVenta frmVenta; // Hace Referencia a FrmVenta
        public FrmVentaDetalle(FrmVenta frmVenta)

        {
            InitializeComponent();
        }

        private void FrmVentaDetalle_Load(object sender, EventArgs e)
        {
            txtbusqueda.Select();
         
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtbusqueda.Text))
                {
                    MessageBox.Show("Por favor, ingrese un identificador de venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtbusqueda.Text, out int idVenta))
                {
                    MessageBox.Show("El identificador de la venta debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener la venta con sus detalles
                Venta venta = VentaCln.ObtenerVentaConDetalle(idVenta);
              

                if (venta == null)
                {
                    MessageBox.Show("No se encontró una venta con el ID especificado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Mostrar los datos de la venta
                txtfecha.Text = venta.fechaRegistro.ToString("dd/MM/yyyy HH:mm:ss");
                txttipodocumento.Text = venta.TipoDocumento;
                txtusuario.Text = venta.UsuarioRegistro;
                txtdoccliente.Text = venta.DocumentoCliente;
                txtnombrecliente.Text = venta.NombreCliente;

                // Mostrar los totales
                txtmontototal.Text = venta.MontoTotal.ToString("0.00");
                txtmontopago.Text = venta.MontoPago.ToString("0.00");
                txtmontocambio.Text = venta.MontoCambio.ToString("0.00");

               


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al buscar la venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnborrar_Click(object sender, EventArgs e)
        {
            txtbusqueda.Text = "";
            txtfecha.Text = "";
            txttipodocumento.Text = "";
            txtusuario.Text = "";
            txtdoccliente.Text = "";
            txtnombrecliente.Text = "";

  
            txtmontototal.Text = "0.00";
            txtmontopago.Text = "0.00";
            txtmontocambio.Text = "0.00";
        }


    }
}
