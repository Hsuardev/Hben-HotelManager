using Capa_Datos;
using Capá_Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Negocio
{
    public class CamaBL
    {
        public List<CamaCLS> listarCama()
        {
            CamaDAL oCamaDAL = new CamaDAL();
            return oCamaDAL.listarCama();
        }
        public int guardarTipoCama(CamaCLS oCama)
        {
            CamaDAL oCamaDAL = new CamaDAL();
            return oCamaDAL.guardarTipoCama(oCama);
        }
        public int EliminarCama(int iidcama)
        {
            CamaDAL oCama = new CamaDAL();
            return oCama.EliminarCama(iidcama);

        }
        public List<CamaCLS> filtrarCama(string nombrecama)
        {
            CamaDAL oCama = new CamaDAL();
            return oCama.filtrarCama(nombrecama);
        }
       
    }
}

