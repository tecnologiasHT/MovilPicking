namespace Picking
{
    partial class frm_leer_carrito
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
            this.txt_no = new System.Windows.Forms.TextBox();
            this.btn_ok = new System.Windows.Forms.Button();
            this.lbltipo = new System.Windows.Forms.Label();
            this.btn_salir = new System.Windows.Forms.Button();
            this.btncaja = new System.Windows.Forms.Button();
            this.lblmsg = new System.Windows.Forms.Label();
            this.btn_carrito = new System.Windows.Forms.Button();
            this.btntarima = new System.Windows.Forms.Button();
            this.btnbuscar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_no
            // 
            this.txt_no.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Regular);
            this.txt_no.Location = new System.Drawing.Point(1, 101);
            this.txt_no.Name = "txt_no";
            this.txt_no.Size = new System.Drawing.Size(294, 39);
            this.txt_no.TabIndex = 3;
            this.txt_no.GotFocus += new System.EventHandler(this.txt_no_GotFocus);
            this.txt_no.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_no_KeyDown);
            this.txt_no.LostFocus += new System.EventHandler(this.txt_no_LostFocus);
            // 
            // btn_ok
            // 
            this.btn_ok.BackColor = System.Drawing.Color.Lime;
            this.btn_ok.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btn_ok.Location = new System.Drawing.Point(3, 146);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(83, 35);
            this.btn_ok.TabIndex = 4;
            this.btn_ok.Text = "OK";
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // lbltipo
            // 
            this.lbltipo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lbltipo.Location = new System.Drawing.Point(3, 0);
            this.lbltipo.Name = "lbltipo";
            this.lbltipo.Size = new System.Drawing.Size(295, 23);
            this.lbltipo.Text = "Seleccionar Medio Para Surtir:";
            // 
            // btn_salir
            // 
            this.btn_salir.BackColor = System.Drawing.Color.Red;
            this.btn_salir.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btn_salir.ForeColor = System.Drawing.Color.White;
            this.btn_salir.Location = new System.Drawing.Point(216, 148);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(79, 35);
            this.btn_salir.TabIndex = 6;
            this.btn_salir.Text = "Salir";
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // btncaja
            // 
            this.btncaja.Location = new System.Drawing.Point(5, 25);
            this.btncaja.Name = "btncaja";
            this.btncaja.Size = new System.Drawing.Size(81, 50);
            this.btncaja.TabIndex = 0;
            this.btncaja.Text = "Caja";
            this.btncaja.Click += new System.EventHandler(this.btncaja_Click);
            this.btncaja.GotFocus += new System.EventHandler(this.btncaja_GotFocus);
            // 
            // lblmsg
            // 
            this.lblmsg.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblmsg.Location = new System.Drawing.Point(3, 81);
            this.lblmsg.Name = "lblmsg";
            this.lblmsg.Size = new System.Drawing.Size(150, 20);
            this.lblmsg.Text = "CARRITO #";
            // 
            // btn_carrito
            // 
            this.btn_carrito.Location = new System.Drawing.Point(108, 26);
            this.btn_carrito.Name = "btn_carrito";
            this.btn_carrito.Size = new System.Drawing.Size(86, 50);
            this.btn_carrito.TabIndex = 1;
            this.btn_carrito.Text = "Carrito";
            this.btn_carrito.Click += new System.EventHandler(this.btn_carrito_Click);
            // 
            // btntarima
            // 
            this.btntarima.Location = new System.Drawing.Point(215, 27);
            this.btntarima.Name = "btntarima";
            this.btntarima.Size = new System.Drawing.Size(76, 50);
            this.btntarima.TabIndex = 2;
            this.btntarima.Text = "Tarima";
            this.btntarima.Click += new System.EventHandler(this.btntarima_Click);
            // 
            // btnbuscar
            // 
            this.btnbuscar.BackColor = System.Drawing.Color.Blue;
            this.btnbuscar.Enabled = false;
            this.btnbuscar.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnbuscar.ForeColor = System.Drawing.Color.White;
            this.btnbuscar.Location = new System.Drawing.Point(102, 146);
            this.btnbuscar.Name = "btnbuscar";
            this.btnbuscar.Size = new System.Drawing.Size(92, 35);
            this.btnbuscar.TabIndex = 5;
            this.btnbuscar.Text = "Buscar";
            this.btnbuscar.Click += new System.EventHandler(this.btnbuscar_Click);
            // 
            // frm_leer_carrito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(301, 186);
            this.Controls.Add(this.btnbuscar);
            this.Controls.Add(this.btntarima);
            this.Controls.Add(this.btn_carrito);
            this.Controls.Add(this.lblmsg);
            this.Controls.Add(this.btncaja);
            this.Controls.Add(this.btn_salir);
            this.Controls.Add(this.lbltipo);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.txt_no);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frm_leer_carrito";
            this.Text = "Medio Para Surtir en PICKING2";
            this.Load += new System.EventHandler(this.frm_leer_carrito_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txt_no;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Label lbltipo;
        private System.Windows.Forms.Button btn_salir;
        private System.Windows.Forms.Button btncaja;
        private System.Windows.Forms.Label lblmsg;
        private System.Windows.Forms.Button btn_carrito;
        private System.Windows.Forms.Button btntarima;
        private System.Windows.Forms.Button btnbuscar;
    }
}