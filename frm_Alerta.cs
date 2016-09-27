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
    public partial class frm_Alerta : Form
    {
        public frm_Alerta()
        {
            InitializeComponent();
        }

        public static System.Drawing.Color colorfondo=new Color() ;
        public string caja = "";
        private void btn_ok_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (txt_caja.Visible == false)
            {
                this.Close();
                return;
            }
            if (caja != "")
            {
                if (txt_caja.Text.Trim() != caja)
                {
                    MessageBox.Show("Numero de caja no valido");
                    txt_caja.Focus();
                    timer1.Enabled = true;
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                
               
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pnl_msj.BackColor == Color.White)
            {
                lbl_msj.Visible = true;                
                System.Media.SystemSounds.Exclamation.Play();
                pnl_msj.BackColor = colorfondo;
                if (txt_caja.Visible == false)
                {
                    pnl_msj.Focus();
                }
                else
                {
                    txt_caja.Focus();
                }
            }
            else
            {
                 lbl_msj.Visible = false; 
                 System.Media.SystemSounds.Exclamation.Play();
                 pnl_msj.BackColor = Color.White;

                 if (txt_caja.Visible == false)
                 {
                     pnl_msj.Focus();
                 }
                 else
                 {
                     txt_caja.Focus();  
                 } 

            }
        }

        private void txt_caja_GotFocus(object sender, EventArgs e)
        {
            txt_caja.BackColor = Color.Yellow;  
        }

        private void txt_caja_LostFocus(object sender, EventArgs e)
        {
            txt_caja.BackColor = Color.White; 
        }

        private void txt_caja_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txt_caja.Text.Trim() !="")
            {
                if (txt_caja.Text.Trim() == caja)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Numero de caja no valido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    txt_caja.Focus(); 
                }
            }
        }

        private void frm_Alerta_Closing(object sender, CancelEventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;  
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (txt_caja.BackColor == Color.Yellow)
            {
                txt_caja.BackColor = Color.White;
            }
            else
            {
                txt_caja.BackColor = Color.Yellow;
            }
        }

        private void frm_Alerta_Load(object sender, EventArgs e)
        {
            if (txt_caja.Visible)
            {
                timer2.Enabled = true;   
                txt_caja.Focus();  
            }
            else
            {
                pnl_msj.Focus();
            }
 
        }

        private void pnl_msj_GotFocus(object sender, EventArgs e)
        {

        }

        private void lbl_surtido_ParentChanged(object sender, EventArgs e)
        {

        }

        private void lbl_msj_ParentChanged(object sender, EventArgs e)
        {

        }

        private void lbl_msj_caja_ParentChanged(object sender, EventArgs e)
        {

        }

        private void txt_caja_TextChanged(object sender, EventArgs e)
        {

        }
    }
}