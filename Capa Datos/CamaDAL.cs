using Capá_Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class CamaDAL: CadenaDal
    {

        public List<CamaCLS> listarCama()
        {
            List<CamaCLS> lista = null;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspListarCama", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {
                            lista = new List<CamaCLS>();
                            CamaCLS oCamaCLS;
                            int posId = drd.GetOrdinal("IIDCAMA");
                            int posNombre = drd.GetOrdinal("nombre");
                            int posDescripcion = drd.GetOrdinal("descripcion");
                            while (drd.Read())
                            {
                                oCamaCLS = new CamaCLS();
                                oCamaCLS.idcama = drd.IsDBNull(posId) ? 0 : 
                                    drd.GetInt32(posId);
                                oCamaCLS.nombre = drd.IsDBNull(posNombre) ? "":
                                    drd.GetString(posNombre);
                                oCamaCLS.descripcion = drd.IsDBNull(posDescripcion) ? "No hay descripcion" :
                                    drd.GetString(posDescripcion);
                                lista.Add(oCamaCLS);
                            }
                        }
                    }


                    cn.Close();
                }
                catch (Exception ex)
                {
                    cn.Close();
                }

            }
            return lista;
        }
        public List<CamaCLS> filtrarCama(string nombrecama)
        {
            List<CamaCLS> lista = null;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspFiltarCama", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombrecama", nombrecama);
                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {
                            lista = new List<CamaCLS>();
                            CamaCLS oCamaCLS;
                            int posId = drd.GetOrdinal("IIDCAMA");
                            int posNombre = drd.GetOrdinal("nombre");
                            int posDescripcion = drd.GetOrdinal("descripcion");
                            while (drd.Read())
                            {
                                oCamaCLS = new CamaCLS();
                                oCamaCLS.idcama = drd.IsDBNull(posId) ? 0 :
                                    drd.GetInt32(posId);
                                oCamaCLS.nombre = drd.IsDBNull(posNombre) ? "" :
                                    drd.GetString(posNombre);
                                oCamaCLS.descripcion = drd.IsDBNull(posDescripcion) ? "No hay descripcion" :
                                    drd.GetString(posDescripcion);
                                lista.Add(oCamaCLS);
                            }
                        }
                    }


                    cn.Close();
                }
                catch (Exception ex)
                {
                    cn.Close();
                }

            }
            return lista;
        }
        public int guardarTipoCama(CamaCLS oCama)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspGuardarCama", cn))

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", oCama.idcama);
                        cmd.Parameters.AddWithValue("@nombre", oCama.nombre);
                        cmd.Parameters.AddWithValue("@descripcion", oCama.descripcion);
                        rpta = cmd.ExecuteNonQuery();
                        cn.Close();
                    }
                }
                catch (Exception ex)
                {
                    rpta = 0;
                    cn.Close();
                }
            }
            return rpta;

        }
        public int EliminarCama(int iidcama)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspEliminarCama", cn))

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", iidcama);

                        rpta = cmd.ExecuteNonQuery();
                        cn.Close();
                    }
                }
                catch (Exception ex)
                {
                    rpta = 0;
                    cn.Close();
                }
            }
            return rpta;

        }
    }
}
    
