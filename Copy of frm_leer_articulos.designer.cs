namespace Picking
{
    partial class frm_leer_articulos2
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_unidad = new System.Windows.Forms.Label();
            this.lbl_surtir_loc = new System.Windows.Forms.Label();
            this.lbl_loc_surt = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_pendiente = new System.Windows.Forms.Label();
            this.lbl_cant_surtida = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.tab_captura = new System.Windows.Forms.TabControl();
            this.Codigo = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_caja = new System.Windows.Forms.TextBox();
            this.txt_codigo = new System.Windows.Forms.TextBox();
            this.txt_loc = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbl_caja1 = new System.Windows.Forms.Label();
            this.lbl_shipperid = new System.Windows.Forms.Label();
            this.Clave = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txt_caja1 = new System.Windows.Forms.TextBox();
            this.lbl_caja2 = new System.Windows.Forms.Label();
            this.txt_cant_art = new System.Windows.Forms.TextBox();
            this.txt_cve_art = new System.Windows.Forms.TextBox();
            this.txt_loc_art = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_salir = new System.Windows.Forms.Button();
            this.txt_desc = new System.Windows.Forms.TextBox();
            this.txt_cve = new System.Windows.Forms.TextBox();
            this.lbl_factura = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer();
            this.txt_diag = new System.Windows.Forms.TextBox();
            this.btn_excep = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.tab_captura.SuspendLayout();
            this.Codigo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.Clave.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.lbl_unidad);
            this.panel2.Controls.Add(this.lbl_surtir_loc);
            this.panel2.Controls.Add(this.lbl_loc_surt);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lbl_pendiente);
            this.panel2.Controls.Add(this.lbl_cant_surtida);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Location = new System.Drawing.Point(2, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(315, 37);
            // 
            // lbl_unidad
            // 
            this.lbl_unidad.BackColor = System.Drawing.Color.White;
            this.lbl_unidad.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_unidad.Location = new System.Drawing.Point(141, 13);
            this.lbl_unidad.Name = "lbl_unidad";
            this.lbl_unidad.Size = new System.Drawing.Size(50, 20);
            this.lbl_unidad.Text = "------";
            this.lbl_unidad.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_surtir_loc
            // 
            this.lbl_surtir_loc.BackColor = System.Drawing.Color.White;
            this.lbl_surtir_loc.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_surtir_loc.Location = new System.Drawing.Point(88, 13);
            this.lbl_surtir_loc.Name = "lbl_surtir_loc";
            this.lbl_surtir_loc.Size = new System.Drawing.Size(50, 20);
            this.lbl_surtir_loc.Text = "0";
            this.lbl_surtir_loc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_loc_surt
            // 
            this.lbl_loc_surt.BackColor = System.Drawing.Color.White;
            this.lbl_loc_surt.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_loc_surt.Location = new System.Drawing.Point(3, 13);
            this.lbl_loc_surt.Name = "lbl_loc_surt";
            this.lbl_loc_surt.Size = new System.Drawing.Size(82, 20);
            this.lbl_loc_surt.Text = "0";
            this.lbl_loc_surt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(2, -3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 19);
            this.label1.Text = "Localización";
            // 
            // lbl_pendiente
            // 
            this.lbl_pendiente.BackColor = System.Drawing.Color.Yellow;
            this.lbl_pendiente.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_pendiente.ForeColor = System.Drawing.Color.Red;
            this.lbl_pendiente.Location = new System.Drawing.Point(251, 14);
            this.lbl_pendiente.Name = "lbl_pendiente";
            this.lbl_pendiente.Size = new System.Drawing.Size(54, 20);
            this.lbl_pendiente.Text = "0";
            this.lbl_pendiente.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_cant_surtida
            // 
            this.lbl_cant_surtida.BackColor = System.Drawing.Color.White;
            this.lbl_cant_surtida.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_cant_surtida.Location = new System.Drawing.Point(194, 13);
            this.lbl_cant_surtida.Name = "lbl_cant_surtida";
            this.lbl_cant_surtida.Size = new System.Drawing.Size(54, 20);
            this.lbl_cant_surtida.Text = "0";
            this.lbl_cant_surtida.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(141, -3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 19);
            this.label2.Text = "Unidad";
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.label15.Location = new System.Drawing.Point(254, -2);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(51, 18);
            this.label15.Text = "Pend.";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(193, -3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 18);
            this.label3.Text = "Surtido";
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.label16.Location = new System.Drawing.Point(88, -3);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(49, 19);
            this.label16.Text = "Surtir";
            // 
            // tab_captura
            // 
            this.tab_captura.Controls.Add(this.Codigo);
            this.tab_captura.Controls.Add(this.Clave);
            this.tab_captura.Controls.Add(this.tabPage1);
            this.tab_captura.Enabled = false;
            this.tab_captura.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.tab_captura.Location = new System.Drawing.Point(3, 88);
            this.tab_captura.Name = "tab_captura";
            this.tab_captura.SelectedIndex = 0;
            this.tab_captura.Size = new System.Drawing.Size(314, 73);
            this.tab_captura.TabIndex = 43;
            this.tab_captura.SelectedIndexChanged += new System.EventHandler(this.tab_captura_SelectedIndexChanged);
            // 
            // Codigo
            // 
            this.Codigo.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Codigo.Controls.Add(this.panel1);
            this.Codigo.Controls.Add(this.lbl_shipperid);
            this.Codigo.Location = new System.Drawing.Point(4, 25);
            this.Codigo.Name = "Codigo";
            this.Codigo.Size = new System.Drawing.Size(306, 44);
            this.Codigo.Text = "F1-Codigo";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(224)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.txt_caja);
            this.panel1.Controls.Add(this.txt_codigo);
            this.panel1.Controls.Add(this.txt_loc);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.lbl_caja1);
            this.panel1.Location = new System.Drawing.Point(0, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(307, 41);
            // 
            // txt_caja
            // 
            this.txt_caja.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.txt_caja.Location = new System.Drawing.Point(3, 17);
            this.txt_caja.Name = "txt_caja";
            this.txt_caja.Size = new System.Drawing.Size(55, 21);
            this.txt_caja.TabIndex = 41;
            this.txt_caja.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_caja_KeyDown);
            // 
            // txt_codigo
            // 
            this.txt_codigo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.txt_codigo.Location = new System.Drawing.Point(146, 17);
            this.txt_codigo.Name = "txt_codigo";
            this.txt_codigo.Size = new System.Drawing.Size(105, 21);
            this.txt_codigo.TabIndex = 38;
            this.txt_codigo.GotFocus += new System.EventHandler(this.txt_codigo_GotFocus);
            this.txt_codigo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_codigo_KeyDown);
            this.txt_codigo.LostFocus += new System.EventHandler(this.txt_codigo_LostFocus);
            // 
            // txt_loc
            // 
            this.txt_loc.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.txt_loc.Location = new System.Drawing.Point(61, 17);
            this.txt_loc.Name = "txt_loc";
            this.txt_loc.Size = new System.Drawing.Size(82, 21);
            this.txt_loc.TabIndex = 0;
            this.txt_loc.GotFocus += new System.EventHandler(this.txt_loc_GotFocus);
            this.txt_loc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_loc_KeyDown);
            this.txt_loc.LostFocus += new System.EventHandler(this.txt_loc_LostFocus);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(146, 1);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 19);
            this.label12.Text = "Codigo";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(61, 1);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 19);
            this.label11.Text = "Loc #";
            // 
            // lbl_caja1
            // 
            this.lbl_caja1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_caja1.Location = new System.Drawing.Point(1, 0);
            this.lbl_caja1.Name = "lbl_caja1";
            this.lbl_caja1.Size = new System.Drawing.Size(57, 19);
            this.lbl_caja1.Text = "Caja #";
            // 
            // lbl_shipperid
            // 
            this.lbl_shipperid.Location = new System.Drawing.Point(133, -21);
            this.lbl_shipperid.Name = "lbl_shipperid";
            this.lbl_shipperid.Size = new System.Drawing.Size(18, 18);
            this.lbl_shipperid.Text = "0";
            // 
            // Clave
            // 
            this.Clave.Controls.Add(this.panel3);
            this.Clave.Location = new System.Drawing.Point(4, 25);
            this.Clave.Name = "Clave";
            this.Clave.Size = new System.Drawing.Size(306, 44);
            this.Clave.Text = "F2-Clave";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel3.Controls.Add(this.txt_caja1);
            this.panel3.Controls.Add(this.lbl_caja2);
            this.panel3.Controls.Add(this.txt_cant_art);
            this.panel3.Controls.Add(this.txt_cve_art);
            this.panel3.Controls.Add(this.txt_loc_art);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Location = new System.Drawing.Point(2, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(297, 44);
            // 
            // txt_caja1
            // 
            this.txt_caja1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.txt_caja1.Location = new System.Drawing.Point(3, 19);
            this.txt_caja1.Name = "txt_caja1";
            this.txt_caja1.Size = new System.Drawing.Size(61, 21);
            this.txt_caja1.TabIndex = 50;
            this.txt_caja1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_caja1_KeyDown);
            // 
            // lbl_caja2
            // 
            this.lbl_caja2.Location = new System.Drawing.Point(1, 3);
            this.lbl_caja2.Name = "lbl_caja2";
            this.lbl_caja2.Size = new System.Drawing.Size(48, 19);
            this.lbl_caja2.Text = "Caja #";
            // 
            // txt_cant_art
            // 
            this.txt_cant_art.Location = new System.Drawing.Point(238, 19);
            this.txt_cant_art.Name = "txt_cant_art";
            this.txt_cant_art.Size = new System.Drawing.Size(55, 23);
            this.txt_cant_art.TabIndex = 44;
            this.txt_cant_art.Text = "0";
            this.txt_cant_art.GotFocus += new System.EventHandler(this.txt_cant_art_GotFocus);
            this.txt_cant_art.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_cant_art_KeyDown);
            this.txt_cant_art.LostFocus += new System.EventHandler(this.txt_cant_art_LostFocus);
            // 
            // txt_cve_art
            // 
            this.txt_cve_art.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.txt_cve_art.Location = new System.Drawing.Point(151, 20);
            this.txt_cve_art.Name = "txt_cve_art";
            this.txt_cve_art.Size = new System.Drawing.Size(85, 21);
            this.txt_cve_art.TabIndex = 38;
            this.txt_cve_art.GotFocus += new System.EventHandler(this.txt_cve_art_GotFocus);
            this.txt_cve_art.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_cve_art_KeyDown);
            this.txt_cve_art.LostFocus += new System.EventHandler(this.txt_cve_art_LostFocus_1);
            // 
            // txt_loc_art
            // 
            this.txt_loc_art.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.txt_loc_art.Location = new System.Drawing.Point(65, 20);
            this.txt_loc_art.Name = "txt_loc_art";
            this.txt_loc_art.Size = new System.Drawing.Size(84, 21);
            this.txt_loc_art.TabIndex = 0;
            this.txt_loc_art.GotFocus += new System.EventHandler(this.txt_loc_art_GotFocus);
            this.txt_loc_art.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_loc_art_KeyDown);
            this.txt_loc_art.LostFocus += new System.EventHandler(this.txt_loc_art_LostFocus);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(63, 4);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 19);
            this.label9.Text = "Loc";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.label10.Location = new System.Drawing.Point(239, 3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 14);
            this.label10.Text = "Cant";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(155, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 19);
            this.label8.Text = "Clave";
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(306, 44);
            this.tabPage1.Text = "F7-Cajas";
            // 
            // btn_salir
            // 
            this.btn_salir.BackColor = System.Drawing.Color.Red;
            this.btn_salir.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btn_salir.ForeColor = System.Drawing.Color.White;
            this.btn_salir.Location = new System.Drawing.Point(207, 163);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(104, 29);
            this.btn_salir.TabIndex = 53;
            this.btn_salir.Text = "F10-Salir";
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // txt_desc
            // 
            this.txt_desc.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txt_desc.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.txt_desc.Location = new System.Drawing.Point(2, 21);
            this.txt_desc.Multiline = true;
            this.txt_desc.Name = "txt_desc";
            this.txt_desc.ReadOnly = true;
            this.txt_desc.Size = new System.Drawing.Size(315, 28);
            this.txt_desc.TabIndex = 57;
            this.txt_desc.Text = "Obteniendo articulo para surtir...";
            // 
            // txt_cve
            // 
            this.txt_cve.BackColor = System.Drawing.Color.White;
            this.txt_cve.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.txt_cve.Location = new System.Drawing.Point(160, 0);
            this.txt_cve.Multiline = true;
            this.txt_cve.Name = "txt_cve";
            this.txt_cve.ReadOnly = true;
            this.txt_cve.Size = new System.Drawing.Size(98, 21);
            this.txt_cve.TabIndex = 58;
            // 
            // lbl_factura
            // 
            this.lbl_factura.BackColor = System.Drawing.Color.White;
            this.lbl_factura.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbl_factura.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_factura.ForeColor = System.Drawing.Color.Red;
            this.lbl_factura.Location = new System.Drawing.Point(69, 0);
            this.lbl_factura.Multiline = true;
            this.lbl_factura.Name = "lbl_factura";
            this.lbl_factura.ReadOnly = true;
            this.lbl_factura.Size = new System.Drawing.Size(78, 23);
            this.lbl_factura.TabIndex = 61;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Navy;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(1, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 18);
            this.label4.Text = "Factura #";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txt_diag
            // 
            this.txt_diag.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txt_diag.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_diag.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.txt_diag.ForeColor = System.Drawing.Color.Black;
            this.txt_diag.Location = new System.Drawing.Point(148, 0);
            this.txt_diag.Multiline = true;
            this.txt_diag.Name = "txt_diag";
            this.txt_diag.ReadOnly = true;
            this.txt_diag.Size = new System.Drawing.Size(10, 21);
            this.txt_diag.TabIndex = 65;
            this.txt_diag.Text = "/";
            this.txt_diag.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_excep
            // 
            this.btn_excep.BackColor = System.Drawing.Color.Yellow;
            this.btn_excep.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btn_excep.ForeColor = System.Drawing.Color.Black;
            this.btn_excep.Location = new System.Drawing.Point(2, 162);
            this.btn_excep.Name = "btn_excep";
            this.btn_excep.Size = new System.Drawing.Size(102, 29);
            this.btn_excep.TabIndex = 67;
            this.btn_excep.Text = "Excepciones";
            // 
            // frm_leer_articulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(317, 195);
            this.Controls.Add(this.btn_excep);
            this.Controls.Add(this.txt_desc);
            this.Controls.Add(this.btn_salir);
            this.Controls.Add(this.tab_captura);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txt_cve);
            this.Controls.Add(this.txt_diag);
            this.Controls.Add(this.lbl_factura);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_leer_articulos";
            this.Text = "Surtir Articulo....";
            this.Load += new System.EventHandler(this.frm_leer_articulos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_leer_articulos_KeyDown);
            this.panel2.ResumeLayout(false);
            this.tab_captura.ResumeLayout(false);
            this.Codigo.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.Clave.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lbl_surtir_loc;
        public System.Windows.Forms.Label lbl_loc_surt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.Label lbl_pendiente;
        public System.Windows.Forms.Label lbl_cant_surtida;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tab_captura;
        private System.Windows.Forms.TabPage Codigo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_codigo;
        private System.Windows.Forms.TextBox txt_loc;
        public System.Windows.Forms.Label lbl_shipperid;
        private System.Windows.Forms.TabPage Clave;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txt_cant_art;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_cve_art;
        private System.Windows.Forms.TextBox txt_loc_art;
        private System.Windows.Forms.Button btn_salir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_unidad;
        public System.Windows.Forms.TextBox txt_desc;
        public System.Windows.Forms.TextBox txt_cve;
        public System.Windows.Forms.TextBox lbl_factura;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_caja1;
        private System.Windows.Forms.TextBox txt_caja;
        private System.Windows.Forms.TextBox txt_caja1;
        private System.Windows.Forms.Label lbl_caja2;
        private System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.TextBox txt_diag;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btn_excep;
    }
}