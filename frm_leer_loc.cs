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
    public partial class frm_leer_loc : Form
    {
        public frm_leer_loc()
        {
            InitializeComponent();
        }
        public string invcnbr = "";
        public bool desbloq = false;
        public bool ok = false;
        static string localizacion="";

       // //declarar objetos Reader & ReaderData 
       //  Symbol.Barcode.Reader barcodeReader = null;
       //  Symbol.Barcode.ReaderData barcodeReaderData = null;

       // //barcodeReader.ReadNotify += new EventHandler(barcodeReader_Read);  //eventHandler se dispara cuando hay una lectura.
        
       // //EventHandler MyReadNotifyHandler = new EventHandler(MyReader_ReadNotify);
       // //EventHandler MyStatusNotifyHandler = new EventHandler(MyReader_StatusNotify);
       // //private System.EventHandler MyReadNotifyHandler = new EventHandler(MyReader_ReadNotify);
       // //private System.EventHandler MyStatusNotifyHandler = new EventHandler(MyReader_StatusNotify);
               

       // /// <summary>
       // /// Read notification handler
       // /// </summary>
       //private void MyReader_ReadNotify(object Sender, EventArgs e)
       // {
       //     // Get ReaderData.
       //     Symbol.Barcode.ReaderData nextReaderData = barcodeReader.GetNextReaderData();
       //     switch (nextReaderData.Result)
       //     {
       //         case Symbol.Results.SUCCESS:
       //             // Handle the data from this read.
       //             //string MessageToDisplay;
       //             //MessageToDisplay = TheReaderData.Source + ": '" + TheReaderData.Text + "'";
       //                //Issue a read request.
       //             if (nextReaderData.Text.Trim() != "")
       //             {
       //                 if (nextReaderData.Text.Trim() == localizacion)
       //                 {
                          
       //                 }
       //                 else
       //                 {
       //                     barcodeReader.Actions.Read(barcodeReaderData);
       //                 }
       //             }
       //             else
       //             {
       //                 barcodeReader.Actions.Read(barcodeReaderData);
       //             }
                  
       //             break;
       //         case Symbol.Results.CANCELED:
       //             break;
       //         default:
       //             //string sMsg = "Read Failed\n"
       //             //+ "Result = " + ((int)TheReaderData.Result).ToString("X8");
       //             break;
       //     }
       // }

       // void barcodeReader_Read(object sender, EventArgs e)
       // {
       //     Symbol.Barcode.ReaderData nextReaderData = barcodeReader.GetNextReaderData();  //Get(s)NextReaderData                        
       //     if (nextReaderData.Text.Trim() != "")
       //     {
                
       //         if (nextReaderData.Text.Trim() == lbl_loc.Text.Trim())
       //         {
       //             System.Media.SystemSounds.Asterisk.Play();
       //             timer1.Enabled = false;
       //             txt_loc.Text = "";
       //             txt_loc.Text = nextReaderData.Text.Trim();
       //             ok = true;
       //             btn_Cerrar_Click(this, EventArgs.Empty);
       //             //this.Close();
       //         }
       //         else
       //         {
       //             System.Media.SystemSounds.Exclamation.Play();
       //             MessageBox.Show("Localizacion no valida..");
       //             barcodeReader.Actions.Read(barcodeReaderData); //Espera para la siguiente lectura del lector.
       //         }
       //     }

       // }



       // /// <summary>
       // /// Status notification handler
       // /// </summary>
       // //static  void MyReader_StatusNotify(object Sender, EventArgs e)
       // //{
       // //    // Get current status. 
       // //    Symbol.Barcode.BarcodeStatus TheEvent = barcodeReader.GetNextStatus();   //

       // //    // Set event text in UI.
       // //    //this.EventTextBox.Text = TheEvent.Text;
       // //}

        


       
        public void btn_Cerrar_Click(object sender, EventArgs e)
        {           
            timer1.Enabled = false;          
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (txt_loc.BackColor != Color.Yellow)
            {
                txt_loc.BackColor = Color.Yellow;
                if (!desbloq)
                {
                    txt_loc.Text = "Esperando lectura";
                }
            }
            else
            {
                txt_loc.BackColor = Color.White;
                if (!desbloq)
                {
                    txt_loc.Text = "------------------------";
                }
            }
            txt_loc.Focus();
            txt_loc.SelectAll();
        }

        private void btnaceptar_Click(object sender, EventArgs e)
        {
            if (txt_loc.Text.Trim().ToUpper() != lbl_loc.Text.Trim())
            {
                MessageBox.Show("Localizacion no valida");
                txt_loc.Text = "";
                txt_loc.Focus();
            }
            else
            {
                ok = true;
                timer1.Enabled = false;               
                this.Close();
            }
        }

        private void frm_leer_loc_Closing(object sender, CancelEventArgs e)
        {
            try
            {
                timer1.Enabled = false;
                //Borrar la variables de la memoria
                //if (barcodeReader != null)
                //{                   
                //    // Remove read notification handler.                   
                //    barcodeReader.ReadNotify -= barcodeReader_Read;
                //    barcodeReader.Actions.Flush();
                //    barcodeReader.Actions.Disable();            
                //    barcodeReader.Dispose();
                //    barcodeReader = null; 
                  
                //}
                //// If we have a reader data. 
                //if (barcodeReaderData != null)
                //{
                //    // Free it up. 
                //    barcodeReaderData.Dispose();
                //    // Indicate we no longer have one. 
                //    barcodeReaderData = null;

                //}




            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al salir.." + ex.Message.ToString()  );  
            }
        }

        private void txt_loc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txt_loc.Text !="" )
            {
                if (txt_loc.Text.Trim().ToUpper() == lbl_loc.Text.Trim())
                {
                    ok = true;
                    timer1.Enabled = false;
                    //if (barcodeReader != null)
                    //{
                    //    try
                    //    {
                    //        barcodeReader.Actions.Flush();
                    //        barcodeReader.Actions.Disable();
                    //        barcodeReader.Dispose();
                    //        barcodeReaderData.Dispose();
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        MessageBox.Show("Error al desactivar scaner" + ex.Message.ToString());
                    //    }
                    //}

                    this.Close();
                }
                else
                {
                    txt_loc.Text = "";
                    txt_loc.Focus();  
                }
            }
            else
            {
                txt_loc.Focus(); 
            }
        }

        private void btn_guion_Click(object sender, EventArgs e)
        {
            //if (txt_loc.Text != "")
            //{
            //    txt_loc.Focus();
            //    //txt_loc. 
            //    txt_loc.Text = txt_loc.Text + "-";
            //    txt_loc.Focus();
                
            //}
            //else
            //{
            //    txt_loc.Focus();
            //    txt_loc.Text = txt_loc.Text + "-";
            //    txt_loc.Focus();

            //}
        }

        //private void btn_no_bin_Click(object sender, EventArgs e)
        //{
        //    if (lbl_loc.Text.Trim().ToUpper() == "NO_BIN")
        //    {
        //        timer1.Enabled = false;
        //        txt_loc.Focus();
        //        txt_loc.Text ="NO_BIN";
        //        //txt_loc.Focus();                
        //        this.Close();
        //    }
        //    else
        //    {
        //        txt_loc.Focus();
        //    }
        //}

        
        private void frm_leer_loc_Load(object sender, EventArgs e)
        {
            //verificar si existe excepcion registrada para la localizacio
            if (Global.VerificarExcepcionesLocalizacion(lbl_loc.Text.Trim()))
            {
                //activar el campo de lectura
                desbloq = true; 
                txt_loc.Enabled = true;
                txt_loc.ReadOnly = false;
                //btn_desbloq.Enabled = false;
                //btnaceptar.Enabled = true;  
                txt_loc.Focus(); 
            }
            else
            {
                //barcodeReader = new Symbol.Barcode.Reader();
                //sets up ReaderData to receive text and allocates max buffer size for barcode (7905 bytes).
                //barcodeReaderData = new Symbol.Barcode.ReaderData(Symbol.Barcode.ReaderDataTypes.Text, Symbol.Barcode.ReaderDataLengths.MaximumLabel);
                // Crear Data Reader
                //Symbol.Barcode.ReaderData MyReaderData = new Symbol.Barcode.ReaderData(Symbol.Barcode.ReaderDataTypes.Text, Symbol.Barcode.ReaderDataLengths.MaximumLabel);
                //barcodeReaderData = new Symbol.Barcode.ReaderData(Symbol.Barcode.ReaderDataTypes.Text, Symbol.Barcode.ReaderDataLengths.MaximumLabel);
                //barcodeReader.Actions.Enable();  //Activar el scanner.
                //barcodeReader.ReadNotify += new EventHandler(barcodeReader_Read);  //eventHandler se dispara cuando hay una lectura.
                //barcodeReader.Actions.Read(barcodeReaderData);  //Leer scnanner.  
            }
            txt_loc.Focus();
        }

        private void txt_loc_TextChanged(object sender, EventArgs e)
        {

        }
    }
}