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
    public partial class frm_login : Form 
    {
        public frm_login()
        {
            InitializeComponent();
        }
        //SqlConnection cn = new SqlConnection(Properties.Resources.connectionstring);

        public bool acceso = false;

        bool validar_usuario(string usuario,string password)
        {
            DataSet dt = new DataSet();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn ;
            SqlDataAdapter da = new SqlDataAdapter();
            DataRow dr;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Obtener_Usuario";
            cmd.Parameters.AddWithValue("@NumNomina",usuario.Trim());
            //cmd.Parameters.AddWithValue("@Puesto", puesto.Trim() );            
            da.SelectCommand = cmd;
            try
            {
                
                da.Fill(dt);
                //NumNomina, 
                //Nombre, 
                //Puesto,
                //Password,
                //Status

                if (dt.Tables[0].Rows.Count != 0)
                {
                    dr = dt.Tables[0].Rows[0];
                    if (!string.IsNullOrEmpty(dr["Status"].ToString()))
                    {
                        //string s = dr["Status"].ToString().Trim();
                        if (dr["Status"].ToString().Trim() != "True")
                        {
                            MessageBox.Show("Usuario No Autorizado!");
                            txt_usuario.Focus();
                            txt_usuario.Text = "";
                            txt_password.Text = "";
                            return false;
                        }
                        else if (!string.IsNullOrEmpty(dr["Password"].ToString().Trim()))
                        {
                            if (dr["Password"].ToString().Trim() != password)
                            {
                                MessageBox.Show("Password Incorrecto");
                                //txt_usuario.Focus();
                                //txt_usuario.Text = "";
                                txt_password.Text = "";
                                txt_password.Focus();
                                return false;
                            }
                            else
                            {
                                //Zona
                                Global.usuario = dr["NumNomina"].ToString().Trim();
                                if (!string.IsNullOrEmpty(dr["Nombre"].ToString()))
                                {
                                    Global.nombre = dr["Nombre"].ToString().Trim();
                                }
                                else
                                {
                                    Global.nombre = "--------------";
                                }

                                if (!string.IsNullOrEmpty(dr["Puesto"].ToString()))
                                {
                                    Global.puesto = dr["Puesto"].ToString().Trim();
                                }
                                else
                                {
                                    Global.puesto = "";
                                }
                                //id del proceso de surtimiento
                                Global.idproceso = 2;

                                //if (!string.IsNullOrEmpty(dr["Area"].ToString()))
                                //{
                                //    Global.area = dr["Area"].ToString().Trim();
                                //}
                                //else
                                //{
                                //    Global.area = ""; 
                                //}
                                //if (!string.IsNullOrEmpty(dr["Zona"].ToString()))
                                //{
                                //    Global.zona = dr["Zona"].ToString().Trim();
                                //}
                                //else
                                //{
                                //    Global.zona = "";
                                //}
                                //if (!string.IsNullOrEmpty(dr["Orden"].ToString()))
                                //{
                                //    Global.orden_zona = Convert.ToInt16(dr["Orden"].ToString().Trim());
                                //}

                                return true;


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
                    MessageBox.Show("Usuario No Valido");
                    txt_usuario.Focus();
                    return false;
                }

            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Error.." + ex.Message.ToString()); 
                return false;
            }

        }

        private void txt_usuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txt_usuario.Text != "")
                {
                    txt_password.Focus();  
                }
            }
        }

        private void txt_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {              

                if (txt_usuario.Text != "" && txt_password.Text != "")
                {
                    btn_aceptar_Click(this, EventArgs.Empty);  

                }
            }
        }

        private void txt_usuario_GotFocus(object sender, EventArgs e)
        {
            txt_usuario.BackColor = Color.Yellow;   
        }

        private void txt_password_GotFocus(object sender, EventArgs e)
        {
            txt_password.BackColor = Color.Yellow;   
        }

        private void txt_usuario_LostFocus(object sender, EventArgs e)
        {
            txt_usuario.BackColor = Color.White;   
        }

        private void txt_password_LostFocus(object sender, EventArgs e)
        {
            txt_password.BackColor = Color.White;   
        }

        private void frm_login_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode )
            {
                //case Keys.Alt:
                //    break;
                case Keys.F1:
                    btn_aceptar_Click(this, EventArgs.Empty);   
                    break;
                case Keys.F4:
                    txt_usuario.Focus();  
                    break;
                case Keys.F5:
                    txt_password.Focus()  ;
                    break;
                case Keys.F10:
                    this.Close();
                    break;             
                default:
                    break;
            }

        }

        private void frm_login_Load(object sender, EventArgs e)
        {
            txt_usuario.Focus();  
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {           

            if (txt_usuario.Text != "" && txt_password.Text !=""  )
            {
                Cursor.Current = Cursors.WaitCursor;
                if (validar_usuario(txt_usuario.Text.Trim().ToUpper(), txt_password.Text.Trim()))
                {
                    //asignamos la variable usuario la cual debe de estar disponible en todos los formularios
                    Cursor.Current = Cursors.Default;
                    this.Hide();
                    Global.Eliminar_Zonas_Usuario(txt_usuario.Text.Trim().ToUpper());
                    frm_seleccionar_picking f = new frm_seleccionar_picking();
                    f.ShowDialog();                  
                }
                else
                {
                    MessageBox.Show("Datos de acceso no validos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    Cursor.Current = Cursors.Default;
                }

            }

        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void btn_aceptar_GotFocus(object sender, EventArgs e)
        {
            btn_aceptar.BackColor = Color.Yellow;   
        }

        private void btn_aceptar_LostFocus(object sender, EventArgs e)
        {
            btn_aceptar.BackColor = Color.Gray;
        }
    }
}