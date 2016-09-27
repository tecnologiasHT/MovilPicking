namespace Picking
{
    partial class frm_cajas_transito
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_factura = new System.Windows.Forms.Label();
            this.lst_cajas = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_tot_cajas = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_msj = new System.Windows.Forms.Label();
            this.btn_confirmar_envio = new System.Windows.Forms.Button();
            this.btn_salir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.Text = "Factura:";
            // 
            // lbl_factura
            // 
            this.lbl_factura.BackColor = System.Drawing.Color.White;
            this.lbl_factura.Location = new System.Drawing.Point(56, 9);
            this.lbl_factura.Name = "lbl_factura";
            this.lbl_factura.Size = new System.Drawing.Size(98, 20);
            // 
            // lst_cajas
            // 
            this.lst_cajas.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lst_cajas.Location = new System.Drawing.Point(163, 29);
            this.lst_cajas.Name = "lst_cajas";
            this.lst_cajas.Size = new System.Drawing.Size(148, 98);
            this.lst_cajas.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(163, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.Text = "Cajas/Articulos:";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 20);
            this.label3.Text = "Cajas:";
            // 
            // lbl_tot_cajas
            // 
            this.lbl_tot_cajas.BackColor = System.Drawing.Color.White;
            this.lbl_tot_cajas.Location = new System.Drawing.Point(56, 33);
            this.lbl_tot_cajas.Name = "lbl_tot_cajas";
            this.lbl_tot_cajas.Size = new System.Drawing.Size(98, 20);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(3, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 20);
            this.label4.Text = "Mensaje:";
            // 
            // lbl_msj
            // 
            this.lbl_msj.BackColor = System.Drawing.Color.White;
            this.lbl_msj.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_msj.ForeColor = System.Drawing.Color.Red;
            this.lbl_msj.Location = new System.Drawing.Point(3, 73);
            this.lbl_msj.Name = "lbl_msj";
            this.lbl_msj.Size = new System.Drawing.Size(154, 73);
            this.lbl_msj.Text = "--";
            // 
            // btn_confirmar_envio
            // 
            this.btn_confirmar_envio.Enabled = false;
            this.btn_confirmar_envio.Location = new System.Drawing.Point(3, 149);
            this.btn_confirmar_envio.Name = "btn_confirmar_envio";
            this.btn_confirmar_envio.Size = new System.Drawing.Size(154, 32);
            this.btn_confirmar_envio.TabIndex = 15;
            this.btn_confirmar_envio.Text = "F1-Confirmar Envio";
            this.btn_confirmar_envio.Click += new System.EventHandler(this.btn_confirmar_envio_Click);
            // 
            // btn_salir
            // 
            this.btn_salir.Location = new System.Drawing.Point(220, 149);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(91, 32);
            this.btn_salir.TabIndex = 23;
            this.btn_salir.Text = "Salir";
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // frm_cajas_transito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(326, 188);
            this.Controls.Add(this.btn_salir);
            this.Controls.Add(this.btn_confirmar_envio);
            this.Controls.Add(this.lbl_msj);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_tot_cajas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lst_cajas);
            this.Controls.Add(this.lbl_factura);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "frm_cajas_transito";
            this.Text = "Mover Cajas De Picking";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_cajas_transito_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frm_cajas_transito_Closing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_cajas_transito_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lbl_factura;
        public System.Windows.Forms.ListBox lst_cajas;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lbl_tot_cajas;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label lbl_msj;
        public System.Windows.Forms.Button btn_confirmar_envio;
        public System.Windows.Forms.Button btn_salir;

    }
}