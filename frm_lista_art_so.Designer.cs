namespace Picking
{
    partial class frm_lista_art_so
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
            this.dg_articulos = new System.Windows.Forms.DataGrid();
            this.btn_surtir = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dg_articulos
            // 
            this.dg_articulos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dg_articulos.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.dg_articulos.Location = new System.Drawing.Point(3, 3);
            this.dg_articulos.Name = "dg_articulos";
            this.dg_articulos.Size = new System.Drawing.Size(338, 131);
            this.dg_articulos.TabIndex = 0;
            // 
            // btn_surtir
            // 
            this.btn_surtir.Location = new System.Drawing.Point(3, 140);
            this.btn_surtir.Name = "btn_surtir";
            this.btn_surtir.Size = new System.Drawing.Size(79, 39);
            this.btn_surtir.TabIndex = 1;
            this.btn_surtir.Text = "Surtir";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(261, 140);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(79, 39);
            this.button2.TabIndex = 2;
            this.button2.Text = "Cerrar";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frm_lista_art_so
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(344, 182);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_surtir);
            this.Controls.Add(this.dg_articulos);
            this.Name = "frm_lista_art_so";
            this.Text = "Lista Articulos En Surtimiento";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGrid dg_articulos;
        private System.Windows.Forms.Button btn_surtir;
        private System.Windows.Forms.Button button2;
    }
}