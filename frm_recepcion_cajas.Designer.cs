namespace Picking
{
    partial class frm_recepcion_cajas
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
            this.txt_caja = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dbg_facturas = new System.Windows.Forms.DataGrid();
            this.lbl_tot_rec = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_tot_cajas = new System.Windows.Forms.Label();
            this.lbl_factura = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer();
            this.lbl_msj = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_id_zona = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_caja
            // 
            this.txt_caja.Location = new System.Drawing.Point(3, 50);
            this.txt_caja.Name = "txt_caja";
            this.txt_caja.Size = new System.Drawing.Size(203, 27);
            this.txt_caja.TabIndex = 0;
            this.txt_caja.GotFocus += new System.EventHandler(this.txt_caja_GotFocus);
            this.txt_caja.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_caja_KeyDown);
            this.txt_caja.LostFocus += new System.EventHandler(this.txt_caja_LostFocus);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(1, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.Text = "Leer Caja:";
            // 
            // btn_cerrar
            // 
            this.btn_cerrar.Location = new System.Drawing.Point(223, 163);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(87, 28);
            this.btn_cerrar.TabIndex = 2;
            this.btn_cerrar.Text = "F3-Salir";
            this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(223, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.Text = "Factura:";
            // 
            // dbg_facturas
            // 
            this.dbg_facturas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dbg_facturas.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular);
            this.dbg_facturas.Location = new System.Drawing.Point(1, 83);
            this.dbg_facturas.Name = "dbg_facturas";
            this.dbg_facturas.Size = new System.Drawing.Size(309, 74);
            this.dbg_facturas.TabIndex = 5;
            // 
            // lbl_tot_rec
            // 
            this.lbl_tot_rec.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_tot_rec.Location = new System.Drawing.Point(94, 26);
            this.lbl_tot_rec.Name = "lbl_tot_rec";
            this.lbl_tot_rec.Size = new System.Drawing.Size(25, 20);
            this.lbl_tot_rec.Text = "0";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.label5.Location = new System.Drawing.Point(119, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 20);
            this.label5.Text = "de";
            // 
            // lbl_tot_cajas
            // 
            this.lbl_tot_cajas.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_tot_cajas.Location = new System.Drawing.Point(154, 27);
            this.lbl_tot_cajas.Name = "lbl_tot_cajas";
            this.lbl_tot_cajas.Size = new System.Drawing.Size(25, 20);
            this.lbl_tot_cajas.Text = "0";
            // 
            // lbl_factura
            // 
            this.lbl_factura.ForeColor = System.Drawing.Color.Red;
            this.lbl_factura.Location = new System.Drawing.Point(217, 26);
            this.lbl_factura.Name = "lbl_factura";
            this.lbl_factura.Size = new System.Drawing.Size(93, 20);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbl_msj
            // 
            this.lbl_msj.ForeColor = System.Drawing.Color.Red;
            this.lbl_msj.Location = new System.Drawing.Point(3, 163);
            this.lbl_msj.Name = "lbl_msj";
            this.lbl_msj.Size = new System.Drawing.Size(217, 31);
            this.lbl_msj.Text = "----------------";
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(3, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 20);
            this.label3.Text = "Recibir Cajas en Zona:";
            // 
            // lbl_id_zona
            // 
            this.lbl_id_zona.BackColor = System.Drawing.Color.Yellow;
            this.lbl_id_zona.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_id_zona.ForeColor = System.Drawing.Color.Red;
            this.lbl_id_zona.Location = new System.Drawing.Point(181, 3);
            this.lbl_id_zona.Name = "lbl_id_zona";
            this.lbl_id_zona.Size = new System.Drawing.Size(34, 28);
            this.lbl_id_zona.Text = "0";
            this.lbl_id_zona.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frm_recepcion_cajas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(313, 194);
            this.Controls.Add(this.lbl_id_zona);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_msj);
            this.Controls.Add(this.lbl_factura);
            this.Controls.Add(this.lbl_tot_cajas);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbl_tot_rec);
            this.Controls.Add(this.dbg_facturas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_cerrar);
            this.Controls.Add(this.txt_caja);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "frm_recepcion_cajas";
            this.Text = "Recepcion de Cajas";
            this.Load += new System.EventHandler(this.frm_recepcion_cajas_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frm_recepcion_cajas_Closing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_recepcion_cajas_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        public  System.Windows.Forms.TextBox txt_caja;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGrid dbg_facturas;
       public System.Windows.Forms.Label lbl_tot_rec;
        private System.Windows.Forms.Label label5;
       public System.Windows.Forms.Label lbl_tot_cajas;
        public System.Windows.Forms.Label lbl_factura;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbl_msj;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lbl_id_zona;

    }
}