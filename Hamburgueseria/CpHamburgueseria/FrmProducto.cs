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
        private bool esNuevo = false;
        public FrmProducto(FrmVenta frmVenta)
        {
            InitializeComponent();
        }

        private void listar()
        {
            var lista = ProductoCln.listarPa(txtParametroProducto.Text);
            dgvListaProducto.DataSource = lista;
            dgvListaProducto.Columns["IdProducto"].Visible = false;
            dgvListaProducto.Columns["estado"].Visible = false;
            dgvListaProducto.Columns["Codigo"].HeaderText = "Código";
            dgvListaProducto.Columns["Nombre"].HeaderText = "Nombre";
            dgvListaProducto.Columns["Descripcion"].HeaderText = "Descripción";
            dgvListaProducto.Columns["IdCategoria"].HeaderText = "Categoria";
            dgvListaProducto.Columns["Stock"].HeaderText = "Stock";
            dgvListaProducto.Columns["PrecioCompra"].HeaderText = "Precio de Compra";
            dgvListaProducto.Columns["PrecioVenta"].HeaderText = "Precio de Venta";

            // Habilitar los botones si se encontró al menos un producto
            btnEditar.Enabled = lista.Count > 0;
            btnEliminar.Enabled = lista.Count > 0;

            // Seleccionar la primera celda si hay resultados
            if (lista.Count > 0)
                dgvListaProducto.CurrentCell = dgvListaProducto.Rows[0].Cells["Codigo"];
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            Size =new Size (722, 598);
            listar();
            CargarCategorias();
            
        }
        private void DesactivarCampos()
        {
            txtCodigo.Enabled = false;
            txtNombre.Enabled = false;
            txtDescripcion.Enabled = false;
            txtPrecioVenta.Enabled = false;
            txtPrecioCompra.Enabled = false;
            nudStock.Enabled = false;
            cbxCategoria.Enabled = false;

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            esNuevo = true;
            Size = new Size(991, 598);
            HabilitarCampos();
            txtCodigo.Focus();
            limpiar();

        }

        private void HabilitarCampos()
        {
            txtCodigo.Enabled = true;
            txtNombre.Enabled = true;
            txtDescripcion.Enabled = true;
            cbxCategoria.Enabled = true;
            txtPrecioVenta.Enabled = true;
            txtPrecioCompra.Enabled = true;
            nudStock.Enabled = true;
            

        }
        private void limpiar()
        {
            txtCodigo.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            cbxCategoria.Text = string.Empty;
            txtPrecioVenta.Text = string.Empty;
            txtPrecioCompra.Text = string.Empty;
            nudStock.Text = string.Empty;


        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            esNuevo = false;
            Size = new Size(991, 598);

            int index = dgvListaProducto.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dgvListaProducto.Rows[index].Cells["idProducto"].Value);
            var producto = ProductoCln.obtenerUno(id);

            txtCodigo.Text = producto.Codigo;
            txtNombre.Text = producto.Nombre;
            txtDescripcion.Text = producto.Descripcion;


            cbxCategoria.SelectedValue = producto.IdCategoria; // Usa SelectedValue si IdCategoria es numérico

            txtPrecioVenta.Text = producto.PrecioVenta.ToString();
            txtPrecioCompra.Text = producto.PrecioCompra.ToString();
            nudStock.Value = producto.Stock;  // Asignar el stock

            HabilitarCampos();
            txtCodigo.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Size = new Size(722, 598);
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

        private bool validar()
        {
            bool esValido = true;
            erpCodigo.SetError(txtCodigo, "");
            erpNombre.SetError(txtNombre, "");
            erpDescripcion.SetError(txtDescripcion, "");
            erpCategoria.SetError(cbxCategoria, "");
            erpPrecioVenta.SetError(txtPrecioVenta, "");
            erpPrecioCompra.SetError(txtPrecioCompra, "");

            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                esValido = false;
                erpCodigo.SetError(txtCodigo, "El campo Código es obligatorio");
            }

            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                esValido = false;
                erpNombre.SetError(txtNombre, "El campo Nombre es obligatorio");
            }

            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                esValido = false;
                erpDescripcion.SetError(txtDescripcion, "El campo Descripción es obligatorio");
            }

            if (string.IsNullOrEmpty(cbxCategoria.Text))
            {
                esValido = false;
                erpCategoria.SetError(cbxCategoria, "El campo Categoria es obligatorio");
            }

            // Validación para txtPrecioVenta
            if (!decimal.TryParse(txtPrecioVenta.Text, out decimal precioVenta) || precioVenta < 0)
            {
                esValido = false;
                erpPrecioVenta.SetError(txtPrecioVenta, "El campo Precio de Venta debe ser un número mayor o igual a 0");
            }

            // Validación para txtPrecioCompra
            if (!decimal.TryParse(txtPrecioCompra.Text, out decimal precioCompra) || precioCompra < 0)
            {
                esValido = false;
                erpPrecioCompra.SetError(txtPrecioCompra, "El campo Precio de Compra debe ser un número mayor o igual a 0");
            }

            if (nudStock.Value < 0)
            {
                esValido = false;
                erpStock.SetError(nudStock, "El campo Stock no debe ser negativo");
            }
            return esValido;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
             if (validar())
    {
        try
        {
            var producto = new Producto();
            producto.Codigo = txtCodigo.Text.Trim();
            producto.Nombre = txtNombre.Text.Trim();
            producto.Descripcion = txtDescripcion.Text.Trim();
            producto.IdCategoria = (int)cbxCategoria.SelectedValue;
            producto.PrecioVenta = decimal.Parse(txtPrecioVenta.Text);
            producto.PrecioCompra = decimal.Parse(txtPrecioCompra.Text);
            producto.Stock = nudStock.Value;
            producto.UsuarioRegistro = Util.usuario.usuario1;

            bool guardado = false; // Variable para verificar si se guardaron los datos

            if (esNuevo)
            {
                producto.fechaRegistro = DateTime.Now;
                producto.estado = 1;
                ProductoCln.insertar(producto);
                guardado = true;
            }
            else
            {
                int index = dgvListaProducto.CurrentCell.RowIndex;
                producto.IdProducto = Convert.ToInt32(dgvListaProducto.Rows[index].Cells["IdProducto"].Value);
                ProductoCln.actualizar(producto);
                guardado = true;
            }

            if (guardado)
            {
                listar();
                btnCancelar.PerformClick();
                MessageBox.Show("Producto guardado correctamente", "::: Hamburgueseria - Mensaje :::",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiar(); // Solo limpia si se guardaron los datos correctamente
                DesactivarCampos();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al guardar el producto: {ex.Message}", "::: Hamburgueseria - Error :::",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
        }

       
        private void CargarCategorias()
        {
            var categorias = CategoriaCln.listar();
            cbxCategoria.DataSource = categorias;
            cbxCategoria.DisplayMember = "descripcion";
            cbxCategoria.ValueMember = "IdCategoria";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int index = dgvListaProducto.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dgvListaProducto.Rows[index].Cells["IdProducto"].Value); // Cambia "id" por "idProducto"
            string codigo = dgvListaProducto.Rows[index].Cells["Codigo"].Value.ToString();
            DialogResult dialog =
                MessageBox.Show($"¿Está seguro que desea dar de baja al producto con codigo {codigo}?",
                "::: Hamburgueseria - Mensaje :::", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {
                ProductoCln.eliminar(id, Util.usuario.usuario1);
                listar();
                MessageBox.Show("Producto dado de baja correctamente", "::: Hamburgueseria - Mensaje :::",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
