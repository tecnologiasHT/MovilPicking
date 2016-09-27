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
    public partial class frm_detalle_factura : Form
    {
        public frm_detalle_factura()
        {
            InitializeComponent();
        }
        public string invcnbr;

        void detalle_factura()
        { 
         //obtiene el detalle de la factura especificada
         //ADN_factura_detalle 
         //@InvcNbr VARCHAR(20)
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter ad = new SqlDataAdapter();
            cmd.Connection = Global.cn;
            DataSet dt = new DataSet();
            //DataRow dr;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ADN_factura_detalle_movil";
            cmd.Parameters.AddWithValue("@InvcNbr", invcnbr);
            ad.SelectCommand = cmd;
            try
            {
                ad.Fill(dt);

                if (dt.Tables.Count != 0)
                {
                    if (dt.Tables[0].Rows.Count != 0)
                    {
                        dg_factura.DataSource = dt.Tables[0]; 
                         
                    }
                  
                }

            }
            catch
            { 
            
            }


        }

        private void frm_detalle_factura_Load(object sender, EventArgs e)
        {
            detalle_factura();
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            detalle_factura();
            //GridTableStylesCollection tb ;
           
 
        }
    }
}