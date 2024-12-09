using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocios
{
    public class EstilosNegocio
    {
        public List<Estilos> listar()
        {
            List<Estilos> lista = new List<Estilos> ();
            AccesoDatos datos = new AccesoDatos ();
            try
            {
                datos.Consulta("select id, Descripcion, RegionOrigen from ESTILOS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Estilos aux = new Estilos ();
                    aux.IdEstilo = (int)datos.Lector["id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.RegionOrigen = (string)datos.Lector["RegionOrigen"];
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
