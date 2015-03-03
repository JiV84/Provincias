using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Security.Permissions;

namespace Prueba_Provincias
{
    static class Program
    {
        static private GUI gui;
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        //[STAThread]
        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.ControlAppDomain)]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.Automatic);
            Application.Run(gui = new GUI());

        }
    }
}
