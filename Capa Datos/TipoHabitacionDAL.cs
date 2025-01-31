using Capá_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
namespace Capa_Datos
   
{
    public class TipoHabitacionDAL: CadenaDal
    {
        public List<TipoHabitacionCLS> listarTipoHabitacion()
        {
            List<TipoHabitacionCLS> lista = null;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspListarTipoHabitacion", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader drd = cmd.ExecuteReader();
                        if(drd != null)
                        {
                            lista = new List<TipoHabitacionCLS>();
                            TipoHabitacionCLS oTipoHabitacionCLS;
                            int posId = drd.GetOrdinal("IIDTIPOHABILITACION");
                            int posNombre = drd.GetOrdinal("nombre");
                            int posDescripcion = drd.GetOrdinal("descripcion");
                            while (drd.Read())
                            {
                                oTipoHabitacionCLS = new TipoHabitacionCLS();
                                oTipoHabitacionCLS.id = drd.IsDBNull(posId)? 0: drd.GetInt32(posId);
                                oTipoHabitacionCLS.nombre = drd.IsDBNull(posNombre) ? "No hay nombre" : drd.GetString(posNombre);
                                oTipoHabitacionCLS.descripcion = drd.IsDBNull(posDescripcion) ? "No hay descripcion": drd.GetString(posDescripcion);
                                lista.Add(oTipoHabitacionCLS);
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

        public TipoHabitacionCLS recuperarTipoHabitacion(int id)
        {
            TipoHabitacionCLS oTipoHabitacionCLS=null;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspRecuperarTipoHabitacion", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", id);
                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {
                            
                            
                            int posId = drd.GetOrdinal("IIDTIPOHABILITACION");
                            int posNombre = drd.GetOrdinal("nombre");
                            int posDescripcion = drd.GetOrdinal("descripcion");
                            while (drd.Read())
                            {
                                oTipoHabitacionCLS = new TipoHabitacionCLS();
                                oTipoHabitacionCLS.id = drd.IsDBNull(posId) ? 0 : drd.GetInt32(posId);
                                oTipoHabitacionCLS.nombre = drd.IsDBNull(posNombre) ? "No hay nombre" : drd.GetString(posNombre);
                                oTipoHabitacionCLS.descripcion = drd.IsDBNull(posDescripcion) ? "No hay descripcion" : drd.GetString(posDescripcion);
                               
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
            return oTipoHabitacionCLS;
        }
        public int guardarTipoHabitacion(TipoHabitacionCLS oTipoHabitacion)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspGuardarTipohabitacion", cn))
                       
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", oTipoHabitacion.id);
                        cmd.Parameters.AddWithValue("@nombre", oTipoHabitacion.nombre);
                        cmd.Parameters.AddWithValue("@descripcion", oTipoHabitacion.descripcion);
                        rpta= cmd.ExecuteNonQuery();
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
        public int eliminarTipoHabitacion(int iidtipohabitacion)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspEliminarTipoHabitacion", cn))

                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", iidtipohabitacion);
                        
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

        public List<TipoHabitacionCLS> filtrarTipoHabitacion(string nombrehabitacion)
        {
            List<TipoHabitacionCLS> lista = null;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspFiltrarTipoHabitacion", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombrehabitacion", nombrehabitacion);
                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {
                            lista = new List<TipoHabitacionCLS>();
                            TipoHabitacionCLS oTipoHabitacionCLS;
                            int posId = drd.GetOrdinal("IIDTIPOHABILITACION");
                            int posNombre = drd.GetOrdinal("nombre");
                            int posDescripcion = drd.GetOrdinal("descripcion");
                            while (drd.Read())
                            {
                                oTipoHabitacionCLS = new TipoHabitacionCLS();
                                oTipoHabitacionCLS.id = drd.IsDBNull(posId) ? 0 : drd.GetInt32(posId);
                                oTipoHabitacionCLS.nombre = drd.IsDBNull(posNombre) ? "No hay nombre" : drd.GetString(posNombre);
                                oTipoHabitacionCLS.descripcion = drd.IsDBNull(posDescripcion) ? "No hay descripcion": drd.GetString(posDescripcion);
                                lista.Add(oTipoHabitacionCLS);
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


    }
}




  