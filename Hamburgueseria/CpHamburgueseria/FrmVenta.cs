﻿using CadHamburgueseria;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CpHamburgueseria
{
    public partial class FrmVenta : Form
    {
        public FrmVenta()
        {
            InitializeComponent();
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            string documento = txtdocumento.Text;

            if (string.IsNullOrWhiteSpace(documento))
            {
                MessageBox.Show("Por favor, ingrese el cedula de identidad del cliente ", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var context = new LabHamburgueseriaEntities())
            {
                var cliente = context.Cliente.FirstOrDefault(c => c.documento == documento);

                if (cliente != null)
                {
                    txtNombre.Text = cliente.nombreCompleto;
                }
                else
                {
                    MessageBox.Show("El cliente no existe, puede crear un cliente si desea ", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    limpiarDocumento();
                }
            }
        }
        public void SetListaCliente(string documento, string nombreCompleto)
        {
            txtdocumento.Text = documento;
            txtNombre.Text = nombreCompleto;

        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            var frmCliente = new FrmCliente(this);
            frmCliente.ShowDialog();
        }
        private void limpiarDocumento()
        {
            txtdocumento.Text = string.Empty;
        }
        private void FrmVenta_Load(object sender, EventArgs e)
        {
            txtdocumento.KeyPress += Util.onlyNumbers;
            txtPagaCon.TextChanged += txtPagaCon_TextChanged;
            dgvVentas.Columns.Add("IdUsuario", "Id del Usuario");
            dgvVentas.Columns.Add("Codigo", "Código");
            dgvVentas.Columns.Add("Nombre", "Nombre");
            dgvVentas.Columns.Add("TipoDocumento", "Tipo de Documento");
            dgvVentas.Columns.Add("Descripcion", "Descripción");
            dgvVentas.Columns.Add("PrecioVenta", "Precio de Venta");
            dgvVentas.Columns.Add("Cantidad", "Cantidad");
            dgvVentas.Columns.Add("Total", "Total");
            dgvVentas.Columns.Add("UsuarioRegistro", "Usuario de Registro");
            dgvVentas.Columns.Add("FechaRegistro", "Fecha de Registro"); // Nueva columna
            
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            FrmListProductos productoFrm = new FrmListProductos(this);
            productoFrm.ShowDialog(); 
        }
        public void SetListaProducto(string codigo, string nombre, string descripcion, string stock, string precioVenta)
        {
            txtCodigoProducto.Text = codigo;
            txtProducto.Text = nombre;
            txtDescripcion.Text = descripcion;
            txtStock.Text = stock;
            txtPrecioVenta.Text = precioVenta;
            if (int.TryParse(stock, out int stockDisponible))
            {
                nudCantidadVenta.Maximum = stockDisponible;
            }
            else
            {
                nudCantidadVenta.Maximum = 1;
            }
        }

        private bool validar(bool RegistroVenta = false)
        {
            bool esValido = true;

            erpDocumentoCliente.SetError(txtdocumento, "");
            erpCodigoProducto.SetError(txtCodigoProducto, "");
            erpCantidadVender.SetError(nudCantidadVenta, "");
            erpPagaCon.SetError(txtPagaCon, "");

            if (string.IsNullOrWhiteSpace(txtdocumento.Text))
            {
                esValido = false;
                erpDocumentoCliente.SetError(txtdocumento, "Este campo no debe estar vacío.");
            }

            if (!RegistroVenta) // Validación para productos
            {
                if (string.IsNullOrEmpty(txtCodigoProducto.Text))
                {
                    esValido = false;
                    erpCodigoProducto.SetError(txtCodigoProducto, "Este campo no debe estar vacío.");
                }

                if (nudCantidadVenta.Value <= 0)
                {
                    esValido = false;
                    erpCantidadVender.SetError(nudCantidadVenta, "La cantidad no debe ser negativa o cero.");
                }
            }

            if (RegistroVenta)
            {
                if (string.IsNullOrWhiteSpace(txtPagaCon.Text) || !decimal.TryParse(txtPagaCon.Text, out decimal pagaCon) || pagaCon < Convert.ToDecimal(txtMontoAPagar.Text))
                {
                    esValido = false;
                    erpPagaCon.SetError(txtPagaCon, "El monto de pago debe ser suficiente para cubrir el total.");
                }
            }

            return esValido;
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (!validar())
            {
                MessageBox.Show("Por favor, corrija los errores antes de agregar el producto.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCodigoProducto.Text))
            {
                MessageBox.Show("Por favor, selecciona un producto válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Verificar que el producto exista en la base de datos
            string codigo = txtCodigoProducto.Text;
            using (var context = new LabHamburgueseriaEntities())
            {
                var producto = context.Producto.FirstOrDefault(p => p.Codigo == codigo);
                if (producto == null)
                {
                    MessageBox.Show("Producto no encontrado en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var nombre = producto.Nombre;
                var descripcion = producto.Descripcion;
                var precioVenta = producto.PrecioVenta;
                var stock = producto.Stock;

                if (stock <= 0)
                {
                    MessageBox.Show("El producto no tiene stock disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var cantidad = (int)nudCantidadVenta.Value;
                var total = precioVenta * cantidad;

                // Verificar si la cantidad deseada está disponible en stock
                if (cantidad > stock)
                {
                    MessageBox.Show("La cantidad solicitada excede el stock disponible.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener el IdUsuario (relacionado con el idEmpleado del usuario actual)
                int idUsuario = Util.usuario.idEmpleado;

                // Validar que el usuario tenga un IdEmpleado asociado
                if (idUsuario <= 0)
                {
                    MessageBox.Show("No se pudo identificar al empleado asociado al usuario actual.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Agregar el producto al DataGridView
                var usuarioRegistro = Util.usuario.usuario1; // Usuario actual
                var fechaRegistro = DateTime.Now.ToString("dd/MM/yyyy HH:mm"); // Fecha actual

                dgvVentas.Rows.Add(idUsuario, codigo, nombre, cbxTipoDocumento.Text, descripcion, precioVenta, cantidad, total, usuarioRegistro, fechaRegistro);
                LimpiarCampos();
                CalcularTotalPagar();
            }
        }
        private void LimpiarCampos()
        {
            txtCodigoProducto.Clear();
            txtProducto.Clear();
            txtDescripcion.Clear();
            txtStock.Clear();
            txtPrecioVenta.Clear();
            nudCantidadVenta.Value = 1;
        }

        private void CalcularTotalPagar()
        {
            decimal totalPagar = 0;

            foreach (DataGridViewRow row in dgvVentas.Rows)
            {
                if (row.Cells["Total"].Value != null &&
                    decimal.TryParse(row.Cells["Total"].Value.ToString(), out decimal total))
                {
                    totalPagar += total;
                }
            }

            txtMontoAPagar.Text = totalPagar.ToString("0.00");
        }


        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvVentas.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvVentas.SelectedRows)
                {
                    dgvVentas.Rows.RemoveAt(row.Index);
                }
                CalcularTotalPagar();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un producto para quitar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtPagaCon_TextChanged(object sender, EventArgs e)
        {
            decimal montoAPagar;
            decimal pagaCon;

            if (decimal.TryParse(txtMontoAPagar.Text, out montoAPagar) && decimal.TryParse(txtPagaCon.Text, out pagaCon))
            {
                if (pagaCon >= montoAPagar)
                {
                    decimal cambio = pagaCon - montoAPagar;
                    txtCambio.Text = cambio.ToString("0.00");
                }
                else
                {
                    txtCambio.Text = "0.00";
                }
            }
            else
            {
                txtCambio.Text = "0.00";
            }
        }

        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtdocumento.Text) || string.IsNullOrEmpty(txtNombre.Text) ||
                    string.IsNullOrEmpty(cbxTipoDocumento.Text) || string.IsNullOrEmpty(txtPagaCon.Text) ||
                    string.IsNullOrEmpty(txtMontoAPagar.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos requeridos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idEmpleado = Util.usuario.idEmpleado;

                if (idEmpleado <= 0)
                {
                    MessageBox.Show("No se pudo identificar al empleado asociado al usuario actual.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (var context = new LabHamburgueseriaEntities())
                {
                    var venta = new Venta
                    {
                        IdUsuario = idEmpleado,
                        TipoDocumento = cbxTipoDocumento.Text,
                        DocumentoCliente = txtdocumento.Text,
                        NombreCliente = txtNombre.Text,
                        MontoPago = Convert.ToDecimal(txtPagaCon.Text),
                        MontoCambio = Convert.ToDecimal(txtCambio.Text),
                        MontoTotal = Convert.ToDecimal(txtMontoAPagar.Text),
                        UsuarioRegistro = Util.usuario.usuario1,
                        fechaRegistro = DateTime.Now,
                        estado = 1
                    };

                    context.Venta.Add(venta);
                    context.SaveChanges();

                    MessageBox.Show("Venta registrada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormularioVenta();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al registrar la venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LimpiarFormularioVenta()
        {
            txtdocumento.Clear();
            txtNombre.Clear();
            txtCodigoProducto.Clear();
            cbxTipoDocumento.SelectedIndex = -1;
            txtProducto.Clear();
            txtDescripcion.Clear();
            txtStock.Clear();
            txtPrecioVenta.Clear();
            nudCantidadVenta.Value = 1;
            txtMontoAPagar.Clear();
            txtPagaCon.Clear();
            txtCambio.Clear();
            dgvVentas.Rows.Clear();
        }

        private int GetProductoIdByCodigo(string codigoProducto)
        {
            using (var context = new LabHamburgueseriaEntities())
            {
                var producto = context.Producto.FirstOrDefault(p => p.Codigo == codigoProducto);
                return producto != null ? producto.IdProducto : 0;
            }
        }
      

     



        private void btnAñadirProducto_Click(object sender, EventArgs e)
        {
            var frmProducto = new FrmProducto(this);
            frmProducto.ShowDialog(); ;
        }
    }
}
