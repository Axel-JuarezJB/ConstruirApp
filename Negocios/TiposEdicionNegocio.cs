using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocios
{
    public class TiposEdicionNegocio
    {
        public List<TiposEdicion> listar()
        {
            List<TiposEdicion> lista = new List<TiposEdicion>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.Consulta("select id, Descripcion from TIPOSEDICION");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    TiposEdicion aux = new TiposEdicion();
                    aux.IdTipoEdicion = (int)datos.Lector["id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerarConexion();
            }
        }
    }
}
