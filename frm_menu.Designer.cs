namespace Picking
{
    partial class frm_menu
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
            this.btn_surtimiento = new System.Windows.Forms.Button();
            this.btn_cambiar_secc = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.grd_zonas = new System.Windows.Forms.DataGrid();
            this.lbl_picking = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_salir = new System.Windows.Forms.Button();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.button1 = new System.Windows.Forms.Button();
            this.linkIndicadores = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_surtimiento
            // 
            this.btn_surtimiento.BackColor = System.Drawing.Color.Lime;
            this.btn_surtimiento.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btn_surtimiento.ForeColor = System.Drawing.Color.Black;
            this.btn_surtimiento.Location = new System.Drawing.Point(147, 67);
            this.btn_surtimiento.Name = "btn_surtimiento";
            this.btn_surtimiento.Size = new System.Drawing.Size(122, 50);
            this.btn_surtimiento.TabIndex = 0;
            this.btn_surtimiento.Text = "F1- Surtir";
            this.btn_surtimiento.Click += new System.EventHandler(this.btn_surtimiento_Click);
            // 
            // btn_cambiar_secc
            // 
            this.btn_cambiar_secc.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.btn_cambiar_secc.Location = new System.Drawing.Point(147, 34);
            this.btn_cambiar_secc.Name = "btn_cambiar_secc";
            this.btn_cambiar_secc.Size = new System.Drawing.Size(122, 30);
            this.btn_cambiar_secc.TabIndex = 2;
            this.btn_cambiar_secc.Text = "F2- Zonas";
            this.btn_cambiar_secc.Click += new System.EventHandler(this.btn_cambiar_secc_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panel1.Controls.Add(this.linkIndicadores);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.grd_zonas);
            this.panel1.Controls.Add(this.lbl_picking);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(138, 154);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.Text = "Zonas:";
            // 
            // grd_zonas
            // 
            this.grd_zonas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.grd_zonas.Location = new System.Drawing.Point(3, 39);
            this.grd_zonas.Name = "grd_zonas";
            this.grd_zonas.Size = new System.Drawing.Size(129, 88);
            this.grd_zonas.TabIndex = 19;
            // 
            // lbl_picking
            // 
            this.lbl_picking.BackColor = System.Drawing.Color.White;
            this.lbl_picking.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_picking.Location = new System.Drawing.Point(87, 4);
            this.lbl_picking.Name = "lbl_picking";
            this.lbl_picking.Size = new System.Drawing.Size(41, 22);
            this.lbl_picking.Text = "0";
            this.lbl_picking.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(1, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.Text = "PICKING";
            // 
            // btn_salir
            // 
            this.btn_salir.BackColor = System.Drawing.Color.Red;
            this.btn_salir.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_salir.Location = new System.Drawing.Point(147, 123);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(122, 29);
            this.btn_salir.TabIndex = 16;
            this.btn_salir.Text = "F10-Salir";
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 431);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(638, 24);
            this.statusBar1.Text = "statusBar1";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(147, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 28);
            this.button1.TabIndex = 19;
            this.button1.Text = "F3- Picking";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // linkIndicadores
            // 
            this.linkIndicadores.Font = new System.Drawing.Font("Tahoma", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.linkIndicadores.Location = new System.Drawing.Point(21, 130);
            this.linkIndicadores.Name = "linkIndicadores";
            this.linkIndicadores.Size = new System.Drawing.Size(114, 20);
            this.linkIndicadores.TabIndex = 23;
            this.linkIndicadores.Text = "Indicadores...";
            this.linkIndicadores.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.linkIndicadores.Click += new System.EventHandler(this.linkIndicadores_Click);
            // 
            // frm_menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(638, 455);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.btn_salir);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_cambiar_secc);
            this.Controls.Add(this.btn_surtimiento);
            this.MaximizeBox = false;
            this.Name = "frm_menu";
            this.Text = "Menu    ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_menu_Load);
            this.Activated += new System.EventHandler(this.frm_menu_Activated);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frm_menu_Closing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_menu_KeyDown);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_surtimiento;
        private System.Windows.Forms.Button btn_cambiar_secc;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_salir;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.Label lbl_picking;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGrid grd_zonas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.LinkLabel linkIndicadores;
    }
}