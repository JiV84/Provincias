using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prueba_Provincias
{
    public class OrigenDatos
    {
        #region Campos
        private List<Provincia> provincias = new List<Provincia>();
        private DAOProvincia dao = new DAOProvincia();
        private static bool _conectado = false; 
        #endregion

        #region Eventos
        public event EventHandler OnBorrarProvincia;
        public event EventHandler OnAnadirProvincia;
        //public event EventHandler OnModificarProvincia;
        public event EventHandler OnDesconectar; 
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene el estado de conexión.
        /// </summary>
        public static bool Conectado
        {
            get { return OrigenDatos._conectado; }
            private set { OrigenDatos._conectado = value; }
        }
        public List<Provincia> Provincias
        {
            get
            {
                IEnumerable<Provincia> p;
                p = from pr in provincias
                    where pr.ProvinciaNombre != ""
                    select pr;

                return provincias = p.ToList();
            }
            set { provincias = value; }
        } 
        #endregion

        #region Métodos

        public List<Provincia> LeerDatos()
        {
            return provincias = dao.LeerDB();
        }

        public bool Conectar(string cadenaConexion)
        {
            if (this.dao.Conectar(cadenaConexion))
                return Conectado = true;
            return !Conectado;
        }

        public void DesconectarDB()
        {
            this.dao.Desconectar();
            Conectado = false;
            if (OnDesconectar != null)
                OnDesconectar(this, null);
        }

        public void BorrarProvincia(List<Provincia> provincia, string nombre)
        {
            try
            {
                this.dao.BorrarProvincia(provincia, nombre);
                if (OnBorrarProvincia != null)
                    OnBorrarProvincia(this, null);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool AnadirProvincia(List<Provincia> p, string n, string cod)
        {
            bool res = this.dao.AnadirProvincia(p, n, cod);
            if (OnAnadirProvincia != null && res)
                OnAnadirProvincia(this, null);
            return res;
        }

        //public List<object> FiltrarProvincias(List<object> lista, string filtro)
        //{
        //    return dao.FiltrarItems(lista, filtro);
        //}

        public List<Provincia> BuscarLocalidad(List<Provincia> lista, string localidad, out int cantidad)
        {
            return this.dao.BuscarLocalidad(lista, localidad, out cantidad);
        } 
        #endregion
    }
}
