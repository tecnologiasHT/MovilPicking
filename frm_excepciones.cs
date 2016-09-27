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
    public partial class frm_excepciones : Form
    {
        public frm_excepciones()
        {
            InitializeComponent();
        }

        public string invcnbr="";
        public string invtid="";
        public long ID_Surt_Art = 0;
        public string idexcepcion="";
        public bool OK = false; 
        bool registrar_excepcion(string supervisor)
        { 
        //ADN_registro_excepcion_articulo	
        //@InvcNbr varchar(20),
        //@ID_Surt_Art numeric(9),
        //@IdExcepcion int
            if (cboexcepciones.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el tipo de excepcion correctamente");
                cboexcepciones.Focus();
 
                return false;
            }
            SqlCommand cmd = new SqlCommand();           
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_registro_excepcion_articulo";
            cmd.Parameters.AddWithValue("@InvcNbr",invcnbr );
            cmd.Parameters.AddWithValue("@ID_Surt_Art",ID_Surt_Art);
            cmd.Parameters.AddWithValue("@IdExcepcion", cboexcepciones.SelectedValue.ToString() );
            cmd.Parameters.AddWithValue("@Supervisor", supervisor);
            

            cmd.Connection = Global.cn;
            if (Global.cn.State == ConnectionState.Closed)
            {
                Global.cn.Open();  
            }
            try
            {
                cmd.ExecuteNonQuery();
                idexcepcion = cboexcepciones.SelectedValue.ToString();
                return true;
            }
            catch 
            {
                return false;
            }
        
        }

        void lista_excepciones()
        { 
          //ADN_Lista_excepciones_proceso	
	      //@IdProceso int
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_Lista_excepciones_proceso";
            cmd.Parameters.AddWithValue("@IdProceso", Global.idproceso);  
            cmd.Connection = Global.cn;
            DataSet dt = new DataSet();
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
                            cboexcepciones.DataSource = dt.Tables[0];
                            cboexcepciones.DisplayMember = "Descr";
                            cboexcepciones.ValueMember = "IdExcepcion";  
                             
                        }
                    }

                }
            }
            catch 
            { 
            
            }
            


        }

        private void frm_excepciones_Load(object sender, EventArgs e)
        {
            lista_excepciones();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnaceptar_Click(object sender, EventArgs e)
        {
            if (txt_cve_sup.Text == "")
            {
                MessageBox.Show("Introduzca la clave del supervisor", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                txt_cve_sup.Focus(); 
                return;
 
            
            }
            else if (cboexcepciones.SelectedIndex == -1 || cboexcepciones.Text.Trim()==""  )
            {
                MessageBox.Show("Seleccione el tipo de excepcion correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                cboexcepciones.Focus();
                return;
            }


            string numnomina;

            Global.obtener_datos_supervisor(txt_cve_sup.Text.Trim().ToUpper(), out numnomina);

            if (numnomina != "")
            {
                if (registrar_excepcion(numnomina))
                {
                    OK = true;  
                    idexcepcion = cboexcepciones.SelectedValue.ToString().Trim(); ; 
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Clave de supervisor no valida", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                txt_cve_sup.Text = "";
                txt_cve_sup.Focus();
                return;
            
            }


        }

        private void txt_cve_sup_GotFocus(object sender, EventArgs e)
        {
            txt_cve_sup.BackColor = Color.Yellow;
  
        }

        private void txt_cve_sup_LostFocus(object sender, EventArgs e)
        {
            txt_cve_sup.BackColor = Color.White;
        }

        private void cboexcepciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboexcepciones.SelectedIndex != -1)
            {
                txt_cve_sup.Text = "";
                txt_cve_sup.Focus();                
            }
        }

        private void txt_cve_sup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txt_cve_sup.Text.Trim()!="" && cboexcepciones.Text !="")
            {
                btnaceptar_Click(this, EventArgs.Empty);
            }
        }
    }
}