using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_de_Negocio;
using Capa_Datos;
using Capá_Entidad;

namespace Capa_de_Negocio
{
    public class TipoHabitacionBL
    {
        public List<TipoHabitacionCLS> listarTipoHabitacion()
        {
            TipoHabitacionDAL oTipoHabitacionDAL = new TipoHabitacionDAL();
            return oTipoHabitacionDAL.listarTipoHabitacion();
        }
        public int guardarTipoHabitacion(TipoHabitacionCLS oTipoHabitacion)
        {
            TipoHabitacionDAL oTipoHabitacionDAL = new TipoHabitacionDAL();
            return oTipoHabitacionDAL.guardarTipoHabitacion(oTipoHabitacion);
        }
        public TipoHabitacionCLS recuperarTipoHabitacion(int id)
        {
            TipoHabitacionDAL oTipoHabitacionDAL = new TipoHabitacionDAL();
            return oTipoHabitacionDAL.recuperarTipoHabitacion(id);

        }
        public int eliminarTipoHabitacion(int id)
        {
            TipoHabitacionDAL oTipoHabitacionDAL = new TipoHabitacionDAL();
            return oTipoHabitacionDAL.eliminarTipoHabitacion(id);

        }
        public List<TipoHabitacionCLS> filtrarTipoHabitacion(string nombrehabitacion)
        {
            TipoHabitacionDAL oTipoHabitacionDAL = new TipoHabitacionDAL();
            return oTipoHabitacionDAL.filtrarTipoHabitacion(nombrehabitacion);

        }
        
    }
}


