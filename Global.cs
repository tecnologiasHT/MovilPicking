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
using System.Drawing;
//using HelperAccesoDatos;

namespace Picking
{
    public class Global
    {
        public static string usuario;
        public static string invcnbr = "";   //factura principal de el usuario
        public static string invcnbr2 = ""; //factura alterna de el usuario
        public static string nombre;
        public static string puesto;
        public static string area="";//area de surtimiento
        public static string zona=""; //zona de surtimiento
        public static int idarea=0;//area de surtimiento
        public static int idzona=0; //zona de surtimiento
        public static string status_factura;
        public static int orden_zona;//indica el orden en el cual se empezara el surtimiento
        public static int idproceso;
        public static int picking;
        public static string factura = ""; //factura actual en surtimiento por el usuario
        public static SqlConnection cn = new SqlConnection(Properties.Resources.connectionstring);
        public static string cajap2 = "";
        public static string tipocaja = "";
        public static DateTime fecha_ultima_actividad; //indica la fecha de la ultima actividad del usuario
        public static bool timeout=false;

        /// <summary>
        /// Funcion para obtener la fecha y hora actual
        /// </summary>
        public static DateTime FechaHoraActual()
        {
            //intra_ObtenerFechaHoy
            string fecha = "";
            try
            {
                //Declaramos el comando para ejecutar el query
                //cn.ConnectionString = Properties.Resources.connectionstring;
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("intra_ObtenerFechaHoraActual", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                //Abrimos conexin a BD
                if (cn.State == ConnectionState.Closed)
                {
                   cn.Open();
                }
                fecha = cmd.ExecuteScalar().ToString();
                DateTime result;
                result=DateTime.Parse(fecha);
                return result;
            }//try
            catch 
            {               
                return DateTime.Now;
            } // catch
            finally
            {
                if (cn != null && cn.State != ConnectionState.Closed)
                {
                    //Cerramos conexión a BD
                    cn.Close();
                }
            }//finally   

        }

        /// <summary>
        /// Funcion para obtener el nombre del usuario actual
        /// </summary>
        public static string  NombreUsuario(string pUsuario)
        {
           
            try
            {               
                SqlCommand cmd = new SqlCommand("SELECT Nombre FROM  ADN_Almacenistas where NumNomina=@NumNomina", cn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@NumNomina", pUsuario); 
                //Abrimos conexin a BD
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                string usuario = cmd.ExecuteScalar().ToString();               
                return usuario;
            }//try
            catch
            {
                return "";
            } // catch
            finally
            {
                if (cn != null && cn.State != ConnectionState.Closed)
                {
                    //Cerramos conexión a BD
                    cn.Close();
                }
            }//finally   

        }
        /// <summary>
        /// Funcion para agregar los eventos de inactividad de los usuarios
        /// </summary>
        public static bool agregar_log_eventos(
            string pEvento,
            string pDescripcion,
            string pInvcNbr,
            string pUsuario,
            string pLocalizacion
            )
        {
            //ADN_AgregarLogEventos
            //@Evento, 
            //@Descripcion , 
            //@InvcNbr , 
            //@Usuario ,
            //@Picking , 
            //@Zona , 
            //@Area , 
            //@Localizacion
    //   @Evento VARCHAR(100), 
    //@Descripcion VARCHAR(max), 
    //@InvcNbr VARCHAR(20), 
    //@Usuario VARCHAR(50),
    //@Picking VARCHAR(50), 
    //@Zona VARCHAR(50), 
    //@Area VARCHAR(50), 
    //@Localizacion VARCHAR(50) 

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_AgregarLogEventos";
            cmd.Parameters.AddWithValue("@Evento", pEvento);
            cmd.Parameters.AddWithValue("@Descripcion", pDescripcion);
            cmd.Parameters.AddWithValue("@InvcNbr", pInvcNbr);
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario);
            cmd.Parameters.AddWithValue("@Picking", Global.picking);
            cmd.Parameters.AddWithValue("@Zona", Global.idzona.ToString());
            if (Global.area != null)
            {
                cmd.Parameters.AddWithValue("@Area", Global.area);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Area", "");
            }
           
            cmd.Parameters.AddWithValue("@Localizacion",pLocalizacion );           
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
                MessageBox.Show("Error al agregar log" + ex.Message.ToString());
                return false;
            }


        }

        /// <summary>
        /// Funcion para agregar los eventos de excepciones: desbloque de localizaciones, excepciones para leer articulos manualmente
        /// </summary>
        public static bool registrar_log_eventos_supervisor(
            string pEvento,
            string pDescripcion,
            string pInvcNbr,
            string pUsuario,
            string pLocalizacion,
            string supervisor

            )
        {
            //ADN_AgregarLogEventos
            //@Evento, 
            //@Descripcion , 
            //@InvcNbr , 
            //@Usuario ,
            //@Picking , 
            //@Zona , 
            //@Area , 
            //@Localizacion
            // @Evento VARCHAR(100), 
            //@Descripcion VARCHAR(max), 
            //@InvcNbr VARCHAR(20), 
            //@Usuario VARCHAR(50),
            //@Picking VARCHAR(50), 
            //@Zona VARCHAR(50), 
            //@Area VARCHAR(50), 
            //@Localizacion VARCHAR(50) 

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_AgregarLogEventos";
            cmd.Parameters.AddWithValue("@Evento", pEvento);
            cmd.Parameters.AddWithValue("@Descripcion", pDescripcion);
            cmd.Parameters.AddWithValue("@InvcNbr", pInvcNbr);
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario);
            cmd.Parameters.AddWithValue("@Picking", Global.picking);
            cmd.Parameters.AddWithValue("@Zona", Global.idzona.ToString());
            if (Global.area != null)
            {
                cmd.Parameters.AddWithValue("@Area", Global.area);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Area", "");
            }

            cmd.Parameters.AddWithValue("@Localizacion", pLocalizacion);
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
                MessageBox.Show("Error al agregar log" + ex.Message.ToString());
                return false;
            }


        }


        /// <summary>
        /// Obtiene el total de ventos 
        /// </summary>

        public static int  total_eventos_usuario_dia( string pUsuario )      
        {
           //ADN_TotalEventosUsuarioDia
           //@Usuario VARCHAR(50)	
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_TotalEventosUsuarioDia";
            cmd.Parameters.AddWithValue("@Usuario", pUsuario);                    
            try
            {
                if (Global.cn.State == ConnectionState.Closed)
                {
                    Global.cn.Open();
                }
                int tot= int.Parse(cmd.ExecuteScalar().ToString());
                return tot;

            }
            catch 
            {                
                return -1;
            }


        }

        /// <summary>
        /// Obtiene la lista de excepciones registradas de la localizacion especificada
        /// </summary>
        public static DataTable  ObtenerExcepcionesLocalizacion()
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet dt = new DataSet();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT IdExcepcion, Excepcion FROM  ADN_ExcepcionesLocalizacion";
            da.SelectCommand = cmd; 
            try
            {
                da.Fill(dt);
                return dt.Tables[0]; 
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Verifica si ya existe una excepcion registrada en la localizacion especificada
        /// </summary>
        public static  bool VerificarExcepcionesLocalizacion(string pLocalizacion)
        {
            //Funcion para verificar si ya existen excepciones registradas en la laocalizacion especificada
            //ADN_ObtenerExcepcionesLocalizacion
            //@Localizacion VARCHAR(50)
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet dt = new DataSet();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_ObtenerExcepcionesLocalizacion";
            cmd.Parameters.AddWithValue("@Localizacion", pLocalizacion);
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
                            //indica que ya existe una excepcion registrada
                            return true;
                        }
                        else
                        {
                            //No hay ninguna excepcion registrada
                            return false;
                        }
                    }
                    else
                    {
                        //No hay ninguna excepcion registrada
                        return false;
                    }
                }
                else
                {
                    //No hay ninguna excepcion registrada
                    return false;
                }
               
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Verifica si ya existe una excepcion registrada para la clave del articulo especificado
        /// </summary>
        public static  bool VerificarCapturaArticulo(string pInvID)
        {
            //Funcion para verificar si el articulo se puede capturar por clave
            //ADN_ObtenerExcepcionesLocalizacion
            //@Localizacion VARCHAR(50)
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet dt = new DataSet();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT InvtID FROM  ADN_ExcepcionesCapturaArticulos  WHERE InvtID=@InvtID";
            cmd.Parameters.AddWithValue("@InvtID", pInvID);
            try
            {
                da.Fill(dt);
                if (dt != null)
                {
                    if (dt.Tables.Count > 0)
                    {
                        if (dt.Tables[0].Rows.Count > 0)
                        {
                            //indica que ya existe una excepcion registrada
                            return true;
                        }
                        else
                        {
                            //No hay ninguna excepcion registrada
                            return false;
                        }
                    }
                    else
                    {
                        //No hay ninguna excepcion registrada
                        return false;
                    }
                }
                else
                {
                    //No hay ninguna excepcion registrada
                    return false;
                }
               
            }
            catch
            {
                return false;
            }
        }
        
         /// <summary>
        /// Verifica si ya la clave especificada esta registrada para surtimiento agranel
        /// </summary>
        public static  bool VerificarArticuloAgranel(string pInvID)
        {           
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet dt = new DataSet();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT  InvtID FROM  ADN_ArticulosConSurtimientoAgranel WHERE InvtID=@InvtID";
            cmd.Parameters.AddWithValue("@InvtID", pInvID);
            try
            {
                da.Fill(dt);
                if (dt != null)
                {
                    if (dt.Tables.Count > 0)
                    {
                        if (dt.Tables[0].Rows.Count > 0)
                        {
                            //indica que ya existe una excepcion registrada
                            return true;
                        }
                        else
                        {
                            //No hay ninguna excepcion registrada
                            return false;
                        }
                    }
                    else
                    {
                        //No hay ninguna excepcion registrada
                        return false;
                    }
                }
                else
                {
                    //No hay ninguna excepcion registrada
                    return false;
                }
               
            }
            catch
            {
                return false;
            }
        }



          
   
  


        // public static bool enviar_mensaje_evento(
       // string pEvento,
       // string pDescripcion,
       // //string pNombre,
       // string pAsunto,
       // string pZona,
       // string pPicking,
       // string pArea,
       // string pLocalizacion,
       // string pInvcNbr,       
       // string pUsuario

       //)
       // {
       //     OpenNETCF.Net.Mail.MailMessage message = new OpenNETCF.Net.Mail.MailMessage();
       //     message.To.Add("julio.sifuentes@hecort.com");
       //     message.To.Add("jose.vazquez@hecort.com");
       //     message.Bcc.Add("martin.medina@hecort.com");   
       //     DateTime fecha=FechaHoraActual(); 
       //     //message.To.Add("martin.medina@hecort.com");
       //     message.Subject = pAsunto;
       //     message.From = new OpenNETCF.Net.Mail.MailAddress("no_responder@hecort.com");
       //     //message.Body = mensaje;
       //     OpenNETCF.Net.Mail.SmtpClient smtp = new OpenNETCF.Net.Mail.SmtpClient();
       //     //NetworkCredential cred = new NetworkCredential("mmedina", "mmedina");
       //     OpenNETCF.Net.Mail.SmtpCredential cred =new OpenNETCF.Net.Mail.SmtpCredential("mmedina","mmedina","hecort.com");
       //     smtp.Credentials = cred; 
   
       //     //smtp.Credentials.UserName="mmedina";
       //     //smtp.Credentials.Password="mmedina";
       //     //smtp.EnableSsl = true;   
       //     smtp.DeliveryMethod = OpenNETCF.Net.Mail.SmtpDeliveryMethod.Network;
       //     smtp.Host = "192.168.1.5";
       //     smtp.Port = 587;
            
       //     //obtener el total de ventos

       //     int tot_eventos=total_eventos_usuario_dia(pUsuario);
       //     if(tot_eventos >=0)
       //     {
       //      tot_eventos++;
       //     }
       //     //obtener los articulos por surtir de la factura
       //     int tot_ps = total_articulos_status(pInvcNbr, "PS");

       //     string nombre_usuario = NombreUsuario(pUsuario);
       //     //[FECHA]
       //     //[USUARIO]
       //     //[NOMBRE]
       //     //[EVENTO]
       //     //[DESCRIPCION]
       //     //[FACTURA]
       //     //[PICKING]
       //     //[ZONA]
       //     //[AREA]
       //     //[LOCALIZACION]
       //     //[EVENTOS]
       //     //[PARTIDAS]

       //     string fullpath = "";         
       //     string path;
       //     path = System.IO.Path.GetDirectoryName( 
       //     System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase );
       //     //MessageBox.Show( path );

          
       //    System.IO.DirectoryInfo di = new DirectoryInfo(path);
       //    //if (di.Exists)
       //    //{
       //        fullpath = Path.Combine(path, "Aviso_Evento_Log.html");
       //        System.IO.FileInfo fi = new FileInfo(fullpath);

       //        if (!fi.Exists)
       //        {
       //            //MessageBox.Show("El mensaje de notificacion no se envio correctamente, la plantilla de mensajes no fue encontrada");
       //            return false;
       //        }

       //     string TemplateName = fullpath;
                                
       //     using (StreamReader sReader = new StreamReader(TemplateName))
       //     {
       //         string htmlTemplate = sReader.ReadToEnd();
       //         htmlTemplate = htmlTemplate.Replace("[FECHA]",fecha.ToString()  );
       //         htmlTemplate = htmlTemplate.Replace("[USUARIO]",pUsuario );
       //         htmlTemplate = htmlTemplate.Replace("[NOMBRE]", nombre_usuario);
       //         htmlTemplate = htmlTemplate.Replace("[EVENTO]", pEvento);
       //         htmlTemplate = htmlTemplate.Replace("[DESCRIPCION]", pDescripcion);
       //         htmlTemplate = htmlTemplate.Replace("[FACTURA]", pInvcNbr);
       //         htmlTemplate = htmlTemplate.Replace("[PARTIDAS]", tot_ps.ToString().Trim()  );                
       //         htmlTemplate = htmlTemplate.Replace("[PICKING]", pPicking);
       //         htmlTemplate = htmlTemplate.Replace("[ZONA]", pZona);
       //         htmlTemplate = htmlTemplate.Replace("[AREA]", pArea);
       //         htmlTemplate = htmlTemplate.Replace("[LOCALIZACION]", pLocalizacion);
       //         htmlTemplate = htmlTemplate.Replace("[EVENTOS]", tot_eventos.ToString().Trim() );
       //         message.Body = htmlTemplate;
               
       //     }
       //     try
       //     {
       //         smtp.Send(message);                
       //         return true;
       //     }
       //     catch 
       //     {
       //         //msj = "Error al enviar mensaje.." + ex.Message.ToString();
       //         return false;
       //     }
       // }
        
        //public static DateTime GetNetworkTime()
        //{
        //    try
        //    {
        //        const string ntpServer = "pool.ntp.org";
        //        var ntpData = new byte[48];
        //        ntpData[0] = 0x1B; //LeapIndicator = 0 (no warning), VersionNum = 3 (IPv4 only), Mode = 3 (Client Mode)

        //        var addresses = Dns.GetHostEntry(ntpServer).AddressList;
        //        var ipEndPoint = new IPEndPoint(addresses[0], 123);
        //        var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        //        socket.Connect(ipEndPoint);
        //        socket.Send(ntpData);
        //        socket.Receive(ntpData);
        //        socket.Close();

        //        ulong intPart = (ulong)ntpData[40] << 24 | (ulong)ntpData[41] << 16 | (ulong)ntpData[42] << 8 | (ulong)ntpData[43];
        //        ulong fractPart = (ulong)ntpData[44] << 24 | (ulong)ntpData[45] << 16 | (ulong)ntpData[46] << 8 | (ulong)ntpData[47];

        //        var milliseconds = (intPart * 1000) + ((fractPart * 1000) / 0x100000000L);
        //        var networkDateTime = (new DateTime(1900, 1, 1)).AddMilliseconds((long)milliseconds);
        //        return networkDateTime;
        //    }
        //    catch
        //    {
        //        return DateTime.Now ;
        //    }
        //}

        /// <summary>
        /// obtener el total de minutos de tolerancia para picking1
        /// </summary>
        /// <returns></returns>
        public static int  tot_minutos_timeout()
        {          
            try
            {
                //obtiene el total de minutos que puede estar un usuario sin actividad                
              
                SqlCommand cmd = new SqlCommand("SELECT TOP(1) TimeOutPicking FROM  ADN_ParametrosGenerales", cn);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;
                //Abrimos conexin a BD
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                int tot = int.Parse(cmd.ExecuteScalar().ToString());
                return tot;
            }//try
            catch
            {
                return -1;
            } // catch
            finally
            {
                if (cn != null && cn.State != ConnectionState.Closed)
                {
                    //Cerramos conexión a BD
                    cn.Close();
                }
            }//finally   

        }

        /// <summary>
        /// Obtener el total de minutos de tolerancia para picking2
        /// </summary>
        /// <returns></returns>
        public static int tot_minutos_timeout_picking2()
        {
            try
            {
                //obtiene el total de minutos que puede estar un usuario sin actividad                

                SqlCommand cmd = new SqlCommand("SELECT TOP (1) TimeOutPicking2 FROM  ADN_ParametrosGenerales", cn);
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;
                //Abrimos conexin a BD
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                int tot = int.Parse(cmd.ExecuteScalar().ToString());
                cn.Close(); 
                return tot;
            }//try
            catch
            {
                return -1;
            } // catch
            finally
            {
                if (cn != null && cn.State != ConnectionState.Closed)
                {
                    //Cerramos conexión a BD
                    cn.Close();
                }
            }//finally   

        }


        public static bool TimeOutPicking()
        {
            try
            {
                if (fecha_ultima_actividad != null)
                {
                    DateTime fecha = FechaHoraActual();
                    //obtener el total de minutos de inactividad                
                    int tot_inactividad = fecha.Subtract(fecha_ultima_actividad).Minutes;
                    //obtener los m inutos de inactividad maximos para aplicar el timeout
                    int tot_minutos = 0;
                    if (picking == 1)
                    {
                     tot_minutos= tot_minutos_timeout();
                    }
                    else if (picking == 2)
                    {
                        tot_minutos = tot_minutos_timeout_picking2();
                    }
                    else
                    {
                        //valor default
                        tot_minutos = 10;
                    }
                    
                    if (tot_inactividad > 0 && tot_minutos > 0)
                    {
                        if (tot_inactividad >= tot_minutos)
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
            catch
            {
                return false;
            
            }
        
        }

        public static bool agregar_status_zona(string invcnbr, int idzona, string status)
        {
            //ADN_agregar_status_zonas	
            //@InvcNbr VARCHAR(10),
            //@IdZona INT,
            //@Picking INT,
            //@Status varchar(20),
            //@Usuario VARCHAR(50)
            if (string.IsNullOrEmpty(invcnbr))
            {
                return false;
            }

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
                return false;
            }


        }


        public static bool agregar_status_zona_area(string invcnbr, int Zona1, string Area1, string status)
        {
            //ADN_agregar_status_zona_area	
            //@InvcNbr VARCHAR(10),
            //@IdZona INT,
            //@Area VARCHAR(50),
            //@Status varchar(20),
            //@Usuario VARCHAR(50)
            if (string.IsNullOrEmpty(invcnbr))
            {
                return false;
            }
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_agregar_status_zona_area";
            cmd.Parameters.AddWithValue("@InvcNbr", invcnbr);
            cmd.Parameters.AddWithValue("@IdZona", Zona1);
            cmd.Parameters.AddWithValue("@Area", Area1);
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

        //public static bool agregar_status_zona_area_picking1(string invcnbr, int Zona1, string Area1, string status)
        //{
        //    //ADN_agregar_status_zona_area	
        //    //@InvcNbr VARCHAR(10),
        //    //@IdZona INT,
        //    //@Area VARCHAR(50),
        //    //@Status varchar(20),
        //    //@Usuario VARCHAR(50)
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Connection = Global.cn;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = "ADN_agregar_status_zona_area";
        //    cmd.Parameters.AddWithValue("@InvcNbr", invcnbr);
        //    cmd.Parameters.AddWithValue("@IdZona", Zona1);
        //    cmd.Parameters.AddWithValue("@Area", Area1);
        //    cmd.Parameters.AddWithValue("@Status", status);
        //    cmd.Parameters.AddWithValue("@Usuario", Global.usuario);
        //    try
        //    {
        //        if (Global.cn.State == ConnectionState.Closed)
        //        {
        //            Global.cn.Open();
        //        }
        //        cmd.ExecuteNonQuery();
        //        return true;

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al agregar status de factura.." + ex.Message.ToString());
        //        return false;
        //    }

        //}


       public static bool agregar_status_zonas_area_picking1(string invcnbr, int idzona, string area, string status)
        {
            //ADN_agregar_status_zona_area_picking	
            //@InvcNbr VARCHAR(10),
            //@IdZona INT,
            //@Area VARCHAR(50),
            //@Status varchar(20),
            //@Picking INT,
            //@Usuario VARCHAR(50)
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_agregar_status_zona_area_picking";
            cmd.Parameters.AddWithValue("@InvcNbr", invcnbr);
            cmd.Parameters.AddWithValue("@IdZona", idzona);
            cmd.Parameters.AddWithValue("@Area", area);
            cmd.Parameters.AddWithValue("@Status", status);
            cmd.Parameters.AddWithValue("@Picking", Global.picking);
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario);
            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                   cn.Open();
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




        /// <summary>
        /// Test that the server is connected
        /// </summary>
        /// <param name="connectionString">The connection string</param>
        /// <returns>true if the connection is opened</returns>
        private static bool IsServerConnected(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }
                finally
                {
                    // not really necessary
                    connection.Close();
                }
            }
        }

        public static bool IsNetworkAvail()
        {

            try
            {

                string hostName = Dns.GetHostName();
                //IPHostEntry curHost = Dns.GetHostByName(hostName);
                IPHostEntry curHost = Dns.GetHostEntry("172.16.1.3");
                return curHost.AddressList[0].ToString() != IPAddress.Loopback.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error  Servidor De Datos No Disponible: " + ex.Message.ToString(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return false;
            }

        }



        public static void verificar_satus_factura()
        {
            if (Global.invcnbr == "")
            {
                return;
            }
                    
            StringBuilder cad = new StringBuilder();
            cad.Append("SELECT InvcNbr, Shipperid, Status FROM  ADN_FacturasSurtimiento ");
            //cad.AppendLine("FROM  ADN_FacturasSurtimiento ");
            cad.AppendLine("WHERE InvcNbr='" + Global.invcnbr.Trim() + "'");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            DataRow dr;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = cad.ToString();
            cmd.Connection = Global.cn;
            //cmd.Parameters.AddWithValue("@InvcNbr", Global.invcnbr);

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
                        if (!string.IsNullOrEmpty(dr["Status"].ToString()))
                        {
                            status_factura = dr["Status"].ToString().Trim();
                        }
                        else
                        {
                            status_factura = "";

                        }
                    }
                    else
                    {
                        status_factura = "";
                    }
                }
                else
                {
                    status_factura = "";
                }

                dt.Dispose();
                cmd.Dispose();
                da.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar status de factura.." + ex.Message.ToString());
                status_factura = "";
            }

        }

        public static string obtener_status_factura(string factura)
        {
            
            StringBuilder cad = new StringBuilder();
            cad.Append("SELECT Status FROM  ADN_FacturasSurtimiento ");
            //cad.AppendLine("FROM  ADN_FacturasSurtimiento ");
            cad.AppendLine("WHERE InvcNbr='" + factura + "'");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;         
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = cad.ToString();           
            string status = "";           
           
            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                
                status = cmd.ExecuteScalar().ToString();
                      
               
                
                return status;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar status de factura.." + ex.Message.ToString());
                return  "";
            }

        }


        public static bool tomar_turno_factura_picking2(string factura, int idzona, int sigzona)
        {
            //[ADN_tomar_turno_factura_picking2]
            //@InvcNbr VARCHAR(20),
            //@IdZona INT,
            //@SigZona INT,
            //@Usuario varchar(50)
            SqlCommand cmd = new SqlCommand();
            //SqlDataAdapter da = new SqlDataAdapter();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_tomar_turno_factura_picking2";
            cmd.Parameters.AddWithValue("@InvcNbr", factura);
            cmd.Parameters.AddWithValue("@IdZona", idzona);
            cmd.Parameters.AddWithValue("@SigZona", sigzona);
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario);
            try
            {
                if (Global.cn.State == ConnectionState.Closed)
                {
                    Global.cn.Open();
                }
                return Convert.ToBoolean(cmd.ExecuteScalar().ToString());
                //return true;

            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error al Actualizar Turno Factura, Notificar al Administrador " + ex.Message.ToString());
                return false;
            }




        }

        public static bool Actualizar_status_turno_factura(string factura, int idzona, int sigzona, bool activo)
        {
            //ADN_actualizar_status_turno_factura
            //@InvcNbr VARCHAR(20),
            //@IdZona INT,
            //@SigZona INT,
            //@Activo bit
            SqlCommand cmd = new SqlCommand();
            //SqlDataAdapter da = new SqlDataAdapter();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_actualizar_status_turno_factura";
            cmd.Parameters.AddWithValue("@InvcNbr", factura);
            cmd.Parameters.AddWithValue("@IdZona", idzona);
            cmd.Parameters.AddWithValue("@SigZona", sigzona);
            cmd.Parameters.AddWithValue("@Activo", activo);
            try
            {
                if (Global.cn.State == ConnectionState.Closed)
                {
                    Global.cn.Open();
                }
                cmd.ExecuteScalar().ToString();
                return true;

            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error al Actualizar Turno Factura, Notificar al Administrador " + ex.Message.ToString());
                return false;
            }




        }





        public static bool tomar_turno_factura(string factura, int idzona, int sigzona)
        {
            // PROCEDURE ADN_Actualizar_turno_factura
            // - Add the parameters for the stored procedure here
            //@InvcNbr VARCHAR(20),
            //@IdZona INT,
            //@SigZona int
            SqlCommand cmd = new SqlCommand();
            //SqlDataAdapter da = new SqlDataAdapter();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_tomar_turno_factura";
            cmd.Parameters.AddWithValue("@InvcNbr", factura);
            cmd.Parameters.AddWithValue("@IdZona", idzona);
            cmd.Parameters.AddWithValue("@SigZona", sigzona);

            try
            {
                if (Global.cn.State == ConnectionState.Closed)
                {
                    Global.cn.Open();
                }
                return Convert.ToBoolean(cmd.ExecuteScalar().ToString());
                //return true;

            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error al Actualizar Turno Factura, Notificar al Administrador " + ex.Message.ToString());
                return false;
            }

        }

        public static bool actualizar_turno_factura(string factura, int idzona, int sigzona)
        {
            // PROCEDURE ADN_Actualizar_turno_factura
            // - Add the parameters for the stored procedure here
            //@InvcNbr VARCHAR(20),
            //@IdZona INT,
            //@SigZona int
            SqlCommand cmd = new SqlCommand();
            //SqlDataAdapter da = new SqlDataAdapter();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Actualizar_turno_factura";
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
                //MessageBox.Show("Error al Actualizar Turno Factura, Notificar al Administrador " + ex.Message.ToString());
                return false;
            }




        }


        public static bool actualizar_status_zonas(string factura)
        {
            //ADN_actualizar_status_zonas            
            //@InvcNbr varchar(20)
            SqlCommand cmd = new SqlCommand();
            //SqlDataAdapter da = new SqlDataAdapter();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_actualizar_status_zonas";
            cmd.Parameters.AddWithValue("@InvcNbr", factura);

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
                //MessageBox.Show("Error al Actualizar ZONAS Factura, Notificar al Administrador " + ex.Message.ToString());
                return false;
            }


        }


        public static bool actualizar_status_partida(string factura, string status)
        {

            // ADN_Actualizar_status_partidas
            //-- Add the parameters for the stored procedure here
            //@InvcNbr varchar(20),
            //@Id_Zona int,
            //@Usuario varchar(50),
            //@Status varchar(50)	

            SqlCommand cmd = new SqlCommand();
            //SqlDataAdapter da = new SqlDataAdapter();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Actualizar_status_partidas";
            cmd.Parameters.AddWithValue("@InvcNbr", factura);
            cmd.Parameters.AddWithValue("@Id_Zona", Global.idzona);
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario.Trim());
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
                //MessageBox.Show("Error al Actualizar Factura, Notificar al Administrador " + ex.Message.ToString());
                return false;
            }


        }


        public static bool mover_cajas(string factura, int id_zona)
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
                //MessageBox.Show("Error al mover cajas.." + ex.Message.ToString());
                return false;
            }

        }


        public static int facturas_por_enviar(int idzona, int sigzona)
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

        //public static string obtener_factura_turno_picking2()
        //{
        //    //ADN_Obtener_factura_turno_picking2         

        //    //@Usuario VARCHAR(50) 

        //    SqlCommand cmd = new SqlCommand();
        //    SqlDataAdapter da = new SqlDataAdapter();
        //    cmd.Connection = Global.cn;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = "ADN_Obtener_factura_turno_picking2";
        //    cmd.Parameters.AddWithValue("@Usuario",Global.usuario);
        //    //cmd.Parameters.AddWithValue("@SigZona", sigzona);

        //    try
        //    {
        //        if (Global.cn.State == ConnectionState.Closed)
        //        {
        //            Global.cn.Open();
        //        }

        //        return cmd.ExecuteScalar().ToString().Trim();

        //    }
        //    catch
        //    {
        //        return "";
        //    }

        //}




        public static string obtener_factura_turno_picking2(int IdZona)
        {
            //[dbo].[ADN_Obtener_factura_turno_picking2_piva]	
            // @IdZona int,
            //@Usuario VARCHAR(50) 

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Obtener_factura_turno_picking2_piva";
            cmd.Parameters.AddWithValue("@IdZona", IdZona);
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario);
            //cmd.Parameters.AddWithValue("@SigZona", sigzona);

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

        public static string obtener_factura_URGENTE_P2()
        {
            //obtiene las facturas por surtir urgentes en picking2
            //ADN_Obtener_Factura_Prioridad_Urgente_P2
            //@IdZona INT,
            //@Usuario VARCHAR(50)
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet dt = new DataSet();
            DataRow dr;
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Obtener_Factura_Prioridad_Urgente_P2";
            cmd.Parameters.AddWithValue("@IdZona", Global.idzona);
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario);
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
                                return dr["InvcNbr"].ToString().Trim();
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


        public static string obtener_factura_prioridad_picking2()
        {
            //ADN_Obtener_Factura_Prioridad_Picking2
            //@IdZona INT,
            //@Usuario VARCHAR(50)
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet dt = new DataSet();
            DataRow dr;
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Obtener_Factura_Prioridad_Picking2";
            cmd.Parameters.AddWithValue("@IdZona", Global.idzona);
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario);
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
                                return dr["InvcNbr"].ToString().Trim();
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


        public static string obtener_factura_turno(int idzona, int sigzona)
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
     
        public static string obtener_factura_turno_zonas_orden1()
        {
            //ADN_Obtener_factura_turno_picking1_orden1
            //@Usuario VARCHAR(50) 
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Obtener_factura_turno_picking1_orden1";
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario);

            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }

                return cmd.ExecuteScalar().ToString().Trim();

            }
            catch
            {
                MessageBox.Show("Error al obetener factura turno en zona con orden1");
                return "";
            }

        }
        


        public static bool obtener_factura_turno_zonas(out string InvcNbr, out int IdZona)
        {
            //ADN_Obtener_Factura_Turno_Zonas  
            //@Usuario VARCHAR(50)

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet dt = new DataSet();
            DataRow dr;
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Obtener_Factura_Turno_Zonas";
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario);
            da.SelectCommand = cmd;
            try
            {

                da.Fill(dt);
                if (dt != null)
                {
                    if (dt.Tables[0].Rows.Count > 0)
                    {
                        dr = dt.Tables[0].Rows[0];
                        if (!string.IsNullOrEmpty(dr["InvcNbr"].ToString()))
                        {
                            InvcNbr = dr["InvcNbr"].ToString().Trim();
                            IdZona = int.Parse(dr["IdZona"].ToString().Trim());
                            return true;
                        }
                        else
                        {
                            InvcNbr = "";
                            IdZona = 0;
                            return false;
                        }
                    }
                    else
                    {
                        InvcNbr = "";
                        IdZona = 0;
                        return false;
                    }

                }
                else
                {
                    InvcNbr = "";
                    IdZona = 0;
                    return false;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener factura en turno.." + ex.Message.ToString());
                InvcNbr = "";
                IdZona = 0;
                return false;
            }

        }



        public static string obtener_factura_enviar(int idzona, int sigzona)
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

        public static int total_articulos_status(string factura, string status)
        {
            //Obtiene el total de articulos con el status proporcionado
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
                //MessageBox.Show("Error al obtener total de articulos");
                return -1;
            }

        }


        public static int tot_cajas_pend_recibir_zona(int idzona)
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
                //MessageBox.Show("Error al obtener total de cajas por recibir " + ex.Message.ToString());
                return 0;
            }


        }


        public static int tot_cajas_pend_recibir(string factura, int idzona)
        {
            //ADN_tot_cajas_pend_recibir 	
            //@InvcNbr varchar(20),
            //@Id_Zona int
            SqlCommand cmd = new SqlCommand();
            //SqlDataAdapter da = new SqlDataAdapter();
            cmd.Connection = Global.cn;
            //DataSet dt = new DataSet();
            //DataRow dr;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_tot_cajas_pend_recibir";
            cmd.Parameters.AddWithValue("@Id_Zona", idzona);
            cmd.Parameters.AddWithValue("@InvcNbr", factura);
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
                //MessageBox.Show("Error al obtener total de cajas por recibir " + ex.Message.ToString());
                return 0;
            }


        }

        public static int tot_cajas_pend_recibir_picking2(string factura)
        {
            //ADN_tot_cajas_pend_recibir_picking2 	
            //@InvcNbr varchar(20)
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_tot_cajas_pend_recibir_picking2";
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
                //MessageBox.Show("Error al obtener total de cajas por recibir " + ex.Message.ToString());
                return -1;
            }

        }


        public static void tot_cajas_pend_recibir_zonas(string factura, out string idzona, out int total)
        {
            //[ADN_tot_cajas_pend_recibir_zonas] 	
            //@InvcNbr varchar(20),
            //@Usuario VARCHAR(50)
            //Obtiene la zona y el numero total de cajas pendientes de recibir de la factura

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.Connection = Global.cn;
            DataSet dt = new DataSet();
            DataRow dr;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_tot_cajas_pend_recibir_zonas";
            cmd.Parameters.AddWithValue("@InvcNbr", factura);
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario);
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
                            //SELECT @IdZona AS Zona , @Tot AS Total
                            idzona = dr["Zona"].ToString();
                            total = int.Parse(dr["Total"].ToString());
                        }
                        else
                        {
                            idzona = "";
                            total = 0;
                        }
                    }
                    else
                    {
                        idzona = "";
                        total = 0;
                    }
                }
                else
                {
                    idzona = "";
                    total = 0;

                }


            }
            catch
            {
                //MessageBox.Show("Error al obtener total de cajas por recibir " + ex.Message.ToString());
                idzona = "";
                total = 0;
                //return 0;
            }


        }



        public static string obtener_factura_pend(int idzona)
        {
            //obtiene el numero de la factura de las cajas pendientes de recepcion
            // ADN_Obtener_factura_cajas_pend_rec	
            //@Id_Zona INT
            SqlCommand cmd = new SqlCommand();
            //SqlDataAdapter da = new SqlDataAdapter();
            cmd.Connection = Global.cn;
            //DataSet dt = new DataSet();
            //DataRow dr;
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
                fac = cmd.ExecuteScalar().ToString().Trim();
                return fac;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error al obtener factura.." + ex.Message.ToString());
                //idzona = -1;
                //tota
                return "";
            }


        }

        public static bool actualiza_status_zona(string invcnbr, int idzona, string status)
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
                //MessageBox.Show("Error al actualizar status de factura.." + ex.Message.ToString());
                return false;
            }


        }

    
        public static bool actualiza_status_zona_usuario_picking1(string invcnbr, int idzona, string status)
        {
            //ADN_Actualizar_status_zona_usuario_picking1	
            //@InvcNbr VARCHAR(10),
            //@IdZona INT,
            //@Status VARCHAR(20),
            //@Usuario VARCHAR(50)
            SqlCommand cmd = new SqlCommand();            
            cmd.Connection = Global.cn;           
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Actualizar_status_zona_usuario_picking1";
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
                //MessageBox.Show("Error al actualizar status de factura.." + ex.Message.ToString());
                return false;
            }


        }



        public static bool verificar_transito( string factura)
        {
            //Funcion para verificar si existe el Status TRAN o SO en la zona de la factura
            //ADN_verificar_zona_transito	
            //@InvcNbr VARCHAR(10),
            //@IdZona int
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.Connection = Global.cn;
            //DataSet dt = new DataSet();
            //DataRow dr;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_verificar_zona_transito";            
            cmd.Parameters.AddWithValue("@InvcNbr", factura);
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario);             
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
                //MessageBox.Show("Error la verificar zona en transito.." + ex.Message.ToString());  
                return false;
            }


        }

        public static int Tot_articulos_status_zona(string factura, int idzona, string status)
        {
            //Obtiene el total de articulos con el status especificado, en la zona especificada
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
                //MessageBox.Show("Error al obtener total de articulos con status: " + status +" " + ex.Message.ToString()   )  ;
                return -1;
            }

        }


        public static bool obtener_articulo_status(string factura, string status, int id_zona, string id_area)
        {
            //Obtiene los articulos de la factura en la zona y area especificada segun el status
            //ADN_Obtener_Articulo_Status
            //@InvcNbr VARCHAR(20),
            //@Usuario varchar(50),
            //@Status_surt varchar(10),
            //@IdZona INT , 
            //@IdArea VARCHAR(50)

            SqlDataAdapter da = new SqlDataAdapter();
            DataSet dt = new DataSet();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Obtener_Articulo_Status";
            cmd.Parameters.AddWithValue("@InvcNbr", factura.Trim());
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario);
            cmd.Parameters.AddWithValue("@Status_surt", status);
            cmd.Parameters.AddWithValue("@IdZona", id_zona);
            cmd.Parameters.AddWithValue("@IdArea", id_area);

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
                //MessageBox.Show("Error al obtener articulos de factura");  
                return false;
            }



        }


        public static int tot_cajas_factura(string factura)
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

                    //txt_cajas.Text = tot_cajas.ToString();    
                }
                else
                {
                    return 0;
                    //txt_cajas.Text = "0";
                }
            }
            catch (Exception ex)
            {

                return 0;
                //txt_cajas.Text = "0";
            }


        }


        public static int tot_ps_zona_4(string factura)
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
                //MessageBox.Show("Error al obtener total de articulos por surtir en zona 4 y 3");
                return -1;
            }


        }

        public static DataSet obtener_articulo_para_surtir_picking2(string factura)
        {
            //version PIVA
            //ADN_obtener_articulo_para_surtir_picking2	
            //@InvcNbr VARCHAR(15),	
            //@Usuario VARCHAR(50) 

            SqlCommand cmd = new SqlCommand();
            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ADN_obtener_articulo_para_surtir_picking2";
                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@InvcNbr", factura.Trim());
                cmd.Parameters.AddWithValue("@Usuario", Global.usuario);

                da.SelectCommand = cmd;
                da.Fill(dt);
                if (dt == null)
                {
                    //MessageBox.Show("No hay articulos para surtir", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                    return null;
                }
                if (dt.Tables.Count != 0)
                {
                    if (dt.Tables[0].Rows.Count != 0)
                    {

                        return dt;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }

            }
            catch
            {
                return null;
            }
        }


        public static int tot_art_ps_picking2(string factura)
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
                //MessageBox.Show("Error al obtener total de articulos por surtir en picking2..");
                return -1;
            }




        }



        public static int total_articulos_por_surtir_picking2(string factura)
        {
            //ADN_Obtener_total_articulos_por_surtir_picking2	
            //@InvcNbr VARCHAR(20)

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.Connection = Global.cn;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Obtener_total_articulos_por_surtir_picking2";
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
                //MessageBox.Show("Error al obtener total de articulos por surtir en picking2..");
                return -1;
            }




        }


        public static void totales_ps_area_zona(string factura, out int tot_ps_area, out int tot_ps_zona)
        {
            //ADN_total_arts_surtir_area_zona
            //@InvcNbr VARCHAR(20),
            //@Area varchar(50),
            //@Zona varchar(50),
            //@Status varchar(50)
            //if (factura == "")
            //{
            //    return;
            //}
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

                    //Tot_A, Tot_B
                    if (!string.IsNullOrEmpty(dr["tot_area"].ToString()))
                    {
                        tot_ps_area = Convert.ToInt16(dr["tot_area"].ToString());

                    }
                    else
                    {
                        tot_ps_area = 0;
                    }

                    if (!string.IsNullOrEmpty(dr["Tot_A"].ToString()))
                    {
                        if (Convert.ToInt16(dr["Tot_A"].ToString()) > 0)
                        {
                            tot_ps_area = Convert.ToInt16(dr["Tot_A"].ToString());

                        }


                    }

                    if (!string.IsNullOrEmpty(dr["Tot_B"].ToString()))
                    {
                        if (Convert.ToInt16(dr["Tot_B"].ToString()) > 0)
                        {
                            tot_ps_area = Convert.ToInt16(dr["Tot_B"].ToString());

                        }
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
            catch (Exception ex)
            {
                //MessageBox.Show("Error al obtener totales por susrtir");
                tot_ps_area = 0;
                tot_ps_zona = 0;
            }


        }


        public static int total_articulos_por_surtir_area_zona(string factura)
        {
            //ADN_total_arts_por_surtir_zona_area
            //@InvcNbr VARCHAR(20),
            //@IdZona int,
            //@IdArea VARCHAR(50)
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            DataSet dt = new DataSet();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_total_arts_por_surtir_zona_area";
            cmd.Parameters.AddWithValue("@InvcNbr", factura.Trim() );
            cmd.Parameters.AddWithValue("@IdZona",  Global.idzona  );
            cmd.Parameters.AddWithValue("@IdArea",  Global.area  );

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
                MessageBox.Show("Error al obtener total de articulos por surtir.." + ex.Message.ToString());
                return -1;
            }
        }





        public static int total_articulos_ps_zonas(string InvcNbr)
        {
            //ADN_total_arts_por_surtir_zonas	
            //@InvcNbr VARCHAR(20),	
            //@Usuario varchar(50)
            //Obtiene el total de articulos por surtir en las zonas de el usuario
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_total_arts_por_surtir_zonas";
            cmd.Parameters.AddWithValue("@InvcNbr", InvcNbr);
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario);

            try
            {

                if (Global.cn.State == ConnectionState.Closed)
                {
                    Global.cn.Open();
                }

                int tot = int.Parse(cmd.ExecuteScalar().ToString());
                return tot;
            }
            catch
            {
                //MessageBox.Show("Error al obetene")
                return -1;

            }


        }
       
        public static int total_articulos_ps_zonas_usuario(string InvcNbr)
        {
            //ADN_total_arts_por_surtir_zonas_usuario	
            //@InvcNbr VARCHAR(20),	
            //@Usuario varchar(50)
            //Obtiene el total de articulos por surtir en las zonas de el usuario
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_total_arts_por_surtir_zonas_usuario";
            cmd.Parameters.AddWithValue("@InvcNbr", InvcNbr);
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario);
            try
            {

                if (Global.cn.State == ConnectionState.Closed)
                {
                    Global.cn.Open();
                }

                int tot = int.Parse(cmd.ExecuteScalar().ToString());
                return tot;
            }
            catch
            {                
                return -1;

            }


        }





        public static bool obtener_zona_area_por_surtir(string InvcNbr, out int zona, out string area, out int tot_arts)
        {
            //ADN_Obtener_Zona_Total_PS 
            //@InvcNbr VARCHAR(20),
            //@Usuario VARCHAR(50)
            //Obtiene la zona y area en la cual el usuario todavia tiene articulos por surtir
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Obtener_Zona_Total_PS";
            cmd.Parameters.AddWithValue("@InvcNbr", InvcNbr);
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario);
            DataSet dt = new DataSet();
            DataRow dr;
            SqlDataAdapter da = new SqlDataAdapter();
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
                            if (!string.IsNullOrEmpty(dr["Zona"].ToString()))
                            {
                                zona = int.Parse(dr["Zona"].ToString().Trim());
                            }
                            else
                            {
                                zona = -1;
                            }
                            if (!string.IsNullOrEmpty(dr["Area"].ToString()))
                            {
                                area = dr["Area"].ToString().Trim();
                            }
                            else
                            {
                                area = "";
                            }
                            if (!string.IsNullOrEmpty(dr["Tot_Partidas"].ToString()))
                            {
                                tot_arts = int.Parse(dr["Tot_Partidas"].ToString().Trim());
                            }
                            else
                            {
                                tot_arts = 0;
                            }
                            return true;

                        }
                        else
                        {
                            zona = -1;
                            area = "";
                            tot_arts = 0;
                            return false;
                        }
                    }
                    else
                    {
                        zona = -1;
                        area = "";
                        tot_arts = 0;
                        return false;
                    }
                }
                else
                {

                    zona = -1;
                    area = "";
                    tot_arts = 0;
                    return false;
                }
            }
            catch
            {
                zona = -1;
                area = "";
                tot_arts = 0;
                return false;

            }


        }


        public static int total_facturas_turno_zona(int idzona)
        {
            //ADN_total_facturas_turno_zona 
            //--Add the parameters for the stored procedure here
            //@IdZona INT
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_total_facturas_turno_zona";
            cmd.Parameters.AddWithValue("@IdZona", idzona);

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
                //MessageBox.Show("Error al obtener total de articulos por surtir en picking2..");
                return -1;
            }


        }

        public static void actualizar_observaciones_status_historial(string factura, string observaciones, string status_fac)
        {
            //ADN_actualizar_observaciones_status
            //@InvcNbr VARCHAR(20),
            //@Observaciones  varchar(max),
            //@Usuario  varchar(50),
            //@Status varchar(50)          
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_actualizar_observaciones_status";
            cmd.Parameters.AddWithValue("@InvcNbr", factura.Trim());
            cmd.Parameters.AddWithValue("@Observaciones", observaciones);
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario);
            cmd.Parameters.AddWithValue("@Status", status_fac);
            try
            {
                if (Global.cn.State == ConnectionState.Closed)
                {
                    Global.cn.Open();
                }
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error al  actualizar observaciones de status.." + ex.Message.ToString());

            }

        }

        //public static void agregar_status_historial_zona_area(string factura, string observaciones, string status, int idzona,string area)
        //{
        //    //ADN_agregar_status_historial_zona_area
        //    //@InvcNbr varchar(15), 
        //    //@IdZona INT,
        //    //@Area VARCHAR(50),
        //    //@Status varchar(15),
        //    //@Observaciones VARCHAR(MAX), 
        //    //@Usuario varchar(50)        
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Connection = Global.cn;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = "ADN_agregar_status_historial_zona_area";
        //    cmd.Parameters.AddWithValue("@InvcNbr", factura.Trim());
        //    cmd.Parameters.AddWithValue("@Observaciones", observaciones);
        //    cmd.Parameters.AddWithValue("@Usuario", Global.usuario);
        //    cmd.Parameters.AddWithValue("@Status", status);
        //    cmd.Parameters.AddWithValue("@IdZona", idzona);
        //    cmd.Parameters.AddWithValue("@Area", area);          
        //    try
        //    {
        //        if (Global.cn.State == ConnectionState.Closed)
        //        {
        //            Global.cn.Open();
        //        }
        //        cmd.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        //MessageBox.Show("Error al  actualizar observaciones de status.." + ex.Message.ToString());

        //    }

        //}


        public static void actualiza_status_historial(string factura)
        {
            //[dbo].[ADN_finalizar_Status_Historial]
            //@InvcNbr varchar(15), 
            //@Status varchar(15),
            //--@Observaciones VARCHAR(MAX), 
            //@Usuario varchar(50)
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_finalizar_Status_Historial";
            cmd.Parameters.AddWithValue("@InvcNbr", factura.Trim());
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario);
            //cmd.Parameters.AddWithValue("@Status", status);         
            try
            {
                if (Global.cn.State == ConnectionState.Closed)
                {
                    Global.cn.Open();
                }
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error al  actualizar observaciones de status.." + ex.Message.ToString());

            }

        }

        public static void surtimiento_status_historial_area_zona(string factura, string observaciones, string status, string idzona, string area, int op)
        {
            // ADN_surtimiento_historial_status_area_zona
            //@InvcNbr VARCHAR(20), 
            //@IdZona VARCHAR(50), 
            //@Area VARCHAR(50), 
            //@Status VARCHAR(50), 
            //@Usuario VARCHAr(50),
            //@OP int        
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_surtimiento_historial_status_area_zona";
            cmd.Parameters.AddWithValue("@InvcNbr", factura.Trim());
            cmd.Parameters.AddWithValue("@IdZona", idzona);
            cmd.Parameters.AddWithValue("@Area", area);
            cmd.Parameters.AddWithValue("@Status", status);
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario);
            cmd.Parameters.AddWithValue("@OP", op);
            try
            {
                if (Global.cn.State == ConnectionState.Closed)
                {
                    Global.cn.Open();
                }
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error al  actualizar observaciones de status.." + ex.Message.ToString());

            }

        }



        public static void finalizar_status_historial_zona(string factura, string idzona)
        {
            //ADN_finalizar_status_zona_historial 
            //@InvcNbr VARCHAR(20) , 
            //@IdZona VARCHAR(50)
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_finalizar_status_zona_historial";
            cmd.Parameters.AddWithValue("@InvcNbr", factura.Trim());
            cmd.Parameters.AddWithValue("@IdZona", idzona);

            try
            {
                if (Global.cn.State == ConnectionState.Closed)
                {
                    Global.cn.Open();
                }
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error al  actualizar observaciones de status.." + ex.Message.ToString());

            }

        }

        public static int tot_status_zona(int idzona, string status)
        {
            //Obtiene el total de facturas con el status especificado en la zona especificada
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
                MessageBox.Show("Error al obtener total de facturas en  la ZONA" + ex.Message.ToString());
                return -1;
            }


        }
        /// <summary>
        /// Obtiene el total de partidas por status en la zona
        /// </summary>
        /// <param name="pInvcNbr"></param>
        /// <param name="pIdZona"></param>
        /// <param name="pStatus"></param>
        /// <returns></returns>
        public static int TotPartidasStatusZonaFactura(string pInvcNbr,int pIdZona, string pStatus)
        {  
            //ADN_TotalArticulosStatusZonaFactura
            //@InvcNbr VARCHAR(20),
            //@IdZona INT,
            //@Status VARCHAR(50) 
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_TotalArticulosStatusZonaFactura";
            cmd.Parameters.AddWithValue("@InvcNbr", pInvcNbr);
            cmd.Parameters.AddWithValue("@IdZona", pIdZona);
            cmd.Parameters.AddWithValue("@Status ", pStatus);
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
                MessageBox.Show("Error al obtener total de facturas en  la ZONA" + ex.Message.ToString());
                return -1;
            }


        }



        public static int tot_facturas_activas_zonas()
        {
            // ADN_Total_Facturas_Activas_Zonas 
            //@Usuario varchar(50)
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Total_Facturas_Activas_Zonas";
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario);
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
                MessageBox.Show("Error al obtener total de facturas" + ex.Message.ToString());
                return -1;
            }


        }





        public static string factura_pend_zona(int idzona)
        {
            //obtiene la factura activa de la zona, que este en status "SO", o TRAN
            // ADN_factura_pend_zona
            //@IdZona INT,          
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_factura_pend_zona";
            cmd.Parameters.AddWithValue("@IdZona", idzona);

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
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener factura pendiente del usuario " + ex.Message.ToString());
                return "";
            }



        }

        public static string factura_pend_zonas()
        {
            //[dbo].[ADN_factura_pend_zonas]	
            //@Usuario VARCHAR(50)            
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_factura_pend_zonas";
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
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener factura pendiente del usuario " + ex.Message.ToString());
                return "";
            }



        }


       

        public static string factura_pend_zonas_usuario()
        {
            //ADN_factura_pend_zonas_usuario
            //@Usuario VARCHAR(50)
            //Procedimiento para obetenr la factura activa de el usuario
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_factura_pend_zonas_usuario";
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
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener factura pendiente del usuario " + ex.Message.ToString());
                return "";
            }



        }
   
        public static bool actualizar_status_factura_usuario(string factura)
        {
            //ADN_Actualizar_Status_Zona_Usuario
            //@InvcNbr VARCHAR(20),
            //@Usuario VARCHAR(50)
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Actualizar_Status_Zona_Usuario";
            cmd.Parameters.AddWithValue("@InvcNbr", factura);
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario);
            try
            {
                if (Global.cn.State == ConnectionState.Closed)
                {
                    Global.cn.Open();
                }
                cmd.ExecuteScalar().ToString().Trim();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar status de la factura" + ex.Message.ToString());
                return  false;
            }

        }

        public static string factura_por_surtir_zonas()
        {
            //ADN_obtener_factura_surtimiento_zonas
            //@Usuario VARCHAR(50)
            //obtiene la factura para surtir en las zonas del usuario
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            DataSet dt = new DataSet();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_obtener_factura_por_surtir_zonas";
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario);
            da.SelectCommand = cmd;
            DataRow dr;

            //@InvcNbr AS InvcNbr,@Shipperid AS Shipperid,@Tot AS Partidas,@status AS Status,
            //@Prioridad AS Prioridad,@env_junto AS env_junto,@tot_env_junto AS Tot_env_junto
            
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
                            if (!string.IsNullOrEmpty(dr["InvcNbr"].ToString().Trim()))
                            {
                                //dt.Dispose();
                                return dr["InvcNbr"].ToString().Trim();
                            }
                            else
                            {
                                dt.Dispose();
                                return "";
                            }

                        }
                        else
                        {
                            dt.Dispose();
                            return "";
                        }
                    }
                    else
                    {
                        dt.Dispose();
                        return "";
                    }
                }
                else
                {
                    dt.Dispose();
                    return "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener factura por surtir.." + ex.Message.ToString());
                return "";
            }
        }


        public static string factura_por_surtir_zonas_orden1()
        {
            //ADN_obtener_factura_por_surtir_zonas_orden1
            //@Usuario VARCHAR(50)
            //obtiene la factura para surtir en las zonas del usuario
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            DataSet dt = new DataSet();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_obtener_factura_por_surtir_zonas_orden1";
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario);
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
                            if (!string.IsNullOrEmpty(dr["InvcNbr"].ToString().Trim()))
                            {
                                //dt.Dispose();
                                return dr["InvcNbr"].ToString().Trim();
                            }
                            else
                            {
                                dt.Dispose();
                                return "";
                            }

                        }
                        else
                        {
                            dt.Dispose();
                            return "";
                        }
                    }
                    else
                    {
                        dt.Dispose();
                        return "";
                    }
                }
                else
                {
                    dt.Dispose();
                    return "";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener factura por surtir.." + ex.Message.ToString());
                return "";
            }



        }




        public static int tot_facturas_turno_zonas()
        {
            // ADN_Tot_Facturas_Turno_Zonas 
            //@Usuario VARCHAR(50)
            //obtiene el total de facturas en turno hacia las zonas de surtimiento de el usuario
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Tot_Facturas_Turno_Zonas";
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario);
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
                MessageBox.Show("Error al obtener total de facturas en turno" + ex.Message.ToString());
                return -1;
            }


        }

        public static bool agregar_turno_factura(string factura, int idzona, int sigzona)
        {
            // ADN_Agregar_turno_factura         
            //@InvcNbr varchar(20), 
            //@IdZona int, 
            //@SigZona int
            SqlCommand cmd = new SqlCommand();
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

        public static decimal porc_surtimiento_zona(int idzona)
        {
            //ADN_obtener_porc_surtimiento_zona
            //@IdZona INT
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_obtener_porc_surtimiento_zona";
            cmd.Parameters.AddWithValue("@IdZona", idzona);
            try
            {
                if (Global.cn.State == ConnectionState.Closed)
                {
                    Global.cn.Open();
                }

                return Convert.ToDecimal(cmd.ExecuteScalar().ToString());

            }
            catch (Exception ex)
            {
                return -1;

            }


        }


        public static decimal porc_surtimiento_zona4()
        {
            //ADN_obtener_porc_surtimiento_zona4
            //OBTIENE EL PORCENTAJE DE SURTIMIENTO DE LAS FACTURAS ACTIVAS EN LA ZONA 4

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_obtener_porc_surtimiento_zona4";

            try
            {
                if (Global.cn.State == ConnectionState.Closed)
                {
                    Global.cn.Open();
                }

                return Convert.ToDecimal(cmd.ExecuteScalar().ToString());

            }
            catch (Exception ex)
            {
                return -1;

            }


        }


        public static void obtener_datos_zona_surtimiento(int idzona, out int minutos, out decimal porcsurt)
        {
            // ADN_obtener_datos_zona_surtimiento]	
            //@IdZona INT
            SqlCommand cmd = new SqlCommand();
            DataRow dr;
            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_obtener_datos_zona_surtimiento";
            cmd.Parameters.AddWithValue("@IdZona", idzona);
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
                            if (!string.IsNullOrEmpty(dr["minutos"].ToString()))
                            {
                                minutos = Convert.ToInt16(dr["minutos"].ToString());
                            }
                            else
                            {
                                minutos = 0;
                            }

                            if (!string.IsNullOrEmpty(dr["porcsurt"].ToString()))
                            {
                                porcsurt = Convert.ToDecimal(dr["porcsurt"].ToString());
                            }
                            else
                            {
                                porcsurt = 0;
                            }

                        }
                        else
                        {
                            minutos = 0;
                            porcsurt = 0;
                        }
                    }
                    else
                    {
                        minutos = 0;
                        porcsurt = 0;
                    }
                }
                else
                {
                    minutos = 0;
                    porcsurt = 0;
                }


            }
            catch (Exception ex)
            {
                minutos = 0;
                porcsurt = 0;
            }


        }

        public static bool recibir_cajas_zona(string factura, int idzona)
        {
            //ADN_recibir_cajas_zona  
            //@InvcNbr VARCHAR(20),
            //@IdZona int
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_recibir_cajas_zona";
            cmd.Parameters.AddWithValue("@InvcNbr", factura);
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
                MessageBox.Show("Error al recibir cajas " + ex.Message.ToString());
                return false;
            }


        }

        public static int tot_facturas_turno_zona(int idzona, int sigzona)
        {
            //ADN_tot_facturas_turno_zona 
            //@IdZona int, 
            //@SigZona int

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_tot_facturas_turno_zona";
            //cmd.Parameters.AddWithValue("@InvcNbr", factura);
            cmd.Parameters.AddWithValue("@IdZona", idzona);
            cmd.Parameters.AddWithValue("@SigZona", sigzona);
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
                MessageBox.Show("Error al obtener total de facturas en turno" + ex.Message.ToString());
                return 0;
            }


        }

        public static int tot_facturas_activas_zona(int idzona)
        {
            // ADN_tot_facturas_activas_zona
            //@IdZona	int 
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_tot_facturas_activas_zona";
            cmd.Parameters.AddWithValue("@IdZona", idzona);
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
                MessageBox.Show("Error al obtener total de facturas activas en zona" + ex.Message.ToString());
                return 0;
            }

        }

        public static void avanzar_factura_zona1()
        {
            //envia todas las facturas a la ZONA1 que no tengan partidas por surtir en la zona2
            //ADN_obtener_factura_zona1
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_obtener_factura_zona1";
            cmd.Parameters.AddWithValue("@IdZona", idzona);
            try
            {
                if (Global.cn.State == ConnectionState.Closed)
                {
                    Global.cn.Open();
                }
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error al obtener total de facturas activas en zona" + ex.Message.ToString());

            }

        }



        public static bool cancelar_surt_articulo(string ID_Surt_Art)
        {
            //ADN_cancelar_surt_articulo	
            //@ID_Surt_Art NUMERIC(9)
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_cancelar_surt_articulo";
            cmd.Parameters.AddWithValue("@ID_Surt_Art", ID_Surt_Art);
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
                return false;

            }

        }

        public static void obtener_datos_supervisor(string PasswordAdmin, out string numnomina)
        {
            //ADN_obtener_datos_supervisor 
            //@PasswordAdmin varchar(100)
            SqlCommand cmd = new SqlCommand();
            DataSet dt = new DataSet();
            DataRow dr;
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_obtener_datos_supervisor";
            cmd.Parameters.AddWithValue("@PasswordAdmin", PasswordAdmin);
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
                            if (!string.IsNullOrEmpty(dr["NumNomina"].ToString()))
                            {
                                numnomina = dr["NumNomina"].ToString().Trim();
                            }
                            else
                            {
                                numnomina = "";
                            }
                        }
                        else
                        {
                            numnomina = "";
                        }

                    }
                    else
                    {
                        numnomina = "";
                    }
                }
                else
                {
                    numnomina = "";

                }

                //numnomina="";
            }
            catch (Exception ex)
            {
                //return false;
                numnomina = "";

            }

        }


        public static bool Enviar_Validacion(string factura)
        {
            //ADN_terminar_surtimiento
            //@InvcNbr VARCHAR(20),
            //@Usuario VARCHAR(50)
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_enviar_validacion";
            cmd.Parameters.AddWithValue("@InvcNbr", factura);
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




        public static string obtener_tarima()
        {
            //ADN_Obtener_tarima_surtimiento
            //@InvcNbr VARCHAR(20)         
            //@Usuario varchar(20)
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Obtener_tarima_surtimiento";
            cmd.Parameters.AddWithValue("@InvcNbr", Global.invcnbr);
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario);
            int tarima = 0;
            try
            {
                if (Global.cn.State == ConnectionState.Closed)
                {
                    Global.cn.Open();
                }
                tarima = Convert.ToInt16(cmd.ExecuteScalar().ToString());

                if (tarima == 0)
                {
                    return "";
                }
                else
                {
                    return tarima.ToString();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener tarima para surtir" + ex.Message.ToString());
                return "";
            }


        }


        public static int tot_cajas_tipo(string tipo)
        {
            //[dbo].[ADN_tot_cajas_tipo]

            //@InvcNbr VARCHAR(20),
            //@Tipo VARCHAR(20)

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_tot_cajas_tipo";
            cmd.Parameters.AddWithValue("@InvcNbr", Global.invcnbr);
            cmd.Parameters.AddWithValue("@Tipo", tipo);

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
                MessageBox.Show("Error al obtener total de cajas para surtir" + ex.Message.ToString());
                return 0;
            }


        }



        public static bool cancelar_turno_factura(string factura)
        {
            //* Actualiza todos los turnos activos que tenga la factura a false
            //se usa sobre todo cuando la factura es cancelada

            // ADN_Cancelar_turno_factura	
            //@InvcNbr varchar(20)
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Cancelar_turno_factura";
            cmd.Parameters.AddWithValue("@InvcNbr", factura);

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
                MessageBox.Show("Error al actualizar turno de factura" + ex.Message.ToString());
                return false;
            }


        }


        //public static int Tot_articulos_status_zona(string factura, int idzona, string status)
        //{
        //    //ADN_obtener_tot_articulos_status_zona	
        //    //@InvcNbr VARCHAR(10),
        //    //@IdZona  INT,
        //    //@Status varchar(10)
        //    SqlCommand cmd = new SqlCommand();
        //    SqlDataAdapter da = new SqlDataAdapter();
        //    cmd.Connection = Global.cn;
        //    //DataSet dt = new DataSet();
        //    //DataRow dr;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = "ADN_obtener_tot_articulos_status_zona";
        //    cmd.Parameters.AddWithValue("@IdZona", idzona);
        //    cmd.Parameters.AddWithValue("@InvcNbr", factura);
        //    cmd.Parameters.AddWithValue("@Status", status);
        //    //da.SelectCommand = cmd;
        //    try
        //    {
        //        if (Global.cn.State == ConnectionState.Closed)
        //        {
        //            Global.cn.Open();
        //        }

        //        return Convert.ToInt16(cmd.ExecuteScalar().ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al obtener total de articulos con status: " + status + " " + ex.Message.ToString());
        //        return -1;
        //    }

        //}


        public static DataSet lista_zonas_usuario()
        {
            //ADN_Lista_Zonas_Usuario
            //@Usuario VARCHAR(50)

            DataSet dt = new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Lista_Zonas_Usuario";
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario);
            ad.SelectCommand = cmd;
            try
            {
                ad.Fill(dt);

                return dt;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener zonas usuario.." + ex.Message.ToString());
                return null;
            }


        }


        public static bool Agregar_zonas_usuario(string idzona, string area)
        {
            //ADN_Picking_Registrar_Acceso_Zona
            //@Usuario VARCHAR(50),	
            //@IdZona int, 
            //@Area VARCHAR(50)
            DataSet dt = new DataSet();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Picking_Registrar_Acceso_Zona";
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario);
            cmd.Parameters.AddWithValue("@IdZona", idzona);
            cmd.Parameters.AddWithValue("@Area", area);

            try
            {
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
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al agregar zonas usuario.." + ex.Message.ToString());
                return false;
            }


        }


        public static bool Valida_Zona_Area(string zona, string area, out string idzona)
        {
            //ADN_Obtener_Datos_Zona_Area	
            // @IdZona int, 
            // @Area varchar(50), 
            //@IdPicking int
            DataSet dt = new DataSet();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Obtener_Datos_Zona_Area";
            cmd.Parameters.AddWithValue("@IdZona", zona);
            cmd.Parameters.AddWithValue("@Area", area);
            cmd.Parameters.AddWithValue("@IdPicking", Global.picking);
            da.SelectCommand = cmd;
            DataRow dr;
            try
            {
                da.Fill(dt);
                if (dt.Tables.Count > 0)
                {
                    if (dt.Tables[0].Rows.Count > 0)
                    {
                        dr = dt.Tables[0].Rows[0];
                        if (!string.IsNullOrEmpty(dr["IdZona"].ToString()))
                        {
                            idzona = dr["IdZona"].ToString().Trim();
                            return true;
                        }
                        else
                        {
                            idzona = "";
                            return false;
                        }


                    }
                    else
                    {
                        idzona = "";
                        return false;
                    }
                }
                else
                {
                    idzona = "";
                    return false;
                }


            }
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al obtener datos de la zona: " + ex.Message.ToString());
                idzona = "";
                return false;
            }


        }

        //
        // Id)
        public static bool Eliminar_Zona_Area(string id)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM ADN_Picking_Usuario_Zona WHERE (Id =" + id + ")";


            try
            {
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
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al eliminar datos de la zona: " + ex.Message.ToString());

                return false;
            }


        }

        public static bool Eliminar_Zonas_Usuario(string usuario)
        {
            //DELETE FROM ADN_Picking_Usuario_Zona
            //WHERE (Usuario = @Usuario)
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Eliminar_Zonas_Usuario";
            cmd.Parameters.Add("@Usuario", usuario);
            //cmd.CommandText = "DELETE FROM ADN_Picking_Usuario_Zona WHERE (Usuario ='" + usuario + "')";


            try
            {
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
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al eliminar datos: " + ex.Message.ToString());

                return false;
            }


        }


        public static bool validar_Orden_Surtimiento(string idpicking)
        {
            // ADN_Validar_Orden_Surtimiento	
            //@IdPicking INT
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet dt = new DataSet();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Validar_Orden_Surtimiento";
            cmd.Parameters.AddWithValue("@IdPicking", idpicking);
            da.SelectCommand = cmd;
            try
            {
                da.Fill(dt);
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
            catch (Exception ex)
            {
                if (cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
                MessageBox.Show("Error al obtener orden de surtimiento" + ex.Message.ToString());

                return false;
            }


        }

        public static bool Obtener_siguiete_zona_surtimiento(string invcnbr, string usuario, out string idzona, out string idpicking)
        {
            //ADN_Obtener_siguiente_zona_surtimiento
            //@InvcNbr VARCHAR(20),
            //@Usuario VARCHAR(50)
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet dt = new DataSet();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Obtener_siguiente_zona_surtimiento";
            cmd.Parameters.AddWithValue("@InvcNbr", invcnbr);
            cmd.Parameters.AddWithValue("@Usuario", usuario);
            da.SelectCommand = cmd;
            DataRow dr;
            //IdZona,
            //Picking
            try
            {
                da.Fill(dt);
                if (dt.Tables.Count > 0)
                {
                    if (dt.Tables[0].Rows.Count > 0)
                    {
                        dr = dt.Tables[0].Rows[0];
                        idzona = dr["IdZona"].ToString().Trim();
                        idpicking = dr["Picking"].ToString().Trim();
                        return true;
                    }
                    else
                    {
                        idzona = "";
                        idpicking = "";
                        return false;
                    }
                }
                else
                {
                    idzona = "";
                    idpicking = "";
                    return false;

                }
            }
            catch
            {
                idzona = "";
                idpicking = "";
                return false;
            }

        }

        public static int Obtener_total_arts_pend_surtir_factura(string invcnbr)
        {
            //ADN_Obtener_total_arts_pend_surtir
            //@InvcNbr VARCHAR(20)

            //Obtiene el total de articulos pendientes de surtir de la factura especificada
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Obtener_total_arts_pend_surtir";
            cmd.Parameters.AddWithValue("@InvcNbr", invcnbr);

            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                int res = int.Parse(cmd.ExecuteScalar().ToString());

                return res;

            }
            catch
            {
                return -1;
            }
        }

        public static int Obtener_IdZona_Picking2()
        {
            //Obtiene El valor del id de la zona de PICKING2
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT TOP(1) Valor FROM  ADN_Configuraciones WHERE Configuracion='PICKING2'";

            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                int res = int.Parse(cmd.ExecuteScalar().ToString().Trim());

                return res;

            }
            catch
            {
                return -1;
            }
        }

    
    /// <summary>
    /// Obtiene el articulo para surtir en la localizacion
    /// </summary>
    /// <param name="factura"></param>
    /// <param name="localizacion"></param>
    /// <returns></returns>
        public static DataSet Obtener_articulo_para_surtir_localizacion(string factura, string localizacion)
        {
            //obtiene el articulo para surtir en la localizacion especificaada
            //ADN_obtener_articulo_por_surtir_localizacion
            //@InvcNbr VARCHAR(15),	--Factura en surtimiento
            //@Localizacion VARCHAR(50),
            //@Usuario VARCHAR(50) 
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_obtener_articulo_por_surtir_localizacion";
            cmd.Parameters.AddWithValue("@InvcNbr", factura);            
            cmd.Parameters.AddWithValue("@Localizacion", localizacion);
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario);
            da.SelectCommand = cmd;
            DataSet dt = new DataSet();
            try
            {
                da.Fill(dt);
                return dt;

            }
            catch
            {
                return null; ;
            }
        }
        /// <summary>
        /// Obtiene la partida para surtir en la localizacion, de la clave especificada, se usa para cuando son multiples partidas
        /// </summary>
        /// <param name="pFactura"></param>
        /// <param name="plocalizacion"></param>
        /// <param name="pInvtId"></param>
        /// <returns></returns>
        public static DataSet Obtener_Partida_Surtir_Localizacion(string pFactura, string plocalizacion, string pInvtId)
        {
            //ADN_ObtenerPartidaSurtirClaveLocalizacion	
            //@InvcNbr VARCHAR(15),	--Factura en surtimiento
            //@Localizacion VARCHAR(50), --Localizacion de surtimiento
            //@InvtId VARCHAR(50), --Clave del producto
            //@Usuario VARCHAR(50)  
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_ObtenerPartidaSurtirClaveLocalizacion";
            cmd.Parameters.AddWithValue("@InvcNbr", pFactura);
            cmd.Parameters.AddWithValue("@Localizacion", plocalizacion);
            cmd.Parameters.AddWithValue("@InvtId", pInvtId);
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario);
            da.SelectCommand = cmd;
            DataSet dt = new DataSet();
            try
            {
                da.Fill(dt);
                return dt;
            }
            catch
            {
                return null; ;
            }
        }

    /// <summary>
    /// Obtiene el total de partidas pendientes de surtir de  la clave en la localizacion
    /// </summary>
    /// <param name="pFactura"></param>
    /// <param name="plocalizacion"></param>
    /// <param name="pInvtId"></param>
    /// <returns></returns>
        public static int Obtener_TotPartidasPorSurtirClaveLocalizacion(string pFactura, string plocalizacion, string pInvtId)
        {
            //ADN_ObtenerTotPartidasSurtirClaveLocalizacion
            //@InvcNbr VARCHAR(15),	--Factura en surtimiento
            //@Localizacion VARCHAR(50), --Localizacion de surtimiento
            //@InvtId VARCHAR(50) --Clave del producto 
            SqlCommand cmd = new SqlCommand();
            //SqlDataAdapter da = new SqlDataAdapter();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_ObtenerTotPartidasSurtirClaveLocalizacion";
            cmd.Parameters.AddWithValue("@InvcNbr", pFactura);
            cmd.Parameters.AddWithValue("@Localizacion", plocalizacion);
            cmd.Parameters.AddWithValue("@InvtId", pInvtId);          
            //da.SelectCommand = cmd;
            //DataSet dt = new DataSet();
            try
            {
                int tot = 0;
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                tot = int.Parse(cmd.ExecuteScalar().ToString());
                return tot;
                //da.Fill(dt);
                //return dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al obtener total de partidas por surtir..." + ex.Message.ToString()  );
                return -1; 
            }
        }


        public static DataSet Obtener_articulo_para_surtir_zonas_picking1(string factura)
        {
            //ADN_obtener_articulo_zonas_picking1
            //@InvcNbr VARCHAR(15),	
            //@Usuario VARCHAR(50)
            //Obtiene el articulo para surtir en Picking1
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_obtener_articulo_zonas_picking1";
            cmd.Parameters.AddWithValue("@InvcNbr", factura);
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario);
            cmd.Parameters.AddWithValue("@Orden", Global.orden_zona);            
            da.SelectCommand = cmd;
            DataSet dt = new DataSet();
            try
            {
                da.Fill(dt);
                return dt;

            }
            catch
            {
                return null; ;
            }
        }

        /// <summary>
        /// Obtiene el articulo para surtir en la zona especificada, se usa para cuando el usuario ya no tiene articulos por surtir en su lado
        /// </summary>
        /// <param name="pInvcNbr"></param>
        /// <param name="pIdZona"></param>
        /// <returns></returns>      
        public static DataSet ObtenerArticuloParaSurtirZonaPicking1(string pInvcNbr, string pIdZona)
        {
            //ADN_ObtenerArticuloParaSurtirZona	
            //@InvcNbr VARCHAR(15),	--Factura en surtimiento
            //@Usuario VARCHAR(50), --usuario actual
            //@IdZona int            
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_ObtenerArticuloParaSurtirZona";
            cmd.Parameters.AddWithValue("@InvcNbr", factura);
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario);
            cmd.Parameters.AddWithValue("@IdZona", pIdZona );
            da.SelectCommand = cmd;
            DataSet dt = new DataSet();
            try
            {
                da.Fill(dt);
                return dt;

            }
            catch
            {
                return null; ;
            }
        }

        public static bool finalizar_status_zona_area(string factura, int Zona, string Area, string status)
        {
            //ADN_finalizar_status_zona_area
            //@InvcNbr VARCHAR(10),
            //@IdZona INT,
            //@Area VARCHAR(50),
            //@Status varchar(20),
            //@Usuario VARCHAR(50)	

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_finalizar_status_zona_area";
            cmd.Parameters.AddWithValue("@InvcNbr", factura);
            cmd.Parameters.AddWithValue("@IdZona", zona);
            cmd.Parameters.AddWithValue("@Area", Area);
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario);
            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                cmd.ExecuteNonQuery();
                return true;

            }
            catch
            {
                return false;
            }
        }

        public static bool finalizar_status_zona_area_usuario(string factura, int Zona, string Area, string status)
        {
            //ADN_finalizar_status_zona_area
            //@InvcNbr VARCHAR(10),
            //@IdZona INT,
            //@Area VARCHAR(50),
            //@Status varchar(20),
            //@Usuario VARCHAR(50)	

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_finalizar_status_zona_area";
            cmd.Parameters.AddWithValue("@InvcNbr", factura);
            cmd.Parameters.AddWithValue("@IdZona", zona);
            cmd.Parameters.AddWithValue("@Area", Area);
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario);
            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                cmd.ExecuteNonQuery();
                return true;

            }
            catch
            {
                return false;
            }
        }

    	
        public static bool finalizar_status_zona_area_picking1(string factura, int idzona1, string Area, string status)
        {
            //ADN_finalizar_status_zona_area_picking1
            //@InvcNbr VARCHAR(20),
            //@IdZona INT,
            //@Area VARCHAR(50),
            //@Status varchar(20),	
            //@Usuario VARCHAR(50)

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_finalizar_status_zona_area_picking1";
            cmd.Parameters.AddWithValue("@InvcNbr", factura);
            cmd.Parameters.AddWithValue("@IdZona", idzona1);
            cmd.Parameters.AddWithValue("@Area", Area);
            cmd.Parameters.AddWithValue("@Status",status);
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario);
            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                cmd.ExecuteNonQuery();
                return true;

            }
            catch
            {
                MessageBox.Show("Error al actualizar Status");
                return false;
            }
        }


        public static int obtener_total_articulos_por_surtir_P1(string factura)
        {
            //ADN_Obtener_total_articulos_por_sutir_P1 
            //@InvcNbr VARCHAR(20)
            //Obtiene el total de partidas por surtir de la factura para picking1
            SqlCommand cmd = new SqlCommand();           
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Obtener_total_articulos_por_sutir_P1";
            cmd.Parameters.AddWithValue("@InvcNbr", factura);
            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                int tot = int.Parse(cmd.ExecuteScalar().ToString());

                return tot;


            }
            catch
            {
                return -1;
            }
        }


        public static int obtener_total_articulos_por_surtir_P2(string factura)
        {
            //ADN_Obtener_total_articulos_por_sutir_P2 
            //@InvcNbr VARCHAR(20)
            //Obtiene el total de partidas por surtir de la factura para picking1
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Obtener_total_articulos_por_sutir_P2";
            cmd.Parameters.AddWithValue("@InvcNbr", factura);

            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                int tot = int.Parse(cmd.ExecuteScalar().ToString());

                return tot;


            }
            catch
            {
                return -1;
            }
        }

        public static int obtener_siguiente_zona_por_surtir_P1(string factura)
        {
            //ADN_obtener_sig_Zona_surtimiento_P1	
            //@InvcNbr VARCHAR(10)
            //Obtiene la siguiente zona con articulos por surtir en PICKING1
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_obtener_sig_Zona_surtimiento_P1";
            cmd.Parameters.AddWithValue("@InvcNbr", factura);
            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                int idzona = int.Parse(cmd.ExecuteScalar().ToString());
                return idzona;
            }
            catch
            {
                return -1;
            }
        }



        public static string Obtener_factura_pend_usuario_Pick2()
        {
            //ADN_Obtener_factura_pend_usuario_Pick2
            //@Usuario VARCHAR(50)
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Obtener_factura_pend_usuario_Pick2";
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario);
            da.SelectCommand = cmd;
            DataSet dt = new DataSet();
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
                            if (!string.IsNullOrEmpty(dr["InvcNbr"].ToString()))
                            {
                                return dr["InvcNbr"].ToString().Trim();
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

        public static bool mover_cajas_validacion(string factura)
        {
            //ADN_Surtimiento_mover_cajas_validacion
            //@InvcNbr VARCHAR(20)
            //@Usuario VARCHAR(50)
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Surtimiento_mover_cajas_validacion";
            cmd.Parameters.AddWithValue("@InvcNbr", factura);
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario);
            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool actualizar_turno_activo_factura(string factura)
        {
            //ADN_Actualizar_Turno_Activo_Factura
            //@InvcNbr VARCHAR(20)          
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Actualizar_Turno_Activo_Factura";
            cmd.Parameters.AddWithValue("@InvcNbr", factura);
            //cmd.Parameters.AddWithValue("@Usuario", Global.usuario);
            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public static int obtener_idzona_validacion()
        {
            //ADN_Obtener_IdZona_Validacion        
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Obtener_IdZona_Validacion";

            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                int id = int.Parse(cmd.ExecuteScalar().ToString());
                return id;
            }
            catch
            {
                return -1;
            }

        }



        public static int obtener_idzona_P2()
        {
            //ADN_Obtener_IdZona_Validacion        
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Obtener_id_zona_P2";

            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                int id = int.Parse(cmd.ExecuteScalar().ToString());
                return id;
            }
            catch
            {
                return -1;
            }

        }

        
        public static DataSet datos_caja_factura(string factura, string caja)
        {
            //ADN_Obtener_Datos_caja_factura
            //@InvcNbr VARCHAR(20),
            //@Caja	INT
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Obtener_Datos_caja_factura";
            cmd.Parameters.AddWithValue("@InvcNbr", factura );
            cmd.Parameters.AddWithValue("@Caja", caja);
            SqlDataAdapter da = new SqlDataAdapter();
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






        public static DataSet lista_zonas_usuario1()
        {
            //ADN_Lista_Zonas_Usuario1
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Lista_Zonas_Usuario1";
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario);
            SqlDataAdapter da = new SqlDataAdapter();
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

        public static DataSet lista_zonas_picking()
        {
            //ADN_Lista_Zonas_Picking
            //@IdPicking INT, 
            //@Area VARCHAR(1)
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Lista_Zonas_Picking";
            cmd.Parameters.AddWithValue("@IdPicking", Global.picking);           
            SqlDataAdapter da = new SqlDataAdapter();
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


        public static bool zonas_usuario_OP(int idzona1, string area1, bool status)
        {
            //ADN_Picking_zonas_usuario_OP 
            //@Usuario VARCHAR(50), 
            //@IdZona int, 
            //@Area VARCHAR(50),
            //@Status bit
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Picking_zonas_usuario_OP";
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario);
            cmd.Parameters.AddWithValue("@IdZona", idzona1);
            cmd.Parameters.AddWithValue("@Area", area1);
            cmd.Parameters.AddWithValue("@Status", status);

            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public static DataSet lista_zonas_picking2()
        {
            //ADN_lista_zonas_picking2
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_lista_zonas_picking2";
            SqlDataAdapter da = new SqlDataAdapter();
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


        public static int obtener_orden_surtimiento_picking1()
        {

            //ADN_Obtener_orden_surtimiento_pick1  
            //@Usuario VARCHAR(50)
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Obtener_orden_surtimiento_pick1";
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario);

            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                int id = int.Parse(cmd.ExecuteScalar().ToString());
                return id;
            }
            catch
            {
                return -1;
            }

        }

        public static DataSet obtener_datos_factura(string factura, string shipperid)
        {
            DataSet dt = new DataSet();
            //[dbo].[ADN_obtener_datos_factura2]	
            //@InvcNbr varchar(50),
            //@Shipperid varchar(50)
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_obtener_datos_factura2";
            cmd.Parameters.AddWithValue("@InvcNbr", factura);
            cmd.Parameters.AddWithValue("@Shipperid", shipperid);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
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

        	
        public static int obtener_zona_inicio_picking1()
        {
            //ADN_Obtener_zona_inicio
            //@Usuario VARCHAR(50),
            //@Orden int            
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Obtener_zona_inicio";
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario);
            cmd.Parameters.AddWithValue("@Orden", Global.orden_zona);

            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                int id = int.Parse(cmd.ExecuteScalar().ToString());
                return id;
            }
            catch
            {
                return -1;
            }

        }
        public static DataSet lista_art_surtir(string factura)
        {
            //ADN_Obtener_lista_art_surtir2	
            //@InvcNbr varchar(20),
            //@IdPicking INT,
            //@Usuario VARCHAR(50)
            //Obtiene la lista de articulos por surtir de el usuario en la pantalla de surtimiento
            //
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet dt = new DataSet();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Obtener_lista_art_surtir2";
            cmd.Parameters.AddWithValue("@InvcNbr", factura.Trim());
            cmd.Parameters.AddWithValue("@IdPicking", Global.picking);
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario);
            da.SelectCommand = cmd;
            try
            {
                da.Fill(dt);
                return dt;

            }
            catch
            {
                //MessageBox.Show("Error al obtener lista de articulos por surtir");
                return  null;
            }


        }

    
        public static bool verificar_factura_salida_usuario(string factura)
        {
            //ADN_Verificar_factura_salida_usuario
            //@InvcNbr VARCHAR(20),
            //@Usuario VARCHAR(50),
            //@IdPicking int          
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Verificar_factura_salida_usuario";
            cmd.Parameters.AddWithValue("@InvcNbr", factura);
            cmd.Parameters.AddWithValue("@Usuario", Global.usuario);
            cmd.Parameters.AddWithValue("@IdPicking", Global.picking);

            try
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }

        }
      public static   bool actualizar_status_factura(string factura, string status)
        {
            // ADN_terminar_surt_factura	
            //@InvcNbr VARCHAR(20),
            //@Usuario VARCHAR(50)
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Actualizar_Status_Factura_Usuario";
            cmd.Parameters.AddWithValue("@InvcNbr", factura.Trim());
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
                MessageBox.Show("Error al actualizar status de factura..");
                return false;
            }


        }

        	
      public static bool obtener_cantidades_partida(long id_surt_art, out decimal cantsol, out decimal cantsurt)
      {
          //ADN_Obtener_cantidades_partida
          //@ID_Surt_Art NUMERIC(9)
          SqlCommand cmd = new SqlCommand();
          SqlDataAdapter da = new SqlDataAdapter();
          DataSet dt = new DataSet();
          cmd.Connection = cn;
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.CommandText = "ADN_Obtener_cantidades_partida";
          //cmd.Parameters.AddWithValue("@InvcNbr", factura.Trim());
          cmd.Parameters.AddWithValue("@ID_Surt_Art", id_surt_art);
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
                           cantsol = decimal.Parse(dr["CantSol"].ToString());

                          if (!string.IsNullOrEmpty(dr["CantSurtida"].ToString()))
                          {
                              cantsurt = decimal.Parse(dr["CantSurtida"].ToString());
                          }
                          else
                          {
                              cantsurt = 0;
                          }
                          dt.Dispose();
                          return true;
                      }
                      else
                      {
                          cantsol = 0;
                          cantsurt = 0;
                          return false;
                      }
                  }
                  else
                  {
                      cantsol = 0;
                      cantsurt = 0;
                      return false;
                  }

              }
              else
              {
                  cantsol=0;
                  cantsurt = 0;
                  return false;
              
              }
             
          }
          catch (Exception ex)
          {
              MessageBox.Show("Error al obtener datos de surtimiento de la partida..");
              cantsol = 0;
              cantsurt = 0;
              return false;
          }


      }

      public static bool actualizar_status_partida(long id_surt_art, string status)
      {
          //ADN_actualizar_status_partida
          //@ID_Surt_Art NUMERIC(9)
          //@Usuario VARCHAR(50)
          //@Status VARCHAR(20)

          SqlCommand cmd = new SqlCommand();          
          cmd.Connection = cn;
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.CommandText = "ADN_actualizar_status_partida";          
          cmd.Parameters.AddWithValue("@ID_Surt_Art", id_surt_art);
          cmd.Parameters.AddWithValue("@Usuario", Global.usuario );
          cmd.Parameters.AddWithValue("@Status", status);
         
          try
          {

              if (cn.State == ConnectionState.Closed)
              {
                  cn.Open();
              }
              cmd.ExecuteNonQuery();
              return true;

          }
          catch (Exception ex)
          {
              MessageBox.Show("Error al actualizar status de articulo");
             
              return false;
          }


      }
      public static bool agregar_caja(string caja, int op)
      {
          //ADN_surtimiento_cajas_OP
          // Add the parameters for the stored procedure here
          //@InvcNbr VARCHAR(20),
          //@Numcaja INT,	
          //@OP INT,	
          //@Usuario VARCHAR(50),	
          //@Res BIT OUTPUT	

          SqlCommand cmd = new SqlCommand();
          cmd.Connection = Global.cn;
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.CommandText = "ADN_surtimiento_cajas_OP";
          cmd.Parameters.AddWithValue("@InvcNbr", invcnbr.Trim());
          cmd.Parameters.AddWithValue("@Numcaja", caja);
          cmd.Parameters.AddWithValue("@Usuario", Global.usuario);
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
                      MessageBox.Show("Error al actualizar factura");
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
      
      
      public static bool disponibilidad_caja(string caja, out string factura)
      {
         
          SqlCommand cmd = new SqlCommand();
          cmd.Connection = Global.cn;
          cmd.CommandType = CommandType.Text;
          cmd.CommandText = "SELECT InvcNbr,Numerocaja,Status FROM  ADN_Lista_surtimiento_cajas where Numerocaja=" + caja + " AND Status=0"  ;
          SqlDataAdapter da = new SqlDataAdapter();
          da.SelectCommand = cmd;
          DataSet dt = new DataSet();
          try
          {
              da.Fill(dt);
              if (dt != null)
              {
                  if (dt.Tables.Count > 0)
                  {
                      if (dt.Tables[0].Rows.Count > 0)
                      {
                          DataRow dr;
                          //La caja ya esta asiganada a una factura
                          dr = dt.Tables[0].Rows[0];
                          factura = dr["InvcNbr"].ToString().Trim();
                          return false;

                      }
                      else
                      {
                          factura = "";
                          return true;
                      }
                  }
                  else
                  {
                      factura = "";
                      return true;
                  }
              }
              else
              {
                 
                  factura = "";
                  return true;
              }

            


          }
          catch
          {
              MessageBox.Show("Error al verificar disponibilidad de caja", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
              factura = "";
              return false;
          }

      }
    
      public static bool salir_factura_picking1(string factura)
      {
          //ADN_salir_factura	
          //@InvcNbr VARCHAR(20),
          //@Usuario VARCHAR(50)

          SqlCommand cmd = new SqlCommand();
          cmd.Connection = cn;
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.CommandText = "ADN_salir_factura";
          cmd.Parameters.AddWithValue("@InvcNbr", factura);          
          cmd.Parameters.AddWithValue("@Usuario", Global.usuario);
          try
          {
              if (cn.State == ConnectionState.Closed)
              {
                  cn.Open();
              }
              cmd.ExecuteNonQuery();
              return true;
          }
          catch (Exception ex)
          {
              MessageBox.Show("Error al salir de la factura");
              return false;
          
          }
      }

      public static bool salir_factura_picking1_orden1(string factura)
      {
          //ADN_salir_factura_orden1	
          //@InvcNbr VARCHAR(20),
          //@Usuario VARCHAR(50)

          SqlCommand cmd = new SqlCommand();
          cmd.Connection = cn;
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.CommandText = "ADN_salir_factura_orden1";
          cmd.Parameters.AddWithValue("@InvcNbr", factura);
          cmd.Parameters.AddWithValue("@Usuario", Global.usuario);
          try
          {
              if (cn.State == ConnectionState.Closed)
              {
                  cn.Open();
              }
              cmd.ExecuteNonQuery();
              return true;
          }
          catch (Exception ex)
          {
              MessageBox.Show("Error al salir de la factura");
              return false;

          }
      }

      public static bool salir_factura_picking2(string factura)
      {
          //ADN_salir_factura	
          //@InvcNbr VARCHAR(20),
          //@Usuario VARCHAR(50)

          SqlCommand cmd = new SqlCommand();
          cmd.Connection = cn;
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.CommandText = "ADN_salir_factura_picking2";
          cmd.Parameters.AddWithValue("@InvcNbr", factura);
          cmd.Parameters.AddWithValue("@Usuario", Global.usuario);
          try
          {
              if (cn.State == ConnectionState.Closed)
              {
                  cn.Open();
              }
              cmd.ExecuteNonQuery();
              return true;
          }
          catch (Exception ex)
          {
              MessageBox.Show("Error al salir de la factura");
              return false;

          }
      }
      public static int tot_partidas_localizacion(string factura,string invtid, string loc)
      {
          //ADN_Total_partidas_localizacion1
          //@InvcNbr VARCHAR(20),
          //@InvtId VARCHAR(20),
          //@Localizacion VARCHAR(50)
          //obtiene el total de partidas 
          SqlCommand cmd = new SqlCommand();
          cmd.Connection = cn;
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.CommandText = "ADN_Total_partidas_localizacion1";
          cmd.Parameters.AddWithValue("@InvcNbr", factura);
          cmd.Parameters.AddWithValue("@InvtId",invtid);
          cmd.Parameters.AddWithValue("@Localizacion", loc);
          try
          {
              if (cn.State == ConnectionState.Closed)
              {
                  cn.Open();
              }
              return int.Parse(cmd.ExecuteScalar().ToString());
             
          }
          catch (Exception ex)
          {
              MessageBox.Show("Error al obtener total de partidas");
              return -1;

          }
      }

        /// <summary>
        /// Obtiene la cantidad total solicita de la clave en la localizacion
        /// </summary>
        /// <param name="factura"></param>
        /// <param name="invtid"></param>
        /// <param name="loc"></param>
        /// <returns></returns>
   public static decimal ObtenerCantidadTotalSolictadaLoc(string factura,string invtid, string loc)
      {
        //ADN_ObtenerCantidadTotalSolicitadaLocalizacion
        //@InvcNbr VARCHAR(20),
        //@InvtId VARCHAR(20),
        //@Localizacion VARCHAR(50)
          SqlCommand cmd = new SqlCommand();
          cmd.Connection = cn;
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.CommandText = "ADN_ObtenerCantidadTotalSolicitadaLocalizacion";
          cmd.Parameters.AddWithValue("@InvcNbr", factura);
          cmd.Parameters.AddWithValue("@InvtId",invtid);
          cmd.Parameters.AddWithValue("@Localizacion", loc);
          try
          {
              if (cn.State == ConnectionState.Closed)
              {
                  cn.Open();
              }
              return decimal.Parse(cmd.ExecuteScalar().ToString());
             
          }
          catch
          {
              MessageBox.Show("Error al obtener cantidad total solicitada en la localizacion");
              return -1;

          }
      }


/// <summary>
/// Obtiene la cantidad total surtida de la clave especificada en la localizacion
/// </summary>
/// <param name="factura"></param>
/// <param name="invtid"></param>
/// <param name="loc"></param>
/// <returns></returns>
   public static decimal ObtenerCantidadTotalSurtidaLoc(string factura, string invtid, string loc)
   {
       //ADN_ObtenerCantidadTotalSurtidaLocalizacion
       //@InvcNbr VARCHAR(20),
       //@InvtId VARCHAR(20),
       //@Localizacion VARCHAR(50)
       SqlCommand cmd = new SqlCommand();
       cmd.Connection = cn;
       cmd.CommandType = CommandType.StoredProcedure;
       cmd.CommandText = "ADN_ObtenerCantidadTotalSurtidaLocalizacion";
       cmd.Parameters.AddWithValue("@InvcNbr", factura);
       cmd.Parameters.AddWithValue("@InvtId", invtid);
       cmd.Parameters.AddWithValue("@Localizacion", loc);
       try
       {
           if (cn.State == ConnectionState.Closed)
           {
               cn.Open();
           }
           return decimal.Parse(cmd.ExecuteScalar().ToString());

       }
       catch
       {
           MessageBox.Show("Error al obtener cantidad total surtida en la localizacion");
           return -1;

       }
   }



      public static int tot_partidas_localizacion_PS(string factura,  string localizacion)
      {
          //ADN_Total_partidas_localizacion1
          //@InvcNbr VARCHAR(20),
          //@InvtId VARCHAR(20),
          //@Localizacion VARCHAR(50)
          //obtiene el total de partidas 
          SqlCommand cmd = new SqlCommand();
          cmd.Connection = cn;
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.CommandText = "ADN_Total_partidas_PS_localizacion";
          cmd.Parameters.AddWithValue("@InvcNbr", factura);         
          cmd.Parameters.AddWithValue("@Localizacion", localizacion);
          try
          {
              if (cn.State == ConnectionState.Closed)
              {
                  cn.Open();
              }
              return int.Parse(cmd.ExecuteScalar().ToString());

          }
          catch (Exception ex)
          {
              MessageBox.Show("Error al obtener total de partidas");
              return -1;

          }
      }

      public static void  totales_partidas_localizacion(string factura, string invtid, string loc, out int tot_partidas, out int tot_partidas_sa)
      {
         //ADN_Total_partidas_localizacion
         //@InvcNbr VARCHAR(20),
         //@InvtId VARCHAR(20),
         //@Localizacion VARCHAR(50)
          //obtiene el total de partidas 
          //tot_partidas,tot_partidas_sa

          SqlCommand cmd = new SqlCommand();
          cmd.Connection = cn;
          SqlDataAdapter da = new SqlDataAdapter();
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.CommandText = "ADN_Total_partidas_localizacion";
          cmd.Parameters.AddWithValue("@InvcNbr", factura);
          cmd.Parameters.AddWithValue("@InvtId", invtid);
          cmd.Parameters.AddWithValue("@Localizacion", loc);
          DataRow dr;
          DataSet dt=new DataSet();
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
                          if (!string.IsNullOrEmpty(dr["tot_partidas"].ToString()))
                          {
                              tot_partidas = int.Parse(dr["tot_partidas"].ToString());
                          }
                          else
                          {
                              tot_partidas = -1;
                          }

                          if (!string.IsNullOrEmpty(dr["tot_partidas_sa"].ToString()))
                          {
                              tot_partidas_sa = int.Parse(dr["tot_partidas_sa"].ToString());
                          }
                          else
                          {
                              tot_partidas_sa = -1;
                          }

       
                      }
                      else
                      {
                          tot_partidas = -1;
                          tot_partidas_sa = -1;
                      }
                  }
                  else
                  {
                      tot_partidas = -1;
                      tot_partidas_sa = -1;
                  }

              }
              else
              {
                  tot_partidas = -1;
                  tot_partidas_sa = -1;
              }


          }
          catch (Exception ex)
          {
              tot_partidas = -1;
              tot_partidas_sa = -1;
              MessageBox.Show("Error al obtener total de partidas " + ex.Message.ToString());
             //return -1;

          }
      }

      /// <summary>
      /// Funcion para actualizar una partida como surtida
      /// </summary>
      public static bool finalizar_partida(long id_surt_art)
      {
          decimal cantsol = 0; //cantidad solicitada
          decimal cantsurt = 0; //cantidad surtida actual
          if (Global.obtener_cantidades_partida(id_surt_art, out cantsol, out cantsurt))
          {
                  if (cantsol == cantsurt)
                  {
                      //si la cantidad solicitada y surtida son iguales actualizar el status de la partida como SA=Surtido
                      if (Global.actualizar_status_partida(id_surt_art, "SA"))
                      {
                          if (Global.picking == 1)
                          {
                              //Global.finalizar_status_zona_area(Global.invcnbr, IdZona, Area, "SO");
                              Global.finalizar_status_zona_area_picking1(Global.invcnbr, Global.idzona, Global.area, "SO");

                          }
                          else if (Global.picking == 2)
                          {
                              Global.actualiza_status_zona(Global.invcnbr, Global.idzona, "SO");

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
                      if (Global.actualizar_status_partida(id_surt_art, "PS"))
                      {
                          if (Global.picking == 1)
                          {
                              //Global.finalizar_status_zona_area(Global.invcnbr, IdZona, Area, "SO");
                              Global.finalizar_status_zona_area_picking1(Global.invcnbr, Global.idzona, Global.area, "SO");
                          }
                          else if (Global.picking == 2)
                          {
                              Global.actualiza_status_zona(Global.invcnbr, Global.idzona, "SO");

                          }

                          return true;

                      }
                      else
                      {
                          return false; 
                      }

                      
                  }
              //}
             
          }
          else
          {
              return false;
          }
         
      }

      /// <summary>
      /// Funcion para registrar un articulo y este se pueda capturar de forma manual en surtimiento
      /// </summary>
      public bool AgregarArticuloExcepcionCaptura(string pInvtID)
      {
          //Permite agregar la clave del articulo para que les permita a los surtidores capturarla manualmente
          try
          {
              //@InvtID VARCHAR(50),
              //@Usuario VARCHAR(50)
              SqlCommand cmd = new SqlCommand("ADN_AgregarArticuloExcepcionCaptura", cn);
              cmd.CommandType = CommandType.StoredProcedure;
              cmd.Parameters.AddWithValue("@InvtID", pInvtID);
              cmd.Parameters.AddWithValue("@Usuario", usuario);
              if (cn.State == ConnectionState.Closed)
              {
                  cn.Open();
              }
              cmd.ExecuteNonQuery();
              cn.Close();
              return true;
          }//try
          catch (Exception ex)
          {
              MessageBox.Show("Error al registrar excepcion de articulo");
              return false;
          } // catch
          finally
          {
              if (cn != null && cn.State != ConnectionState.Closed)
              {
                  //Cerramos conexión a BD
                  cn.Close();
              }
          }//finally
      }

        /// <summary>
        /// Obtiene el total de partidas pendientes de surtir de la localizacion
        /// </summary>
        /// <param name="pInvcNbr"></param>
        /// <param name="pInvtID"></param>
        /// <param name="pLocalizacion"></param>
        /// <returns></returns>
      public int ObtenerTotalPartidasClaveLocalizacion(string pInvcNbr, string pInvtID, string pLocalizacion)
      {
        // ADN_ObtenerTotalPartidasLocalizacion
        //@InvcNbr VARCHAR(20),
        //@InvtId VARCHAR(20),
        //@Localizacion VARCHAR(50)
          try
          {
              int tot = 0;
              SqlCommand cmd = new SqlCommand("ADN_ObtenerTotalPartidasLocalizacion", cn);
              cmd.CommandType = CommandType.StoredProcedure;
              cmd.Parameters.AddWithValue("@InvcNbr", pInvcNbr );
              cmd.Parameters.AddWithValue("@InvtId", pInvtID);
              cmd.Parameters.AddWithValue("@Localizacion", pLocalizacion );
              if (cn.State == ConnectionState.Closed)
              {
                  cn.Open();
              }
              tot=int.Parse( cmd.ExecuteScalar().ToString())  ;
              cn.Close();
              return tot;
          }//try
          catch 
          {
              MessageBox.Show("Error al obtener el total de partidas de la localizacion");
              return 0;
          } // catch
          finally
          {
              if (cn != null && cn.State != ConnectionState.Closed)
              {
                  //Cerramos conexión a BD
                  cn.Close();
              }
          }//finally
      }
        /// <summary>
        /// Muestra la alerta de articulo completado
        /// </summary>
        /// <param name="pInvtid"></param>
        /// <param name="pCantSurtida"></param>
        /// <param name="pCantSol"></param>
        /// <param name="pCaja"></param>
      public static void MostrarAlertaArticuloSurtido(string pInvtid,string pCantSurtida, string pCantSol, string pCaja)
      {
          frm_Alerta f = new frm_Alerta();
          frm_Alerta.colorfondo = Color.Lime;
          f.timer2.Enabled = true;
          f.lbl_msj.ForeColor = Color.Black;
          f.lbl_msj.Text = "ARTICULO COMPLETADO:  " + pInvtid;
          f.lbl_surtido.Text = "SURTIDO:" + pCantSurtida  + "/" + pCantSol ;
          f.lbl_msj_caja.Text = "DEPOSITAR EN CAJA: " + pCaja;
          if (Global.picking == 1)
          {
              f.caja = pCaja ;
              f.lbl_msj_caja.Visible = true;
              f.btn_ok.Enabled = false;
              f.txt_caja.Visible = true;
              f.timer2.Enabled = true;
              f.txt_caja.Focus();
          }
          else
          {
              f.caja = pCaja ;
              f.lbl_msj_caja.Visible = false;
              f.btn_ok.Enabled = true;
              f.txt_caja.Visible = false;
              f.timer2.Enabled = false;
          }
          f.ShowDialog();
          f.Dispose();
      
      }
        /// <summary>
        /// Obtiene el reporte de todo el proceso de surtimiento por zona
        /// </summary>
        /// <returns></returns>
      public static DataSet ReporteProcesossurtiemientoZonas()
      {
          //ADN_ReporteProcesossurtimientoZona
          SqlCommand cmd = new SqlCommand();
          DataSet dt = new DataSet();
          SqlDataAdapter da = new SqlDataAdapter(); 
          cmd.Connection = cn;
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.CommandText = "ADN_ReporteProcesossurtimientoZona";
          da.SelectCommand = cmd; 
          try
          {
              da.Fill(dt);
              return dt;
          }
          catch 
          {
              //MessageBox.Show("Error al obtener reporte.." + ex.Message.ToString()  );
              return null;
          }
      }

   /// <summary>
   /// Obtiene el numero de zona de la partida en surtimiento
   /// </summary>
   /// <param name="pInvcNbr"></param>
   /// <returns></returns>
      public static int ObtenerIdZonaSurtimientoFactura(string pInvcNbr)
      {
          // ADN_ObtenerZonaSurtimientoFactura
          //@InvcNbr VARCHAR(20)
          try
          {
              int IdZona = 0;
              SqlCommand cmd = new SqlCommand("ADN_ObtenerZonaSurtimientoFactura", cn);
              cmd.CommandType = CommandType.StoredProcedure;
              cmd.Parameters.AddWithValue("@InvcNbr", pInvcNbr);             
              if (cn.State == ConnectionState.Closed)
              {
                  cn.Open();
              }
              IdZona = int.Parse(cmd.ExecuteScalar().ToString());
              cn.Close();
              return IdZona;
          }//try
          catch
          {
              MessageBox.Show("Error al obtener Zona");
              return 0;
          } // catch
          
      }





    //public static SurtirPartidaArticulo( 
    //    string ID_Surt_Art,
    //    string invc, 
    //    string loc, 
    //    string sku, 
    //    string codigo,
    //    string cant, 
    //    string caja
    //    )
    //  {  
    //   //ADN_SurtirArticuloPicking
    ////@ID_Surt_Art NUMERIC(9),
    ////@InvcNbr VARCHAR(50), --numero de factura
    ////@Localizacion VARCHAR(50), --localizacion de la cual se van agregar los articulos
    ////@SKU VARCHAR(50), ---codigo del articulo que se va agregar
    ////@CodigoBarras VARCHAR(50), --el codigo de barras
    ////@Cantidad NUMERIC(9,2), -- cantidad que se va agregar
    ////@tot_surt numeric(9,2) OUTPUT, --cantidad total surtida del articulo
    ////@Numcaja INT,-- numero de caja 
    ////@Usuario VARCHAR(50),
    ////@ID_SurtArtSig NUMERIC(9) OUTPUT, --id de partida por surtir siguiente
    ////@TotalSurtido numeric(9,2) OUTPUT --obtiene el total surtido de  la partida
    //      SqlCommand cmd = new SqlCommand();
    //      try
    //      {
    //          //Cursor.Current = Cursors.WaitCursor; 
    //          cmd.Connection = Global.cn;
    //          cmd.CommandType = CommandType.StoredProcedure;
    //          cmd.CommandText = "ADN_SurtirArticuloPicking";
    //          cmd.Parameters.AddWithValue("@ID_Surt_Art", ID_Surt_Art);
    //          cmd.Parameters.AddWithValue("@InvcNbr", invc.Trim());
    //          cmd.Parameters.AddWithValue("@Localizacion", loc.Trim().ToUpper());
    //          cmd.Parameters.AddWithValue("@SKU", sku.Trim());
    //          cmd.Parameters.AddWithValue("@Numcaja", caja);
    //          if (codigo == "")
    //          {
    //              cmd.Parameters.AddWithValue("@CodigoBarras", DBNull.Value);
    //          }
    //          else
    //          {
    //              cmd.Parameters.AddWithValue("@CodigoBarras", codigo.Trim());
    //          }
    //          //cantidad que se va agregar
    //          cmd.Parameters.AddWithValue("@Cantidad", cant);
    //          cmd.Parameters.Add("@TotalSurtido", SqlDbType.Decimal);
    //          cmd.Parameters["@TotalSurtido"].Direction = ParameterDirection.Output;

    //           cmd.Parameters.Add("@ID_SurtArtSig", SqlDbType.Int);
    //          cmd.Parameters["@ID_SurtArtSig"].Direction = ParameterDirection.InputOutput;
    //          cmd.Parameters["@ID_SurtArtSig"].Value=DBNull.Value ;  
    //          //@ID_SurtArtSig

    //          //cmd.Parameters["@tot_surt"].Value = 0;              

    //          cmd.Parameters.AddWithValue("@Usuario", Global.usuario);
              
    //          if (Global.cn.State == ConnectionState.Closed)
    //          {
    //              Global.cn.Open();
    //          }

    //          cmd.ExecuteNonQuery();

    //          if (!string.IsNullOrEmpty(cmd.Parameters["@tot_surt"].Value.ToString()))
    //          {

    //              //lbl_surtir_loc.Text = tot_surtir.ToString();
    //              tot_surtir = cantsol - Convert.ToDecimal(cmd.Parameters["@tot_surt"].Value.ToString());
    //              if (tot_partidas == 1)
    //              {
    //                  tot_cant_surtida = Convert.ToDecimal(cmd.Parameters["@tot_surt"].Value.ToString());
    //                  lblsurtido.Text = tot_cant_surtida.ToString();
    //                  lbl_tot_por_surtir.Text = tot_surtir.ToString();
    //              }
    //              else if (tot_partidas > 1)
    //              {
    //                  //obtiene la cantidad total solicitada en la localizacion de la clave especificada
    //                  CantSolLoc = Global.ObtenerCantidadTotalSolictadaLoc(Global.invcnbr, invtid, lbl_loc_surt.Text.Trim());
    //                  lbl_surtir_loc.Text = CantSolLoc.ToString();
    //                  //Obtiene el total surtido en la localizacion
    //                  CantSurtLoc = Global.ObtenerCantidadTotalSurtidaLoc(Global.invcnbr, invtid, lbl_loc_surt.Text.Trim());
    //                  //Cantidad por surtir en la localizacion
    //                  CantPorSurtirLoc = CantSolLoc - CantSurtLoc;
    //                  //Visualizar Total surtido en la localizacion
    //                  lblsurtido.Text = CantSurtLoc.ToString();
    //                  //Visualizar total por surtir

    //                  lbl_tot_por_surtir.Text = CantPorSurtirLoc.ToString();


    //              }
    //              //si la cantidad por surtir de la partida es cero
    //              if (tot_surtir <= 0)
    //              {
    //                  //si solo existe una partida de la clave
    //                  if (tot_partidas == 1)
    //                  {
    //                      if (Global.tot_partidas_localizacion_PS(Global.invcnbr, localizacion) > 0)
    //                      {
    //                          if (ObtenerArticuloPorSurtirLocalizacion())
    //                          {
    //                              return true;
    //                          }
    //                          else
    //                          {
    //                              Global.MostrarAlertaArticuloSurtido(invtid, tot_cant_surtida.ToString(), cantsol.ToString(), lblcaja.Text.Trim());
    //                              this.Close();
    //                              return true;
    //                          }
    //                      }
    //                      else
    //                      {
    //                          Global.MostrarAlertaArticuloSurtido(invtid, tot_cant_surtida.ToString(), cantsol.ToString(), lblcaja.Text.Trim());
    //                          this.Close();
    //                          return true;
    //                      }
    //                  }
    //                  else if (tot_partidas > 1)
    //                  {
    //                      //verificar si existen partidas pendientes de surtir de la misma clava
    //                      if (Global.Obtener_TotPartidasPorSurtirClaveLocalizacion(Global.invcnbr, localizacion, invtid) > 0)
    //                      {
    //                          //obtener la siguiente partida para surtir
    //                          if (ObtenerSiguientePartidaPorSurtirClaveLocalizacion())
    //                          {
    //                              return true;
    //                          }
    //                          else
    //                          {
    //                              Global.MostrarAlertaArticuloSurtido(invtid,
    //                                  CantSolLoc.ToString(),
    //                                  CantSurtLoc.ToString(),
    //                                  lblcaja.Text.Trim()
    //                                  );
    //                              this.Close();
    //                              return true;
    //                          }
    //                      }
    //                      else
    //                      {
    //                          //verificar si existen partidas por surtir de otra clave en la localizacion
    //                          Global.MostrarAlertaArticuloSurtido(invtid,
    //                                 CantSolLoc.ToString(),
    //                                 CantSurtLoc.ToString(),
    //                                 lblcaja.Text.Trim()
    //                                 );

    //                          if (Global.tot_partidas_localizacion_PS(Global.invcnbr, localizacion) > 0)
    //                          {
    //                              if (ObtenerArticuloPorSurtirLocalizacion())
    //                              {
    //                                  return true;
    //                              }
    //                              else
    //                              {
    //                                  this.Close();
    //                                  return true;
    //                              }
    //                          }
    //                          else
    //                          {
    //                              this.Close();
    //                              return true;
    //                          }

    //                      }

    //                  }

    //              }
    //          }
    //          return true;
    //      }
    //      catch (Exception ex)
    //      {
    //          MessageBox.Show("Error al agregar articulo.." + ex.Message.ToString());
    //          return false;
    //      }
    //  }

        

      ///// <summary>
      ///// Funcion para registrar un articulo y este se pueda capturar de forma manual en surtimiento
      ///// </summary>
      //public bool AgregarArticuloExcepcionCaptura(string pInvtID)
      //{
      //    //Permite agregar la clave del articulo para que les permita a los surtidores capturarla manualmente
      //    try
      //    {
      //        //@InvtID VARCHAR(50),
      //        //@Usuario VARCHAR(50)
      //        SqlCommand cmd = new SqlCommand("ADN_AgregarArticuloExcepcionCaptura", cn);
      //        cmd.CommandType = CommandType.StoredProcedure;
      //        cmd.Parameters.AddWithValue("@InvtID", pInvtID);
      //        cmd.Parameters.AddWithValue("@Usuario", usuario);
      //        if (cn.State == ConnectionState.Closed)
      //        {
      //            cn.Open();
      //        }
      //        cmd.ExecuteNonQuery();
      //        cn.Close();
      //        return true;
      //    }//try
      //    catch (Exception ex)
      //    {
      //        MessageBox.Show("Error al registrar excepcion de articulo");
      //        return false;
      //    } // catch
      //    finally
      //    {
      //        if (cn != null && cn.State != ConnectionState.Closed)
      //        {
      //            //Cerramos conexión a BD
      //            cn.Close();
      //        }
      //    }//finally
      //}




    }
}

//}

//}
