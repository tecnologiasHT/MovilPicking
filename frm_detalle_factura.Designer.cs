namespace Picking
{
    partial class frm_detalle_factura
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
            this.dg_factura = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_factura = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_salir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dg_factura
            // 
            this.dg_factura.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dg_factura.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.dg_factura.Location = new System.Drawing.Point(3, 27);
            this.dg_factura.Name = "dg_factura";
            this.dg_factura.Size = new System.Drawing.Size(295, 113);
            this.dg_factura.TabIndex = 0;
            this.dg_factura.TableStyles.Add(this.dataGridTableStyle1);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn1);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn2);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn3);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn4);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn5);
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = global::Picking.Properties.Resources.usuario;
            this.dataGridTextBoxColumn1.FormatInfo = null;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = global::Picking.Properties.Resources.usuario;
            this.dataGridTextBoxColumn2.FormatInfo = null;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = global::Picking.Properties.Resources.usuario;
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.Width = 100;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = global::Picking.Properties.Resources.usuario;
            this.dataGridTextBoxColumn4.FormatInfo = null;
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = global::Picking.Properties.Resources.usuario;
            this.dataGridTextBoxColumn5.FormatInfo = null;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.Text = "Factura #:";
            // 
            // lbl_factura
            // 
            this.lbl_factura.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_factura.ForeColor = System.Drawing.Color.Red;
            this.lbl_factura.Location = new System.Drawing.Point(91, 4);
            this.lbl_factura.Name = "lbl_factura";
            this.lbl_factura.Size = new System.Drawing.Size(153, 20);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Green;
            this.button1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.SystemColors.Window;
            this.button1.Location = new System.Drawing.Point(186, 144);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 24);
            this.button1.TabIndex = 3;
            this.button1.Text = "F1-Actualizar";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_salir
            // 
            this.btn_salir.BackColor = System.Drawing.Color.Red;
            this.btn_salir.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btn_salir.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_salir.Location = new System.Drawing.Point(3, 144);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(112, 24);
            this.btn_salir.TabIndex = 4;
            this.btn_salir.Text = "F-10 Salir";
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // frm_detalle_factura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(301, 172);
            this.Controls.Add(this.btn_salir);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbl_factura);
            this.Controls.Add(this.dg_factura);
            this.Controls.Add(this.label1);
            this.Name = "frm_detalle_factura";
            this.Text = "Detalle Factura";
            this.Load += new System.EventHandler(this.frm_detalle_factura_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGrid dg_factura;
        private System.Windows.Forms.Label label1;
        public  System.Windows.Forms.Label lbl_factura;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_salir;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
    }
}