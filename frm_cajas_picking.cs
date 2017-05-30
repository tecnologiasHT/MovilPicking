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
    public partial class frm_cajas_picking : Form
    {
        public frm_cajas_picking()
        {
            InitializeComponent();
        }

        public string invcnbr="";


        bool actualizar_status_caja(string caja,bool status)
        { 
            //ADN_cajas_surtimiento_actualizar_status
            //@InvcNbr VARCHAR(20), 
            //@Numerocaja INT, 
            //@Status BIT        
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_cajas_surtimiento_actualizar_status";
            cmd.Parameters.AddWithValue("@InvcNbr",invcnbr);
            cmd.Parameters.AddWithValue("@Numerocaja", caja);
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
                MessageBox.Show("Error A Liberar Caja.."); 
                return false;
            }

        }

        decimal obtener_vol_articulos()
        { 
          //ADN_obtener_total_vol_articulos	
          //@InvcNbr varchar(10)
             DataSet dt=new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_obtener_total_vol_articulos";
            cmd.Parameters.AddWithValue("@InvcNbr",invcnbr  );
            ad.SelectCommand = cmd;
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
                MessageBox.Show("Error al obtener volumen total de articulos.." + ex.Message.ToString()); 
                return 0;

            }

        }

        void lista_facturas()
        { 
        //ADN_lista_facturas_surtir_junto	
        //@InvcNbr VARCHAR(20)
            DataSet dt=new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_lista_facturas_surtir_junto";
            cmd.Parameters.AddWithValue("@InvcNbr",lbl_factura.Text.Trim()   );
            ad.SelectCommand = cmd;
            try
            {

                ad.Fill(dt);

                //lst_facturas.Items.Clear();
                //lst_facturas.Items.Add(lbl_factura.Text.Trim());
                //if (dt.Tables[0].Rows.Count != 0)
                //{
                //    foreach (DataRow  dr in dt.Tables[0].Rows  )
                //    {
                //        if (!string.IsNullOrEmpty(dr["InvcNbr"].ToString()))
                //        {
                //            lst_facturas.Items.Add(dr["InvcNbr"].ToString().Trim());   
                //        }
                //    }
                  
                //}
     

            }
            catch
            {
            
            }


        }

        void lista_cajas()
        {
            //ADN_Obtener_lista_cajas 
            //@InvcNbr varchar(15)
            timer1.Enabled = false; 
            DataSet dt=new DataSet();
            SqlDataAdapter ad = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Obtener_lista_cajas";
            cmd.Parameters.AddWithValue("@InvcNbr",invcnbr.Trim()   );
            ad.SelectCommand = cmd;
            try
            {
                ad.Fill(dt);

                dg_cajas.DataSource = dt.Tables[0];
                

                timer1.Enabled = true;  
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos.." + ex.Message.ToString());  
            }
 
        
        }
        bool agregar_caja( string caja, int op)
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
            cmd.Parameters.AddWithValue("@InvcNbr",invcnbr.Trim()  );
            cmd.Parameters.AddWithValue("@Numcaja",txt_caja.Text);
            cmd.Parameters.AddWithValue("@Usuario",Global.usuario);
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
                        MessageBox.Show("Caja en uso, seleccione otra...");
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
                MessageBox.Show("Error al agregar caja","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Exclamation,MessageBoxDefaultButton.Button1 ) ;  
                return false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;  
            this.Close();
        }

        private void frm_cajas_picking_Load(object sender, EventArgs e)
        {
                       
            lista_cajas();
            if (Properties.Resources.volcajapicking != "")
            {
                decimal totvol = 0;
                totvol = obtener_vol_articulos();

                if (totvol > 0)
                {

                    lbl_tot_cajas.Text = (Math.Round((Convert.ToDecimal(Properties.Resources.volcajapicking.Trim()) / totvol),0)).ToString().Trim();   
                }

            }                       
            Cursor.Current = Cursors.Default;

        }

        private void txt_caja_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txt_caja.Text !="" )
            {
                if (agregar_caja(txt_caja.Text.Trim(), 1))
                {
                    txt_caja.Text = "";
                    lista_cajas();
                    txt_caja.Focus();
                }
                else
                {
                    txt_caja.Text = "";
                    txt_caja.Focus();
                }
            }


        }

        private void lst_facturas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_caja.Focus();  
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            frm_liberar_cajas f = new frm_liberar_cajas();
            f.ShowDialog();
            lista_cajas();
            txt_caja.Focus();
        }

        private void dg_cajas_Click(object sender, EventArgs e)
        {
            //if (dg_cajas.VisibleRowCount > 0)
            //{

            //}
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lista_cajas();


        }

        private void frm_cajas_picking_Closing(object sender, CancelEventArgs e)
        {
            timer1.Enabled = false;  
        }

        private void txt_caja_GotFocus(object sender, EventArgs e)
        {
            txt_caja.BackColor = Color.Yellow;   
        }

        private void txt_caja_LostFocus(object sender, EventArgs e)
        {
            txt_caja.BackColor = Color.White;   
        }

       
       

       
    }
}