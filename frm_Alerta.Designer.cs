namespace Picking
{
    partial class frm_Alerta
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.timer1 = new System.Windows.Forms.Timer();
            this.pnl_msj = new System.Windows.Forms.Panel();
            this.lbl_surtido = new System.Windows.Forms.Label();
            this.lbl_msj = new System.Windows.Forms.Label();
            this.btn_ok = new System.Windows.Forms.Button();
            this.lbl_msj_caja = new System.Windows.Forms.Label();
            this.txt_caja = new System.Windows.Forms.TextBox();
            this.timer2 = new System.Windows.Forms.Timer();
            this.pnl_msj.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 800;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pnl_msj
            // 
            this.pnl_msj.BackColor = System.Drawing.Color.White;
            this.pnl_msj.Controls.Add(this.lbl_surtido);
            this.pnl_msj.Controls.Add(this.lbl_msj);
            this.pnl_msj.Location = new System.Drawing.Point(3, 3);
            this.pnl_msj.Name = "pnl_msj";
            this.pnl_msj.Size = new System.Drawing.Size(295, 102);
            this.pnl_msj.GotFocus += new System.EventHandler(this.pnl_msj_GotFocus);
            // 
            // lbl_surtido
            // 
            this.lbl_surtido.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.lbl_surtido.ForeColor = System.Drawing.Color.Red;
            this.lbl_surtido.Location = new System.Drawing.Point(3, 72);
            this.lbl_surtido.Name = "lbl_surtido";
            this.lbl_surtido.Size = new System.Drawing.Size(289, 20);
            this.lbl_surtido.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbl_surtido.ParentChanged += new System.EventHandler(this.lbl_surtido_ParentChanged);
            // 
            // lbl_msj
            // 
            this.lbl_msj.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.lbl_msj.ForeColor = System.Drawing.Color.Red;
            this.lbl_msj.Location = new System.Drawing.Point(3, 9);
            this.lbl_msj.Name = "lbl_msj";
            this.lbl_msj.Size = new System.Drawing.Size(289, 63);
            this.lbl_msj.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbl_msj.ParentChanged += new System.EventHandler(this.lbl_msj_ParentChanged);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(210, 130);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(86, 29);
            this.btn_ok.TabIndex = 15;
            this.btn_ok.Text = "OK";
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // lbl_msj_caja
            // 
            this.lbl_msj_caja.BackColor = System.Drawing.Color.Black;
            this.lbl_msj_caja.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_msj_caja.ForeColor = System.Drawing.Color.Lime;
            this.lbl_msj_caja.Location = new System.Drawing.Point(3, 108);
            this.lbl_msj_caja.Name = "lbl_msj_caja";
            this.lbl_msj_caja.Size = new System.Drawing.Size(295, 20);
            this.lbl_msj_caja.Visible = false;
            this.lbl_msj_caja.ParentChanged += new System.EventHandler(this.lbl_msj_caja_ParentChanged);
            // 
            // txt_caja
            // 
            this.txt_caja.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.txt_caja.Location = new System.Drawing.Point(3, 129);
            this.txt_caja.Name = "txt_caja";
            this.txt_caja.Size = new System.Drawing.Size(203, 29);
            this.txt_caja.TabIndex = 0;
            this.txt_caja.Visible = false;
            this.txt_caja.TextChanged += new System.EventHandler(this.txt_caja_TextChanged);
            this.txt_caja.GotFocus += new System.EventHandler(this.txt_caja_GotFocus);
            this.txt_caja.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_caja_KeyDown);
            this.txt_caja.LostFocus += new System.EventHandler(this.txt_caja_LostFocus);
            // 
            // timer2
            // 
            this.timer2.Interval = 500;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // frm_Alerta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(638, 455);
            this.Controls.Add(this.txt_caja);
            this.Controls.Add(this.lbl_msj_caja);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.pnl_msj);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Alerta";
            this.Text = "Aviso";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_Alerta_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frm_Alerta_Closing);
            this.pnl_msj.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Timer timer1;
       public System.Windows.Forms.Panel pnl_msj;
       public  System.Windows.Forms.Button btn_ok;
        public System.Windows.Forms.Label lbl_msj;
        public System.Windows.Forms.Label lbl_msj_caja;
        public System.Windows.Forms.TextBox txt_caja;
        public System.Windows.Forms.Timer timer2;
        public System.Windows.Forms.Label lbl_surtido;
    }
}