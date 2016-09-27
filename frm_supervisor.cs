using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Picking
{
    public partial class frm_supervisor : Form
    {
        public frm_supervisor()
        {
            InitializeComponent();
        }
        public bool ok = false;
        public string supervisor;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (txt_codigo.BackColor == Color.White)
            {
                txt_codigo.BackColor = Color.Yellow;
            }
            else
            {
                txt_codigo.BackColor = Color.White;
            }
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;  
            this.Close();
        }

        private void txt_codigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txt_codigo.Text.Trim() !="")
            {               

                Global.obtener_datos_supervisor(txt_codigo.Text.Trim().ToUpper(), out supervisor);
                if (supervisor != "")
                {
                  ok = true;   
                  this.Close();                    
                }
                else
                {
                    MessageBox.Show("Clave de supervisor no valida", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    txt_codigo.Text = "";
                    txt_codigo.Focus();

                }
            }


        }

        private void frm_supervisor_Closing(object sender, CancelEventArgs e)
        {
            timer1.Enabled = false;   
        }
    }
}