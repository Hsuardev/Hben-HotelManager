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
    public class ProductoDAL: CadenaDal
    {
        public List<ProductoCLS> filtrarProductos(string nombre)
        {
            List<ProductoCLS> lista = null;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspFiltrarProductos", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombre",nombre);
                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {
                            lista = new List<ProductoCLS>();
                            ProductoCLS oProductoCLS;
                            int posId = drd.GetOrdinal("IIDPRODUCTO");
                            int posNombreProducto = drd.GetOrdinal("nombre");
                            int posNombreMarca = drd.GetOrdinal("NOMBREMARCA");
                            int posPrecio = drd.GetOrdinal("PRECIOVENTA");
                            int posStock = drd.GetOrdinal("STOCK");
                            while (drd.Read())
                            {
                                oProductoCLS = new ProductoCLS();
                                oProductoCLS.iidproducto = drd.IsDBNull(posId) ? 0
                                    : drd.GetInt32(posId);
                                oProductoCLS.nombreproducto = drd.IsDBNull(posNombreProducto) ? "No hay nombre"
                                    : drd.GetString(posNombreProducto).ToUpper();
                                oProductoCLS.nombremarca = drd.IsDBNull(posNombreMarca) ? "No hay descripcion"
                                    : drd.GetString(posNombreMarca);
                                oProductoCLS.precioventa = drd.IsDBNull(posPrecio) ? 0
                                    : drd.GetDecimal(posPrecio);
                                oProductoCLS.stock = drd.IsDBNull(posStock) ? 0
                                    : drd.GetInt32(posStock);
                                oProductoCLS.denominacion = drd.IsDBNull(posStock) ? "" :
                                    (drd.GetInt32(posStock) > 50 ? "Alto" : "Bajo");

                                lista.Add(oProductoCLS);
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


        public List<ProductoCLS> listarProductos()
        {
            List<ProductoCLS> lista = null;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspListarProductos", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader drd = cmd.ExecuteReader();
                        if (drd != null)
                        {
                            lista = new List<ProductoCLS>();
                            ProductoCLS oProductoCLS;
                            int posId = drd.GetOrdinal("IIDPRODUCTO");
                            int posNombreProducto = drd.GetOrdinal("nombre");
                            int posNombreMarca = drd.GetOrdinal("NOMBREMARCA");
                            int posPrecio = drd.GetOrdinal("PRECIOVENTA");
                            int posStock = drd.GetOrdinal("STOCK");
                            while (drd.Read())
                            {
                                oProductoCLS = new ProductoCLS();
                                oProductoCLS.iidproducto = drd.IsDBNull(posId) ? 0 
                                    : drd.GetInt32(posId);
                                oProductoCLS.nombreproducto = drd.IsDBNull(posNombreProducto) ? "No hay nombre" 
                                    : drd.GetString(posNombreProducto);
                                oProductoCLS.nombremarca = drd.IsDBNull(posNombreMarca) ? "No hay descripcion" 
                                    : drd.GetString(posNombreMarca);
                                oProductoCLS.precioventa = drd.IsDBNull(posPrecio) ? 0
                                    : drd.GetDecimal(posPrecio);
                                oProductoCLS.stock = drd.IsDBNull(posStock) ? 0
                                    : drd.GetInt32(posStock);
                                oProductoCLS.denominacion = drd.IsDBNull(posStock) ? "":
                                    (drd.GetInt32(posStock) > 50 ? "Alto" : "Bajo");
                                    
                                lista.Add(oProductoCLS);
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
