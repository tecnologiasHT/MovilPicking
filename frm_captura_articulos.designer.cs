namespace Picking
{
    partial class frm_captura_articulos
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
            this.lbl_factura = new System.Windows.Forms.Label();
            this.btn_Salir = new System.Windows.Forms.Button();
            this.btn_no_disp = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_unidad = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_cant_sol = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_tot_surtido = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_cve = new System.Windows.Forms.TextBox();
            this.txt_desc = new System.Windows.Forms.TextBox();
            this.lbl_tot_pend = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lbl_shipperid = new System.Windows.Forms.Label();
            this.btn_surtir = new System.Windows.Forms.Button();
            this.btn_sig_art = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_inc = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_factura
            // 
            this.lbl_factura.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.lbl_factura.ForeColor = System.Drawing.Color.Red;
            this.lbl_factura.Location = new System.Drawing.Point(4, 7);
            this.lbl_factura.Name = "lbl_factura";
            this.lbl_factura.Size = new System.Drawing.Size(142, 22);
            this.lbl_factura.Text = "0";
            // 
            // btn_Salir
            // 
            this.btn_Salir.BackColor = System.Drawing.Color.Red;
            this.btn_Salir.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btn_Salir.ForeColor = System.Drawing.Color.White;
            this.btn_Salir.Location = new System.Drawing.Point(232, 30);
            this.btn_Salir.Name = "btn_Salir";
            this.btn_Salir.Size = new System.Drawing.Size(71, 22);
            this.btn_Salir.TabIndex = 45;
            this.btn_Salir.Text = "F10-Salir";
            this.btn_Salir.Click += new System.EventHandler(this.btn_Salir_Click);
            // 
            // btn_no_disp
            // 
            this.btn_no_disp.BackColor = System.Drawing.Color.Black;
            this.btn_no_disp.Enabled = false;
            this.btn_no_disp.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btn_no_disp.ForeColor = System.Drawing.Color.White;
            this.btn_no_disp.Location = new System.Drawing.Point(231, 6);
            this.btn_no_disp.Name = "btn_no_disp";
            this.btn_no_disp.Size = new System.Drawing.Size(71, 22);
            this.btn_no_disp.TabIndex = 41;
            this.btn_no_disp.Text = "F5-NDP";
            this.btn_no_disp.Click += new System.EventHandler(this.btn_no_disp_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 20);
            this.label5.Text = "Unidad";
            // 
            // lbl_unidad
            // 
            this.lbl_unidad.BackColor = System.Drawing.Color.White;
            this.lbl_unidad.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_unidad.Location = new System.Drawing.Point(3, 89);
            this.lbl_unidad.Name = "lbl_unidad";
            this.lbl_unidad.Size = new System.Drawing.Size(105, 20);
            this.lbl_unidad.Text = "----------------------";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(115, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 18);
            this.label6.Text = "Cant.";
            // 
            // lbl_cant_sol
            // 
            this.lbl_cant_sol.BackColor = System.Drawing.Color.White;
            this.lbl_cant_sol.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_cant_sol.Location = new System.Drawing.Point(113, 89);
            this.lbl_cant_sol.Name = "lbl_cant_sol";
            this.lbl_cant_sol.Size = new System.Drawing.Size(59, 21);
            this.lbl_cant_sol.Text = "0";
            this.lbl_cant_sol.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(4, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 19);
            this.label4.Text = "Descripcion";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(174, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 19);
            this.label2.Text = "Clave:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(179, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 18);
            this.label1.Text = "Surtido.";
            this.label1.ParentChanged += new System.EventHandler(this.label1_ParentChanged);
            // 
            // lbl_tot_surtido
            // 
            this.lbl_tot_surtido.BackColor = System.Drawing.Color.White;
            this.lbl_tot_surtido.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_tot_surtido.Location = new System.Drawing.Point(179, 88);
            this.lbl_tot_surtido.Name = "lbl_tot_surtido";
            this.lbl_tot_surtido.Size = new System.Drawing.Size(59, 22);
            this.lbl_tot_surtido.Text = "0";
            this.lbl_tot_surtido.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.txt_cve);
            this.panel2.Controls.Add(this.txt_desc);
            this.panel2.Controls.Add(this.lbl_tot_pend);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.lbl_tot_surtido);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lbl_cant_sol);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.lbl_unidad);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(307, 113);
            // 
            // txt_cve
            // 
            this.txt_cve.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txt_cve.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.txt_cve.Location = new System.Drawing.Point(221, 4);
            this.txt_cve.Multiline = true;
            this.txt_cve.Name = "txt_cve";
            this.txt_cve.ReadOnly = true;
            this.txt_cve.Size = new System.Drawing.Size(82, 22);
            this.txt_cve.TabIndex = 13;
            this.txt_cve.Text = "--------------";
            this.txt_cve.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_desc
            // 
            this.txt_desc.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txt_desc.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular);
            this.txt_desc.Location = new System.Drawing.Point(4, 38);
            this.txt_desc.Multiline = true;
            this.txt_desc.Name = "txt_desc";
            this.txt_desc.ReadOnly = true;
            this.txt_desc.Size = new System.Drawing.Size(299, 36);
            this.txt_desc.TabIndex = 12;
            // 
            // lbl_tot_pend
            // 
            this.lbl_tot_pend.BackColor = System.Drawing.Color.White;
            this.lbl_tot_pend.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_tot_pend.ForeColor = System.Drawing.Color.Red;
            this.lbl_tot_pend.Location = new System.Drawing.Point(243, 89);
            this.lbl_tot_pend.Name = "lbl_tot_pend";
            this.lbl_tot_pend.Size = new System.Drawing.Size(59, 21);
            this.lbl_tot_pend.Text = "0";
            this.lbl_tot_pend.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(246, 71);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(45, 18);
            this.label13.Text = "Pend.";
            // 
            // lbl_shipperid
            // 
            this.lbl_shipperid.Location = new System.Drawing.Point(174, 8);
            this.lbl_shipperid.Name = "lbl_shipperid";
            this.lbl_shipperid.Size = new System.Drawing.Size(13, 20);
            this.lbl_shipperid.Text = "0";
            this.lbl_shipperid.Visible = false;
            this.lbl_shipperid.ParentChanged += new System.EventHandler(this.lbl_shipperid_ParentChanged);
            // 
            // btn_surtir
            // 
            this.btn_surtir.Enabled = false;
            this.btn_surtir.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btn_surtir.Location = new System.Drawing.Point(77, 32);
            this.btn_surtir.Name = "btn_surtir";
            this.btn_surtir.Size = new System.Drawing.Size(69, 22);
            this.btn_surtir.TabIndex = 51;
            this.btn_surtir.Text = "F2-SURT";
            this.btn_surtir.Click += new System.EventHandler(this.btn_surtir_Click);
            // 
            // btn_sig_art
            // 
            this.btn_sig_art.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btn_sig_art.ForeColor = System.Drawing.Color.Black;
            this.btn_sig_art.Location = new System.Drawing.Point(4, 32);
            this.btn_sig_art.Name = "btn_sig_art";
            this.btn_sig_art.Size = new System.Drawing.Size(67, 22);
            this.btn_sig_art.TabIndex = 48;
            this.btn_sig_art.Text = "F1-SIG";
            this.btn_sig_art.Click += new System.EventHandler(this.btn_sig_art_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.btn_sig_art);
            this.panel1.Controls.Add(this.lbl_shipperid);
            this.panel1.Controls.Add(this.btn_inc);
            this.panel1.Controls.Add(this.btn_surtir);
            this.panel1.Controls.Add(this.btn_Salir);
            this.panel1.Controls.Add(this.btn_no_disp);
            this.panel1.Controls.Add(this.lbl_factura);
            this.panel1.Location = new System.Drawing.Point(3, 122);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(305, 57);
            this.panel1.GotFocus += new System.EventHandler(this.panel1_GotFocus);
            // 
            // btn_inc
            // 
            this.btn_inc.BackColor = System.Drawing.Color.Yellow;
            this.btn_inc.Enabled = false;
            this.btn_inc.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btn_inc.ForeColor = System.Drawing.Color.Black;
            this.btn_inc.Location = new System.Drawing.Point(157, 31);
            this.btn_inc.Name = "btn_inc";
            this.btn_inc.Size = new System.Drawing.Size(65, 22);
            this.btn_inc.TabIndex = 53;
            this.btn_inc.Text = "F4-INC.";
            this.btn_inc.Click += new System.EventHandler(this.btn_inc_Click);
            // 
            // frm_captura_articulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(313, 184);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_captura_articulos";
            this.Text = "Articulos";
            this.Load += new System.EventHandler(this.frm_captura_articulos_Load);
            this.Activated += new System.EventHandler(this.frm_captura_articulos_Activated);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_captura_articulos_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label lbl_factura;
        private System.Windows.Forms.Button btn_Salir;
        private System.Windows.Forms.Button btn_no_disp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_unidad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_cant_sol;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_tot_surtido;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_sig_art;
        private System.Windows.Forms.Label lbl_tot_pend;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btn_surtir;
        public System.Windows.Forms.Label lbl_shipperid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_inc;
        private System.Windows.Forms.TextBox txt_cve;
        private System.Windows.Forms.TextBox txt_desc;

    }
}