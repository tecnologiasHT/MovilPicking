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
    public partial class frm_liberar_cajas : Form
    {
        public frm_liberar_cajas()
        {
            InitializeComponent();
        }

        string status = "";
        bool Obtener_datos_caja(string caja)
        {
            // ADN_Obtener_caja_factura    
            //@Numerocaja int
            SqlCommand cmd = new SqlCommand();
            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            DataRow dr;
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Obtener_caja_factura";
            //cmd.Parameters.AddWithValue("@InvcNbr", invcnbr);
            cmd.Parameters.AddWithValue("@Numerocaja", caja);
            da.SelectCommand = cmd;
            try
            {
                da.Fill(dt);
                if (dt != null)
                {
                    if (dt.Tables.Count > 0)
                    {
                        if (dt.Tables[0].Rows.Count > 0)
                        {
                            dr = dt.Tables[0].Rows[0];
                            if (!string.IsNullOrEmpty(dr["InvcNbr"].ToString()))
                            {
                                txt_factura.Text = dr["InvcNbr"].ToString().Trim();

                                if (!string.IsNullOrEmpty(dr["Status"].ToString()))
                                {
                                    status = dr["Status"].ToString().Trim();
                                }
                                else
                                {
                                    status = "";
                                }

                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        bool actualizar_status_caja(string invcnbr,string caja, bool status)
        {
            //ADN_cajas_surtimiento_actualizar_status
            //@InvcNbr VARCHAR(20), 
            //@Numerocaja INT, 
            //@Status BIT        
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_cajas_surtimiento_actualizar_status";
            cmd.Parameters.AddWithValue("@InvcNbr", invcnbr);
            cmd.Parameters.AddWithValue("@Numerocaja", caja);
            cmd.Parameters.AddWithValue("@Status", status);

            try
            {
                if (Global.cn.State == ConnectionState.Closed)
                {
                    Global.cn.Open();
                }

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error A Liberar Caja..");
                return false;
            }

        }


        private void txtcaja_GotFocus(object sender, EventArgs e)
        {
            txtcaja.BackColor = Color.Yellow;
   
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtcaja_LostFocus(object sender, EventArgs e)
        {
            txtcaja.BackColor = Color.White;   
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            if (txt_factura.Text.Trim() == Global.invcnbr)
            {
                if ((Global.tot_cajas_factura(Global.invcnbr) == 1) && status == "SO")
                {
                    MessageBox.Show("La Caja Seleccionada No Se Puede Liberar, Debe Haber Al Menos Una Caja", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            

            if (txt_factura.Text.Trim() != "" && txtcaja.Text != "")
            {

                if (status == "SO")
                {
                    if (Global.tot_cajas_factura(txt_factura.Text.Trim()) == 1)
                    {
                        MessageBox.Show("La Caja Seleccionada No Se Puede Liberar, Debe Haber Al Menos Una Caja Asiganada A La Factura..", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        return;
                    }

                }

                string res = MessageBox.Show("Desea liberar la caja seleccionada..?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2).ToString();
                if (res == "Yes")
                {
                    if (actualizar_status_caja(txt_factura.Text.Trim(),txtcaja.Text.Trim(), true))
                    {
                        this.Close();
                    }
                }


            }


        }

        private void txtcaja_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtcaja.Text !="" )
            {
                if (Obtener_datos_caja(txtcaja.Text.Trim().ToUpper()))
                {
                    txtcaja.ReadOnly = true; 
                    btn_aceptar.Enabled = true;
                    btn_aceptar.Focus();
                    
                }
                else
                {
                    MessageBox.Show("La Caja No Esta Asignada..");
                    txtcaja.Focus();
                    txtcaja.SelectAll(); 
                }
    
            }
        }

        
    }
}