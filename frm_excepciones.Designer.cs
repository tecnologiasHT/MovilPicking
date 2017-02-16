namespace Picking
{
    partial class frm_excepciones
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
            this.btn_salir = new System.Windows.Forms.Button();
            this.cboexcepciones = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnaceptar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_cve_sup = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_salir
            // 
            this.btn_salir.BackColor = System.Drawing.Color.Red;
            this.btn_salir.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btn_salir.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_salir.Location = new System.Drawing.Point(3, 125);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(80, 37);
            this.btn_salir.TabIndex = 0;
            this.btn_salir.Text = "Salir";
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // cboexcepciones
            // 
            this.cboexcepciones.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.cboexcepciones.Location = new System.Drawing.Point(3, 32);
            this.cboexcepciones.Name = "cboexcepciones";
            this.cboexcepciones.Size = new System.Drawing.Size(302, 23);
            this.cboexcepciones.TabIndex = 1;
            this.cboexcepciones.SelectedIndexChanged += new System.EventHandler(this.cboexcepciones_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 20);
            this.label1.Text = "Tipo De Excepcion:";
            // 
            // btnaceptar
            // 
            this.btnaceptar.BackColor = System.Drawing.Color.Green;
            this.btnaceptar.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnaceptar.ForeColor = System.Drawing.Color.Snow;
            this.btnaceptar.Location = new System.Drawing.Point(225, 127);
            this.btnaceptar.Name = "btnaceptar";
            this.btnaceptar.Size = new System.Drawing.Size(80, 37);
            this.btnaceptar.TabIndex = 3;
            this.btnaceptar.Text = "Aceptar";
            this.btnaceptar.Click += new System.EventHandler(this.btnaceptar_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(3, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 20);
            this.label2.Text = "Clave Supervisor:";
            // 
            // txt_cve_sup
            // 
            this.txt_cve_sup.Location = new System.Drawing.Point(3, 84);
            this.txt_cve_sup.Name = "txt_cve_sup";
            this.txt_cve_sup.Size = new System.Drawing.Size(302, 23);
            this.txt_cve_sup.TabIndex = 7;
            this.txt_cve_sup.GotFocus += new System.EventHandler(this.txt_cve_sup_GotFocus);
            this.txt_cve_sup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_cve_sup_KeyDown);
            this.txt_cve_sup.LostFocus += new System.EventHandler(this.txt_cve_sup_LostFocus);
            // 
            // frm_excepciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(311, 167);
            this.Controls.Add(this.txt_cve_sup);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnaceptar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboexcepciones);
            this.Controls.Add(this.btn_salir);
            this.Name = "frm_excepciones";
            this.Text = "Registro De Excepciones";
            this.Load += new System.EventHandler(this.frm_excepciones_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_salir;
        private System.Windows.Forms.ComboBox cboexcepciones;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnaceptar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_cve_sup;
    }
}