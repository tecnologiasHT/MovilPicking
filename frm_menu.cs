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
    public partial class frm_menu : Form
    {
        public frm_menu()
        {
            InitializeComponent();
        }

        public bool login = false;


        //bool registrar_acceso(string usuario, int idzona, string area, int op)
        //{
        //    //Registra el acceso en el historial de accesos
        //    //ADN_Registrar_Acceso_Usuarios
        //    //@Usuario varchar(50),
        //    //@IdZona int,
        //    //@Area varchar(50)	
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Connection = Global.cn;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = "ADN_Registrar_Acceso_Usuarios";
        //    cmd.Parameters.AddWithValue("@Usuario", usuario);
        //    cmd.Parameters.AddWithValue("@IdZona", idzona);
        //    cmd.Parameters.AddWithValue("@Area", area);
        //    cmd.Parameters.AddWithValue("@OP", op);


        //    try
        //    {
        //        if (Global.cn.State == ConnectionState.Closed)
        //        {
        //            Global.cn.Open();
        //        }
        //        cmd.ExecuteNonQuery();
        //        return true;
        //    }
        //    catch
        //    {
        //        MessageBox.Show("Error al registrar acceso en el sistema");
        //        return false;
        //    }

        //}
        void lista_zonas_usuario()
        {
            DataSet dt;
            try
            {
                if (Global.picking == 1)
                {
                    dt = Global.lista_zonas_usuario1();
                    if (dt != null)
                    {
                        grd_zonas.DataSource = dt.Tables[0];
                        //grd_zonas.bin
                    }
                }
                else if (Global.picking == 2)
                { 
                  dt=Global.lista_zonas_picking2();
                  if (dt != null)
                  {
                      grd_zonas.DataSource = dt.Tables[0];
                      //grd_zonas.bin
                  }
                }

                
            }
            catch
            { 
            
            }
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm_zona f = new frm_zona();
            f.ShowDialog(); 
        }

        private void frm_menu_Load(object sender, EventArgs e)
        {
            this.Text = "HT Picking         Ver " + Properties.Resources.ver; 
           
            statusBar1.Text = Global.usuario + " " + Global.nombre;
            lbl_picking.Text = Global.picking.ToString();
            if (Global.picking == 1)
            {
                lista_zonas_usuario();
            }
            else
            {
                lista_zonas_usuario();
                btn_cambiar_secc.Enabled = false;
            }
        }

        private void frm_menu_Activated(object sender, EventArgs e)
        {
            //txt_seccion.Text = Global.zona;
            //txt_area.Text = Global.area;  
        }

        private void btn_surtimiento_Click(object sender, EventArgs e)
        {            
                frmSurtimiento f = new frmSurtimiento();
                this.Visible = false;
                f.ShowDialog();
                f.Dispose();
                this.Visible = true;
                
        }

        private void frm_menu_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    btn_surtimiento_Click(this, EventArgs.Empty);  
                    break;
                case Keys.F10:
                    btn_salir_Click(this, EventArgs.Empty);  
                    break;                
                case Keys.F2:
                    //btn_validacion_Click(this, EventArgs.Empty);   
                    break;                
                //case Keys.F3:
                //    btn_cajas_Click(this, EventArgs.Empty);  
                //    break;
                //case Keys.F4:
                //    btn_cajas_Click(this, EventArgs.Empty);  
                //    break;
                default:
                    break;
            }
        }

        private void btn_validacion_Click(object sender, EventArgs e)
        {

        }

        private void btn_cajas_Click(object sender, EventArgs e)
        {

        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            try
            {
                if (Global.cn.State == ConnectionState.Open)
                {
                    Global.cn.Close();
                }

                if (Global.invcnbr != "")
                {
                    if (Global.verificar_factura_salida_usuario(Global.invcnbr))
                    {
                        Application.Exit();
                    }
                    else
                    {
                        MessageBox.Show("Error al cerrar sistema Notificar al Administrador ");
                        Application.Exit();

                    }
                }
                else
                {
                    Application.Exit();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cerrar sistema.." + ex.Message.ToString()); 
            }

            
             
            
        }

        private void btn_cambiar_secc_Click(object sender, EventArgs e)
        {
            Global.invcnbr = "";
            frm_seleccionar_areas_piciking f = new frm_seleccionar_areas_piciking();
            f.login = false;
            f.ShowDialog();
            f.Dispose();
            lista_zonas_usuario();
            
            
        }

        private void frm_menu_Closing(object sender, CancelEventArgs e)
        {
            //if (registrar_acceso(Global.usuario, Global.idzona, Global.area,2))
            //{
            //    Application.Exit();
            //}
            //else
            //{
            //    Application.Exit();
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                
                frm_seleccionar_picking f = new frm_seleccionar_picking();
                f.login = true;
                this.Close();
                f.Show();

            
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Exclamation.Play();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Asterisk.Play();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Beep.Play();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Hand.Play();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Question.Play();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
         

        }

        private void linkIndicadores_Click(object sender, EventArgs e)
        {
            frmIndicadores f = new frmIndicadores();
            f.ShowDialog(); 
        }
    }
}