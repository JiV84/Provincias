using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Permissions;

namespace Prueba_Provincias
{
    public partial class GUI : Form
    {
        #region Campos
        internal AppDomain Dominio = AppDomain.CurrentDomain;
        private OrigenDatos datos = new OrigenDatos();
        private ConfigConexion config;
        private enum Estado { SinConexion, Conectado, Error, Desconectado };
        private enum TipoError { MySql, Otro };
        private static bool mostrandoMaxCodigo = false;
        private static bool cargado = false; 
        #endregion

        #region Constructor
        public GUI()
        {
            InitializeComponent();
            datos.OnAnadirProvincia += dao_OnAnadirProvincia;
            datos.OnBorrarProvincia += dao_OnBorrarProvincia;
            datos.OnDesconectar += datos_OnDesconectar;
            Dominio.UnhandledException += Dominio_UnhandledException;
        } 
        #endregion

        #region Eventos
        void datos_OnDesconectar(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
            this.listBox2.Items.Clear();
            this.textBox2.Clear();
            this.label3.ForeColor = Color.Black;
            this.label3.Text = Estado.Desconectado.ToString();
        }

        void Dominio_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            MessageBox.Show(ex.ToString()); //Si ocurre una excepción no controlada , mostrará el mensaje debug en la pantalla.
        }

        void dao_OnBorrarProvincia(object sender, EventArgs e)
        {
            doCargarListbox();
        }

        void dao_OnAnadirProvincia(object sender, EventArgs e)
        {
            doCargarListbox();
        }
        /// <summary>
        /// Este evento muestra la lista de localidades de cada provincia
        /// al cambiar / seleccionar una provincia de la lista.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.listBox2.Items.Clear();
            this.textBox2.Clear();
            string localidad = string.Empty;
            int cantidad;//Para poder llamar al método buscar.
            List<Provincia> l = datos.BuscarLocalidad(this.datos.Provincias, this.textBox4.Text, out cantidad);

            //Estamos mostrando la lista localidades encontradas.
            if (this.textBox4.Text != "" && l != null)
            {
                foreach (var lis in listBox1.SelectedItems)
                    foreach (var provincia in l)
                        foreach (var loc in provincia.Localidades)
                            if (lis.ToString() == provincia.ProvinciaNombre)
                            {
                                localidad = string.Format("{0}", loc.Municipio);
                                this.listBox2.Items.Add(localidad);
                            }
            }
            else //Estamos mostrando la lista localidades completas.
            {
                foreach (var lis in listBox1.SelectedItems)
                    foreach (var provincia in datos.Provincias)
                        foreach (var loc in provincia.Localidades)
                            if (lis.ToString() == provincia.ProvinciaNombre)
                            {
                                localidad = string.Format("{0}", loc.Municipio);
                                this.listBox2.Items.Add(localidad);
                            }
            }

            this.textBox5.Clear();

            try
            {
                this.textBox2.Paste(datos.Provincias.First(item => item.ProvinciaNombre == this.listBox1.SelectedItem.ToString()).CodProvincia);
                mostrandoMaxCodigo = false;
            }
            catch (Exception)
            {
                //A veces no selecciona bien.
            }

        }

        private void button1_Click(object sender, EventArgs e) //Borrar provincia
        {
            DialogResult res;
            string str = string.Empty;

            try
            {
                if (listBox1.SelectedItem != null)
                {
                    str = string.Format("Se borrará la provincia {0}, está seguro? S/N", listBox1.SelectedItem);
                    res = MessageBox.Show(this, str, "Atención!", MessageBoxButtons.YesNoCancel);

                    if (res == DialogResult.Yes)
                        datos.BorrarProvincia(datos.Provincias, this.textBox2.Text);
                }
                else
                    MessageBox.Show(this, "Debes seleccionar una provincia de la lista", "Aviso");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "ERROR");
            }
        }

        private void button2_Click(object sender, EventArgs e) //Conectar
        {
            Estado estado = Estado.SinConexion;
            TipoError error = TipoError.Otro;

            try
            {
                //no debe conectar si ya está conectado.
                if (OrigenDatos.Conectado)
                    MessageBox.Show(this, "Ya está conectado", "Aviso");

                else if (datos.Conectar(ConfigConexion.datosConexion.CadenaConexion)) //Si no conecta la excepción abajo.
                {
                    MessageBox.Show(this, "Conexión establecida con éxito", "MySqlMensaje");
                    doCargarListbox(true);
                    estado = Estado.Conectado;
                }
            }
            catch (Exception ex)
            {
                estado = Estado.Error;

                if (ex is ErrorDeConexion)
                    error = TipoError.MySql;

                switch (error)
                {
                    case TipoError.MySql:
                        MessageBox.Show(this, ex.Message, "MySqlERROR");
                        break;
                    case TipoError.Otro:
                        MessageBox.Show(this, ex.Message, "ERROR");
                        break;
                    default:
                        break;
                }
            }

            switch (estado)
            {
                case Estado.Conectado:
                    this.label3.Text = "Conectado";
                    this.label3.ForeColor = Color.Green;
                    break;
                case Estado.Error:
                    this.label3.Text = "Error en la conexión";
                    this.label3.ForeColor = Color.Red;
                    break;
                default:
                    break;
            }
        }

        private void button3_Click(object sender, EventArgs e) //Abrir configuración de conexion
        {
            config = new ConfigConexion();
            config.Show();
        }

        private void AnadirProvincia_Click(object sender, EventArgs e)
        {
            string nombre = this.textBox1.Text;
            string codigo = this.textBox2.Text;

            if (OrigenDatos.Conectado && this.textBox1.Text != "")
            {
                if (datos.AnadirProvincia(datos.Provincias, nombre, codigo))
                {
                    this.textBox1.Clear();
                    mostrandoMaxCodigo = false;
                }
                else
                    MessageBox.Show(this, "El código de provincia ya existe", "ERROR");
            }
            else
                MessageBox.Show(this, "No hay conexión o el nombre introducido es erróneo", "ERROR");
        }
        /// <summary>
        /// Este evento filtra en tiempo real las provincias según el texto
        /// que se vaya escribiendo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (OrigenDatos.Conectado)
            {
                if (textBox3.Text == "")
                {
                    if (!cargado)
                    {
                        doCargarListbox();
                        cargado = true;
                    }
                }
                else
                {
                    FiltrarItems();
                    cargado = false;
                }
            }
        }
        /// <summary>
        /// Este evento muestra el código máximo + 1 cuando se escribe en el textbox de 
        /// añadir provincia.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string texto = this.textBox2.Text;
            int maxcod = int.Parse(texto == "" ? "00" : texto); //El texto no puede ser ""     

            //this.textBox2.Clear();
            doCargarListbox();

            if (!mostrandoMaxCodigo)
            {
                foreach (var item in datos.Provincias)
                {
                    if (int.Parse(item.CodProvincia) > maxcod)
                        maxcod = int.Parse(item.CodProvincia);
                }
                if (this.textBox2.Text == "" && this.listBox1.Items != null)
                    this.listBox1.SelectedIndex = this.listBox1.Items.Count - 1;//ex
                else
                {
                    this.textBox2.Clear();
                    this.textBox2.Paste((maxcod + 1).ToString());
                    mostrandoMaxCodigo = true;
                }

            }
        }
        /// <summary>
        /// Este evento activa otro evento al hacer click en el textbox 3
        /// que hacer cargar la lista y realizar de nuevo el filtrado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            this.textBox3_TextChanged(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)//Desconectar
        {
            if (OrigenDatos.Conectado)
                datos.DesconectarDB();
            else
                MessageBox.Show(this, "No hay conexión", "ERROR");
        }

        private void button5_Click(object sender, EventArgs e)//Buscar localidad
        {
            string filtro = this.textBox4.Text;
            List<Provincia> l = null;
            int cantidad = 0;
            if (filtro == "")
                doCargarListbox();
            else
                l = datos.BuscarLocalidad(this.datos.Provincias, this.textBox4.Text, out cantidad);

            if (l != null)
            {
                this.listBox1.Items.Clear();
                this.listBox2.Items.Clear();

                foreach (var item in l)
                    this.listBox1.Items.Add(item.ProvinciaNombre);
            }

            this.label7.Text = string.Format("{0} resultados", cantidad);
        }
        /// <summary>
        /// Evento que añade el Código postal de una localidad en pantalla automáticamente 
        /// al seleccionarla.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var item in this.listBox2.SelectedItems)
                foreach (var provincia in this.datos.Provincias)
                    foreach (var localidad in provincia.Localidades)
                        if (localidad.Municipio == item.ToString())
                        {
                            this.textBox5.Clear();
                            this.textBox5.Paste(localidad.CodPostal);
                        }
        } 
        #endregion

        #region Métodos
        private void doCargarListbox()
        {
            this.listBox1.Items.Clear();
            this.listBox2.Items.Clear();

            if (OrigenDatos.Conectado)
            {
                foreach (var item in datos.Provincias)
                    this.listBox1.Items.Add(item.ProvinciaNombre);
                cargado = true;
            }
        }

        private void doCargarListbox(bool inicio)
        {
            this.listBox1.Items.Clear();
            this.listBox2.Items.Clear();

            if (OrigenDatos.Conectado)
            {
                foreach (var item in datos.LeerDatos())
                    this.listBox1.Items.Add(item.ProvinciaNombre);
                cargado = true;
            }
        }

        private void FiltrarItems()
        {
            string filtro = this.textBox3.Text;
            List<object> lista = new List<object>();
            doCargarListbox();

            foreach (var item in listBox1.Items)
                if (item.ToString().StartsWith(filtro))
                    lista.Add(item);

            this.listBox1.Items.Clear();
            this.listBox2.Items.Clear();
            this.listBox1.Items.AddRange(lista.ToArray());
        }         
        #endregion
    }
}
