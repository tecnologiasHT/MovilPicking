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
    public partial class frm_cajas_transito : Form
    {
        public frm_cajas_transito()
        {
            InitializeComponent();
        }
        public string invcnbr = "";
        public string status = "";
        public bool alerta = false;

        bool agregar_turno_factura(string factura,int idzona,int sigzona)
        { 
        // ALTER PROCEDURE  [dbo].[ADN_Agregar_turno_factura] 
        //  Add the parameters for the stored procedure here
        //@InvcNbr varchar(20), 
        //@IdZona int, 
        //@SigZona int
            SqlCommand cmd = new SqlCommand();
            //SqlDataAdapter da = new SqlDataAdapter();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Agregar_turno_factura";
            cmd.Parameters.AddWithValue("@InvcNbr", factura);
            cmd.Parameters.AddWithValue("@IdZona", idzona);
            cmd.Parameters.AddWithValue("@SigZona", sigzona);
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
                MessageBox.Show("Error al agregar turno de Factura " + ex.Message.ToString());
                return false;
            }


        }


        bool verificar_factura_usuario(string factura)
        { 
        // ALTER PROCEDURE ADN_Verificar_factura_usuario
        //-- Add the parameters for the stored procedure here
        //@InvcNbr varchar(20),
        //@Id_Zona int,
        //@Usuario varchar(50) 
            SqlCommand cmd = new SqlCommand();
            //SqlDataAdapter da = new SqlDataAdapter();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Verificar_factura_usuario";
            cmd.Parameters.AddWithValue("@InvcNbr",factura);
            cmd.Parameters.AddWithValue("@Id_Zona", Global.idzona);
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario.Trim() );
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
                MessageBox.Show("Error al Finalizar Factura " + ex.Message.ToString());
                return false;
            }


        }

        int tot_so_zona2()
        {
            //[dbo].[ADN_obtener_disponibilidad_zona2]
            SqlCommand cmd = new SqlCommand();
            //SqlDataAdapter da = new SqlDataAdapter();
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
                MessageBox.Show("Error al obtener disponibilidad en la ZONA " + ex.Message.ToString());
                return -1;
            }

        }
        int tot_cajas_pend_recibir_zona(int idzona)
        {
            //[dbo].[ADN_tot_cajas_pend_recibir_zona] 
            //  @Id_Zona int
            SqlCommand cmd = new SqlCommand();
            //SqlDataAdapter da = new SqlDataAdapter();
            cmd.Connection = Global.cn;
            //DataSet dt = new DataSet();
            //DataRow dr;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_tot_cajas_pend_recibir_zona";
            cmd.Parameters.AddWithValue("@Id_Zona", idzona);

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
                MessageBox.Show("Error al obtener total de cajas por recibir " + ex.Message.ToString());
                return 0;
            }


        }


        //int facturas_por_enviar(int idzona)
        //{ 
        ////ADN_obtener_facturas_por_enviar
        ////@Id_Zona int
        //    SqlCommand cmd = new SqlCommand();
        //    SqlDataAdapter da = new SqlDataAdapter();
        //    cmd.Connection = Global.cn;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = "ADN_obtener_facturas_por_enviar";
        //    cmd.Parameters.AddWithValue("@Id_Zona", idzona);

        //    try
        //    {
        //        if (Global.cn.State == ConnectionState.Closed)
        //        {
        //            Global.cn.Open();
        //        }
        //        return (Convert.ToInt16(cmd.ExecuteNonQuery().ToString()));
               
        //    }
        //    catch
        //    {
        //        return -1;
        //    }


        //}

        int facturas_por_enviar(int idzona, int sigzona)
        {
            //ADN_Obtener_tot_facturas_turno
            //@Id_Zona int
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Obtener_tot_facturas_turno";
            cmd.Parameters.AddWithValue("@IdZona", idzona);
            cmd.Parameters.AddWithValue("@SigZona", sigzona);
            try
            {
                if (Global.cn.State == ConnectionState.Closed)
                {
                    Global.cn.Open();
                }
                return (Convert.ToInt16(cmd.ExecuteScalar().ToString()));

            }
            catch
            {
                return -1;
            }


        }



        string obtener_factura_enviar(int idzona)
                        {
                // [dbo].[ADN_obtener_factura_por_enviar]
                //-- Add the parameters for the stored procedure here
                //@Id_Zona int

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_obtener_factura_por_enviar";
            cmd.Parameters.AddWithValue("@Id_Zona", idzona);

            try
            {
                if (Global.cn.State == ConnectionState.Closed)
                {
                    Global.cn.Open();
                }

                return cmd.ExecuteScalar().ToString().Trim()  ;

            }
            catch
            {
                return "";
            }

         
        }

        bool actualizar_cajas_validacion(string factura,string validacion)
        {
            // ADN_Actualizar_cajas_validacion
            //@InvcNbr varchar(20)
            //@IdValidacion int
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Actualizar_cajas_validacion";
            cmd.Parameters.AddWithValue("@InvcNbr", factura);
            cmd.Parameters.AddWithValue("@Validacion", validacion);
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


        bool verificar_validacion()
        {
         //ADN_verificar_validacion	
         //@IdZona int
            //funcion para verificar si hay puntos de validacion activos en la zona
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_verificar_validacion";
            cmd.Parameters.AddWithValue("@IdZona", Global.idzona );            
            try
            {
                if (Global.cn.State == ConnectionState.Closed)
                {
                    Global.cn.Open();
                }

                return Convert.ToBoolean( cmd.ExecuteScalar().ToString());  

            }
            catch
            {
                MessageBox.Show("Error al verificar punto de validacion");
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
                }
                else
                {
                    lbl_msj.BackColor = Color.White;
                }
            }
            else
            {
                lbl_msj.BackColor = Color.White;
            }

        }

        void msjalerta2()
        {

            if (alerta)
            {
                if (lbl_msj.BackColor == Color.White)
                {
                    lbl_msj.BackColor = Color.GreenYellow;
                }
                else
                {
                    lbl_msj.BackColor = Color.White;
                }
            }
            else
            {
                lbl_msj.BackColor = Color.White;
            }

        }

        bool actualizar_status_factura(string factura, string status)
        {
            // ADN_terminar_surt_factura	
            //@InvcNbr VARCHAR(20),
            //@Usuario VARCHAR(50)
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_terminar_surt_factura";
            cmd.Parameters.AddWithValue("@InvcNbr", factura.Trim());
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
                MessageBox.Show("Error al actualizar status de factura..");  
                return false;
            }


        }


        string obtener_validacion_picking1()
        {
            DataSet dt = new DataSet();
            DataRow dr;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Obtener_validacion_picking1";
            SqlDataAdapter da = new SqlDataAdapter();
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
                            if (dr[0].ToString() != null)
                            {
                                return dr[1].ToString().Trim();
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
            catch 
            {
                return "";
            }

        
        }
        
        string obtener_validacion_picking2()
        {
            DataSet dt = new DataSet();
            DataRow dr;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Obtener_validacion_picking2";
            SqlDataAdapter da = new SqlDataAdapter();
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
                            if (dr[1].ToString() != null)
                            {
                                return dr[1].ToString().Trim();
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
            catch
            {
                return "";
            }


        }

        int tot_cajas_pend_recibir( int idzona)
        {
            StringBuilder cad = new StringBuilder();
            SqlCommand cmd = new SqlCommand();           
            cmd.Connection = Global.cn;
            cad.Append("SELECT  COUNT(Caja) FROM ADN_Surtimiento_cajas_zonas ");
            cad.AppendLine("WHERE Id_Zona=@Id_Zona AND Rec=0");

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = cad.ToString();
            cmd.Parameters.AddWithValue("@Id_Zona", idzona);
            
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
                MessageBox.Show("Error al obtener total de cajas por recibir " + ex.Message.ToString());
                return 0;
            }


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
        
        bool mover_cajas(string factura, int id_zona, int idpicking)
        { 
         //PROCEDURE ADN_Surtimiento_mover_cajas	
        //@InvcNbr VARCHAR(20),
        //@Id_Zona int
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            //DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            //DataRow dr;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Surtimiento_mover_cajas";
            cmd.Parameters.AddWithValue("@InvcNbr", factura);
            cmd.Parameters.AddWithValue("@Id_Zona", id_zona);
            cmd.Parameters.AddWithValue("@IdPicking", idpicking);
           
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
                MessageBox.Show("Error al mover cajas.." + ex.Message.ToString());  
                return false;
            }
        
        }


   bool mover_cajas_picking(string factura, int id_zona, int idpicking)
        { 
      //ADN_Surtimiento_mover_cajas_picking	
      //@InvcNbr VARCHAR(20),
      //@Id_Zona INT,
      //@IdPicking int
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            //DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            //DataRow dr;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Surtimiento_mover_cajas_picking";
            cmd.Parameters.AddWithValue("@InvcNbr", factura);
            cmd.Parameters.AddWithValue("@Id_Zona", id_zona);
            cmd.Parameters.AddWithValue("@IdPicking", idpicking);
    
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
                MessageBox.Show("Error al mover cajas.." + ex.Message.ToString());  
                return false;
            }
        
        }
     


        bool mover_cajas_area(string factura, int id_zona, string IdArea)
        {
            //PROCEDURE ADN_Surtimiento_mover_cajas_area	
            //@InvcNbr VARCHAR(20),
            //@Id_Zona int
            //@IdArea VARCHAR(50)
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            //DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            //DataRow dr;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Surtimiento_mover_cajas_area";
            cmd.Parameters.AddWithValue("@InvcNbr", factura);
            cmd.Parameters.AddWithValue("@Id_Zona", id_zona);
            if (IdArea == "")
            {
                cmd.Parameters.AddWithValue("@IdArea", IdArea);
            }
            else
            {
                cmd.Parameters.AddWithValue("@IdArea", DBNull.Value );
            
            }

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
                MessageBox.Show("Error al mover cajas.." + ex.Message.ToString());
                return false;
            }

        }

        int tot_cajas_factura(string factura)
        {
            //ADN_obtener_tot_cajas_factura
            //@InvcNbr varchar(20)
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            DataRow dr;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_obtener_tot_cajas_factura";
            cmd.Parameters.AddWithValue("@InvcNbr", factura);
            da.SelectCommand = cmd;
            try
            {
                da.Fill(dt);
                if (dt.Tables[0].Rows.Count != 0)
                {
                    dr = dt.Tables[0].Rows[0];
                    if (!string.IsNullOrEmpty(dr[0].ToString()))
                    {
                        return Convert.ToInt16(dr[0].ToString());
                    }
                    else
                    {
                        return 0;
                    }

                   
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {

                return 0;
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

        int tot_zonas_status(string InvcNbr, string status)
        {
            //[ADN_obtener_tot_zonas_status]
            //@InvcNbr VARCHAR(20),
            //@Status VARCHAR(10)
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            DataSet dt = new DataSet();
            //SqlDataAdapter da = new SqlDataAdapter();
            //DataRow dr;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_obtener_tot_zonas_status";
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
        
        bool agregar_status_zona(string invcnbr, int idzona, string status)
        {
            //ADN_agregar_status_zonas	
            //@InvcNbr VARCHAR(10),
            //@IdZona INT,
            //@Status varchar(20)
            if (invcnbr == "" || invcnbr == null)
            {
                return false;
            }
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

    //[dbo].[ADN_agregar_status_zona_area]
    //-- Add the parameters for the stored procedure here
    //@InvcNbr VARCHAR(10),
    //@IdZona INT,
    //@Area VARCHAR(50),
    //@Status varchar(20)

        bool agregar_status_zona_area(string invcnbr, int idzona,string area, string status)
        {
            //ADN_agregar_status_zonas	
            //@InvcNbr VARCHAR(10),
            //@IdZona INT,
            //@Area
            //@Status varchar(20)
            if (invcnbr == "" || invcnbr == null)
            {
                return false;
            }

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;            
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_agregar_status_zona_area";
            cmd.Parameters.AddWithValue("@InvcNbr", invcnbr);
            cmd.Parameters.AddWithValue("@IdZona", idzona);
            cmd.Parameters.AddWithValue("@Area",area);
            cmd.Parameters.AddWithValue("@Status", status);
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario );

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

        bool obtener_disponibilidad(int idzona)
        {
            //ADN_obtener_disponibilidad_zona	
            //@Id_Zona int
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.Connection = Global.cn;
            //DataSet dt = new DataSet();
            //DataRow dr;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_obtener_disponibilidad_zona";
            cmd.Parameters.AddWithValue("@Id_Zona", idzona);
            da.SelectCommand = cmd;
            try
            {
                 if(Global.cn.State==ConnectionState.Closed)
                {
                    Global.cn.Open();
                }
              return Convert.ToBoolean(cmd.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener disponibilidad en la ZONA: " + idzona.ToString() + " " + ex.Message.ToString());
                return false;
            }

        }

        void lista_cajas()
        {
            //ADN_Obtener_lista_cajas 
            //@InvcNbr varchar(15)
            DataSet dt = new DataSet();
            //DataRow dr;
            SqlDataAdapter ad = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Obtener_lista_cajas";
            cmd.Parameters.AddWithValue("@InvcNbr", invcnbr);
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
                            foreach (DataRow dr in dt.Tables[0].Rows)
                            {
                                if (!string.IsNullOrEmpty(dr["Caja#"].ToString()))
                                {
                                    lst_cajas.Items.Add(dr["Caja#"].ToString().Trim() + "(" + dr["Articulos"].ToString().Trim() + ")");
                                }

                            }
                        }
                    }
                }
               


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar cajas.." + ex.Message.ToString());
            }
        }

        void obtener_factura_transito(int id_zona, out string invcnbr, out int tot_cajas)
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
                        }

                    }
                    else
                    {
                        invcnbr = "";
                        tot_cajas = 0;
                    }
                }
                else
                {
                    invcnbr = "";
                    tot_cajas = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener factura en transito.." + ex.Message.ToString());
                invcnbr = "";
                tot_cajas = 0;
                da.Dispose();
                dt.Dispose();
                cmd.Dispose();
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
            cmd.Parameters.AddWithValue("@InvcNbr", invcnbr);
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

        private void frm_cajas_transito_Load(object sender, EventArgs e)
        {
            lista_cajas();
            lbl_tot_cajas.Text = tot_cajas_factura(invcnbr).ToString();  
        }

        private void btn_recibido_Click(object sender, EventArgs e)
        {
            if (actualiza_status_zona(invcnbr, Global.idzona, "TRAN"))
            {
                int sig_zona = 0;
                //btn_recibido.Enabled = false;
                lbl_msj.Text = "Recibiendo cajas de factura" ;
                          
                if (agregar_status_zona(invcnbr, Global.idzona, "REC"))
                {

                    if (Global.idzona > 1)
                    {
                        sig_zona = Global.idzona - 1;
                        if (obtener_disponibilidad(sig_zona))
                        {
                            status = "E"; 
                            lbl_msj.Text = "Avanzar cajas hacia la ZONA" + sig_zona.ToString() + ", Click en Confirmar Envio para terminar";
                            btn_confirmar_envio.Enabled = true;
                            //timer1.Enabled = true;
                        }
                        else
                        {
                            status = "E"; 
                            lbl_msj.Text = "Espere un momento, La Sig. Zona Esta Ocupada";
                            btn_confirmar_envio.Enabled = false;
                            timer1.Enabled = true;
                        }

                    }
                }
                else
                {
                    //btn_recibido.Enabled = true;
                    MessageBox.Show("Error al actualizar status de cajas, intente otra vez");
                }
            }
            else
            {
                //lbl_msj.Text = "Avanzar cajas hacia la ZONA" + sig_zona.ToString() + ", Click en Confirmar Envio para terminar";
                MessageBox.Show("Error al actualizar status de cajas, intente otra vez");      
            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Global.picking == 1)
            {
                //obtenemos el total de articulos por surtir en PICKING1 
                int tot_arts_ps = Global.obtener_total_articulos_por_surtir_P1(invcnbr);
                int id_zona = 0;
                if (tot_arts_ps > 0)
                {
                    //obtenemos el id de la siguiente zona con articulos por surtir
                    id_zona = Global.obtener_siguiente_zona_por_surtir_P1(invcnbr);
                    if (id_zona > 0)
                    {
                        alerta = true;
                        System.Media.SystemSounds.Exclamation.Play();
                        lbl_msj.Text = "Mover Cajas A La ZONA " + id_zona.ToString() + ", Click en Confirmar Envio Para Terminar";
                        btn_confirmar_envio.Enabled = true;
                        msjalerta2();
                        timer1.Enabled = true;
                        return;
                    }
                    else
                    {
                        alerta = true;
                        System.Media.SystemSounds.Exclamation.Play();
                        lbl_msj.Text = "Error al obtener siguiente ZONA";
                        btn_confirmar_envio.Enabled = false;
                        msjalerta2();
                        timer1.Enabled = true;
                        return;


                    }
                }
                else if (tot_arts_ps == 0)
                {
                    int tot_arts_ps_p2 = Global.obtener_total_articulos_por_surtir_P2(invcnbr);
                    if (tot_arts_ps_p2 > 0)
                    {
                        alerta = true;
                        System.Media.SystemSounds.Exclamation.Play();
                        lbl_msj.Text = "Mover Cajas a PICKING2";
                        btn_confirmar_envio.Enabled = true;
                        msjalerta2();
                        timer1.Enabled = true;
                        return;
                    }
                    else if (tot_arts_ps_p2 == 0)
                    {
                        alerta = true;
                        System.Media.SystemSounds.Exclamation.Play();
                        lbl_msj.Text = "Mover Cajas a VALIDACION";
                        btn_confirmar_envio.Enabled = true;
                        msjalerta2();
                        timer1.Enabled = true;
                        return;
                    }
                    else
                    {
                        alerta = true;
                        System.Media.SystemSounds.Exclamation.Play();
                        lbl_msj.Text = "Error al obtener ZONA";
                        btn_confirmar_envio.Enabled = false;
                        msjalerta2();
                        timer1.Enabled = true;
                        return;

                    }


                }
                else
                {
                    alerta = true;
                    System.Media.SystemSounds.Exclamation.Play();
                    lbl_msj.Text = "Error al obtener ZONA";
                    btn_confirmar_envio.Enabled = false;
                    msjalerta2();
                    timer1.Enabled = true;
                    return;
                }
            
            }
            else if (Global.picking != 1)
            {
                //obtener articulos pendientes de surtir en P1
                //ESTO POR SI SE JUNTO UNA FACTURA EN ULTIMO MOMENTO, LA FACTURA DEBE REGRESAR A P1
                int tot_arts_ps = Global.obtener_total_articulos_por_surtir_P1(invcnbr);

                if (tot_arts_ps > 0)
                {
                    int id_zona = Global.obtener_siguiente_zona_por_surtir_P1(invcnbr);
                    alerta = true;
                    System.Media.SystemSounds.Exclamation.Play();
                    lbl_msj.Text = "Mover Cajas a PICKING1 ZONA " + id_zona.ToString();
                    btn_confirmar_envio.Enabled = true;
                    msjalerta2();
                    timer1.Enabled = true;
                    return;

                }
                else
                {
                    int tot_arts_ps_p2 = Global.obtener_total_articulos_por_surtir_P2(invcnbr);
                    if (tot_arts_ps_p2 == 0)
                    {
                        alerta = true;
                        System.Media.SystemSounds.Exclamation.Play();
                        lbl_msj.Text = "Mover Cajas a VALIDACION";
                        btn_confirmar_envio.Enabled = true;
                        msjalerta2();
                        timer1.Enabled = true;
                        return;
                    }
                    else
                    {
                        alerta = true;
                        System.Media.SystemSounds.Exclamation.Play();
                        lbl_msj.Text = "Todavia existen articulos por surtir";
                        btn_confirmar_envio.Enabled = false;
                        msjalerta2();
                        timer1.Enabled = true;
                        return;

                    }
                }


                
            
            }


            //if (Global.idzona >1 && Global.idzona <=4)
            //    {
            //        int sig_zona = 0;
            //    if (Global.idzona == 4 || Global.idzona == 3)
            //        {
            //            sig_zona = 2;
            //        }
            //       //else if (Global.idzona == 1)
            //       // {
            //       //    sig_zona = 5;
            //       // }
            //       else
            //       {
            //           sig_zona = Global.idzona - 1;
            //       }
                    
            //        timer1.Enabled = false;
            //        if (status == "E")
            //        {
                        
            //            if (Global.idzona == 4 || Global.idzona == 3)
            //            {
                            
            //                //obtener_factura_enviar(int idzona)
            //                if (facturas_por_enviar(Global.idzona,2) > 0)
            //                {
            //                    alerta = true;
            //                    System.Media.SystemSounds.Exclamation.Play();
            //                    if (Global.total_articulos_status(invcnbr, "PS") == 0)
            //                    {
            //                        lbl_msj.Text = "Enviar Cajas A VALIDACION..." + ", Click en Confirmar Envio Para Terminar";
            //                    }
            //                    else
            //                    {
            //                        lbl_msj.Text = "Mover Cajas A La Rampa" + ", Click en Confirmar Envio Para Terminar";
            //                    }
                              
                               
            //                    btn_confirmar_envio.Enabled = true;
            //                    msjalerta2();
            //                    timer1.Enabled = true;
            //                }
            //                else
            //                {

            //                    alerta = true;
            //                    System.Media.SystemSounds.Exclamation.Play();
            //                    lbl_msj.Text = "Mover Cajas A La ZONA2" + ", Click en Confirmar Envio Para Terminar";
            //                    btn_confirmar_envio.Enabled = true;
            //                    msjalerta2();
            //                    timer1.Enabled = true;
                            
            //                }
                         
            //            }
            //            else
            //            {

            //                if (Global.idzona == 2)
            //                {
            //                    int tot_env = facturas_por_enviar(Global.idzona, 1);
            //                    //VERIFICAMOS si tienen facturas en fila por susrtir
            //                    //el buffer debe ser de 3 facturas en espera
            //                    if (tot_env <= 3)
            //                    {
            //                        alerta = true;
            //                        System.Media.SystemSounds.Exclamation.Play();
            //                        lbl_msj.Text = "Avanzar cajas hacia la ZONA:" + sig_zona.ToString() + ", Click en Confirmar Envio para terminar";
            //                        btn_confirmar_envio.Enabled = true;
            //                        msjalerta2();
            //                        timer1.Enabled = true;
            //                    }
            //                    else
            //                    {
            //                        alerta = true;
            //                        lbl_msj.Text = "Espere para enviar Cajas  a la siguiente ZONA:" + sig_zona.ToString();
            //                        btn_confirmar_envio.Enabled = false;
            //                        msjalerta();
            //                        timer1.Enabled = true;

            //                    }
            //                }

            //            }
            //        }
            //        else if (status == "V")
            //        {
                        
            //            System.Media.SystemSounds.Exclamation.Play(); 
            //            alerta = true;
            //            msjalerta2();
            //            lbl_msj.Text = "Enviar Cajas A VALIDACION" + ", Click en Confirmar Envio para terminar";
            //            btn_confirmar_envio.Enabled = true;
            //            timer1.Enabled = true;
            //        }

            //   }
            //    else if (Global.idzona == 1)
            //    {
            //        timer1.Enabled = false;
            //        if (!verificar_zona_transito())
            //        {
            //            //timer1.Enabled = false;
            //            System.Media.SystemSounds.Beep.Play();
            //            System.Media.SystemSounds.Beep.Play();
            //            lbl_msj.Text = "Envio Terminado...";
            //            System.Threading.Thread.Sleep(6000);
            //            this.Close();
            //        }

            //        //btn_confirmar_envio.Enabled = true;
                    
            //        if (total_articulos_status(lbl_factura.Text.Trim(), "PS") > 0)
            //        {
            //            if (Tot_articulos_status_zona(lbl_factura.Text, 5, "PS") > 0 || Tot_articulos_status_zona(lbl_factura.Text, 6, "PS") > 0 || Tot_articulos_status_zona(lbl_factura.Text, 11, "PS") > 0)
            //            {
            //                btn_confirmar_envio.Enabled = true;
            //                System.Media.SystemSounds.Hand.Play();
            //                alerta = true;
            //                msjalerta2();
            //                lbl_msj.Text = "Enviar Cajas A PICKING2 Para Surtimiento" + ", Click en Confirmar Envio Para Terminar";

            //            }
            //        }
            //        else
            //        {
            //            string cad = "VALIDACION1";
            //            //cad = obtener_validacion_picking1();
                       
            //            alerta = true;
            //            msjalerta2();
            //            if (cad != "")
            //            {
            //                System.Media.SystemSounds.Exclamation.Play();
            //                lbl_msj.Text = "Enviar Cajas A " + cad + ", Click En Confirmar Envio Para Terminar";
            //                btn_confirmar_envio.Enabled = true;
            //            }
            //            else
            //            {
            //                System.Media.SystemSounds.Beep.Play();
            //                lbl_msj.Text = "Espere Para Enviar Cajas A VALIDACION.." ;
            //                btn_confirmar_envio.Enabled = false;
            //            }

            //        }
            //        timer1.Enabled = true; 
            //    }
            //else if (Global.idzona >= 5)
            //{
            //    timer1.Enabled = false;
            //    //string cad = "";
            //    if (!verificar_zona_transito())
            //    {
            //        //timer1.Enabled = false;
            //        System.Media.SystemSounds.Beep.Play();
            //        System.Media.SystemSounds.Beep.Play();
            //        lbl_msj.Text = "Envio Terminado...";
            //        System.Threading.Thread.Sleep(6000);
            //        this.Close();
            //        return;
            //    }

                
            //        System.Media.SystemSounds.Exclamation.Play();
            //        alerta = true;
            //        msjalerta2();
            //        lbl_msj.Text = "Enviar Cajas A  VALIDACION2"   + ", Click en Confirmar Envio Para Terminar";
            //        btn_confirmar_envio.Enabled = true;
            //        timer1.Enabled = true;
               

            //}


        }

        private void btn_confirmar_envio_Click(object sender, EventArgs e)
        {

            if (Global.picking == 1)
            {
                //obtenemos el total de articulos por surtir en PICKING1 
                int tot_arts_ps = Global.obtener_total_articulos_por_surtir_P1(invcnbr);
                int idzonaini = Global.obtener_zona_inicio_picking1();
                int id_zona = 0;
                if (tot_arts_ps > 0)
                {
                    //obtenemos el id de la siguiente zona con articulos por surtir
                    id_zona = Global.obtener_siguiente_zona_por_surtir_P1(invcnbr);
                    if (id_zona > 0)
                    {
                       
                   
                        //AGREGAMOS EL TURNO DE LA FACTURA
                        
                        Global.actualizar_status_zonas(Global.invcnbr);
                        Global.actualizar_turno_activo_factura(Global.invcnbr);
                        agregar_turno_factura(invcnbr, idzonaini, id_zona);
                        mover_cajas(invcnbr, id_zona,1);
                        Global.invcnbr = "";
                        Global.idzona = 0;
                        this.Close();

                    }
                    else
                    {
                        alerta = true;
                        System.Media.SystemSounds.Exclamation.Play();
                        MessageBox.Show("Error al obtener siguiente ZONA"); ;
                        //btn_confirmar_envio.Enabled = false;
                        msjalerta2();
                        timer1.Enabled = true;
                        return;


                    }
                } //if (tot_arts_ps > 0)
                else if (tot_arts_ps == 0)
                {
                    int tot_arts_ps_p2 = Global.obtener_total_articulos_por_surtir_P2(invcnbr);
                    if (tot_arts_ps_p2 > 0)
                    {
                        int idzonap2 = Global.Obtener_IdZona_Picking2();                        
                        Global.actualizar_status_zonas(Global.invcnbr);
                        //AGREGAMOS EL TURNO DE LA FACTURA
                        Global.actualizar_turno_activo_factura(Global.invcnbr);
                        agregar_turno_factura(invcnbr, idzonaini, idzonap2);
                        mover_cajas(invcnbr, idzonap2,2);
                        Global.invcnbr = "";
                        Global.idzona = 0;
                        this.Close();

                    }
                    else if (tot_arts_ps_p2 == 0)
                    {
                        //mover cajas a validacion
                        int idzonaval = Global.obtener_idzona_validacion();
                        if (idzonaval > 0)
                        {
                            Global.actualizar_status_zonas(Global.invcnbr);
                            //AGREGAMOS EL TURNO DE LA FACTURA
                            Global.actualizar_turno_activo_factura(Global.invcnbr);
                            agregar_turno_factura(invcnbr, idzonaini, idzonaval);
                            mover_cajas(invcnbr, idzonaval,0);
                            Global.actualizar_status_factura(Global.invcnbr, "PV");
                            Global.invcnbr = "";
                            Global.idzona = 0;
                            this.Close();

                        }
                        else
                        {
                            alerta = true;
                            System.Media.SystemSounds.Exclamation.Play();
                            MessageBox.Show("Error al obtener ZONA de validacion");                           
                            msjalerta2();
                            timer1.Enabled = true;
                            return;
                        
                        }

                    }
                    else
                    {
                        alerta = true;
                        System.Media.SystemSounds.Exclamation.Play();
                        lbl_msj.Text = "Error al obtener ZONA";
                        btn_confirmar_envio.Enabled = false;
                        msjalerta2();
                        timer1.Enabled = true;
                        return;

                    }


                }
                else
                {
                    alerta = true;
                    System.Media.SystemSounds.Exclamation.Play();
                    lbl_msj.Text = "Error al obtener ZONA";
                    btn_confirmar_envio.Enabled = false;
                    msjalerta2();
                    timer1.Enabled = true;
                    return;
                }
            
            }
            else if (Global.picking != 1)
            {
                int tot_arts_ps_p2 = Global.obtener_total_articulos_por_surtir_P2(Global.invcnbr);
                    if (tot_arts_ps_p2 > 0)
                    {
                        alerta = true;
                        System.Media.SystemSounds.Exclamation.Play();
                        MessageBox.Show("Error al enviar todavia existen articulos por surtir");
                        msjalerta2();
                        timer1.Enabled = true;
                        return;
                    }
                    else if (tot_arts_ps_p2 == 0)
                    {
                        //mover cajas a validacion
                        int idzonaval = Global.obtener_idzona_validacion();
                        int idzonap2 = Global.Obtener_IdZona_Picking2();
                        if (idzonaval > 0)
                        {
                            //actualiza_status_zona(invcnbr, Global.idzona, "SO");
                            //actualiza_status_zona(invcnbr, Global.idzona, "TRAN");
                            Global.actualizar_status_zonas(Global.invcnbr);
                            Global.actualizar_turno_activo_factura(Global.invcnbr);
                            //AGREGAMOS EL TURNO DE LA FACTURA
                            Global.actualizar_turno_activo_factura(Global.invcnbr);
                            agregar_turno_factura(invcnbr, idzonap2, idzonaval);
                            mover_cajas(invcnbr, idzonaval,0);
                            Global.actualizar_status_factura(Global.invcnbr, "PV");
                            Global.invcnbr = "";
                            Global.idzona = 0;
                            Global.cajap2 = "";
                            this.Close();

                        }
                        else
                        {
                            alerta = true;
                            System.Media.SystemSounds.Exclamation.Play();
                            MessageBox.Show("Error al obtener ZONA de validacion");
                            msjalerta2();
                            timer1.Enabled = true;
                            return;

                        }
                    }
                    else
                    {
                        alerta = true;
                        System.Media.SystemSounds.Exclamation.Play();
                        MessageBox.Show("Error al Enviar cantidad de articulos no valida");
                        msjalerta2();
                        timer1.Enabled = true;
                        return;

                    
                    }
            }
                
               
        }


        private void frm_cajas_transito_Closing(object sender, CancelEventArgs e)
        {
            timer1.Enabled = false; 
        }

        private void frm_cajas_transito_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "F1":
                    {
                        if (btn_confirmar_envio.Enabled == true)
                        {
                            btn_confirmar_envio_Click(this, EventArgs.Empty); 
                        }
                        break;
                    }
                //case "F2":
                //    {
                //        if (btn_confirmar_envio.Enabled == true)
                //        {
                //            btn_confirmar_envio_Click(this, EventArgs.Empty); 
                //        }
                       
                //        break;
                //    }
               
                default:
                    break;
            }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;  
            this.Close();
        }

      

    }
}