using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Picking
{
    public partial class frm_seleccionar_picking : Form
    {
        public frm_seleccionar_picking()
        {
            InitializeComponent();
        }

        public bool login = true;
        public int picking = 0;
        public bool ok = false;

        private void btn_salir_Click(object sender, EventArgs e)
        {
            if (login == true)
            {
                Application.Exit();
               
            }
            else
            {
                
                this.Close();
                
            }
        }

        private void btn_picking1_Click(object sender, EventArgs e)
        {           
                if (login == true)
                {                    
                    Global.picking = 1;
                    Global.cajap2 = "";
                    this.Close();
                    frm_seleccionar_areas_piciking f = new frm_seleccionar_areas_piciking();
                    f.Show();
                    
                }
                else if (Global.picking == 2)
                {
                        if (Global.invcnbr != "")
                        {
                            MessageBox.Show("Tiene una factura pendiente en PICKING2 " + Global.invcnbr);
                            return;
                        }
                        else
                        {
                            frm_supervisor f1 = new frm_supervisor();
                            this.Hide();
                            f1.ShowDialog();
                            if (f1.ok)
                            {
                                Global.picking = 1;
                                Global.cajap2 = "";
                                frm_menu f = new frm_menu();
                                f.login = false;
                                this.Close();
                                f.Show();
                            }
                            else
                            {
                                this.Show();
                            }
                        }
                    
                }
            

        }

        private void btn_picking2_Click(object sender, EventArgs e)
        {
            if (login == true)
            {
                Global.Eliminar_Zonas_Usuario(Global.usuario);
                Global.picking = 2;
                Global.orden_zona = 2;
                //frmIndicadores f1 = new frmIndicadores();
                //f1.ShowDialog();
                frm_menu f = new frm_menu();
                f.login = true;
                this.Close();
                f.Show();             
                return;


            }
            else
            {
                if (Global.picking == 1)
                {
                    
                    frm_supervisor f1 = new frm_supervisor();
                    this.Hide();
                    f1.ShowDialog();
                    if (f1.ok)
                    {
                        if (Global.invcnbr != "")
                        {                            
                           Global.verificar_factura_salida_usuario(Global.invcnbr);

                        }
                        Global.Eliminar_Zonas_Usuario(Global.usuario);
                        Global.picking = 2;
                        Global.orden_zona = 2;
                        frm_menu f = new frm_menu();
                        f.login = false;
                        this.Close();
                        f.Show();
                    }
                    else
                    {
                        this.Show();
                    }                    
                }
                else
                {
                    Global.Eliminar_Zonas_Usuario(Global.usuario);
                    Global.picking = 2;
                    Global.orden_zona = 2;
                    frm_menu f = new frm_menu();
                    f.login = false;
                    this.Close();
                    f.Show();

                }            
            
            }

        }

    }
}