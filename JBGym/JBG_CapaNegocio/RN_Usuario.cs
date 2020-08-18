using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using JBG_CapaDatos;

namespace JBG_CapaNegocio
{
    public class RN_Usuario
    {
        public bool RN_Verificar_Acceso(string Usuario, string Contraseña)
        {
            BD_Usuario obj = new BD_Usuario();
            return obj.BD_Verificar_Acceso(Usuario, Contraseña);
        }
    }
}
