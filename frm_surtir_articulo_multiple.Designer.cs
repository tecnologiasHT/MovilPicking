﻿namespace Picking
{
    partial class frm_surtir_articulo_multiple
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
            this.lblcaja = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_excepcion = new System.Windows.Forms.Button();
            this.txtmsj = new System.Windows.Forms.TextBox();
            this.btn_salir = new System.Windows.Forms.Button();
            this.txt_cant_art = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblsurtido = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_loc_surt = new System.Windows.Forms.Label();
            this.lbl_surtir_loc = new System.Windows.Forms.Label();
            this.lbl_unidad = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.t1 = new System.Windows.Forms.Timer();
            this.lbltipo = new System.Windows.Forms.Label();
            this.txt_desc = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tab_captura = new System.Windows.Forms.TabControl();
            this.Codigo = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_cant_codigo = new System.Windows.Forms.TextBox();
            this.txt_codigo = new System.Windows.Forms.TextBox();
            this.lbl_shipperid = new System.Windows.Forms.Label();
            this.Clave = new System.Windows.Forms.TabPage();
            this.txt_cve_art = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_partida = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tab_captura.SuspendLayout();
            this.Codigo.SuspendLayout();
            this.Clave.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblcaja
            // 
            this.lblcaja.BackColor = System.Drawing.Color.Transparent;
            this.lblcaja.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblcaja.Location = new System.Drawing.Point(52, 165);
            this.lblcaja.Name = "lblcaja";
            this.lblcaja.Size = new System.Drawing.Size(68, 22);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(195, -2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.Text = "Unidad.";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(131, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.Text = "Surtir.";
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
            // btn_excepcion
            // 
            this.btn_excepcion.BackColor = System.Drawing.Color.Yellow;
            this.btn_excepcion.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btn_excepcion.Location = new System.Drawing.Point(127, 159);
            this.btn_excepcion.Name = "btn_excepcion";
            this.btn_excepcion.Size = new System.Drawing.Size(96, 34);
            this.btn_excepcion.TabIndex = 94;
            this.btn_excepcion.Text = "Excepcion";
            // 
            // txtmsj
            // 
            this.txtmsj.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtmsj.ForeColor = System.Drawing.Color.Red;
            this.txtmsj.Location = new System.Drawing.Point(140, 163);
            this.txtmsj.Multiline = true;
            this.txtmsj.Name = "txtmsj";
            this.txtmsj.Size = new System.Drawing.Size(77, 20);
            this.txtmsj.TabIndex = 93;
            // 
            // btn_salir
            // 
            this.btn_salir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_salir.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btn_salir.ForeColor = System.Drawing.Color.White;
            this.btn_salir.Location = new System.Drawing.Point(231, 159);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(88, 34);
            this.btn_salir.TabIndex = 92;
            this.btn_salir.Text = "F10-Salir";
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click_1);
            // 
            // txt_cant_art
            // 
            this.txt_cant_art.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txt_cant_art.Location = new System.Drawing.Point(227, 4);
            this.txt_cant_art.Name = "txt_cant_art";
            this.txt_cant_art.Size = new System.Drawing.Size(75, 31);
            this.txt_cant_art.TabIndex = 44;
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
            this.panel1.Location = new System.Drawing.Point(6, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(314, 47);
            // 
            // lblsurtido
            // 
            this.lblsurtido.BackColor = System.Drawing.Color.Black;
            this.lblsurtido.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblsurtido.ForeColor = System.Drawing.Color.Yellow;
            this.lblsurtido.Location = new System.Drawing.Point(242, 16);
            this.lblsurtido.Name = "lblsurtido";
            this.lblsurtido.Size = new System.Drawing.Size(68, 24);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(253, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 15);
            this.label4.Text = "Surtido";
            // 
            // lbl_loc_surt
            // 
            this.lbl_loc_surt.BackColor = System.Drawing.Color.Black;
            this.lbl_loc_surt.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lbl_loc_surt.ForeColor = System.Drawing.Color.White;
            this.lbl_loc_surt.Location = new System.Drawing.Point(3, 17);
            this.lbl_loc_surt.Name = "lbl_loc_surt";
            this.lbl_loc_surt.Size = new System.Drawing.Size(111, 23);
            // 
            // lbl_surtir_loc
            // 
            this.lbl_surtir_loc.BackColor = System.Drawing.Color.Black;
            this.lbl_surtir_loc.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lbl_surtir_loc.ForeColor = System.Drawing.Color.Lime;
            this.lbl_surtir_loc.Location = new System.Drawing.Point(115, 16);
            this.lbl_surtir_loc.Name = "lbl_surtir_loc";
            this.lbl_surtir_loc.Size = new System.Drawing.Size(80, 24);
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
            // t1
            // 
            this.t1.Enabled = true;
            this.t1.Interval = 1000;
            // 
            // lbltipo
            // 
            this.lbltipo.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbltipo.Location = new System.Drawing.Point(6, 166);
            this.lbltipo.Name = "lbltipo";
            this.lbltipo.Size = new System.Drawing.Size(59, 20);
            this.lbltipo.Text = "Caja #";
            // 
            // txt_desc
            // 
            this.txt_desc.BackColor = System.Drawing.SystemColors.ControlText;
            this.txt_desc.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.txt_desc.ForeColor = System.Drawing.Color.Lime;
            this.txt_desc.Location = new System.Drawing.Point(9, 3);
            this.txt_desc.Multiline = true;
            this.txt_desc.Name = "txt_desc";
            this.txt_desc.ReadOnly = true;
            this.txt_desc.Size = new System.Drawing.Size(270, 39);
            this.txt_desc.TabIndex = 90;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(306, 30);
            this.tabPage1.Text = "F3-Sel. Caja..";
            // 
            // tab_captura
            // 
            this.tab_captura.Controls.Add(this.Codigo);
            this.tab_captura.Controls.Add(this.Clave);
            this.tab_captura.Controls.Add(this.tabPage1);
            this.tab_captura.Enabled = false;
            this.tab_captura.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.tab_captura.Location = new System.Drawing.Point(6, 93);
            this.tab_captura.Name = "tab_captura";
            this.tab_captura.SelectedIndex = 0;
            this.tab_captura.Size = new System.Drawing.Size(314, 64);
            this.tab_captura.TabIndex = 91;
            // 
            // Codigo
            // 
            this.Codigo.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Codigo.Controls.Add(this.label5);
            this.Codigo.Controls.Add(this.txt_cant_codigo);
            this.Codigo.Controls.Add(this.txt_codigo);
            this.Codigo.Controls.Add(this.lbl_shipperid);
            this.Codigo.Location = new System.Drawing.Point(4, 30);
            this.Codigo.Name = "Codigo";
            this.Codigo.Size = new System.Drawing.Size(306, 30);
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
            this.txt_cant_codigo.Location = new System.Drawing.Point(221, 3);
            this.txt_cant_codigo.Name = "txt_cant_codigo";
            this.txt_cant_codigo.Size = new System.Drawing.Size(84, 31);
            this.txt_cant_codigo.TabIndex = 39;
            // 
            // txt_codigo
            // 
            this.txt_codigo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txt_codigo.Location = new System.Drawing.Point(3, 3);
            this.txt_codigo.Name = "txt_codigo";
            this.txt_codigo.Size = new System.Drawing.Size(180, 31);
            this.txt_codigo.TabIndex = 38;
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
            this.Clave.BackColor = System.Drawing.Color.White;
            this.Clave.Controls.Add(this.label6);
            this.Clave.Controls.Add(this.txt_cant_art);
            this.Clave.Controls.Add(this.txt_cve_art);
            this.Clave.Location = new System.Drawing.Point(4, 30);
            this.Clave.Name = "Clave";
            this.Clave.Size = new System.Drawing.Size(306, 30);
            this.Clave.Text = "F2-Clave";
            // 
            // txt_cve_art
            // 
            this.txt_cve_art.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txt_cve_art.Location = new System.Drawing.Point(3, 4);
            this.txt_cve_art.Name = "txt_cve_art";
            this.txt_cve_art.Size = new System.Drawing.Size(191, 31);
            this.txt_cve_art.TabIndex = 38;
            // 
            // timer1
            // 
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Yellow;
            this.panel2.Controls.Add(this.lbl_partida);
            this.panel2.Location = new System.Drawing.Point(282, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(40, 39);
            // 
            // lbl_partida
            // 
            this.lbl_partida.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lbl_partida.Location = new System.Drawing.Point(3, 9);
            this.lbl_partida.Name = "lbl_partida";
            this.lbl_partida.Size = new System.Drawing.Size(34, 20);
            this.lbl_partida.Text = "9/9";
            // 
            // frm_surtir_articulo_multiple
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(326, 196);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblcaja);
            this.Controls.Add(this.btn_excepcion);
            this.Controls.Add(this.txtmsj);
            this.Controls.Add(this.btn_salir);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbltipo);
            this.Controls.Add(this.txt_desc);
            this.Controls.Add(this.tab_captura);
            this.Name = "frm_surtir_articulo_multiple";
            this.Text = "Surtir Articulo";
            this.panel1.ResumeLayout(false);
            this.tab_captura.ResumeLayout(false);
            this.Codigo.ResumeLayout(false);
            this.Clave.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label lblcaja;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_excepcion;
        private System.Windows.Forms.TextBox txtmsj;
        private System.Windows.Forms.Button btn_salir;
        private System.Windows.Forms.TextBox txt_cant_art;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblsurtido;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label lbl_loc_surt;
        private System.Windows.Forms.Label lbl_surtir_loc;
        private System.Windows.Forms.Label lbl_unidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer t1;
        public System.Windows.Forms.Label lbltipo;
        public System.Windows.Forms.TextBox txt_desc;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tab_captura;
        private System.Windows.Forms.TabPage Codigo;
        public System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_cant_codigo;
        private System.Windows.Forms.TextBox txt_codigo;
        public System.Windows.Forms.Label lbl_shipperid;
        private System.Windows.Forms.TabPage Clave;
        private System.Windows.Forms.TextBox txt_cve_art;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbl_partida;
    }
}