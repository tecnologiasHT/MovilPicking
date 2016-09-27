using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Picking
{
    public partial class frm_sel_caja : Form
    {
        public frm_sel_caja()
        {
            InitializeComponent();
        }

        public string invcnbr="";
        public string caja = "";

        private void btncerrar_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;  
            this.Close();
        }
        bool verifica_caja(string invcnbr, string numcaja)
        {
            //@InvcNbr VARCHAR(15),
            //@Numerocaja	INT
            //@Tipo VARCHAR(50)

//            SELECT     ADN_Lista_surtimiento_cajas.ID,
// ADN_Lista_surtimiento_cajas.InvcNbr, 
//ADN_Lista_surtimiento_cajas.Numerocaja, 
//ADN_Lista_surtimiento_cajas.Status, 
//ADN_Picking_cajas.Tipo

            SqlCommand cmd = new SqlCommand();
            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            DataRow dr;
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Datos_caja_picking";
            cmd.Parameters.AddWithValue("@InvcNbr", invcnbr.Trim());
            cmd.Parameters.AddWithValue("@Numerocaja", numcaja.Trim());
            //cmd.Parameters.AddWithValue("@Tipo", tipo);
            da.SelectCommand = cmd;
            try
            {
                da.Fill(dt);
                if (dt.Tables[0].Rows.Count != 0)
                {
                    dr = dt.Tables[0].Rows[0];
                    if (Convert.ToBoolean(dr["Status"].ToString()) == false)
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("La caja ya ha sido liberada,seleccionar otra caja", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        return false;


                    }

                }
                else
                {
                    MessageBox.Show("Error..La caja no ha sido asignada a esta orden");
                    return false;
                }

            }
            catch
            {
                MessageBox.Show("Error al verificar caja..");
                return false;
            }
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            if (txtcaja.BackColor != Color.Yellow)
            {
                txtcaja.BackColor = Color.Yellow;
            }
            else
            {
                txtcaja.BackColor = Color.White;
            }

        }

        private void frm_sel_caja_Closing(object sender, CancelEventArgs e)
        {
            //timer1.Enabled = false;  
        }

        private void txtcaja_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtcaja.Text != "")
            {
              
                if (verifica_caja(invcnbr, txtcaja.Text.Trim().ToUpper()))
                {
                    caja = txtcaja.Text.Trim();   
                    timer1.Enabled = false; 
                    this.Close();
                }
                else
                {
                    caja = "";
                    txtcaja.Text = "";
                    txtcaja.Focus(); 
                }
            }
            else
            {
                txtcaja.Focus(); 
            }
        }
    }
}