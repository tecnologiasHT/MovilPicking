using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;

namespace Picking
{
    public partial class frm_captura_articulos : Form
    {
        public frm_captura_articulos()
        {
            InitializeComponent();
        }
        SqlConnection cn = new SqlConnection(Properties.Resources.connectionstring);

        public bool IsNumeric(object Expression)
        {
            
            decimal num;            
            try
            {
                num=decimal.Parse(Convert.ToString(Expression));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
           
        }
        bool terminar_articulo()
        { 
            //Funcion utilizada para terminar el surtimiento del articulo
            //puede usarse en caso de que el articulo no exista o este incompleto
          //[dbo].[ADN_terminar_surtimiento_art]
            //@InvcNbr VARCHAR(20),
            //@InvtId  VARCHAR(20)
             SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_terminar_surtimiento_art";
            cmd.Parameters.AddWithValue("@InvcNbr",lbl_factura.Text.Trim());
            cmd.Parameters.AddWithValue("@InvtId",txt_cve.Text.Trim()   );
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
                return false;
            }

        }
        void limpiar_datos()
        {
            //lbl_clave.Text = "";
            //lbl_desc.Text = "";
            txt_cve.Text = "";
            txt_desc.Text = "";
            lbl_tot_surtido.Text = "";
            //lbl_loc_surtir.Text = "";
            //lbl_pendiente.Text = "0";
            lbl_cant_sol.Text = "0";
            //lbl_cant_surtida.Text = "0";
            lbl_unidad.Text = "";
 
        }
        bool finalizar()
        { 
        //     ADN_terminar_surtimiento
        //@InvcNbr VARCHAR(20),
        //@Usuario VARCHAR(50)
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_terminar_surtimiento";
            cmd.Parameters.AddWithValue("@InvcNbr",lbl_factura.Text.Trim());
            cmd.Parameters.AddWithValue("@Usuario", "ADMIN");
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
                MessageBox.Show("Error al actualizar status.." + ex.Message.ToString());  
                return false;
            }

        }

        bool pendiente()
        {
            //ADN_obtenert_tot_partidas_surt
            //@InvcNbr varchar(20)
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn; 
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_obtenert_tot_partidas_surt";
            cmd.Parameters.AddWithValue("@InvcNbr", lbl_factura.Text.Trim());
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
            catch (Exception ex)
            {

                return false;
            }
        
        }

        void obtener_totales(string InvcNbr, string InvtId)
        {
            //ADN_totales_articulo
            //@InvcNbr varchar(20),
            //@InvtId  VARCHAR(20)

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_datos_codigobar";
            cmd.Connection = cn;
            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            DataRow dr;
            //decimal cant;
            //cant = 0;
            try
            {
                cmd.Parameters.AddWithValue("@InvcNbr", InvcNbr);
                cmd.Parameters.AddWithValue("@InvtId", InvtId);
                da.SelectCommand = cmd;
                da.Fill(dt);
                if (dt.Tables[0].Rows.Count != 0)
                {
                    dr = dt.Tables[0].Rows[0];
                    //total a surtir
                    if (!string.IsNullOrEmpty(dr[0].ToString()))
                    {
                        lbl_cant_sol.Text = dr[0].ToString().Trim();
                    }
                    //total surtido
                    //if (!string.IsNullOrEmpty(dr[1].ToString()))
                    //{
                    //    lbl_cant_surtida.Text = dr[1].ToString().Trim();
                    //}

                    //pendiente de surtir
                    //if (!string.IsNullOrEmpty(dr[2].ToString()))
                    //{
                    //    lbl_pendiente.Text = dr[2].ToString().Trim();
                    //}


                }
                da.Dispose();
                dt.Dispose();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener totales");
            }


        }

        //bool validar_codigo(string articulo, string codigo)
        //{
        //    //ADN_datos_codigobar
        //    //@Articulo VARCHAR(15),
        //    //@Codigo VARCHAR(50)             
        //    //SELECT  Articulo, Codigo, Multiplo, Nivel
        //    //FROM   Herramientas.dbo.rqMultiplos

        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = "ADN_datos_codigobar";
        //    cmd.Connection = cn;
        //    DataSet dt = new DataSet();
        //    SqlDataAdapter da = new SqlDataAdapter();
        //    DataRow dr;
        //    decimal cant;
        //    cant = 0;
        //    try
        //    {
        //        cmd.Parameters.AddWithValue("@Articulo", articulo);
        //        cmd.Parameters.AddWithValue("@Codigo", codigo);
        //        da.SelectCommand = cmd;
        //        da.Fill(dt);
        //        if (dt.Tables[0].Rows.Count != 0)
        //        {
        //            dr = dt.Tables[0].Rows[0];

        //            if (!string.IsNullOrEmpty(dr["Articulo"].ToString()))
        //            {
        //                if (dr["Articulo"].ToString().Trim() != lbl_clave.Text.Trim())
        //                {
        //                    MessageBox.Show("Codigo de articulo no valido");
        //                    //txt_loc.Text = "";
        //                    //txt_codigo.Text = "";
        //                    return false;
        //                }

        //            }
        //            else
        //            {
        //                MessageBox.Show("Codigo de articulo no valido");
        //                //txt_loc.Text = "";
        //                //txt_codigo.Text = "";
        //                return false;

        //            }

        //            if (!string.IsNullOrEmpty(dr["Multiplo"].ToString()))
        //            {
        //                cant = Convert.ToDecimal(dr["Multiplo"].ToString());
        //                if (cant > Convert.ToDecimal(lbl_pendiente.Text.Trim()))
        //                {
        //                    MessageBox.Show("La cantidad es mayor al pendiente de surtir");
        //                    //txt_loc.Text = "";
        //                    //txt_codigo.Text = "";
        //                    return false;
        //                }
        //            }
        //            else
        //            {
        //                MessageBox.Show("La cantidad no es valida");
        //                //txt_loc.Text = "";
        //                //txt_codigo.Text = "";
        //                return false;
        //            }

        //            if (agregar_articulo(lbl_factura.Text, lbl_tot_surtido.Text, dr["Articulo"].ToString().Trim(), dr["Codigo"].ToString().Trim(), Convert.ToDecimal(dr["Multiplo"].ToString()), false))
        //            {
        //                return true;

        //            }
        //            else
        //            {
        //                MessageBox.Show("Error al agregar articulo");
        //                return false;
        //            }

        //        }
        //        else
        //        {
        //            MessageBox.Show("codigo no encontrado");
        //            txt_loc.Text = "";
        //            txt_codigo.Text = "";
        //            return false;

        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show("Error al agregar articulo.." + ex.Message.ToString());
        //        return false;
        //    }

        //}

        //bool agregar_articulo(string invc, string loc, string sku, string codigo, decimal cant, bool nodisp)
        //{
        //    //ADN_agregar_art_lista_surt        	
        //    //@InvcNbr VARCHAR(20), --numero de factura
        //    //@Localizacion VARCHAR(50), --localizacion de la cual se van agregar los articulos
        //    //@SKU VARCHAR(50), ---codigo del articulo que se va agregar
        //    //@CodigoBarras VARCHAR(50), --el codigo de barras
        //    //@Cantidad NUMERIC(9,2), -- cantidad que se va agregar
        //    //@Cant_Sol NUMERIC(9,2), ---cantidad solicitada del articulo de la localizacion
        //    //@Cant_total_surtir NUMERIC(9,2),---Cantidad total que se debe de surtir del articulo
        //    //@tot_surt numeric(9,2) OUTPUT, --cantidad total surtida del articulo
        //    //@tot_surt_loc NUMERIC(9,2) OUTPUT, ---cantidad total surtida de la localizacion actual
        //    //@NoDisp BIT                        
        //    SqlCommand cmd = new SqlCommand();
        //    try
        //    {
        //        //Cursor.Current = Cursors.WaitCursor; 
        //        cmd.Connection = cn;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "ADN_agregar_art_lista_surt";
        //        cmd.Connection = cn;
        //        cmd.Parameters.AddWithValue("@InvcNbr", invc.Trim() );
        //        cmd.Parameters.AddWithValue("@Localizacion", loc.Trim());
        //        cmd.Parameters.AddWithValue("@SKU", sku.Trim());
        //        if(codigo=="")
        //        {
        //            cmd.Parameters.AddWithValue("@CodigoBarras", DBNull.Value );
        //        }
        //        else
        //        {
        //        cmd.Parameters.AddWithValue("@CodigoBarras", codigo.Trim() );
        //        }
        //        //cantidad que se va agregar
        //        cmd.Parameters.AddWithValue("@Cantidad", cant);
        //        //cantidad total a surtir de la localizacion
        //        cmd.Parameters.AddWithValue("@Cant_Sol", lbl_surtir_loc.Text.Trim());
        //        //cantidad total a surtir del articulo
        //        cmd.Parameters.AddWithValue("@Cant_total_surtir", lbl_cant_sol.Text.Trim());
        //        //Obtiene la cantidad total surtida del articulo
        //        cmd.Parameters.AddWithValue("@tot_surt", 0);
        //        //obtiene la cantidad total surtida de la localizacion
        //        cmd.Parameters.AddWithValue("@tot_surt_loc", 0);
        //        cmd.Parameters["@tot_surt"].Direction = ParameterDirection.InputOutput;
        //        cmd.Parameters["@tot_surt_loc"].Direction = ParameterDirection.InputOutput;
        //        cmd.Parameters.AddWithValue("@NoDisp", nodisp);
        //        if (cn.State == ConnectionState.Closed)
        //        {
        //            cn.Open();
        //        }

        //        cmd.ExecuteNonQuery();

        //        if (!string.IsNullOrEmpty(cmd.Parameters["@tot_surt"].Value.ToString()))
        //        {
        //            //lbl_cant_sol.Text 
        //            //lbl_cant_surtida.Text;
        //            //lbl_pendiente.Text  
        //            //obtenemos el total pendiente de surtir del articulo
        //            lbl_tot_pend.Text = (Convert.ToDecimal(lbl_cant_sol.Text) - Convert.ToDecimal(cmd.Parameters["@tot_surt"].Value.ToString())).ToString();
        //            //lbl_cant_surtida.Text = cmd.Parameters["@tot_surt"].Value.ToString();
        //            //lbl_pendiente.Text = (Convert.ToDecimal(lbl_cant_sol.Text) - Convert.ToDecimal(lbl_cant_surtida.Text)).ToString();
        //        }
        //        else 
        //        {
        //            lbl_tot_pend.Text = "0";
        //        }

        //        if (!string.IsNullOrEmpty(cmd.Parameters["@tot_surt_loc"].Value.ToString()))
        //        {
                    
        //            lbl_cant_surtida.Text = cmd.Parameters["@tot_surt_loc"].Value.ToString().Trim();
        //            //lbl_cant_surtida.Text = cmd.Parameters["@tot_surt_loc"].Value.ToString().Trim();
        //            lbl_pendiente.Text = (Convert.ToDecimal(lbl_surtir_loc.Text) - Convert.ToDecimal(lbl_cant_surtida.Text)).ToString();
        //            }
        //        else
        //        {
        //            lbl_pendiente.Text = "0";
        //        }

        //        return true;


        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al agregar articulo.." + ex.Message.ToString());
        //        return false;
        //    }



        //}
        decimal tot_pend_surt_art()
        { 
        //ADN_obtener_tot_surt_articulo	
        //@InvcNbr VARCHAR(20),
        //@InvtID varchar(20)
            if (txt_cve.Text   == "")
            {
                return 0;
            }

         SqlCommand cmd = new SqlCommand();
            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            DataRow dr;
            decimal res=0;
            try
            {
                //Cursor.Current = Cursors.WaitCursor;              
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ADN_obtener_tot_surt_articulo";
                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@InvcNbr", lbl_factura.Text.Trim());
                cmd.Parameters.AddWithValue("@InvtID", txt_cve.Text.Trim()      );
                da.SelectCommand = cmd;
                da.Fill(dt);
                if (dt.Tables[0].Rows.Count != 0)
                {
                    dr = dt.Tables[0].Rows[0];
                    //total_surtir
                    // tot_surtido_art
                    if (!string.IsNullOrEmpty(dr[0].ToString()))
                    {
                        res = Convert.ToDecimal(dr[0].ToString().Trim()) - Convert.ToDecimal(dr[1].ToString().Trim());
                        lbl_tot_surtido.Text = dr[1].ToString().Trim().Trim();
                        lbl_tot_pend.Text = res.ToString().Trim();
                        if (res == 0)
                        {
                            btn_inc.Enabled = false;
                            //btn_terminar.Enabled = true;
                            //btn_terminar.Focus(); 
                            btn_sig_art.Enabled = false;
                            btn_no_disp.Enabled = false;
                            btn_surtir.Enabled = false;
                        }
                        return res;
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        bool  obtener_articulo()
        {
            //Obtiene el articulo que se va a surtir

            //ADN_obtener_art_surtir
            //@InvcNbr VARCHAR(15)
            //shipperid, invtid,
            //descr, qtyship, whseloc, 
            //custid, classid,
            // billname, invcnbr,
            // invcdate, noteid, billaddr, 
            // shipaddr, ordenloc, peso, shiptoid, 
            // slsperid, dfltsounit,
            // dbo.ADN_surtimiento_tot_surtido(invcnbr,invtid) AS tot_surtido

            SqlCommand cmd = new SqlCommand();
            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            DataRow dr;
            try
            {
                //Cursor.Current = Cursors.WaitCursor;              
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ADN_obtener_art_surtir";
                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@InvcNbr", lbl_factura.Text.Trim());

                da.SelectCommand = cmd;
                da.Fill(dt);
                if (dt.Tables[0].Rows.Count != 0)
                {
                    dr = dt.Tables[0].Rows[0];
                    if (!string.IsNullOrEmpty(dr["invtid"].ToString()))
                    {
                        txt_cve.Text = dr["invtid"].ToString().Trim();  
                        //lbl_clave.Text = dr["invtid"].ToString();
                    }
                    if (!string.IsNullOrEmpty(dr["descr"].ToString()))
                    {
                        //lbl_desc.Text = dr["descr"].ToString();
                        txt_desc.Text = dr["descr"].ToString().Trim();  
                    }

                    if (!string.IsNullOrEmpty(dr["dfltsounit"].ToString()))
                    {
                        lbl_unidad.Text = dr["dfltsounit"].ToString();
                    }

                      //total_surtir,
                    if (!string.IsNullOrEmpty(dr["total_surtir"].ToString()))
                    {
                        lbl_cant_sol.Text = dr["total_surtir"].ToString();
                    }
                    //cantidad surtida
                    if (!string.IsNullOrEmpty(dr["tot_surtido_art"].ToString()))
                    {
                        //lbl_cant_sol.Text = dr["tot_surtido_art"].ToString().Trim();
                        //lbl_tot_pend.Text
                        lbl_tot_pend.Text = (Convert.ToDecimal(lbl_cant_sol.Text) - Convert.ToDecimal(dr["tot_surtido_art"].ToString().Trim())).ToString();
                        if (Convert.ToDecimal(dr["tot_surtido_art"].ToString()) == 0)
                        {
                            btn_no_disp.Enabled = true;
                            btn_inc.Enabled = false; 
                        }
                        else
                        {
                            btn_no_disp.Enabled = false;
                            btn_inc.Enabled = true;  
                        }
                    }
                    if (Convert.ToDecimal(lbl_tot_pend.Text.Trim())==0)
                    {
                        MessageBox.Show("Articulo Completado","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Exclamation,MessageBoxDefaultButton.Button1)    ;
                        btn_surtir.Enabled = false;
                        btn_sig_art.Enabled = true;  
                    }

                    //txt_loc.Focus();
                    return true;
                }
                else
                {
                    Cursor.Current = Cursors.Default;
                    cmd.Dispose();
                    return false;
                    //if (pendiente() == false)
                    //{
                    //    finalizar();
                    //    MessageBox.Show("Orden Completada!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    //    //this.Close();
                    //    btn_surtir.Enabled = false;
                    //    btn_sig_art.Enabled = false;
                    //    btn_no_disp.Enabled = false;
                    //    btn_terminar.Enabled = true;  
                    //    return false;
                    //}
                    //else
                    //{
                    //    MessageBox.Show("No hay articulos para surtir", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    //    //this.Close();
                    //    return false;
                    //}
                    
                }



            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                cmd.Dispose();
                MessageBox.Show("Error al obtener articulo para surtir..." + ex.Message.ToString());
                return false;
            }
            //Cursor.Current = Cursors.Default;





        }

        //bool obtener_localizacion_surtir()
        //{ 
        //    // ADN_obtener_art_surtir_loc     
        //    //@InvcNbr VARCHAR(15)
        //    //@InvtId VARCHAR(20)	
        //    //Obtienen la localizacion de la cual se debe de surtir el articulo
        //     SqlCommand cmd = new SqlCommand();
        //    DataSet dt = new DataSet();
        //    SqlDataAdapter da = new SqlDataAdapter();
        //    DataRow dr;
        //    try
        //    {
        //        //Cursor.Current = Cursors.WaitCursor;              
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "ADN_obtener_art_surtir_loc";
        //        cmd.Connection = cn;
        //        cmd.Parameters.AddWithValue("@InvcNbr", lbl_factura.Text.Trim());
        //        cmd.Parameters.AddWithValue("@InvtId", lbl_clave.Text.Trim());
        //        da.SelectCommand = cmd;
        //        da.Fill(dt);
        //        if (dt.Tables[0].Rows.Count != 0)
        //        {
        //            dr = dt.Tables[0].Rows[0];

        //            //invtid,
        //            //qtyship,whseloc, 
        //            // ordenloc, peso,
        //            // dfltsounit,
        //            //dbo.ADN_surtimiento_total_surtir_art(invcnbr,invtid) AS total_surtir,
        //            //dbo.ADN_surtimiento_tot_surtido_loc(invcnbr,invtid,whseloc) AS tot_surtido_loc,
        //            //dbo.ADN_surtimiento_tot_surtido_art(invcnbr,invtid) AS tot_surtido_art


        //            //Obtenenomos la cantidad ttotal a surtir de la localizacion
        //            //lbl_loc_surt
        //            lbl_tot_surtido.Text = "";
        //            if (!string.IsNullOrEmpty(dr["whseloc"].ToString()))
        //            {
        //                lbl_tot_surtido.Text = dr["whseloc"].ToString().Trim();
        //            }


        //            if (!string.IsNullOrEmpty(dr["qtyship"].ToString()))
        //            {
        //                lbl_surtir_loc.Text = dr["qtyship"].ToString().Trim();
        //            }
        //            else
        //            {
        //                lbl_surtir_loc.Text = "0";
        //            }
        //            //Obtenemos la cantidad total surtida de la localizacion
        //            if (!string.IsNullOrEmpty(dr["tot_surtido_loc"].ToString()))
        //            {
        //                lbl_cant_surtida.Text = dr["tot_surtido_loc"].ToString().Trim();
        //            }
        //            else
        //            {
        //                lbl_cant_surtida.Text = "0";
        //            }

        //            //obtenemos la catidad total pendiente de surtir de la localizacion

        //            lbl_pendiente.Text = (Convert.ToDecimal(dr["qtyship"].ToString().Trim()) - Convert.ToDecimal(dr["tot_surtido_loc"].ToString().Trim())).ToString().Trim();

        //            //obtenemos la cantidad total pendiente de surtir del articulo

        //            if (!string.IsNullOrEmpty(dr["tot_surtido_art"].ToString()))
        //            {
        //                lbl_tot_pend.Text = (Convert.ToDecimal(lbl_cant_sol.Text.Trim()) - Convert.ToDecimal(dr["tot_surtido_art"].ToString().Trim())).ToString().Trim();

        //            }

        //            return true;

        //        }
        //        else
        //        {
        //            MessageBox.Show("Articulo Completo");  
        //            return false;
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        Cursor.Current = Cursors.Default;
        //        return false;
        //    }


        //}




        private void frm_captura_articulos_Load(object sender, EventArgs e)
        {
            //obtener_articulo();
            Cursor.Current = Cursors.Default;
            btn_sig_art.Focus();  
        }
        
        //private void btn_sel_loc_Click(object sender, EventArgs e)
        //{
        //    Cursor.Current = Cursors.WaitCursor;
        //    frm_sel_loc f = new frm_sel_loc();
        //    f.lbl_clave.Text = lbl_clave.Text;
        //    f.lbl_desc.Text = lbl_desc.Text;
        //    f.ShowDialog();
        //    Cursor.Current = Cursors.Default;
        //    if (f.txt_loc.Text != "")
        //    {
        //        lbl_tot_surtido.Text = f.txt_loc.Text.Trim();
        //    }
        //}

        private void btn_no_disp_Click(object sender, EventArgs e)
        {
            if (terminar_articulo())
            {
                limpiar_datos();
                btn_surtir.Enabled = false;
                btn_no_disp.Enabled = false;
                //btn_terminar.Enabled = false;
                btn_inc.Enabled = false;
                if (pendiente() == true)
                {
                    btn_sig_art.Enabled = true;
                }
                else
                {
                    btn_sig_art.Enabled = false;

                }
            }

        }

        //private void txt_loc_GotFocus(object sender, EventArgs e)
        //{
        //    txt_loc.BackColor = Color.Yellow;
        //}

        //private void txt_loc_LostFocus(object sender, EventArgs e)
        //{
        //    txt_loc.BackColor = Color.White;
        //}

        //private void txt_loc_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        if (txt_loc.Text != "")
        //        {
        //            if (txt_loc.Text.Trim() != lbl_tot_surtido.Text.Trim())
        //            {
        //                MessageBox.Show("Localizacion no valida para surtimiento " + txt_loc.Text.Trim());
        //                txt_loc.SelectAll();
        //                txt_loc.Focus();
        //                txt_loc.SelectAll();
        //                //txt_loc.Text = "";
        //            }
        //            else
        //            {
        //                txt_codigo.Text = "";
        //                txt_codigo.Focus();
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Favor leer la localizacion correctamente: ");
        //            txt_loc.Focus();
        //            txt_loc.Text = "";

        //        }


        //    }
        //}

        //private void txt_codigo_GotFocus(object sender, EventArgs e)
        //{
        //    txt_codigo.BackColor = Color.Yellow;
        //}

        //private void txt_codigo_LostFocus(object sender, EventArgs e)
        //{
        //    txt_codigo.BackColor = Color.White;
        //}

        //private void btn_agregar_art_Click(object sender, EventArgs e)
        //{
        //    if (txt_codigo.Text != "" && txt_loc.Text == lbl_tot_surtido.Text)
        //    {
        //        if (validar_codigo(lbl_clave.Text, txt_codigo.Text))
        //        {
        //            txt_loc.Text = "";
        //            txt_codigo.Text = "";

        //            if (lbl_pendiente.Text == "0")
        //            {

        //            }

        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Codigo no valido");
        //        txt_codigo.Text = "";

        //    }
        //}

        //private void txt_codigo_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        if (txt_loc.Text.Trim() != lbl_tot_surtido.Text.Trim())
        //        {
        //            MessageBox.Show("Localizacion no valida: " + txt_loc.Text.Trim());
        //            txt_loc.Focus();
        //            txt_loc.SelectAll();
        //            return;
        //        }
        //        if (txt_codigo.Text.Trim() != "")
        //        {
        //            if (validar_codigo(lbl_clave.Text.Trim(), txt_codigo.Text.Trim()))
        //            {

        //                //if (agregar_articulo(lbl_factura.Text, lbl_loc_surt.Text, dr["Articulo"].ToString().Trim(), dr["Codigo"].ToString().Trim(), Convert.ToDecimal(dr["Multiplo"].ToString()), false))
        //                //{
                           

        //                //}
        //                //else
        //                //{
        //                //    MessageBox.Show("Error al agregar articulo");
                           
        //                //}

        //                //txt_loc.Text = "";
        //                //txt_codigo.Text = "";
        //                //txt_loc.Focus();
        //                txt_codigo.Focus();
        //                //txt_codigo.SelectAll();  
        //                if (pendiente() == false)
        //                {
        //                    btn_no_disp.Enabled = false;
        //                    btn_sel_loc.Enabled = false;
        //                    btn_sig_art.Enabled = false;
        //                    tab_captura.Enabled = false;
        //                    btn_terminar.Enabled = true;
        //                    MessageBox.Show("Orden Completa!");
        //                }
        //                else
        //                {
        //                    //lbl_tot_pend

        //                    if (Convert.ToDecimal(lbl_tot_pend.Text.Trim()) == 0)
        //                    {
        //                        MessageBox.Show("Articulo Completado");
        //                        btn_no_disp.Enabled = false;
        //                        btn_sel_loc.Enabled = false;
        //                        btn_sig_art.Enabled = true;
        //                        tab_captura.Enabled = false;
        //                        btn_terminar.Enabled = false;
        //                    }
        //                    else
        //                    { 
        //                      //lbl_surtir_loc
        //                      //lbl_cant_surtida
        //                       //lbl_pendiente
        //                        if (Convert.ToDecimal(lbl_pendiente.Text) == 0)
        //                        {
        //                            MessageBox.Show("Articulo Completado");
        //                            btn_no_disp.Enabled = false;
        //                            btn_sel_loc.Enabled = false;
        //                            btn_sig_art.Enabled = true;
        //                            tab_captura.Enabled = false;
        //                            btn_terminar.Enabled = false;
        //                        }
        //                        else
        //                        {

        //                            //obtener_localizacion_surtir(); 
        //                        }

        //                    }

        //                }
                        

        //            }
        //            else
        //            {
        //                //MessageBox.Show("Codigo no valido:" + txt_codigo.Text);
        //                txt_codigo.SelectAll();
        //                txt_codigo.Focus();
        //                //txt_codigo.Text = "";
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Codigo no valido");
        //            //txt_codigo.SelectAll();
        //            txt_codigo.Focus();
        //            //txt_codigo.Text = "";  

        //        }
        //    }

        //}

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        //private void txt_cve_art_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        if (txt_loc_art.Text.Trim() != lbl_tot_surtido.Text.Trim())
        //        {
        //            MessageBox.Show("Localizacion no valida: " + txt_loc_art.Text.Trim());
        //            txt_loc_art.Focus();
        //            txt_loc_art.SelectAll();
        //            return;
        //        }
        //        else if (txt_cve_art.Text.Trim() != lbl_clave.Text.Trim())
        //        {
        //            MessageBox.Show("Clave de articulo no valida: " + txt_cve_art.Text.Trim());
        //            txt_cve_art.Focus();
        //            txt_cve_art.SelectAll();
        //            return;
        //        }
        //        else
        //        {
        //            txt_cant_art.Text = "";
        //            txt_cant_art.Focus();
        //        }

        //    }





        //}

        //private void txt_loc_art_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        if (txt_loc_art.Text.Trim() != lbl_tot_surtido.Text.Trim())
        //        {
        //            MessageBox.Show("Localizacion no valida para surtimiento " + txt_loc_art.Text);

        //            txt_loc_art.Focus();
        //            txt_loc_art.SelectAll();
        //            //txt_loc.Text = "";
        //        }
        //        else
        //        {
        //            txt_cve_art.Text = "";
        //            txt_cve_art.Focus();


        //        }
        //    }
            
        
        //}

        //private void txt_loc_art_GotFocus(object sender, EventArgs e)
        //{
        //    txt_loc_art.BackColor = Color.Yellow;

        //}

        //private void txt_cve_art_GotFocus(object sender, EventArgs e)
        //{
        //    txt_cve_art.BackColor = Color.Yellow;

        //}

        //private void txt_loc_art_LostFocus(object sender, EventArgs e)
        //{
        //    txt_loc_art.BackColor = Color.White;
        //}

        //private void txt_cve_art_LostFocus(object sender, EventArgs e)
        //{
        //    txt_cve_art.BackColor = Color.White;
        //}

        //private void txt_cant_art_GotFocus(object sender, EventArgs e)
        //{
        //    txt_cant_art.BackColor = Color.Yellow;

        //}

        //private void txt_cant_art_LostFocus(object sender, EventArgs e)
        //{
        //    txt_cant_art.BackColor = Color.White;
        //}

        //private void txt_cant_art_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        if (txt_loc_art.Text.Trim() != lbl_tot_surtido.Text.Trim())
        //        {
        //            MessageBox.Show("Localizacion no valida: " + txt_loc_art.Text.Trim());
        //            txt_loc_art.Focus();
        //            txt_loc_art.SelectAll();
        //            return;
        //        }
        //        else if (txt_cve_art.Text.Trim() != lbl_clave.Text.Trim())
        //        {
        //            MessageBox.Show("Clave de articulo no valida: " + txt_cve_art.Text.Trim());
        //            txt_cve_art.Focus();
        //            txt_cve_art.SelectAll();
        //            return;
        //        }
        //        if (txt_cant_art.Text != "")
        //        { 
        //          if(!IsNumeric(txt_cant_art.Text.Trim()))
        //          {
        //             MessageBox.Show("Cantidad no valida: " );
        //              txt_cant_art.Text="";
        //              txt_cant_art.Focus(); 
                   
        //            return;
        //          }
        //          else if (Convert.ToDecimal(txt_cant_art.Text.Trim()) == 0)
        //          {
        //              MessageBox.Show("Cantidad no valida: ");
        //              txt_cant_art.Text = "";
        //              txt_cant_art.Focus(); 
        //          }
        //          else if (Convert.ToDecimal(txt_cant_art.Text.Trim()) < 0)
        //          {
        //              MessageBox.Show("Cantidad no valida: ");
        //              txt_cant_art.Text = "";
        //              txt_cant_art.Focus();
        //          }
        //          else if (Convert.ToDecimal(txt_cant_art.Text.Trim()) > Convert.ToDecimal(lbl_pendiente.Text))
        //          {
        //              MessageBox.Show("Cantidad mayor al pendiente de surtir: ");
        //              txt_cant_art.Text = "";
        //              txt_cant_art.Focus();
        //          }
        //          else
        //          {
        //              //btn_agregar_art.Focus();  

        //              if (agregar_articulo(lbl_factura.Text.Trim(), lbl_tot_surtido.Text.Trim(), txt_cve_art.Text.Trim(), "", Convert.ToDecimal(txt_cant_art.Text.Trim()), false))
        //              {
        //                txt_loc_art.Text="";
        //                txt_cve_art.Text="";
        //                txt_cant_art.Text="";
        //                txt_loc_art.Focus();  
        //              }
        //              else
        //              {
                        
        //              }
              
        //          }

        //        }
  



        //    }



        //}

        //private void btn_agregar_cve_Click(object sender, EventArgs e)
        //{
        //    if (txt_loc_art.Text.Trim() != lbl_tot_surtido.Text.Trim())
        //    {
        //        MessageBox.Show("Localizacion no valida: " + txt_loc_art.Text.Trim());
        //        txt_loc_art.Focus();
        //        txt_loc_art.SelectAll();
        //        return;
        //    }
        //    else if (txt_cve_art.Text.Trim() != lbl_clave.Text.Trim())
        //    {
        //        MessageBox.Show("Clave de articulo no valida: " + txt_cve_art.Text.Trim());
        //        txt_cve_art.Focus();
        //        txt_cve_art.SelectAll();
        //        return;
        //    }
        //    if (txt_cant_art.Text != "")
        //    {
        //        if (!IsNumeric(txt_cant_art.Text.Trim()))
        //        {
        //            MessageBox.Show("Cantidad no valida: ");
        //            txt_cant_art.Text = "";
        //            txt_cant_art.Focus();

        //            return;
        //        }
        //        else if (Convert.ToDecimal(txt_cant_art.Text.Trim()) == 0)
        //        {
        //            MessageBox.Show("Cantidad no valida: ");
        //            txt_cant_art.Text = "";
        //            txt_cant_art.Focus();
        //        }
        //        else if (Convert.ToDecimal(txt_cant_art.Text.Trim()) < 0)
        //        {
        //            MessageBox.Show("Cantidad no valida: ");
        //            txt_cant_art.Text = "";
        //            txt_cant_art.Focus();
        //        }
        //        else if (Convert.ToDecimal(txt_cant_art.Text.Trim()) > Convert.ToDecimal(lbl_pendiente.Text))
        //        {
        //            MessageBox.Show("Cantidad mayor al pendiente de surtir: ");
        //            txt_cant_art.Text = "";
        //            txt_cant_art.Focus();
        //        }
        //        else
        //        {
        //            //agregar articulo
        //            if (agregar_articulo(lbl_factura.Text.Trim(), lbl_tot_surtido.Text.Trim(), txt_cve_art.Text.Trim(), "", Convert.ToDecimal(txt_cant_art.Text.Trim()), false))
        //            {
        //                txt_loc_art.Text = "";
        //                txt_cve_art.Text = "";
        //                txt_cant_art.Text = "";
        //                txt_loc_art.Focus();
        //            }
        //            else
        //            {

        //            }


        //        }

        //    }

        //}

        private void btn_sig_art_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (obtener_articulo())
            {
                btn_no_disp.Enabled = true;
                btn_sig_art.Enabled = false;
                btn_surtir.Enabled = true;
                btn_surtir.Focus();
            }
            else
            {
                if (pendiente() == false)
                {
                    finalizar();
                    MessageBox.Show("Orden Completada!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    this.Close();
                    //btn_surtir.Enabled = false;
                    //btn_sig_art.Enabled = false;
                    //btn_no_disp.Enabled = false;
                    //btn_terminar.Enabled = true;
                   
                }
                else
                {
                    MessageBox.Show("No hay articulos para surtir", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    this.Close();
                   
                }
            
            }
            Cursor.Current = Cursors.Default;
 
        }

        private void btn_terminar_Click(object sender, EventArgs e)
        {
            
            
            if (terminar_articulo())
            {
                limpiar_datos();
                btn_surtir.Enabled = false;
                btn_no_disp.Enabled = false;
                //btn_terminar.Enabled = false;
                btn_inc.Enabled = false;  
                if (pendiente() == true)
                {
                    btn_sig_art.Enabled = true;
                }
                else
                {
                    btn_sig_art.Enabled = false;
                
                }
            }
            else
            { 
            
            }
            


        }

        private void btn_surtir_Click(object sender, EventArgs e)
        {
            //SetCursor(LoadCursor(NULL, IDC_WAIT));
            try
            {
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
                //Cursor.Show();  

                frm_leer_articulos1 f = new frm_leer_articulos1();
                f.invcnbr = lbl_factura.Text.Trim();
                f.invtid = txt_cve.Text.Trim();
                //f.lbl_clave.Text = lbl_clave.Text.Trim();
                //f.lbl_desc.Text = lbl_desc.Text.Trim();    
                f.txt_cve.Text = txt_cve.Text.Trim();
                f.txt_desc.Text = txt_desc.Text.Trim();
                //f.desc = lbl_desc.Text.Trim();    
                f.shipperid = lbl_shipperid.Text.Trim();
                f.cant_sol = Convert.ToDecimal(lbl_cant_sol.Text.Trim());
                //f.Text = lbl_clave.Text.Trim() + "-" + lbl_desc.Text.Trim();
                //this.Hide();
                f.ShowDialog();
                //this.ShowDialog();
            }
            catch (Exception)
            {
                Cursor.Current = Cursors.Default; 
            }
            finally
            {
                Cursor.Current = Cursors.Default;  
            }

        }

        private void label1_ParentChanged(object sender, EventArgs e)
        {

        }

        private void lbl_shipperid_ParentChanged(object sender, EventArgs e)
        {

        }

        private void frm_captura_articulos_Activated(object sender, EventArgs e)
        {
            if (txt_cve.Text  != "")
            {
                if (tot_pend_surt_art() == 0)
                {
                     if(terminar_articulo())
                    {
                        limpiar_datos();
                        btn_surtir.Enabled = false;
                        btn_no_disp.Enabled = false;
                        //btn_terminar.Enabled = false;
                        btn_inc.Enabled = false;
                    }
                    //verifica si hay articulos pendientes de surtir
                    if (pendiente() == false)
                    {
                        finalizar();
                        MessageBox.Show("Orden Completada!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        this.Close();
                        //btn_surtir.Enabled = false;
                        //btn_sig_art.Enabled = false;
                        //btn_no_disp.Enabled = false;
                        //btn_terminar.Enabled = true;

                    }
                    else
                    {
                        //MessageBox.Show("Articulo Completado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        ////limpiar_datos();
                        btn_sig_art.Enabled = true;
                        btn_sig_art.Focus();  
                        btn_no_disp.Enabled = false;
                        btn_inc.Enabled = false;
                        //btn_terminar.Enabled = false; 
                    }
                      
                }
            }
        }

        private void btn_inc_Click(object sender, EventArgs e)
        {
            if (terminar_articulo())
            {
                limpiar_datos();
                btn_surtir.Enabled = false;
                btn_no_disp.Enabled = false;
                //btn_terminar.Enabled = false;
                btn_inc.Enabled = false;
                if (pendiente() == true)
                {
                    btn_sig_art.Enabled = true;
                }
                else
                {
                    btn_sig_art.Enabled = false;

                }
            }


        }

        private void frm_captura_articulos_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode )
            {
               
                case Keys.F1:
                    if (btn_sig_art.Enabled == true)
                    {
                        btn_sig_art_Click(this, EventArgs.Empty);   
                    }
                    break;                           
                case Keys.F2:
                    if (btn_surtir.Enabled == true)
                    {
                        btn_surtir_Click(this, EventArgs.Empty);   
                    }
                    break;      
                 case Keys.F3:
                    //if (btn_terminar.Enabled == true)
                    //{
                    //    btn_terminar_Click(this, EventArgs.Empty);   
                    //}
                    break;
                 case Keys.F4:
                    if (btn_inc.Enabled == true)
                    {
                        btn_inc_Click(this, EventArgs.Empty);   
                    }
                    break;
                 case Keys.F5:
                    string res;

                    btn_no_disp_Click(this, EventArgs.Empty);
  
                    break;
                 case Keys.F10:
                    this.Close(); 
                    break;  

                default:
                    break;
            }
        }

        private void lbl_clave_ParentChanged(object sender, EventArgs e)
        {

        }

        private void panel1_GotFocus(object sender, EventArgs e)
        {

        }

       

       







        }
        }






//    }  
    
//}