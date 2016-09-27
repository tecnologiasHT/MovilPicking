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
    public partial class frm_time_out : Form
    {
        public frm_time_out()
        {
            InitializeComponent();
        }

        public int tot_secs=0;
        public string InvcNbr = "";
        public string localizacion = "";
        //web service para el envio de mensajes de correo
        PickingWS.WebService1 ws = new Picking.PickingWS.WebService1();

        private void button1_Click(object sender, EventArgs e)
        {
            Global.fecha_ultima_actividad = Global.FechaHoraActual();
            Global.timeout = false;
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tot_secs ++;
            lbl_sec.Text = tot_secs.ToString();
            System.Media.SystemSounds.Exclamation.Play();
            if (tot_secs == 10)
            {
                timer1.Enabled = false; 
                Global.timeout = true;
                this.Close();
            }
        }

        private void frm_time_out_Closing(object sender, CancelEventArgs e)
        {
            timer1.Enabled = false;  
        }

        private void frm_time_out_Load(object sender, EventArgs e)
        {
            string cad_usuario = "";
            cad_usuario = Global.usuario;
            cad_usuario = cad_usuario + "-" + Global.NombreUsuario(Global.usuario);
            int tot = Global.tot_minutos_timeout();
            if (Global.agregar_log_eventos("INACTIVIDAD", "EL USUARIO  TIENE MAS DE " + tot.ToString()  + " MINUTOS SIN ACTIVIDAD", InvcNbr, Global.usuario, localizacion))
            {
                //Global.enviar_mensaje_evento("INACTIVIDAD",
                //    "EL USUARIO  TIENE MAS DE 5 MINUTOS SIN ACTIVIDAD",
                //    "AVISO USUARIO SIN ACTIVIDAD: " + cad_usuario,
                //    Global.idzona.ToString(),
                //    Global.picking.ToString(),
                //    Global.area,
                //    localizacion,
                //    InvcNbr,
                //    Global.usuario
                //    );

                ws.enviar_mensaje_evento(
                "INACTIVIDAD",
                "EL USUARIO  TIENE MAS DE " + tot.ToString() + " MINUTOS SIN ACTIVIDAD",
                "AVISO USUARIO SIN ACTIVIDAD: " + cad_usuario,
                Global.idzona.ToString(),
                Global.picking.ToString(),
                Global.area,
                "",
                Global.invcnbr,
                Global.usuario
                ); 


            }


        }
    }
}