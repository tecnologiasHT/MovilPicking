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
    public partial class frm_surtir_articulo_multiple : Form
    {
        public frm_surtir_articulo_multiple()
        {
            InitializeComponent();
        }

        bool obtener_datos_articulo()
        {
            //SELECT ID_Surt_Art, InvcNbr, InvtId, Descr, Unidad, Localizacion, CantSol, CantSurtida, Usuario, Completo, Nodisp, Pickstatus, IdZona, IdArea, Status_surt
            //FROM   ADN_Lista_Surtimiento_Maestro
            StringBuilder cad = new StringBuilder();
            cad.Append("SELECT ID_Surt_Art, InvcNbr, InvtId, Descr, Unidad, Localizacion, CantSol, CantSurtida, Usuario, Completo, Nodisp, Pickstatus, IdZona, IdArea, Status_surt");
            cad.AppendLine(" FROM   ADN_Lista_Surtimiento_Maestro");
            cad.AppendLine(" WHERE ID_Surt_Art=@ID_Surt_Art");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            DataRow dr;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = cad.ToString();
            cmd.Connection = Global.cn;
            //cmd.Parameters.AddWithValue("@ID_Surt_Art", ID_Surt_Art);

            da.SelectCommand = cmd;

            try
            {
                da.Fill(dt);
                if (dt != null)
                {
                    if (dt.Tables.Count != 0)
                    {
                        if (dt.Tables[0].Rows.Count != 0)
                        {
                            dr = dt.Tables[0].Rows[0];
                            //SELECT ID_Surt_Art, InvcNbr, InvtId, Descr, Unidad, Localizacion, CantSol, CantSurtida, Usuario, Completo, Nodisp, Pickstatus, IdZona, IdArea, Status_surt
                            ////FROM   ADN_Lista_Surtimiento_Maestro

                            if (!string.IsNullOrEmpty(dr["Status_surt"].ToString()))
                            {
                                if (dr["Status_surt"].ToString() == "E")
                                {
                                    t1.Enabled = false;
                                   
                                    this.Close();
                                }
                                else
                                {
                                    //status = dr["Status_surt"].ToString().Trim();
                                }
                            }

                            if (!string.IsNullOrEmpty(dr["Descr"].ToString()))
                            {
                                txt_desc.Text = dr["Descr"].ToString();
                            }
                            if (!string.IsNullOrEmpty(dr["Localizacion"].ToString()))
                            {
                                lbl_loc_surt.Text = dr["Localizacion"].ToString();
                            }
                            if (!string.IsNullOrEmpty(dr["Unidad"].ToString()))
                            {
                                lbl_unidad.Text = dr["Unidad"].ToString();
                            }


                            if (!string.IsNullOrEmpty(dr["CantSol"].ToString()))
                            {
                                //cantsol = Convert.ToDecimal(dr["CantSol"].ToString());
                            }
                            else
                            {
                                //cantsol = 0;
                                //MessageBox.Show("Articulo Completado..", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                                this.Close();
                            }

                            if (!string.IsNullOrEmpty(dr["CantSurtida"].ToString()))
                            {
                                //tot_surtir = (cantsol - Convert.ToDecimal(dr["CantSurtida"].ToString()));
                                //lblsurtido.Text = dr["CantSurtida"].ToString().Trim();
                                //if (tot_surtir > 0)
                                //{
                                //    lbl_surtir_loc.Text = tot_surtir.ToString().Trim();
                                //}
                                //else
                                //{
                                //    MessageBox.Show("Articulo Completado..", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                                //    //lbl_surtir_loc.Text = "0";
                                //    //tab_captura.Enabled = false;  
                                //    this.Close();

                                //}

                            }
                            else
                            {
                                lblsurtido.Text = "0";
                                if (!string.IsNullOrEmpty(dr["CantSol"].ToString()))
                                {
                                //    tot_surtir = Convert.ToDecimal(dr["CantSol"].ToString());
                                //    cantsol = Convert.ToDecimal(dr["CantSol"].ToString());
                                //    lbl_surtir_loc.Text = tot_surtir.ToString().Trim();
                                }
                                else
                                {
                                    tab_captura.Enabled = false;
                                    txtmsj.Text = "Error Cantidad Solicitada No Valida..";
                                }
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
            catch
            {
                return false;
            }


        }


        private void btn_excepcion_Click(object sender, EventArgs e)
        {

        }

        private void btn_salir_Click(object sender, EventArgs e)
        {

        }

        private void txt_cant_art_GotFocus(object sender, EventArgs e)
        {

        }

        private void txt_cant_art_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txt_cant_art_LostFocus(object sender, EventArgs e)
        {

        }

        private void t1_Tick(object sender, EventArgs e)
        {

        }

        private void txt_cant_codigo_GotFocus(object sender, EventArgs e)
        {

        }

        private void txt_cant_codigo_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txt_cant_codigo_LostFocus(object sender, EventArgs e)
        {

        }

        private void txt_codigo_GotFocus(object sender, EventArgs e)
        {

        }

        private void txt_codigo_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txt_codigo_LostFocus(object sender, EventArgs e)
        {

        }

        private void txt_cve_art_GotFocus(object sender, EventArgs e)
        {

        }

        private void txt_cve_art_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txt_cve_art_LostFocus(object sender, EventArgs e)
        {

        }

        private void tab_captura_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void btn_salir_Click_1(object sender, EventArgs e)
        {
            string res = MessageBox.Show("Desea Salir ?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1).ToString();
            if (res == "Yes")
            {
                t1.Enabled = false;
                this.Close();
            }
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {

        }
    }
}