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
    public partial class frm_zona : Form
    {
        public frm_zona()
        {
            InitializeComponent();
        }
        public bool acceso = false;
        public bool salir = false;
        bool registrar_acceso(string usuario, int idzona, string area,int op)
        { 
            //Registra el acceso en el historial de accesos
            //ADN_Registrar_Acceso_Usuarios
            //@Usuario varchar(50),
            //@IdZona int,
            //@Area varchar(50)	
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Registrar_Acceso_Usuarios";
            cmd.Parameters.AddWithValue("@Usuario", usuario);
            cmd.Parameters.AddWithValue("@IdZona", idzona);
            cmd.Parameters.AddWithValue("@Area", area);
            cmd.Parameters.AddWithValue("@OP",op);

           
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
                //MessageBox.Show("Error al registrar acceso en el sistema");  
                return false;
            }
        
        }

        bool validar()
        {
            DataSet dt = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_obtener_datos_zona";
            cmd.Parameters.AddWithValue("@Zona",txt_seccion.Text.Trim().ToUpper() );
            cmd.Parameters.AddWithValue("@Area", txt_area.Text.Trim().ToUpper() );
            DataRow dr;
            da.SelectCommand = cmd;
            try
            {
                da.Fill(dt);

                if (dt.Tables[0].Rows.Count != 0)
                {
                    dr = dt.Tables[0].Rows[0];
                    Global.area = txt_area.Text.Trim().ToUpper();
                    Global.idarea = Convert.ToInt16(dr["IdArea"].ToString());

                    if (!string.IsNullOrEmpty(dr["IdPicking"].ToString()))
                    {
                        Global.picking = int.Parse(dr["IdPicking"].ToString());
                    }
                    else
                    {
                        Global.picking = 0;
                        MessageBox.Show("Error la zona no tiene Picking asignado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                        return false;
                    }

                    if (Convert.ToInt16(dr["IdZona"].ToString()) != Global.idzona)
                    {
                        //al cambiar de zona  borrar la factura actual en surtimiento, 
                        Global.factura = "";
                        Global.invcnbr = "";
                    }
                    Global.idzona = Convert.ToInt16(dr["IdZona"].ToString());
                    Global.zona = txt_seccion.Text.Trim().ToUpper();
                    if (!string.IsNullOrEmpty(dr["Orden"].ToString()))
                    {
                        Global.orden_zona = Convert.ToInt16(dr["Orden"].ToString());
                    }
                    else
                    {
                        Global.orden_zona = -1;
                    }
                    return true;
                }
                else
                {
                    txt_seccion.Text = "";
                    txt_area.Text = "";
                    txt_seccion.Focus();  
                    MessageBox.Show("Datos no encontrados intente otra vez..", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Datos no encontrados intente otra vez..", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                txt_seccion.Text = "";
                txt_area.Text = "";
                txt_seccion.Focus(); 
                return false;
            }
  
        
        }


        private void txt_seccion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_seccion.Text != "")
                {
                    if (txt_seccion.Text.Trim().ToUpper() == "PICKING2")
                    {
                        btn_aceptar_Click(this, EventArgs.Empty);   
                    }
                    else
                    {
                        txt_area.Text = "";  
                        txt_area.Focus();
                    }
                }
            }
        }

        private void txt_area_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_seccion.Text != "")
                {
                    if (txt_area.Text != "")
                    {
                        //if (validar())
                        //{
                        //    this.Close();
                        //    frm_menu f = new frm_menu();
                        //    f.ShowDialog(); 

                        //}
                        //btn_aceptar.Focus();
                        btn_aceptar_Click(this, EventArgs.Empty);
 
                    }
                }
                else
                {
                    txt_seccion.Focus();  
                }
            }
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            string s = MessageBox.Show("Desea cerrar esta ventatana?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2).ToString();
            if (s == "Yes")
            {
                salir = true;
                this.Close();
            }
          
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
           
            if (txt_seccion.Text.Trim().ToUpper() == "PICKING2")
            {
                if (registrar_acceso(Global.usuario, 5, "PICKING2", 1))
                {
                    Global.invcnbr = "";
                    Global.idzona = 5;
                    Global.zona = "ZONA5";  
                    Global.area = "PICKING2";
                    Global.orden_zona = 6;
                    acceso = true;
                    this.Close();
                    //this.Hide();
                    //frm_menu f = new frm_menu();
                    //f.ShowDialog();
                }
                else
                {
                    acceso = false;
                    MessageBox.Show("Error al registrar acceso, intente otra vez.");  
                }
            }
            else if (txt_seccion.Text != "" && txt_area.Text != "")
            {
                if (validar())
                {
                    if (registrar_acceso(Global.usuario, Global.idzona, Global.area, 1))
                    {
                        acceso = true;
                        this.Close();
                        //frm_menu f = new frm_menu();
                        //f.ShowDialog();
                    }
                    else
                    {
                        acceso = false;
                    }

                }
                else
                {
                    acceso = false;
                }
            }
            else
            {
                txt_seccion.Text = "";  
                txt_seccion.Focus(); 
            }
        }

        private void txt_seccion_GotFocus(object sender, EventArgs e)
        {
            txt_seccion.BackColor = Color.Yellow;   
        }

        private void txt_seccion_LostFocus(object sender, EventArgs e)
        {
            txt_seccion.BackColor = Color.White;   
        }

        private void txt_area_GotFocus(object sender, EventArgs e)
        {
            txt_area.BackColor = Color.Yellow;   
        }

        private void txt_area_LostFocus(object sender, EventArgs e)
        {
            txt_area.BackColor = Color.White;   
        }

        private void frm_zona_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.F1:
                    btn_aceptar_Click(this, EventArgs.Empty); 
                    break;
                                 
                case Keys.F10:
                    btn_Salir_Click(this, EventArgs.Empty);  
                    break;
                
               
               
                default:
                    break;
            }

        }

        private void frm_zona_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
            txt_seccion.Focus();
        }
    }
}