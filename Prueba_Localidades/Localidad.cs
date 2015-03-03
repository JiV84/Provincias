using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prueba_Provincias
{
    public class Localidad
    {
        #region Campos
        private string _municipio;
        private string _codProvincia;
        private string _codPostal;
        #endregion

        #region Constructores
        public Localidad(string municipio, string codProvincia, string codPostal)
        {
            this.Municipio = municipio;
            this.CodProvincia = codProvincia;
            this.CodPostal = codPostal;
        } 
        #endregion

        #region Propiedades
        public string CodPostal
        {
            get { return _codPostal; }
            set { _codPostal = value ?? "ERROR"; }
        }

        public string Municipio
        {
            get
            {
                return _municipio;
            }
            set
            {
                _municipio = value;
            }
        }

        public string CodProvincia
        {
            get
            {
                return _codProvincia;
            }
            set
            {
                _codProvincia = value;
            }
        } 
        #endregion
    }
}
