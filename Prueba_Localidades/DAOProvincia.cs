using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Prueba_Provincias
{
    public class ErrorDeConexion : Exception
    {
        public ErrorDeConexion(string msg) : base(msg) { }
    }

    public class DAOProvincia
    {
        #region Campos
        private enum TipoError { ErrorContrasena = 0, ErrorConexion = 1, Desconocido };
        private MySqlConnection conexion;
        #endregion

        #region Métodos

        /// <summary>
        /// Conecta a la base de datos
        /// </summary>
        /// <returns></returns>
        public bool Conectar(string cadenaConexion)
        {
            TipoError error = TipoError.Desconocido;
            try
            {
                this.conexion = new MySqlConnection(cadenaConexion);
                this.conexion.Open();
                return true;
            }
            catch (MySqlException e)
            {
                if (e.Number == 0)
                    error = TipoError.ErrorContrasena;
                else if (e.Number == 1)
                    error = TipoError.ErrorConexion;
                else
                    error = TipoError.Desconocido;

                switch (error)
                {
                    case TipoError.ErrorContrasena:
                        throw new ErrorDeConexion("Usuario o contraseña incorrectos");
                    case TipoError.ErrorConexion:
                        throw new ErrorDeConexion("Error en la conexión");
                    case TipoError.Desconocido:
                        throw;
                    default:
                        throw;
                }
            }
        }
        /// <summary>
        /// Desconectar la conexión de la db
        /// </summary>
        public void Desconectar()
        {
            this.conexion.Close();
        }

        public void BorrarProvincia(List<Provincia> provincia, string codigo)
        {
            try
            {
                provincia.Remove(provincia.First(item => item.CodProvincia == codigo));
            }
            catch (Exception ex)
            {
                string msg = string.Empty;
                if (ex is InvalidOperationException)
                    msg = "No se ha podido realizar la operación";
                else
                    msg = ex.Message;
                throw new Exception(msg);
            }
        }

        public bool AnadirProvincia(List<Provincia> provincias, string nombre, string codigo)
        {
            bool existe = provincias.Exists(item => item.CodProvincia == codigo);
            if (!existe)
                provincias.Add(new Provincia(nombre, codigo));
            return !(existe);
        }

        public List<Provincia> LeerDB()
        {
            List<Provincia> provincias = new List<Provincia>();
            List<Localidad> localidades = new List<Localidad>();

            string query = "select municipio, codprov, codpostal from localidades";
            string query2 = "select provincia, codprov from provincias";

            MySqlCommand cmd = new MySqlCommand(query, this.conexion);
            MySqlDataReader lector = cmd.ExecuteReader();

            //Primero se llena la lista de localidades.
            while (lector.Read())
                localidades.Add(new Localidad(lector["municipio"].ToString(), lector["codprov"].ToString(), lector["codpostal"].ToString()));

            lector.Close();

            //Se cambia la consulta para leer las provincias.
            cmd = new MySqlCommand(query2, conexion);
            lector = cmd.ExecuteReader();

            //Se llena la lista de provincias.
            while (lector.Read())
                provincias.Add(new Provincia(lector["provincia"].ToString(), lector["codprov"].ToString())); //Se omite la lista de localidades a propósito.

            //Ahora se realiza el filtrado para enlazar cada provincia con su lista de localidades mediante claves.            
            foreach (var prov in provincias)
                foreach (var loc in localidades)
                    if (prov.CodProvincia == loc.CodProvincia)
                    {
                        if (prov.Localidades == null) //No deberia ocurrir nunca.
                            prov.Localidades = new List<Localidad>();
                        prov.Localidades.Add(loc);
                    }

            lector.Close();
            return provincias;
        }

        public List<Provincia> BuscarLocalidad(List<Provincia> lista, string localidad, out int cantidad)
        {
            cantidad = 0;

            if (localidad == "")
                return null; //fuera bisho.

            List<Provincia> p = new List<Provincia>();
            List<Localidad> l = new List<Localidad>();
            //Se obtiene la lista de provincias y localidades que cumplen con el predicado y no están repetidas.
            foreach (var item in lista)
                foreach (var local in item.Localidades)
                    if (local.Municipio.Contains(localidad))
                    {
                        if (!p.Exists(x => x.ProvinciaNombre == item.ProvinciaNombre))                        
                            p.Add(new Provincia(item.ProvinciaNombre, item.CodProvincia)); //Evitar que modifique la lista original copiando a una nueva.                       
                        if (!l.Exists(x => x.Municipio == local.Municipio))
                            l.Add(new Localidad(local.Municipio, local.CodProvincia, local.CodPostal)); //idem.
                    }

            int limiteLoc;
            int limiteProv;

            //Si es 0, fuera.
            if (p.Count > 0)
            {
                limiteLoc = l.Count;
                limiteProv = p.Count;

                //Se reinicia la lista de localidades de cada provincia obtenida.
                foreach (var item in p)
                    item.Localidades = new List<Localidad>();

                //Se necesita for porque se está modificando la lista que se itera.
                //Se le asigna a cada provincia su nueva lista de localidades mediante sus claves.
                for (int i = 0; i < limiteProv; i++)
                    for (int j = 0; j < limiteLoc; j++)
                        if (p[i].CodProvincia == l[j].CodProvincia)
                            p[i].Localidades.Add(l[j]);
            }
            else
                return null;

            cantidad = l.Count;
            return p;
        } 
        #endregion        
    }
}
