namespace Picking
{
    partial class frm_supervisor
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
            this.txt_codigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer();
            this.btn_Salir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_codigo
            // 
            this.txt_codigo.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txt_codigo.Font = new System.Drawing.Font("Arial", 22F, System.Drawing.FontStyle.Regular);
            this.txt_codigo.Location = new System.Drawing.Point(3, 65);
            this.txt_codigo.Name = "txt_codigo";
            this.txt_codigo.PasswordChar = '*';
            this.txt_codigo.Size = new System.Drawing.Size(324, 40);
            this.txt_codigo.TabIndex = 0;
            this.txt_codigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_codigo_KeyDown);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(301, 49);
            this.label1.Text = "Clave Autorización";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btn_Salir
            // 
            this.btn_Salir.BackColor = System.Drawing.Color.Red;
            this.btn_Salir.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btn_Salir.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_Salir.Location = new System.Drawing.Point(105, 125);
            this.btn_Salir.Name = "btn_Salir";
            this.btn_Salir.Size = new System.Drawing.Size(102, 48);
            this.btn_Salir.TabIndex = 2;
            this.btn_Salir.Text = "Salir";
            this.btn_Salir.Click += new System.EventHandler(this.btn_Salir_Click);
            // 
            // frm_supervisor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(330, 186);
            this.Controls.Add(this.btn_Salir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_codigo);
            this.MinimizeBox = false;
            this.Name = "frm_supervisor";
            this.Text = "Supervisor";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frm_supervisor_Closing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txt_codigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Salir;
        public System.Windows.Forms.Timer timer1;
    }
}