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
                comando.CommandText = "select D.id, titulo, CantidadCanciones, URLimagentapa, D.IdEstilo, D.IdTipoEdicion,  E.Descripcion AS Descripcion_Genero, T.Descripcion AS Descripcion_Tipo, RegionOrigen from DISCOS D, ESTILOS E, TIPOSEDICION T where E.Id = D.IdEstilo and T.Id = D.IdTipoEdicion and Activo = 1";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Discos aux = new Discos();
                    //aux.Id = lector.GetInt32(0);
                    aux.Id = (int)lector["Id"];
                    aux.Titulo = (string)lector["titulo"];

                    // 2 Formas de validar Null (solo hacerlo no es not null en la db):
                    //if (!(lector.IsDBNull(lector.GetOrdinal("FechaLanzamiento"))))
                     //aux.FechaLanzamiento = (DateTime)lector["FechaLanzamiento"];

                    // la otra mas facil:
                    //if (!(lector["FechaLanzamiento"] is DBNull))
                    //aux.FechaLanzamiento = (DateTime)lector["FechaLanzamiento"];

                    aux.Canciones = lector.GetInt32(2);
                    if (!(lector["URLimagenTapa"] is DBNull))
                    aux.URLimagenTapa = (string)lector["URLimagenTapa"];
                    aux.Genero = new Estilos();
                    aux.Genero.IdEstilo = (int)lector["IdEstilo"];
                    aux.Genero.Descripcion = (string)lector["Descripcion_Genero"];
                    aux.RegionOrigen = new Estilos();
                    aux.RegionOrigen.Descripcion = (string)lector["RegionOrigen"];
                    aux.Tipo = new TiposEdicion();
                    aux.Tipo.IdTipoEdicion = (int)lector["IdTipoEdicion"];
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
                //datos.Consulta("insert into DISCOS (Titulo, CantidadCanciones, UrlImagenTapa, IdEstilo, IdTipoEdicion) values ('" + nuevo.Titulo +"', "+ nuevo.Canciones +", '"+ nuevo.URLimagenTapa +"', @IdEstilo, @IdTipoEdicion)");
                //datos.setParametro("@IdEstilo", nuevo.Genero.id);
                //datos.setParametro("@IdTipoEdicion", nuevo.Tipo.id);
                datos.Consulta("INSERT INTO DISCOS (Titulo, CantidadCanciones, UrlImagenTapa, IdEstilo, IdTipoEdicion) " +
            "VALUES (@Titulo, @CantidadCanciones, @UrlImagenTapa, @IdEstilo, @IdTipoEdicion)");

                datos.setParametro("@Titulo", nuevo.Titulo);
                datos.setParametro("@CantidadCanciones", nuevo.Canciones);
                datos.setParametro("@UrlImagenTapa", nuevo.URLimagenTapa);
                datos.setParametro("@IdEstilo", nuevo.Genero.IdEstilo);
                datos.setParametro("@IdTipoEdicion", nuevo.Tipo.IdTipoEdicion);
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
        public void modificar(Discos dis)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.Consulta("update DISCOS set Titulo = @titulo, CantidadCanciones = @canciones, UrlImagenTapa = @img, IdEstilo = @IdEstilo, IdTipoEdicion = @IdTipoEdicion where id = @Id");
                datos.setParametro("@titulo", dis.Titulo);
                //datos.setParametro("@fecha", dis.FechaLanzamiento);
                datos.setParametro("@canciones", dis.Canciones);
                datos.setParametro("@img", dis.URLimagenTapa);
                datos.setParametro("@IdEstilo", dis.Genero.IdEstilo);
                datos.setParametro("@IdTipoEdicion", dis.Tipo.IdTipoEdicion);
                datos.setParametro("@Id", dis.Id);

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
        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.Consulta("delete from DISCOS where Id = @id");
                datos.setParametro("@id", id);
                datos.ejectuarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void eliminarLogico(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.Consulta("update DISCOS set Activo = 0 where id = @id");
                datos.setParametro("@id", id);
                datos.ejectuarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Discos> filtrar(string campo, string criterio, string filtro)
        {
            List<Discos> lista = new List<Discos>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "select D.id, titulo, CantidadCanciones, URLimagentapa, D.IdEstilo, D.IdTipoEdicion,  E.Descripcion AS Descripcion_Genero, T.Descripcion AS Descripcion_Tipo, RegionOrigen from DISCOS D, ESTILOS E, TIPOSEDICION T where E.Id = D.IdEstilo and T.Id = D.IdTipoEdicion and Activo = 1 and ";
                if(campo == "Canciones")
                {
                    if (criterio == "Mas de")
                    {
                        consulta += "CantidadCanciones > " + filtro;
                    }
                    else if (criterio == "Menos de")
                    {
                        consulta += "CantidadCanciones < " + filtro;
                    }
                    else consulta += "CantidadCanciones = " + filtro;
                }
                else if (campo == "Titulo")
                {
                    if (criterio == "Empieza con")
                    {
                        consulta += "Titulo like '" + filtro + "%' ";
                    }
                    else if (criterio == "Termina con")
                    {
                        consulta += "Titulo like '%" + filtro + "' ";
                    }
                    else consulta += "Titulo like '%" + filtro + "%' ";
                }
                else
                {
                    if (criterio == "Empieza con")
                    {
                        consulta += "E.Descripcion like '" + filtro + "%' ";
                    }
                    else if (criterio == "Termina con")
                    {
                        consulta += "E.Descripcion like '%" + filtro + "' ";
                    }
                    else consulta += "E.Descripcion like '%" + filtro + "%' ";
                }
                datos.Consulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Discos aux = new Discos();
                    //aux.Id = lector.GetInt32(0);
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Titulo = (string)datos.Lector["titulo"];
                    aux.Canciones = datos.Lector.GetInt32(2);
                    if (!(datos.Lector["URLimagenTapa"] is DBNull))
                        aux.URLimagenTapa = (string)datos.Lector["URLimagenTapa"];
                    aux.Genero = new Estilos();
                    aux.Genero.IdEstilo = (int)datos.Lector["IdEstilo"];
                    aux.Genero.Descripcion = (string)datos.Lector["Descripcion_Genero"];
                    aux.RegionOrigen = new Estilos();
                    aux.RegionOrigen.Descripcion = (string)datos.Lector["RegionOrigen"];
                    aux.Tipo = new TiposEdicion();
                    aux.Tipo.IdTipoEdicion = (int)datos.Lector["IdTipoEdicion"];
                    aux.Tipo.Descripcion = (string)datos.Lector["Descripcion_Tipo"];

                    lista.Add(aux);
                }

                return lista;
            }
     
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
