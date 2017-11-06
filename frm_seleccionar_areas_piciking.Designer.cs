namespace Picking
{
    partial class frm_seleccionar_areas_piciking
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
            this.label2 = new System.Windows.Forms.Label();
            this.btn_continuar = new System.Windows.Forms.Button();
            this.btn_picking = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lstv_a = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.lstv_b = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Font = new System.Drawing.Font("Arial", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(98, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 25);
            this.label2.Text = "A";
            // 
            // btn_continuar
            // 
            this.btn_continuar.BackColor = System.Drawing.Color.Chartreuse;
            this.btn_continuar.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btn_continuar.Location = new System.Drawing.Point(201, 151);
            this.btn_continuar.Name = "btn_continuar";
            this.btn_continuar.Size = new System.Drawing.Size(91, 33);
            this.btn_continuar.TabIndex = 9;
            this.btn_continuar.Text = "Aceptar";
            this.btn_continuar.Click += new System.EventHandler(this.btn_continuar_Click);
            this.btn_continuar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btn_continuar_KeyDown);
            // 
            // btn_picking
            // 
            this.btn_picking.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular);
            this.btn_picking.Location = new System.Drawing.Point(104, 151);
            this.btn_picking.Name = "btn_picking";
            this.btn_picking.Size = new System.Drawing.Size(91, 33);
            this.btn_picking.TabIndex = 10;
            this.btn_picking.Text = "Sel Picking";
            this.btn_picking.Click += new System.EventHandler(this.btn_picking_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(7, 151);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 33);
            this.button1.TabIndex = 11;
            this.button1.Text = "Salir";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lstv_a
            // 
            this.lstv_a.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lstv_a.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lstv_a.CheckBoxes = true;
            this.lstv_a.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.lstv_a.ForeColor = System.Drawing.Color.White;
            this.lstv_a.FullRowSelect = true;
            this.lstv_a.Location = new System.Drawing.Point(23, 1);
            this.lstv_a.Name = "lstv_a";
            this.lstv_a.Size = new System.Drawing.Size(75, 144);
            this.lstv_a.TabIndex = 16;
            this.lstv_a.View = System.Windows.Forms.View.SmallIcon;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Gold;
            this.label1.Font = new System.Drawing.Font("Arial", 16F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(175, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 25);
            this.label1.Text = "B";
            // 
            // lstv_b
            // 
            this.lstv_b.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lstv_b.BackColor = System.Drawing.Color.Gold;
            this.lstv_b.CheckBoxes = true;
            this.lstv_b.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.lstv_b.ForeColor = System.Drawing.Color.Black;
            this.lstv_b.FullRowSelect = true;
            this.lstv_b.Location = new System.Drawing.Point(202, 0);
            this.lstv_b.Name = "lstv_b";
            this.lstv_b.Size = new System.Drawing.Size(75, 144);
            this.lstv_b.TabIndex = 19;
            this.lstv_b.View = System.Windows.Forms.View.SmallIcon;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Location = new System.Drawing.Point(134, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(28, 144);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Silver;
            this.label8.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(2, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 20);
            this.label8.Text = "---";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Silver;
            this.label7.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(2, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 20);
            this.label7.Text = "---";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Silver;
            this.label6.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(2, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 20);
            this.label6.Text = "---";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Silver;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(2, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 20);
            this.label5.Text = "---";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Silver;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(2, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 20);
            this.label4.Text = "---";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Silver;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(2, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 20);
            this.label3.Text = "---";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Silver;
            this.label9.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(2, 105);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 20);
            this.label9.Text = "---";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frm_seleccionar_areas_piciking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(638, 455);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lstv_b);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstv_a);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_picking);
            this.Controls.Add(this.btn_continuar);
            this.Controls.Add(this.label2);
            this.Name = "frm_seleccionar_areas_piciking";
            this.Text = "Seleccionar Zona/Area";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_seleccionar_areas_piciking_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_continuar;
        private System.Windows.Forms.Button btn_picking;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView lstv_a;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lstv_b;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
    }
}