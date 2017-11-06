namespace Picking
{
    partial class frm_sel_caja
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
            this.timer1 = new System.Windows.Forms.Timer();
            this.txtcaja = new System.Windows.Forms.TextBox();
            this.btncerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtcaja
            // 
            this.txtcaja.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular);
            this.txtcaja.Location = new System.Drawing.Point(3, 1);
            this.txtcaja.Name = "txtcaja";
            this.txtcaja.Size = new System.Drawing.Size(311, 45);
            this.txtcaja.TabIndex = 0;
            this.txtcaja.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtcaja_KeyDown);
            // 
            // btncerrar
            // 
            this.btncerrar.BackColor = System.Drawing.Color.Red;
            this.btncerrar.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btncerrar.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btncerrar.Location = new System.Drawing.Point(99, 57);
            this.btncerrar.Name = "btncerrar";
            this.btncerrar.Size = new System.Drawing.Size(112, 42);
            this.btncerrar.TabIndex = 2;
            this.btncerrar.Text = "Cerrar";
            this.btncerrar.Click += new System.EventHandler(this.btncerrar_Click);
            // 
            // frm_sel_caja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(317, 106);
            this.Controls.Add(this.btncerrar);
            this.Controls.Add(this.txtcaja);
            this.MinimizeBox = false;
            this.Name = "frm_sel_caja";
            this.Text = "1.- Seleccionar Caja";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frm_sel_caja_Closing);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TextBox txtcaja;
        private System.Windows.Forms.Button btncerrar;
        public System.Windows.Forms.Timer timer1;
    }
}