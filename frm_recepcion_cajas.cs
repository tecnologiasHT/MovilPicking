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
    public partial class frm_recepcion_cajas : Form
    {
        public frm_recepcion_cajas()
        {
            InitializeComponent();
        }

        int tot_rec = 0;
        int tot_Cajas = 0;
        int tot_ps_zona = 0;
        int tot_ps_area = 0;
        string status_zona_factura;
        public string invcnbr="";
        public string carrito = "";
        public int idzona1 = 0;
        //string obtener_factura_pend(int idzona)
        //{ 
        //  //obtiene el numero de la factura de las cajas pendientes de recepcion
        // // ADN_Obtener_factura_cajas_pend_rec	
        // //@Id_Zona INT
        //   SqlCommand cmd = new SqlCommand();
        //    //SqlDataAdapter da = new SqlDataAdapter();
        //    cmd.Connection = Global.cn;
        //    //DataSet dt = new DataSet();
        //    //DataRow dr;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = "ADN_Obtener_factura_cajas_pend_rec";
        //    cmd.Parameters.AddWithValue("@IdZona", idzona);

        //    try
        //    {
        //        if (Global.cn.State == ConnectionState.Closed)
        //        {
        //            Global.cn.Open();                
        //        }
        //        return cmd.ExecuteScalar().ToString().Trim();  
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al obtener factura.." + ex.Message.ToString());
        //        return "";
        //    }

        //}
        int tot_art_ps_picking2(string factura)
        {
            //ADN_Obtener_tot_art_ps_picking2             
            //@InvcNbr VARCHAR(20)
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Obtener_tot_art_ps_picking2";
            cmd.Parameters.AddWithValue("@InvcNbr", factura);
            try
            {
                if (Global.cn.State == ConnectionState.Closed)
                {
                    Global.cn.Open();
                }
                return Convert.ToInt16(cmd.ExecuteScalar().ToString());
            }
            catch
            {
                MessageBox.Show("Error al obtener total de articulos por surtir en picking2..");
                return -1;
            }




        }


        bool actualizar_zona_picking2(string factura,string usuario,string carritono, int idzona)
        { 

            StringBuilder cad = new StringBuilder();
            cad.Append("UPDATE ADN_surtimiento_zona SET ");
            cad.AppendLine("Usuario=@Usuario , CarritoNo=@CarritoNo ");
            cad.AppendLine("Where InvcNbr=@InvcNbr and IdZona=@IdZona and Activo=1");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = cad.ToString();
            cmd.Parameters.AddWithValue("@InvcNbr", factura);
            cmd.Parameters.AddWithValue("@Usuario",usuario );
            cmd.Parameters.AddWithValue("@CarritoNo",carritono);
            cmd.Parameters.AddWithValue("@IdZona", idzona);
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
                MessageBox.Show("Error al actualizar zona Surtimiento"); 
                return false;
            }


        
        }

        bool agregar_caja(string caja, int op)
        {
            //Agrega el numero de Caja o Carrito
            //ADN_surtimiento_cajas_OP           
            //@InvcNbr VARCHAR(20),
            //@Numcaja INT,	
            //@OP INT,	
            //@Res BIT OUTPUT	

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_surtimiento_cajas_OP";
            cmd.Parameters.AddWithValue("@InvcNbr", invcnbr.Trim());
            cmd.Parameters.AddWithValue("@Numcaja", caja);
            cmd.Parameters.AddWithValue("@OP", 1);
            cmd.Parameters.Add("@Res", SqlDbType.Bit, 1);
            cmd.Parameters["@Res"].Direction = ParameterDirection.Output;
            try
            {
                if (Global.cn.State == ConnectionState.Closed)
                {
                    Global.cn.Open();
                }
                cmd.ExecuteNonQuery();

                if (!string.IsNullOrEmpty(cmd.Parameters["@Res"].ToString()))
                {
                    string s = cmd.Parameters["@Res"].Value.ToString();
                    if (Convert.ToBoolean(cmd.Parameters["@Res"].Value.ToString()) == true)
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error al Agregar Caja");
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
                MessageBox.Show("Error al agregar caja", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return false;
            }

        }


        bool actualiza_status_zona(string invcnbr, int idzona, string status)
        {
            //ADN_Actualizar_status_zona	
            //@InvcNbr VARCHAR(10),
            //@IdZona INT,
            //@Status VARCHAR(20)
            SqlCommand cmd = new SqlCommand();
            //SqlDataAdapter da = new SqlDataAdapter();
            cmd.Connection = Global.cn;
            //DataSet dt = new DataSet();
            //DataRow dr;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Actualizar_status_zona";
            cmd.Parameters.AddWithValue("@InvcNbr", invcnbr);
            cmd.Parameters.AddWithValue("@IdZona", idzona);
            cmd.Parameters.AddWithValue("@Status", status);
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario);

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
                MessageBox.Show("Error al actualizar status de factura.." + ex.Message.ToString());
                return false;
            }
            
        }


        bool agregar_status_zona(string invcnbr, int idzona, string status)
        {
            //ADN_agregar_status_zonas	
            //@InvcNbr VARCHAR(10),
            //@IdZona INT,
            //@Status varchar(20)
            SqlCommand cmd = new SqlCommand();
            //SqlDataAdapter da = new SqlDataAdapter();
            cmd.Connection = Global.cn;
            //DataSet dt = new DataSet();
            //DataRow dr;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_agregar_status_zonas";
            cmd.Parameters.AddWithValue("@InvcNbr", invcnbr);
            cmd.Parameters.AddWithValue("@IdZona", idzona);
            cmd.Parameters.AddWithValue("@Status", status);
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario  );
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
                MessageBox.Show("Error al agregar status de factura.." + ex.Message.ToString());
                return false;
            }


        }

        bool verificar_zona_transito()
        {
            //ADN_verificar_zona_transito	
            //@InvcNbr VARCHAR(10),
            //@IdZona int
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.Connection = Global.cn;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_verificar_zona_transito";
            cmd.Parameters.AddWithValue("@IdZona", Global.idzona);

            try
            {
                if (Global.cn.State == ConnectionState.Closed)
                {
                    Global.cn.Open();
                }
                return Convert.ToBoolean(cmd.ExecuteScalar().ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar Zona en transito..." + ex.Message.ToString());
                return false;
            }


        }


        bool obtener_factura()
        {
            // ADN_obtener_orden_surtimiento
            //@InvcNbr VARCHAR(15) OUTPut
            //@Surtidor VARCHAR(50),
            //@Tot INT OUTPUT --facturas pendientes de surtir 
            //timer1.Enabled = false;
            //invcnbr = "";
            //lbl_msj.Text = "Obteniendo Nueva Factura....";
            SqlCommand cmd = new SqlCommand();
            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            DataRow dr;

            //Cursor.Current = Cursors.WaitCursor;   
            //SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_obtener_factura_area";
            cmd.Connection = Global.cn;
            cmd.Parameters.AddWithValue("@IdArea", Global.area);
            cmd.Parameters.AddWithValue("@IdZona", Global.idzona);
            da.SelectCommand = cmd;
            try
            {
                //dg_ordenes.DataBindings.Clear();   
                da.Fill(dt);
                if (dt.Tables.Count != 0)
                {
                    if (dt.Tables[0].Rows.Count != 0)
                    {
                        dr = dt.Tables[0].Rows[0];
                        if (!string.IsNullOrEmpty(dr["InvcNbr"].ToString()))
                        {
                            //txt_factura.Text = dr["InvcNbr"].ToString().Trim();
                            //btn_factura.Tag = dr["InvcNbr"].ToString().Trim();
                            lbl_factura.Text   = dr["InvcNbr"].ToString().Trim();
                            invcnbr = dr["InvcNbr"].ToString().Trim();
                            //datos_factura();
                            //if (!string.IsNullOrEmpty(dr["Prioridad"].ToString().Trim()))
                            //{
                            //    prioridad_surt = Convert.ToInt16(dr["Prioridad"].ToString().Trim());
                            //    txt_prioridad.Text = dr["Prioridad"].ToString().Trim();
                            //}
                            //else
                            //{
                            //    txt_prioridad.Text = "";
                            //    prioridad_surt = 0;
                            //}

                            //if (!string.IsNullOrEmpty(dr["Shipperid"].ToString().Trim()))
                            //{
                            //    lbl_shiperid.Text = dr["Shipperid"].ToString().Trim();
                            //}

                            //if (!string.IsNullOrEmpty(dr["Partidas"].ToString().Trim()))
                            //{
                            //    txt_partidas.Text = dr["Partidas"].ToString().Trim();
                            //}
                            //else
                            //{
                            //    txt_partidas.Text = "0";
                            //}

                            //if (!string.IsNullOrEmpty(dr["env_junto"].ToString().Trim()))
                            //{
                            //    env_junto = Convert.ToBoolean(dr["env_junto"].ToString().Trim());
                            //}
                            //else
                            //{
                            //    env_junto = false;
                            //}

                            //Status_area
                            if (!string.IsNullOrEmpty(dr["Status_area"].ToString().Trim()))
                            {
                                status_zona_factura = dr["Status_area"].ToString().Trim();
                            }
                            else
                            {
                                status_zona_factura = "";
                            }
                            //btn_ver.Enabled = false;
                            //lbl_msj.Visible = false;
                            return true;
                        }
                        else
                        {
                            lbl_msj.Text = "Espere..Obteniendo factura para surtir";
                            lbl_msj.Visible = true;
                            //timer1.Enabled = true; 
                            return false;

                        }

                    }
                    else
                    {
                        string fact = "";
                        int tot = 0;
                        string s;
                        obtener_factura_transito(Global.idzona, out fact, out tot, out s);
                        if (fact != "")
                        {
                            //txt_factura.Text = fact.Trim();
                            invcnbr = fact.Trim();
                            //datos_factura(invcnbr);
                            return true;
                        }
                        else
                        {
                            //timer1.Enabled = true;
                            lbl_msj.Text = "Espere..Obteniendo factura para surtir";
                            lbl_msj.Visible = true;
                            return false;
                        }
                    }
                }
                else
                {
                    //timer1.Enabled = true;
                    lbl_msj.Text = "Espere..Obteniendo factura para surtir";
                    lbl_msj.Visible = true;
                    return false;
                }
            }
            catch (Exception ex)
            {
                dt.Dispose();
                da.Dispose();
                //btn_obtener.Enabled = true;  
                Cursor.Current = Cursors.Default;
                cmd.Dispose();
                lbl_msj.Visible = true;
                lbl_msj.Text = "Error al obtener Factura.";
                return false;
            }
            //Cursor.Current = Cursors.Default;

        }

        int total_articulos_status(string factura, string status)
        {
            //Obtiene el total de articulos de la factura , segun el status proporcionado
            //ADN_obtener_tot_arts_status
            //@InvcNbr VARCHAR(20),
            //@Status VARCHAR(10)
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_obtener_tot_arts_status";
            cmd.Parameters.AddWithValue("@InvcNbr", factura.Trim());
            cmd.Parameters.AddWithValue("@Status", status);
            //SqlDataAdapter da = new SqlDataAdapter();
            //DataSet dt = new DataSet();

            try
            {
                if (Global.cn.State == ConnectionState.Closed)
                {
                    Global.cn.Open();
                }
                int i = Convert.ToInt16(cmd.ExecuteScalar().ToString());

                return i;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener total de articulos");
                return -1;
            }


        }


        void obtener_factura_transito(int id_zona, out string invcnbr, out int tot_cajas, out string status)
        {
            //obtiene la factura que este en transito en la zona especificada
            //ADN_obtener_factura_transito
            //@IdZona int
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.Connection = Global.cn;
            DataSet dt = new DataSet();
            DataRow dr;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_obtener_factura_transito";
            cmd.Parameters.AddWithValue("@IdZona", id_zona);
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
                            invcnbr = dr["InvcNbr"].ToString().Trim();
                            if (!string.IsNullOrEmpty(dr["Status"].ToString().Trim()))
                            {
                                status = dr["Status"].ToString().Trim();
                            }
                            else
                            {
                                status = "";
                            }

                            if (!string.IsNullOrEmpty(dr["Tot_cajas"].ToString().Trim()))
                            {
                                tot_cajas = Convert.ToInt16(dr["Tot_cajas"].ToString());
                            }
                            else
                            {
                                tot_cajas = 0;
                            }
                            da.Dispose();
                            dt.Dispose();
                            cmd.Dispose();

                        }
                        else
                        {
                            invcnbr = "";
                            tot_cajas = 0;
                            status = "";
                        }

                    }
                    else
                    {
                        invcnbr = "";
                        tot_cajas = 0;
                        status = "";
                    }
                }
                else
                {
                    invcnbr = "";
                    tot_cajas = 0;
                    status = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener factura en transito.." + ex.Message.ToString());
                invcnbr = "";
                tot_cajas = 0;
                status = "";
                da.Dispose();
                dt.Dispose();
                cmd.Dispose();
            }


        }    


        int Tot_articulos_status_zona(string factura, int idzona, string status)
        {
            //ADN_obtener_tot_articulos_status_zona	
            //@InvcNbr VARCHAR(10),
            //@IdZona  INT,
            //@Status varchar(10)
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.Connection = Global.cn;
            //DataSet dt = new DataSet();
            //DataRow dr;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_obtener_tot_articulos_status_zona";
            cmd.Parameters.AddWithValue("@IdZona", idzona);
            cmd.Parameters.AddWithValue("@InvcNbr", factura);
            cmd.Parameters.AddWithValue("@Status", status);
            //da.SelectCommand = cmd;
            try
            {
                if (Global.cn.State == ConnectionState.Closed)
                {
                    Global.cn.Open();
                }

                return Convert.ToInt16(cmd.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener total de articulos con status: " + status + " " + ex.Message.ToString());
                return -1;
            }

        }

        void  totales_ps_zona(string factura)
        {
            //ADN_total_arts_surtir_area_zona
            //@InvcNbr VARCHAR(20),
            //@Area varchar(50),
            //@Zona varchar(50),
            //@Status varchar(50)
            if (lbl_factura.Text == "")
            {
                return ;
            }
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            DataRow dr;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_total_arts_surtir_area_zona";
            cmd.Parameters.AddWithValue("@IdArea", Global.area);
            cmd.Parameters.AddWithValue("@IdZona", Global.idzona);
            cmd.Parameters.AddWithValue("@Status", "PS");
            cmd.Parameters.AddWithValue("@InvcNbr", factura.Trim());
            da.SelectCommand = cmd;
            try
            {
                da.Fill(dt);
                if (dt.Tables[0].Rows.Count != 0)
                {
                    dr = dt.Tables[0].Rows[0];
                    if (!string.IsNullOrEmpty(dr["tot_area"].ToString()))
                    {
                        tot_ps_area = Convert.ToInt16(dr["tot_area"].ToString());

                    }
                    else
                    {
                        tot_ps_area = 0;
                    }

                    if (!string.IsNullOrEmpty(dr["tot_zona"].ToString()))
                    {
                        tot_ps_zona= Convert.ToInt16(dr["tot_zona"].ToString());

                    }
                    else
                    {
                        tot_ps_zona = 0;
                    }

                }
                else
                {
                    tot_ps_area = 0;
                    tot_ps_zona = 0;
                    
                }


            }
            catch
            {
                MessageBox.Show("Error al obtener totales por susrtir");
                tot_ps_area = 0;
                tot_ps_zona = 0;
            }


        }




        int total_cajas_factura(string factura)
        {
            //[dbo].[ADN_obtener_tot_cajas_factura] 
           //@InvcNbr varchar(20)	
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            //SqlDataAdapter da = new SqlDataAdapter();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_obtener_tot_cajas_factura";
            cmd.Parameters.AddWithValue("@InvcNbr", factura);
            
            try
            {
                if (Global.cn.State == ConnectionState.Closed)
                {
                    Global.cn.Open();
                }
                tot_Cajas = Convert.ToInt16(cmd.ExecuteScalar().ToString());

                return Convert.ToInt16(cmd.ExecuteScalar().ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener total de cajas de la factura.." + ex.Message.ToString()  );
                return 0;

            }


        }

       int  total_cajas_rec(string factura,int id_zona)
        { 
            //ADN_Obtener_total_cajas_recibidas_zona
            //@InvcNbr varchar(20),
            //@Id_Zona int
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            //SqlDataAdapter da = new SqlDataAdapter();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Obtener_total_cajas_recibidas_zona";
            cmd.Parameters.AddWithValue("@InvcNbr", factura);            
            cmd.Parameters.AddWithValue("@Id_Zona", id_zona);
            //da.SelectCommand = cmd;
            try
            {
                if (Global.cn.State == ConnectionState.Closed)
                {
                    Global.cn.Open();
                }
                tot_rec = Convert.ToInt16(cmd.ExecuteScalar().ToString());
                return Convert.ToInt16(cmd.ExecuteScalar().ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener total de cajas recibidas"); 
                return 0;

            }
         
        }


        bool recibir_caja(string factura,string caja, int id_zona)
        { 
            //ADN_surtimiento_recibir_caja	
            //@InvcNbr VARCHAR(20),
            //@Caja INT,
            //@Id_Zona INT,
            //@Usuario varchar(50)

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;            
            SqlDataAdapter da = new SqlDataAdapter();           
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_surtimiento_recibir_caja";
            cmd.Parameters.AddWithValue("@InvcNbr", factura);
            cmd.Parameters.AddWithValue("@Caja", caja);
            cmd.Parameters.AddWithValue("@Id_Zona", id_zona);
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario);

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
                MessageBox.Show("Error al actualizar caja.." + ex.Message.ToString());  
                return false;
            }

        }

        bool recibir_caja_picking2(string factura, string caja, int id_zona)
        {
            //ADN_surtimiento_recibir_caja_picking2
            //@InvcNbr VARCHAR(20),
            //@Caja INT,
            //@Id_Zona INT,
            //@Usuario varchar(50),
            //@Carrito int
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_surtimiento_recibir_caja_picking2";
            cmd.Parameters.AddWithValue("@InvcNbr", factura);
            cmd.Parameters.AddWithValue("@Caja", caja);
            cmd.Parameters.AddWithValue("@Id_Zona", id_zona);
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario);
            cmd.Parameters.AddWithValue("@Carrito", carrito);
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
                MessageBox.Show("Error al actualizar caja.." + ex.Message.ToString());
                return false;
            }

        }



       bool datos_caja(string factura,string caja, int id_zona)
        { 
        //[dbo].[ADN_Obtener_datos_cajas_recibidas]	
        //@InvcNbr VARCHAR(20),
        //@Id_Zona INT,
        //@Caja   int


            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            DataRow dr;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Obtener_datos_cajas_recibidas";
            cmd.Parameters.AddWithValue("@Caja", caja);
            cmd.Parameters.AddWithValue("@Id_Zona", id_zona);
            cmd.Parameters.AddWithValue("@InvcNbr", factura);
            da.SelectCommand = cmd;
            //InvcNbr, Caja
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
                            if (!string.IsNullOrEmpty(dr["Rec"].ToString()))
                            {
                                if (Convert.ToBoolean(dr["Rec"].ToString()) == true)
                                {
                                    MessageBox.Show("La Caja Ya Fue Recibida");
                                    return false;
                                }
                                else
                                {
                                    return true;
                                }

                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Datos No Encontrados");
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Datos No Encontrados");
                        return false;
                    }

                }
                else
                {
                    MessageBox.Show("Datos No Encontrados");
                    return false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Datos No Encontrados");
                return false;
            }

        }

        void lista_cajas(string factura, int id_zona)
        { 
            //ADN_Lista_cajas_recibidas_zona	
            //@InvcNbr varchar(20),
            //@Id_Zona INT
           SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            DataRow dr;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Lista_cajas_recibidas_zona";
            cmd.Parameters.AddWithValue("@InvcNbr",factura);
            cmd.Parameters.AddWithValue("@Id_Zona",id_zona);
            da.SelectCommand = cmd;
            try
            {
                
                da.Fill(dt);
                dbg_facturas.DataSource = null;
                if (dt != null)
                {
                    if (dt.Tables.Count != 0)
                    {
                        dbg_facturas.DataSource = dt.Tables[0];
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener cajas...");  
            
            }
        }


        string obtener_factura(int id_zona)
        {
            //Obtienen la factura que se tienen que recibir en la zona
            //se debn de leer todas las cajas
        // ADN_Obtener_factura_zona
        //--@Caja INT,
        //@Id_Zona int
             SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            DataRow dr;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Obtener_factura_zona";
            cmd.Parameters.AddWithValue("@Id_Zona", id_zona);
            da.SelectCommand = cmd; 
            try
            {
                da.Fill(dt);
                if (dt != null)
                {
                    if (dt.Tables.Count != 0)
                    {
                        if (dt.Tables[0].Rows.Count > 0)
                        {
                            dr = dt.Tables[0].Rows[0];
                            if (!string.IsNullOrEmpty(dr[0].ToString()))
                            {
                                return dr[0].ToString();
                            }
                            else
                            {
                                return "";
                            }
                        }
                        else
                        {
                            return "";
                        }
                    }
                    else
                    {
                        return "";
                    }
                }
                else
                {
                    return "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener factura.." + ex.Message.ToString() );  
                return "";
            }

        }

       


        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            if (lbl_factura.Text != "")
            {
                //this.Close();
                lista_cajas(lbl_factura.Text, int.Parse(lbl_id_zona.Text));
                lbl_tot_rec.Text = total_cajas_rec(lbl_factura.Text.Trim(), int.Parse(lbl_id_zona.Text)).ToString();
                lbl_tot_cajas.Text = total_cajas_factura(lbl_factura.Text.Trim()).ToString();
                if (tot_rec == tot_Cajas)
                {
                      Global.actualiza_status_historial(invcnbr);
  
                        timer1.Enabled = false;
                        timer2.Enabled = false;  
                        this.Close();
                    //}
                }
                else
                {
                    if (tot_rec < tot_Cajas)
                    {
                        MessageBox.Show("Todavia tiene cajas pendientes por recibir..","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Exclamation,MessageBoxDefaultButton.Button1   );
                        this.Close();
                    }
                }
                
            }
            else
            {
                this.Close();
            
            }
        }

        private void txt_caja_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txt_caja.Text != "")
            {
                if (datos_caja(lbl_factura.Text.Trim(),txt_caja.Text.Trim(), int.Parse(lbl_id_zona.Text)))
                {
                     timer2.Enabled = true;
                     recibir_caja_picking2(lbl_factura.Text.Trim(), txt_caja.Text.Trim(), Global.idzona);
                     //recibir_caja_picking2(lbl_factura.Text.Trim(), txt_caja.Text.Trim(), Global.idzona);
                     if (Global.picking == 1)
                     {
                         if (recibir_caja(lbl_factura.Text, txt_caja.Text.Trim(), int.Parse(lbl_id_zona.Text)))
                         {
                             txt_caja.Text = "";
                             txt_caja.Focus();
                         }

                     }
                     else if (Global.picking == 2)
                     { 
                          if (recibir_caja_picking2(lbl_factura.Text.Trim(), txt_caja.Text.Trim(),  int.Parse(lbl_id_zona.Text)))
                          {
                            txt_caja.Text = "";
                            txt_caja.Focus();
                          }
                     }
                     
                     //}
                     //if (Global.idzona < 5)
                     //{
                     //    if (recibir_caja(lbl_factura.Text, txt_caja.Text.Trim(), Global.idzona))
                     //    {

                     //        txt_caja.Text = "";
                     //        txt_caja.Focus();


                     //    }
                     //}
                     //else if (Global.idzona >=5 )
                     //{
                     //    if (recibir_caja_picking2(lbl_factura.Text.Trim(), txt_caja.Text.Trim(), Global.idzona))
                     //    {
                     //        txt_caja.Text = "";
                     //        txt_caja.Focus();
                     //    }
                     
                     //}

                      
                }
                else
                {
                    //MessageBox.Show("Numero de Caja No Encontrado");
                    txt_caja.Text = "";
                    txt_caja.Focus(); 
                }


            
            }

        }

       

        private void btn_mover_Click(object sender, EventArgs e)
        {
            if (lbl_factura.Text != "")
            {
                frm_cajas_transito f = new frm_cajas_transito();
                f.lbl_factura.Text = lbl_factura.Text.Trim();
                f.invcnbr = lbl_factura.Text.Trim();
                f.ShowDialog();
 
            }


        }

        private void frm_recepcion_cajas_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    //if (btn_mover.Enabled == true)
                    //{
                    //    btn_mover_Click(this, EventArgs.Empty); 
                    //}
                    break;
                case Keys.F2:
                    //if (btn_terminar.Enabled == true)
                    //{
                    //    btn_terminar_Click(this, EventArgs.Empty);   
                    //}
                    break;
                case Keys.F3:
                    if (btn_cerrar.Enabled == true)
                    {
                        btn_cerrar_Click(this, EventArgs.Empty); 
                    }
                    break;

                case Keys.Enter:
                    txt_caja.Focus(); 
                    break;        

                default:
                    break;
            }

        }

        private void btn_terminar_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (lbl_factura.Text != "")
            {
                lista_cajas(lbl_factura.Text, int.Parse(lbl_id_zona.Text));
                lbl_tot_rec.Text = total_cajas_rec(lbl_factura.Text.Trim(), int.Parse(lbl_id_zona.Text)).ToString();
                lbl_tot_cajas.Text = total_cajas_factura(lbl_factura.Text.Trim()).ToString();
                if (tot_rec == tot_Cajas)
                {
                    timer2.Enabled = false;
                    timer1.Enabled = false;
                    lbl_msj.Text = "Recepcion Terminada De Cajas De Factura";
                    if (Global.picking == 1)
                    {
                        int tot_ps = Global.total_articulos_ps_zonas(lbl_factura.Text.Trim());
                        int id_zona = 0;
                        string area = "";
                        int tot_arts = 0;
                        if (tot_ps > 0)
                        {
                            //Global.obtener_zona_area_por_surtir(lbl_factura.Text.Trim(), out id_zona, out area, out tot_arts);
                            //Global.agregar_status_zona_area(Global.invcnbr, id_zona, area, "SO");
                            MessageBox.Show("Tiene " + tot_arts.ToString() + " Articulos Para Surtir En La Zona:" + id_zona.ToString() + " " + area);
                            frm_leer_articulos1 f = new frm_leer_articulos1();
                            f.invcnbr = Global.invcnbr;                            
                            f.lbl_factura.Text = invcnbr.Trim();
                            f.tipocaja = "CAJA";
                            f.timer1.Enabled = true;                            
                            f.ShowDialog();
                            f.Dispose();
                            Cursor.Current = Cursors.Default;
                            this.Close();                          
                            //return;

                        }
                        else
                        {
                            MessageBox.Show("Recepcion  Terminada no tiene articulos para surtir" );
                            this.Close();
                        }


                    }
                    else if (Global.picking == 2)
                    {
                        int tot_ps = Global.total_articulos_por_surtir_picking2(lbl_factura.Text.Trim());
                        //int id_zona=0;
                        //string area="";
                        //int tot_arts=0;
                        if (tot_ps > 0)
                        {
                            //Global.obtener_zona_area_por_surtir(lbl_factura.Text.Trim(), out id_zona, out area, out tot_arts);
                            MessageBox.Show("Tiene " + tot_ps.ToString() + " Articulos Para Surtir En PICKING2, Seleccionar Medio Para Surtir" );
                            this.Close();
                            //if (Global.cajap2 == "")
                            //{
                            //    frm_leer_carrito f1 = new frm_leer_carrito();
                            //    f1.invcnbr = Global.invcnbr;
                            //    this.Visible = false;
                            //    f1.ShowDialog();
                            //    if (Global.cajap2 == "")
                            //    {
                            //        MessageBox.Show("Seleccionar Carrito o Canasta Correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                            //        this.Visible = true;
                            //        timer1.Enabled = true;
                            //        return;
                            //    }
                                //else
                                //{
                                //    Global.obtener_zona_area_por_surtir(lbl_factura.Text.Trim(), out id_zona, out area, out tot_arts);
                                //    Global.agregar_status_zona_area(Global.invcnbr, id_zona, area, "SO");
                                //    frm_leer_articulos1 f = new frm_leer_articulos1();
                                //    f.invcnbr = invcnbr.Trim();
                                //    //f.invcnbr_status = false;
                                //    f.lbl_factura.Text = invcnbr.Trim();
                                //    //f.lbl_shipperid.Text = lbl_shiperid.Text;                   
                                //    f.tipocaja = "CARRITO";
                                //    f.timer1.Enabled = true;
                                //    this.Close();
                                //    f.Show();
                                
                                //}
                               
                               
                            //}
                            //else
                            //{
                            //    Global.obtener_zona_area_por_surtir(lbl_factura.Text.Trim(), out id_zona, out area, out tot_arts);
                            //    Global.agregar_status_zona_area(Global.invcnbr, id_zona, area, "SO");
                            //    frm_leer_articulos1 f = new frm_leer_articulos1();
                            //    f.invcnbr = invcnbr.Trim();
                            //    //f.invcnbr_status = false;
                            //    f.lbl_factura.Text = invcnbr.Trim();
                            //    //f.lbl_shipperid.Text = lbl_shiperid.Text;                   
                            //    f.tipocaja = "CARRITO";
                            //    f.timer1.Enabled = true;
                            //    this.Close();
                            //    f.Show();
                            
                            //}


                        }
                        else
                        {
                            MessageBox.Show("Recepcion  Terminada no tiene articulos para surtir");
                            this.Close();
                        }
                    
                    }
                   
                 
                       
                    


                }
                else
                {
                    lbl_msj.Text = "Recibir Cajas..";  
                }

            }
        }

        private void frm_recepcion_cajas_Load(object sender, EventArgs e)
        {
            //if (obtener_factura())
            //{ 
             
            //}
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (txt_caja.Focus())
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
        }

        private void txt_caja_GotFocus(object sender, EventArgs e)
        {
            txt_caja.BackColor = Color.Yellow;  
        }

        private void txt_caja_LostFocus(object sender, EventArgs e)
        {
            txt_caja.BackColor = Color.White;  
        }

        private void frm_recepcion_cajas_Closing(object sender, CancelEventArgs e)
        {
            timer2.Enabled = false;
            timer1.Enabled = false; 
        }

       
    }
}