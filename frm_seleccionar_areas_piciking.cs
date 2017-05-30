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
    public partial class frm_seleccionar_areas_piciking : Form
    {
        public frm_seleccionar_areas_piciking()
        {
            InitializeComponent();
        }

        public bool ok = false;

        public bool login = true;

        void lista_zonas_picking()
        {
            
            DataSet dt = new DataSet();
            dt = Global.lista_zonas_picking();
            lstv_a.Items.Clear();
            lstv_b.Items.Clear();
            if (dt != null)
            {
                if (dt.Tables.Count > 0)
                {
                    if (dt.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Tables[0].Rows)
                        {

                            if (!string.IsNullOrEmpty(dr["Zona"].ToString()))
                            {
                                ListViewItem l = new ListViewItem();
                                ListViewItem l1 = new ListViewItem();
                                l.Tag = dr["IdZona"].ToString();
                                l.Text = dr["Zona"].ToString();
                                l1.Tag = dr["IdZona"].ToString();
                                l1.Text = dr["Zona"].ToString();
                                lstv_a.Items.Add(l);
                                lstv_b.Items.Add(l1);
                            }
                        }
                    }
                }
            
            }
        
        }

        void lista_zonas_seleccionadas()
        {
            DataSet dt = new DataSet();
            
            dt = Global.lista_zonas_usuario();
            string zona = "";
            if (dt != null)
            {
                
                if (dt.Tables.Count > 0)
                {
                    if (dt.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Tables[0].Rows)
                        {
                            if (dr["Area"].ToString().Trim() == "A")
                            {
                                ListViewItem l = new ListViewItem();
                                 zona="ZONA" + dr["IdZona"].ToString().Trim();
                                l.Tag = dr["IdZona"].ToString().Trim();
                                l.Text=zona;
                                for (int i = 0; i < lstv_a.Items.Count; i++)
                                {
                                    if (lstv_a.Items[i].Text.Trim()==zona)
                                    {
                                        lstv_a.Items[i].Checked = true;
                                    }
                                }

                            }
                            else if (dr["Area"].ToString().Trim() == "B")
                            {
                                ListViewItem l = new ListViewItem();
                                zona = "ZONA" + dr["IdZona"].ToString().Trim();
                                l.Tag = dr["IdZona"].ToString().Trim();
                                l.Text = zona;

                                for (int i = 0; i < lstv_b.Items.Count; i++)
                                {
                                    if (lstv_b.Items[i].Text.Trim() == zona)
                                    {
                                        lstv_b.Items[i].Checked = true;
                                    }
                                }



                            }
                        }
                    }
                }
              
            }
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (login == true)
            {
                frm_seleccionar_picking f = new frm_seleccionar_picking();
                this.Close();
                
                f.ShowDialog();
               
            }
            else
            {
                this.Close();
            }
           
        }

        private void btn_continuar_Click(object sender, EventArgs e)
        {
          
            int tot = 0;
            foreach (ListViewItem l in lstv_b.Items)
            {
                if (l.Checked)
                {
                    tot++;

                }

            }

            foreach (ListViewItem l in lstv_a.Items)
            {
                if (l.Checked)
                {
                    tot++;

                }
            }


            if (tot <= 0)
            {
                MessageBox.Show("Seleccione las ZONAS de surtimiento correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            
            }


            Global.Eliminar_Zonas_Usuario(Global.usuario);
            //Lado a
            foreach (ListViewItem l in lstv_a.Items)
            {
                if (l.Checked)
                { 
                 tot++;
                 
                }

                Global.zonas_usuario_OP( int.Parse(l.Tag.ToString()), "A", l.Checked);

            }

            //Lado b

            foreach (ListViewItem l in lstv_b.Items)
            {
                if (l.Checked)
                {
                    tot++;

                }

                Global.zonas_usuario_OP(int.Parse(l.Tag.ToString()), "B", l.Checked);
            }

            

            if (login == true)
            {
                
                Global.orden_zona = Global.obtener_orden_surtimiento_picking1();
                frm_menu f = new frm_menu();
                f.Show();
                this.Close();
            }
            else
            {
                Global.orden_zona = Global.obtener_orden_surtimiento_picking1();
                this.Close();
            }

        }

        private void frm_seleccionar_areas_piciking_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.Default;
            lista_zonas_picking();
            lista_zonas_seleccionadas();
            btn_continuar.Focus();
        }

        private void btn_picking_Click(object sender, EventArgs e)
        {
            if (login == false)
            {
                string res = MessageBox.Show("Desea Cambiar de PICKING ?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2).ToString();
                if (res == "Yes")
                {
                    frm_supervisor f1 = new frm_supervisor();
                    this.Visible = false;
                    f1.ShowDialog();
                    if (f1.ok == true)
                    {
                        frm_seleccionar_picking f = new frm_seleccionar_picking();
                        this.Close();
                        f.Show();
                    }
                    else
                    {
                        this.Visible = true;
                    }


                }
            }
            else
            {
                frm_seleccionar_picking f = new frm_seleccionar_picking();
                f.login = true;
                this.Close();
                f.Show();
            }
        }


        private void btn_continuar_KeyDown(object sender, KeyEventArgs e)
        {
            //MessageBox.Show("Keycode: " + e.KeyCode.ToString() + ", KeyData: " + e.KeyData.ToString() + ", KeyValue: " + e.KeyValue.ToString());
            switch (e.KeyCode.ToString())
            {
                case "D1":
                    if (lstv_a.Items[0].Checked == true && lstv_b.Items[0].Checked == true)
                    {
                        lstv_a.Items[0].Checked = false;
                        lstv_b.Items[0].Checked = false;
                    }
                    else
                    {
                        lstv_a.Items[0].Checked = true;
                        lstv_b.Items[0].Checked = true;
                    }
                    break;
                case "D2":
                    if (lstv_a.Items[1].Checked == true && lstv_b.Items[1].Checked == true)
                    {
                        lstv_a.Items[1].Checked = false;
                        lstv_b.Items[1].Checked = false;
                    }
                    else
                    {
                        lstv_a.Items[1].Checked = true;
                        lstv_b.Items[1].Checked = true;
                    }
                    break;
                case "D3":
                    if (lstv_a.Items[2].Checked == true && lstv_b.Items[2].Checked == true)
                    {
                        lstv_a.Items[2].Checked = false;
                        lstv_b.Items[2].Checked = false;
                    }
                    else
                    {
                        lstv_a.Items[2].Checked = true;
                        lstv_b.Items[2].Checked = true;
                    }
                    break;
                case "D4":
                    if (lstv_a.Items[3].Checked == true && lstv_b.Items[3].Checked == true)
                    {
                        lstv_a.Items[3].Checked = false;
                        lstv_b.Items[3].Checked = false;
                    }
                    else
                    {
                        lstv_a.Items[3].Checked = true;
                        lstv_b.Items[3].Checked = true;
                    }
                    break;
                case "D5":
                    if (lstv_a.Items[4].Checked == true && lstv_b.Items[4].Checked == true)
                    {
                        lstv_a.Items[4].Checked = false;
                        lstv_b.Items[4].Checked = false;
                    }
                    else
                    {
                        lstv_a.Items[4].Checked = true;
                        lstv_b.Items[4].Checked = true;
                    }
                    break;
                case "D6":
                    if (lstv_a.Items[5].Checked == true && lstv_b.Items[5].Checked == true)
                    {
                        lstv_a.Items[5].Checked = false;
                        lstv_b.Items[5].Checked = false;
                    }
                    else
                    {
                        lstv_a.Items[5].Checked = true;
                        lstv_b.Items[5].Checked = true;
                    }
                    break;
                case "D7":
                    if (lstv_a.Items[6].Checked == true && lstv_b.Items[6].Checked == true)
                    {
                        lstv_a.Items[6].Checked = false;
                        lstv_b.Items[6].Checked = false;
                    }
                    else
                    {
                        lstv_a.Items[6].Checked = true;
                        lstv_b.Items[6].Checked = true;
                    }
                    break;
                case "D8":
                    if (lstv_a.Items[7].Checked == true && lstv_b.Items[7].Checked == true)
                    {
                        lstv_a.Items[7].Checked = false;
                        lstv_b.Items[7].Checked = false;
                    }
                    else
                    {
                        lstv_a.Items[7].Checked = true;
                        lstv_b.Items[7].Checked = true;
                    }
                    break;
                default:
                    break;
            }
        }

    }
}