using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace Prueba_Provincias
{
    /// <summary>
    /// Interfaz de configuración de datos
    /// para la conexión a la Base de datos.
    /// </summary>
    public partial class ConfigConexion : Form
    {
        readonly private static string fichero = @Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar.ToString() + "conexion.txt";
        private StreamReader leer;
        private StreamWriter escribir;
        public static DatosConexion datosConexion = new DatosConexion();

        public ConfigConexion()
        {
            InitializeComponent();
            LeerFichero();            
        }

        private void SetDatosDeConexion()
        {
            datosConexion.Host = this.textBox1.Text;
            datosConexion.BaseDatos = this.textBox2.Text;
            datosConexion.User = this.textBox3.Text;
            datosConexion.Pass = this.textBox4.Text;
        }

        private void LeerFichero()
        {
            if (!File.Exists(fichero))
            {
                escribir = new StreamWriter(fichero);
                escribir.Close();
            }
            leer = new StreamReader(fichero);
            this.textBox1.Text = leer.ReadLine();
            this.textBox2.Text = leer.ReadLine();
            this.textBox3.Text = leer.ReadLine();
            //this.textBox4.Text = leer.ReadLine(); NO pass
            leer.Close();
        }
        private void button1_Click(object sender, EventArgs e) //Guardar.
        {
            GuardarFichero();
            SetDatosDeConexion();
            this.Close();            
        }

        private void GuardarFichero()
        {
            escribir = new StreamWriter(fichero);
            escribir.Flush();
            escribir.WriteLine(this.textBox1.Text);
            escribir.WriteLine(this.textBox2.Text);
            escribir.WriteLine(this.textBox3.Text);
            //escribir.WriteLine(this.textBox4.Text); NO pass
            escribir.Close();
        }
    }
}
