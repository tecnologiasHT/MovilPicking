namespace Picking
{
    partial class frm_surtir_articulo
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
            this.lbl_loc_surt = new System.Windows.Forms.Label();
            this.lbl_surtir_loc = new System.Windows.Forms.Label();
            this.lbl_unidad = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbltipo = new System.Windows.Forms.Label();
            this.lblcaja = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblsurtido = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_salir = new System.Windows.Forms.Button();
            this.txtmsj = new System.Windows.Forms.TextBox();
            this.btn_excepcion = new System.Windows.Forms.Button();
            this.t1 = new System.Windows.Forms.Timer();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTotPartidas = new System.Windows.Forms.Label();
            this.txt_desc = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Clave = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_cant_art = new System.Windows.Forms.TextBox();
            this.txt_cve_art = new System.Windows.Forms.TextBox();
            this.Codigo = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_cant_codigo = new System.Windows.Forms.TextBox();
            this.txt_codigo = new System.Windows.Forms.TextBox();
            this.lbl_shipperid = new System.Windows.Forms.Label();
            this.tab_captura = new System.Windows.Forms.TabControl();
            this.lbl_tot_por_surtir = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.Clave.SuspendLayout();
            this.Codigo.SuspendLayout();
            this.tab_captura.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_loc_surt
            // 
            this.lbl_loc_surt.BackColor = System.Drawing.Color.Black;
            this.lbl_loc_surt.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lbl_loc_surt.ForeColor = System.Drawing.Color.White;
            this.lbl_loc_surt.Location = new System.Drawing.Point(3, 16);
            this.lbl_loc_surt.Name = "lbl_loc_surt";
            this.lbl_loc_surt.Size = new System.Drawing.Size(111, 24);
            this.lbl_loc_surt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_surtir_loc
            // 
            this.lbl_surtir_loc.BackColor = System.Drawing.Color.Black;
            this.lbl_surtir_loc.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lbl_surtir_loc.ForeColor = System.Drawing.Color.Lime;
            this.lbl_surtir_loc.Location = new System.Drawing.Point(115, 16);
            this.lbl_surtir_loc.Name = "lbl_surtir_loc";
            this.lbl_surtir_loc.Size = new System.Drawing.Size(80, 24);
            this.lbl_surtir_loc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_unidad
            // 
            this.lbl_unidad.BackColor = System.Drawing.Color.Black;
            this.lbl_unidad.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lbl_unidad.ForeColor = System.Drawing.Color.White;
            this.lbl_unidad.Location = new System.Drawing.Point(196, 16);
            this.lbl_unidad.Name = "lbl_unidad";
            this.lbl_unidad.Size = new System.Drawing.Size(45, 24);
            this.lbl_unidad.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(4, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.Text = "Localización";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(120, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.Text = "CantSol.";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(194, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.Text = "Unidad.";
            // 
            // lbltipo
            // 
            this.lbltipo.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbltipo.Location = new System.Drawing.Point(0, 154);
            this.lbltipo.Name = "lbltipo";
            this.lbltipo.Size = new System.Drawing.Size(59, 18);
            this.lbltipo.Text = "Caja #";
            this.lbltipo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblcaja
            // 
            this.lblcaja.BackColor = System.Drawing.Color.Transparent;
            this.lblcaja.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblcaja.ForeColor = System.Drawing.Color.Red;
            this.lblcaja.Location = new System.Drawing.Point(5, 172);
            this.lblcaja.Name = "lblcaja";
            this.lblcaja.Size = new System.Drawing.Size(53, 19);
            this.lblcaja.Text = "0000";
            this.lblcaja.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lblsurtido);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lbl_loc_surt);
            this.panel1.Controls.Add(this.lbl_surtir_loc);
            this.panel1.Controls.Add(this.lbl_unidad);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(314, 47);
            // 
            // lblsurtido
            // 
            this.lblsurtido.BackColor = System.Drawing.Color.Yellow;
            this.lblsurtido.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblsurtido.ForeColor = System.Drawing.Color.Red;
            this.lblsurtido.Location = new System.Drawing.Point(242, 16);
            this.lblsurtido.Name = "lblsurtido";
            this.lblsurtido.Size = new System.Drawing.Size(68, 24);
            this.lblsurtido.Text = "00000";
            this.lblsurtido.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(253, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 15);
            this.label4.Text = "Surtido";
            // 
            // btn_salir
            // 
            this.btn_salir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_salir.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btn_salir.ForeColor = System.Drawing.Color.White;
            this.btn_salir.Location = new System.Drawing.Point(249, 157);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(65, 34);
            this.btn_salir.TabIndex = 82;
            this.btn_salir.Text = "Salir";
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // txtmsj
            // 
            this.txtmsj.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtmsj.ForeColor = System.Drawing.Color.Red;
            this.txtmsj.Location = new System.Drawing.Point(134, 161);
            this.txtmsj.Multiline = true;
            this.txtmsj.Name = "txtmsj";
            this.txtmsj.Size = new System.Drawing.Size(20, 20);
            this.txtmsj.TabIndex = 84;
            // 
            // btn_excepcion
            // 
            this.btn_excepcion.BackColor = System.Drawing.Color.Yellow;
            this.btn_excepcion.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btn_excepcion.Location = new System.Drawing.Point(160, 157);
            this.btn_excepcion.Name = "btn_excepcion";
            this.btn_excepcion.Size = new System.Drawing.Size(83, 34);
            this.btn_excepcion.TabIndex = 86;
            this.btn_excepcion.Text = "Excepcion";
            this.btn_excepcion.Click += new System.EventHandler(this.btn_excepcion_Click);
            // 
            // t1
            // 
            this.t1.Enabled = true;
            this.t1.Interval = 1000;
            this.t1.Tick += new System.EventHandler(this.t1_Tick);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(68, 154);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 18);
            this.label7.Text = "Partidas";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTotPartidas
            // 
            this.lblTotPartidas.BackColor = System.Drawing.Color.Transparent;
            this.lblTotPartidas.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotPartidas.ForeColor = System.Drawing.Color.Red;
            this.lblTotPartidas.Location = new System.Drawing.Point(68, 170);
            this.lblTotPartidas.Name = "lblTotPartidas";
            this.lblTotPartidas.Size = new System.Drawing.Size(75, 21);
            this.lblTotPartidas.Text = "0";
            this.lblTotPartidas.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txt_desc
            // 
            this.txt_desc.BackColor = System.Drawing.SystemColors.ControlText;
            this.txt_desc.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txt_desc.ForeColor = System.Drawing.Color.Lime;
            this.txt_desc.Location = new System.Drawing.Point(1, 1);
            this.txt_desc.Multiline = true;
            this.txt_desc.Name = "txt_desc";
            this.txt_desc.ReadOnly = true;
            this.txt_desc.Size = new System.Drawing.Size(313, 39);
            this.txt_desc.TabIndex = 60;
            this.txt_desc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_desc.GotFocus += new System.EventHandler(this.txt_desc_GotFocus);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(306, 35);
            this.tabPage1.Text = "F3-Sel. Caja..";
            // 
            // Clave
            // 
            this.Clave.BackColor = System.Drawing.Color.White;
            this.Clave.Controls.Add(this.label6);
            this.Clave.Controls.Add(this.txt_cant_art);
            this.Clave.Controls.Add(this.txt_cve_art);
            this.Clave.Location = new System.Drawing.Point(4, 25);
            this.Clave.Name = "Clave";
            this.Clave.Size = new System.Drawing.Size(306, 35);
            this.Clave.Text = "F2-Clave";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(199, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 27);
            this.label6.Text = "X";
            // 
            // txt_cant_art
            // 
            this.txt_cant_art.Enabled = false;
            this.txt_cant_art.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txt_cant_art.Location = new System.Drawing.Point(227, 4);
            this.txt_cant_art.Name = "txt_cant_art";
            this.txt_cant_art.ReadOnly = true;
            this.txt_cant_art.Size = new System.Drawing.Size(75, 26);
            this.txt_cant_art.TabIndex = 44;
            this.txt_cant_art.Text = "1";
            this.txt_cant_art.GotFocus += new System.EventHandler(this.txt_cant_art_GotFocus);
            this.txt_cant_art.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_cant_art_KeyDown);
            this.txt_cant_art.LostFocus += new System.EventHandler(this.txt_cant_art_LostFocus);
            // 
            // txt_cve_art
            // 
            this.txt_cve_art.Enabled = false;
            this.txt_cve_art.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txt_cve_art.Location = new System.Drawing.Point(3, 4);
            this.txt_cve_art.Name = "txt_cve_art";
            this.txt_cve_art.ReadOnly = true;
            this.txt_cve_art.Size = new System.Drawing.Size(191, 26);
            this.txt_cve_art.TabIndex = 38;
            this.txt_cve_art.GotFocus += new System.EventHandler(this.txt_cve_art_GotFocus);
            this.txt_cve_art.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_cve_art_KeyDown);
            this.txt_cve_art.LostFocus += new System.EventHandler(this.txt_cve_art_LostFocus);
            // 
            // Codigo
            // 
            this.Codigo.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Codigo.Controls.Add(this.label5);
            this.Codigo.Controls.Add(this.txt_cant_codigo);
            this.Codigo.Controls.Add(this.txt_codigo);
            this.Codigo.Controls.Add(this.lbl_shipperid);
            this.Codigo.Location = new System.Drawing.Point(4, 25);
            this.Codigo.Name = "Codigo";
            this.Codigo.Size = new System.Drawing.Size(306, 35);
            this.Codigo.Text = "F1-Codigo";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(192, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 27);
            this.label5.Text = "X";
            // 
            // txt_cant_codigo
            // 
            this.txt_cant_codigo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txt_cant_codigo.Location = new System.Drawing.Point(219, 3);
            this.txt_cant_codigo.Name = "txt_cant_codigo";
            this.txt_cant_codigo.Size = new System.Drawing.Size(86, 26);
            this.txt_cant_codigo.TabIndex = 39;
            this.txt_cant_codigo.Text = "1";
            this.txt_cant_codigo.GotFocus += new System.EventHandler(this.txt_cant_codigo_GotFocus);
            this.txt_cant_codigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_cant_codigo_KeyDown);
            this.txt_cant_codigo.LostFocus += new System.EventHandler(this.txt_cant_codigo_LostFocus);
            // 
            // txt_codigo
            // 
            this.txt_codigo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txt_codigo.Location = new System.Drawing.Point(15, 3);
            this.txt_codigo.Name = "txt_codigo";
            this.txt_codigo.Size = new System.Drawing.Size(176, 26);
            this.txt_codigo.TabIndex = 38;
            this.txt_codigo.GotFocus += new System.EventHandler(this.txt_codigo_GotFocus);
            this.txt_codigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_codigo_KeyDown);
            this.txt_codigo.LostFocus += new System.EventHandler(this.txt_codigo_LostFocus);
            // 
            // lbl_shipperid
            // 
            this.lbl_shipperid.Location = new System.Drawing.Point(133, -21);
            this.lbl_shipperid.Name = "lbl_shipperid";
            this.lbl_shipperid.Size = new System.Drawing.Size(18, 18);
            this.lbl_shipperid.Text = "0";
            // 
            // tab_captura
            // 
            this.tab_captura.Controls.Add(this.Codigo);
            this.tab_captura.Controls.Add(this.Clave);
            this.tab_captura.Controls.Add(this.tabPage1);
            this.tab_captura.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.tab_captura.Location = new System.Drawing.Point(3, 198);
            this.tab_captura.Name = "tab_captura";
            this.tab_captura.SelectedIndex = 0;
            this.tab_captura.Size = new System.Drawing.Size(314, 64);
            this.tab_captura.TabIndex = 71;
            this.tab_captura.Visible = false;
            this.tab_captura.SelectedIndexChanged += new System.EventHandler(this.tab_captura_SelectedIndexChanged);
            // 
            // lbl_tot_por_surtir
            // 
            this.lbl_tot_por_surtir.BackColor = System.Drawing.Color.Black;
            this.lbl_tot_por_surtir.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Regular);
            this.lbl_tot_por_surtir.ForeColor = System.Drawing.Color.Lime;
            this.lbl_tot_por_surtir.Location = new System.Drawing.Point(0, 92);
            this.lbl_tot_por_surtir.Name = "lbl_tot_por_surtir";
            this.lbl_tot_por_surtir.Size = new System.Drawing.Size(314, 57);
            this.lbl_tot_por_surtir.Text = "0";
            this.lbl_tot_por_surtir.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Black;
            this.label8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(0, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 21);
            this.label8.Text = "Surtir:";
            // 
            // frm_surtir_articulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(638, 455);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbl_tot_por_surtir);
            this.Controls.Add(this.txt_desc);
            this.Controls.Add(this.lblTotPartidas);
            this.Controls.Add(this.lblcaja);
            this.Controls.Add(this.btn_excepcion);
            this.Controls.Add(this.txtmsj);
            this.Controls.Add(this.btn_salir);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbltipo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tab_captura);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "frm_surtir_articulo";
            this.Text = "3.- Surtir Articulo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_surtir_articulo_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frm_surtir_articulo_Closing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_surtir_articulo_KeyDown);
            this.panel1.ResumeLayout(false);
            this.Clave.ResumeLayout(false);
            this.Codigo.ResumeLayout(false);
            this.tab_captura.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label lbl_loc_surt;
        private System.Windows.Forms.Label lbl_surtir_loc;
        private System.Windows.Forms.Label lbl_unidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lbltipo;
        public System.Windows.Forms.Label lblcaja;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_salir;
        private System.Windows.Forms.TextBox txtmsj;
        private System.Windows.Forms.Button btn_excepcion;
        private System.Windows.Forms.Timer t1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblsurtido;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label lblTotPartidas;
        public System.Windows.Forms.TextBox txt_desc;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage Clave;
        public System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_cant_art;
        private System.Windows.Forms.TextBox txt_cve_art;
        private System.Windows.Forms.TabPage Codigo;
        public System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_cant_codigo;
        private System.Windows.Forms.TextBox txt_codigo;
        public System.Windows.Forms.Label lbl_shipperid;
        private System.Windows.Forms.TabControl tab_captura;
        private System.Windows.Forms.Label lbl_tot_por_surtir;
        private System.Windows.Forms.Label label8;
    }
}