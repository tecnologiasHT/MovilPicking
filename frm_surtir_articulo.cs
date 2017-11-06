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
    public partial class frm_surtir_articulo : Form
    {
        public frm_surtir_articulo()
        {
            InitializeComponent();
        }
        //declarar objetos Reader & ReaderData 
        //Symbol.Barcode.Reader barcodeReader = null;
        //Symbol.Barcode.ReaderData barcodeReaderData = null;
        public bool excepcion = false;

        public bool desbloq = false;

        void msjsurtirarticulo()
        {
            System.Media.SystemSounds.Beep.Play();            
        }

        public string invcnbr; //factura principal
        public string invcnbr_surtiendo = "";
        public string invtid; //clave del articulo
        public string localizacion = "";
        public long ID_Surt_Art = 0; //clave de la partida
        public decimal cantsol=0; //cantidad solicitada
        public decimal tot_cantsol = 0; //total cantidad solicitada
        public decimal tot_cant_surtida = 0; //total cantidad solicitada
        public decimal tot_surtir=0;  //total por surtir del articulo cuando es solo una partida
        public string status="";      //
        public int idzona ;    //zona actual
        public string area = "";
        public int tot_partidas = 0; //Variable para controlar el numero de partidas de la misma clave y localizacion
        public decimal CantSolLoc = 0; //Cantidad total solicita en la localizacion
        public decimal CantSurtLoc = 0; //Cantidad total surtida en la localizacion
        public decimal CantPorSurtirLoc = 0;//Cantidad pendiente por surtir en la localizacion
        Global mod = new Global();
        
        bool obtener_articulo_zonas_picking1(string factura)
        {
            //timer1.Enabled = false;
            //txt_desc.Text = "Espere un momento, Obteniendo Articulo...";
            DataSet dt = new DataSet();
            DataRow dr;
            try
            {
                dt = Global.Obtener_articulo_para_surtir_zonas_picking1(Global.invcnbr);               
                if (dt.Tables.Count != 0)
                {
                    if (dt.Tables[0].Rows.Count != 0)
                    {
                        System.Media.SystemSounds.Beep.Play();

                        dr = dt.Tables[0].Rows[0];
                                              
                        if (!string.IsNullOrEmpty(dr["ID_Surt_Art"].ToString()))
                        {
                            ID_Surt_Art = Convert.ToInt64(dr["ID_Surt_Art"].ToString());
                        }
                        else
                        {
                            ID_Surt_Art = 0;
                            return false;
                        }


                        tot_partidas = mod.ObtenerTotalPartidasClaveLocalizacion(Global.invcnbr, invtid, lbl_loc_surt.Text.Trim());
                        lblTotPartidas.Text = tot_partidas.ToString();                            
                        //lblTotPartidas.Text = totpartidas.ToString();

                        //total_surtir
                        if (!string.IsNullOrEmpty(dr["CantSol"].ToString()))
                        {

                           cantsol = Convert.ToDecimal(dr["CantSol"].ToString());
                        }
                        else
                        {
                            cantsol = 0;
                            CantSolLoc = 0;
                        }

                        //total surtido
                        if (!string.IsNullOrEmpty(dr["CantSurtida"].ToString()))
                        {
                            tot_cant_surtida = Convert.ToDecimal(dr["CantSurtida"].ToString().Trim());
                        }
                        else
                        {
                            tot_cant_surtida = 0;
                           
                        }

                        //if (tot_partidas == 1)
                        //{
                            CantSolLoc = cantsol; //cantidad total solictada
                            CantSurtLoc = tot_cant_surtida; //cantidad surtida en la localizacion
                            lbl_surtir_loc.Text = dr["CantSol"].ToString().Trim();
                            lblsurtido.Text   = dr["CantSurtida"].ToString().Trim();
                            lbl_tot_por_surtir.Text = (cantsol - tot_cant_surtida).ToString(); 
                            ///lbl_pendiente.Text = (Convert.ToDecimal(cant_sol) - Convert.ToDecimal(dr["CantSurtida"].ToString().Trim())).ToString();

                        //}
                        //else if (tot_partidas > 1)
                        //{
                        //    //obtiene la cantidad total solictada en la localizacion de la clave especificada
                        //    CantSolLoc = Global.ObtenerCantidadTotalSolictadaLoc(Global.invcnbr, invtid, lbl_loc_surt.Text.Trim());
                        //    //obtiene la cantidad total surtida de la localizacion
                        //    CantSurtLoc = Global.ObtenerCantidadTotalSurtidaLoc(Global.invcnbr, invtid, lbl_loc_surt.Text.Trim());
                        //    lbl_surtir_loc.Text = CantSolLoc.ToString();
                        //    //lbl_cant_surtida.Text = CantSurtLoc.ToString();
                        //    //lbl_pendiente.Text = (Convert.ToDecimal(cant_sol) - Convert.ToDecimal(dr["CantSurtida"].ToString().Trim())).ToString();

                        //}


                        //System.Media.SystemSounds.Beep.Play();
                        //if (totpartidas == 1)
                        //{
                        //    pend_surt_art = cant_sol - tot_surtido_articlo;
                        //}
                        //else if (totpartidas > 1)
                        //{
                        //    pend_surt_art = CantSolLoc - CantSurtLoc;
                        //}

                        //if (pend_surt_art == 0)
                        //{
                        //    //tab_captura.Enabled = false;
                        //    MessageBox.Show("Articulo Completado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        //    limpiar_articulo();
                        //    txt_desc.Text = "Obteniendo siguiente articulo...";
                        //}

                        //txt_loc.Focus();
                        return true;
                    }
                    else
                    {
                        //Cursor.Current = Cursors.Default;
                        dt.Dispose();
                        //MessageBox.Show("No hay articulos para surtir", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
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
                //MessageBox.Show("Error al obtener articulo para surtir..." + ex.Message.ToString());
                return false;
            }

        }

        bool obtener_articulo_para_surtir_picking2(string factura)
        {
            //version PIVA
            //ADN_obtener_articulo_para_surtir_picking2	
            //@InvcNbr VARCHAR(15),	
            //@Usuario VARCHAR(50)           
            //SqlCommand cmd = new SqlCommand();
            DataSet dt = new DataSet();
            //SqlDataAdapter da = new SqlDataAdapter();
            DataRow dr;
            try
            {
                dt = Global.obtener_articulo_para_surtir_picking2(Global.invcnbr);
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

                        
                        if (!string.IsNullOrEmpty(dr["ID_Surt_Art"].ToString()))
                        {
                            ID_Surt_Art = Convert.ToInt64(dr["ID_Surt_Art"].ToString());
                        }
                        else
                        {
                            ID_Surt_Art = 0;
                            return false;
                        }
                        tot_partidas = mod.ObtenerTotalPartidasClaveLocalizacion(Global.invcnbr, invtid, lbl_loc_surt.Text.Trim());
                        lblTotPartidas.Text = tot_partidas.ToString();                                             
                      
                        //total_surtir
                        if (!string.IsNullOrEmpty(dr["CantSol"].ToString()))
                        {
                            //lbl_surtir_loc.Text = dr["CantSol"].ToString().Trim();
                            cantsol  = Convert.ToDecimal(dr["CantSol"].ToString());
                        }
                        else
                        {
                            cantsol = 0;
                        }
                        
                        if (!string.IsNullOrEmpty(dr["CantSurtida"].ToString()))
                        {
                            //lbl_cant_surtida.Text = dr["CantSurtida"].ToString().Trim();
                            //tot_surtido_articlo = Convert.ToDecimal(dr["CantSurtida"].ToString().Trim());
                            ////lbl_tot_pend.Text
                            //lbl_pendiente.Text = (Convert.ToDecimal(cant_sol) - Convert.ToDecimal(dr["CantSurtida"].ToString().Trim())).ToString();
                            tot_cant_surtida = Convert.ToDecimal(dr["CantSurtida"].ToString().Trim());
                        }
                        else
                        {
                            //lbl_cant_surtida.Text = "0";
                            //tot_surtido_articlo = 0;
                            //lbl_pendiente.Text = cant_sol.ToString();
                            tot_cant_surtida=0;
                        }

                        //if (tot_partidas == 1)
                        //{
                            CantSolLoc = cantsol; //cantidad total solictada
                            CantSurtLoc = tot_cant_surtida; //cantidad surtida en la localizacion
                            lbl_surtir_loc.Text = dr["CantSol"].ToString().Trim();
                            lblsurtido.Text = dr["CantSurtida"].ToString().Trim();
                            lbl_tot_por_surtir.Text = (cantsol - tot_cant_surtida).ToString();
                            ///lbl_pendiente.Text = (Convert.ToDecimal(cant_sol) - Convert.ToDecimal(dr["CantSurtida"].ToString().Trim())).ToString();

                        //}
                        //else if (tot_partidas > 1)
                        //{
                        //    //obtiene la cantidad total solictada en la localizacion de la clave especificada
                        //    CantSolLoc = Global.ObtenerCantidadTotalSolictadaLoc(Global.invcnbr, invtid, lbl_loc_surt.Text.Trim());
                        //    //obtiene la cantidad total surtida de la localizacion
                        //    CantSurtLoc = Global.ObtenerCantidadTotalSurtidaLoc(Global.invcnbr, invtid, lbl_loc_surt.Text.Trim());
                        //    lbl_surtir_loc.Text = CantSolLoc.ToString();
                        //    //lbl_cant_surtida.Text = CantSurtLoc.ToString();
                        //    //lbl_pendiente.Text = (Convert.ToDecimal(cant_sol) - Convert.ToDecimal(dr["CantSurtida"].ToString().Trim())).ToString();

                        //}

                        //System.Media.SystemSounds.Beep.Play();
                        //pend_surt_art = cant_sol - tot_surtido_articlo;
                        //if (pend_surt_art == 0)
                        //{
                        //    //tab_captura.Enabled = false;
                        //    MessageBox.Show("Articulo Completado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        //    limpiar_articulo();
                        //    txt_desc.Text = "Obteniendo siguiente articulo...";
                        //}

                        //txt_loc.Focus();
                        return true;
                    }
                    else
                    {
                        Cursor.Current = Cursors.Default;
                        //cmd.Dispose();
                        //MessageBox.Show("No hay articulos para surtir", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
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
                //cmd.Dispose();
                //MessageBox.Show("Error al obtener articulo para surtir..." + ex.Message.ToString());
                return false;
            }
            //Cursor.Current = Cursors.Default;
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

        /// <summary>
        /// Obtiene la siguiente partida por surtir en la lcalizacion
        /// </summary>
        /// <returns></returns>
        /// ADN_ObtenerPartidaPorSurtirLocalizacion
        bool ObtenerArticuloPorSurtirLocalizacion()
        {            
            DataSet dt = new DataSet();
            DataRow dr;
            try
            {
                //Obtener el articulo pendiente de surtir en la localizacion actual
                dt = Global.Obtener_articulo_para_surtir_localizacion(Global.invcnbr,localizacion);

                if (dt == null)
                {
                   // MessageBox.Show("No hay articulos para surtir", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return false;
                }
                if (dt.Tables.Count != 0)
                {
                    if (dt.Tables[0].Rows.Count != 0)
                    {
                        System.Media.SystemSounds.Beep.Play();

                        dr = dt.Tables[0].Rows[0];

                        if (!string.IsNullOrEmpty(dr["ID_Surt_Art"].ToString()))
                        {
                            ID_Surt_Art = Convert.ToInt64(dr["ID_Surt_Art"].ToString());
                        }
                        else
                        {
                            ID_Surt_Art = 0;
                            return false;
                        }
                        if (!string.IsNullOrEmpty(dr["InvcNbr"].ToString()))
                        {
                            invcnbr_surtiendo  = dr["InvcNbr"].ToString();
                        }
                        else
                        {
                            invcnbr_surtiendo = "";
                            return false;
                        }
                        
                        if (!string.IsNullOrEmpty(dr["Localizacion"].ToString()))
                        {
                            lbl_loc_surt.Text = dr["Localizacion"].ToString().Trim();
                        }

                        if (!string.IsNullOrEmpty(dr["Unidad"].ToString()))
                        {
                            lbl_unidad.Text = dr["Unidad"].ToString().Trim();
                        }
                        //Cantidad total a surtir de la partida asignada
                        if (!string.IsNullOrEmpty(dr["CantSol"].ToString()))
                        {
                           //lbl_surtir_loc.Text = dr["CantSol"].ToString().Trim();
                           cantsol = Convert.ToDecimal(dr["CantSol"].ToString());
                           //tot_cantsol = tot_cantsol + decimal.Parse(dr["CantSol"].ToString());
                        }
                        else
                        {
                            cantsol = 0;
                        }

                        //Cantidad surtida de la partida asignada
                        if (!string.IsNullOrEmpty(dr["CantSurtida"].ToString()))
                        {
                            //lblsurtido.Text = dr["CantSurtida"].ToString().Trim();
                            tot_surtir = cantsol - decimal.Parse(dr["CantSurtida"].ToString().Trim());
                            tot_cant_surtida = Convert.ToDecimal(dr["CantSurtida"].ToString().Trim());
                            ////lbl_tot_pend.Text
                            //lbl_pendiente.Text = (Convert.ToDecimal(cant_sol) - Convert.ToDecimal(dr["CantSurtida"].ToString().Trim())).ToString();

                        }
                        else
                        {
                            lblsurtido.Text = "0";
                            tot_surtir = cantsol;
                            tot_cant_surtida = 0;
                        }

                        //obtener el total de partidas solicitas de la clave en la localizacion
                        tot_partidas = mod.ObtenerTotalPartidasClaveLocalizacion(Global.invcnbr, invtid, lbl_loc_surt.Text.Trim());
                        lblTotPartidas.Text = tot_partidas.ToString();                        

                        //if (tot_partidas == 1)
                        //{
                            //CantSolLoc = cantsol; //cantidad total solicitada
                            //CantSurtLoc = tot_cant_surtida; //cantidad surtida en la localizacion
                            lbl_surtir_loc.Text = dr["CantSol"].ToString().Trim();
                            lblsurtido.Text = tot_cant_surtida.ToString().Trim()   ;
                            lbl_tot_por_surtir.Text = (cantsol - tot_cant_surtida).ToString();
                            ///lbl_pendiente.Text = (Convert.ToDecimal(cant_sol) - Convert.ToDecimal(dr["CantSurtida"].ToString().Trim())).ToString();

                        //}
                        //else if (tot_partidas > 1)
                        //{
                        //    //obtiene la cantidad total solicitada en la localizacion de la clave especificada
                        //    CantSolLoc = Global.ObtenerCantidadTotalSolictadaLoc(Global.invcnbr, invtid, lbl_loc_surt.Text.Trim());
                        //    //visualizar la cantidad total por surtir
                        //    lbl_surtir_loc.Text = CantSolLoc.ToString(); 
                        //    //obtiene la cantidad total surtida de la localizacion
                        //    CantSurtLoc = Global.ObtenerCantidadTotalSurtidaLoc(Global.invcnbr, invtid, lbl_loc_surt.Text.Trim());
                        //    lblsurtido.Text = CantSurtLoc.ToString();
   
                        //    lbl_tot_por_surtir.Text = (CantSolLoc - CantSurtLoc).ToString();
                        //    //lbl_cant_surtida.Text = CantSurtLoc.ToString();
                        //    //lbl_pendiente.Text = (Convert.ToDecimal(cant_sol) - Convert.ToDecimal(dr["CantSurtida"].ToString().Trim())).ToString();
                        //}



                        System.Media.SystemSounds.Beep.Play();
                        
                        //txt_loc.Focus();
                        return true;
                    }
                    else
                    {
                        Cursor.Current = Cursors.Default;
                        dt.Dispose();
                        //MessageBox.Show("No hay articulos para surtir", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
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
                //MessageBox.Show("Error al obtener articulo para surtir..." + ex.Message.ToString());
                return false;
            }

        }
        /// <summary>
        /// Obtiene la siguiente partida por surtir en la localizacion
        /// </summary>
        /// <returns></returns>
        bool ObtenerSiguientePartidaPorSurtirClaveLocalizacion()
        {
            DataSet dt = new DataSet();
            DataRow dr;
            try
            {
                //Obtener el articulo pendiente de surtir en la localizacion actual
                dt = Global.Obtener_Partida_Surtir_Localizacion(Global.invcnbr, localizacion,invtid );

                if (dt == null)
                {
                    // MessageBox.Show("No hay articulos para surtir", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return false;
                }
                if (dt.Tables.Count != 0)
                {
                    if (dt.Tables[0].Rows.Count != 0)
                    {
                        System.Media.SystemSounds.Beep.Play();

                        dr = dt.Tables[0].Rows[0];

                        if (!string.IsNullOrEmpty(dr["ID_Surt_Art"].ToString()))
                        {
                            ID_Surt_Art = Convert.ToInt64(dr["ID_Surt_Art"].ToString());
                        }
                        else
                        {
                            ID_Surt_Art = 0;
                            return false;
                        }
                        if (!string.IsNullOrEmpty(dr["InvcNbr"].ToString()))
                        {
                            invcnbr_surtiendo = dr["InvcNbr"].ToString();
                        }
                        else
                        {
                            invcnbr_surtiendo = "";
                            return false;
                        }
                        //obtener el total de partidas solicitas de la clave en la localizacion
                        tot_partidas = mod.ObtenerTotalPartidasClaveLocalizacion(Global.invcnbr, invtid, lbl_loc_surt.Text.Trim());
                        lblTotPartidas.Text = tot_partidas.ToString();
                        //Cantidad total a surtir de la partida asignada
                        if (!string.IsNullOrEmpty(dr["CantSol"].ToString()))
                        {
                            //lbl_surtir_loc.Text = dr["CantSol"].ToString().Trim();
                            cantsol = Convert.ToDecimal(dr["CantSol"].ToString());
                           // tot_cantsol = tot_cantsol + decimal.Parse(dr["CantSol"].ToString());
                        }
                        else
                        {
                            cantsol = 0;
                        }

                        //Cantidad surtida de la partida asignada
                        if (!string.IsNullOrEmpty(dr["CantSurtida"].ToString()))
                        {
                            //lblsurtido.Text = dr["CantSurtida"].ToString().Trim();
                            tot_surtir = cantsol - decimal.Parse(dr["CantSurtida"].ToString().Trim());
                            tot_cant_surtida = decimal.Parse(dr["CantSurtida"].ToString().Trim());
                        }
                        else
                        {
                            lblsurtido.Text = "0";
                            tot_surtir = cantsol;
                            tot_cant_surtida = 0;
                        }

                                              
                           lbl_surtir_loc.Text = dr["CantSol"].ToString().Trim();
                           lblsurtido.Text = tot_cant_surtida.ToString()  ;
                           lbl_tot_por_surtir.Text = tot_surtir.ToString().Trim() ;
                            
                                                
                        System.Media.SystemSounds.Beep.Play();

                        //txt_loc.Focus();
                        return true;
                    }
                    else
                    {
                        Cursor.Current = Cursors.Default;
                        dt.Dispose();
                        //MessageBox.Show("No hay articulos para surtir", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        return false;


                    }

                }
                else
                {
                    dt.Dispose();
                    return false;
                }
            }
            catch 
            {
                Cursor.Current = Cursors.Default;
                dt.Dispose();
                //MessageBox.Show("Error al obtener articulo para surtir..." + ex.Message.ToString());
                return false;
            }

        }




        bool agregar_cve(string invc, string loc, string sku, string cant, string caja)
        {
            //@ID_Surt_Art NUMERIC(9),
            //@InvcNbr VARCHAR(20), --numero de factura
            //@Localizacion VARCHAR(50), --localizacion de la cual se van agregar los articulos
            //@SKU VARCHAR(50), ---codigo del articulo que se va agregar
            //@CodigoBarras VARCHAR(50), --el codigo de barras
            //@Cantidad NUMERIC(9,2), -- cantidad que se va agregar
            //@tot_surt numeric(9,2) OUTPUT, --cantidad total surtida del articulo
            //@Numcaja INT,-- numero de caja 
            //@Usuario VARCHAR(50)

            SqlCommand cmd = new SqlCommand();
            try
            {
                //Cursor.Current = Cursors.WaitCursor; 
                cmd.Connection = Global.cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ADN_agregar_art_lista_surt";
                cmd.Parameters.AddWithValue("@ID_Surt_Art", ID_Surt_Art);
                cmd.Parameters.AddWithValue("@InvcNbr", invc.Trim());
                cmd.Parameters.AddWithValue("@Localizacion", loc.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@SKU", sku.Trim());
                cmd.Parameters.AddWithValue("@Numcaja", caja);               
               cmd.Parameters.AddWithValue("@CodigoBarras", DBNull.Value);               
                //cantidad que se va agregar
                cmd.Parameters.AddWithValue("@Cantidad", cant);
                cmd.Parameters.Add("@tot_surt", SqlDbType.Decimal);
                cmd.Parameters["@tot_surt"].Direction = ParameterDirection.Output;
                //cmd.Parameters["@tot_surt"].Value = 0;              

                cmd.Parameters.AddWithValue("@Usuario", Global.usuario);
                if (Global.cn.State == ConnectionState.Closed)
                {
                    Global.cn.Open();
                }

                cmd.ExecuteNonQuery();

                if (!string.IsNullOrEmpty(cmd.Parameters["@tot_surt"].Value.ToString()))
                {
                    //obtenemos el total pendiente de surtir del articulo
                    tot_surtir = cantsol - Convert.ToDecimal(cmd.Parameters["@tot_surt"].Value.ToString());
                    tot_cant_surtida = tot_cant_surtida + Convert.ToDecimal(cmd.Parameters["@tot_surt"].Value.ToString());
                    lbl_surtir_loc.Text = tot_surtir.ToString();
                    if (tot_surtir <= 0)
                    {                        
                        //si solo existe una partida de la clave
                        //if (tot_partidas == 1)
                        //{
                            if (Global.tot_partidas_localizacion_PS(Global.invcnbr, localizacion) > 0)
                            {
                                if (ObtenerArticuloPorSurtirLocalizacion())
                                {
                                    return true;
                                }
                                else
                                { 
                                  Global.MostrarAlertaArticuloSurtido(invtid, tot_cant_surtida.ToString(), cantsol.ToString() , lblcaja.Text.Trim());
                                  this.Close();                               
                                }
                            }
                            else
                            {
                                Global.MostrarAlertaArticuloSurtido(invtid, tot_cant_surtida.ToString(), cantsol.ToString() , lblcaja.Text.Trim());
                                this.Close();
                            }

                        //}
                        //else if (tot_partidas > 1)
                        //{
                        //    this.Close();
                        //    return true;
                            
                            //verificar si existen partidas pendientes de surtir de la misma clava
                            //if (Global.Obtener_TotPartidasPorSurtirClaveLocalizacion(Global.invcnbr, localizacion, invtid) > 0)
                            //{
                            //    //obtener la siguiente partida para surtir
                            //    if (ObtenerSiguientePartidaPorSurtirClaveLocalizacion())
                            //    {
                            //        return true;
                            //    }
                            //    else
                            //    {
                            //        Global.MostrarAlertaArticuloSurtido(invtid,
                            //            CantSolLoc.ToString()    ,
                            //            CantSurtLoc.ToString()  ,
                            //            lblcaja.Text.Trim()
                            //            );
                            //        this.Close();
                            //    }
                            //}
                            //else
                            //{
                            //    //verificar si existen partidas por surtir de otra clave en la localizacion
                            //    Global.MostrarAlertaArticuloSurtido(invtid,
                            //           CantSolLoc.ToString(),
                            //           CantSurtLoc.ToString(),
                            //           lblcaja.Text.Trim()
                            //           );

                            //    if (Global.tot_partidas_localizacion_PS(Global.invcnbr, localizacion) > 0)
                            //    {                                    
                            //        if (ObtenerArticuloPorSurtirLocalizacion())
                            //        {
                            //            return true;
                            //        }
                            //        else
                            //        {
                            //            this.Close(); 
                            //        }
                            //    }
                            //    else
                            //    {
                            //        this.Close(); 
                            //    }
                            
                            //}

                        //} //else if (tot_partidas > 1)
                                                
                        //frm_Alerta f = new frm_Alerta();
                        //frm_Alerta.colorfondo = Color.Lime;
                        //f.timer2.Enabled = true;
                        //f.lbl_msj.ForeColor = Color.Black;
                        //f.lbl_msj.Text = "ARTICULO COMPLETADO:  " + sku.Trim();
                        //f.lbl_surtido.Text = "SURTIDO:" + tot_cant_surtida.ToString() + "/" + tot_cantsol.ToString().Trim();
                        //f.lbl_msj_caja.Text = "DEPOSITAR EN CAJA " + lblcaja.Text.Trim();
                        //if (Global.picking == 1)
                        //{
                        //    f.caja = lblcaja.Text.Trim();
                        //    f.lbl_msj_caja.Visible = true;
                        //    f.btn_ok.Enabled = false;
                        //    f.txt_caja.Visible = true;
                        //    f.timer2.Enabled = true;
                        //    f.txt_caja.Focus();
                        //}
                        //else
                        //{
                        //    f.caja = lblcaja.Text.Trim();
                        //    f.lbl_msj_caja.Visible = false;
                        //    f.btn_ok.Enabled = true;
                        //    f.txt_caja.Visible = false;
                        //    f.timer2.Enabled = false;
                        //}
                        //f.ShowDialog();
                        //f.Dispose();
                        
                        //MessageBox.Show("Articulo Completado...", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        //this.Close();
                    }
                    //else
                    //{
                    //    txt_cve_art.Focus(); 
                    //}
                }
                else
                {
                    //pend_surt_art = 0;
                    //tot_surtido_articlo = 0;
                    //pickstatus = false;
                }

                return true;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar articulo.." + ex.Message.ToString());
                return false;
            }

        
        }


        bool agregar_articulo(string invc, string loc, string sku, string codigo, string cant, string caja)
           {
            //@ID_Surt_Art NUMERIC(9),
            //@InvcNbr VARCHAR(20), --numero de factura
            //@Localizacion VARCHAR(50), --localizacion de la cual se van agregar los articulos
            //@SKU VARCHAR(50), ---codigo del articulo que se va agregar
            //@CodigoBarras VARCHAR(50), --el codigo de barras
            //@Cantidad NUMERIC(9,2), -- cantidad que se va agregar
            //@tot_surt numeric(9,2) OUTPUT, --cantidad total surtida del articulo
            //@Numcaja INT,-- numero de caja 
            //@Usuario VARCHAR(50)
            SqlCommand cmd = new SqlCommand();
            try
            {
                //Cursor.Current = Cursors.WaitCursor; 
                cmd.Connection = Global.cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ADN_agregar_art_lista_surt";
                cmd.Parameters.AddWithValue("@ID_Surt_Art", ID_Surt_Art);
                cmd.Parameters.AddWithValue("@InvcNbr", invc.Trim());
                cmd.Parameters.AddWithValue("@Localizacion", loc.Trim().ToUpper());
                cmd.Parameters.AddWithValue("@SKU", sku.Trim());
                cmd.Parameters.AddWithValue("@Numcaja", caja);
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
                cmd.Parameters.Add("@tot_surt", SqlDbType.Decimal);
                cmd.Parameters["@tot_surt"].Direction = ParameterDirection.Output;
                //cmd.Parameters["@tot_surt"].Value = 0;              
                             
                cmd.Parameters.AddWithValue("@Usuario", Global.usuario);
                if (Global.cn.State == ConnectionState.Closed)
                {
                    Global.cn.Open();
                }

                cmd.ExecuteNonQuery();

                if (!string.IsNullOrEmpty(cmd.Parameters["@tot_surt"].Value.ToString()))
                {                   
                    //lbl_surtir_loc.Text = tot_surtir.ToString();
                    tot_surtir = cantsol - Convert.ToDecimal(cmd.Parameters["@tot_surt"].Value.ToString());
                    //if (tot_partidas == 1)
                    //{                        
                        tot_cant_surtida = Convert.ToDecimal(cmd.Parameters["@tot_surt"].Value.ToString());
                        lblsurtido.Text = tot_cant_surtida.ToString();
                        lbl_tot_por_surtir.Text = tot_surtir.ToString();  
                    if (tot_surtir <= 0)
                    {                        
                        //si solo existe una partida de la clave
                        if (tot_partidas == 1)
                        {
                            if (Global.tot_partidas_localizacion_PS(Global.invcnbr, localizacion) > 0)
                            {
                                if (ObtenerArticuloPorSurtirLocalizacion())
                                {
                                    return true;
                                }
                                else
                                { 
                                  Global.MostrarAlertaArticuloSurtido(invtid, tot_cant_surtida.ToString(), cantsol.ToString() , lblcaja.Text.Trim());
                                  this.Close();
                                  return true;
                                }
                            }
                            else
                            {
                                Global.MostrarAlertaArticuloSurtido(invtid, tot_cant_surtida.ToString(), cantsol.ToString() , lblcaja.Text.Trim());
                                this.Close();
                                return true;
                            }
                        }
                        else if (tot_partidas > 1)
                        {
                                        
                            //verificar si existen partidas pendientes de surtir de la misma clava
                                if (Global.Obtener_TotPartidasPorSurtirClaveLocalizacion(Global.invcnbr, localizacion, invtid) > 0)
                                {
                                    //obtener la siguiente partida para surtir
                                    if (ObtenerSiguientePartidaPorSurtirClaveLocalizacion())
                                    {
                                        frm_AvisoPartidaDoble f = new frm_AvisoPartidaDoble();
                                        f.ShowDialog(); 
                                        return true;
                                    }
                                    else
                                    {
                                        Global.MostrarAlertaArticuloSurtido(invtid,
                                            CantSolLoc.ToString()    ,
                                            CantSurtLoc.ToString()  ,
                                            lblcaja.Text.Trim()
                                            );
                                        this.Close();
                                        return true;
                                    }
                                }
                                else
                                {
                                    //verificar si existen partidas por surtir de otra clave en la localizacion
                                    Global.MostrarAlertaArticuloSurtido(invtid,
                                           CantSolLoc.ToString(),
                                           CantSurtLoc.ToString(),
                                           lblcaja.Text.Trim()
                                           );

                                    if (Global.tot_partidas_localizacion_PS(Global.invcnbr, localizacion) > 0)
                                    {                                    
                                        if (ObtenerArticuloPorSurtirLocalizacion())
                                        {
                                            return true;
                                        }
                                        else
                                        {
                                            this.Close();
                                            return true;
                                        }
                                    }
                                    else
                                    {
                                        this.Close();
                                        return true;
                                    }

                                }                        
                            }

                        }
                    }
                //} //
                return true;
            }
            catch(Exception ex)
            {
             MessageBox.Show("Error al agregar articulo.." + ex.Message.ToString()  );
             return false;
            }
        }

                    //if (tot_partidas == 1)
                    //{
                    //    //obtenemos el total pendiente de surtir de la partida actual
                    //    tot_surtir = cantsol - Convert.ToDecimal(cmd.Parameters["@tot_surt"].Value.ToString());
                    //    lbl_tot_por_surtir.Text = tot_surtir.ToString();  
                    //    //muestra la cantidad surtida actual
                    //    lblsurtido.Text = cmd.Parameters["@tot_surt"].Value.ToString();
                    //    if (tot_surtir <= 0)
                    //    {
                    //        tot_cant_surtida = tot_cant_surtida + cantsol;
                    //        tot_cantsol = tot_cantsol + cantsol;
                    //        if (Global.tot_partidas_localizacion_PS(Global.invcnbr, localizacion) > 0)
                    //        {
                    //            //if (obtener_articulo_por_surtir_localizacion())
                    //            //{
                    //            //    return true; ;
                    //            //}
                    //            if (ObtenerArticuloPorSurtirLocalizacion())
                    //            {
                    //                return true;
                    //            }

                    //        }

                    //        frm_Alerta f = new frm_Alerta();
                    //        frm_Alerta.colorfondo = Color.Lime;
                    //        f.timer2.Enabled = true;
                    //        f.lbl_msj.ForeColor = Color.Black;
                    //        f.lbl_msj.Text = "ARTICULO COMPLETADO:  " + sku.Trim();
                    //        f.lbl_surtido.Text = "SURTIDO:" + tot_cant_surtida.ToString() + "/" + tot_cantsol.ToString().Trim();
                    //        f.lbl_msj_caja.Text = "DEPOSITAR EN CAJA " + lblcaja.Text.Trim();
                    //        if (Global.picking == 1)
                    //        {
                    //            f.caja = lblcaja.Text.Trim();
                    //            f.lbl_msj_caja.Visible = true;
                    //            f.btn_ok.Enabled = false;
                    //            f.txt_caja.Visible = true;
                    //            f.timer2.Enabled = true;
                    //            f.txt_caja.Focus();
                    //        }
                    //        else
                    //        {
                    //            f.caja = lblcaja.Text.Trim();
                    //            f.lbl_msj_caja.Visible = false;
                    //            f.btn_ok.Enabled = true;
                    //            f.txt_caja.Visible = false;
                    //            f.timer2.Enabled = false;
                    //        }
                    //        f.ShowDialog();
                    //        f.Dispose();

                    //        this.Close();
                    //        //MessageBox.Show("Articulo Completado...ENTER Para Continuar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    //    }
                    
                    //} //if (tot_partidas == 1)
                    //else if (tot_partidas > 1)
                    //{
                    //    //obtenemos el total pendiente de surtir de la partida actual
                    //    tot_surtir = cantsol - Convert.ToDecimal(cmd.Parameters["@tot_surt"].Value.ToString());
                    //    lbl_tot_por_surtir.Text = tot_surtir.ToString();    
                    //    //muestra el total surtido en la localizacion
                    //    CantSurtLoc = Global.ObtenerCantidadTotalSurtidaLoc(Global.invcnbr, invtid, lbl_loc_surt.Text.Trim());
                    //    //Cantidad por surtir en la localizaion
                    //    CantPorSurtirLoc = CantSolLoc - CantSurtLoc;  
                    //    //Total surtido en la localizacion
                    //    lblsurtido.Text = CantSurtLoc.ToString();  
                    //    //total por surtir
                    //    lbl_surtir_loc.Text = CantPorSurtirLoc.ToString() ;

                    //    //verificar el total por surtir de la partida actual
                    //    if (tot_surtir <= 0)
                    //    {
                    //        //si el total menor o igual a cero, obtener una nueva partida
                    //        tot_cant_surtida = tot_cant_surtida + cantsol;
                    //        tot_cantsol = tot_cantsol + cantsol;
                    //        if (Global.tot_partidas_localizacion_PS(Global.invcnbr, localizacion) > 0)
                    //        {
                    //            if (ObtenerArticuloPorSurtirLocalizacion())
                    //            {
                    //                return true;
                    //            }

                    //        }

                    //        frm_Alerta f = new frm_Alerta();
                    //        frm_Alerta.colorfondo = Color.Lime;
                    //        f.timer2.Enabled = true;
                    //        f.lbl_msj.ForeColor = Color.Black;
                    //        f.lbl_msj.Text = "ARTICULO COMPLETADO:  " + sku.Trim();
                    //        f.lbl_surtido.Text = "SURTIDO:" + tot_cant_surtida.ToString() + "/" + tot_cantsol.ToString().Trim();
                    //        f.lbl_msj_caja.Text = "DEPOSITAR EN CAJA " + lblcaja.Text.Trim();
                    //        if (Global.picking == 1)
                    //        {
                    //            f.caja = lblcaja.Text.Trim();
                    //            f.lbl_msj_caja.Visible = true;
                    //            f.btn_ok.Enabled = false;
                    //            f.txt_caja.Visible = true;
                    //            f.timer2.Enabled = true;
                    //            f.txt_caja.Focus();
                    //        }
                    //        else
                    //        {
                    //            f.caja = lblcaja.Text.Trim();
                    //            f.lbl_msj_caja.Visible = false;
                    //            f.btn_ok.Enabled = true;
                    //            f.txt_caja.Visible = false;
                    //            f.timer2.Enabled = false;
                    //        }
                    //        f.ShowDialog();
                    //        f.Dispose();

                            //this.Close();
                            //MessageBox.Show("Articulo Completado...ENTER Para Continuar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        //}
                           


                      
                    //} //if (tot_partidas > 1)

                //}
              

                //return true;


            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error al agregar articulo.." + ex.Message.ToString());
            //    return false;
            //}

        //}
        //}

        bool validar_cve_articulo()
        {
            try
            {
                return true;
            }
            catch
            {
                return false;
            }
        
        }
        
        bool validar_codigo(string articulo, string codigo)
        {
            //ADN_datos_codigobar
            //@Articulo VARCHAR(15),
            //@Codigo VARCHAR(50)             
            //SELECT  Articulo, Codigo, Multiplo, Nivel
            //FROM   Herramientas.dbo.rqMultiplos
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_datos_codigobar";
            cmd.Connection = Global.cn;
            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            DataRow dr;
            decimal cant;
            decimal multiplo = 0;
            decimal cant_codigo = 1;
            decimal total = 0; //cantidad total del articulo que se va agregar
            cant = 0;
            try
            {
                cmd.Parameters.AddWithValue("@Articulo", articulo.Trim());
                cmd.Parameters.AddWithValue("@Codigo", codigo.Trim());
                da.SelectCommand = cmd;
                da.Fill(dt);
                if (dt.Tables[0].Rows.Count != 0)
                {
                    dr = dt.Tables[0].Rows[0];
                    if (!string.IsNullOrEmpty(dr["Articulo"].ToString()))
                    {
                        if (dr["Articulo"].ToString().Trim() != invtid.Trim())
                        {
                            //System.Media.SystemSounds.Exclamation.Play();
                            //System.Media.SystemSounds.Exclamation.Play();
                            frm_Alerta f = new frm_Alerta();
                            frm_Alerta.colorfondo = Color.Yellow;
                            f.lbl_msj.Text = "Codigo de Articulo No Valido " + codigo ;
                            f.ShowDialog();
                            f.Dispose();
                            //MessageBox.Show("Codigo de Articulo No Valido:" + codigo  + " Favor De Verificar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                            //txt_loc.Text = "";
                            txt_codigo.Text = "";
                            txt_codigo.Focus();
                            multiplo = 0;
                            return false;
                        }
                    }
                    else
                    {
                        //System.Media.SystemSounds.Exclamation.Play();
                        //System.Media.SystemSounds.Exclamation.Play();
                        //MessageBox.Show("Codigo de articulo no valido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        //txt_loc.Text = "";
                        frm_Alerta f = new frm_Alerta();
                        frm_Alerta.colorfondo = Color.Yellow;
                        f.lbl_msj.Text = "Codigo de Articulo No Valido";
                        f.ShowDialog();
                        f.Dispose();
                        txt_codigo.Text = "";
                        txt_codigo.Focus();
                        multiplo = 0;
                        return false;
                    }

                    if (!string.IsNullOrEmpty(dr["Multiplo"].ToString()))
                    {
                        cant = Convert.ToDecimal(dr["Multiplo"].ToString());
                        //if (txt_cant_codigo.Text != "")
                        //{
                        //    cant_codigo = Convert.ToDecimal(txt_cant_codigo.Text);
                        //}
                        //else
                        //{
                        //    cant_codigo = 1; 
                        //}
                        multiplo = cant;
                        //if (cant_codigo > 0)
                        //{
                            //obtener el total de articulos 
                            total = multiplo ;
                            //if (tot_partidas == 1)
                            //{
                                if (multiplo > tot_surtir)
                                {
                                    //System.Media.SystemSounds.Exclamation.Play();
                                    //System.Media.SystemSounds.Exclamation.Play();
                                    //MessageBox.Show("La Cantidad Es Mayor Al Pendiente De Surtir");
                                    frm_Alerta f = new frm_Alerta();
                                    frm_Alerta.colorfondo = Color.Yellow;
                                    f.lbl_msj.Text = "La Cantidad Es Mayor Al Pendiente De Surtir";
                                    f.ShowDialog();
                                    f.Dispose();
                                    txt_codigo.Text = "";
                                    txt_codigo.Focus();
                                    return false;
                                }
                    }
                    else
                    {
                        //System.Media.SystemSounds.Exclamation.Play();
                        //System.Media.SystemSounds.Exclamation.Play();
                        //MessageBox.Show("La Cantidad No Es Valida");
                        frm_Alerta f = new frm_Alerta();
                        frm_Alerta.colorfondo = Color.Yellow;
                        f.lbl_msj.Text = "La Cantidad No Es Valida";
                        f.ShowDialog();
                        f.Dispose();
                        //txt_loc.Text = "";
                        txt_codigo.Text = "";
                        txt_codigo.Focus();
                        multiplo = 0;
                        return false;
                    }                                      
                        if (agregar_articulo(invcnbr, lbl_loc_surt.Text.Trim(), dr["Articulo"].ToString().Trim(), dr["Codigo"].ToString().Trim().ToUpper(), total.ToString(), lblcaja.Text.Trim()))
                        {
                            System.Media.SystemSounds.Asterisk.Play();                            
                            return true;
                        }
                        else
                        {
                            //System.Media.SystemSounds.Exclamation.Play();
                            //System.Media.SystemSounds.Exclamation.Play();
                            //MessageBox.Show("Error al agregar articulo");
                            frm_Alerta f = new frm_Alerta();
                            frm_Alerta.colorfondo = Color.Yellow;
                            f.lbl_msj.Text = "Error al agregar articulo";
                            f.ShowDialog();
                            f.Dispose();

                            return false;
                        }


                }
                else
                {
                    //MessageBox.Show("Codigo De Articulo No Encontrado");
                    //System.Media.SystemSounds.Exclamation.Play();
                    //MessageBox.Show("Codigo de Articulo No Valido:" + codigo + " Favor De Verificar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    ////txt_loc.Text = "";
                    frm_Alerta f = new frm_Alerta();
                    frm_Alerta.colorfondo = Color.Yellow;
                    f.lbl_msj.Text = "Codigo de Articulo No Valido:" + codigo;
                    f.ShowDialog();
                    f.Dispose();
                    
                    txt_codigo.Text = "";
                    txt_codigo.Focus();
                    multiplo = 0;
                    return false;

                }

            }
            catch (Exception ex)
            {
                //System.Media.SystemSounds.Exclamation.Play();
                //MessageBox.Show("Error al agregar articulo.." + ex.Message.ToString());
                frm_Alerta f = new frm_Alerta();
                frm_Alerta.colorfondo = Color.Yellow;
                f.lbl_msj.Text = "Error al agregar articulo.." + ex.Message.ToString();
                f.ShowDialog();
                f.Dispose();

                multiplo = 0;
                return false;
            }

        }

        /// <summary>
        /// obtener la partida para surtir
        /// </summary>
        /// <returns></returns>
        bool obtener_datos_articulo()
        { 
            
            //StringBuilder cad = new StringBuilder();
            //cad.Append("SELECT ID_Surt_Art, InvcNbr, InvtId, Descr, Unidad, Localizacion, CantSol, CantSurtida, Usuario, Completo, Nodisp, Pickstatus, IdZona, IdArea, Status_surt");
            //cad.AppendLine(" FROM   ADN_Lista_Surtimiento_Maestro");
            //cad.AppendLine(" WHERE ID_Surt_Art=@ID_Surt_Art");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            DataRow dr;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Obtener_Datos_Articulo_Surtimiento";
            cmd.Connection = Global.cn;
            cmd.Parameters.AddWithValue("@ID_Surt_Art",ID_Surt_Art);            
           
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
                                    status = "E";
                                    this.Close();
                                }
                                else
                                {
                                    status = dr["Status_surt"].ToString().Trim();
                                }
                            }

                            if (!string.IsNullOrEmpty(dr["Descr"].ToString()) && !string.IsNullOrEmpty(dr["InvtId"].ToString()))
                            {
                                txt_desc.Text =dr["InvtId"].ToString().Trim()+": "+ dr["Descr"].ToString();
                            }
                            if (!string.IsNullOrEmpty(dr["Localizacion"].ToString()))
                            {
                                lbl_loc_surt.Text   = dr["Localizacion"].ToString();
                            }
                            if (!string.IsNullOrEmpty(dr["Unidad"].ToString()))
                            {
                                lbl_unidad.Text = dr["Unidad"].ToString();
                            }
                            
                            
                            if (!string.IsNullOrEmpty(dr["CantSol"].ToString()))
                            {
                                cantsol = Convert.ToDecimal(dr["CantSol"].ToString());
                                lbl_surtir_loc.Text = cantsol.ToString().Trim(); 
                            }
                            else
                            {
                                cantsol = 0;
                                lbl_surtir_loc.Text = "0";
                                //MessageBox.Show("Articulo Completado..", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                                
                                this.Close();
                            }
                            //obtener el total de partidas solicitdaas de la clave en la localizacion
                            tot_partidas = mod.ObtenerTotalPartidasClaveLocalizacion(Global.invcnbr, invtid, lbl_loc_surt.Text.Trim());
                            lblTotPartidas.Text = tot_partidas.ToString();

                            if (!string.IsNullOrEmpty(dr["CantSurtida"].ToString()))
                            {
                                tot_surtir = (cantsol - Convert.ToDecimal(dr["CantSurtida"].ToString()));
                                tot_cant_surtida = decimal.Parse(dr["CantSurtida"].ToString());
                                lblsurtido.Text = dr["CantSurtida"].ToString().Trim();
                                if (tot_surtir > 0)
                                {
                                    lbl_tot_por_surtir.Text = tot_surtir.ToString().Trim();
                                }
                                else
                                {
                                    MessageBox.Show("Articulo Completado..","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Exclamation,MessageBoxDefaultButton.Button1   );  
                                    //lbl_surtir_loc.Text = "0";
                                    //tab_captura.Enabled = false;  
                                    this.Close();
                                }
                            }
                            else
                            {
                                lblsurtido.Text = "0";
                                tot_cant_surtida = 0;
                                    
                                tot_surtir = Convert.ToDecimal(dr["CantSol"].ToString());
                                cantsol = Convert.ToDecimal(dr["CantSol"].ToString());
                                lbl_tot_por_surtir.Text = tot_surtir.ToString().Trim();
                                tot_cant_surtida = 0;
                               
                                
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


        private void tab_captura_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tab_captura.SelectedIndex == 0)
            {
                txt_codigo.Focus(); 
            }
            else if (tab_captura.SelectedIndex == 1)
            {
                txt_cve_art.Focus();
  
            }
            else if (tab_captura.SelectedIndex == 2)
            {
                frm_sel_caja f = new frm_sel_caja();
                f.invcnbr = invcnbr;
                f.ShowDialog();
                if (f.caja != "")
                {
                    lblcaja.Text = f.caja;
   
                }
                tab_captura.SelectedIndex = 0;
                f.Dispose();
            }

        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            string res = MessageBox.Show("Desea Salir ?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1).ToString();
            if (res == "Yes")
            {
                t1.Enabled = false;
                //timer_timeout.Enabled = false;           
                this.Close();
            }

        }

        private void txt_codigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txt_codigo.Text != "")
            {
               Cursor.Current = Cursors.WaitCursor;
               Global.fecha_ultima_actividad = Global.FechaHoraActual();
                if(txt_cant_codigo.Text !="" )
                {
                    if (!IsNumeric(txt_cant_codigo.Text))
                    {
                        System.Media.SystemSounds.Exclamation.Play();
                        MessageBox.Show("Cantidad No Valida..");  
                        txt_cant_codigo.Text = "";
                        txt_cant_codigo.Focus();
                            return;
                    }
                }

                    if (validar_codigo(invtid.Trim().ToUpper(), txt_codigo.Text.Trim().ToUpper() ))
                    {
                        Cursor.Current = Cursors.Default;
                        if (tot_surtir > 0)
                        {
                            if (tab_captura.SelectedIndex == 0)
                            {
                                txt_codigo.Text = "";
                                txt_cant_codigo.Text = "";
                                txt_codigo.Focus() ;
                            }
                            else if (tab_captura.SelectedIndex == 1)
                            {
                                txt_cve_art.Text = "";
                                txt_cant_art.Text = "";
                                txt_cve_art.Focus();
                            }

                        }
                        else
                        {
                            t1.Enabled = false; 
                            this.Close();

                        }

                    }
                    else
                    {
                        Cursor.Current = Cursors.Default;
                        txt_codigo.Text = "";
                        txt_cant_codigo.Text = "";
                        txt_codigo.Focus(); 
                        //txt_cant_codigo.Focus();

                    }
               

            }
            else
            {
                txt_codigo.Focus(); 
            }

        }

        private void txt_codigo_GotFocus(object sender, EventArgs e)
        {
            txt_codigo.BackColor = Color.Yellow;
  
        }

        private void txt_codigo_LostFocus(object sender, EventArgs e)
        {
            txt_codigo.BackColor = Color.White;  
        }

        private void txt_cant_codigo_GotFocus(object sender, EventArgs e)
        {
            txt_cant_codigo.BackColor = Color.Yellow;
            txt_cant_codigo.SelectAll(); 
        }

        private void txt_cant_codigo_LostFocus(object sender, EventArgs e)
        {
            txt_cant_codigo.BackColor = Color.White; 
        }

        private void txt_cve_art_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txt_cve_art.Text != "")
            {
                Global.fecha_ultima_actividad = Global.FechaHoraActual();
                if (txt_cve_art.Text.Trim().ToUpper() == invtid.Trim())
                {
                    txt_cant_art.Text = "";
                    txt_cant_art.Focus();
                }
                else
                {
                    System.Media.SystemSounds.Exclamation.Play();
                    MessageBox.Show("Clave De Articulo Incorrecta...");
                    txt_cve_art.Text = "";
                    txt_cve_art.Focus(); 
                 
                }

            }
            else
            {
                txt_cve_art.Focus(); 
            }
        }

        private void txt_cve_art_GotFocus(object sender, EventArgs e)
        {
            txt_cve_art.BackColor = Color.Yellow;  
        }

        private void txt_cve_art_LostFocus(object sender, EventArgs e)
        {
            txt_cve_art.BackColor = Color.White;
        }

        private void txt_cant_codigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                if (txt_cant_codigo.Text != "")
                {
                    
                    if (!IsNumeric(txt_cant_codigo.Text))
                    {
                        System.Media.SystemSounds.Exclamation.Play();
                        MessageBox.Show("Cantidad No Valida..");  
                        txt_cant_codigo.Text = "";
                        txt_cant_codigo.Focus();
                        return;
                    }

                            if (txt_codigo.Text != "")
                            {
                                                         
                                Cursor.Current = Cursors.WaitCursor;
                                if (validar_codigo(invtid.Trim().ToUpper(), txt_codigo.Text.Trim().ToUpper()))
                                {
                                    Cursor.Current = Cursors.Default;
                                    if (tot_surtir > 0)
                                    {
                                        if (tab_captura.SelectedIndex == 0)
                                        {
                                            txt_codigo.Text = "";
                                            txt_cant_codigo.Text = "";
                                            txt_codigo.Focus();
                                        }
                                        else if (tab_captura.SelectedIndex == 1)
                                        {
                                            txt_cve_art.Text = "";
                                            txt_cant_art.Text = "";
                                            txt_cve_art.Focus();
                                        }

                                    }
                                    else
                                    {
                                        tab_captura.Enabled = false;
                                        System.Media.SystemSounds.Exclamation.Play();
                                        MessageBox.Show("Surtimiento Terminado...", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                                        this.Close();

                                    }

                                }
                                else
                                {
                                    Cursor.Current = Cursors.Default;
                                    txt_codigo.Text = "";
                                    txt_cant_codigo.Text = "";
                                    txt_codigo.Focus();

                                }
                            }
                            else
                            {
                                txt_codigo.Focus(); 
                            }

            }
            else
            {
                txt_codigo.Text = "";  
                txt_codigo.Focus(); 
                 
            }


          }
            
        }
       

        private void frm_surtir_articulo_Load(object sender, EventArgs e)
        {
            if (obtener_datos_articulo())
            {
                
            }
            txt_codigo.Text = "";
            txt_codigo.Focus();
        }

        private void txt_cant_art_GotFocus(object sender, EventArgs e)
        {
            txt_cant_art.BackColor = Color.Yellow;

  
        }

        private void txt_cant_art_LostFocus(object sender, EventArgs e)
        {
            txt_cant_art.BackColor = Color.White;  
        }

        private void txt_cant_art_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                if (txt_cant_art.Text != "")
                {
                    if (IsNumeric(txt_cant_art.Text.Trim()))
                    {
                        if (txt_cve_art.Text != "")
                        {
                            if (txt_cve_art.Text.Trim().ToUpper() != invtid)
                            {
                                System.Media.SystemSounds.Exclamation.Play();
                                MessageBox.Show("Clave De Articulo Incorrecta..", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                                txt_cve_art.Text = "";
                                txt_cve_art.Focus();
                                return;

                            }
                            obtener_datos_articulo();
                            if (Convert.ToDecimal(txt_cant_art.Text.Trim()) <= tot_surtir)
                            {
                                if (agregar_cve(invcnbr, lbl_loc_surt.Text.Trim(), invtid, txt_cant_art.Text.Trim(), lblcaja.Text.Trim()))
                                {
                                    System.Media.SystemSounds.Asterisk.Play();
                                    txt_cve_art.Text = "";
                                    txt_cant_art.Text = "";
                                    if (tot_surtir > 0)
                                    {
                                        txt_cve_art.Focus();

                                    }

                                }
                                else
                                {
                                    txt_cve_art.Text = "";
                                    txt_cant_art.Text = "";
                                    txt_cve_art.Focus();
                                }

                            }
                        }
                        else
                        {
                            txt_cve_art.Focus();
                        }

                    }
                    else
                    {
                        System.Media.SystemSounds.Exclamation.Play();
                        MessageBox.Show("Cantidad No Valida...");
                        txt_cant_art.Text = "";
                        txt_cant_art.Focus();

                    }
                }
                else
                {
                    txt_cant_art.Focus();
                }
            }
            else
            {
                //MessageBox.Show("Introduzca la clave de el articulo");  
                System.Media.SystemSounds.Hand.Play();
                txt_cant_art.Focus(); 
            }

        }

        private void frm_surtir_articulo_KeyDown(object sender, KeyEventArgs e)
        {
            switch ( e.KeyCode )
            {
                case Keys.F1:
                    if (tab_captura.Enabled == true)
                    {
                        tab_captura.SelectedIndex = 0; 
                    }
                    break;
                case Keys.F2:
                    if (tab_captura.Enabled == true)
                    {
                        tab_captura.SelectedIndex = 1;
                    }
                    break;
                case Keys.F3:

                    if (tab_captura.Enabled == true)
                    {
                        tab_captura.SelectedIndex = 2;
                    }
                    break;

                default:
                    break;
            }
        }

        private void btn_excepcion_Click(object sender, EventArgs e)
        {
            //timer_timeout.Enabled = false;  
            t1.Enabled = false;
          
            frm_excepciones f = new frm_excepciones();
            f.invcnbr = invcnbr;
            f.invtid = txt_cve_art.Text.Trim();  
            f.ShowDialog();
            if (f.OK)
            {
                excepcion = true; 
                status = "E"; 
                this.Close();
            }
            else
            {
                t1.Enabled = true;
                //timer_timeout.Enabled = true;
                obtener_datos_articulo();
            }

        }

        private void frm_surtir_articulo_Closing(object sender, CancelEventArgs e)
        {
            try
            {
                t1.Enabled = false;
                //timer_timeout.Enabled = false;
                //Borrar la variables de la memoria
                //if (barcodeReader != null)
                //{
                //    // Remove read notification handler.                   
                //    barcodeReader.ReadNotify -= barcodeReader_Read;
                //    barcodeReader.Actions.Flush();
                //    barcodeReader.Actions.Disable();
                //    barcodeReader.Dispose();
                //    barcodeReader = null;
                //}
                //// If we have a reader data. 
                //if (barcodeReaderData != null)
                //{
                //    // Free it up. 
                //    barcodeReaderData.Dispose();
                //    // Indicate we no longer have one. 
                //    barcodeReaderData = null;
                //}
            }
            catch
            { 
              
            }


        }

        private void t1_Tick(object sender, EventArgs e)
        {
            if (Global.invcnbr != "")
            {
                t1.Enabled = false;
                //timer1.Enabled = false;
                Global.verificar_satus_factura();
                if (!string.IsNullOrEmpty(Global.status_factura))
                {
                    if (Global.status_factura.Trim() != "SO")
                    {
                        System.Media.SystemSounds.Exclamation.Play();

                        MessageBox.Show("****FACTURA NO ESTA EN SURTIMIENTO, CONSULTAR CON SUPERVISOR****" + "Status: " + Global.status_factura.Trim(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                        this.Close();
                    }
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
                this.Close(); 
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void timer_timeout_Tick(object sender, EventArgs e)
        {
            //if (Global.TimeOutPicking())
            //{
            //    //timer_timeout.Enabled = false;
            //    frm_time_out f = new frm_time_out();
            //    f.ShowDialog();
            //    f.Dispose();
            //    if (Global.timeout)
            //    {
            //        //Global.finalizar_partida(ID_Surt_Art);
            //        //this.Close();
            //        System.Media.SystemSounds.Exclamation.Play();     
            //    }
            //    else
            //    {
            //        //timer_timeout.Enabled = true;
            //    }
            //}
            //else
            //{
            //    //timer_timeout.Enabled = true;
            //}


        }

        private void btn_desbloq_Click(object sender, EventArgs e)
        {
            return;
            //timer_timeout.Enabled = false;
            //t1.Enabled = false;
            //frm_supervisor f1 = new frm_supervisor();
            //f1.ShowDialog();
            //if (f1.ok)
            //{
            //    if (f1.supervisor != "")
            //    {
            //        desbloq = true;
            //        //Borrar la variables de la memoria
            //        if (barcodeReader != null)
            //        {
            //            // Remove read notification handler.                   
            //            barcodeReader.ReadNotify -= barcodeReader_Read;
            //            barcodeReader.Actions.Flush();
            //            barcodeReader.Actions.Disable();
            //            barcodeReader.Dispose();
            //            barcodeReader = null;
            //        }
            //        // If we have a reader data. 
            //        if (barcodeReaderData != null)
            //        {
            //            // Free it up. 
            //            barcodeReaderData.Dispose();
            //            // Indicate we no longer have one. 
            //            barcodeReaderData = null;
            //        }


            //        txt_codigo.Enabled = true;
            //        txt_codigo.ReadOnly = false;  
            //        txt_cant_codigo.Enabled = true;
            //        txt_cant_codigo.ReadOnly = false;  
            //        txt_cve_art.Enabled = true;
            //        txt_cve_art.ReadOnly = false;
            //        txt_cant_art.ReadOnly = false;  
            //        txt_cant_art.Enabled = true;
            //        tab_captura.Enabled = true;
            //        txt_codigo.Focus();
            //        btn_desbloq.Enabled = false;
            //        panel_surtimiento.Visible = false;
            //        timer_timeout.Enabled = true;
            //        t1.Enabled = true;

            //    }
            //}
            //else
            //{
            //    timer_timeout.Enabled = true;
            //    t1.Enabled = true;
            //}
            //f1.Dispose();
        }

        private void txt_desc_GotFocus(object sender, EventArgs e)
        {
            txt_codigo.Focus();
        }

      
       

    }
}