namespace Picking
{
    partial class frm_seleccionar_picking
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
            this.btn_picking1 = new System.Windows.Forms.Button();
            this.btn_picking2 = new System.Windows.Forms.Button();
            this.btn_salir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_picking1
            // 
            this.btn_picking1.BackColor = System.Drawing.Color.LawnGreen;
            this.btn_picking1.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold);
            this.btn_picking1.Location = new System.Drawing.Point(21, 15);
            this.btn_picking1.Name = "btn_picking1";
            this.btn_picking1.Size = new System.Drawing.Size(136, 72);
            this.btn_picking1.TabIndex = 0;
            this.btn_picking1.Text = "Picking 1";
            this.btn_picking1.Click += new System.EventHandler(this.btn_picking1_Click);
            // 
            // btn_picking2
            // 
            this.btn_picking2.BackColor = System.Drawing.Color.Yellow;
            this.btn_picking2.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold);
            this.btn_picking2.ForeColor = System.Drawing.Color.Black;
            this.btn_picking2.Location = new System.Drawing.Point(163, 15);
            this.btn_picking2.Name = "btn_picking2";
            this.btn_picking2.Size = new System.Drawing.Size(136, 72);
            this.btn_picking2.TabIndex = 1;
            this.btn_picking2.Text = "Picking 2";
            this.btn_picking2.Click += new System.EventHandler(this.btn_picking2_Click);
            // 
            // btn_salir
            // 
            this.btn_salir.BackColor = System.Drawing.Color.Red;
            this.btn_salir.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.btn_salir.ForeColor = System.Drawing.Color.White;
            this.btn_salir.Location = new System.Drawing.Point(99, 125);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(120, 37);
            this.btn_salir.TabIndex = 2;
            this.btn_salir.Text = "Salir";
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // frm_seleccionar_picking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(638, 455);
            this.Controls.Add(this.btn_salir);
            this.Controls.Add(this.btn_picking2);
            this.Controls.Add(this.btn_picking1);
            this.Name = "frm_seleccionar_picking";
            this.Text = "Seleccionar Picking";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_picking1;
        private System.Windows.Forms.Button btn_picking2;
        private System.Windows.Forms.Button btn_salir;

    }
}