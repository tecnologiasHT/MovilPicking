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
    public partial class frm_leer_articulos1 : Form
    {
        public frm_leer_articulos1()
        {
            InitializeComponent();
        }
        public decimal cant_sol; //cantidad solicitada del articulo
        public decimal tot_surt_articulo; //cantidad total surtida del articulo
        public decimal tot_surtido_articlo; //cantidad total surtida del articlo
        public decimal pend_surt_art; //cantidad total pendiente de surtir del articulo
        public decimal pend_surt_loc; //cantidad total pendiente de surtir de la localizacion

        public string invtid; //clave del articulo
        public string desc;
        public string invcnbr; //numero de la factura principal
        public bool invcnbr_status;//indica el status del surtimiento de la factura, true=terminado false=no terminado
        public string invcnbr_surt_junto; //numero de la factura que se debe de surtir con la principal
        public string shipperid;
        public int tab_index;
        public bool env_junto; //indica si la factura se debe surtir con otra facturas
        public bool surt_env_junto; //indica si se esta surtiendo la factura surtir junto
        public int tot_env_junto; //total de facturas que se debn de surtir junto
        public int tot_ps_area; //total de articulos por surtir del area
        public int tot_ps_zona; //total de articulos por surtir de la zona
        public string CarritoNo = "";
        public string tipocaja = "";
        public bool pickstatus =false; //indica el status de surtimiento de el articulo
        public long ID_Surt_Art = 0;
        public int IdZona = 0;
        public string Area="";
        public string loc_act = ""; //localizacion actual en susrtimiento
        public int totpartidas = 0; //total partidas a surtir de la cleve en la localizacion
        public decimal CantSolLoc = 0; //cantidad total de la localizacion
        public decimal CantSurtLoc = 0; //cantidad total surtida en la localizacion
        public decimal CantPorSurtirLoc = 0; //Cantidad por surtir en la localizacion
        Global mod = new Global(); 

        void msjsurtirarticulo()
        {
            System.Media.SystemSounds.Beep.Play();            
            if (btnsurtir.BackColor == Color.LawnGreen)
            {
                btnsurtir.BackColor = Color.White;
            }
            else
            {
                btnsurtir.BackColor = Color.LawnGreen;  
            }
            

        }



        bool obtener_carrito_picking2()
        {
         //ADN_Obtener_carrito_Picking2
        //@InvcNbr VARCHAR(20),
        //@IdZona INT,
        //@Usuario VARCHAR(50)          

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            DataRow dr;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Obtener_carrito_Picking2";
            cmd.Connection = Global.cn;
            cmd.Parameters.AddWithValue("@InvcNbr", invcnbr);
            cmd.Parameters.AddWithValue("@IdZona", Global.idzona);
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario.Trim());
           
            if (Global.cn.State == ConnectionState.Closed)
            {
                Global.cn.Open();
            }
            da.SelectCommand = cmd;
            try
            {

                da.Fill(dt);
                if (dt != null)
                {
                    if (dt.Tables[0].Rows.Count != 0)
                    {
                        dr = dt.Tables[0].Rows[0];
                        if (!string.IsNullOrEmpty(dr["CarritoNo"].ToString()))
                        {
                            CarritoNo = dr["CarritoNo"].ToString().Trim();
                            dt.Dispose();
                            cmd.Dispose();
                            dr = null;
                            return true;
                        }
                        else
                        {
                            dt.Dispose();
                            cmd.Dispose();
                            dr = null;
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
                    dt.Dispose();
                    cmd.Dispose();
                    dr = null;
                    return false;
                }
            }
            catch (Exception ex)
            {
                dt.Dispose();
                da.Dispose();
                cmd.Dispose();
                return false;
            }

        }


        bool actualiza_status_factura(string invcnbr, string status)
        {
            //Actualiza el status de surtimiento de la factura
            //[ADN_actualizar_status_surt_factura]	
            //@InvcNbr VARCHAR(20),
            //@Usuario VARCHAR(50),
            //@Status VARCHAR(20)
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;          
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_actualizar_status_surt_factura";
            cmd.Parameters.AddWithValue("@InvcNbr", invcnbr);
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario);
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
                MessageBox.Show("Error al actualizar status de la factura");
                return false;
            }
        }


        bool actualiza_status_zona(string invcnbr, int idzona, string status)
        {
            //ADN_Actualizar_status_zona	
            //@InvcNbr VARCHAR(10),
            //@IdZona INT,
            //@Status VARCHAR(20),
            //@Usuario VARCHAR(50)
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Actualizar_status_zona";
            cmd.Parameters.AddWithValue("@InvcNbr", invcnbr);
            cmd.Parameters.AddWithValue("@IdZona", idzona);
            cmd.Parameters.AddWithValue("@Status", status);
            cmd.Parameters.AddWithValue("@Usuario",Global.usuario );
            
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
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_agregar_status_zonas";
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
                MessageBox.Show("Error al agregar status de factura.." + ex.Message.ToString());
                return false;
            }


        }

    
        bool agregar_status_zonas_area(string invcnbr, int idzona,string area, string status)
        {
            //ADN_agregar_status_zonas_area	
            //@InvcNbr VARCHAR(10),
            //@IdZona INT,
            //@Area VARCHAR(50),
            //@Status varchar(20),
            //@Usuario VARCHAR(50)	
            SqlCommand cmd = new SqlCommand();
            
            cmd.Connection = Global.cn;
           
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_agregar_status_zonas_area";
            cmd.Parameters.AddWithValue("@InvcNbr", invcnbr);
            cmd.Parameters.AddWithValue("@IdZona", idzona);
            cmd.Parameters.AddWithValue("@Area", area);
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
                MessageBox.Show("Error al agregar status " + ex.Message.ToString());
                return false;
            }


        }
   

        bool finalizar_status_zona_area(string invcnbr, int idzona, string area, string status)
        {
            //ADN_finalizar_status_zona_area	
            //@InvcNbr VARCHAR(10),
            //@IdZona INT,
            //@Area VARCHAR(50),
            //@Status varchar(20),
            //@Usuario VARCHAR(50)	
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_finalizar_status_zona_area";
            cmd.Parameters.AddWithValue("@InvcNbr", invcnbr);
            cmd.Parameters.AddWithValue("@IdZona", idzona);
            cmd.Parameters.AddWithValue("@Area", area);
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
                MessageBox.Show("Error al agregar status " + ex.Message.ToString());
                return false;
            }


        }
        
        void limpiar_datos()
        { 
            txt_cve.Text=""; 
            lbl_factura.Text=""; 
            txt_desc.Text=""; 
            lbl_loc_surt.Text=""; 
            lbl_surtir_loc.Text=""; 
            lbl_unidad.Text=""; 
            lbl_cant_surtida.Text=""; 
            lbl_pendiente.Text=""; 
            
            cant_sol=0; //cantidad solicitada del articulo
            
            pend_surt_loc=0; //cantidad total pendiente de surtir de la localizacion

            invtid=""; //clave del articulo
            shipperid="";       
            env_junto=false ; //indica si la factura se debe surtir con otra facturas
            surt_env_junto=false; //indica si se esta surtiendo la factura surtir junto
            tot_env_junto=0; //total de facturas que se debn de surtir junto
            tot_ps_area=0; //total de articulos por surtir del area
            tot_ps_zona=0;



        }
        void limpiar_articulo()
        { 
            txt_cve.Text=""; 
            lbl_loc_surt.Text=""; 
            lbl_surtir_loc.Text=""; 
            lbl_unidad.Text=""; 
            lbl_cant_surtida.Text=""; 
            lbl_pendiente.Text=""; 
            txt_desc.Text = "";
            txt_desc.Text = "Obteniendo articulo para surtir...";  
        }
        bool avanzar_zona(string InvcNbr)
        { 
         //avanza la factura indicada a la siguiente zona de surtimiento
        //ADN_surtimiento_avanzar_zona
        //@InvcNbr
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            DataSet dt = new DataSet();
            DataRow dr;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_surtimiento_avanzar_zona";
            cmd.Parameters.AddWithValue("@InvcNbr", InvcNbr);
            try
            {
                if (Global.cn.State == ConnectionState.Closed)
                {
                    Global.cn.Open();
                }

                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
           
            
        }

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

        int tot_ps_zona_4(string factura)
        {
            //ADN_Obtener_tot_ps_zona4
            //@InvcNbr
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Obtener_tot_ps_zona4";
            cmd.Parameters.AddWithValue("@InvcNbr", factura.Trim());
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
                MessageBox.Show("Error al obtener total de articulos por surtir en zona 4 y 3");
                return -1;
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
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_obtener_tot_articulos_status_zona";
            cmd.Parameters.AddWithValue("@IdZona", idzona);
            cmd.Parameters.AddWithValue("@InvcNbr", factura);
            cmd.Parameters.AddWithValue("@Status", status);
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


        int tot_zonas_status(string InvcNbr, string status)
        { 
         // [ADN_obtener_tot_zonas_status]
         // @InvcNbr VARCHAR(20),
         //@Status VARCHAR(10)
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            DataSet dt = new DataSet();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_obtener_tot_art_pend_surtir_junto_area";
            cmd.Parameters.AddWithValue("@InvcNbr", InvcNbr);
            cmd.Parameters.AddWithValue("@Status", status);
           
            try
            {
                if (Global.cn.State == ConnectionState.Closed)
                {
                    Global.cn.Open();
                }

                return Convert.ToInt16(cmd.ExecuteScalar());

            }
            catch 
            {
                return -1;
            }



        }
             


        
        void totales_ps_area_zona(string factura)
        {
            //ADN_total_arts_surtir_area_zona
            //@InvcNbr VARCHAR(20),
            //@Area varchar(50),
            //@Zona varchar(50),
            //@Status varchar(50)
            if (lbl_factura.Text   == "")
            {
                return;
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
                        tot_ps_zona = Convert.ToInt16(dr["tot_zona"].ToString());

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


        bool obtener_factura()
        {
        //ADN_obtener_factura_area
       //@Zona VARCHAR(50) 
        //@Area  VARCHAR(50)
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            DataRow dr;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_obtener_factura_area";
            cmd.Connection = Global.cn;
            cmd.Parameters.AddWithValue("@IdArea",Global.area );
            cmd.Parameters.AddWithValue("@Zona", Global.idzona);
            da.SelectCommand = cmd;
            try
            {
                da.Fill(dt);
                if (dt == null)
                {
                    dt.Dispose();
                    return false;
                }
                if (dt.Tables[0].Rows.Count != 0)
                {
                    dr = dt.Tables[0].Rows[0];
                    if (!string.IsNullOrEmpty(dr["InvcNbr"].ToString()))
                    {
                        lbl_factura.Text = dr["InvcNbr"].ToString().Trim();
                        invcnbr = dr["InvcNbr"].ToString().Trim();
                        dt.Dispose();
                        da.Dispose();
                        cmd.Dispose();
                       
                        return true;
                    }
                    else
                    {
                        dt.Dispose();
                        da.Dispose();
                        cmd.Dispose();
                        return false;
                    }
                }
                else
                {
                    dt.Dispose();
                    da.Dispose();
                    cmd.Dispose();
                    lbl_factura.Text = "";
                    return false;
                }

            }
            catch 
            {
                dt.Dispose();
                da.Dispose();
                
                Cursor.Current = Cursors.Default;
                cmd.Dispose();
                return false;
            }

        }
        bool obtener_factura_surtir_junto(string factura)
        { 
        //ADN_obtener_factura_surtirjunto
        //@InvcNbr VARCHAR(20), --numero de factura principal
        //@Zona VARCHAR(50), 
        //@Area  VARCHAR(50)
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            DataRow dr;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_obtener_factura_surtirjunto";
            cmd.Connection = Global.cn;
            cmd.Parameters.AddWithValue("@InvcNbr",factura.Trim());
            cmd.Parameters.AddWithValue("@IdArea", Global.area);
            cmd.Parameters.AddWithValue("@IdZona", Global.idzona);            
           
            da.SelectCommand = cmd;
            try
            {
                da.Fill(dt);
                if (dt == null)
                {
                    dt.Dispose();
                    return false;
                }
                if (dt.Tables[0].Rows.Count != 0)
                {
                    dr = dt.Tables[0].Rows[0];
                    if (!string.IsNullOrEmpty(dr["InvcNbr"].ToString()))
                    {
                        invcnbr_surt_junto = dr["InvcNbr"].ToString().Trim();
                        env_junto = true; 
                        dt.Dispose();
                        da.Dispose();
                        cmd.Dispose();

                        return true;
                    }
                    else
                    {
                        dt.Dispose();
                        da.Dispose();
                        cmd.Dispose();                       
                        invcnbr_surt_junto = ""; 
                        env_junto = false; 
                        return false;
                    }
                }
                else
                {
                    dt.Dispose();
                    da.Dispose();
                    cmd.Dispose();                   
                    invcnbr_surt_junto = "";
                    return false;
                }

            }
            catch
            {
                dt.Dispose();
                da.Dispose();
                invcnbr_surt_junto = "";
                Cursor.Current = Cursors.Default;
                cmd.Dispose();              
                return false;
            }



        
        }

        bool finalizar(string factura)
        {
            //ADN_terminar_surtimiento
            //@InvcNbr VARCHAR(20),
            //@Usuario VARCHAR(50)
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_terminar_surtimiento";
            cmd.Parameters.AddWithValue("@InvcNbr", factura );
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario.Trim());
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
                MessageBox.Show("Error al actualizar status.." + ex.Message.ToString());
                return false;
            }

        }

        int total_articulos_status(string factura,string status)
        { 
            //Obtiene el total de articulos de la factura , segun el status proporcionado
        //ADN_obtener_tot_arts_status
        //@InvcNbr VARCHAR(20),
        //@Status VARCHAR(10)
           SqlCommand cmd = new SqlCommand();
            cmd.Connection =Global.cn  ;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_obtener_tot_arts_status";
            cmd.Parameters.AddWithValue("@InvcNbr", factura.Trim() );
            cmd.Parameters.AddWithValue("@Status", status);
            try
            {
                if (Global.cn.State == ConnectionState.Closed)
                {
                    Global.cn.Open();
                }
                int i=Convert.ToInt16(cmd.ExecuteScalar().ToString());

                return i;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener total de articulos");
                return -1;
            }


        }

        bool pendiente(string factura)
        {
            //ADN_obtenert_tot_partidas_surt
            //@InvcNbr varchar(20)
            //@Status VARCHAR(10)
            //verifica si hay articulos pendientes de surtir de la factura especificada
            SqlCommand cmd = new SqlCommand();
            cmd.Connection =Global.cn  ;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_obtenert_tot_partidas_surt";
            cmd.Parameters.AddWithValue("@InvcNbr", factura.Trim() );           
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet dt = new DataSet();
            DataRow dr;
            da.SelectCommand = cmd;
            try
            {
                da.Fill(dt);
                if (dt.Tables[0].Rows.Count != 0)
                {
                    dr = dt.Tables[0].Rows[0];
                    if (!string.IsNullOrEmpty(dr["Tot_pend"].ToString()))
                    {
                        if (Convert.ToDecimal(dr["Tot_pend"].ToString()) > 0)
                        {
                            return true;
                        }
                        else if (Convert.ToDecimal(dr["Tot_pend"].ToString()) == 0)
                        {
                            return false;
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

        bool verifica_caja(string invcnbr,string  numcaja,string tipo)
        { 
            //@InvcNbr VARCHAR(15),
            //@Numerocaja	INT
            //@Tipo VARCHAR(50)
            SqlCommand cmd = new SqlCommand();
            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            DataRow dr;
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Datos_caja_picking";
            cmd.Parameters.AddWithValue("@InvcNbr", invcnbr.Trim());
            cmd.Parameters.AddWithValue("@Numerocaja",numcaja.Trim());
            cmd.Parameters.AddWithValue("@Tipo",tipo);
            da.SelectCommand = cmd;
            try
            {
                da.Fill(dt);
                if (dt.Tables[0].Rows.Count != 0)
                {
                    dr = dt.Tables[0].Rows[0];
                    if (Convert.ToBoolean(dr["Status"].ToString())== false)
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("La caja ya ha sido liberada,seleccionar otra caja","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Exclamation,MessageBoxDefaultButton.Button1   );
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

        bool obtener_articulo_picking2(string factura)
        {
            //VERSION ADN
            timer1.Enabled = false;
            txt_desc.Text = "Espere un momento, Obteniendo Articulo...";
            SqlCommand cmd = new SqlCommand();
            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            DataRow dr;
            try
            {                             
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ADN_obtener_art_picking2";
                cmd.Connection = Global.cn;
                cmd.Parameters.AddWithValue("@InvcNbr", factura.Trim());
                cmd.Parameters.AddWithValue("@IdZona", Global.idzona);
                cmd.Parameters.AddWithValue("@IdArea", Global.area);
                cmd.Parameters.AddWithValue("@Usuario", Global.usuario);

                da.SelectCommand = cmd;
                da.Fill(dt);
                if (dt == null)
                {
                    MessageBox.Show("No hay articulos para surtir", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                    return false;
                }
                if (dt.Tables.Count != 0)
                {
                    if (dt.Tables[0].Rows.Count != 0)
                    {
                        System.Media.SystemSounds.Beep.Play();

                        dr = dt.Tables[0].Rows[0];

                        if (!string.IsNullOrEmpty(dr["InvcNbr"].ToString()))
                        {
                            lbl_factura.Text = dr["InvcNbr"].ToString();
                        }
                        else
                        {
                            lbl_factura.Text = "";
                            return false;
                        }

                        if (!string.IsNullOrEmpty(dr["ID_Surt_Art"].ToString()))
                        {
                            ID_Surt_Art = Convert.ToInt64(dr["ID_Surt_Art"].ToString());
                        }
                        else
                        {
                            ID_Surt_Art = 0;
                            return false;
                        }

                        if (!string.IsNullOrEmpty(dr["InvtId"].ToString()))
                        {
                            txt_cve.Text = dr["InvtId"].ToString().Trim();
                            invtid = dr["InvtId"].ToString().Trim();
                        }
                        if (!string.IsNullOrEmpty(dr["Descr"].ToString()))
                        {
                            txt_desc.Text = dr["Descr"].ToString().Trim();
                        }
                        //localizacion a surtir                    

                        if (!string.IsNullOrEmpty(dr["Localizacion"].ToString()))
                        {
                            lbl_loc_surt.Text = dr["Localizacion"].ToString().Trim();
                        }

                        if (!string.IsNullOrEmpty(dr["Unidad"].ToString()))
                        {
                            lbl_unidad.Text = dr["Unidad"].ToString().Trim();
                        }
                        //total_surtir
                        if (!string.IsNullOrEmpty(dr["CantSol"].ToString()))
                        {
                            lbl_surtir_loc.Text = dr["CantSol"].ToString().Trim();
                            cant_sol = Convert.ToDecimal(dr["CantSol"].ToString());
                        }
                        else
                        {
                            cant_sol = 0;
                        }

                        if (!string.IsNullOrEmpty(dr["CantSurtida"].ToString()))
                        {
                            lbl_cant_surtida.Text = dr["CantSurtida"].ToString().Trim();
                            tot_surtido_articlo = Convert.ToDecimal(dr["CantSurtida"].ToString().Trim());
                            lbl_pendiente.Text = (Convert.ToDecimal(cant_sol) - Convert.ToDecimal(dr["CantSurtida"].ToString().Trim())).ToString();

                        }
                        else
                        {
                            lbl_cant_surtida.Text = "0";
                            tot_surtido_articlo = 0;
                            lbl_pendiente.Text = cant_sol.ToString();
                        }


                        System.Media.SystemSounds.Beep.Play();
                        pend_surt_art = cant_sol - tot_surtido_articlo;
                        if (pend_surt_art == 0)
                        {
                            MessageBox.Show("Articulo Completado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                            limpiar_articulo();
                            txt_desc.Text = "Obteniendo siguiente articulo...";
                        }

                        return true;
                    }
                    else
                    {
                        Cursor.Current = Cursors.Default;
                        cmd.Dispose();
                        MessageBox.Show("No hay articulos para surtir", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
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
                Cursor.Current = Cursors.Default;
                cmd.Dispose();
                MessageBox.Show("Error al obtener articulo para surtir..." + ex.Message.ToString());
                return false;
            }

        }
             
        bool obtener_articulo_para_surtir_picking2(string factura)
        {
            //version PIVA
            //ADN_obtener_articulo_para_surtir_picking2	
            //@InvcNbr VARCHAR(15),	
            //@Usuario VARCHAR(50) 
            timer1.Enabled = false;
            txt_desc.Text = "Espere un momento, Obteniendo Articulo...";
            DataSet dt = new DataSet();
            DataRow dr;
            try
            {                
                dt = Global.obtener_articulo_para_surtir_picking2(Global.invcnbr);
                if (dt == null)
                {
                    MessageBox.Show("No hay articulos para surtir", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                    return false;
                }
                if (dt.Tables.Count != 0)
                {
                    if (dt.Tables[0].Rows.Count != 0)
                    {
                        System.Media.SystemSounds.Beep.Play();

                        dr = dt.Tables[0].Rows[0];

                        if (!string.IsNullOrEmpty(dr["InvcNbr"].ToString()))
                        {
                            lbl_factura.Text = dr["InvcNbr"].ToString();
                        }
                        else
                        {
                            lbl_factura.Text = "";
                            return false;
                        }

                        if (!string.IsNullOrEmpty(dr["ID_Surt_Art"].ToString()))
                        {
                            ID_Surt_Art = Convert.ToInt64(dr["ID_Surt_Art"].ToString());
                        }
                        else
                        {
                            ID_Surt_Art = 0;
                            return false;
                        }

                        if (!string.IsNullOrEmpty(dr["InvtId"].ToString()))
                        {
                            txt_cve.Text = dr["InvtId"].ToString().Trim();
                            invtid = dr["InvtId"].ToString().Trim();
                        }
                        if (!string.IsNullOrEmpty(dr["Descr"].ToString()))
                        {
                            txt_desc.Text = dr["Descr"].ToString().Trim();
                        }
                        //localizacion a surtir                    

                        if (!string.IsNullOrEmpty(dr["Localizacion"].ToString()))
                        {
                            lbl_loc_surt.Text = dr["Localizacion"].ToString().Trim();
                        }

                        if (!string.IsNullOrEmpty(dr["IdArea"].ToString()))
                          {
                              if (dr["IdArea"].ToString().Trim() == "SEGUETA")
                              {
                                  Area = "SEGUETA";
                                  Global.area = "SEGUETA";
                              }
                              else if (dr["IdArea"].ToString().Trim() == "PICKING2")
                              {
                                  Area = dr["Localizacion"].ToString().Trim();
                                  Global.area = dr["Localizacion"].ToString().Trim();
                              }
                              else
                              {
                                  Area = dr["IdArea"].ToString().Trim();
                                  Global.area = dr["IdArea"].ToString().Trim();
                              
                              }
                          }
                        else
                        {
                          Area="";
                          Global.area ="";
                        }


                        if (!string.IsNullOrEmpty(dr["IdZona"].ToString()))
                        {
                            IdZona = int.Parse(dr["IdZona"].ToString());
                            Global.idzona = int.Parse(dr["IdZona"].ToString());
                        }
                        else
                        {
                            IdZona = Global.Obtener_IdZona_Picking2();
                            if (IdZona <= 0)
                            {
                                IdZona = int.Parse(Properties.Resources.idzonap2.ToString().Trim());
                                Global.idzona = IdZona;
                            }

                        }

                       
                        if (!string.IsNullOrEmpty(dr["Unidad"].ToString()))
                        {
                            lbl_unidad.Text = dr["Unidad"].ToString().Trim();
                        }
                        //total_surtir
                        if (!string.IsNullOrEmpty(dr["CantSol"].ToString()))
                        {
                            
                            cant_sol = Convert.ToDecimal(dr["CantSol"].ToString());
                        }
                        else
                        {
                            cant_sol = 0;
                        }
                                                

                        if (!string.IsNullOrEmpty(dr["CantSurtida"].ToString()))
                        {
                            tot_surtido_articlo = Convert.ToDecimal(dr["CantSurtida"].ToString().Trim());
                        }
                        else
                        {
                            lbl_cant_surtida.Text = "0";
                            tot_surtido_articlo = 0;
                            lbl_pendiente.Text = cant_sol.ToString();
                        }
                        totpartidas = mod.ObtenerTotalPartidasClaveLocalizacion(Global.invcnbr, invtid, lbl_loc_surt.Text.Trim());

                        lblTotPartidas.Text = totpartidas.ToString();

                       
                            if (!string.IsNullOrEmpty(dr["CantSurtida"].ToString().Trim()))
                            {
                                lbl_cant_surtida.Text = dr["CantSurtida"].ToString().Trim();
                                tot_surtido_articlo = decimal.Parse(dr["CantSurtida"].ToString().Trim());
                                lbl_pendiente.Text = (Convert.ToDecimal(cant_sol) - Convert.ToDecimal(dr["CantSurtida"].ToString().Trim())).ToString();
                                pend_surt_art = cant_sol - tot_surtido_articlo;
                            }
                            else
                            {
                                lbl_cant_surtida.Text = "0";
                                tot_surtido_articlo = 0;
                                lbl_pendiente.Text = cant_sol.ToString();
                                pend_surt_art = cant_sol;
                            } 
                            
                            lbl_surtir_loc.Text = dr["CantSol"].ToString().Trim();
                           
                          

                        System.Media.SystemSounds.Beep.Play();
                        if (pend_surt_art == 0)
                        {
                            MessageBox.Show("Articulo Completado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                            limpiar_articulo();
                            txt_desc.Text = "Obteniendo siguiente articulo...";
                        }

                        return true;
                    }
                    else
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("No hay articulos para surtir", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
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
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Error al obtener articulo para surtir..." + ex.Message.ToString());
                return false;
            }
        }

        bool obtener_articulo_zonas_picking1(string factura)
        {
            timer1.Enabled = false;
            txt_desc.Text = "Espere un momento, Obteniendo Articulo...";
            
            DataSet dt = new DataSet();
            DataRow dr;
            try
            {
                dt = Global.Obtener_articulo_para_surtir_zonas_picking1(Global.invcnbr);

                if (dt == null)
                {
                    MessageBox.Show("No hay articulos para surtir", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return false;
                }
                if (dt.Tables.Count != 0)
                {
                    if (dt.Tables[0].Rows.Count != 0)
                    {
                        System.Media.SystemSounds.Beep.Play();

                        dr = dt.Tables[0].Rows[0];

                        if (!string.IsNullOrEmpty(dr["InvcNbr"].ToString()))
                        {
                            lbl_factura.Text = dr["InvcNbr"].ToString();
                        }
                        else
                        {
                            lbl_factura.Text = "";
                            return false;
                        }

                        if (!string.IsNullOrEmpty(dr["ID_Surt_Art"].ToString()))
                        {
                            ID_Surt_Art = Convert.ToInt64(dr["ID_Surt_Art"].ToString());
                        }
                        else
                        {
                            ID_Surt_Art = 0;
                            return false;
                        }
                        if (!string.IsNullOrEmpty(dr["IdZona"].ToString()))
                        {
                            IdZona = int.Parse(dr["IdZona"].ToString());
                            Global.idzona = int.Parse(dr["IdZona"].ToString());
                        }
                        else
                        {
                           IdZona= Global.obtener_zona_inicio_picking1();
                        }

                        if(!string.IsNullOrEmpty(dr["Area"].ToString()))
                        {
                            Area=dr["Area"].ToString().Trim();
                            Global.area = dr["Area"].ToString().Trim();
                        }
                        else
                        {
                            Area = "";
                        }


                        if (!string.IsNullOrEmpty(dr["InvtId"].ToString()))
                        {
                            txt_cve.Text = dr["InvtId"].ToString().Trim();
                            invtid = dr["InvtId"].ToString().Trim();
                        }
                        if (!string.IsNullOrEmpty(dr["Descr"].ToString()))
                        {
                            txt_desc.Text = dr["Descr"].ToString().Trim();
                        }
                        //localizacion a surtir                    

                        if (!string.IsNullOrEmpty(dr["Localizacion"].ToString()))
                        {
                            lbl_loc_surt.Text = dr["Localizacion"].ToString().Trim();
                        }

                        if (!string.IsNullOrEmpty(dr["Unidad"].ToString()))
                        {
                            lbl_unidad.Text = dr["Unidad"].ToString().Trim();
                        }

                       totpartidas = mod.ObtenerTotalPartidasClaveLocalizacion(Global.invcnbr,invtid,lbl_loc_surt.Text.Trim());

                       lblTotPartidas.Text = totpartidas.ToString();

                       //total_surtir
                       if (!string.IsNullOrEmpty(dr["CantSol"].ToString()))
                       {
                          
                           cant_sol = Convert.ToDecimal(dr["CantSol"].ToString());                          
                       }
                       else
                       {
                           cant_sol = 0;
                           CantSolLoc = 0;
                       }

                        //total surtido
                       if (!string.IsNullOrEmpty(dr["CantSurtida"].ToString()))
                       {
                           
                           tot_surtido_articlo = Convert.ToDecimal(dr["CantSurtida"].ToString().Trim());
                       }
                       else
                       {
                           lbl_cant_surtida.Text = "0";
                           tot_surtido_articlo = 0;
                           lbl_pendiente.Text = cant_sol.ToString();
                       }

                       
                           CantSolLoc = cant_sol;
                           CantSurtLoc = tot_surtido_articlo;
                           lbl_surtir_loc.Text = cant_sol.ToString()  ;
                           lbl_cant_surtida.Text = tot_surtido_articlo.ToString();
                           pend_surt_art = cant_sol - tot_surtido_articlo;
                           lbl_pendiente.Text = (cant_sol - tot_surtido_articlo).ToString()  ;


                        System.Media.SystemSounds.Beep.Play();
                       
                        if (pend_surt_art == 0)
                        {
                            MessageBox.Show("Articulo Completado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                            limpiar_articulo();
                            txt_desc.Text = "Obteniendo siguiente articulo...";
                        }

                        return true;
                    }
                    else
                    {
                        Cursor.Current = Cursors.Default;
                        dt.Dispose();
                        MessageBox.Show("No hay articulos para surtir", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        return false;


                    }

                }
                else
                {
                    dt.Dispose();
                    return false;
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                dt.Dispose();
                MessageBox.Show("Error al obtener articulo para surtir..." + ex.Message.ToString());
                return false;
            }

          
        }

        /// <summary>
        /// Obtener articulo para surtir en la zona especificada, de la factura
        /// </summary>
        /// <param name="pIdzona"></param>
        /// <returns></returns>
        bool ObtenerArticuloParasurtirEnZona(string pIdzona)
        {
            timer1.Enabled = false;
            txt_desc.Text = "Espere un momento, Obteniendo Articulo...";

            DataSet dt = new DataSet();
            DataRow dr;
            try
            {
                dt = Global.ObtenerArticuloParaSurtirZonaPicking1(Global.invcnbr,pIdzona );

                if (dt == null)
                {
                    return false;
                }
                if (dt.Tables.Count != 0)
                {
                    if (dt.Tables[0].Rows.Count != 0)
                    {
                        System.Media.SystemSounds.Beep.Play();

                        dr = dt.Tables[0].Rows[0];

                        if (!string.IsNullOrEmpty(dr["InvcNbr"].ToString()))
                        {
                            lbl_factura.Text = dr["InvcNbr"].ToString();
                        }
                        else
                        {
                            lbl_factura.Text = "";
                            return false;
                        }

                        if (!string.IsNullOrEmpty(dr["ID_Surt_Art"].ToString()))
                        {
                            ID_Surt_Art = Convert.ToInt64(dr["ID_Surt_Art"].ToString());
                        }
                        else
                        {
                            ID_Surt_Art = 0;
                            return false;
                        }
                        if (!string.IsNullOrEmpty(dr["IdZona"].ToString()))
                        {
                            IdZona = int.Parse(dr["IdZona"].ToString());
                            Global.idzona = int.Parse(dr["IdZona"].ToString());
                        }
                        else
                        {
                            IdZona = Global.obtener_zona_inicio_picking1();
                        }

                        if (!string.IsNullOrEmpty(dr["Area"].ToString()))
                        {
                            Area = dr["Area"].ToString().Trim();
                            Global.area = dr["Area"].ToString().Trim();
                        }
                        else
                        {
                            Area = "";
                        }


                        if (!string.IsNullOrEmpty(dr["InvtId"].ToString()))
                        {
                            txt_cve.Text = dr["InvtId"].ToString().Trim();
                            invtid = dr["InvtId"].ToString().Trim();
                        }
                        if (!string.IsNullOrEmpty(dr["Descr"].ToString()))
                        {
                            txt_desc.Text = dr["Descr"].ToString().Trim();
                        }
                        //localizacion a surtir                    

                        if (!string.IsNullOrEmpty(dr["Localizacion"].ToString()))
                        {
                            lbl_loc_surt.Text = dr["Localizacion"].ToString().Trim();
                        }

                        if (!string.IsNullOrEmpty(dr["Unidad"].ToString()))
                        {
                            lbl_unidad.Text = dr["Unidad"].ToString().Trim();
                        }

                        totpartidas = mod.ObtenerTotalPartidasClaveLocalizacion(Global.invcnbr, invtid, lbl_loc_surt.Text.Trim());

                        lblTotPartidas.Text = totpartidas.ToString();

                        //total_surtir
                        if (!string.IsNullOrEmpty(dr["CantSol"].ToString()))
                        {
                            cant_sol = Convert.ToDecimal(dr["CantSol"].ToString());
                        }
                        else
                        {
                            cant_sol = 0;
                            CantSolLoc = 0;
                        }

                        //total surtido
                        if (!string.IsNullOrEmpty(dr["CantSurtida"].ToString()))
                        {

                            tot_surtido_articlo = Convert.ToDecimal(dr["CantSurtida"].ToString().Trim());
                        }
                        else
                        {
                            lbl_cant_surtida.Text = "0";
                            tot_surtido_articlo = 0;
                            lbl_pendiente.Text = cant_sol.ToString();
                        }

                        if (totpartidas == 1)
                        {
                            CantSolLoc = cant_sol;
                            CantSurtLoc = tot_surtido_articlo;
                            lbl_surtir_loc.Text = cant_sol.ToString();
                            lbl_cant_surtida.Text = tot_surtido_articlo.ToString();
                            pend_surt_art = cant_sol - tot_surtido_articlo;
                            lbl_pendiente.Text = (cant_sol - tot_surtido_articlo).ToString();

                        }
                        else if (totpartidas > 1)
                        {
                            //obtiene la cantidad total solictada en la localizacion de la clave especificada
                            CantSolLoc = Global.ObtenerCantidadTotalSolictadaLoc(Global.invcnbr, invtid, lbl_loc_surt.Text.Trim());
                            //obtiene la cantidad total surtida de la localizacion
                            CantSurtLoc = Global.ObtenerCantidadTotalSurtidaLoc(Global.invcnbr, invtid, lbl_loc_surt.Text.Trim());
                            CantPorSurtirLoc = CantSolLoc - CantSurtLoc;
                            lbl_surtir_loc.Text = CantSolLoc.ToString();
                            lbl_cant_surtida.Text = CantSurtLoc.ToString();
                            pend_surt_art = CantSolLoc - CantSurtLoc;
                            lbl_pendiente.Text = (CantSolLoc - CantPorSurtirLoc).ToString();

                        }


                        System.Media.SystemSounds.Beep.Play();

                        if (pend_surt_art == 0)
                        {
                            MessageBox.Show("Articulo Completado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                            limpiar_articulo();
                            txt_desc.Text = "Obteniendo siguiente articulo...";
                        }

                        return true;
                    }
                    else
                    {
                        Cursor.Current = Cursors.Default;
                        dt.Dispose();
                        MessageBox.Show("No hay articulos para surtir", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        return false;


                    }

                }
                else
                {
                    dt.Dispose();
                    return false;
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                dt.Dispose();
                MessageBox.Show("Error al obtener articulo para surtir..." + ex.Message.ToString());
                return false;
            }




        }




        bool obtener_articulo(string factura)
        {

            timer1.Enabled = false;  
            txt_desc.Text = "Espere un momento, Obteniendo Articulo...";  
            SqlCommand cmd = new SqlCommand();
            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            DataRow dr;
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ADN_obtener_art_picking1";
                cmd.Connection = Global.cn  ;
                cmd.Parameters.AddWithValue("@InvcNbr",factura.Trim());
                cmd.Parameters.AddWithValue("@IdZona",Global.idzona);
                cmd.Parameters.AddWithValue("@IdArea", Global.area);
                cmd.Parameters.AddWithValue("@Usuario", Global.usuario);
                                
                da.SelectCommand = cmd;
                da.Fill(dt);
                if (dt == null)
                {
                    MessageBox.Show("No hay articulos para surtir", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                    return false;
                }
                if (dt.Tables.Count != 0)
                {
                    if (dt.Tables[0].Rows.Count != 0)
                    {
                        System.Media.SystemSounds.Beep.Play();
                       
                        dr = dt.Tables[0].Rows[0];

                        if (!string.IsNullOrEmpty(dr["InvcNbr"].ToString()))
                        {
                           lbl_factura.Text  = dr["InvcNbr"].ToString();
                        }
                        else
                        {
                           lbl_factura.Text  ="";
                            return false;
                        }

                        if (!string.IsNullOrEmpty(dr["ID_Surt_Art"].ToString()))
                        {
                            ID_Surt_Art = Convert.ToInt64(dr["ID_Surt_Art"].ToString());
                        }
                        else
                        {
                            ID_Surt_Art = 0;
                            return false;
                        }

                        if (!string.IsNullOrEmpty(dr["InvtId"].ToString()))
                        {
                            txt_cve.Text = dr["InvtId"].ToString().Trim();
                            invtid = dr["InvtId"].ToString().Trim();
                        }
                        if (!string.IsNullOrEmpty(dr["Descr"].ToString()))
                        {
                            txt_desc.Text = dr["Descr"].ToString().Trim();
                        }
                        //localizacion a surtir                    

                        if (!string.IsNullOrEmpty(dr["Localizacion"].ToString()))
                        {
                            lbl_loc_surt.Text = dr["Localizacion"].ToString().Trim();
                        }

                        if (!string.IsNullOrEmpty(dr["Unidad"].ToString()))
                        {
                            lbl_unidad.Text = dr["Unidad"].ToString().Trim();
                        }
                        //total_surtir
                        if (!string.IsNullOrEmpty(dr["CantSol"].ToString()))
                        {
                            lbl_surtir_loc.Text = dr["CantSol"].ToString().Trim();
                            cant_sol = Convert.ToDecimal(dr["CantSol"].ToString());
                        }
                        else
                        {
                            cant_sol = 0;
                        }

                        

                 
                        if (!string.IsNullOrEmpty(dr["CantSurtida"].ToString()))
                        {
                            lbl_cant_surtida.Text = dr["CantSurtida"].ToString().Trim();
                            tot_surtido_articlo = Convert.ToDecimal(dr["CantSurtida"].ToString().Trim());
                            lbl_pendiente.Text = (Convert.ToDecimal(cant_sol) - Convert.ToDecimal(dr["CantSurtida"].ToString().Trim())).ToString();
                            
                        }
                        else
                        { 
                           lbl_cant_surtida.Text = "0";
                           tot_surtido_articlo = 0;
                           lbl_pendiente.Text = cant_sol.ToString();                      
                        }


                        System.Media.SystemSounds.Beep.Play();
                        pend_surt_art = cant_sol - tot_surtido_articlo;
                        if (pend_surt_art == 0)
                        {
                            MessageBox.Show("Articulo Completado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                            limpiar_articulo();
                            txt_desc.Text = "Obteniendo siguiente articulo...";
                        }

                        return true;
                    }
                    else
                    {
                        Cursor.Current = Cursors.Default;
                        cmd.Dispose();
                        MessageBox.Show("No hay articulos para surtir", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
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
                Cursor.Current = Cursors.Default;
                cmd.Dispose();
                MessageBox.Show("Error al obtener articulo para surtir..." + ex.Message.ToString());
                return false;
            }

        }

        public bool IsNumeric(object Expression)
        {

            decimal num;
            try
            {
                num = decimal.Parse(Convert.ToString(Expression));
                return true;
            }
            catch 
            {
                return false;
            }


        }


        bool partidas_pendientes()
        {
            //ADN_obtenert_tot_partidas_surt
            //@InvcNbr varchar(20)
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_obtenert_tot_partidas_surt";
            cmd.Parameters.AddWithValue("@InvcNbr", invcnbr);
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet dt = new DataSet();
            DataRow dr;
            da.SelectCommand = cmd;
            try
            {
                da.Fill(dt);
                if (dt.Tables[0].Rows.Count != 0)
                {
                    dr = dt.Tables[0].Rows[0];
                    if (!string.IsNullOrEmpty(dr[2].ToString()))
                    {
                        if (Convert.ToDecimal(dr[2].ToString()) > 0)
                        {
                            return true;
                        }
                        else if (Convert.ToDecimal(dr[2].ToString()) == 0)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }

                    }
                    else
                    {
                        return true;
                    }


                }
                else
                {
                    return true;
                }
            }
            catch 
            {

                return false;
            }

        }

        bool agregar_articulo(string invc, string loc, string sku, string codigo, decimal cant, bool nodisp, string caja)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Connection = Global.cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ADN_agregar_art_lista_surt";
                cmd.Parameters.AddWithValue("@ID_Surt_Art", ID_Surt_Art);
                cmd.Parameters.AddWithValue("@InvcNbr", invc.Trim());
                cmd.Parameters.AddWithValue("@Localizacion", loc.Trim().ToUpper() );
                cmd.Parameters.AddWithValue("@SKU", sku.Trim());
                cmd.Parameters.AddWithValue("@Numcaja",caja );                
                if (codigo == "")
                {
                    cmd.Parameters.AddWithValue("@CodigoBarras", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@CodigoBarras", codigo.Trim());
                }
                //cantidad que se va agregar
                cmd.Parameters.AddWithValue("@Cantidad", cant);
                cmd.Parameters.Add("@tot_surt",SqlDbType.Decimal);
                cmd.Parameters["@tot_surt"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@Pickstatus",SqlDbType.Bit);
                cmd.Parameters["@Pickstatus"].Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("@Usuario", Global.usuario);

                if (Global.cn.State == ConnectionState.Closed)
                {
                    Global.cn.Open();
                }

                cmd.ExecuteNonQuery();

                if (!string.IsNullOrEmpty(cmd.Parameters["@tot_surt"].Value.ToString()))
                 {
                    //obtenemos el total pendiente de surtir del articulo
                     pend_surt_art = cant_sol - Convert.ToDecimal(cmd.Parameters["@tot_surt"].Value.ToString());
                     tot_surtido_articlo = Convert.ToDecimal(cmd.Parameters["@tot_surt"].Value.ToString());
                     lbl_cant_surtida.Text = cmd.Parameters["@tot_surt"].Value.ToString().Trim();
                     lbl_pendiente.Text = pend_surt_art.ToString().Trim();
                     
                     if (!string.IsNullOrEmpty(cmd.Parameters["@Pickstatus"].Value.ToString()))
                     {
                         pickstatus = Convert.ToBoolean(cmd.Parameters["@Pickstatus"].Value.ToString());
                     }
                                       
                }
                else
                {
                   pend_surt_art = 0;
                   tot_surtido_articlo=0;
                   pickstatus = false;
                }

                return true;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar articulo.." + ex.Message.ToString());
                return false;
            }



        }

        bool agregar_articulo_Detalle(string invc, string loc, string sku, string codigo, decimal cant, bool nodisp,bool pickstatus)
        {
                          
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.Connection = Global.cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ADN_agregar_art_lista_surt_detalle";
                cmd.Parameters.AddWithValue("@InvcNbr", invc.Trim());
                cmd.Parameters.AddWithValue("@Localizacion", loc.Trim());
                cmd.Parameters.AddWithValue("@SKU", sku.Trim());
                if (codigo != "")
                {
                    cmd.Parameters.AddWithValue("@CodigoBarras", codigo.Trim().ToUpper());
                }
                else
                {
                    cmd.Parameters.AddWithValue("@CodigoBarras",DBNull.Value  );
                }
                //cantidad del articulo
                cmd.Parameters.AddWithValue("@Cantidad", cant);
                //indica la disponibilidad en la localizacion
                cmd.Parameters.AddWithValue("@NoDisp", nodisp);
                //indica el status del surtimiento 1=terminado, 0=pendiente
                cmd.Parameters.AddWithValue("@Pickstatus",pickstatus );

                if (Global.cn.State == ConnectionState.Closed)
                {
                    Global.cn.Open();
                }

                cmd.ExecuteNonQuery();             

                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar articulo.." + ex.Message.ToString());
                return false;
            }

        }

       private void btn_salir_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;

            if (ID_Surt_Art > 0)
            {
                decimal cantsol = 0;
                decimal cantsurt = 0;
                if (Global.obtener_cantidades_partida(ID_Surt_Art, out cantsol, out cantsurt))
                {
                    string res = MessageBox.Show("Tiene un articulo por surtir, Desea Salir?..", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1).ToString();
                    if (res == "Yes")
                    {
                        if (cantsol == cantsurt)
                        {
                            if (Global.actualizar_status_partida(ID_Surt_Art, "SA"))
                            {
                                if (Global.picking == 1)
                                {
                                  
                                    Global.finalizar_status_zona_area_picking1(Global.invcnbr, IdZona, Area, "SO");
                      
                                    this.Close();
                                }
                                else if (Global.picking == 2)
                                {
                                    Global.actualiza_status_zona(Global.invcnbr, IdZona, "SO");
                                    this.Close();
                                }
                                else
                                {
                                    this.Close();
                                }

                                
                            }
                            else
                            {
                                MessageBox.Show("Error al actualizar status de la partida, Intente de nuevo");
                                timer1.Enabled = true;
                                timer2.Enabled = true;
                                return;
                            }
                        }
                        else
                        {
                            if (Global.actualizar_status_partida(ID_Surt_Art, "PS"))
                            {
                                if (Global.picking == 1)
                                {
                                    Global.finalizar_status_zona_area_picking1(Global.invcnbr, IdZona, Area, "SO");
                                    this.Close();
                                }
                                else if (Global.picking == 2)
                                {
                                    Global.actualiza_status_zona(Global.invcnbr, IdZona, "SO");
                                    this.Close();
                                }
                                else
                                {
                                    this.Close();
                                }


                            }
                            else
                            {
                                MessageBox.Show("Error al actualizar status de la partida, Intente de nuevo");
                                timer1.Enabled = true;
                                timer2.Enabled = true;
                                return;
                            }
                        }
                    }
                    else
                    {
                        timer1.Enabled = true;
                        timer2.Enabled = true;
                        return;

                    }

                }
                else
                {
                    MessageBox.Show("Error al actualizar status de la partida, Intente de nuevo");
                    timer1.Enabled = true;
                    timer2.Enabled = true;
                    return;
                }


            }
            else
            {

                if (Global.picking == 1)
                {
                    Global.finalizar_status_zona_area_picking1(Global.invcnbr, IdZona, Area, "SO");
                    this.Close();
                }
                else if (Global.picking == 2)
                {
                    Global.actualiza_status_zona(Global.invcnbr, IdZona, "SO");
                    this.Close();
                }
                else
                {
                    this.Close();
                }
            }
  
        }

        
        private void frm_leer_articulos_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F7:
                    if (lbl_factura.Text !=""  )
                    {
                        frm_cajas_picking f = new frm_cajas_picking();
                        
                        f.ShowDialog();
                    }
                    break;
                case Keys.F10:
                    this.Close(); 
                    break;
                default:
                    break;
            }
        }

        private void btn_loc_vacia_Click(object sender, EventArgs e)
        {
         
        }

        private void frm_leer_articulos_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
            if (Global.picking == 1)
            {
                int tot_arts_ps = Global.total_articulos_ps_zonas(Global.invcnbr);
                if (tot_arts_ps == 0)
                {
                    timer1.Enabled = false;
                    timer2.Enabled = false;
                    t1.Enabled = false;
                    MessageBox.Show("No hay articulos por surtir..", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    this.Close();
                }               
            }
            else
            {
                timer_timeout.Enabled = false;  
            }
        }

        private void frm_leer_articulos_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show(e.KeyChar.ToString());    
        }

        private void btn_loc_vac_Click(object sender, EventArgs e)
        {
            if (agregar_articulo_Detalle(invcnbr, lbl_loc_surt.Text.Trim(), invtid.Trim(), "", 0, true,true ))
            {
                lbl_loc_surt.Text = "";
                MessageBox.Show("Seleccione otra localizacion para surtir");
            }
     
        }

        private void btn_loc_inc_Click(object sender, EventArgs e)
        {
            if (agregar_articulo_Detalle(invcnbr, lbl_loc_surt.Text.Trim(), invtid.Trim(), "", 0, false, true))
            {
                lbl_loc_surt.Text = "";
                MessageBox.Show("Seleccione otra localizacion para surtir");
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txt_desc.Text = "Obteniendo Articulo...";

            if (Global.picking == 1)
            {
                if (obtener_articulo_zonas_picking1(Global.invcnbr))
                {
                    timer1.Enabled = false;
                    btnsurtir.Enabled = true;
                    btnsurtir.Focus();
                    Global.agregar_status_zonas_area_picking1(Global.invcnbr, IdZona, Area, "SO");
                    timer2.Enabled = true;
                    return;
                }
                else
                {
                    timer1.Enabled = false;
                    timer2.Enabled = false;
                    t1.Enabled = false;
                    //obtener los articulos por surtir en las zonas de el usuario
                    int tot_arts_ps = Global.total_articulos_ps_zonas(Global.invcnbr);
                    if (tot_arts_ps == 0)
                    {
                        int IdZona1 = 0;
                        int totpszona1 = 0;
                        Global.actualiza_status_zona_usuario_picking1(Global.invcnbr, IdZona, "SO");
                        IdZona1 = Global.ObtenerIdZonaSurtimientoFactura(Global.invcnbr);
                        if (IdZona1 > 0)
                        {  
                            //VERIFICAR SI EXISTEN ARTICULOS POR SURTIR EN LA ZONA
                           totpszona1 = Global.TotPartidasStatusZonaFactura(Global.invcnbr, IdZona1, "PS");
                           if (totpszona1 >= 2)
                           {
                               string res = MessageBox.Show("No hay mas articulos por surtir en su lado. Desea surtir articulos del otro lado?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2).ToString();
                               if (res == "Yes")
                               {
                                   limpiar_articulo();
                                   if (ObtenerArticuloParasurtirEnZona(IdZona1.ToString().Trim()))
                                   {
                                       timer1.Enabled = false;
                                       btnsurtir.Enabled = true;
                                       btnsurtir.Focus();
                                       Global.agregar_status_zonas_area_picking1(Global.invcnbr, IdZona, Area, "SO");
                                       timer2.Enabled = true;
                                       return;
                                   }
                                   else
                                   {
                                       MessageBox.Show("No fue posible obtener un articulo para surtir", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                                       this.Close();
                                   }
                               }
                               else
                               {
                                   this.Close();
                               }                               
 
                           }
                           else
                           {
                               MessageBox.Show("No fue posible obtener un articulo para surtir", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                               this.Close();
                              
                           }
                        }
                        else
                        {
                            this.Close();
                        }

                       
                        
                    }
                    else
                    {                       
                        Global.actualiza_status_zona_usuario_picking1(Global.invcnbr, IdZona, "SO");
                        MessageBox.Show("Existen articulos en surtimiento por otro usuario..", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        this.Close();
                    }
                }
            } //picking2
            else
            {
                if (Global.total_articulos_por_surtir_picking2(Global.invcnbr) > 0)
                {

                    if (obtener_articulo_para_surtir_picking2(invcnbr))
                    {
                        timer1.Enabled = false;
                        Global.agregar_status_zonas_area_picking1(Global.invcnbr, IdZona, Area, "SO");
                        timer2.Enabled = true;
                        btnsurtir.Enabled = true;
                        btnsurtir.Focus();
                    }
                    else
                    {
                        timer1.Enabled = false;
                        timer2.Enabled = false;
                        Global.actualiza_status_zona(Global.invcnbr, IdZona, "SO");
                        MessageBox.Show("No hay articulos para surtir en PICKING2", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        this.Close();
                        
                    }
                }
                else
                {
                    timer1.Enabled = false;
                    timer2.Enabled = false;
                    Global.actualiza_status_zona(Global.invcnbr, IdZona, "SO");
                    MessageBox.Show("No hay articulos para surtir en PICKING2", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    this.Close();
                }
            
            }

        }

      

        private void btnsurtir_Click(object sender, EventArgs e)
        {           
            if (Global.picking == 1)
            {
                //leer la caja
                string caja = "";
                string loc = "";
                this.Visible = false; ;
                timer2.Enabled = false;
                t1.Enabled = false;
                timer_timeout.Enabled = false;
                frm_sel_caja f1 = new frm_sel_caja();
                f1.invcnbr = invcnbr;
                f1.ShowDialog();
                if (f1.txtcaja.Text != "")
                {
                    caja = f1.txtcaja.Text.Trim();
                }
                else
                {
                    this.Visible = true;
                    timer1.Enabled = true;
                    return;
                }
                f1.Dispose();
                //comparar la ultima localizacion
                //con la actual, 
                if (loc_act != lbl_loc_surt.Text.Trim())
                {
                    frm_leer_loc f2 = new frm_leer_loc();
                    f2.invcnbr = invcnbr;
                    f2.lbl_loc.Text = lbl_loc_surt.Text.Trim();
                    f2.ShowDialog();
                    if (f2.ok)
                    {
                        loc = f2.txt_loc.Text.Trim().ToUpper();
                    }
                    else
                    {
                        this.Visible = true;
                        timer1.Enabled = true;
                        return;
                    }
                   
                    if (loc == "")
                    {
                        this.Visible = true;
                        timer1.Enabled = true;
                        return;

                    }
                    else
                    {
                        loc_act = lbl_loc_surt.Text.Trim();
                    }
                }
               
                frm_surtir_articulo f = new frm_surtir_articulo();
                f.invcnbr = lbl_factura.Text.Trim();
                f.invtid = txt_cve.Text.Trim();
                f.ID_Surt_Art = ID_Surt_Art;
                f.lblcaja.Text = caja;
                f.lbl_loc_surt.Text = loc;
                f.localizacion = loc;
                f.tot_cantsol = cant_sol; 
                f.Text = "Surtir Articulo:" + txt_cve.Text.Trim();
                f.ShowDialog();
                
                this.Visible = true;
                if (f.excepcion)
                {
                    int tot_arts_ps = Global.total_articulos_ps_zonas(Global.invcnbr);
                    if (tot_arts_ps == 0)
                    {
                        Global.finalizar_status_zona_area_picking1(Global.invcnbr, IdZona, Area, "SO");
                        limpiar_articulo();
                        this.Close();
                    }
                    else
                    {
                        limpiar_articulo();
                        timer1.Enabled = true;
                        return;
                    }

                   
                }
                else
                {
                    int tot_arts_ps = Global.total_articulos_ps_zonas(Global.invcnbr);                  
                    if (tot_arts_ps == 0)
                    {
                        Global.finalizar_status_zona_area_picking1(Global.invcnbr, IdZona, Area, "SO");
                        limpiar_articulo();
                        this.Close();
                       
                    }
                    else
                    {
                        limpiar_articulo();
                        timer1.Enabled = true;
                        return;
                       
                    }
                
                }

            }
            else if(Global.picking != 1)
            {
                string loc = "";
                this.Visible = false; ;
                timer1.Enabled = false;  
                timer2.Enabled = false;
                t1.Enabled = false;
                timer_timeout.Enabled = false;  
                frm_surtir_articulo f = new frm_surtir_articulo();
                f.invcnbr = lbl_factura.Text.Trim();
                f.invtid = txt_cve.Text.Trim();
                f.ID_Surt_Art = ID_Surt_Art;
                if (Global.cajap2 != "")
                {
                    f.lblcaja.Text = Global.cajap2;
                }
                else
                {
                    frm_leer_carrito f2 = new frm_leer_carrito();
                    f2.invcnbr = invcnbr;
                    this.Visible = false;
                    f.ShowDialog();
                    if (Global.cajap2 == "")
                    {
                        MessageBox.Show("Seleccionar Carrito Correctamente");
                        this.Visible = true;
                        timer2.Enabled = true;
                        t1.Enabled = true;
                        f.Dispose(); 
                        return;
                    }
                    else
                    {
                        f.lblcaja.Text = Global.cajap2;
                    }

                }

                if (loc_act != lbl_loc_surt.Text.Trim())
                {
                    frm_leer_loc f3 = new frm_leer_loc();
                    f3.invcnbr = invcnbr;
                    f3.lbl_loc.Text = lbl_loc_surt.Text.Trim().ToUpper();
                    f3.ShowDialog();
                    if (!f3.ok)
                    {
                        this.Visible = true;
                        f3.Dispose();
                        return;
                    }
                    loc = f3.txt_loc.Text.Trim().ToUpper();
                    f3.Dispose();
                    if (loc != lbl_loc_surt.Text.Trim()   )
                    {
                        this.Visible = true;
                        timer1.Enabled = true;
                        return;
                    }

                    f.lbl_loc_surt.Text = loc;
                    loc_act = loc;

               }
                else
                {
                    f.lbl_loc_surt.Text = loc_act;
                
                }
                
                f.Text = "Surtir Articulo:" + txt_cve.Text.Trim();
                f.ShowDialog();

                if (f.status == "E")
                {
                   
                    int tot_arts_ps = Global.total_articulos_por_surtir_picking2(Global.invcnbr);
                    if (tot_arts_ps > 0)
                    {
                        this.Visible = true;
                        limpiar_articulo();
                        timer1.Enabled = true;
                        return;
                    }
                    else
                    {
                        Global.actualiza_status_zona(Global.invcnbr, IdZona, "SO");
                        this.Close();
                    }

                }
                else
                {
                    int tot_arts_ps = Global.total_articulos_por_surtir_picking2(Global.invcnbr);
                    if (tot_arts_ps > 0)
                    {
                        this.Visible = true;
                        limpiar_articulo();
                        timer1.Enabled = true;
                        return;
                    }
                    else
                    {
                        Global.actualiza_status_zona(Global.invcnbr, IdZona, "SO");
                        this.Close();
                    }
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            msjsurtirarticulo();
        }

        private void frm_leer_articulos_Closing(object sender, CancelEventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            timer_timeout.Enabled = false;
            t1.Enabled = false;  
        }

        private void btn_excep_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            t1.Enabled = false;
            timer_timeout.Enabled = false;  
            frm_excepciones f = new frm_excepciones();
            f.invcnbr = invcnbr;
            f.invtid = txt_cve.Text.Trim();
            f.ID_Surt_Art = ID_Surt_Art; 
            f.ShowDialog();
            if (f.OK)
            {
                f.Dispose();
                limpiar_articulo();
                timer1.Enabled = true;
                timer2.Enabled = true;
                t1.Enabled = true;
                timer_timeout.Enabled = true;  
            }
            else
            {
                timer1.Enabled = true;
                timer2.Enabled = true;
                t1.Enabled = true;
                timer_timeout.Enabled = true;  
            }
           
        }

        private void t1_Tick(object sender, EventArgs e)
        {
            if (invcnbr  != "")
            {
                t1.Enabled = false;
                Global.verificar_satus_factura();
                if (Global.status_factura != "SO")
                {
                    timer1.Enabled = false;
                    timer2.Enabled = false;  
                    System.Media.SystemSounds.Exclamation.Play();
                    
                    MessageBox.Show("****FACTURA CANCELADA****", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    limpiar_datos();
                   

                }
                else
                {
                    t1.Enabled = true;
                }
            }
            else
            {
                Global.factura = "";
                Global.status_factura = "";

            }
        }

        private void timer_timeout_Tick(object sender, EventArgs e)
        {
            if (Global.TimeOutPicking())
            {
                System.Media.SystemSounds.Exclamation.Play();     
            }
        }

    }
}