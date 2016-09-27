namespace Picking
{
    partial class frm_sel_loc
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
            this.dg_loc = new System.Windows.Forms.DataGrid();
            this.lbl_clave = new System.Windows.Forms.Label();
            this.lbl_desc = new System.Windows.Forms.Label();
            this.txt_loc = new System.Windows.Forms.TextBox();
            this.btn_ok = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dg_loc
            // 
            this.dg_loc.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dg_loc.Location = new System.Drawing.Point(3, 0);
            this.dg_loc.Name = "dg_loc";
            this.dg_loc.Size = new System.Drawing.Size(215, 69);
            this.dg_loc.TabIndex = 0;
            this.dg_loc.DoubleClick += new System.EventHandler(this.dg_loc_DoubleClick);
            this.dg_loc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dg_loc_KeyDown);
            this.dg_loc.Click += new System.EventHandler(this.dg_loc_Click);
            // 
            // lbl_clave
            // 
            this.lbl_clave.BackColor = System.Drawing.Color.White;
            this.lbl_clave.Location = new System.Drawing.Point(5, 5);
            this.lbl_clave.Name = "lbl_clave";
            this.lbl_clave.Size = new System.Drawing.Size(67, 19);
            // 
            // lbl_desc
            // 
            this.lbl_desc.BackColor = System.Drawing.Color.White;
            this.lbl_desc.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular);
            this.lbl_desc.Location = new System.Drawing.Point(75, 5);
            this.lbl_desc.Name = "lbl_desc";
            this.lbl_desc.Size = new System.Drawing.Size(157, 19);
            // 
            // txt_loc
            // 
            this.txt_loc.Location = new System.Drawing.Point(1, 27);
            this.txt_loc.Name = "txt_loc";
            this.txt_loc.Size = new System.Drawing.Size(215, 23);
            this.txt_loc.TabIndex = 4;
            this.txt_loc.GotFocus += new System.EventHandler(this.txt_loc_GotFocus);
            this.txt_loc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_loc_KeyDown);
            this.txt_loc.LostFocus += new System.EventHandler(this.txt_loc_LostFocus);
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(5, 130);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(85, 20);
            this.btn_ok.TabIndex = 5;
            this.btn_ok.Text = "F3-Aceptar";
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(156, 129);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(72, 20);
            this.button2.TabIndex = 7;
            this.button2.Text = "F10-Cerrar";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 20);
            this.label2.Text = "2.- Leer Localización:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(229, 100);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dg_loc);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(221, 71);
            this.tabPage1.Text = "F1-Sel Localizacion";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.txt_loc);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(221, 71);
            this.tabPage2.Text = "F2-Validar";
            // 
            // frm_sel_loc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(234, 154);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.lbl_desc);
            this.Controls.Add(this.lbl_clave);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_sel_loc";
            this.Text = "Seleccionar Localizacion";
            this.Load += new System.EventHandler(this.frm_sel_loc_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_sel_loc_KeyDown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGrid dg_loc;
        public System.Windows.Forms.Label lbl_clave;
        public System.Windows.Forms.Label lbl_desc;
        public System.Windows.Forms.TextBox txt_loc;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}