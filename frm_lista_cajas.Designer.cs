namespace Picking
{
    partial class frm_lista_cajas
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
            this.lstcajas = new System.Windows.Forms.ListBox();
            this.btnsel = new System.Windows.Forms.Button();
            this.btnagregar = new System.Windows.Forms.Button();
            this.btn_salir = new System.Windows.Forms.Button();
            this.lbltipo = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstcajas
            // 
            this.lstcajas.BackColor = System.Drawing.SystemColors.HotTrack;
            this.lstcajas.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.lstcajas.ForeColor = System.Drawing.Color.White;
            this.lstcajas.Location = new System.Drawing.Point(3, 29);
            this.lstcajas.Name = "lstcajas";
            this.lstcajas.Size = new System.Drawing.Size(286, 106);
            this.lstcajas.TabIndex = 0;
            // 
            // btnsel
            // 
            this.btnsel.BackColor = System.Drawing.Color.Lime;
            this.btnsel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnsel.Location = new System.Drawing.Point(2, 136);
            this.btnsel.Name = "btnsel";
            this.btnsel.Size = new System.Drawing.Size(66, 48);
            this.btnsel.TabIndex = 1;
            this.btnsel.Text = "SEL";
            this.btnsel.Click += new System.EventHandler(this.btnsel_Click);
            // 
            // btnagregar
            // 
            this.btnagregar.BackColor = System.Drawing.Color.Blue;
            this.btnagregar.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnagregar.ForeColor = System.Drawing.Color.White;
            this.btnagregar.Location = new System.Drawing.Point(74, 136);
            this.btnagregar.Name = "btnagregar";
            this.btnagregar.Size = new System.Drawing.Size(70, 48);
            this.btnagregar.TabIndex = 2;
            this.btnagregar.Text = "Agregar";
            this.btnagregar.Click += new System.EventHandler(this.btnagregar_Click);
            // 
            // btn_salir
            // 
            this.btn_salir.BackColor = System.Drawing.Color.Red;
            this.btn_salir.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btn_salir.ForeColor = System.Drawing.Color.White;
            this.btn_salir.Location = new System.Drawing.Point(225, 136);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(62, 48);
            this.btn_salir.TabIndex = 3;
            this.btn_salir.Text = "Salir";
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // lbltipo
            // 
            this.lbltipo.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbltipo.Location = new System.Drawing.Point(6, 5);
            this.lbltipo.Name = "lbltipo";
            this.lbltipo.Size = new System.Drawing.Size(175, 20);
            this.lbltipo.Text = "-------";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Yellow;
            this.button1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(149, 136);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 48);
            this.button1.TabIndex = 4;
            this.button1.Text = "Liberar";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frm_lista_cajas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(297, 189);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbltipo);
            this.Controls.Add(this.btn_salir);
            this.Controls.Add(this.btnagregar);
            this.Controls.Add(this.btnsel);
            this.Controls.Add(this.lstcajas);
            this.Name = "frm_lista_cajas";
            this.Load += new System.EventHandler(this.frm_lista_cajas_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstcajas;
        private System.Windows.Forms.Button btnsel;
        private System.Windows.Forms.Button btnagregar;
        private System.Windows.Forms.Button btn_salir;
        public System.Windows.Forms.Label lbltipo;
        private System.Windows.Forms.Button button1;
    }
}