using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocios
{
    public class DiscosNegocio
    {
        public List<Discos> listar()
        {
            List<Discos> lista = new List<Discos>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=DISCOS_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select D.id, titulo, CantidadCanciones, URLimagentapa, E.Descripcion AS Descripcion_Genero, T.Descripcion AS Descripcion_Tipo, RegionOrigen from DISCOS D, ESTILOS E, TIPOSEDICION T where E.Id = D.IdEstilo and T.Id = D.IdTipoEdicion";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Discos aux = new Discos();
                    aux.Id = lector.GetInt32(0);
                    aux.Titulo = (string)lector["titulo"];
                    aux.Canciones = lector.GetInt32(2);
                    aux.URLimagenTapa = (string)lector["URLimagenTapa"];
                    aux.Genero = new Estilos();
                    aux.Genero.descripcion = (string)lector["Descripcion_Genero"];
                    aux.RegionOrigen = new Estilos();
                    aux.RegionOrigen.descripcion = (string)lector["RegionOrigen"];
                    aux.Tipo = new TiposEdicion();
                    aux.Tipo.Descripcion = (string)lector["Descripcion_Tipo"];

                    lista.Add(aux);
                }
                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void agregarDisco(Discos nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.Consulta("insert into DISCOS (Titulo, CantidadCanciones, UrlImagenTapa," +
                    "IdEstilo, IdTipoEdicion) values ('" + nuevo.Titulo +"', "+ nuevo.Canciones +", '"+ nuevo.URLimagenTapa +"', @IdEstilo, @IdTipoEdicion)");
                datos.setParametro("@IdEstilo", nuevo.Genero.id);
                datos.setParametro("@IdTiposEdicion", nuevo.Tipo.id);
                datos.ejectuarAccion();
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
