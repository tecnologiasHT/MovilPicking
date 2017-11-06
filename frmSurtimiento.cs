using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;

namespace Picking
{
  

    public partial class frmSurtimiento : Form
    {
        public frmSurtimiento()
        {
            InitializeComponent();
        }
        public string invcnbr;
        public string status; //status de la orden
        public string custid; //clave del cliente
        public string cliente; //nombre del cliente
        public string tipo_cliente; //tipo de cliente
        public int prioridad_surt; //indica la prioridad 
        public bool env_junto; // esta variable nos indica si la factura debe surtirse con otras facturas
        public int tot_ps_area;//total de articulos por surtir del area
        public int tot_ps_zona; //total de articulos por surtir de la zona
        public int tot_cajas;
        public string Idzona_rec = ""; //variable para guardar la zona donde estan las cajas pend. de recibir
        public int tot_cajas_pend_rec = 0; //total de cajas pendientes de recibir
        public int tot_arts_ps = 0;
        public bool parar = false;
        public string status_zona_factura=""; //Se utiliza para guardar el status actual de la factura en la zona
        public bool alerta = false;
       PickingWS.WebService1 ws=new Picking.PickingWS.WebService1();
        
       
       

    


        public bool obtener_factura_pick1_zona1()
        {
            //ADN_obtener_factura_pick1_zona1
            //@Surtidor VARCHAR(50)
            SqlCommand cmd = new SqlCommand();
            DataSet dt = new DataSet();
            DataRow dr;
            
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_obtener_factura_pick1_zona1";
            cmd.Parameters.AddWithValue("@Surtidor", Global.usuario);
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
                                Global.invcnbr = dr["InvcNbr"].ToString().Trim();
                                txt_factura.Text = dr["InvcNbr"].ToString().Trim();
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                                //@InvcNbr=InvcNbr,
                                //@Shipperid=Shipperid,
                                //@status=Status,
                                //@Prioridad= Prioridad

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


        public bool obtener_factura_pick1_zona2()
        {
            //ADN_obtener_factura_pick1_zona2
            //@Surtidor VARCHAR(50)
            SqlCommand cmd = new SqlCommand();
            DataSet dt = new DataSet();
            DataRow dr;
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_obtener_factura_pick1_zona2";
            cmd.Parameters.AddWithValue("@Surtidor", Global.usuario);
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
                                Global.invcnbr = dr["InvcNbr"].ToString().Trim();
                                txt_factura.Text = dr["InvcNbr"].ToString().Trim();
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                            //@InvcNbr=InvcNbr,
                            //@Shipperid=Shipperid,
                            //@status=Status,
                            //@Prioridad= Prioridad

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







        void msjalerta()
        {

            if (alerta)
            {
                if (lbl_msj.BackColor == Color.White)
                {
                    lbl_msj.BackColor = Color.Black;
                    lbl_msj.Refresh(); 
                }
                else
                {
                    lbl_msj.BackColor = Color.White;
                    lbl_msj.Refresh();
                }
            }
            else
            {
                lbl_msj.BackColor = Color.White;
                lbl_msj.Refresh();
            }

        }


      

        string obtener_factura_enviar(int idzona, int sigzona  )
        {
            // [dbo].[ADN_Obtener_factura_turno]
            //-- Add the parameters for the stored procedure here
            //@IdZona int
            //"@SigZona"
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Obtener_factura_turno";
            cmd.Parameters.AddWithValue("@IdZona", idzona);
            cmd.Parameters.AddWithValue("@SigZona", sigzona);
            
            try
            {
                if (Global.cn.State == ConnectionState.Closed)
                {
                    Global.cn.Open();
                }

                return cmd.ExecuteScalar().ToString().Trim();

            }
            catch
            {
                return "";
            }


        }
        
        void lista_art_surtir(string factura)
        { 
           //ADN_Obtener_lista_art_surtir2	
           //@InvcNbr varchar(20),
           //@IdPicking INT,
           //@Usuario VARCHAR(50)

            DataSet dt = new DataSet();
            try
            {
               dt=Global.lista_art_surtir(factura);
                if (dt != null)
                {
                    if (dt.Tables.Count > 0)
                    {
                        dgarticulos.DataSource = dt.Tables[0];
                    }
                    else
                    {
                        dgarticulos.DataSource = null; 
                    }

                }
                else
                {
                    dgarticulos.DataSource = null;  
                }

            }
            catch
            {
                MessageBox.Show("Error al obtener lista de articulos por surtir"); 
                dgarticulos.DataSource = null;
            }


        }

        bool verifica_factura_picking2(string factura)
        {
            //Funcion verifica el usuario que tomo la factura de picking2
            StringBuilder cad = new StringBuilder();
            cad.Append("SELECT InvcNbr, IdZona, Status, Usuario, CarritoNo, Activo FROM   ADN_surtimiento_zona ");
            cad.AppendLine("WHERE InvcNbr=@InvcNbr AND IdZona in(5,6,11) AND Activo=1");
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet dt = new DataSet();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = cad.ToString(); 
            cmd.Parameters.AddWithValue("@InvcNbr", factura.Trim());
            cmd.Parameters.AddWithValue("@IdZona", Global.idzona);           
            da.SelectCommand = cmd;
            DataRow dr;
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
                            if (!string.IsNullOrEmpty(dr["Activo"].ToString()))
                            {
                                if (Convert.ToBoolean(dr["Activo"].ToString()) == true)
                                {
                                    if (!string.IsNullOrEmpty(dr["Usuario"].ToString()))
                                    {
                                        if (dr["Usuario"].ToString() != "")
                                        {
                                            if (dr["Usuario"].ToString().Trim() != Global.usuario)
                                            {
                                                //La factura ya fue tomada por otro usuario
                                                return false;
                                            }
                                            else
                                            {
                                                //la factura fue tomada por el usuario actual
                                                return true;
                                            }

                                        }
                                        else
                                        {
                                            //la factura no la ha tomado ningun usuario
                                            return true;
                                        }

                                    }
                                    else
                                    {
                                        //la factura no la ha tomado ningun usuario
                                        return true;
                                    }
                                }
                                else
                                {
                                    //El status SO ya no esta activo, ya fue surtida
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
             
        void agregar_cajas()
        {

            frm_cajas_picking f = new frm_cajas_picking();
            f.lbl_factura.Text = txt_factura.Text;
            f.invcnbr = Global.invcnbr;    
            f.ShowDialog();
            f.Dispose();
        }

        string obtener_factura_pend(int idzona)
        {
            //obtiene el numero de la factura de las cajas pendientes de recepcion
            // ADN_Obtener_factura_cajas_pend_rec	
            //@Id_Zona INT
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Obtener_factura_cajas_pend_rec";
            cmd.Parameters.AddWithValue("@Id_Zona", idzona);

            try
            {
                if (Global.cn.State == ConnectionState.Closed)
                {
                    Global.cn.Open();
                }
                string fac = "";
                fac = cmd.ExecuteScalar().ToString().Trim()  ;
                return fac;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener factura.." + ex.Message.ToString());
                return "";
            }


        }

        void surtimiento()
        {
            //procedimiento para abrir la pantalla donde se capturan los articulos
            Cursor.Current = Cursors.WaitCursor;
            tot_cajas = Global.tot_cajas_factura(Global.invcnbr);
            if (tot_cajas == 0)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("No hay cajas para surtir,agregar cajas", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return ;
            }
            Global.totales_ps_area_zona(Global.invcnbr,out tot_ps_area,out tot_ps_zona);   
            if (tot_ps_area == 0 )
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("No hay articulos para surtir en su area", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return ;
            }
           
            frm_leer_articulos1 f = new frm_leer_articulos1();
            f.invcnbr = invcnbr.Trim();
            f.invcnbr_status = false;
            f.lbl_factura.Text = invcnbr.Trim();
            f.timer1.Enabled = true;  
            f.ShowDialog();
            f.Dispose();
            Cursor.Current = Cursors.Default;

           
            
        }

        bool verificar_transito(int idzona,string factura)
        {
            //Funcion para verificar si existe el Status TRAN o SO en la zona de la factura
            //ADN_verificar_zona_transito	
            //@InvcNbr VARCHAR(10),
            //@IdZona int
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_verificar_zona_transito";
            cmd.Parameters.AddWithValue("@IdZona", idzona);
            cmd.Parameters.AddWithValue("@InvcNbr", factura);
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
                MessageBox.Show("Error la verificar zona en transito.." + ex.Message.ToString());  
                return false;
            }

           
        }

        bool Surtir_Factura(string factura)
        {

            try
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                datos_factura(factura);
                tot_cajas = Global.tot_cajas_factura(Global.invcnbr);
                lista_cajas();
                int pend = 0;
                pend = (Convert.ToInt16(txt_partidas.Text) - Convert.ToInt16(txt_part_surtidas.Text));
                btn_ver.Enabled = true;
                btn_cajas.Enabled = true;
                btn_ver.Enabled = true;

                Global.totales_ps_area_zona(Global.invcnbr, out tot_ps_area, out tot_ps_zona);
                if (tot_ps_area > 0)
                {
                    timer2.Enabled = false;
                    timer1.Enabled = false; 
                    lbl_msj.Text = "Surtir FACTURA:" + invcnbr;
                    btn_aceptar.Enabled = true;
                    btn_aceptar.Focus();
                    return true;
                }
                else if (tot_ps_zona > 0)
                {
                    btn_aceptar.Enabled = false;
                    lbl_msj.Visible = true;
                    lbl_msj.Text = "Espere un momento.., hay articulos pendientes por surtir en su ZONA";
                    timer1.Enabled = true;                  
                    timer2.Enabled = true;              
                    return true; 
                }
                else
                {
                    
                    timer1.Enabled = true;
                    return false;
                  
                }
            } //try
            catch (Exception ex)
            {
                MessageBox.Show("Error en procedimiento Surtir_Factura.." + ex.Message.ToString());
                return false;
            }
        
        }

        string factura_pend_usuario()
        { 
        // ADN_factura_pend_usuario
        //@IdZona INT,
        //@Usuario varchar(50)
            SqlCommand cmd = new SqlCommand();            
            cmd.Connection = Global.cn;            
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_factura_pend_usuario";
            cmd.Parameters.AddWithValue("@IdZona",Global.idzona );
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario);
            try
            {               
                if (Global.cn.State == ConnectionState.Closed)
                {
                    Global.cn.Open();
                }
                string invcnbr = cmd.ExecuteScalar().ToString().Trim();
                if (!string.IsNullOrEmpty(invcnbr))
                {
                    return invcnbr;
                }
                else
                {
                    return "";
                }

                


            }
            catch(Exception ex)
            {
                return "";
            }



        
        }


        void obtener_factura_transito(int id_zona,out string invcnbr, out int tot_cajas,out string status)
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
                                status=dr["Status"].ToString().Trim();
                            }
                            else
                            {
                             status="";
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

        bool agregar_status_zona(string invcnbr,int idzona,string status)
        { 
           //ADN_agregar_status_zonas	
           //@InvcNbr VARCHAR(10),
           //@IdZona INT,
           //@Picking int
          //@Status varchar(20)
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_agregar_status_zonas";
            cmd.Parameters.AddWithValue("@InvcNbr", invcnbr);
            cmd.Parameters.AddWithValue("@IdZona", idzona);
            cmd.Parameters.AddWithValue("@Picking", Global.picking);
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
                return false ;
            }


        }
   

        int tot_status_zona_usuario(int idzona, string status)
        {

        //  ADN_tot_status_zona_usuario 
        //-- Add the parameters for the stored procedure here
        //@IdZona INT,
        //@status VARCHAR(50),
        //@Usuario VARCHAR(50

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_tot_status_zona_usuario";
            cmd.Parameters.AddWithValue("@IdZona", idzona);
            cmd.Parameters.AddWithValue("@status", status);
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario );

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
                MessageBox.Show("Error al obtener Total Status ZONA" + ex.Message.ToString());
                return -1;
            }


        }



        int tot_status_zona(int idzona, string status)
        {
            
            // ADN_tot_status_zona
            //@IdZona INT,
            //@status VARCHAR(50)
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_tot_status_zona";
            cmd.Parameters.AddWithValue("@IdZona", idzona);
            cmd.Parameters.AddWithValue("@status", status);
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
                MessageBox.Show("Error al obtener disponibilidad en la ZONA" + ex.Message.ToString());
                return -1;
            }

        
        }
        

        int tot_so_zona2()
        {
            //[dbo].[ADN_obtener_disponibilidad_zona2]
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_obtener_disponibilidad_zona2";
            
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
                MessageBox.Show("Error al obtener disponibilidad en la ZONA "  + ex.Message.ToString());
                return -1;
            }

        }

        bool obtener_disponibilidad(int idzona)
        { 
          //ADN_obtener_disponibilidad_zona	
	      //@Id_Zona int
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_obtener_disponibilidad_zona";
            cmd.Parameters.AddWithValue("@Id_Zona",idzona);
            da.SelectCommand = cmd; 
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
                MessageBox.Show("Error al obtener disponibilidad en la ZONA: " + idzona.ToString() + " " + ex.Message.ToString()  );  
                return false;
            }


        }

        void lista_cajas()
        {
            //ADN_Obtener_lista_cajas 
            //@InvcNbr varchar(15)
            DataSet dt = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Obtener_lista_cajas";
            cmd.Parameters.AddWithValue("@InvcNbr", Global.invcnbr);
            ad.SelectCommand = cmd;
            try
            {
                ad.Fill(dt);
                lst_cajas.Items.Clear();  
                if (dt != null)
                {
                    if (dt.Tables.Count != 0)
                    {
                        if (dt.Tables[0].Rows.Count != 0)
                        {
                            foreach (DataRow dr in dt.Tables[0].Rows )
                            {
                                if (!string.IsNullOrEmpty(dr["Caja#"].ToString()))
                                {
                                    lst_cajas.Items.Add(dr["Caja#"].ToString().Trim() + "(" + dr["Articulos"].ToString().Trim() + ")");  
                                }
                                
                            }
                            tot_cajas = Global.tot_cajas_factura(Global.invcnbr);
   
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar cajas.." + ex.Message.ToString());
            }
        }

      

        void limpiar_datos()
        {
            tot_cajas = 0;
            tot_ps_zona = 0;
            tot_ps_zona = 0; 
            txt_factura.Text = "";            
            invcnbr="";
            Global.invcnbr = "";
            Global.factura = "";
            lbl_shiperid.Text = "0";
            txt_prioridad.Text   = "";
            txt_cajas.Text = "";  
            txt_partidas.Text = "";            
            txt_part_surtidas.Text = "";  
            status = "";
            custid = "";
            cliente = "";
            prioridad_surt = 0;
            tipo_cliente = "";
            lbl_msj.Text = "";
            lbl_msj.Text="Espere un momento...";  
            lst_cajas.Items.Clear();
            dgarticulos.DataSource = null;
            txt_leyenda.BackColor = Color.White;
            txt_leyenda.Text = "";
        }
        bool avanzar_zona(string InvcNbr)
        {
            //avanza la factura indicada a la siguiente zona de surtimiento
            //ADN_surtimiento_avanzar_zona
            //@InvcNbr
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            DataSet dt = new DataSet();
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

        void obtener_sig_zona_surtimiento( out int id_zona,out string zona)
        { 
            //Procedimiento para obtener la siguiente zona por surtir de la factura
          //ADN_obtener_sig_Zona_surtimiento	
          //@InvcNbr VARCHAR(10)
            //datos columnas
            //IdZona
            //Zona
            //Orden
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter ad = new SqlDataAdapter();
                cmd.Connection = Global.cn;
                DataSet dt = new DataSet();
                DataRow dr;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ADN_obtener_sig_Zona_surtimiento";
                cmd.Parameters.AddWithValue("@InvcNbr", Global.invcnbr);
                ad.SelectCommand = cmd;
                try
                {
                    ad.Fill(dt);
                    if (dt != null)
                    {
                        if (dt.Tables.Count != 0)
                        {
                            dr = dt.Tables[0].Rows[0];
                            if (!string.IsNullOrEmpty(dr["IdZona"].ToString()))
                            {
                                id_zona = Convert.ToInt16(dr["IdZona"].ToString());
                            }
                            else
                            {
                                id_zona = -1;
                            }

                            if (!string.IsNullOrEmpty(dr["Zona"].ToString()))
                            {
                                zona = dr["Zona"].ToString();
                            }
                            else
                            {
                                zona = "";
                            }


                        }
                        else
                        {
                            id_zona = -1;
                            zona = "";
                        }
                    }
                    else
                    {
                        id_zona = -1;
                        zona = "";
                    }
                }
                catch (Exception ex)
                {
                    id_zona = -1;
                    zona = "";
                }
        
        }
    
       

      bool obtener_factura()
       {
        // ADN_obtener_orden_surtimiento
          //@InvcNbr VARCHAR(15) OUTPut
          //@Surtidor VARCHAR(50),
          //@Tot INT OUTPUT --facturas pendientes de surtir 
           timer1.Enabled = false;
           invcnbr = "";
           lbl_msj.Text = "Obteniendo Nueva Factura....";  
           SqlCommand cmd = new SqlCommand();
           DataSet dt = new DataSet();
           SqlDataAdapter da = new SqlDataAdapter();
           DataRow dr;
           
               cmd.Connection = Global.cn;             
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.CommandText = "ADN_obtener_factura_area";
               cmd.Connection = Global.cn;
               cmd.Parameters.AddWithValue("@IdArea", Global.area);
               cmd.Parameters.AddWithValue("@IdZona", Global.idzona);               
               da.SelectCommand = cmd;
               try
               {
               da.Fill(dt);
               if (dt.Tables.Count != 0)
               {
                   if (dt.Tables[0].Rows.Count != 0)
                   {
                       dr = dt.Tables[0].Rows[0];
                       if (!string.IsNullOrEmpty(dr["InvcNbr"].ToString()))
                       {

                           txt_factura.Text   = dr["InvcNbr"].ToString().Trim();
                           invcnbr = dr["InvcNbr"].ToString().Trim();
                           Global.invcnbr = dr["InvcNbr"].ToString().Trim();
                           //datos_factura();
                           if (!string.IsNullOrEmpty(dr["Prioridad"].ToString().Trim()))
                           {
                               prioridad_surt = Convert.ToInt16(dr["Prioridad"].ToString().Trim());
                               txt_prioridad.Text = dr["Prioridad"].ToString().Trim();
                           }
                           else
                           {
                               txt_prioridad.Text = "";
                               prioridad_surt = 0;
                           }

                           if (!string.IsNullOrEmpty(dr["Shipperid"].ToString().Trim()))
                           {
                               lbl_shiperid.Text = dr["Shipperid"].ToString().Trim();
                           }

                           if (!string.IsNullOrEmpty(dr["Partidas"].ToString().Trim()))
                           {
                              txt_partidas.Text   = dr["Partidas"].ToString().Trim();
                           }
                           else
                           {
                               txt_partidas.Text = "0";
                           }

                          

                           //Status_area
                           if (!string.IsNullOrEmpty(dr["Status_area"].ToString().Trim()))
                           {
                               status_zona_factura = dr["Status_area"].ToString().Trim();
                           }
                           else
                           {
                              status_zona_factura = "";
                           }
                           btn_ver.Enabled = false;
                           lbl_msj.Visible = false;  
                           return true;
                       }
                       else
                       {
                           lbl_msj.Text = "Espere..Obteniendo factura para surtir";
                           lbl_msj.Visible = true;  
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
                           txt_factura.Text = fact.Trim();
                           invcnbr = fact.Trim();
                           datos_factura(invcnbr);
                           return true;
                       }
                       else
                       {
                           lbl_msj.Text = "Espere..Obteniendo factura para surtir";
                           lbl_msj.Visible = true;
                           return false;
                       }
                   }
               }
               else
               {
                   lbl_msj.Text = "Espere..Obteniendo factura para surtir";
                   lbl_msj.Visible = true;
                   return false;
               }
           }
           catch (Exception ex)
           {
               dt.Dispose();
               da.Dispose();
               Cursor.Current = Cursors.Default;
               cmd.Dispose();
               lbl_msj.Visible = true;  
               lbl_msj.Text = "Error al obtener Factura." ;
               return false;
           }

       }

      bool obtener_factura_picking1()
      { 
          //*OBSOLETO PARA PIVA*****
        //ADN_obtener_orden_surtimiento_picking1]
        //@Surtidor VARCHAR(50),
        //@Zona varchar(50)
          timer1.Enabled = false;
          lbl_msj.Text = "Espere un momento, Obteniendo Factura..";  
           SqlCommand cmd = new SqlCommand();
          cmd.Connection=Global.cn;  
           DataSet dt = new DataSet();
           SqlDataAdapter da = new SqlDataAdapter();
           DataRow dr;
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.CommandText = "ADN_obtener_orden_surtimiento_picking1";
               cmd.Connection = Global.cn;          
               cmd.Parameters.AddWithValue("@Surtidor",Global.usuario.Trim());
               cmd.Parameters.AddWithValue("@IdZona",Global.idzona);
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
                          if (!string.IsNullOrEmpty(dr["InvcNbr"].ToString()))
                          {
                              txt_factura.Text = dr["InvcNbr"].ToString().Trim();
                              invcnbr = dr["InvcNbr"].ToString().Trim();
                              Global.factura = dr["InvcNbr"].ToString().Trim();
                              Global.invcnbr = invcnbr;
                              if (!string.IsNullOrEmpty(dr["Prioridad"].ToString().Trim()))
                              {
                                  prioridad_surt = Convert.ToInt16(dr["Prioridad"].ToString().Trim());
                                  txt_prioridad.Text = dr["Prioridad"].ToString().Trim();
                              }
                              else
                              {
                                  txt_prioridad.Text = "";
                                  prioridad_surt = 0;
                              }
                              if (!string.IsNullOrEmpty(dr["Shipperid"].ToString().Trim()))
                              {
                                  lbl_shiperid.Text = dr["Shipperid"].ToString().Trim();
                              }
                              if (!string.IsNullOrEmpty(dr["env_junto"].ToString().Trim()))
                              {
                                  env_junto = Convert.ToBoolean(dr["env_junto"].ToString().Trim());
                              }
                              else
                              {
                                  env_junto = false;
                              }

                              btn_ver.Enabled = false;
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
                          dt.Dispose();
                          cmd.Dispose();
                          dr = null;
                          MessageBox.Show("No hay facturas para surtir, intente otra vez");
                          limpiar_datos();
                          btn_ver.Enabled = true;
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
               lbl_msj.Text= "Error al obtener factura..." + ex.Message.ToString();
               System.Media.SystemSounds.Beep.Play();
               System.Threading.Thread.Sleep(5000);   
               return false;
           }
      
      }

      bool obtener_factura_picking2()
      {
            //ADN_Obtener_Factura_Picking2           
            //@IdZona INT,
            //@Usuario VARCHAR(50)
          timer1.Enabled = false;
          lbl_msj.Text = "Espere un momento, Obteniendo Factura..";
          SqlCommand cmd = new SqlCommand();
          cmd.Connection = Global.cn;
          DataSet dt = new DataSet();
          SqlDataAdapter da = new SqlDataAdapter();
          DataRow dr;
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.CommandText = "ADN_Obtener_Factura_Picking2";
          cmd.Connection = Global.cn;
          cmd.Parameters.AddWithValue("@Usuario", Global.usuario.Trim());
          cmd.Parameters.AddWithValue("@IdZona", Global.idzona);
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
                  if (dt.Tables.Count > 0)
                  {
                      if (dt.Tables[0].Rows.Count != 0)
                      {
                          dr = dt.Tables[0].Rows[0];
                          if (!string.IsNullOrEmpty(dr["InvcNbr"].ToString()))
                          {
                              txt_factura.Text = dr["InvcNbr"].ToString().Trim();
                              invcnbr = dr["InvcNbr"].ToString().Trim();
                              Global.factura = dr["InvcNbr"].ToString().Trim();
                              Global.invcnbr = invcnbr;
                              btn_ver.Enabled = false;
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
              lbl_msj.Text = "Error al obtener factura... + " + ex.Message.ToString();
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
           cmd.Parameters.AddWithValue("@InvcNbr", factura);
           cmd.Parameters.AddWithValue("@Usuario", Global.usuario.Trim()   );
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

       bool pendiente(string factura)
       {
           //Funcion para verificar el numero de partidas pendientes de surtir de la factura
           //ADN_obtenert_tot_partidas_surt
           //@InvcNbr varchar(20)
           SqlCommand cmd = new SqlCommand();
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.CommandText = "ADN_obtenert_tot_partidas_surt";
           cmd.Parameters.AddWithValue("@InvcNbr", factura.Trim());
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
           catch (Exception ex)
           {
               MessageBox.Show("Error al obtener partidas pendientes de surtir..." + ex.Message.ToString());  
               return false;
           }

       }

       void datos_factura(string factura)
       {
           //ADN_obtener_datos_factura
           //@InvcNbr varchar(50),
           //@Shipperid varchar(50)
            //ADN_FacturasSurtimiento.Status, 
            //Herramientas.dbo.SOShipHeader.CustID, 
            //Herramientas.dbo.Customer.Name, 
            //Herramientas.dbo.Customer.ClassId,
            //@tot_partidas AS Tot_Partidas,
            //@tot AS Total
           string tipo = "";
           
           if (factura == null || factura == "")
           {
               return;
           }
 
           DataSet dt = new DataSet();
           DataRow dr;
           try
           {
               
               dt = Global.obtener_datos_factura(factura.Trim(), lbl_shiperid.Text.Trim());
               if (dt != null)
               {
                   if (dt.Tables[0].Rows.Count != 0)
                   {
                       dr = dt.Tables[0].Rows[0];
                       if (!string.IsNullOrEmpty(dr["Status"].ToString()))
                       {
                           status = dr["Status"].ToString().Trim();
                       }
                       if (!string.IsNullOrEmpty(dr["CustID"].ToString()))
                       {
                           custid = dr["CustID"].ToString();
                       }

                       if (!string.IsNullOrEmpty(dr["Name"].ToString()))
                       {
                           cliente = dr["Name"].ToString();
                       }

                       if (!string.IsNullOrEmpty(dr["ClassId"].ToString()))
                       {
                           tipo_cliente = dr["ClassId"].ToString().Trim();
                       }

                       if (!string.IsNullOrEmpty(dr["Tot_Partidas"].ToString()))
                       {
                           txt_partidas.Text = dr["Tot_Partidas"].ToString();
                       }
                       else
                       {
                           txt_partidas.Text = "0";
                       }

                       if (!string.IsNullOrEmpty(dr["tot_surtidas"].ToString()))
                       {
                           txt_part_surtidas.Text = dr["tot_surtidas"].ToString();
                       }
                       else
                       {
                           txt_part_surtidas.Text = "0";
                       }
                       if (!string.IsNullOrEmpty(dr["Prioridad"].ToString()))
                       {
                           txt_prioridad.Text = dr["Prioridad"].ToString();
                       }
                       else
                       {
                           txt_prioridad.Text = "";
                       }

                       if (!string.IsNullOrEmpty(dr["Vip"].ToString()))
                       {

                           if (Convert.ToBoolean(dr["Vip"].ToString()) == true)
                           {
                               tipo = "VIP";
                           }

                       }
                       if (!string.IsNullOrEmpty(dr["loc"].ToString()) && tipo == "")
                       {
                           if (Convert.ToBoolean(dr["loc"].ToString()) == true)
                           {
                               tipo = "LOCAL";
                           }

                       }

                       if (!string.IsNullOrEmpty(dr["ClassId"].ToString()))
                       {
                           if (dr["ClassId"].ToString() == "TOC")
                           {
                               tipo = "TOC";
                           }

                       }

                       if (!string.IsNullOrEmpty(dr["tot_env_junto"].ToString()))
                       {
                           if (Convert.ToInt16(dr["tot_env_junto"].ToString()) > 0)
                           {
                               tipo = "JUNTOS";
                           }

                       }
                       switch (tipo)
                       {
                           case "TOC":
                               txt_leyenda.BackColor = Color.HotPink;
                               txt_leyenda.Text = "TOC";
                               break;
                           case "OA":
                               txt_leyenda.BackColor = Color.Red;
                               txt_leyenda.Text = "OA";
                               txt_leyenda.ForeColor = Color.White;
                               break;
                           case "LOCAL":
                               txt_leyenda.BackColor = Color.Goldenrod;
                               txt_leyenda.Text = "LOCAL";
                               break;
                           case "VIP":
                               txt_leyenda.BackColor = Color.Orange;
                               txt_leyenda.Text = "VIP";
                               break;
                           case "JUNTOS":
                               txt_leyenda.BackColor = Color.Silver;
                               txt_leyenda.Text = "SURT.JUNTO(" + dr["tot_env_junto"].ToString().Trim() + ")";
                               break;
                           default:
                               txt_leyenda.Text = dr["ClassId"].ToString().Trim();
                               txt_leyenda.BackColor = Color.White;
                               txt_leyenda.ForeColor = Color.Black;

                               break;
                       }

                       lista_art_surtir(txt_factura.Text);
                   }
                   dt.Dispose();
               }
              
             
           }
           catch (Exception ex)
           {
               Cursor.Current = Cursors.Default;
               if (dt != null)
               {
                   dt.Dispose();
               }
               lbl_msj.Visible = true;  
               lbl_msj.Text=  "Error al obtener datos de Factura.." ;  
           }
       }
        

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
          
            Cursor.Current = Cursors.Default;
            Global.fecha_ultima_actividad = Global.FechaHoraActual();
            timer_timeout.Enabled = false;  
            tot_cajas = Global.tot_cajas_factura(Global.invcnbr);
            if (tot_cajas == 0)
            {
                Cursor.Current = Cursors.Default;
                timer_timeout.Enabled = true; 
                MessageBox.Show("No hay cajas para surtir,agregar cajas", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }   
        
            if (Global.picking != 1)
            {
                if (Global.tot_art_ps_picking2(Global.invcnbr) > 0)
                {
                    timer1.Enabled = false;
                    t1.Enabled = false;
                    timer_timeout.Enabled = false; 
                    if (Global.cajap2 == "")
                    {
                        frm_leer_carrito f1 = new frm_leer_carrito();
                        f1.invcnbr = Global.invcnbr;                       
                        this.Visible = false;
                        alerta = false;
                        msjalerta();
                        f1.ShowDialog();
                        if (Global.cajap2 == "")
                        {
                            MessageBox.Show("Seleccionar Carrito o Canasta Correctamente","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Exclamation ,MessageBoxDefaultButton.Button1   );
                            this.Visible = true;
                            timer1.Enabled = true;
                            return;
                        }
                        
                    }
                    
                    frm_leer_articulos1 f = new frm_leer_articulos1();
                    f.invcnbr = invcnbr.Trim();                  
                    
                    f.lbl_factura.Text = invcnbr.Trim();
                    f.tipocaja = "CARRITO";                    
                    f.timer1.Enabled = true;
                    alerta = false;
                    msjalerta();
                    f.ShowDialog();
                    f.Dispose();
                    Cursor.Current = Cursors.Default;
                    this.Show();
                    timer1.Enabled = true;
                    t1.Enabled = true;  
                }
                else
                {
                    MessageBox.Show("No Hay Articulos Para Surtir En PICKING2");  
                
                }
                return;
            }
            else if (Global.picking==1)
            {
                 //verificar los articulos por surtir
                 int tot_ps_zonas = Global.total_articulos_ps_zonas(Global.invcnbr);               
                 if (tot_ps_zonas > 0)
                {
                    timer1.Enabled = false;
                    t1.Enabled = false;  
                    frm_leer_articulos1 f = new frm_leer_articulos1();
                    f.invcnbr = Global.invcnbr;
                    f.lbl_factura.Text = Global.invcnbr;                    
                    f.tipocaja = "CAJA";
                    f.timer1.Enabled = true;
                    alerta = false;
                    msjalerta();
                    f.ShowDialog();
                    f.Dispose();
                    Cursor.Current = Cursors.Default;
                    this.Show();
                    timer1.Enabled = true;
                    t1.Enabled = true;  
                    return;
                }
                else
                {
                    int IdZona1=0;
                     IdZona1 = Global.ObtenerIdZonaSurtimientoFactura(Global.invcnbr);
                     if (IdZona1 > 0)
                     {
                         int tot_ps_zonas1 = Global.TotPartidasStatusZonaFactura(Global.invcnbr, IdZona1, "PS");
                         if (tot_ps_zonas1 > 0)
                         {
                             timer1.Enabled = false;
                             t1.Enabled = false;
                             frm_leer_articulos1 f = new frm_leer_articulos1();
                             f.invcnbr = Global.invcnbr;
                             f.lbl_factura.Text = Global.invcnbr;
                             f.tipocaja = "CAJA";
                             f.timer1.Enabled = true;
                             alerta = false;
                             msjalerta();
                             f.ShowDialog();
                             f.Dispose();
                             Cursor.Current = Cursors.Default;
                             this.Show();
                             timer1.Enabled = true;
                             t1.Enabled = true;
                             return;

                         }
                         else
                         {
                             MessageBox.Show("No Hay Articulos Para Surtir En La Zona");
                             return;
                         }
                     }
                     else
                     {
                         MessageBox.Show("No Hay Articulos Para Surtir");
                         return;
                     }
                    
                }
            
            }

            
  
           

        }

        private void frmSurtimiento_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
            if (Global.picking == 2)
            {
                timer_timeout.Enabled = false;  
            }
            timer1.Enabled = true;  

        }


        private void frmSurtimiento_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "F1":
                    {
                        if (btn_aceptar.Enabled    == true)
                        {
                            btn_aceptar_Click(this, EventArgs.Empty);                           
                             
                        }
                            break;
                    }
                
                case "F3":
                    {

                        if (btn_ver.Enabled == true)
                        {

                            btn_ver_Click(this, EventArgs.Empty); 
                        
                        }
                     
                       break;
                    }
                    case "F4":
                    {

                        if (btn_cajas.Enabled == true)
                      {
                          btn_cajas_Click(this, EventArgs.Empty); 
                      }
                       break;
                    }

                case "F10":
                    {
                        btn_salir_Click(this, EventArgs.Empty);   
                        break;
                    }

                default:
                 break;
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_msj.Text = "";
            if (Global.invcnbr == "" || Global.invcnbr == null)
            {
                limpiar_datos();
                if (txt_factura.Text != "")
                {
                    Global.invcnbr = txt_factura.Text.Trim();
                    return;
                }
                lbl_msj.Text = "Espere un momento, Obteniendo Factura...";
                //Obtenemos la nueva factura para surtir
                lbl_msj.Visible = true;
                if (Global.orden_zona == 1)
                {
                    timer1.Enabled = false;
                    int tot_fact_activas = Global.tot_facturas_activas_zonas();
                    if (tot_fact_activas > 0)
                    {
                        //obtenemos la factura que esta activa                        
                        string fac = "";
                        fac = Global.factura_pend_zonas_usuario();
                        if (fac != "")
                        {
                            Global.fecha_ultima_actividad = Global.FechaHoraActual();

                            System.Media.SystemSounds.Exclamation.Play();
                            txt_factura.Text = fac.Trim();
                            Global.invcnbr = fac.Trim();
                            invcnbr = fac;
                            datos_factura(Global.invcnbr);
                            txt_cajas.Text = Global.tot_cajas_factura(Global.invcnbr).ToString();
                            lista_cajas();
                            timer1.Enabled = true;
                            return;

                        }
                        else
                        {
                            fac=Global.factura_pend_zonas();
                            if (fac != "")
                            {
                                Global.fecha_ultima_actividad = Global.FechaHoraActual();
                                System.Media.SystemSounds.Exclamation.Play();
                                txt_factura.Text = fac.Trim();
                                Global.invcnbr = fac.Trim();
                                invcnbr = fac;
                                datos_factura(Global.invcnbr);
                                txt_cajas.Text = Global.tot_cajas_factura(Global.invcnbr).ToString();
                                lista_cajas();
                                timer1.Enabled = true;
                                return;

                            }
                            else
                            {
                                timer1.Enabled = true;
                                return;
                            
                            }

                        }
                    }
                    else if (tot_fact_activas == 0)                        
                    { 
                      //OBTENER UNA NUEVA FACTURA PARA SURTIR 
                      //verificar las facturas que tengan turno activo
                        string fac = "";
                        //pruebas
                        fac = Global.obtener_factura_turno_zonas_orden1();

                        if (fac == "" || fac==null)
                        {
                           fac = Global.factura_por_surtir_zonas_orden1();
                        }

                            if (fac != "")
                            {
                                Global.fecha_ultima_actividad = Global.FechaHoraActual();
                                int idzona = Global.obtener_zona_inicio_picking1();
                                if (idzona > 0)
                                {
                                    Global.idzona = idzona;
                                }                                   
                                    System.Media.SystemSounds.Exclamation.Play();
                                    txt_factura.Text = fac.Trim();
                                    Global.invcnbr = fac.Trim();
                                    invcnbr = fac;
                                    datos_factura(Global.invcnbr);
                                    txt_cajas.Text = Global.tot_cajas_factura(Global.invcnbr).ToString();
                                    lista_cajas();
                                    timer1.Enabled = true;
                                    return;                                                             
                            }
                            else
                            {
                                timer1.Enabled = true;
                                return;

                            }
                        }
                        else if (tot_fact_activas == 1)
                        {
                            timer1.Enabled = true;
                            return;
                        }
                        else
                        {
                            timer1.Enabled = true;
                            return;
                        
                        }
                    
                    
                  

                } // if (Global.orden_zona == 1)
                else if (Global.picking == 1)
                {
                    //PICKING1***
                    //********************
                    string fac = "";
                    int IdZona=0;
                   
                        if(Global.tot_facturas_activas_zonas()==0)
                        {
                        //verificamos si hay facturas en turno de la zona 
                            if (Global.tot_facturas_turno_zonas() > 0)
                            {
                                //obtener la factura en turno de la zona o zonas seleccionadas
                                if (Global.obtener_factura_turno_zonas(out fac, out IdZona))
                                {
                                    if (fac != "" && fac != null)
                                    {
                                        //antes de tomar la factura verificar otra vez que no haya otra factura activa
                                        if (Global.tot_facturas_activas_zonas() == 0)
                                        {
                                            if (IdZona > 0)
                                            {
                                                int sigzona = Global.obtener_siguiente_zona_por_surtir_P1(fac);
                                                if (sigzona > 0)
                                                {
                                                    if (sigzona == 8 || sigzona == 7 || sigzona == 6 || sigzona == 5)
                                                    {
                                                        MessageBox.Show("La Factura: " + fac + " Todavia tiene articulos por surtir en la Zona: " + sigzona.ToString(), "ALERTA!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                                                        Global.actualizar_turno_activo_factura(fac);
                                                        Global.actualizar_status_zonas(fac);
                                                        Global.actualizar_status_factura(fac, "PS");
                                                        timer1.Enabled = true;
                                                        return;
                                                    }
                                                    else
                                                    {
                                                        Global.fecha_ultima_actividad = Global.FechaHoraActual();
                                                        Global.invcnbr = fac.Trim();
                                                        System.Media.SystemSounds.Exclamation.Play();
                                                        txt_factura.Text = fac;
                                                        invcnbr = fac.Trim();
                                                        datos_factura(Global.invcnbr);
                                                        txt_cajas.Text = Global.tot_cajas_factura(Global.invcnbr).ToString();
                                                        timer1.Enabled = true;
                                                        return;
                                                    }
                                                }
                                                else
                                                {
                                                    int tot_ps_p1 = Global.obtener_total_articulos_por_surtir_P1(fac);
                                                    if (tot_ps_p1 == 0)
                                                    {
                                                       datos_factura(Global.invcnbr);                                                        
                                                        System.Media.SystemSounds.Exclamation.Play();
                                                        alerta = true;
                                                        msjalerta();
                                                        lbl_msj.Text = "No hay articulos para surtir en PICKING1 Mover Cajas";
                                                        txt_factura.Text = fac;
                                                        invcnbr = fac.Trim();
                                                        Global.invcnbr = fac.Trim();
                                                        btn_mover.Enabled = true;
                                                        timer1.Enabled = true;
                                                        return;
                                                    }
                                                    else
                                                    {
                                                        timer1.Enabled = true;
                                                        return;
                                                    }
                                                
                                                }
                                            }
                                            else
                                            {
                                                timer1.Enabled = true;
                                                return;
                                            }


                                        }
                                        else //if(Global.tot_facturas_activas_zona(Global.idzona)==0)
                                        {
                                            //obtener la factura que ya esta activa en la zona
                                            fac = Global.factura_pend_zonas();
                                            if (fac != "")
                                            {
                                                Global.fecha_ultima_actividad = Global.FechaHoraActual(); 
                                                System.Media.SystemSounds.Exclamation.Play();
                                                txt_factura.Text = fac.Trim();
                                                Global.invcnbr = fac.Trim();
                                                invcnbr = fac;
                                                datos_factura(Global.invcnbr);
                                                timer1.Enabled = true;
                                                return;
                                            }
                                            else
                                            {
                                                alerta = true;
                                                msjalerta();
                                                lbl_msj.Text = "Esperando Factura Para Surtir";
                                                timer1.Enabled = true;
                                                return;
                                            }

                                        } //if(Global.tot_facturas_activas_zona(Global.idzona)==0)
                                    }
                                    else
                                    {
                                        alerta = true;
                                        msjalerta();
                                        lbl_msj.Text = "Esperando Factura Para Surtir";
                                        timer1.Enabled = true;
                                        return;

                                    }
                                }
                                else
                                {
                                    alerta = true;
                                    msjalerta();
                                    lbl_msj.Text = "Esperando Factura Para Surtir";
                                    timer1.Enabled = true;
                                    return;
                                }
                            }
                            else
                            {
                                alerta = true;
                                msjalerta();
                                lbl_msj.Text = "Esperando Factura Para Surtir";
                                timer1.Enabled = true;
                              return;
                            }
                            
                        }
                        else
                        {
                            //si existen facturas activas
                            fac = Global.factura_pend_zonas();
                            if (fac != "")
                            {
                                int idzona = Global.obtener_zona_inicio_picking1();
                                if (idzona > 0)
                                {
                                    //PARA ELIMINAR
                                    Global.fecha_ultima_actividad = Global.FechaHoraActual(); 
                                    System.Media.SystemSounds.Exclamation.Play();
                                    txt_factura.Text = fac.Trim();
                                    Global.invcnbr = fac.Trim();
                                    invcnbr = fac;
                                    datos_factura(Global.invcnbr);
                                    timer1.Enabled = true;
                                    return;
                                }
                                else
                                {
                                    timer1.Enabled = true;
                                    return;
                                }
                                
                                
                            }
                            else
                            {
                                timer1.Enabled = true;
                                return;
                            }
                        
                        
                        }

                    //FIN PICKING1***
                    //********************
                }//**FIN** if ( Global.picking ==1)
                else if (Global.picking == 2)
                {
                    //**PICKING2
                    string fac = "";                    
                    //Obtener el idzona de picking2
                    int IdZonaP2 = Global.Obtener_IdZona_Picking2();
                    if (IdZonaP2 <= 0)
                    {                        
                        IdZonaP2 = int.Parse(Properties.Resources.idzonap2.ToString());
                    }
                    Global.idzona = IdZonaP2;

                    fac = Global.Obtener_factura_pend_usuario_Pick2();

                    if(fac =="" ) 
                    {
                        //obtenemos la factura que tenga prioridad 0= URGENTE
                        fac = Global.obtener_factura_URGENTE_P2();

                        if (fac == "" || fac == null)
                        {
                            //obtener las facturas con prioridad 1-3 que son prioritarias pero menos urgentes
                            fac = Global.obtener_factura_prioridad_picking2(); 
                        }

                        if (fac == "" || fac == null)
                        {
                            //obtenemos la factura en turno que no tenga prioridad                           
                            fac = Global.obtener_factura_turno_picking2(Global.idzona);
                            
                        }                                               

                        if (fac != "" && fac != null)
                        {
                            //Global.actualizar_status_zonas(fac);
                            Global.fecha_ultima_actividad = Global.FechaHoraActual(); 
                            System.Media.SystemSounds.Exclamation.Play();
                            txt_factura.Text = fac;
                            invcnbr = fac.Trim();
                            Global.invcnbr = fac.Trim();
                            Global.factura = fac.Trim();
                            datos_factura(Global.invcnbr);                           
                            timer1.Enabled = true;
                            return;
                        }
                        else
                            if (obtener_factura_picking2())
                            {
                                Global.fecha_ultima_actividad = Global.FechaHoraActual(); 
                                System.Media.SystemSounds.Exclamation.Play();
                                datos_factura(Global.invcnbr);
                                Global.agregar_turno_factura(Global.invcnbr, 1, IdZonaP2);
                                timer1.Enabled = true;
                                return;
                            }
                            else
                            {
                                timer1.Enabled = true;
                                return;

                            }


                    }
                    else // if(fac !="" )
                    {
                      //si hay una factura pendiente de surtir de el usuario
                           string status = Global.obtener_status_factura(fac);

                           if (status == "SO" || status == "PS")
                           {
                               Global.fecha_ultima_actividad = Global.FechaHoraActual(); 
                               System.Media.SystemSounds.Exclamation.Play();
                               txt_factura.Text = fac.Trim();
                               invcnbr = fac;
                               Global.invcnbr = fac.Trim();
                               datos_factura(Global.invcnbr);
                               System.Media.SystemSounds.Exclamation.Play();
                               timer1.Enabled = true;
                               return;
                           }
                           else
                           {
                               MessageBox.Show("La Factura " + fac + ", No Esta En surtimiento");
                               Global.actualizar_status_zonas(fac);
                               Global.actualizar_turno_activo_factura(fac);
                               timer1.Enabled = true;
                               return; 
                           
                           }

                     }
                       

                } //if (Global.picking == 2)

            } //if (Global.invcnbr == "" || Global.invcnbr == null)
            else
            {
                timer1.Enabled = false;
                btn_ver.Enabled = true;
                btn_cajas.Enabled = true;
                lbl_msj.Visible = true;
                if (Global.picking == 1)
                {
                    //verificar si la factura todavia esta activa en la zona
                    if (!Global.verificar_transito(Global.invcnbr))
                    {
                        Global.invcnbr = "";
                        invcnbr = "";
                        txt_factura.Text = "";
                        timer1.Enabled = true;
                        return;
                    }
                }
                   
                txt_factura.Text = Global.invcnbr;
                //obtener el status actual de la factura
                string status1 = Global.obtener_status_factura(Global.invcnbr);
                if (status1 != "")
                {
                    if (status1 != "SO")
                    {
                        switch (status1)
                        {
                            case "X":
                                System.Media.SystemSounds.Exclamation.Play();
                                MessageBox.Show("La Factura: " + Global.invcnbr + "Ha Sido Cancelada Para Surtimiento", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                                break;

                            case "RR":
                                System.Media.SystemSounds.Exclamation.Play();
                                MessageBox.Show("La Factura: " + Global.invcnbr + "Ha Sido Retenida Para Surtimiento", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                                break;

                            case "RF":
                                System.Media.SystemSounds.Exclamation.Play();
                                MessageBox.Show("La Factura: " + Global.invcnbr + "Esta En Revision, Surtimiento Cancelado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                                break;


                            default:
                                System.Media.SystemSounds.Exclamation.Play();
                                MessageBox.Show("La Factura: " + Global.invcnbr + "No Esta En Surtimiento, Notificar A Supervisor", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                                break;
                        }
                        Global.actualizar_status_zonas(Global.invcnbr);
                        Global.actualizar_turno_activo_factura(Global.invcnbr);
                        Global.invcnbr = "";
                        Global.cajap2 = "";
                        limpiar_datos();
                        timer1.Enabled = true;
                        return;

                    }
                   

                }
                else
                {
                    MessageBox.Show("Error al verificar el status de la Factura: " + Global.invcnbr + " ,Verificar que el equipo este conectado correctamente a la red inalambrica", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    timer1.Enabled = true;
                    return;
                    
                
                }


                lista_cajas();
                //obtener el total de cajas
                tot_cajas =Global.tot_cajas_factura(Global.invcnbr);
                //obtener el total de articulos por surtir
                tot_arts_ps = Global.Obtener_total_arts_pend_surtir_factura(Global.invcnbr);

                txt_cajas.Text = tot_cajas.ToString();
                //obetner las partidas por surtir en las zonas
                lista_art_surtir(Global.invcnbr);
                
                //Verificar el numero de cajas pendientes de recibir en la zona                   
                //Totales por surtir en las zonas seleccionadas
                if (Global.picking == 1)
                {
                    if (tot_cajas == 0)
                    {
                        alerta = true;
                        msjalerta();
                        System.Media.SystemSounds.Hand.Play();
                        lbl_msj.Text = "Agregar Cajas Para Surtir..";
                        btn_recibir_cajas.Enabled = false;
                        btn_mover.Enabled = false;
                        btn_aceptar.Enabled = false;
                        timer1.Enabled = true;
                        return;
                    }
                   
                    lista_cajas();
                    Global.tot_cajas_pend_recibir_zonas(Global.invcnbr, out Idzona_rec, out tot_cajas_pend_rec);
                    if (Idzona_rec != "")
                    {
                        alerta = true;
                        msjalerta();
                        System.Media.SystemSounds.Hand.Play();
                        lbl_msj.Text = "Recibir Cajas De La Factura En ZONA " + Idzona_rec + " CAJAS:" + tot_cajas_pend_rec.ToString();
                        btn_recibir_cajas.Enabled = true;
                        btn_mover.Enabled = false;
                        btn_aceptar.Enabled = false;
                        timer1.Enabled = true;
                        return;
                    }
                    else
                    {
                        btn_recibir_cajas.Enabled = false;
                    }
                    
                    tot_arts_ps = Global.Obtener_total_arts_pend_surtir_factura(Global.invcnbr);
                    if (tot_arts_ps > 0)
                    {
                        //obtiene el total de partidas por surtir en la zona
                        tot_ps_zona = Global.total_articulos_ps_zonas(Global.invcnbr);                        
                        if (tot_ps_zona > 0)
                        {    
                            //total partidas por surtir en el area o lado
                            int tot_ps_zona_usuario = Global.total_articulos_ps_zonas_usuario(Global.invcnbr);
                            lista_art_surtir(Global.invcnbr);
                            if (tot_ps_zona_usuario > 0)
                            {
                                alerta = true;
                                msjalerta();
                                int idzona1 = 0;
                                string area = "";
                                int tot_arts = 0;
                                //obtener el total de articulos por surtir en el lado de el usuario
                                if (Global.obtener_zona_area_por_surtir(Global.invcnbr, out idzona1, out area, out tot_arts))
                                {
                                    if (idzona1 > 0)
                                    {
                                        if (tot_arts > 0)
                                        {
                                            alerta = true;
                                            System.Media.SystemSounds.Hand.Play();
                                            msjalerta();
                                            lbl_msj.Text = "SURTIR " + tot_arts.ToString() + " PARTIDAS " + "En ZONA " + idzona1.ToString() + " " + area;
                                            msjalerta();
                                            btn_aceptar.Enabled = true;
                                            Global.idzona = idzona1;
                                            btn_aceptar.Enabled = true;
                                            timer1.Enabled = true;
                                            return;
                                        }
                                        else
                                        {
                                            timer1.Enabled = true;
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        timer1.Enabled = true;
                                        return;
                                    }
                                }
                                else
                                {
                                    //Ya no haya articulos para surtir del lado del usuario
                                    System.Media.SystemSounds.Beep.Play();
                                    alerta = true;
                                    msjalerta();
                                    lbl_msj.Text = "No hay Articulos Para Surtir En Su Area, Espere Para Mover Cajas";
                                    msjalerta();
                                    btn_aceptar.Enabled = false;
                                    btn_mover.Enabled = true;
                                    timer1.Enabled = true;
                                    return;
                                }
                            }  //(tot_ps_zona_usuario > 0)
                            else
                            { 
                              //Si No hay articulos para surtir en las zonas del usuario obtener otra factura para surtir
                                if (Global.orden_zona == 1)
                                {
                                    string res = MessageBox.Show("No hay Articulos por surtir de la factura "+ Global.invcnbr +" Desea Obtener Otra?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1).ToString();
                                    if (res == "Yes")
                                    {
                                        if (Global.actualizar_status_factura_usuario(Global.invcnbr))
                                        {
                                            //obtener una nueva factura
                                            string fac = Global.factura_por_surtir_zonas();
                                            if (fac != "")
                                            {
                                                int idzona = Global.obtener_zona_inicio_picking1();                                               
                                                System.Media.SystemSounds.Exclamation.Play();
                                                txt_factura.Text = fac.Trim();
                                                Global.invcnbr = fac.Trim();
                                                invcnbr = fac;
                                                datos_factura(Global.invcnbr);
                                                txt_cajas.Text = Global.tot_cajas_factura(Global.invcnbr).ToString();
                                                lista_cajas();
                                                timer1.Enabled = true;
                                                return;

                                            }
                                            else
                                            {
                                                timer1.Enabled = true;
                                                return;

                                            }
                                        }
                                        else
                                        {
                                            timer1.Enabled = true;
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        System.Media.SystemSounds.Beep.Play();
                                        alerta = true;
                                        msjalerta();
                                        lbl_msj.Text = "No hay Articulos Para Surtir En Su Area, Espere Para Mover Cajas";
                                        btn_aceptar.Enabled = false;
                                        btn_mover.Enabled = true;
                                        timer1.Enabled = true;
                                        return;
                                    }
                                }
                                else
                                {
                                    int IdZona1=0;
                                    //Obtener la zona de surtimiento actual
                                    IdZona1 = Global.ObtenerIdZonaSurtimientoFactura(Global.invcnbr);
                                    if (IdZona1 > 0)
                                    {
                                        //obtener el total de partidas por surtir de la zona
                                        int tot_ps_zonas1 = Global.TotPartidasStatusZonaFactura(Global.invcnbr, IdZona1, "PS");
                                        if (tot_ps_zonas1 > 0)
                                        {
                                            System.Media.SystemSounds.Beep.Play();
                                            alerta = true;
                                            msjalerta();
                                            lbl_msj.Text = "Todavia hay articulos por surtir en la ZONA" + IdZona1.ToString().Trim() + ", Clic en SURTIR";
                                            btn_aceptar.Enabled = true;
                                            btn_mover.Enabled = false;
                                            timer1.Enabled = true;
                                            return;
                                        }
                                        else
                                        {
                                            System.Media.SystemSounds.Beep.Play();
                                            alerta = true;
                                            msjalerta();
                                            lbl_msj.Text = "Surtimiento Terminado en ZONA " + IdZona1.ToString() + "Mover Cajas";
                                            btn_aceptar.Enabled = false;
                                            btn_mover.Enabled = true;
                                            timer1.Enabled = true;
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        System.Media.SystemSounds.Beep.Play();
                                        alerta = true;
                                        msjalerta();
                                        lbl_msj.Text = "Surtimiento Terminado Mover Cajas";
                                        btn_aceptar.Enabled = false;
                                        btn_mover.Enabled = true;
                                        timer1.Enabled = true;
                                        return;
                                    
                                    }
                                   
                                
                                }

                            }


                        }
                        else
                        {
                            // No hay articulos por surtir en las zonas seleccionadas
                            System.Media.SystemSounds.Beep.Play();
                           

                            int tot_ps_arts_p1 = Global.obtener_total_articulos_por_surtir_P1(Global.invcnbr);
                            
                            if (tot_ps_arts_p1 > 0)
                            {
                                alerta = true;
                                msjalerta();
                               System.Media.SystemSounds.Beep.Play();
                               int id_zona = Global.obtener_siguiente_zona_por_surtir_P1(Global.invcnbr);
                               lbl_msj.Text = "MOVER Cajas a  ZONA " + id_zona.ToString();
                               btn_aceptar.Enabled = false;
                               btn_mover.Enabled = true;
                               timer1.Enabled = true;
                               return;                               
                                
                            }
                            else
                            {
                                int tot_ps_arts_p2 = Global.obtener_total_articulos_por_surtir_P2(Global.invcnbr);
                                if (tot_ps_arts_p2 > 0)
                                {
                                    alerta = true;
                                    msjalerta();
                                    System.Media.SystemSounds.Beep.Play();
                                    int id_zona = Global.obtener_siguiente_zona_por_surtir_P1(Global.invcnbr);
                                    lbl_msj.Text = "MOVER Cajas a  PICKING2";
                                    btn_aceptar.Enabled = false;
                                    btn_mover.Enabled = true;
                                    timer1.Enabled = true;
                                    return;
                                }
                                else
                                {
                                    alerta = true;
                                    msjalerta();
                                    System.Media.SystemSounds.Beep.Play();
                                    lbl_msj.Text = "MOVER Cajas a  VALIDACION";
                                    msjalerta();
                                    btn_aceptar.Enabled = false;
                                    btn_mover.Enabled = true;
                                    timer1.Enabled = true;
                                    return; 
                                }

                            }





                        }




                    }
                    else
                    { 
                      //ya no hay articulos para surtir en la factura
                        alerta = true;
                        msjalerta();
                        System.Media.SystemSounds.Exclamation.Play();
                        lbl_msj.Text = "No hay Articulos Para Surtir, MOVER Cajas a VALIDACION";
                        msjalerta();
                        btn_aceptar.Enabled = false;
                        btn_mover.Enabled = true;
                        timer1.Enabled = true;
                        return;
                    }                  
                    
                }

                //Totales por surtir en PICKING2
                if (Global.picking == 2)
                {
                    //VERIFICAR SI HAY CAJAS POR RECIBIR EN LA ZONA1
                    //Obtener el Id de la zona de PICKING2
                    //
                    int IdZona_Picking = Global.Obtener_IdZona_Picking2();
                    if (IdZona_Picking <= 0)
                    {
                        alerta = true;
                        msjalerta();
                        System.Media.SystemSounds.Hand.Play();
                        lbl_msj.Text = "Error al obtener Idzona de PICKING2";
                        btn_recibir_cajas.Enabled = false;
                        btn_mover.Enabled = false;
                        btn_aceptar.Enabled = false;
                        timer1.Enabled = true;
                        return;
                    }
                    else
                    {
                        //alerta = false;
                    }

                    if (tot_cajas == 0)
                    {
                        alerta = true;
                        msjalerta();
                        System.Media.SystemSounds.Hand.Play();
                        lbl_msj.Text = "Agregar Cajas Para Surtir..";
                        btn_recibir_cajas.Enabled = false;
                        btn_mover.Enabled = false;
                        btn_aceptar.Enabled = false;
                        timer1.Enabled = true;
                        return;
                    }

                  tot_arts_ps = Global.Obtener_total_arts_pend_surtir_factura(Global.invcnbr);                 

                  if (tot_arts_ps > 0)
                  {
                      int tot_cajas_pend_rec = Global.tot_cajas_pend_recibir_picking2(Global.invcnbr);
                      if (tot_cajas_pend_rec > 0)
                      {
                          alerta = true;
                          msjalerta();
                          System.Media.SystemSounds.Hand.Play();
                          lbl_msj.Text = "Recibir Cajas De La Factura En ZONA1 ";
                          btn_recibir_cajas.Enabled = true;
                          btn_mover.Enabled = false;
                          btn_aceptar.Enabled = false;
                          timer1.Enabled = true;
                          return;
                      }
                      else
                      {
                          btn_recibir_cajas.Enabled = false;                     
                      
                      }

                      alerta = true;
                      msjalerta(); 
                      btn_aceptar.Enabled = true;
                      System.Media.SystemSounds.Exclamation.Play();
                      lbl_msj.Text = "Tiene " + tot_arts_ps.ToString() + " Articulos " + "Para Surtir En PICKING2 " ;
                      msjalerta();
                      btn_aceptar.Enabled = true;
                      timer1.Enabled = true;
                      return;
                                  
                  }
                  else
                  {
                      alerta = true;
                      msjalerta();
                      System.Media.SystemSounds.Exclamation.Play();
                      lbl_msj.Text = "No hay Articulos Para Surtir, MOVER Cajas a VALIDACION";
                      msjalerta();
                      btn_aceptar.Enabled = false;
                      btn_mover.Enabled = true;
                      timer1.Enabled = true;
                  } // if (tot_arts_ps > 0)
                }//if (Global.picking == 2)


            } //**fin** if (Global.invcnbr == "" || Global.invcnbr == null)

        }


        private void btn_cajas_Click(object sender, EventArgs e)
        {
            if (txt_factura.Text == "")
            {
                return;
            }
            timer1.Enabled = false; 
            if (Global.picking ==2 )
            {
                
                    frm_leer_carrito f2 = new frm_leer_carrito();
                    f2.invcnbr = Global.invcnbr;                   
                    this.Visible = false;
                    f2.ShowDialog();
                    f2.Dispose();
                    lista_cajas();
                    tot_cajas = Global.tot_cajas_factura(Global.invcnbr);
                    timer1.Enabled = true;                  
                
                if (Global.cajap2 == "")
                {
                    lista_cajas();
                    tot_cajas = Global.tot_cajas_factura(Global.invcnbr);
                    Cursor.Current = Cursors.Default;
                    this.Visible = true;
                    timer1.Enabled = true;
                    t1.Enabled = true;
                    return;
                }
                else
                {
                    lista_cajas();
                    tot_cajas = Global.tot_cajas_factura(Global.invcnbr);
                    Cursor.Current = Cursors.Default;
                    this.Visible = true;  
                    timer1.Enabled = true; 
                }
                

            }
            else
            {
                frm_cajas_picking f = new frm_cajas_picking();
                f.lbl_factura.Text = invcnbr;
                f.invcnbr = Global.invcnbr;
                f.ShowDialog();
                f.Dispose();
                lista_cajas();
                tot_cajas = Global.tot_cajas_factura(Global.invcnbr);
                if (Global.idzona == 4 || Global.idzona == 3)
                {
                    Global.totales_ps_area_zona(Global.invcnbr, out tot_ps_area, out tot_ps_zona);

                    if (tot_ps_zona > 0)
                    {
                        Global.surtimiento_status_historial_area_zona(Global.invcnbr, "", "SO", Global.idzona.ToString(), Global.area, 1);
                    }
                    else
                    {
                        Global.surtimiento_status_historial_area_zona(Global.invcnbr, "", "TRAN", Global.idzona.ToString(), Global.area, 1);
                    }

                }

                Cursor.Current = Cursors.Default;
                timer1.Enabled = true; 
            }
            
        }

        private void btn_factura_Click(object sender, EventArgs e)
        {

        }

        private void btn_ver_Click(object sender, EventArgs e)
        {
            if (txt_factura.Text != "")
            {
                timer1.Enabled = false;  
                frm_detalle_factura f = new frm_detalle_factura();
                f.invcnbr = Global.invcnbr;
                f.lbl_factura.Text = Global.invcnbr;     
                f.ShowDialog();
                f.Dispose();
                timer1.Enabled = true;  
            }
        }
              


        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Global.invcnbr != "")
            {
                if (!Surtir_Factura(Global.invcnbr))
                {
                    timer2.Enabled = false; 
                    limpiar_datos();
                    timer1.Enabled = true; 
                }

            }

        }

        private void frmSurtimiento_Closing(object sender, CancelEventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            t1.Enabled = false;
        }

        private void btn_recibir_cajas_Click1(object sender, EventArgs e)
        {
            if (txt_factura.Text != "")
            {
                string idzona = "";
                int tot_cajas = 0;
                timer1.Enabled = false;
                Global.fecha_ultima_actividad = Global.FechaHoraActual();
                //obtener las cajas pendientes por recibir en picking1
                if (Global.picking == 1)
                {
                    //obtener el total de cajas pendientes de recibir
                    Global.tot_cajas_pend_recibir_zonas(Global.invcnbr, out idzona, out tot_cajas);
                    if (tot_cajas > 0)
                    {
                       
                        frm_recepcion_cajas f = new frm_recepcion_cajas();
                        f.lbl_id_zona.Text = idzona;                       
                        f.lbl_factura.Text = Global.invcnbr;
                        this.Visible = false;
                        alerta = false;
                        msjalerta();
                        btn_recibir_cajas.Enabled = true;
                        f.ShowDialog();
                        this.Visible = true;
                        btn_recibir_cajas.Enabled = false;
                        timer1.Enabled = true;
                        Global.fecha_ultima_actividad = Global.FechaHoraActual();
                        timer_timeout.Enabled = true ;
                        return;

                    }
                    else
                    {
                        btn_recibir_cajas.Enabled = false;
                        timer1.Enabled = true;
                        return;
                    
                    }
                }
                else if (Global.picking == 2) //*****************************//
                {
                    Global.fecha_ultima_actividad = Global.FechaHoraActual();
                    timer_timeout.Enabled = false;  
                    int idzonap2 = Global.obtener_idzona_P2();
                    int tot_cajas_pen_rec = Global.tot_cajas_pend_recibir_picking2(Global.invcnbr);
                    if (idzonap2 <= 0)
                    {
                        idzonap2 = int.Parse(Properties.Resources.idzonap2.ToString());
                    }
                    if (tot_cajas_pen_rec > 0)
                    {
                        frm_recepcion_cajas f2 = new frm_recepcion_cajas();
                        f2.lbl_factura.Text = Global.invcnbr;
                        f2.idzona1 = idzonap2;
                        f2.lbl_id_zona.Text = idzonap2.ToString();
                        this.Hide();
                        alerta = false;
                        msjalerta();
                        f2.ShowDialog();
                        tot_cajas_pen_rec = Global.tot_cajas_pend_recibir_picking2(Global.invcnbr);
                        f2.Dispose();
                        if (tot_cajas_pen_rec > 0)
                        {
                            MessageBox.Show("Recepcion de cajas incompleta, Intente Otra Vez");
                            btn_recibir_cajas.Enabled = true;
                            timer1.Enabled = true;
                            this.Show();
                            return;
                        }
                        else if (tot_cajas_pen_rec == 0)
                        {
                            btn_recibir_cajas.Enabled = false;
                            frm_leer_carrito f = new frm_leer_carrito();
                            f.invcnbr = Global.invcnbr;
                            this.Hide();
                            alerta = false;
                            msjalerta();
                            f.ShowDialog();

                            if (Global.cajap2 == "" || Global.cajap2 == null)
                            {
                                lbl_msj.Text = "Seleccionar Carrito Para PICKING2 Correctamente";
                                MessageBox.Show("Seleccionar Carrito Para PICKING2 Correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                                timer1.Enabled = true;
                                timer_timeout.Enabled = true;  
                                this.Show();
                                return;
                            }
                            else
                            {
                                f.Dispose();
                                btn_aceptar.Enabled = true;
                                timer1.Enabled = true;
                                Global.fecha_ultima_actividad = Global.FechaHoraActual();
                                timer_timeout.Enabled = true;  
                                this.Show();
                                return;

                            }
                        } //else if(tot_cajas_pen_rec ==0)
                        else
                        {
                            timer1.Enabled = true;
                            Global.fecha_ultima_actividad = Global.FechaHoraActual();
                            timer_timeout.Enabled = true; 
                            this.Show();
                            return;
                        }


                    }
                    else if (tot_cajas_pen_rec == 0)
                    {
                        frm_leer_carrito f = new frm_leer_carrito();
                        f.invcnbr = Global.invcnbr;
                        this.Hide();
                        alerta = false;
                        msjalerta();
                        f.ShowDialog();
                        if (Global.cajap2 == "" || Global.cajap2 == null)
                        {
                            lbl_msj.Text = "Seleccionar Carrito Para PICKING2 Correctamente";
                            MessageBox.Show("Seleccionar Carrito Para PICKING2 Correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                            this.Show();
                            timer1.Enabled = true;
                            return;
                        }
                        else
                        {
                            this.Show();
                            timer1.Enabled = true;
                            return;
                        }

                    }
                    else
                    {
                        btn_recibir_cajas.Enabled = true;
                        MessageBox.Show("Error al obtener total cajas pendientes de recibir");
                        this.Show();
                        timer1.Enabled = true;
                        return;

                    }

                }
                else
                {
                    btn_recibir_cajas.Enabled = true;
                    MessageBox.Show("Error Picking no valido");
                    this.Show();
                    timer1.Enabled = true;
                    return;
                }
                   
                
                }                
           
        }

        private void btn_mover_Click(object sender, EventArgs e)
        {


            if (txt_factura.Text != "")
            {
                timer1.Enabled = false;
                int tot_ps = 0;
                int id_zona = 0;
                string area = "";
                int tot_arts = 0;                

                if (Global.picking == 1)
                {
                    tot_ps = Global.total_articulos_ps_zonas(txt_factura.Text.Trim());
                    if (tot_ps > 0)
                    {
                        Global.obtener_zona_area_por_surtir(txt_factura.Text, out id_zona, out area, out tot_arts);
                        if (tot_arts > 0)
                        {
                        MessageBox.Show("Tiene " + tot_arts.ToString() + " Articulos Para Surtir En La Zona:" + id_zona.ToString() + " " + area);
                        timer1.Enabled = true;
                        return;
                        }
                        else
                        {
                            MessageBox.Show("Todavia Existen Articulos Por Surtir En Las Zonas Seleccionadas");
                            timer1.Enabled = true;
                            return;
                        }
                    }
                    else if (tot_ps == 0)
                    {
                        timer1.Enabled = false;
                        timer2.Enabled = false;
                        t1.Enabled = false;
                        frm_cajas_transito f = new frm_cajas_transito();
                        if (Global.total_articulos_status(Global.invcnbr, "PS") > 0)
                        {
                            f.status = "E";
                        }
                        else
                        {

                            f.status = "V";


                        }
                        try
                        {
                            f.lbl_factura.Text = Global.invcnbr;
                            f.invcnbr = Global.invcnbr;
                            f.timer1.Enabled = true;
                            btn_mover.Enabled = false;
                            btn_recibir_cajas.Enabled = false;
                            this.Visible = false;
                            alerta = false;
                            msjalerta();
                            f.ShowDialog();
                            f.Dispose();
                            this.Visible = true;
                            this.Show();
                            limpiar_datos();
                            timer1.Enabled = true;
                            t1.Enabled = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error.." + ex.Message.ToString());
                        }



                    }
                    else
                    {

                        MessageBox.Show("Error al comprobar articulos por surtir, Intente de nuevo");
                        timer1.Enabled = true;
                        t1.Enabled = true;
                    }

                }
                else if (Global.picking == 2)
                {
                    tot_ps = Global.total_articulos_por_surtir_picking2(txt_factura.Text.Trim());

                    Global.fecha_ultima_actividad = Global.FechaHoraActual();
                    timer_timeout.Enabled = false;
                    if (tot_ps > 0)
                    {
                        btn_aceptar.Enabled = true;
                        MessageBox.Show("Todavia existen articulos por surtir en PICKING2");
                        timer1.Enabled = true;
                        return;

                    }
                    else if (tot_ps == 0)
                    {
                        timer1.Enabled = false;
                        timer2.Enabled = false;
                        t1.Enabled = false;
                        frm_cajas_transito f = new frm_cajas_transito();                       
                        f.status = "E";                        
                        try
                        {
                            f.lbl_factura.Text = Global.invcnbr;
                            f.invcnbr = Global.invcnbr;
                            f.timer1.Enabled = true;
                            btn_mover.Enabled = false;
                            btn_recibir_cajas.Enabled = false;
                            this.Visible = false;
                            alerta = false;
                            msjalerta();
                            f.ShowDialog();
                            f.Dispose();
                            this.Visible = true;
                            this.Show();
                            limpiar_datos();
                            timer1.Enabled = true;
                            t1.Enabled = true;
                            timer_timeout.Enabled = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error.." + ex.Message.ToString());
                        }


                    }
                    else
                    {
                        MessageBox.Show("Error al obetener total de articulos por surtir, Intente otra vez ");
                        timer1.Enabled = true;
                        return;
                    }


                }
                else
                {
                    MessageBox.Show("Error Picking No Valido, Salir y seleccionar picking correctamente");
                    timer1.Enabled = true;
                    return;
                
                }
            }
          


        }

        private void t1_Tick(object sender, EventArgs e)
        {
            if (Global.invcnbr != "")
            {
                t1.Enabled = false;
                Global.verificar_satus_factura();
                if (Global.status_factura == "X" || Global.status_factura == "RR" || Global.status_factura == "RF")
                {
                    System.Media.SystemSounds.Exclamation.Play();
                    lbl_msj.Text = "****FACTURA CANCELADA****";
                    MessageBox.Show("****FACTURA CANCELADA****NOTIFICAR AL SUPERVISOR", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    limpiar_datos();
                    Global.actualizar_status_zonas(Global.invcnbr);
                    Global.actualizar_turno_activo_factura(Global.invcnbr);                    
                    btn_aceptar.Enabled = false;
                    btn_recibir_cajas.Enabled = false;
                    btn_mover.Enabled = false;
                    lbl_msj.Text = "";
                    timer1.Enabled = true;

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

        private void txt_factura_TextChanged(object sender, EventArgs e)
        {
            if (txt_factura.Text != "")
            {
                Global.factura = txt_factura.Text.Trim();
                t1.Enabled = true; 
            }
            else
            {
                t1.Enabled = false;
                Global.factura = "";
                Global.status_factura = "";  
               
            }
        }

        private void timer_surtimiento_Tick(object sender, EventArgs e)
        {

            if (Global.idzona == 4 || Global.idzona == 3)
            {

                try
                {
                    if (tot_so_zona2() <= 0)
                    {
                       
                            if (Global.tot_cajas_pend_recibir_zona(2) == 0)
                            {
                                int tot_env = Global.facturas_por_enviar(Global.idzona,2);
                                if (tot_env > 0)
                                {
                                    string cad = obtener_factura_enviar(Global.idzona,2);
                                    if (cad != null)
                                    {
                                        if (Global.mover_cajas(cad.Trim(), 2))
                                        {
                                            Global.actualizar_turno_factura(cad.Trim(), Global.idzona, 2);
                                            if (Global.actualiza_status_zona(cad, Global.idzona, "PEV"))
                                            {

                                            }
                                        }

                                    }
                                }
                            }
                    }
                }
                catch
                {
                }
            }

        }

        private void btn_salir_Click(object sender, EventArgs e)
        {

            timer1.Enabled = false;
            timer2.Enabled = false;
            t1.Enabled = false;
            timer_timeout.Enabled = false;
            if (txt_factura.Text != "")
            {
                if (Global.picking ==2)
                {
                    int tot_ps = Global.total_articulos_por_surtir_picking2(txt_factura.Text.Trim());
                    int tot_ps_p1 = Global.obtener_total_articulos_por_surtir_P1(txt_factura.Text.Trim());
                    string status = Global.obtener_status_factura(Global.invcnbr);
                    if (tot_ps_p1 > 0 && (status == "SO" || status == "PS"))
                    {
                        MessageBox.Show("Esta Factura tiene partidas pendientes de surtir en PICKING1");
                        Global.actualizar_status_zonas(Global.invcnbr);
                        Global.actualizar_turno_activo_factura(Global.invcnbr);
                        Global.actualizar_status_factura(Global.invcnbr, "PS");
                        Global.invcnbr = "";
                        Global.cajap2 = "";
                        limpiar_datos();
                        this.Close();
                    }


                    if (tot_ps > 0 && (status == "SO" || status == "PS"))
                    {
                        string res = MessageBox.Show("Todavia Tiene Articulos Por Surtir..La Factura Se Asiganara A Otro Usuario" + " Desea Salir?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2).ToString();

                        if (res == "Yes")
                        {
                            frm_supervisor f = new frm_supervisor();
                            f.ShowDialog();

                            if (f.ok)
                            {

                                if (Global.salir_factura_picking2(Global.invcnbr))
                                {
                                    Global.invcnbr = "";
                                    Global.cajap2 = "";
                                    limpiar_datos();
                                    this.Close();
                                }
                                else
                                {
                                    timer1.Enabled = true;
                                    t1.Enabled = true;
                                    return;

                                }
                            }
                            else
                            {
                                timer1.Enabled = true;
                                t1.Enabled = true;
                                return;
                            
                            }
                        }
                        else
                        {
                            timer1.Enabled = true;
                            t1.Enabled = true;
                            timer_timeout.Enabled = true;
                            return;
                        }
                    }
                    else if (tot_ps == 0 && (status == "SO" || status == "PS")
                        )
                        {

                        if (Global.Enviar_Validacion(Global.invcnbr))
                        {
                            int idzona_val = Global.obtener_idzona_validacion();
                            int idzonap2 = Global.Obtener_IdZona_Picking2();
                            Global.actualizar_status_zonas(Global.invcnbr);
                            Global.actualizar_turno_activo_factura(Global.invcnbr);
                            Global.mover_cajas_validacion(Global.invcnbr);
                            Global.agregar_turno_factura(Global.invcnbr, idzonap2, idzona_val);
                            Global.invcnbr = "";
                            Global.cajap2 = "";
                            limpiar_datos();
                            this.Close();

                        }
                        else
                        {
                            if (Global.salir_factura_picking2(Global.invcnbr))
                            {
                                Global.invcnbr = "";
                                Global.cajap2 = "";
                                limpiar_datos();
                                this.Close();
                            }
                            else
                            {
                                timer1.Enabled = true;
                                t1.Enabled = true;
                                timer_timeout.Enabled = true;
                                return;

                            }

                        }

                    }
                    else
                    {
                        MessageBox.Show("Error al salir");
                        timer1.Enabled = true;
                        t1.Enabled = true;
                        timer_timeout.Enabled = true;
                        return;

                    
                    }

                } //if (Global.picking ==2)
                else if (Global.picking == 1)
                {
                    int tot_arts_ps = Global.total_articulos_ps_zonas_usuario(Global.invcnbr);
                    if (Global.orden_zona == 1)
                    {
                        if (tot_arts_ps > 0)
                        {
                            string res = MessageBox.Show("Todavia Tiene Articulos Por Surtir..La Factura Se Asiganara A Otro Usuario" + "Desea Salir?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2).ToString();
                            if (res == "Yes")
                            {
                                if (Global.salir_factura_picking1_orden1(Global.invcnbr))
                                {
                                    Global.invcnbr = "";
                                    limpiar_datos();
                                    this.Close();
                                }
                                else
                                {
                                    timer1.Enabled = true;
                                    t1.Enabled = true;
                                    timer_timeout.Enabled = true;
                                    return;

                                }
                            }
                            else
                            {
                                timer1.Enabled = true;
                                t1.Enabled = true;
                                return;
                            }
                        }
                        else
                        {
                             string res = MessageBox.Show("Tiene una factura en surtimiento, Desea Salir?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2).ToString();
                             if (res == "Yes")
                             {

                                 if (Global.salir_factura_picking1_orden1(Global.invcnbr))
                                 {
                                     Global.invcnbr = "";
                                     limpiar_datos();
                                     this.Close();
                                 }
                                 else
                                 {
                                     timer1.Enabled = true;
                                     t1.Enabled = true;
                                     timer_timeout.Enabled = true;
                                     return;

                                 }
                             }
                             else
                             {
                                 timer1.Enabled = true;
                                 t1.Enabled = true;
                                 timer_timeout.Enabled = true;
                                 return;
                             }
                        
                        }

                    }
                    else
                    {
                        if (tot_arts_ps > 0)
                        {
                            string res = MessageBox.Show("Todavia Tiene Articulos Por Surtir En La Factura Actual. " + "Desea Salir?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2).ToString();
                            if (res == "Yes")
                            {
                                if (Global.salir_factura_picking1(Global.invcnbr))
                                {
                                    Global.invcnbr = "";
                                    limpiar_datos();
                                    this.Close();
                                }
                                else
                                {
                                    timer1.Enabled = true;                                    
                                    t1.Enabled = true;
                                    timer_timeout.Enabled = true;
                                    return;

                                }
                            }
                            else
                            {
                                timer1.Enabled = true;
                                t1.Enabled = true;
                                timer_timeout.Enabled = true;
                                return;
                            }
                        }
                        else
                        {
                            string res = MessageBox.Show("Tiene una factura en surtimiento, Desea Salir?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2).ToString();
                            if (res == "Yes")
                            {

                                if (Global.salir_factura_picking1(Global.invcnbr))
                                {
                                    Global.invcnbr = "";
                                    limpiar_datos();
                                    this.Close();
                                }
                                else
                                {
                                    timer1.Enabled = true;
                                    t1.Enabled = true;
                                    timer_timeout.Enabled = true;
                                    return;

                                }
                            }
                            else
                            {
                                timer1.Enabled = true;
                                t1.Enabled = true;
                                timer_timeout.Enabled = true;
                                return;
                            }

                        }
                    
                    }
                   

                   

                }
                else
                {
                    Global.invcnbr = "";
                    this.Close();
                
                }

            }
            else //if (txt_factura.Text != "")
            {
               Global.invcnbr = "";
               Global.cajap2 = "";
               this.Close();
            }


        }

        private void frmSurtimiento_Closing_1(object sender, CancelEventArgs e)
        {
            timer_timeout.Enabled = false;
            timer1.Enabled = false;
            timer2.Enabled = false;
            t1.Enabled = false;
        }

        private void timer_timeout_Tick(object sender, EventArgs e)
        {
            
            if(Global.picking==1 )
            {
                if (Global.invcnbr != "")
                {
                    //verificar si hay articulos por surtir
                    if (Global.total_articulos_ps_zonas(Global.invcnbr) > 0)
                    {
                        if (Global.total_articulos_ps_zonas_usuario(Global.invcnbr) > 0)
                        {
                            if (Global.TimeOutPicking())
                            {
                                System.Media.SystemSounds.Exclamation.Play();
                                
                            }
                        }

                    }
                    else
                    { 
                     //si ya no tienen articulos por surtir, se debe mover la factura a la sig zona o validacion
                     //aplicar Timeout por no mover las cajas
                        if (Global.TimeOutPicking())
                        {
                            System.Media.SystemSounds.Exclamation.Play();
                            timer_timeout.Enabled = false;
                            timer1.Enabled = false;
                            t1.Enabled = false;
                            string cad_usuario = "";
                            cad_usuario = Global.usuario;
                            cad_usuario = cad_usuario + "-" + Global.NombreUsuario(Global.usuario);
                            Global.fecha_ultima_actividad = Global.FechaHoraActual();
                            timer_timeout.Enabled = true;
                            timer1.Enabled = true;
                            t1.Enabled = true;
                           
                        }


                    }
                }
            }
        }

        private void btnIndicadores_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            timer2.Enabled = false;
            t1.Enabled = false;
            timer_timeout.Enabled = false;
            frmIndicadores f = new frmIndicadores();
            f.ShowDialog();
            f.Dispose();
            timer1.Enabled = true;
            timer2.Enabled = true;
            t1.Enabled = true;
            timer_timeout.Enabled = true;
        }

    }
}