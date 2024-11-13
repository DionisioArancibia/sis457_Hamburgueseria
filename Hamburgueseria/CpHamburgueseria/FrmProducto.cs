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
    public partial class FrmProducto : Form
    {
        public FrmProducto()
        {
            InitializeComponent();
        }

        private void Listar()
        {
            var lista = ProductoCln.listarPa(txtParametroProducto.Text);
            dgvListaProducto.DataSource = lista;
            dgvListaProducto.Columns["idProducto"].Visible = false;
            dgvListaProducto.Columns["estado"].Visible = false ;
            dgvListaProducto.Columns["codigo"].HeaderText = "Código";
            dgvListaProducto.Columns["Nombre"].HeaderText = "Nombre";
            dgvListaProducto.Columns["Descripcion"].HeaderText = "Descripción";
            dgvListaProducto.Columns["IdCategoria"].HeaderText = "Categoria";
            dgvListaProducto.Columns["Stock"].HeaderText = "Stock";
            dgvListaProducto.Columns["PrecioCompra"].HeaderText = "Precio de Compra";
            dgvListaProducto.Columns["PrecioVenta"].HeaderText = "Precio de Venta";
            btnEditar.Enabled = lista.Count > 0;
            btnEliminar.Enabled = lista.Count > 0;
            if (lista.Count > 0) dgvListaProducto.CurrentCell = dgvListaProducto.Rows[0].Cells["codigo"];
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            Size = new Size(901, 717);
            Listar();
        }
    }
}
