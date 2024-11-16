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
    public partial class FrmListProductos : Form
    {
        private FrmVenta frmVenta;
        public FrmListProductos(FrmVenta venta)
        {
            InitializeComponent();
            frmVenta = venta;
        }

        public void listar()
        {
            var lista = ProductoCln.listarPa(txtParametroProducto.Text);
            dgvLista.DataSource = lista;
            dgvLista.Columns["IdProducto"].Visible = false;
            if (lista.Count > 0) dgvLista.CurrentCell = dgvLista.Rows[0].Cells["codigo"];
        }

        private void FrmListarProducto_Load(object sender, EventArgs e)
        {
            listar();
        }

        private void dgvLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string codigo = dgvLista.Rows[e.RowIndex].Cells["codigo"].Value.ToString();
                string nombre = dgvLista.Rows[e.RowIndex].Cells["nombre"].Value.ToString();
                string descripcion = dgvLista.Rows[e.RowIndex].Cells["descripcion"].Value.ToString();
                string stock = dgvLista.Rows[e.RowIndex].Cells["stock"].Value.ToString();
                string precioVenta = dgvLista.Rows[e.RowIndex].Cells["precioVenta"].Value.ToString();
                

                frmVenta.SetListaProducto(codigo, nombre, descripcion, stock, precioVenta);
                this.Close();
            }
        }

        private void FrmListProductos_Load(object sender, EventArgs e)
        {
            listar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {


            listar();
        }

            private void txtParametroProducto_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar == (char)Keys.Enter) listar();
            }
        }
    }

