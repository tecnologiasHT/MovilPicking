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
    public partial class frm_desbloqearlocalizacion : Form
    {
        public frm_desbloqearlocalizacion()
        {
            InitializeComponent();
        }
        public Boolean ok = false;
        public string supervisor="";
        public string localizacion="";
        Global mod = new Global();

        void listaexcepciones()
        {
            DataTable dt = Global.ObtenerExcepcionesLocalizacion();
            if (dt != null)
            {  cbo_motivo.DataSource = dt;
                cbo_motivo.DisplayMember = "Excepcion";
                cbo_motivo.ValueMember = "IdExcepcion";
            }
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            ok = false; 
            this.Close();
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            if (cbo_motivo.Text != "")
            {
                string cad_comentario = "";
                if (txt_comentario.Text.Trim() != "")
                {
                    cad_comentario = txt_comentario.Text.Trim().ToUpper();
                }
                else
                {
                    cad_comentario = cbo_motivo.Text;
                }

                if (Global.registrar_log_eventos_supervisor(cbo_motivo.Text.Trim(),
                    cad_comentario,
                    Global.invcnbr,
                    Global.usuario,
                    localizacion,
                    supervisor
                    ))
                {
                    ok = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al registrar evento, intente nuevamente");
                }

            }
            else
            {
                MessageBox.Show("Error al registrar evento, el motivo no es valido");
            }
        }

        private void frm_desbloqearlocalizacion_Load(object sender, EventArgs e)
        {
            listaexcepciones();
        }
      
    }
}