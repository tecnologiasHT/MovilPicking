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
    public partial class frm_sel_loc : Form
    {
        public frm_sel_loc()
        {
            InitializeComponent();
        }
        //SqlConnection cn = new SqlConnection(Properties.Resources.connectionstring);
        DataSet dt = new DataSet();

        //bool valida()
        //{ 
           
        //}

        void lista_localizaciones()
        {
            //ADN_localizaciones_articulo
            SqlCommand cmd = new SqlCommand();
            
            SqlDataAdapter da = new SqlDataAdapter();
            //DataRow dr;
            try
            {
                //Cursor.Current = Cursors.WaitCursor;              
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ADN_localizaciones_articulo";
                cmd.Connection = Global.cn;
                cmd.Parameters.AddWithValue("@Invtid",lbl_clave.Text.Trim()    );
                da.SelectCommand = cmd;
                da.Fill(dt);
                if (dt.Tables[0].Rows.Count != 0)
                {
                    dg_loc.DataSource = dt.Tables[0];
                   
                }
            }
            catch (Exception ex)
            {

            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            txt_loc.Text = "";
            dt.Dispose(); 
            this.Close();
        }

        private void frm_sel_loc_Load(object sender, EventArgs e)
        {
            lista_localizaciones();
            Cursor.Current = Cursors.Default;
            dg_loc.Focus();  
        }

        private void dg_loc_DoubleClick(object sender, EventArgs e)
        {
             MessageBox.Show( dg_loc[dg_loc.CurrentRowIndex, 1].ToString());
        }

        private void dg_loc_Click(object sender, EventArgs e)
        {
            dg_loc.Select(dg_loc.CurrentRowIndex);   
        }

        private void txt_loc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter  )
            {
                if (dg_loc.CurrentRowIndex != -1)
                {
                    if (txt_loc.Text != dg_loc[dg_loc.CurrentRowIndex, 0].ToString().Trim())
                    {
                        MessageBox.Show("Localizacion no valida");
                        txt_loc.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Localizacion no valida");
                    txt_loc.Focus();
                }


            }


        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (dg_loc.VisibleRowCount != 0)
            {
                if (txt_loc.Text == dg_loc[dg_loc.CurrentRowIndex, 0].ToString().Trim())
                {
                    this.Close(); 
                }
                else
                {
                    MessageBox.Show("Localizacion no valida");
                    txt_loc.Text = "";  
                    txt_loc.Focus();
                }

            }
            else
            {
                txt_loc.Text = "";  
                MessageBox.Show("Localizacion no valida, seleccione una localizacion");
                txt_loc.Focus();
            }

        }

        private void dg_loc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_loc.Text = "";  
                txt_loc.Focus();  
            }

        }

        private void txt_loc_GotFocus(object sender, EventArgs e)
        {
            txt_loc.BackColor = Color.Yellow;    
        }

        private void txt_loc_LostFocus(object sender, EventArgs e)
        {
            txt_loc.BackColor = Color.White;  
        }

        private void frm_sel_loc_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    tabControl1.SelectedIndex = 0;  
                    break;
                case Keys.F2:
                    tabControl1.SelectedIndex = 1;  
                    break;
                case Keys.F3:
                    btn_ok_Click(this, EventArgs.Empty);   
                    break;
                case Keys.F10:
                    this.Close(); 
                    break;
                default:
                    break;
            }


        }

      

       

       

    }
}