﻿using Capa_Datos;
using Capá_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Negocio
{
    public class ProductoBL
    {
        public List<ProductoCLS> filtrarProductos(string nombre)
        {
            ProductoDAL oProductoDAL = new ProductoDAL();
            return oProductoDAL.filtrarProductos(nombre);
        }
        public List<ProductoCLS> listarProductos()
        {
            ProductoDAL oProductoDAL = new ProductoDAL();
            return oProductoDAL.listarProductos();
        }
    }
}
