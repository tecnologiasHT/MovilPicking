namespace Picking
{
    partial class frm_leer_loc
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
            this.lbl_loc = new System.Windows.Forms.Label();
            this.txt_loc = new System.Windows.Forms.TextBox();
            this.btn_Cerrar = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer();
            this.SuspendLayout();
            // 
            // lbl_loc
            // 
            this.lbl_loc.BackColor = System.Drawing.Color.Black;
            this.lbl_loc.Font = new System.Drawing.Font("Tahoma", 30F, System.Drawing.FontStyle.Regular);
            this.lbl_loc.ForeColor = System.Drawing.Color.Lime;
            this.lbl_loc.Location = new System.Drawing.Point(3, 2);
            this.lbl_loc.Name = "lbl_loc";
            this.lbl_loc.Size = new System.Drawing.Size(311, 64);
            this.lbl_loc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txt_loc
            // 
            this.txt_loc.Font = new System.Drawing.Font("Tahoma", 27F, System.Drawing.FontStyle.Regular);
            this.txt_loc.Location = new System.Drawing.Point(3, 69);
            this.txt_loc.Name = "txt_loc";
            this.txt_loc.Size = new System.Drawing.Size(313, 50);
            this.txt_loc.TabIndex = 0;
            this.txt_loc.TextChanged += new System.EventHandler(this.txt_loc_TextChanged);
            this.txt_loc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_loc_KeyDown);
            // 
            // btn_Cerrar
            // 
            this.btn_Cerrar.BackColor = System.Drawing.Color.Red;
            this.btn_Cerrar.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btn_Cerrar.ForeColor = System.Drawing.Color.White;
            this.btn_Cerrar.Location = new System.Drawing.Point(99, 125);
            this.btn_Cerrar.Name = "btn_Cerrar";
            this.btn_Cerrar.Size = new System.Drawing.Size(115, 43);
            this.btn_Cerrar.TabIndex = 4;
            this.btn_Cerrar.Text = "Cerrar";
            this.btn_Cerrar.Click += new System.EventHandler(this.btn_Cerrar_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frm_leer_loc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(638, 455);
            this.Controls.Add(this.btn_Cerrar);
            this.Controls.Add(this.txt_loc);
            this.Controls.Add(this.lbl_loc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frm_leer_loc";
            this.Text = "2.-Leer Localización";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_leer_loc_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frm_leer_loc_Closing);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label lbl_loc;
        public System.Windows.Forms.TextBox txt_loc;
        private System.Windows.Forms.Button btn_Cerrar;
        private System.Windows.Forms.Timer timer1;
    }
}