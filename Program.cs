using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Picking
{
    
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
          //public string usuario;
        [MTAThread]
        static void Main()
        {
           //string usuario;
            Application.Run(new frm_login());
        }
    }
}