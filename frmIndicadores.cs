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
    public partial class frmIndicadores : Form
    {
        public frmIndicadores()
        {
            InitializeComponent();
        }
        public static SqlConnection cn = new SqlConnection(Properties.Resources.connectionstring);

        int total = 0;
        void totales_porsurtir()
        {
            SqlCommand cmd = new SqlCommand();
            //cmd.Connection = cn;
            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            DataRow dr;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_totales_por_surtir";
            //if (cn.ConnectionString == "")
            //{
            //    cn.ConnectionString = Properties.Settings.Default.cnBD;
            //}
            cmd.Connection = cn;

            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
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
                            //totps_hoy,  totps_manana, totp1_manana, 
                            //@totp2_hoy AS totp2_hoy,@totp2_manana AS totp2_manana,
                            //@totmix_hoy AS totmix_hoy,@totmix_manana AS totmix_manana

                            if (!string.IsNullOrEmpty(dr["totps_hoy"].ToString()))
                            {
                                lblPorSurtir.Text   = dr["totps_hoy"].ToString();
                            }
                            else
                            {
                                lblPorSurtir.Text = "0";
                            }

                            if (!string.IsNullOrEmpty(dr["totps_manana"].ToString()))
                            {
                                lbl_ps_manana.Text  = dr["totps_manana"].ToString();

                            }
                            else
                            {
                                lbl_ps_manana.Text = "0";
                            }


                            //if (!string.IsNullOrEmpty(dr["totp1_hoy"].ToString()))
                            //{
                            //    string cad = dr["totp1_hoy"].ToString();
                               
                            //}
                            

                            //if (!string.IsNullOrEmpty(dr["totp1_manana"].ToString()))
                            //{
                            //    string cad = dr["totp1_manana"].ToString();                               

                            //}

                            //if (!string.IsNullOrEmpty(dr["totp2_hoy"].ToString()))
                            //{
                            //    string cad = dr["totp2_hoy"].ToString();                              

                            //}

                            //if (!string.IsNullOrEmpty(dr["totp2_manana"].ToString()))
                            //{
                            //    string cad = dr["totp2_manana"].ToString();

                            //}


                            //if (!string.IsNullOrEmpty(dr["totmix_hoy"].ToString()))
                            //{
                            //    string cad = dr["totmix_hoy"].ToString();
                              
                            //}


                            //if (!string.IsNullOrEmpty(dr["totmix_manana"].ToString()))
                            //{
                            //    string cad = dr["totmix_manana"].ToString();
                              
                            //}

                        }
                        else
                        {
                            //lbl_por_surtir_hoy.Text = "0";
                            //lbl_por_surtir_hoy.Text = "0";

                        }
                    }
                    else
                    {
                    //    lbl_por_surtir_hoy.Text = "0";
                    //    lbl_por_surtir_hoy.Text = "0";
                    }
                }
                else
                {
                    //lbl_por_surtir_hoy.Text = "0";
                    //lbl_por_surtir_hoy.Text = "0";
                }
            }
            catch (Exception)
            {

            }


        }

        void totales_surtimiento()
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            DataRow dr;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_totales_surtimiento";
           
            cmd.Connection = cn;

            if (cn.State == ConnectionState.Closed)
            {
                cn.Open();
            }
            da.SelectCommand = cmd;

            //@tot_so_hoy AS totps_hoy, 
            //@tot_so_manana  AS totps_manana,
            //@tot_so_p1_hoy AS totp1_hoy,
            //@tot_so_p1_manana AS totp1_manana, 
            //@tot_so_p2_hoy  AS totp2_hoy,
            //@tot_so_p2_manana AS totp2_manana,
            //@tot_so_mix_hoy AS totmix_hoy,
            //@tot_so_mix_manana AS totmix_manana

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
                            //@totps AS totps,@totp1 AS totp1,@totp2 AS totp2,@totmix AS totp2
                            if (!string.IsNullOrEmpty(dr["totso_hoy"].ToString()))
                            {
                                lblSurtiendo.Text   = dr["totso_hoy"].ToString();
                            }
                            else
                            {
                                lblSurtiendo.Text = "0";
                            }

                            if (!string.IsNullOrEmpty(dr["totso_manana"].ToString()))
                            {
                                lbl_so_manana.Text  = dr["totso_manana"].ToString();
                            }
                            else
                            {
                                lbl_so_manana.Text = "0";
                            }

                            //GraficaS 
                            //@tot_so_p1_hoy AS totp1_hoy,
                            //@tot_so_p1_manana AS totp1_manana, 
                            //@tot_so_p2_hoy  AS totp2_hoy,
                            //@tot_so_p2_manana AS totp2_manana,
                            //@tot_so_mix_hoy AS totmix_hoy,
                            //@tot_so_mix_manana AS totmix_manana
                            //                           , 
                            //@tot_so_manana  AS totso_manana,


                            //if (!string.IsNullOrEmpty(dr["totp1_hoy"].ToString()))
                            //{
                            //    string cad = dr["totp1_hoy"].ToString();
                               
                            //}

                            //if (!string.IsNullOrEmpty(dr["totp1_manana"].ToString()))
                            //{
                            //    string cad = dr["totp1_manana"].ToString();
                               
                            //}
                            
                            //if (!string.IsNullOrEmpty(dr["totp2_hoy"].ToString()))
                            //{
                            //    string cad = dr["totp2_hoy"].ToString();                               

                            //}

                            //if (!string.IsNullOrEmpty(dr["totp2_manana"].ToString()))
                            //{
                            //    string cad = dr["totp2_manana"].ToString();                               

                            //}


                            //if (!string.IsNullOrEmpty(dr["totmix_hoy"].ToString()))
                            //{
                            //    string cad = dr["totmix_hoy"].ToString();
                             
                            //}


                            //if (!string.IsNullOrEmpty(dr["totmix_manana"].ToString()))
                            //{
                            //    string cad = dr["totmix_manana"].ToString();
                                
                            //}

                        }
                        else
                        {
                            //lbl_por_surtir_hoy.Text = "0";
                        }
                    }
                    else
                    {
                        //lbl_por_surtir_hoy.Text = "0";
                    }
                }
                else
                {
                    //lbl_por_surtir_hoy.Text = "0";
                }
            }
            catch (Exception)
            {

            }


        }

        void Totales()
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            DataSet dt = new DataSet();
            DataRow dr;
            //if (cn.ConnectionString == "")
            //{
            //    cn.ConnectionString = Properties.Settings.Default.cnBD;
            //}
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_TotalObjetivos";
            da.SelectCommand = cmd;
            try
            {
                da.Fill(dt);

                if (dt.Tables[0].Rows.Count != 0)
                {
                    dr = dt.Tables[0].Rows[0];

                    //total surtidas
                    if (dr["tot_por_procesar_hoy"].ToString() != null)
                    {
                        //string cad = dr["tot_por_procesar_hoy"].ToString();
                        lblObjetivo.Text = dr["tot_por_procesar_hoy"].ToString();
                    }
                    else
                    {
                        lblObjetivo.Text = "0";
                    }

                    if (dr["tot_procesadas_hoy"].ToString() != null)
                    {
                        //string cad = dr["tot_procesadas_hoy"].ToString();
                        lblAvance.Text = dr["tot_procesadas_hoy"].ToString();
                        total = int.Parse(dr["tot_procesadas_hoy"].ToString()); 
                    }
                    else
                    {
                        lblAvance.Text = "0";
                        total=0;
                    }

                    //if (dr["tot_por_embarcar_hoy"].ToString() != null)
                    //{
                      
                    //}
                    //else
                    //{
                        

                    //}

                    //if (dr["tot_embarcadas_hoy"].ToString() != null)
                    //{
                       
                    //}
                    //else
                    //{
                        
                    //}
                    

                    //gauge_por_procesar_manana                                       
                    if (dr["tot_por_procesar_manana"].ToString() != null)
                    {
                        //gauge_sa.Text = dr[5].ToString();
                        //lbl_por_procesar_manana.Text = dr["tot_por_procesar_manana"].ToString();
                    }
                    else
                    {
                       // lbl_por_procesar_manana.Text = "0";
                    }

                    //gauge_procesadas_manana

                    if (dr["tot_facturas_extra"].ToString() != null)
                    {
                        //string cad = dr["tot_facturas_extra"].ToString();
                        lblExtra.Text = dr["tot_facturas_extra"].ToString();
                        total=total + int.Parse(dr["tot_facturas_extra"].ToString());  
                    }
                    else
                    {
                        lblExtra.Text = "0";
                    }

                    if (dr["tot_procesadas_manana"].ToString() != null)
                    {
                       
                        //lbl_procesadas_manana.Text = dr["tot_procesadas_manana"].ToString();


                    }
                    else
                    {
                       // lbl_procesadas_manana.Text = "0";
                       
                    }



                    //por validar hoy


                    if (dr["tot_por_validar_hoy"].ToString() != null)
                    {

                        //lbl_por_validar_hoy.Text = dr["tot_por_validar_hoy"].ToString();
                        lblPorValidar.Text = dr["tot_por_validar_hoy"].ToString(); 
                    }
                    else
                    {
                        lblPorValidar.Text = "0";
                    }

                    //por validar mañana

                    if (dr["tot_por_validar_manana"].ToString() != null)
                    {

                        //lbl_por_validar_manana.Text = dr["tot_por_validar_manana"].ToString();
                    }
                    else
                    {
                        //lbl_por_validar_manana.Text = "0";
                    }
                    //linearGauge1.Scales[0].Value

                    //tot_validadando_hoy
                    if (dr["tot_validadando_hoy"].ToString() != null)
                    {
                        lblValidando.Text  = dr["tot_validadando_hoy"].ToString();
                    }
                    else
                    {

                        lblValidando.Text = "0";
                    }

                    //tot_validadando_manana
                    if (dr["tot_validadando_manana"].ToString() != null)
                    {
                        
                    }
                    else
                    {
                        
                    }



                    //tot_sin_embarcar_ayer
                    if (dr["tot_sin_embarcar_ayer"].ToString() != null)
                    {

                        //lbl_etiquetadas_atrasadas.Text = dr["tot_sin_embarcar_ayer"].ToString();
                    }
                    else
                    {
                        //lbl_etiquetadas_atrasadas.Text = "0";
                    }


                    lblTotal.Text = total.ToString();    

                }
            }
            catch (Exception)
            {
                //MessageBox.Show("Error.." + ex.Message.ToString());
            }
           
        }


        void ReporteProceso()
        {
            try
            {
               //Cursor = Cursors.WaitCursor; 
               
                DataSet dt = new DataSet();
                dt = Global.ReporteProcesossurtiemientoZonas();

                dataGrid1.DataSource = dt.Tables[0];
            }
            catch
            { 
              
            }
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;  
            this.Close(); 
        }

        private void frmIndicadores_Load(object sender, EventArgs e)
        {
            totales_porsurtir();
            totales_surtimiento();
            Totales();
            timer1.Enabled = true;  
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            totales_porsurtir();
            totales_surtimiento();
            Totales(); 
        }

        private void frmIndicadores_Closing(object sender, CancelEventArgs e)
        {
            timer1.Enabled = false;  
        }

        private void tab1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tab1.SelectedIndex == 0)
            {
                totales_porsurtir();
                totales_surtimiento();
                Totales();
                timer1.Enabled = true;  
            }
            else if (tab1.SelectedIndex == 1)
            {
                timer1.Enabled = false;  
                //ReporteProceso();
            }
            else if (tab1.SelectedIndex == 2)
            {
                timer1.Enabled = false;
                this.Close(); 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReporteProceso();
        }
    }
}