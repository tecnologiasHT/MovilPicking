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
    public partial class frm_AvisoPartidaDoble : Form
    {
        public frm_AvisoPartidaDoble()
        {
            InitializeComponent();
        }
        public static System.Drawing.Color colorfondo = new Color();

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void txt_caja_GotFocus(object sender, EventArgs e)
        {

        }

        private void txt_caja_KeyDown(object sender, KeyEventArgs e)
        {

        }
        private void txt_caja_LostFocus(object sender, EventArgs e)
        {

        }
        private void btn_ok_Click(object sender, EventArgs e)
        {

        }
        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        private void btn_ok_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_AvisoPartidaDoble_Closing(object sender, CancelEventArgs e)
        {
            timer1.Enabled = false;
           
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            pnl_msj.Focus();  
            if (pnl_msj.BackColor == Color.White)
            {
                lbl_msj.Visible = true;
                //lbl_surtido.Visible = true; 
                System.Media.SystemSounds.Exclamation.Play();
                pnl_msj.BackColor =Color.Yellow  ;
               
            }
            else
            {
                lbl_msj.Visible = false;
                System.Media.SystemSounds.Exclamation.Play();
                pnl_msj.BackColor = Color.White;               
            }
        }

        private void timer2_Tick_1(object sender, EventArgs e)
        {
            if (pnl_msj.BackColor   == Color.Yellow)
            {
                pnl_msj.BackColor = Color.White;
            }
            else
            {
                pnl_msj.BackColor = Color.White;
            }
        }
    }
}