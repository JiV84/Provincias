using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prueba_Provincias
{
    /// <summary>
    /// Registro para almacenar los datos 
    /// de conexión.
    /// </summary>
    public struct DatosConexion
    {
        #region Campos
        private string host;
        private string baseDatos;
        private string user;
        private string pass;      
        #endregion   

        #region Propiedades
        public string Host
        {
            get { return host; }
            set { host = value; }
        }

        public string BaseDatos
        {
            get { return baseDatos; }
            set { baseDatos = value; }
        }

        public string User
        {
            get { return user; }
            set { user = value; }
        }

        public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }
        /// <summary>
        /// Propiedad de Solo Lectura que devuelve una cadena de conexión
        /// en formato MySql.
        /// </summary>
        public string CadenaConexion
        {
            get
            {
                return string.Format(
                    "server={0};database={1};uid={2};pwd={3}",
                    this.Host,
                    this.BaseDatos,
                    this.User,
                    this.Pass);
            }
        } 
        #endregion
    }
}
