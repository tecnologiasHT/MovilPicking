namespace Picking
{
    partial class frm_cajas_picking
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
            this.label2 = new System.Windows.Forms.Label();
            this.txt_caja = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.dg_cajas = new System.Windows.Forms.DataGrid();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_tot_cajas = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 15);
            this.label1.Text = "Factura #";
            // 
            // lbl_factura
            // 
            this.lbl_factura.ForeColor = System.Drawing.Color.Red;
            this.lbl_factura.Location = new System.Drawing.Point(70, 1);
            this.lbl_factura.Name = "lbl_factura";
            this.lbl_factura.Size = new System.Drawing.Size(107, 20);
            this.lbl_factura.Text = "-----------------";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 17);
            this.label2.Text = "Caja #";
            // 
            // txt_caja
            // 
            this.txt_caja.Location = new System.Drawing.Point(52, 20);
            this.txt_caja.Name = "txt_caja";
            this.txt_caja.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txt_caja.Size = new System.Drawing.Size(111, 27);
            this.txt_caja.TabIndex = 0;
            this.txt_caja.GotFocus += new System.EventHandler(this.txt_caja_GotFocus);
            this.txt_caja.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_caja_KeyDown);
            this.txt_caja.LostFocus += new System.EventHandler(this.txt_caja_LostFocus);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(213, 154);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 27);
            this.button1.TabIndex = 7;
            this.button1.Text = "F10-Salir";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.BackColor = System.Drawing.Color.DarkGreen;
            this.btn_eliminar.ForeColor = System.Drawing.Color.White;
            this.btn_eliminar.Location = new System.Drawing.Point(3, 154);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(102, 27);
            this.btn_eliminar.TabIndex = 8;
            this.btn_eliminar.Text = "F1-Liberar Caja";
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // dg_cajas
            // 
            this.dg_cajas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dg_cajas.Location = new System.Drawing.Point(3, 47);
            this.dg_cajas.Name = "dg_cajas";
            this.dg_cajas.Size = new System.Drawing.Size(307, 101);
            this.dg_cajas.TabIndex = 12;
            this.dg_cajas.Click += new System.EventHandler(this.dg_cajas_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(167, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 19);
            this.label3.Text = "#Recomendado:";
            // 
            // lbl_tot_cajas
            // 
            this.lbl_tot_cajas.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_tot_cajas.Location = new System.Drawing.Point(266, 23);
            this.lbl_tot_cajas.Name = "lbl_tot_cajas";
            this.lbl_tot_cajas.Size = new System.Drawing.Size(39, 20);
            this.lbl_tot_cajas.Text = "0";
            this.lbl_tot_cajas.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frm_cajas_picking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(638, 455);
            this.Controls.Add(this.lbl_tot_cajas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dg_cajas);
            this.Controls.Add(this.btn_eliminar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_caja);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_factura);
            this.Controls.Add(this.label1);
            this.Name = "frm_cajas_picking";
            this.Text = "Cajas  Para  Surtir";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_cajas_picking_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frm_cajas_picking_Closing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lbl_factura;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txt_caja;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_eliminar;
        private System.Windows.Forms.DataGrid dg_cajas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_tot_cajas;
        private System.Windows.Forms.Timer timer1;
    }
}