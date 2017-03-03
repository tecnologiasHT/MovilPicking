namespace Picking
{
    partial class frmSurtimiento
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
            this.txt_part_surtidas = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_salir = new System.Windows.Forms.Button();
            this.lbl_shiperid = new System.Windows.Forms.Label();
            this.btn_ver = new System.Windows.Forms.Button();
            this.btn_aceptar = new System.Windows.Forms.Button();
            this.txt_partidas = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_prioridad = new System.Windows.Forms.TextBox();
            this.txt_cajas = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer();
            this.lbl_msj = new System.Windows.Forms.Label();
            this.btn_cajas = new System.Windows.Forms.Button();
            this.timer2 = new System.Windows.Forms.Timer();
            this.dgarticulos = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.btn_recibir_cajas = new System.Windows.Forms.Button();
            this.txt_factura = new System.Windows.Forms.TextBox();
            this.btn_mover = new System.Windows.Forms.Button();
            this.t1 = new System.Windows.Forms.Timer();
            this.timer_timeout = new System.Windows.Forms.Timer();
            this.lst_cajas = new System.Windows.Forms.ListBox();
            this.txt_leyenda = new System.Windows.Forms.TextBox();
            this.btnIndicadores = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_part_surtidas
            // 
            this.txt_part_surtidas.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txt_part_surtidas.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.txt_part_surtidas.Location = new System.Drawing.Point(63, 28);
            this.txt_part_surtidas.Name = "txt_part_surtidas";
            this.txt_part_surtidas.ReadOnly = true;
            this.txt_part_surtidas.Size = new System.Drawing.Size(42, 24);
            this.txt_part_surtidas.TabIndex = 56;
            this.txt_part_surtidas.Text = "0";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(14, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 20);
            this.label5.Text = "Surtido:";
            // 
            // btn_salir
            // 
            this.btn_salir.BackColor = System.Drawing.Color.Yellow;
            this.btn_salir.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btn_salir.ForeColor = System.Drawing.Color.Black;
            this.btn_salir.Location = new System.Drawing.Point(230, 155);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(67, 29);
            this.btn_salir.TabIndex = 44;
            this.btn_salir.Text = "Salir";
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // lbl_shiperid
            // 
            this.lbl_shiperid.Location = new System.Drawing.Point(111, 22);
            this.lbl_shiperid.Name = "lbl_shiperid";
            this.lbl_shiperid.Size = new System.Drawing.Size(23, 10);
            this.lbl_shiperid.Text = "0";
            this.lbl_shiperid.Visible = false;
            // 
            // btn_ver
            // 
            this.btn_ver.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_ver.Enabled = false;
            this.btn_ver.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btn_ver.Location = new System.Drawing.Point(182, 2);
            this.btn_ver.Name = "btn_ver";
            this.btn_ver.Size = new System.Drawing.Size(32, 26);
            this.btn_ver.TabIndex = 13;
            this.btn_ver.Text = "VER";
            this.btn_ver.Click += new System.EventHandler(this.btn_ver_Click);
            // 
            // btn_aceptar
            // 
            this.btn_aceptar.Enabled = false;
            this.btn_aceptar.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btn_aceptar.ForeColor = System.Drawing.Color.Black;
            this.btn_aceptar.Location = new System.Drawing.Point(4, 156);
            this.btn_aceptar.Name = "btn_aceptar";
            this.btn_aceptar.Size = new System.Drawing.Size(72, 28);
            this.btn_aceptar.TabIndex = 12;
            this.btn_aceptar.Text = "F1-SURTIR";
            this.btn_aceptar.Click += new System.EventHandler(this.btn_aceptar_Click);
            // 
            // txt_partidas
            // 
            this.txt_partidas.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txt_partidas.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.txt_partidas.Location = new System.Drawing.Point(161, 2);
            this.txt_partidas.Name = "txt_partidas";
            this.txt_partidas.ReadOnly = true;
            this.txt_partidas.Size = new System.Drawing.Size(41, 24);
            this.txt_partidas.TabIndex = 11;
            this.txt_partidas.Text = "0";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(105, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 20);
            this.label4.Text = "Partidas:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightYellow;
            this.panel1.Controls.Add(this.txt_prioridad);
            this.panel1.Controls.Add(this.lbl_shiperid);
            this.panel1.Controls.Add(this.txt_part_surtidas);
            this.panel1.Controls.Add(this.txt_partidas);
            this.panel1.Controls.Add(this.txt_cajas);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(3, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(207, 57);
            // 
            // txt_prioridad
            // 
            this.txt_prioridad.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txt_prioridad.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.txt_prioridad.ForeColor = System.Drawing.Color.Red;
            this.txt_prioridad.Location = new System.Drawing.Point(63, 2);
            this.txt_prioridad.Name = "txt_prioridad";
            this.txt_prioridad.ReadOnly = true;
            this.txt_prioridad.Size = new System.Drawing.Size(42, 24);
            this.txt_prioridad.TabIndex = 68;
            // 
            // txt_cajas
            // 
            this.txt_cajas.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txt_cajas.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.txt_cajas.ForeColor = System.Drawing.Color.Red;
            this.txt_cajas.Location = new System.Drawing.Point(161, 30);
            this.txt_cajas.Name = "txt_cajas";
            this.txt_cajas.ReadOnly = true;
            this.txt_cajas.Size = new System.Drawing.Size(42, 24);
            this.txt_cajas.TabIndex = 74;
            this.txt_cajas.Text = "0";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.Text = "Prioridad:";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(107, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 20);
            this.label6.Text = "Cajas:";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbl_msj
            // 
            this.lbl_msj.BackColor = System.Drawing.Color.White;
            this.lbl_msj.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lbl_msj.ForeColor = System.Drawing.Color.Red;
            this.lbl_msj.Location = new System.Drawing.Point(6, 128);
            this.lbl_msj.Name = "lbl_msj";
            this.lbl_msj.Size = new System.Drawing.Size(298, 25);
            this.lbl_msj.Text = "Espere un momento....\r\n ";
            // 
            // btn_cajas
            // 
            this.btn_cajas.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btn_cajas.Enabled = false;
            this.btn_cajas.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btn_cajas.Location = new System.Drawing.Point(217, 3);
            this.btn_cajas.Name = "btn_cajas";
            this.btn_cajas.Size = new System.Drawing.Size(91, 26);
            this.btn_cajas.TabIndex = 48;
            this.btn_cajas.Text = "F5-CAJAS";
            this.btn_cajas.Click += new System.EventHandler(this.btn_cajas_Click);
            // 
            // timer2
            // 
            this.timer2.Interval = 5000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // dgarticulos
            // 
            this.dgarticulos.BackColor = System.Drawing.Color.White;
            this.dgarticulos.BackgroundColor = System.Drawing.Color.White;
            this.dgarticulos.ColumnHeadersVisible = false;
            this.dgarticulos.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.dgarticulos.Location = new System.Drawing.Point(3, 88);
            this.dgarticulos.Name = "dgarticulos";
            this.dgarticulos.RowHeadersVisible = false;
            this.dgarticulos.Size = new System.Drawing.Size(207, 37);
            this.dgarticulos.TabIndex = 80;
            this.dgarticulos.TableStyles.Add(this.dataGridTableStyle1);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn1);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn2);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn3);
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = global::Picking.Properties.Resources.usuario;
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.Width = 120;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = global::Picking.Properties.Resources.usuario;
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.Width = 150;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = global::Picking.Properties.Resources.usuario;
            this.dataGridTextBoxColumn3.FormatInfo = null;
            // 
            // btn_recibir_cajas
            // 
            this.btn_recibir_cajas.Enabled = false;
            this.btn_recibir_cajas.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btn_recibir_cajas.ForeColor = System.Drawing.Color.Black;
            this.btn_recibir_cajas.Location = new System.Drawing.Point(80, 156);
            this.btn_recibir_cajas.Name = "btn_recibir_cajas";
            this.btn_recibir_cajas.Size = new System.Drawing.Size(73, 28);
            this.btn_recibir_cajas.TabIndex = 57;
            this.btn_recibir_cajas.Text = "F2-RECIBIR";
            this.btn_recibir_cajas.Click += new System.EventHandler(this.btn_recibir_cajas_Click1);
            // 
            // txt_factura
            // 
            this.txt_factura.BackColor = System.Drawing.SystemColors.HighlightText;
            this.txt_factura.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.txt_factura.ForeColor = System.Drawing.Color.Red;
            this.txt_factura.Location = new System.Drawing.Point(5, 2);
            this.txt_factura.Name = "txt_factura";
            this.txt_factura.ReadOnly = true;
            this.txt_factura.Size = new System.Drawing.Size(82, 23);
            this.txt_factura.TabIndex = 69;
            // 
            // btn_mover
            // 
            this.btn_mover.Enabled = false;
            this.btn_mover.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btn_mover.ForeColor = System.Drawing.Color.Black;
            this.btn_mover.Location = new System.Drawing.Point(157, 156);
            this.btn_mover.Name = "btn_mover";
            this.btn_mover.Size = new System.Drawing.Size(69, 28);
            this.btn_mover.TabIndex = 74;
            this.btn_mover.Text = "F3-MOVER";
            this.btn_mover.Click += new System.EventHandler(this.btn_mover_Click);
            // 
            // t1
            // 
            this.t1.Interval = 1000;
            this.t1.Tick += new System.EventHandler(this.t1_Tick);
            // 
            // timer_timeout
            // 
            this.timer_timeout.Enabled = true;
            this.timer_timeout.Interval = 60000;
            this.timer_timeout.Tick += new System.EventHandler(this.timer_timeout_Tick);
            // 
            // lst_cajas
            // 
            this.lst_cajas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lst_cajas.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lst_cajas.ForeColor = System.Drawing.Color.White;
            this.lst_cajas.Location = new System.Drawing.Point(217, 32);
            this.lst_cajas.Name = "lst_cajas";
            this.lst_cajas.Size = new System.Drawing.Size(91, 74);
            this.lst_cajas.TabIndex = 0;
            // 
            // txt_leyenda
            // 
            this.txt_leyenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txt_leyenda.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txt_leyenda.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            this.txt_leyenda.ForeColor = System.Drawing.Color.Black;
            this.txt_leyenda.Location = new System.Drawing.Point(93, 2);
            this.txt_leyenda.Multiline = true;
            this.txt_leyenda.Name = "txt_leyenda";
            this.txt_leyenda.ReadOnly = true;
            this.txt_leyenda.Size = new System.Drawing.Size(86, 23);
            this.txt_leyenda.TabIndex = 84;
            // 
            // btnIndicadores
            // 
            this.btnIndicadores.BackColor = System.Drawing.Color.DarkGreen;
            this.btnIndicadores.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.btnIndicadores.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnIndicadores.Location = new System.Drawing.Point(213, 104);
            this.btnIndicadores.Name = "btnIndicadores";
            this.btnIndicadores.Size = new System.Drawing.Size(96, 22);
            this.btnIndicadores.TabIndex = 88;
            this.btnIndicadores.Text = "INDICADORES";
            this.btnIndicadores.Click += new System.EventHandler(this.btnIndicadores_Click);
            // 
            // frmSurtimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(638, 455);
            this.Controls.Add(this.btnIndicadores);
            this.Controls.Add(this.txt_leyenda);
            this.Controls.Add(this.lst_cajas);
            this.Controls.Add(this.dgarticulos);
            this.Controls.Add(this.btn_mover);
            this.Controls.Add(this.txt_factura);
            this.Controls.Add(this.btn_recibir_cajas);
            this.Controls.Add(this.btn_cajas);
            this.Controls.Add(this.btn_salir);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_ver);
            this.Controls.Add(this.btn_aceptar);
            this.Controls.Add(this.lbl_msj);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "frmSurtimiento";
            this.Text = "Surtimiento Factura:";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSurtimiento_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmSurtimiento_Closing_1);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSurtimiento_KeyDown);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_aceptar;
        private System.Windows.Forms.TextBox txt_partidas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_ver;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lbl_shiperid;
        private System.Windows.Forms.Button btn_salir;
        private System.Windows.Forms.TextBox txt_part_surtidas;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_prioridad;
        private System.Windows.Forms.Label lbl_msj;
        private System.Windows.Forms.Button btn_cajas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_cajas;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button btn_recibir_cajas;
        public System.Windows.Forms.TextBox txt_factura;
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btn_mover;
        private System.Windows.Forms.DataGrid dgarticulos;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
        private System.Windows.Forms.Timer t1;
        private System.Windows.Forms.Timer timer_timeout;
        private System.Windows.Forms.ListBox lst_cajas;
        public System.Windows.Forms.TextBox txt_leyenda;
        private System.Windows.Forms.Button btnIndicadores;
    }
}