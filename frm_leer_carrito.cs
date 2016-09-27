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
    public partial class frm_leer_carrito : Form
    {
        public frm_leer_carrito()
        {
            InitializeComponent();
        }

        public string invcnbr;
        public int tot_Cajas = 0;
        public string tipocarro="CARRITO";
        //bool recibir_carrito()
        //{ 
        
        //}

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
                MessageBox.Show("Error al obtener total de cajas de la factura.." + ex.Message.ToString());
                return 0;

            }


        }

        int total_cajas_rec(string factura, int id_zona)
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
                //tot_rec = Convert.ToInt16(cmd.ExecuteScalar().ToString());
                return Convert.ToInt16(cmd.ExecuteScalar().ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener total de cajas recibidas");
                return 0;

            }

        }
        bool recibir_caja(string factura, string caja, int id_zona)
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


        bool carrito_disponible(string carrito)
        {
           // ADN_disponibilidad_carrito	
           //@Numerocaja INT	
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da=new SqlDataAdapter();
            DataSet dt=new DataSet();
            DataRow dr;
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_disponibilidad_carrito";
            cmd.Parameters.AddWithValue("@Numerocaja", carrito);
            da.SelectCommand = cmd; 
            try
            {
                da.Fill(dt);
                if (dt !=null)
                {
                    if (dt.Tables.Count > 0)
                    {
                        if (dt.Tables[0].Rows.Count > 0)
                        {
                            dr = dt.Tables[0].Rows[0];

                            if (!string.IsNullOrEmpty(dr["InvcNbr"].ToString()))
                            {
                                string factura = dr["InvcNbr"].ToString();
                                if (factura != "")
                                {
                                    if (factura != invcnbr)
                                    {
                                        MessageBox.Show("El Carrito Asignado  A La Factura:" + factura + " , Seleccionar Otro", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                                        return false;
                                    }
                                    else
                                    {
                                        return true;
                                    }

                                }
                                else
                                {
                                    if (tipocarro !="" && txt_no.Text.Trim()  !="" )
                                    {
                                        recibir_caja(invcnbr, txt_no.Text.Trim(), Global.idzona); 
                                    }
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
                    else
                    {
                        return true;
                    }

                }
                else
                {
                    return true;
                }
                //return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar carrito... " + ex.Message.ToString() ,"Aviso",  MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                              
                return false;
            }
        
        
        }

        bool agregar_carrito(string carrito)
        {
        //ADN_agregar_carrito_factura        
        //@InvcNbr VARCHAR(20),
        //@Caja INT,
        //@Usuario VARCHAR(50)

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_agregar_carrito_factura";
            cmd.Parameters.AddWithValue("@InvcNbr", invcnbr.Trim());
            cmd.Parameters.AddWithValue("@Caja", carrito);
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
            catch
            {
                MessageBox.Show("Error al agregar Carrito", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return false;
            }

        }



        bool actualizar_zona_picking2(string factura, string usuario, string carritono, int idzona)
        {
            StringBuilder cad = new StringBuilder();
            cad.Append("UPDATE ADN_surtimiento_zona SET ");
            cad.AppendLine("Usuario=@Usuario,CarritoNo=@CarritoNo ");
            cad.AppendLine("Where InvcNbr=@InvcNbr and IdZona=5 and Activo=1");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = cad.ToString();
            cmd.Parameters.AddWithValue("@InvcNbr", factura);
            cmd.Parameters.AddWithValue("@Usuario", usuario);
            cmd.Parameters.AddWithValue("@CarritoNo", carritono);
            //cmd.Parameters.AddWithValue("@IdZona", idzona);
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
                MessageBox.Show("Error al actualizar zona Surtimiento");
                return false;
            }



        }



        bool obtener_datos_caja(string numero)
        { 
        //ADN_Obtener_Datos_Caja 	
        //@Numero INT,--NUMERO DE CAJA O CARRITO
        //@Tipo varchar(50)--CAJA
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.Connection = Global.cn;
            DataSet dt = new DataSet();
            //DataRow dr;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Obtener_Datos_Caja";
            cmd.Parameters.AddWithValue("@Numero", numero);
            if (tipocarro != "")
            {
                cmd.Parameters.AddWithValue("@Tipo", tipocarro);
            }
            else
            {
                MessageBox.Show("Seleccionar el medio de surtimiento correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return false;
            
            }
            
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
                MessageBox.Show("Error al obtener datos.." + ex.Message.ToString());
                return false;
            
            }
           
        
        }
        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (txt_no.Text == "")
            {
                txt_no.Focus();
                return;
            }

            if (tipocarro == "")
            {
                MessageBox.Show("Seleccionar Medio Para Surtir");  
                return;
            }

            int idzonap2 = Global.obtener_idzona_P2();
            if (idzonap2 <= 0)
            {
                //MessageBox.Show("Error al obtener zona de P2, Intente de nuevo");
                //return;
                idzonap2= int.Parse(Properties.Resources.idzonap2.ToString());

            }
            
            //buscar los datos de la caja en la lista de cajas asignadas de la factura
            DataSet dt = Global.datos_caja_factura(Global.invcnbr, txt_no.Text.Trim());
            if (dt != null)
            {
                if (dt.Tables.Count > 0)
                {
                    if (dt.Tables[0].Rows.Count > 0)
                    {
                        if (recibir_caja(Global.invcnbr, txt_no.Text.Trim(), idzonap2))
                        {
                            //if (Global.tot_cajas_pend_recibir_picking2(Global.invcnbr) > 0)
                            //{
                            //    MessageBox.Show("Terminar recepcion de las cajas de la factura");
                            //    frm_recepcion_cajas f = new frm_recepcion_cajas();
                            //    f.invcnbr = invcnbr;
                            //    f.lbl_factura.Text = invcnbr;
                            //    f.carrito = txt_no.Text.Trim();
                            //    f.Text = "Recibir Cajas PICKING2";
                            //    f.lbl_id_zona.Text = idzonap2.ToString();
                            Global.cajap2 = txt_no.Text.Trim().ToUpper();
                            Global.tipocaja = tipocarro;
                            this.Close();
                            //f.Show();

                            //}
                            //else
                            //{
                            //    Global.cajap2 = txt_no.Text.Trim().ToUpper();
                            //    Global.tipocaja = tipocarro;
                            //    this.Close();

                            //}
                        }
                        else
                        {
                            MessageBox.Show("Error al recibir caja");
                            //if (Global.tot_cajas_pend_recibir_picking2(Global.invcnbr) > 0)
                            //{
                            //    MessageBox.Show("Terminar recepcion de las cajas de la factura");
                            //    frm_recepcion_cajas f = new frm_recepcion_cajas();
                            //    f.invcnbr = invcnbr;
                            //    f.lbl_factura.Text = invcnbr;
                            //    f.carrito = txt_no.Text.Trim();
                            //    f.Text = "Recibir Cajas PICKING2";
                            //    f.lbl_id_zona.Text = idzonap2.ToString();
                            //    Global.cajap2 = txt_no.Text.Trim().ToUpper();
                            //    Global.tipocaja = tipocarro;
                            //    this.Close();
                            //    f.Show();
                            //}
                            //else
                            //{
                            Global.cajap2 = txt_no.Text.Trim().ToUpper();
                            Global.tipocaja = tipocarro;
                            this.Close();

                            //}

                        }


                    }
                    else
                    {
                        //si la caja no existe agregarla a la lista de cajas de la factura
                        if (obtener_datos_caja(txt_no.Text.Trim().ToUpper()))
                        {
                            string fact = "";
                            if (Global.disponibilidad_caja(txt_no.Text.Trim().ToUpper(), out fact))
                            {
                                if (Global.agregar_caja(txt_no.Text.Trim().ToUpper(), 1))
                                {
                                    //if (Global.tot_cajas_pend_recibir_picking2(Global.invcnbr) > 0)
                                    //{
                                    //    frm_recepcion_cajas f = new frm_recepcion_cajas();
                                    //    f.idzona1 = idzonap2;
                                    //    f.invcnbr = invcnbr;
                                    //    f.lbl_factura.Text = invcnbr;
                                    //    f.carrito = txt_no.Text.Trim();
                                    //    f.Text = "Recibir Cajas PICKING2";
                                    //    f.lbl_id_zona.Text = idzonap2.ToString();
                                    //    Global.cajap2 = txt_no.Text.Trim().ToUpper();
                                    //    Global.tipocaja = tipocarro;
                                    //    this.Close();
                                    //    f.Show();

                                    //}
                                    //else
                                    //{
                                    Global.cajap2 = txt_no.Text.Trim().ToUpper();
                                    Global.tipocaja = tipocarro;
                                    this.Close();

                                    //}

                                }
                                else
                                {
                                    MessageBox.Show("Error al agregar caja, intente otra vez");
                                    txt_no.Text = "";
                                    txt_no.Focus();

                                }

                            }
                            else
                            {
                                MessageBox.Show("La caja ya esta asignada a la factura: " + fact);
                                txt_no.Text = "";
                                txt_no.Focus();

                            }

                        }
                        else
                        {
                            MessageBox.Show("Error al obtener datos, intente otra vez");
                            txt_no.Text = "";
                            txt_no.Focus();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Error al obtener datos, intente otra vez");
                    txt_no.Text = "";
                    txt_no.Focus();
                }
            }
            else
            {
                MessageBox.Show("Error al obtener datos, intente otra vez");
                txt_no.Text = "";
                txt_no.Focus();
            }
           
            
        }

        private void txt_no_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txt_no.Text != "" )
            {

                btn_ok_Click(this, EventArgs.Empty);

            }
            else
            {
                txt_no.Focus();
            }



        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkcarrito_CheckStateChanged(object sender, EventArgs e)
        {

        }

        //private void chkcarrito_Click(object sender, EventArgs e)
        //{
        //    if (chkcarrito.Checked)
        //    {
        //        chkcaja.Enabled = false;
        //        chkcaja.Checked = false;
        //        txt_no.Focus(); 
        //    }
        //    else
        //    {
        //        chkcaja.Enabled = true;
        //        txt_no.Focus(); 
        //    }
        //}

        //private void chkcaja_Click(object sender, EventArgs e)
        //{
        //    if (chkcaja.Checked)
        //    {

        //        chkcarrito.Enabled = false;
        //        chkcarrito.Checked = false;
        //        txt_no.Focus(); 
        //    }
        //    else
        //    {
        //        chkcarrito.Enabled = true;
        //        txt_no.Focus(); 
        //    }
        //}

        private void frm_leer_carrito_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
            total_cajas_factura(invcnbr);
        }

        

        private void btncaja_Click(object sender, EventArgs e)
        {
            
                tipocarro = "CAJA";
                btncaja.BackColor = Color.GreenYellow;
                lblmsg.Text = "CAJA #";
                btn_carrito.BackColor = SystemColors.Control;

                btntarima.BackColor = SystemColors.Control;
                txt_no.Focus();
                if (Global.tot_cajas_tipo(tipocarro) > 0)
                {
                    btnbuscar.Enabled = true;
                }
                else
                {
                    btnbuscar.Enabled = false;
                }
           
        }

        private void txt_no_GotFocus(object sender, EventArgs e)
        {
            txt_no.BackColor = Color.Yellow; 
        }

        private void txt_no_LostFocus(object sender, EventArgs e)
        {
            txt_no.BackColor = Color.White; 
        }

        private void btncarrito_GotFocus(object sender, EventArgs e)
        {
            btn_carrito.BackColor = Color.GreenYellow;
            btncaja.BackColor = SystemColors.Control;
            txt_no.Focus(); 
        }

        
        private void btncaja_GotFocus(object sender, EventArgs e)
        {
            btncaja.BackColor = Color.GreenYellow;
            //btncarrito.BackColor = SystemColors.Control;
        }

        private void btn_carrito_Click(object sender, EventArgs e)
        {
            tipocarro = "CARRITO";
            btn_carrito.BackColor = Color.GreenYellow;
            btncaja.BackColor = SystemColors.Control;
            btntarima.BackColor = SystemColors.Control;
            lblmsg.Text = "CARRITO #";
            txt_no.Focus();
            if (Global.tot_cajas_tipo(tipocarro) > 0)
            {
                btnbuscar.Enabled = true;
            }
            else
            {
                btnbuscar.Enabled = false;
            }
        }

        private void btntarima_Click(object sender, EventArgs e)
        {
            tipocarro = "TARIMA";
            btntarima.BackColor = Color.GreenYellow;
            btncaja.BackColor = SystemColors.Control;
            btn_carrito.BackColor = SystemColors.Control;
            lblmsg.Text = "TARIMA #";
            if (Global.tot_cajas_tipo(tipocarro) > 0)
            {
                txt_no.Focus();
                btnbuscar.Enabled = true;
            }
            else
            {
                btnbuscar.Enabled = false;
                string res = MessageBox.Show("Desea Agregar Tarima Para Surtir?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2).ToString();
                if (res == "Yes")
                {
                    string tarima = Global.obtener_tarima();
                    if (tarima != "0")
                    {
                        txt_no.Text = tarima;
                        Global.cajap2 = txt_no.Text.Trim().ToUpper();
                        MessageBox.Show("Tarima # " + tarima, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("No Hay Tarimas Para Surtir, Intente Otra Vez", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                    }
                }
            }
            

        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            if (tipocarro == "")
            {
                return;
            }
            frm_lista_cajas f = new frm_lista_cajas();
            f.Text = "FACTURA # " + Global.invcnbr;
            f.tipo = tipocarro;
            f.lbltipo.Text = tipocarro + "S";
            f.ShowDialog();
            
            if (f.caja != "")
            {
                //Global.cajap2 = f.caja;
                txt_no.Text = f.caja;
                btn_ok.Focus(); 
            }
        }

       

      

        
    }
}