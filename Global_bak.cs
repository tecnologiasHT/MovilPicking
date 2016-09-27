using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace Picking
{
    public class Global
    {
        public static string id_pareja = "0";
        public static string pareja_no = "0";
        public static string piid = "";
        public static string siteid = "";

        public SqlConnection cn = new SqlConnection(Properties.Resources.cn);

        public  bool IsNumeric(string s)
        {
            try
            {
                float output;
                output=float.Parse(s);
                return true;
            }
            catch
            {
                return false;
            }
        }
        
         public string defualt_siteid()
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            //SqlDataAdapter da = new SqlDataAdapter();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Intra_Inventario_Obtener_Almacen_default";
            //da.SelectCommand = cmd;
            DataSet dt = new DataSet();
            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                string res = "";
                res = cmd.ExecuteScalar().ToString();

                return res;

            }
            catch
            {
                return "";
            }
        }
        public DataSet Datos_Pareja(string pSiteid, string pPIID, string pIdpareja)
        {
            //intra_Inventario_Datos_Pareja_Inventario
            //@Pareja_No INT,
            //@SiteID VARCHAR(20),
            //@PIID varchar(20)

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "intra_Inventario_Datos_Pareja_Inventario";
            cmd.Parameters.AddWithValue("@SiteID", pSiteid);
            cmd.Parameters.AddWithValue("@PIID", pPIID);
            cmd.Parameters.AddWithValue("@Pareja_No", pIdpareja);
            da.SelectCommand = cmd;
            DataSet dt = new DataSet();
            try
            {
                da.Fill(dt);
                return dt;

            }
            catch
            {
                return null;
            }
        }

        public DataSet lista_almacenes()
        {
            SqlConnection cn1 = new SqlConnection(Properties.Resources.cn );            
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn1;
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet dt = new DataSet();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "intra_Inventario_Lista_Almacenes";
            da.SelectCommand = cmd;           
            try
            {
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener lista de almacenes.." + ex.Message.ToString());
                return null;
            }
        }

        public DataSet lista_inventarios(string siteid)
        {
            //SqlConnection cn = new SqlConnection();           
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "intra_Inventario_Activo";
            cmd.Parameters.AddWithValue("@SiteID", siteid);
            da.SelectCommand = cmd;
            DataSet dt = new DataSet();
            try
            {
                da.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// Obtiene los datos del marbete especificado
        /// </summary>
        /// <param name="pEtiqueta"></param>
        /// <param name="pPIID"></param>
        /// <returns></returns>
        public DataSet ObtenerDatosMarbete(string pEtiqueta, string pPIID)
        {
            //Intra_Inventario_Obtener_Datos_Marbete	
            //@Etiqueta ,
            //@PIID 
            //SqlConnection cn = new SqlConnection();           
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Intra_Inventario_Obtener_Datos_Marbete";
            cmd.Parameters.AddWithValue("@Etiqueta", pEtiqueta);
            cmd.Parameters.AddWithValue("@PIID", pPIID);
            da.SelectCommand = cmd;
            DataSet dt = new DataSet();
            try
            {
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error  al obtener datos del marbete.." + ex.Message.ToString());
                return null;
            }
        }
          

        public int TotMarbetesLocalizacion(string pEtiqueta,string pClave, string pLocalizacion)
        {
            //intra_inventario_tot_marbetes_loc
            //@SiteID VARCHAR(50),
            //@PIID varchar(50),
            //@Clave VARCHAR(50), 
            //@Localizacion VARCHAR(50)         
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;            
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "intra_inventario_tot_marbetes_loc";            
            cmd.Parameters.AddWithValue("@SiteID", siteid );
            cmd.Parameters.AddWithValue("@PIID", piid);
            cmd.Parameters.AddWithValue("@Clave", pClave);
            cmd.Parameters.AddWithValue("@Localizacion", pLocalizacion);
            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open(); 
                }
                int tot = int.Parse(cmd.ExecuteScalar().ToString());
                return tot;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener total de marbetes en la localizacion" + ex.Message.ToString());
                return 0;
            }
        }

        public int TotLocalizacionesPorContar(string pPIID,string pIdPareja)
        {            
                    
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;            
            cmd.CommandType = CommandType.StoredProcedure ;
            cmd.CommandText = "inventarioTotLocalizacionesPorContar";
            cmd.Parameters.AddWithValue("@PIID", pPIID);
            cmd.Parameters.AddWithValue("@IdPareja", pIdPareja);            
            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open(); 
                }
                int tot = int.Parse(cmd.ExecuteScalar().ToString());
                return tot;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener total de localizaciones por contar..." + ex.Message.ToString());
                return 0;
            }
        }

       public DataSet ObtenerDatosArticuloParaMarbeteManual(string clave_articulo)
        {
            //obtiene los datos del marbete manual que se va a capturar
            try
            {
                if (clave_articulo != "")
                {
                    DataSet dt = new DataSet();
                    SqlCommand cmd = new SqlCommand();
                    SqlDataAdapter Ad = new SqlDataAdapter();
                    //DataRow dr;
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Intra_Inventario_ObtenerDatosArticuloParaMarbeteManual";
                    Ad.SelectCommand = cmd;
                    Ad.SelectCommand.Parameters.AddWithValue("@SiteID", siteid);
                    Ad.SelectCommand.Parameters.AddWithValue("@Articulo", clave_articulo);
                    Ad.Fill(dt);
                    return dt;
                                     

                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Al Obtener Datos.." + ex.Message.ToString());
                return null;

            }

        }


       public bool verificar_localizacion( string loc)
       {
           try
           {
               //VERIFICA LA EXISTENCIA DE LA LOCALIZACION EN EL ALMACEN ESPECIFICADO
               //intra_invetario_verificar_localizacion     
               //@SiteID  VARCHAR(20),
               //@WhseLoc VARCHAR(50)    
               DataSet dt = new DataSet();
               SqlDataAdapter da = new SqlDataAdapter();
               SqlCommand cmd = new SqlCommand("intra_invetario_verificar_localizacion", cn);
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.AddWithValue("@SiteID", siteid);
               cmd.Parameters.AddWithValue("@WhseLoc", loc);
               da.SelectCommand = cmd;

               da.Fill(dt);
               bool res;
               if (dt != null)
               {
                   if (dt.Tables.Count > 0)
                   {
                       if (dt.Tables[0].Rows.Count > 0)
                       {
                           res = true;
                       }
                       else
                       {
                           res = false;
                       }
                   }
                   else
                   {
                       res = false;
                   }
               }
               else
               {
                   res = false;
               }

               dt.Dispose();
               da.Dispose();
               return res;

           }
           catch (Exception ex)
           {
               MessageBox.Show("Error al verificar localizacion.." + ex.Message.ToString());

               return false;
           }
       }

        /// <summary>
        /// Valida que no exista un marbete en la localizacion
        /// </summary>
        /// <param name="Clave"></param>
        /// <param name="Loc"></param>
        /// <returns></returns>
      public  bool valida_marbete(string Clave, string Loc)
       {
           //Valida que un marbete no haya sido agregado previamnte en el inventario
           string cad;
           DataSet dt = new DataSet();
           DataRow dr;
           SqlDataAdapter ad = new SqlDataAdapter();
           cad = "SELECT Etiqueta, Clave, Localizacion, TipoMarbete FROM Intra_Inventario_Maestro";
           cad = cad + "  WHERE SiteID='" + siteid + "'" + " AND PIID='" + piid + "' " + "AND" + " " + "Clave='" + Clave + "' " + "AND" + " " + "Localizacion='" + Loc + "'" + " AND Cancelado=0";
           //SqlConnection cn = new SqlConnection();
           //cn.ConnectionString = Properties.Settings.Default.conectionstring;
           SqlCommand cmd = new SqlCommand();
           cmd.CommandType = CommandType.Text;
           cmd.Connection = cn;
           cmd.CommandText = cad;

           ad.SelectCommand = cmd;

           try
           {
               ad.Fill(dt);
               if (dt.Tables[0].Rows.Count != 0)
               {
                   dr = dt.Tables[0].Rows[0];
                   MessageBox.Show("Error al agregar Marbete, ya existe un marbete con esta clave: Marbete No " + dr["Etiqueta"].ToString() + " Tipo: " + dr["TipoMarbete"].ToString(),"Mensaje"  );
                   dt.Dispose();
                   return false;
               }
               else
               {
                   return true;

               }

           }
           catch (Exception ex)
           {
               MessageBox.Show("Error al verificar marbete.." + ex.Message.ToString());
               return false;
           }
       }


     public  bool GuardarMarbeteManual(string pClave, string pDesc,string pLoc, 
         string pUnidad, 
         decimal pCosto, 
         decimal pCantidad         
         )
      {

         //IntraGuardaMarbeteManual
          SqlCommand cmd = new SqlCommand();
          cmd.CommandType = CommandType.StoredProcedure ;
          cmd.Connection = cn;
          cmd.CommandText = "IntraGuardaMarbeteManual";
          cmd.Parameters.AddWithValue("@Usuario", "ADMIN");
          cmd.Parameters.Add("@Etiqueta", SqlDbType.Int);
          cmd.Parameters["@Etiqueta"].Direction = ParameterDirection.InputOutput;
          cmd.Parameters["@Etiqueta"].Value = 0;
          cmd.Parameters.AddWithValue("@Clave",pClave);
          cmd.Parameters.AddWithValue("@Descr", pDesc);
          cmd.Parameters.AddWithValue("@Localizacion",pLoc);
          cmd.Parameters.AddWithValue("@PIID",piid);
          cmd.Parameters.AddWithValue("@SiteID",siteid);

         //obtener el pasillo correspondiente
          string pasillo = ObtenerPasilloLocalizacion(pLoc);
 
          cmd.Parameters.AddWithValue("@Pasillo", pasillo);
          cmd.Parameters.AddWithValue("@Unidad", pUnidad);
          cmd.Parameters.AddWithValue("@Costo", pCosto);               
         cmd.Parameters.AddWithValue("@Conteo1",pCantidad);
          cmd.Parameters.AddWithValue("@Observaciones","");
          cmd.Parameters.AddWithValue("@OP", "1");
          cmd.Parameters.AddWithValue("@IdPareja",pareja_no);   //numero de pareja que captura el marbete    
          cmd.Parameters.AddWithValue("TipoCapturaManual", "MOVIL");
         
          if (cn.State == ConnectionState.Closed)
          {
              cn.Open();
          }
          try
          {
              cmd.ExecuteNonQuery();
              cn.Close();              
             
              if (cmd.Parameters["@Etiqueta"].Value != null)
              {
                  if (int.Parse(cmd.Parameters["@Etiqueta"].Value.ToString()) > 0)
                  {
                      //txt_no.Text = cmd_guardar.Parameters["@Etiqueta"].Value.ToString();
                      System.Media.SystemSounds.Beep.Play();
                      MessageBox.Show("Los Datos Se Guardaron Correctamente: MARBETE No " + cmd.Parameters["@Etiqueta"].Value.ToString().Trim());
                      return true;
                  }
                  else
                  {
                      MessageBox.Show("Error al guardar Marbete");
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
              MessageBox.Show("Error al guardar marbete..." + ex.Message.ToString());
              return false;
          }

      }





        //public int TotMarbetesPorContar(string pPIID, string pIdPareja)
        //{
        //    //intra_inventario_tot_marbetes_loc
        //    //@SiteID VARCHAR(50),
        //    //@PIID varchar(50),
        //    //@Clave VARCHAR(50), 
        //    //@Localizacion VARCHAR(50)

        //    StringBuilder cad = new StringBuilder();
        //    cad.Append("SELECT COUNT(Etiqueta) ");
        //    cad.AppendLine("FROM  Intra_Inventario_Maestro ");
        //    cad.AppendLine("WHERE PIID=@PIID ");
        //    cad.AppendLine("AND (conteo1 IS NULL) ");
        //    cad.AppendLine("AND (TipoMarbete='SISTEMA') ");
        //    cad.AppendLine("AND Pasillo IN(SELECT  DISTINCT Pasillo ");
        //    cad.AppendLine("FROM intra_Inventario_Pasillos_Parejas ");
        //    cad.AppendLine("WHERE (PIID=@PIID ) ");
        //    cad.AppendLine(" AND (IdPareja= @IdPareja))");
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Connection = cn;
        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandText = cad.ToString();
        //    cmd.Parameters.AddWithValue("@PIID", pPIID);
        //    cmd.Parameters.AddWithValue("@IdPareja", pIdPareja);
        //    try
        //    {
        //        if (cn.State == ConnectionState.Closed)
        //        {
        //            cn.Open();
        //        }
        //        int tot = int.Parse(cmd.ExecuteScalar().ToString());
        //        return tot;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al obtener total de localizaciones por contar..." + ex.Message.ToString());
        //        return 0;
        //    }
        //}

        
        public int TotMarbetesPorContar(string pPIID, string pIdPareja)
        {                       
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "intraInventarioTotMarbetesPorContar";
            cmd.Parameters.AddWithValue("@PIID", pPIID);
            cmd.Parameters.AddWithValue("@IdPareja", pIdPareja);
            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                int tot = int.Parse(cmd.ExecuteScalar().ToString());
                return tot;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener total de localizaciones por contar..." + ex.Message.ToString());
                return 0;
            }
        }
        
        public int TotMarbetesConDiferencias(string pPIID, string pIdPareja)
        {           
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "intraInventarioTotMarbetesConDiferencias";
            cmd.Parameters.AddWithValue("@PIID", pPIID);
            cmd.Parameters.AddWithValue("@IdPareja", pIdPareja);
            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                int tot = int.Parse(cmd.ExecuteScalar().ToString());
                return tot;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener total de marbetes con diferencias..." + ex.Message.ToString());
                return 0;
            }
        }

        public DataSet  ListaMarbetesPorcontar(string pPIID, string pIdPareja,string pClave,string pDescr, string pLoc)
        {
            //intra_InventarioListaMarbetesPorContar
            //@PIID VARCHAR(20),
            //@IdPareja INT,
            //@Clave VARCHAR(20),
            //@Descr VARCHAR(50),
            //@Localizacion VARCHAR(20)
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet dt = new DataSet();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "intra_InventarioListaMarbetesPorContar";
            cmd.Parameters.AddWithValue("@PIID", pPIID);
            cmd.Parameters.AddWithValue("@IdPareja", pIdPareja);
            cmd.Parameters.AddWithValue("@Clave", pClave);
            cmd.Parameters.AddWithValue("@Descr", pDescr);
            cmd.Parameters.AddWithValue("@Localizacion", pLoc);
            da.SelectCommand = cmd; 
            try
            {
                da.Fill(dt); 
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener lista de marbetes pendienets de contar..." + ex.Message.ToString());
                return null;
            }
        }

        public DataSet ListaLocalizacionesPorContar(string pPIID, string pIdPareja, string pLoc)
        {
            //intra_InventarioListaLocalizacionesPorContar
            //@PIID VARCHAR(20),
            //@IdPareja INT,	
            //@Localizacion VARCHAR(20)
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet dt = new DataSet();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "intra_InventarioListaLocalizacionesPorContar";
            cmd.Parameters.AddWithValue("@PIID", pPIID);
            cmd.Parameters.AddWithValue("@IdPareja", pIdPareja);            
            cmd.Parameters.AddWithValue("@Localizacion", pLoc);
            da.SelectCommand = cmd;
            try
            {
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener lista de localizaciones pendienets de contar..." + ex.Message.ToString());
                return null;
            }
        }


        public DataSet ListaMarbetesConDiferencias(string pPIID, string pIdPareja, string pClave,string pDesc, string pPasillo)
        {
           //intra_InventarioListaMarbetesConDiferencias
          //  @PIID VARCHAR(20),
          //  @IdPareja INT,	
          //  @Clave VARCHAR(20),
          //  @Desc VARCHAR(20),
          //  @Pasillo VARCHAR(20)
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet dt = new DataSet();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "intra_InventarioListaMarbetesConDiferencias";
            cmd.Parameters.AddWithValue("@PIID", pPIID);
            cmd.Parameters.AddWithValue("@IdPareja", pIdPareja);
            cmd.Parameters.AddWithValue("@Clave", pClave);
            cmd.Parameters.AddWithValue("@Desc", pDesc);
            cmd.Parameters.AddWithValue("@Pasillo", pPasillo);
            da.SelectCommand = cmd;
            try
            {
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener lista de marbetes con diferencias..." + ex.Message.ToString());
                return null;
            }
        }

        

        /// <summary>
        /// Obtiene la cantidad total en sistema de los marbetes de la localizacion
        /// </summary>
        /// <param name="piid"></param>
        /// <param name="clave"></param>
        /// <param name="loc"></param>
        /// <returns></returns>
        public decimal Obtener_total_localizacion(string piid, string clave, string loc)
        {
            //Obtiene la cantidad fisica total de los marbetes de la localizacion
            // intra_Inventario_Obtener_Total_Localizacion
            //@PIID VARCHAR(20),
            //@Clave VARCHAR(20),
            //@Localizacion VARCHAR(50)
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = Properties.Resources.cn;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "intra_Inventario_Obtener_Total_Localizacion";
            cmd.Parameters.AddWithValue("@PIID", piid);
            cmd.Parameters.AddWithValue("@Clave", clave);
            cmd.Parameters.AddWithValue("@Localizacion", loc);
            cmd.Connection = cn;
            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();

                }

                Int32 res = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                cn.Close();
                cn.Dispose();
                return res;

            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                cn.Dispose();

                MessageBox.Show("Error al obtener total localizacion..." + ex.Message.ToString());
                return 0;
            }

        }


        public int ObtenerUltimoConteoMarbetePedimento(  string pPIID, string pClave, string pLocalizacion )
        {
            try
            {
                //Intra_InventarioObtenerUltimoConteo
                //@PIID VARCHAR(50),
                //@Clave VARCHAR(50),
                //@Localizacion VARCHAR(50)            
                SqlConnection cn = new SqlConnection();
                int res = 0;
                cn.ConnectionString = Properties.Resources.cn;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Intra_InventarioObtenerUltimoConteo";
                cmd.Parameters.AddWithValue("@PIID", pPIID);
                cmd.Parameters.AddWithValue("@Clave", pClave);
                cmd.Parameters.AddWithValue("@Localizacion", pLocalizacion);
                cmd.Connection = cn;
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                res = int.Parse(cmd.ExecuteScalar().ToString());
                return res;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar conteos marbete.." + ex.Message.ToString());
                return 0;

            }

        }


        /// <summary>
        /// gUARDAR dATOS DEL mARBETE
        /// </summary>
        /// <param name="pEtiqueta"></param>
        /// <param name="pIdPareja"></param>
        /// <param name="pPIID"></param>
        /// <param name="pClave"></param>
        /// <param name="pLocalizacion"></param>
        /// <param name="pConteo1"></param>
        /// <param name="pObservaciones"></param>
        /// <param name="pDiferencias"></param>
        /// <param name="pIdconteo"></param>
        /// <returns></returns>
        public bool guardar_marbete2(string pEtiqueta,
             string pIdPareja,
             string pPIID,
            string pClave,
            string pLocalizacion,
             string pConteo1,
             string pObservaciones,
            bool pDiferencias,
            int pIdconteo
             )
        {
            try
            {
                //@PIID VARCHAR(50),
                //@Etiqueta NUMERIC(9),
                //@Clave VARCHAR(50) ,
                //@Localizacion VARCHAR(50),
                //@Conteo1 NUMERIC(9, 2),    
                //@Observaciones VARCHAR(100),   
                //@IdPareja INT,    
                //@Diferencias BIT  ,
                //@IdConteo INT ,
                //@Usuario VARCHAR(50)

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "intra_Inventario_Guardar_Marbete2";
                cmd.Parameters.AddWithValue("@PIID", pPIID);
                cmd.Parameters.AddWithValue("@Etiqueta", pEtiqueta);
                cmd.Parameters.AddWithValue("@Clave", pClave);
                cmd.Parameters.AddWithValue("@Localizacion", pLocalizacion);

                if (pConteo1 != "")
                {
                    cmd.Parameters.AddWithValue("@Conteo1", pConteo1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Conteo1", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("@Observaciones", pObservaciones);
                if (pIdPareja != "")
                {
                    cmd.Parameters.AddWithValue("@IdPareja", pIdPareja);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@IdPareja", "0");
                }
                cmd.Parameters.AddWithValue("@Diferencias", pDiferencias);
                cmd.Parameters.AddWithValue("@IdConteo", pIdconteo);
                cmd.Parameters.AddWithValue("@Usuario","" );
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }

                cmd.ExecuteNonQuery();

                cn.Close();
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar marbete con pedimento.." + ex.Message.ToString());
                return false;

            }

        }


        /// <summary>
        /// GUARDAR LOS DATOS DEL SEGUNDO CONTEO
        /// </summary>
        /// <param name="pEtiqueta"></param>
        /// <param name="pIdPareja"></param>
        /// <param name="pPIID"></param>
        /// <param name="pClave"></param>
        /// <param name="pLocalizacion"></param>
        /// <param name="pConteo1"></param>
        /// <param name="pObservaciones"></param>
        /// <param name="pDiferencias"></param>
        /// <param name="pIdconteo"></param>
        /// <returns></returns>
        public bool GuardarMarbeteConteo2(string pEtiqueta,
             string pIdPareja,
             string pPIID,            
             string pConteo1,
             string pObservaciones            
             )
        {
            try
            {
                //@Etiqueta NUMERIC(9),
                //@Conteo1 NUMERIC(9, 2),
                //@Conteo2 NUMERIC(9, 2),
                //@Observaciones VARCHAR(100),
                //@PIID VARCHAR(50),
                //@IdPareja INT,
                //@Usuario VARCHAR(50),
                //@Diferencias BIT  OUTPUT,
                //@Conteos INT OUTPUT               
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "intra_Inventario_GuardarMarbeteConteo2";
                cmd.Parameters.AddWithValue("@Usuario", "");

                if (pIdPareja != "")
                {
                    cmd.Parameters.AddWithValue("@IdPareja", pIdPareja);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@IdPareja", "0");
                }
                cmd.Parameters.AddWithValue("@Etiqueta", pEtiqueta);
                cmd.Parameters.AddWithValue("@PIID", pPIID);
                if (pConteo1 != "")
                {
                    cmd.Parameters.AddWithValue("@Conteo1", pConteo1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Conteo1", DBNull.Value);
                }

                cmd.Parameters.AddWithValue("@Conteo2", DBNull.Value);
                
                cmd.Parameters.Add("@Diferencias", SqlDbType.Bit);
                cmd.Parameters["@Diferencias"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters["@Diferencias"].Value = 0;
                cmd.Parameters.Add("@Conteos", SqlDbType.Int);
                cmd.Parameters["@Conteos"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters["@Conteos"].Value = 0;
                cmd.Parameters.AddWithValue("@Observaciones", pObservaciones);
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                cmd.ExecuteNonQuery();

                if (!string.IsNullOrEmpty(cmd.Parameters["@Diferencias"].Value.ToString()))
                {
                    if (bool.Parse(cmd.Parameters["@Diferencias"].Value.ToString()) == true)
                    {
                        MessageBox.Show("Marbete Con Diferencias, Contar Nuevamente ");

                    }
                    else
                    {
                        MessageBox.Show("Los datos se guardaron correctamente");
                    }
                }
                else
                {
                    MessageBox.Show("Los datos se guardaron correctamente");
                }
                              
                cn.Close();
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar marbete.." + ex.Message.ToString());
                return false;
            }
        }




        public bool GuardarMarbeteConDiferencias(string pEtiqueta,
            string pIdPareja,
            string pPIID,
           string pClave,
           string pLocalizacion,
            string pConteo1,
            string pObservaciones,
           bool pDiferencias,
           int pIdconteo
            )
        {
            try
            {
                //@PIID VARCHAR(50),
                //@Etiqueta NUMERIC(9),
                //@Clave VARCHAR(50) ,
                //@Localizacion VARCHAR(50),
                //@Conteo1 NUMERIC(9, 2),    
                //@Observaciones VARCHAR(100),   
                //@IdPareja INT,    
                //@Diferencias BIT  ,
                //@IdConteo INT ,
                //@Usuario VARCHAR(50)

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "intra_Inventario_GuardarMarbeteDiferencias";
                cmd.Parameters.AddWithValue("@PIID", pPIID);
                cmd.Parameters.AddWithValue("@Etiqueta", pEtiqueta);
                cmd.Parameters.AddWithValue("@Clave", pClave);
                cmd.Parameters.AddWithValue("@Localizacion", pLocalizacion);

                if (pConteo1 != "")
                {
                    cmd.Parameters.AddWithValue("@Conteo1", pConteo1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Conteo1", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("@Observaciones", pObservaciones);
                if (pIdPareja != "")
                {
                    cmd.Parameters.AddWithValue("@IdPareja", pIdPareja);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@IdPareja", "0");
                }
                cmd.Parameters.AddWithValue("@Diferencias", pDiferencias);
                cmd.Parameters.AddWithValue("@IdConteo", pIdconteo);
                cmd.Parameters.AddWithValue("@Usuario", "");
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }

                cmd.ExecuteNonQuery();

                cn.Close();
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar marbete con pedimento.." + ex.Message.ToString());
                return false;

            }

        }





        /// <summary>
        /// Verifica si existe la cantidad especificada en el detalle de los marbetes
        /// </summary>
        /// <param name="pPIID"></param>
        /// <param name="pClave"></param>
        /// <param name="pLocalizacion"></param>
        /// <param name="pConteo1"></param>
        /// <returns></returns>
        public bool VerificarCantidadMarbetePedimento( string pPIID, string pClave,
                string pLocalizacion,
                string pConteo1
              )
        {
            try
            {
                //Intra_InventarioVerificarConteoMarbetePedimento
                //@PIID VARCHAR(50),
                //@Clave VARCHAR(50),
                //@Localizacion varchar(50),
                //@Conteo1 NUMERIC(9,2)              
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = Properties.Resources.cn;
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet dt = new DataSet();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Intra_InventarioVerificarConteoMarbetePedimento";
                cmd.Parameters.AddWithValue("@PIID", pPIID);
                cmd.Parameters.AddWithValue("@Clave", pClave);
                cmd.Parameters.AddWithValue("@Localizacion", pLocalizacion);
                cmd.Parameters.AddWithValue("@Conteo1", pConteo1);
                cmd.Connection = cn;
                da.SelectCommand = cmd;
                da.Fill(dt);
                if (dt != null)
                {
                    if (dt.Tables.Count > 0)
                    {
                        if (dt.Tables[0].Rows.Count > 0)
                        {
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
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar conteos marbete.." + ex.Message.ToString());
                return false;

            }

        }


        public DataSet ListaMarbetesPedimentoLocalizacion(string pPIID, string pClave, string pLocalizacion)
        {
            try
            {
                StringBuilder cad = new StringBuilder();
                cad.Append("SELECT Etiqueta,Cant_Fisica ");
                cad.AppendLine("FROM Intra_Inventario_Maestro ");
                cad.AppendLine("WHERE (PIID=@PIID ) ");
                cad.AppendLine("AND (Clave=@Clave ) ");
                cad.AppendLine("AND (Localizacion=@Localizacion) ");
                cad.AppendLine("AND LotSerNbr IS NOT NULL ");
                cad.AppendLine("ORDER BY Cant_Fisica DESC ");
                SqlCommand cmd = new SqlCommand(cad.ToString(), cn);
                cmd.CommandType = CommandType.Text;
                DataSet dt = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                cmd.Parameters.AddWithValue("@PIID", pPIID);
                cmd.Parameters.AddWithValue("@Clave", pClave);
                cmd.Parameters.AddWithValue("@Localizacion", pLocalizacion);
                da.SelectCommand = cmd;
                da.Fill(dt);
                return dt;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener marbetes.." + ex.Message.ToString());
                return null;
            }
        }

        /// <summary>
        /// GUARDA LOS DATOS DEL MARBETE CON PEDIMENTO
        /// </summary>
        /// <param name="pEtiqueta"></param>
        /// <param name="pIdPareja"></param>
        /// <param name="pPIID"></param>
        /// <param name="pClave"></param>
        /// <param name="pLocalizacion"></param>
        /// <param name="pConteo1"></param>
        /// <param name="pObservaciones"></param>
        /// <returns></returns>
        public bool GuardarMarbetePedimento(string pEtiqueta,
                   string pIdPareja,
                   string pPIID,
                  string pClave,
                  string pLocalizacion,
                   decimal pConteo1,
                   string pObservaciones
                   )
        {
            try
            {
                //@Etiqueta NUMERIC(9),
                //@Conteo1 NUMERIC(9, 2),
                //@Conteo2 NUMERIC(9, 2),
                //@Observaciones VARCHAR(100),
                //@PIID VARCHAR(50),
                //@IdPareja INT,
                //@Usuario VARCHAR(50),
                //@Diferencias BIT  OUTPUT,
                //@Conteos INT OUTPUT

                DataSet dt = new DataSet();
                decimal CantTotSistema = 0;
                string Etiqueta = "";
                decimal Cant_Fisica = 0;
                decimal CantSuma = 0;
                decimal CantMarbete = 0;//cantidad proporcional asignada al marbete 
                bool diferencia = false;
                int cnt = 1;
                //obtener todos los marbetes con pedimento
                dt = ListaMarbetesPedimentoLocalizacion(pPIID, pClave, pLocalizacion);
                //Obtener la sumatoria total de la cantidad en sistema de todos los marbetes
                CantTotSistema = Obtener_total_localizacion(pPIID, pClave, pLocalizacion);
                //obtener el ultimo conteo
                int ultimoconteo = ObtenerUltimoConteoMarbetePedimento(pPIID, pClave, pLocalizacion);
                //si el ultimo conteo es mayor que uno
                if (ultimoconteo == 0)
                {
                    ultimoconteo = 1;
                }
                else
                {
                    ultimoconteo++;
                }

                if (CantTotSistema == pConteo1)
                {
                    //guardar los marbetes si la cantidad corresponde al total de marbetes en la localizacion
                    if (dt != null)
                    {
                        if (dt.Tables.Count > 0)
                        {
                            if (dt.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow dr in dt.Tables[0].Rows)
                                {
                                    Etiqueta = dr["Etiqueta"].ToString().Trim();
                                    if (!string.IsNullOrEmpty(dr["Cant_Fisica"].ToString()))
                                    {
                                        Cant_Fisica = decimal.Parse(dr["Cant_Fisica"].ToString());
                                    }
                                    else
                                    {
                                        Cant_Fisica = 0;
                                    }

                                    if (cnt < dt.Tables[0].Rows.Count)
                                    {
                                        CantMarbete = Math.Round((pConteo1 * Cant_Fisica) / CantTotSistema, 0);
                                        CantSuma = CantSuma + CantMarbete;
                                    }
                                    else
                                    {
                                        CantMarbete = pConteo1 - CantSuma;
                                    }
                                    
                                    guardar_marbete2(Etiqueta, pIdPareja, pPIID, pClave, pLocalizacion, CantMarbete.ToString(), pObservaciones, false, ultimoconteo);
                                    cnt++;
                                } //for
                                MessageBox.Show("Los datos se guardaron correctamente");
                            }
                        }
                    }
                }
                else
                {
                    //verificar si en el detalle de los conteos si existe la cantidad especificada
                    if (VerificarCantidadMarbetePedimento(pPIID, pClave, pLocalizacion, pConteo1.ToString()))
                    {
                        if (dt != null)
                        {
                            if (dt.Tables.Count > 0)
                            {
                                if (dt.Tables[0].Rows.Count > 0)
                                {
                                    foreach (DataRow dr in dt.Tables[0].Rows)
                                    {
                                        Etiqueta = dr["Etiqueta"].ToString().Trim();
                                        if (!string.IsNullOrEmpty(dr["Cant_Fisica"].ToString()))
                                        {
                                            Cant_Fisica = decimal.Parse(dr["Cant_Fisica"].ToString());
                                        }
                                        else
                                        {
                                            Cant_Fisica = 0;
                                        }

                                        if (cnt < dt.Tables[0].Rows.Count)
                                        {
                                            CantMarbete = Math.Round((pConteo1 * Cant_Fisica) / CantTotSistema, 0);
                                            CantSuma = CantSuma + CantMarbete;
                                        }
                                        else
                                        {
                                            CantMarbete = pConteo1 - CantSuma;
                                        }
                                        guardar_marbete2(Etiqueta, pIdPareja, pPIID, pClave, pLocalizacion, CantMarbete.ToString(), pObservaciones, false, ultimoconteo);
                                        cnt++;
                                    } //for

                                    MessageBox.Show("Los Datos De Conteo Se Guardaron Correctamente..");


                                }
                            }
                        }
                    }
                    else
                    {
                        //guardar los marbetes con diferencia
                        if (dt != null)
                        {
                            if (dt.Tables.Count > 0)
                            {
                                if (dt.Tables[0].Rows.Count > 0)
                                {
                                    foreach (DataRow dr in dt.Tables[0].Rows)
                                    {
                                        Etiqueta = dr["Etiqueta"].ToString().Trim();
                                        if (!string.IsNullOrEmpty(dr["Cant_Fisica"].ToString()))
                                        {
                                            Cant_Fisica = decimal.Parse(dr["Cant_Fisica"].ToString());
                                        }
                                        else
                                        {
                                            Cant_Fisica = 0;
                                        }

                                        if (cnt < dt.Tables[0].Rows.Count)
                                        {
                                            CantMarbete = Math.Round((pConteo1 * Cant_Fisica) / CantTotSistema, 0);
                                            CantSuma = CantSuma + CantMarbete;
                                        }
                                        else
                                        {
                                            CantMarbete = pConteo1 - CantSuma;
                                        }
                                        guardar_marbete2(Etiqueta, pIdPareja, pPIID, pClave, pLocalizacion, CantMarbete.ToString(), pObservaciones, true, ultimoconteo);

                                        cnt++;
                                    } //for
                                    MessageBox.Show("Marbetes Con Diferencias...");
                                }
                            }
                        }
                    }

                }

                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar marbete con pedimento.." + ex.Message.ToString());
                return false;

            }

        }


        /// <summary>
        /// GUARDA LOS DATOS DEL MARBETE CON PEDIMENTO QUE TENGA DIFERENCIAS
        /// </summary>
        /// <param name="pEtiqueta"></param>
        /// <param name="pIdPareja"></param>
        /// <param name="pPIID"></param>
        /// <param name="pClave"></param>
        /// <param name="pLocalizacion"></param>
        /// <param name="pConteo1"></param>
        /// <param name="pObservaciones"></param>
        /// <returns></returns>
        public bool GuardarMarbetePedimentoConDiferencias(string pEtiqueta,
                   string pIdPareja,
                   string pPIID,
                  string pClave,
                  string pLocalizacion,
                   decimal pConteo1,
                   string pObservaciones
                   )
        {
            try
            {
                //@Etiqueta NUMERIC(9),
                //@Conteo1 NUMERIC(9, 2),
                //@Conteo2 NUMERIC(9, 2),
                //@Observaciones VARCHAR(100),
                //@PIID VARCHAR(50),
                //@IdPareja INT,
                //@Usuario VARCHAR(50),
                //@Diferencias BIT  OUTPUT,
                //@Conteos INT OUTPUT

                DataSet dt = new DataSet();
                decimal CantTotSistema = 0;
                string Etiqueta = "";
                decimal Cant_Fisica = 0;
                decimal CantSuma = 0;
                decimal CantMarbete = 0;//cantidad proporcional asignada al marbete 
                bool diferencia = false;
                int cnt = 1;
                //obtener todos los marbetes con pedimento
                dt = ListaMarbetesPedimentoLocalizacion(pPIID, pClave, pLocalizacion);
                //Obtener la sumatoria total de la cantidad en sistema de todos los marbetes
                CantTotSistema = Obtener_total_localizacion(pPIID, pClave, pLocalizacion);
                //obtener el ultimo conteo
                int ultimoconteo = ObtenerUltimoConteoMarbetePedimento(pPIID, pClave, pLocalizacion);
                //si el ultimo conteo es mayor que uno
                if (ultimoconteo == 0)
                {
                    ultimoconteo = 1;
                }
                else
                {
                    ultimoconteo++;
                }

                if (CantTotSistema == pConteo1)
                {
                    //guardar los marbetes si la cantidad corresponde al total de marbetes en la localizacion
                    if (dt != null)
                    {
                        if (dt.Tables.Count > 0)
                        {
                            if (dt.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow dr in dt.Tables[0].Rows)
                                {
                                    Etiqueta = dr["Etiqueta"].ToString().Trim();
                                    if (!string.IsNullOrEmpty(dr["Cant_Fisica"].ToString()))
                                    {
                                        Cant_Fisica = decimal.Parse(dr["Cant_Fisica"].ToString());
                                    }
                                    else
                                    {
                                        Cant_Fisica = 0;
                                    }

                                    if (cnt < dt.Tables[0].Rows.Count)
                                    {
                                        CantMarbete = Math.Round((pConteo1 * Cant_Fisica) / CantTotSistema, 0);
                                        CantSuma = CantSuma + CantMarbete;
                                    }
                                    else
                                    {
                                        CantMarbete = pConteo1 - CantSuma;
                                    }                                    
                                   // guardar_marbete2(Etiqueta, pIdPareja, pPIID, pClave, pLocalizacion, CantMarbete.ToString(), pObservaciones, false, ultimoconteo);
                                    GuardarMarbeteConDiferencias(Etiqueta, pIdPareja, pPIID, pClave, pLocalizacion, CantMarbete.ToString(), pObservaciones, false, ultimoconteo);

                                    cnt++;
                                } //for
                                MessageBox.Show("Los datos se guardaron correctamente");
                            }
                        }
                    }
                }
                else
                {
                    //verificar si en el detalle de los conteos si existe la cantidad especificada
                    if (VerificarCantidadMarbetePedimento(pPIID, pClave, pLocalizacion, pConteo1.ToString()))
                    {
                        if (dt != null)
                        {
                            if (dt.Tables.Count > 0)
                            {
                                if (dt.Tables[0].Rows.Count > 0)
                                {
                                    foreach (DataRow dr in dt.Tables[0].Rows)
                                    {
                                        Etiqueta = dr["Etiqueta"].ToString().Trim();
                                        if (!string.IsNullOrEmpty(dr["Cant_Fisica"].ToString()))
                                        {
                                            Cant_Fisica = decimal.Parse(dr["Cant_Fisica"].ToString());
                                        }
                                        else
                                        {
                                            Cant_Fisica = 0;
                                        }

                                        if (cnt < dt.Tables[0].Rows.Count)
                                        {
                                            CantMarbete = Math.Round((pConteo1 * Cant_Fisica) / CantTotSistema, 0);
                                            CantSuma = CantSuma + CantMarbete;
                                        }
                                        else
                                        {
                                            CantMarbete = pConteo1 - CantSuma;
                                        }
                                        //guardar_marbete2(Etiqueta, pIdPareja, pPIID, pClave, pLocalizacion, CantMarbete.ToString(), pObservaciones, false, ultimoconteo);
                                        GuardarMarbeteConDiferencias(Etiqueta, pIdPareja, pPIID, pClave, pLocalizacion, CantMarbete.ToString(), pObservaciones, false, ultimoconteo);
                                                                                
                                        cnt++;
                                    } //for

                                    MessageBox.Show("Los Datos De Conteo Se Guardaron Correctamente..");


                                }
                            }
                        }
                    }
                    else
                    {
                        //guardar los marbetes con diferencia
                        if (dt != null)
                        {
                            if (dt.Tables.Count > 0)
                            {
                                if (dt.Tables[0].Rows.Count > 0)
                                {
                                    foreach (DataRow dr in dt.Tables[0].Rows)
                                    {
                                        Etiqueta = dr["Etiqueta"].ToString().Trim();
                                        if (!string.IsNullOrEmpty(dr["Cant_Fisica"].ToString()))
                                        {
                                            Cant_Fisica = decimal.Parse(dr["Cant_Fisica"].ToString());
                                        }
                                        else
                                        {
                                            Cant_Fisica = 0;
                                        }

                                        if (cnt < dt.Tables[0].Rows.Count)
                                        {
                                            CantMarbete = Math.Round((pConteo1 * Cant_Fisica) / CantTotSistema, 0);
                                            CantSuma = CantSuma + CantMarbete;
                                        }
                                        else
                                        {
                                            CantMarbete = pConteo1 - CantSuma;
                                        }
                                        //guardar_marbete2(Etiqueta, pIdPareja, pPIID, pClave, pLocalizacion, CantMarbete.ToString(), pObservaciones, true, ultimoconteo);
                                        GuardarMarbeteConDiferencias(Etiqueta, pIdPareja, pPIID, pClave, pLocalizacion, CantMarbete.ToString(), pObservaciones, true, ultimoconteo);
                                        cnt++;
                                    } //for
                                    MessageBox.Show("Marbetes Con Diferencias...");
                                }
                            }
                        }
                    }

                }

                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar marbete con pedimento.." + ex.Message.ToString());
                return false;

            }

        }





        /// <summary>
        /// Guarda los datos del marbete normal
        /// </summary>
        /// <param name="pEtiqueta"></param>
        /// <param name="pIdPareja"></param>
        /// <param name="pPIID"></param>
        /// <param name="pConteo1"></param>
        /// <param name="pObservaciones"></param>
        /// <returns></returns>
        public bool guardar_marbete(string pEtiqueta, string pIdPareja, string pPIID, string pConteo1, string pObservaciones)
        {
            try
            {
                //@Etiqueta NUMERIC(9),
                //@Conteo1 NUMERIC(9, 2),
                //@Conteo2 NUMERIC(9, 2),
                //@Observaciones VARCHAR(100),
                //@PIID VARCHAR(50),
                //@IdPareja INT,
                //@Usuario VARCHAR(50),
                //@Diferencias BIT  OUTPUT,
                //@Conteos INT OUTPUT
                string cad = "";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "intra_Inventario_Guardar_Marbete";
                cmd.Parameters.AddWithValue("@Usuario", "");

                if (pIdPareja != "")
                {
                    cmd.Parameters.AddWithValue("@IdPareja", pIdPareja);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@IdPareja", "0");
                }
                cmd.Parameters.AddWithValue("@Etiqueta", pEtiqueta);
                cmd.Parameters.AddWithValue("@PIID", pPIID);
                if (pConteo1 != "")
                {
                    cmd.Parameters.AddWithValue("@Conteo1", pConteo1);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Conteo1", DBNull.Value);
                }

                cmd.Parameters.AddWithValue("@Conteo2", DBNull.Value);
                //}
                cmd.Parameters.Add("@Diferencias", SqlDbType.Bit);
                cmd.Parameters["@Diferencias"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters["@Diferencias"].Value = 0;
                cmd.Parameters.Add("@Conteos", SqlDbType.Int);
                cmd.Parameters["@Conteos"].Direction = ParameterDirection.InputOutput;
                cmd.Parameters["@Conteos"].Value = 0;
                cmd.Parameters.AddWithValue("@Observaciones", pObservaciones);
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                cmd.ExecuteNonQuery();
                
                MessageBox.Show("Los datos se guardaron correctamente");
               
                cn.Close();
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar marbete.." + ex.Message.ToString());
                return false;
            }

        }
        /// <summary>
        /// Obtiene el total de conteos del marbete
        /// </summary>
        /// <param name="pPIID"></param>
        /// <param name="pEtiqueta"></param>
        /// <returns></returns>
        public int TotConteosMarbete( string pPIID, string pEtiqueta)
        {
            try
            {
                //SELECT COUNT(IdConteo)
                //FROM Intra_Inventario_Maestro_Detalle
                //WHERE (PIID=@PIID)
                //AND (Etiqueta=@Etiqueta)
                string cad = "SELECT COUNT(IdConteo) FROM Intra_Inventario_Maestro_Detalle WHERE (PIID=@PIID) AND (Etiqueta=@Etiqueta)";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text ;
                cmd.CommandText = cad;
                cmd.Parameters.AddWithValue("@PIID", pPIID);
                cmd.Parameters.AddWithValue("@Etiqueta", pEtiqueta);                
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                int tot=int.Parse(cmd.ExecuteScalar().ToString())  ;              
                cn.Close();
                return tot;

            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al obtener conteos.." + ex.Message.ToString());
                return 0;
            }

        }

        public bool ObetenerMarbeteConteoDiferencias(out string Etiqueta)
        {
            try
            {
                //intra_InventarioObtenerMarbeteConteoDiferencias  
                //@PIID VARCHAR(20),
                //@IdPareja int               
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet dt = new DataSet();
                cmd.CommandType = CommandType.StoredProcedure ;
                cmd.CommandText = "intra_InventarioObtenerMarbeteConteoDiferencias";
                cmd.Parameters.AddWithValue("@PIID", piid);
                cmd.Parameters.AddWithValue("@IdPareja", id_pareja);
                da.SelectCommand = cmd;
                da.Fill(dt);
                DataRow dr;
                if (dt != null)
                {
                    if (dt.Tables.Count > 0)
                    {
                        if (dt.Tables[0].Rows.Count > 0)
                        {
                            dr = dt.Tables[0].Rows[0];
                            Etiqueta = dr[0].ToString().Trim();
                            return true;
                        }
                        else
                        {
                            Etiqueta = "";
                            return false;
                        }
                    }
                    else
                    {
                        Etiqueta = "";
                        return false;
                    }
                }
                else
                {
                    Etiqueta = "";
                    return false;
                }

            }
            catch (Exception ex)
            {
               
                MessageBox.Show("Error al obtener marbete para conteo" + ex.Message.ToString());
                Etiqueta = "";
                return false;
            }

        }

        /// <summary>
        /// Libera para conteo el marbete especificado
        /// </summary>
        /// <param name="Etiqueta"></param>
        /// <returns></returns>
        public bool LiberarMarbeteConteoDiferencias(string Etiqueta)
        {
            try
            {                
               //@PIID VARCHAR(20),
               //@Etiqueta INT,
               //@IdPareja INT              
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;                
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "intra_InventarioLiberarMarbeteConteoDiferencias";
                cmd.Parameters.AddWithValue("@PIID", piid);
                cmd.Parameters.AddWithValue("@IdPareja", id_pareja);
                cmd.Parameters.AddWithValue("@Etiqueta", Etiqueta);
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                cmd.ExecuteNonQuery();
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                return true; 

            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al liberar marbete" + ex.Message.ToString());               
                return false;
            }

        }
        /// <summary>
        /// Obtiene la clave del articulo que esta asginada a la localizacion
        /// </summary>
        /// <param name="loc"></param>
        /// <param name="invtid"></param>
        /// <returns></returns>
        public bool verificar_localizacion_articulo( string loc, out string invtid)
        {
            try
            {
                //intra_inventario_validar_loc_marbete_manual
                //@SiteID  VARCHAR(20),
                //@WhseLoc VARCHAR(50)                
                SqlCommand cmd = new SqlCommand("intra_inventario_validar_loc_marbete_manual", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SiteID", siteid);
                cmd.Parameters.AddWithValue("@WhseLoc", loc);
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                string res = "";
                //obiene la clave del articulo agninada a la localizacion
                res = cmd.ExecuteScalar().ToString().Trim();
                cn.Close();
                invtid = res;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar localizacion.." + ex.Message.ToString());
                invtid = "";
                return false;
            }
        }

        /// <summary>
        /// Obtiene el pasillo correspondiente a la localizacion
        /// </summary>
        /// <param name="pLoc"></param>
        /// <returns></returns>
        public string ObtenerPasilloLocalizacion(string pLoc)
        {
            try
            {
                StringBuilder cad = new StringBuilder();
                cad.Append("SELECT TOP(1) intra_Inventario_Pasillos.Pasillo ");
                cad.AppendLine("FROM intra_Inventario_Pasillos_localizaciones INNER JOIN ");
                cad.AppendLine("intra_Inventario_Pasillos ON intra_Inventario_Pasillos_localizaciones.IdPasillo = intra_Inventario_Pasillos.IdPasillo ");
                cad.AppendLine("WHERE intra_Inventario_Pasillos_localizaciones.SiteID=@SiteID ");
                cad.AppendLine("AND intra_Inventario_Pasillos_localizaciones.Localizacion=@Localizacion ");              
                SqlCommand cmd = new SqlCommand(cad.ToString() , cn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@SiteID", siteid);
                cmd.Parameters.AddWithValue("@Localizacion", pLoc);
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                string pasillo = "";
                //obiene la clave del articulo agninada a la localizacion
                pasillo = cmd.ExecuteScalar().ToString().Trim();
                cn.Close();
                return pasillo;              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener Pasillo " + ex.Message.ToString());               
                return "";
            }
        }




    }
}

