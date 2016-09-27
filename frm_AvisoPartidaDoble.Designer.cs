namespace Picking
{
    partial class frm_AvisoPartidaDoble
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
            this.btn_ok = new System.Windows.Forms.Button();
            this.lbl_msj = new System.Windows.Forms.Label();
            this.pnl_msj = new System.Windows.Forms.Panel();
            this.timer2 = new System.Windows.Forms.Timer();
            this.pnl_msj.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 800;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(106, 133);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(86, 29);
            this.btn_ok.TabIndex = 19;
            this.btn_ok.Text = "OK";
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click_1);
            // 
            // lbl_msj
            // 
            this.lbl_msj.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold);
            this.lbl_msj.ForeColor = System.Drawing.Color.Red;
            this.lbl_msj.Location = new System.Drawing.Point(12, 38);
            this.lbl_msj.Name = "lbl_msj";
            this.lbl_msj.Size = new System.Drawing.Size(289, 46);
            this.lbl_msj.Text = " FAVOR  DE SURTIR  LA SIGUIENTE PARTIDA....";
            this.lbl_msj.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnl_msj
            // 
            this.pnl_msj.BackColor = System.Drawing.Color.White;
            this.pnl_msj.Controls.Add(this.lbl_msj);
            this.pnl_msj.Location = new System.Drawing.Point(3, 5);
            this.pnl_msj.Name = "pnl_msj";
            this.pnl_msj.Size = new System.Drawing.Size(315, 122);
            // 
            // timer2
            // 
            this.timer2.Interval = 500;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick_1);
            // 
            // frm_AvisoPartidaDoble
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(638, 455);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.pnl_msj);
            this.Name = "frm_AvisoPartidaDoble";
            this.Text = "Aviso";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frm_AvisoPartidaDoble_Closing);
            this.pnl_msj.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Button btn_ok;
        public System.Windows.Forms.Label lbl_msj;
        public System.Windows.Forms.Panel pnl_msj;
        public System.Windows.Forms.Timer timer2;
    }
}