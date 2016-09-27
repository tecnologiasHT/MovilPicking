namespace Picking
{
    partial class frm_zona
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
            this.txt_seccion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_area = new System.Windows.Forms.TextBox();
            this.btn_aceptar = new System.Windows.Forms.Button();
            this.btn_Salir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.Text = "Zona:";
            // 
            // txt_seccion
            // 
            this.txt_seccion.Location = new System.Drawing.Point(3, 33);
            this.txt_seccion.Name = "txt_seccion";
            this.txt_seccion.Size = new System.Drawing.Size(314, 23);
            this.txt_seccion.TabIndex = 1;
            this.txt_seccion.GotFocus += new System.EventHandler(this.txt_seccion_GotFocus);
            this.txt_seccion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_seccion_KeyDown);
            this.txt_seccion.LostFocus += new System.EventHandler(this.txt_seccion_LostFocus);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 23);
            this.label2.Text = "Area:";
            // 
            // txt_area
            // 
            this.txt_area.Location = new System.Drawing.Point(3, 87);
            this.txt_area.Name = "txt_area";
            this.txt_area.Size = new System.Drawing.Size(314, 23);
            this.txt_area.TabIndex = 4;
            this.txt_area.GotFocus += new System.EventHandler(this.txt_area_GotFocus);
            this.txt_area.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_area_KeyDown);
            this.txt_area.LostFocus += new System.EventHandler(this.txt_area_LostFocus);
            // 
            // btn_aceptar
            // 
            this.btn_aceptar.Location = new System.Drawing.Point(3, 126);
            this.btn_aceptar.Name = "btn_aceptar";
            this.btn_aceptar.Size = new System.Drawing.Size(87, 44);
            this.btn_aceptar.TabIndex = 5;
            this.btn_aceptar.Text = "F1-Aceptar";
            this.btn_aceptar.Click += new System.EventHandler(this.btn_aceptar_Click);
            // 
            // btn_Salir
            // 
            this.btn_Salir.Location = new System.Drawing.Point(217, 126);
            this.btn_Salir.Name = "btn_Salir";
            this.btn_Salir.Size = new System.Drawing.Size(100, 44);
            this.btn_Salir.TabIndex = 6;
            this.btn_Salir.Text = "F10-Salir";
            this.btn_Salir.Click += new System.EventHandler(this.btn_Salir_Click);
            // 
            // frm_zona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(320, 189);
            this.Controls.Add(this.btn_Salir);
            this.Controls.Add(this.btn_aceptar);
            this.Controls.Add(this.txt_area);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_seccion);
            this.Controls.Add(this.label1);
            this.Name = "frm_zona";
            this.Text = "Seleccionar Zona...";
            this.Load += new System.EventHandler(this.frm_zona_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_zona_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_seccion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_area;
        private System.Windows.Forms.Button btn_aceptar;
        private System.Windows.Forms.Button btn_Salir;
    }
}