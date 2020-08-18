using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBG_CapaDatos
{
    public class BD_Conexion
    {
        public String Conectar()
        {
            return @"Data Source= LAPTOP-8HNCIP50\SQLEXPRESS; Initial Catalog = JBGym; uid=FranciscoCdrn; pwd=1309505491";
            //integrated security = true Para conexion con autenticacion de windows
        }
    }
}
