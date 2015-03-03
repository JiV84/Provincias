using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prueba_Provincias
{
    public class Provincia
    {
        #region Campos
        private string _provincia;
        private string _codProvincia;
        private List<Localidad> _localidades = new List<Localidad>(); 
        #endregion

        #region Propiedades
        public List<Localidad> Localidades
        {
            get { return this._localidades; }
            set { _localidades = value; }
        }

        public string CodProvincia
        {
            get { return _codProvincia; }
            set { _codProvincia = value; }
        }

        public string ProvinciaNombre
        {
            get { return _provincia; }
            set { _provincia = value; }
        } 
        #endregion

        #region Constructores
        /// <summary>
        /// Este constructor permite crear una provincia con 0 o n localidades, separadas por comas en el ultimo parámetro.
        /// Si el numero de localidades es 0 , se omite el parámetro
        /// </summary>
        /// <param name="provincia"></param>
        /// <param name="codProvincia"></param>
        /// <param name="localidades"></param>
        public Provincia(string provincia, string codProvincia, params Localidad[] localidades)
        {
            this.ProvinciaNombre = provincia;
            this.CodProvincia = codProvincia;
            this.Localidades = new List<Localidad>(localidades); //Constructor de colección, da memoria a la lista incluso si se ignora el parámetro.
        }
        /// <summary>
        /// Este constructor requiere una lista de localidades obligatoriamente.
        /// Usar este constructor cuando se tenga una lista de localidades.
        /// </summary>
        /// <param name="provincia"></param>
        /// <param name="codProvincia"></param>
        /// <param name="localidades"></param>
        public Provincia(string provincia, string codProvincia, List<Localidad> localidades)
        {
            this.ProvinciaNombre = provincia;
            this.CodProvincia = codProvincia;
            this.Localidades = localidades;
        }         
        #endregion
    }
}
