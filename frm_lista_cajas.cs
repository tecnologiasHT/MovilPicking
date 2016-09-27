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
    public partial class frm_lista_cajas : Form
    {
        public frm_lista_cajas()
        {
            InitializeComponent();
        }
        public string tipo = "";
        public string caja = "";
        void lista_cajas_tipo()
        { 
        // ADN_lista_cajas_tipo    
        //@InvcNbr VARCHAR(20),
        //@Tipo VARCHAR(20)
           
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Global.cn;
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet dt=new DataSet();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_lista_cajas_tipo";
            cmd.Parameters.AddWithValue("@InvcNbr", Global.invcnbr);
            cmd.Parameters.AddWithValue("@Tipo", tipo);
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
                            lstcajas.DataSource = dt.Tables[0];
                            lstcajas.DisplayMember = "Numerocaja";
                            lstcajas.ValueMember = "Numerocaja";
                            if (lstcajas.Items.Count > 0)
                            {
                                lstcajas.SelectedIndex = -1;  
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener cajas.." + ex.Message.ToString());
            }



        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_lista_cajas_Load(object sender, EventArgs e)
        {
            lista_cajas_tipo();
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            if (tipo == "TARIMA")
            {
                string res = MessageBox.Show("Desea Agregar Tarima Para Surtir?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2).ToString();
                if (res == "Yes")
                {
                    string tarima = Global.obtener_tarima();
                    if (tarima != "0")
                    {                        
                        MessageBox.Show("Tarima # " + tarima, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        lista_cajas_tipo();                        
                    }
                    else
                    {
                        MessageBox.Show("No Hay Tarimas Para Surtir, Intente Otra Vez", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    }
                }

            }
            else
            {
                frm_cajas_picking f = new frm_cajas_picking();
                f.lbl_factura.Text = Global.invcnbr;
                f.invcnbr = Global.invcnbr;
                f.ShowDialog();
                f.Dispose();
                lista_cajas_tipo();
            }
        }

        private void btnsel_Click(object sender, EventArgs e)
        {
            if (lstcajas.SelectedIndex != -1)
            {
                caja=lstcajas.SelectedValue.ToString().Trim();
                this.Close();
 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_liberar_cajas f = new frm_liberar_cajas();
            f.ShowDialog();
            f.Dispose();
            lista_cajas_tipo();
        }
    }
}