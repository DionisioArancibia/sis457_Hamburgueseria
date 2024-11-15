using CadHamburgueseria;
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
            dgvVentas.Columns.Add("Codigo", "Código");
            dgvVentas.Columns.Add("Nombre", "Nombre");
            dgvVentas.Columns.Add("Descripcion", "Descripción");
            dgvVentas.Columns.Add("PrecioVenta", "Precio de Venta");
            dgvVentas.Columns.Add("Cantidad", "Cantidad");
            dgvVentas.Columns.Add("Total", "Total");
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

            // Validación del documento del cliente
            if (string.IsNullOrWhiteSpace(txtdocumento.Text))
            {
                esValido = false;
                erpDocumentoCliente.SetError(txtdocumento, "Este campo no debe estar vacío.");
            }

            // Validación de selección de producto
            if (string.IsNullOrWhiteSpace(txtCodigoProducto.Text))
            {
                esValido = false;
                erpCodigoProducto.SetError(txtCodigoProducto, "Este campo no debe estar vacío.");
            }

            // Validación de cantidad de venta
            if (nudCantidadVenta.Value <= 0)
            {
                esValido = false;
                erpCantidadVender.SetError(nudCantidadVenta, "La cantidad debe ser mayor a cero.");
            }

            // Validación de monto de pago
            if (RegistroVenta)
            {
                if (string.IsNullOrWhiteSpace(txtPagaCon.Text) || !decimal.TryParse(txtPagaCon.Text, out decimal pagaCon) || pagaCon <= 0)
                {
                    esValido = false;
                    erpPagaCon.SetError(txtPagaCon, "Ingrese un monto de pago válido.");
                }
                else if (pagaCon < Convert.ToDecimal(txtMontoAPagar.Text))
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

            var codigo = txtCodigoProducto.Text;
            var nombre = txtProducto.Text;
            var descripcion = txtDescripcion.Text;
            var precioVenta = decimal.Parse(txtPrecioVenta.Text);
            var cantidad = int.Parse(nudCantidadVenta.Text);
            var total = precioVenta * cantidad;

            dgvVentas.Rows.Add(codigo, nombre, descripcion, precioVenta, cantidad, total);
            LimpiarCampos();
            CalcularTotalPagar();
        }

        private void LimpiarCampos()
        {
             txtCodigoProducto.Text = string.Empty;
            txtProducto.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtStock.Text = string.Empty;
            txtPrecioVenta.Text = string.Empty;
            nudCantidadVenta.Value = 1;
        }

        private void CalcularTotalPagar()
        {
            decimal totalPagar = 0;

            foreach (DataGridViewRow row in dgvVentas.Rows)
            {
                if (row.Cells["Total"].Value != null)
                {
                    totalPagar += Convert.ToDecimal(row.Cells["Total"].Value);
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
            if (!validar(RegistroVenta: true))
            {
                MessageBox.Show("Por favor, corrige los errores antes de registrar la venta.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtdocumento.Text))
            {
                MessageBox.Show("El documento del cliente no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvVentas.Rows.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un producto a la venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<VentaDetalle> detalles = new List<VentaDetalle>();

            foreach (DataGridViewRow row in dgvVentas.Rows)
            {
                if (row.Cells["Codigo"].Value != null && row.Cells["PrecioVenta"].Value != null && row.Cells["Cantidad"].Value != null)
                {
                    // Get product code and price
                    string codigoProducto = row.Cells["Codigo"].Value.ToString();

                    if (!decimal.TryParse(row.Cells["PrecioVenta"].Value.ToString(), out decimal precioVenta))
                    {
                        MessageBox.Show($"El valor de la columna 'PrecioVenta' en la fila {row.Index + 1} no es un número válido.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        continue;
                    }

                    if (!int.TryParse(row.Cells["Cantidad"].Value.ToString(), out int cantidad))
                    {
                        MessageBox.Show($"El valor de la columna 'Cantidad' en la fila {row.Index + 1} no es un número válido.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        continue;
                    }

                    var detalle = new VentaDetalle
                    {
                        // Assumes you have the product ID available from a previous query
                        // Use the product ID, not the code, to reference the actual product in the database
                        IdProducto = GetProductoIdByCodigo(codigoProducto),
                        PrecioVenta = precioVenta,
                        Cantidad = cantidad,
                        SubTotal = precioVenta * cantidad
                    };
                    detalles.Add(detalle);
                }
            }

            // Create a new Venta (sale) object
            var cliente = new Cliente
            {
                documento = txtdocumento.Text,
                nombreCompleto = txtNombre.Text
            };

            var venta = new Venta
            {
                DocumentoCliente = cliente.documento,
                MontoTotal = Convert.ToDecimal(txtMontoAPagar.Text),
                // Add the sale details to the venta object
                VentaDetalle = detalles
            };

            try
            {
                using (var context = new LabHamburgueseriaEntities())
                {
                    context.Venta.Add(venta);  // Add the sale to the context
                    context.SaveChanges();     // Commit the transaction to the database
                }

                MessageBox.Show("Venta registrada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (DbEntityValidationException ex)
            {
                // Handle validation errors
                string errorMessage = "Error al registrar la venta: ";
                foreach (var validationError in ex.EntityValidationErrors)
                {
                    foreach (var error in validationError.ValidationErrors)
                    {
                        errorMessage += $"{error.PropertyName}: {error.ErrorMessage}\n";
                    }
                }
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado al registrar la venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int GetProductoIdByCodigo(string codigoProducto)
        {
            using (var context = new LabHamburgueseriaEntities())
            {
                var producto = context.Producto.FirstOrDefault(p => p.Codigo == codigoProducto);
                return producto != null ? producto.IdProducto : 0;
            }
        }


    }
}
