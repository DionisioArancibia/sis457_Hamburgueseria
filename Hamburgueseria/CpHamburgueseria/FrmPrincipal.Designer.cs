﻿namespace CpHamburgueseria
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.c1Ribbon1 = new C1.Win.Ribbon.C1Ribbon();
            this.ribbonApplicationMenu1 = new C1.Win.Ribbon.RibbonApplicationMenu();
            this.ribbonBottomToolBar1 = new C1.Win.Ribbon.RibbonBottomToolBar();
            this.ribbonConfigToolBar1 = new C1.Win.Ribbon.RibbonConfigToolBar();
            this.ribbonQat1 = new C1.Win.Ribbon.RibbonQat();
            this.rbnCategoria = new C1.Win.Ribbon.RibbonTab();
            this.descripcion = new C1.Win.Ribbon.RibbonGroup();
            this.btnCaCategoria = new C1.Win.Ribbon.RibbonButton();
            this.btnCaProductos = new C1.Win.Ribbon.RibbonButton();
            this.btnCaCliente = new C1.Win.Ribbon.RibbonButton();
            this.rbnVentas = new C1.Win.Ribbon.RibbonTab();
            this.descricion = new C1.Win.Ribbon.RibbonGroup();
            this.btnVeVenta = new C1.Win.Ribbon.RibbonButton();
            this.btnDeVentaDetalle = new C1.Win.Ribbon.RibbonButton();
            this.ribbonTopToolBar1 = new C1.Win.Ribbon.RibbonTopToolBar();
            ((System.ComponentModel.ISupportInitialize)(this.c1Ribbon1)).BeginInit();
            this.SuspendLayout();
            // 
            // c1Ribbon1
            // 
            this.c1Ribbon1.ApplicationMenuHolder = this.ribbonApplicationMenu1;
            this.c1Ribbon1.AutoSizeElement = C1.Framework.AutoSizeElement.Width;
            this.c1Ribbon1.BottomToolBarHolder = this.ribbonBottomToolBar1;
            this.c1Ribbon1.ConfigToolBarHolder = this.ribbonConfigToolBar1;
            this.c1Ribbon1.Location = new System.Drawing.Point(0, 0);
            this.c1Ribbon1.Margin = new System.Windows.Forms.Padding(4);
            this.c1Ribbon1.Name = "c1Ribbon1";
            this.c1Ribbon1.QatHolder = this.ribbonQat1;
            this.c1Ribbon1.Size = new System.Drawing.Size(1067, 201);
            this.c1Ribbon1.Tabs.Add(this.rbnCategoria);
            this.c1Ribbon1.Tabs.Add(this.rbnVentas);
            this.c1Ribbon1.TopToolBarHolder = this.ribbonTopToolBar1;
            // 
            // ribbonApplicationMenu1
            // 
            this.ribbonApplicationMenu1.Name = "ribbonApplicationMenu1";
            // 
            // ribbonBottomToolBar1
            // 
            this.ribbonBottomToolBar1.Name = "ribbonBottomToolBar1";
            // 
            // ribbonConfigToolBar1
            // 
            this.ribbonConfigToolBar1.Name = "ribbonConfigToolBar1";
            // 
            // ribbonQat1
            // 
            this.ribbonQat1.Name = "ribbonQat1";
            // 
            // rbnCategoria
            // 
            this.rbnCategoria.Groups.Add(this.descripcion);
            this.rbnCategoria.Name = "rbnCategoria";
            this.rbnCategoria.Text = "Categorias";
            // 
            // descripcion
            // 
            this.descripcion.Items.Add(this.btnCaCategoria);
            this.descripcion.Items.Add(this.btnCaProductos);
            this.descripcion.Items.Add(this.btnCaCliente);
            this.descripcion.Name = "descripcion";
            this.descripcion.Text = "descripcion Categoria";
            // 
            // btnCaCategoria
            // 
            this.btnCaCategoria.IconSet.Add(new C1.Framework.C1BitmapIcon("DefaultImage", new System.Drawing.Size(16, 16), System.Drawing.Color.Transparent, "DefaultImage", -1));
            this.btnCaCategoria.IconSet.Add(new C1.Framework.C1BitmapIcon(null, new System.Drawing.Size(32, 32), System.Drawing.Color.Transparent, ((System.Drawing.Image)(resources.GetObject("btnCaCategoria.IconSet")))));
            this.btnCaCategoria.Name = "btnCaCategoria";
            this.btnCaCategoria.Text = "Categoria";
            this.btnCaCategoria.Click += new System.EventHandler(this.btnCaCategoria_Click);
            // 
            // btnCaProductos
            // 
            this.btnCaProductos.IconSet.Add(new C1.Framework.C1BitmapIcon("DefaultImage", new System.Drawing.Size(16, 16), System.Drawing.Color.Transparent, "DefaultImage", -1));
            this.btnCaProductos.IconSet.Add(new C1.Framework.C1BitmapIcon("Paste", new System.Drawing.Size(32, 32), System.Drawing.Color.Transparent, "Preset_LargeImages", 200));
            this.btnCaProductos.Name = "btnCaProductos";
            this.btnCaProductos.Text = "Productos";
            this.btnCaProductos.Click += new System.EventHandler(this.btnCaProductos_Click);
            // 
            // btnCaCliente
            // 
            this.btnCaCliente.IconSet.Add(new C1.Framework.C1BitmapIcon("DefaultImage", new System.Drawing.Size(16, 16), System.Drawing.Color.Transparent, "DefaultImage", -1));
            this.btnCaCliente.IconSet.Add(new C1.Framework.C1BitmapIcon(null, new System.Drawing.Size(32, 32), System.Drawing.Color.Transparent, ((System.Drawing.Image)(resources.GetObject("btnCaCliente.IconSet")))));
            this.btnCaCliente.Name = "btnCaCliente";
            this.btnCaCliente.Text = "Clientes";
            this.btnCaCliente.Click += new System.EventHandler(this.btnCaCliente_Click);
            // 
            // rbnVentas
            // 
            this.rbnVentas.Groups.Add(this.descricion);
            this.rbnVentas.Name = "rbnVentas";
            this.rbnVentas.Text = "Ventas";
            // 
            // descricion
            // 
            this.descricion.Items.Add(this.btnVeVenta);
            this.descricion.Items.Add(this.btnDeVentaDetalle);
            this.descricion.Name = "descricion";
            this.descricion.Text = "Descripcion venta";
            // 
            // btnVeVenta
            // 
            this.btnVeVenta.IconSet.Add(new C1.Framework.C1BitmapIcon("DefaultImage", new System.Drawing.Size(16, 16), System.Drawing.Color.Transparent, "DefaultImage", -1));
            this.btnVeVenta.IconSet.Add(new C1.Framework.C1BitmapIcon("TrackChanges", new System.Drawing.Size(32, 32), System.Drawing.Color.Transparent, "Preset_LargeImages", 323));
            this.btnVeVenta.Name = "btnVeVenta";
            this.btnVeVenta.Text = "Ventas";
            this.btnVeVenta.Click += new System.EventHandler(this.btnVeVenta_Click);
            // 
            // btnDeVentaDetalle
            // 
            this.btnDeVentaDetalle.IconSet.Add(new C1.Framework.C1BitmapIcon("DefaultImage", new System.Drawing.Size(16, 16), System.Drawing.Color.Transparent, "DefaultImage", -1));
            this.btnDeVentaDetalle.IconSet.Add(new C1.Framework.C1BitmapIcon("Report", new System.Drawing.Size(32, 32), System.Drawing.Color.Transparent, "Preset_LargeImages", 235));
            this.btnDeVentaDetalle.Name = "btnDeVentaDetalle";
            this.btnDeVentaDetalle.Text = "Venta Detalle";
            this.btnDeVentaDetalle.Click += new System.EventHandler(this.btnDeVentaDetalle_Click);
            // 
            // ribbonTopToolBar1
            // 
            this.ribbonTopToolBar1.Name = "ribbonTopToolBar1";
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.c1Ribbon1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmPrincipal";
            this.Text = "::: Hamburgueseria - Principal:::";
            ((System.ComponentModel.ISupportInitialize)(this.c1Ribbon1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.Ribbon.C1Ribbon c1Ribbon1;
        private C1.Win.Ribbon.RibbonApplicationMenu ribbonApplicationMenu1;
        private C1.Win.Ribbon.RibbonBottomToolBar ribbonBottomToolBar1;
        private C1.Win.Ribbon.RibbonConfigToolBar ribbonConfigToolBar1;
        private C1.Win.Ribbon.RibbonQat ribbonQat1;
        private C1.Win.Ribbon.RibbonTopToolBar ribbonTopToolBar1;
        private C1.Win.Ribbon.RibbonTab rbnVentas;
        private C1.Win.Ribbon.RibbonGroup descricion;
        private C1.Win.Ribbon.RibbonButton btnVeVenta;
        private C1.Win.Ribbon.RibbonTab rbnCategoria;
        private C1.Win.Ribbon.RibbonGroup descripcion;
        private C1.Win.Ribbon.RibbonButton btnCaCategoria;
        private C1.Win.Ribbon.RibbonButton btnCaProductos;
        private C1.Win.Ribbon.RibbonButton btnCaCliente;
        private C1.Win.Ribbon.RibbonButton btnDeVentaDetalle;
    }
}