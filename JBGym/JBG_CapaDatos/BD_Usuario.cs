using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; //Para uso de operaciones SQL
using System.Data.SqlClient; //Permite usar procedimientos almacenados
using JBG_CapaEntidad;
using JBG_CapaDatos;
using System.Windows.Forms;

namespace JBG_CapaDatos
{
    public class BD_Usuario : BD_Conexion //Heredamos para utilizar el metodo Conectar
    {
        public bool BD_Verificar_Acceso(string Usuario, string Contraseña)

       {
            bool funtionReturnValue = false;
            Int32 xfil = 0;
            SqlConnection Cn = new SqlConnection();
            SqlCommand Cmd = new SqlCommand();
            Cn.ConnectionString = Conectar();
            var _with1 = Cmd;
            _with1.CommandText = "SP_Login";//Procedimiento Almacenado
            //Habilitar Conexion
            _with1.Connection = Cn;
            //Tiempo aprox de intento de conexion
            _with1.CommandTimeout = 20;
            //Indica que estamos trabajando con procedimientos
            _with1.CommandType = CommandType.StoredProcedure;
            //Parametros de Entrada del procedimiento
            _with1.Parameters.AddWithValue("@Usuario", Usuario);
            _with1.Parameters.AddWithValue("@Contraseña", Contraseña);

            try
            {
                //Abrimos la conexion
                Cn.Open();
                xfil = (Int32)Cmd.ExecuteScalar();
                if (xfil > 0)
                {
                    funtionReturnValue = true;
                }
                else
                {
                    funtionReturnValue = false;
                }

                //Liberamos recursos
                Cmd.Parameters.Clear();
                Cmd.Dispose();
                Cmd = null;
                Cn.Close();
                Cn = null;
            }
            catch (Exception ex)
            {
                if (Cn.State == ConnectionState.Open)
                    Cn.Close();
                Cmd.Dispose();
                Cmd = null;
                Cn.Close();
                Cn = null;
                MessageBox.Show("Algo malo pasó: " + ex.Message, "Advertencia de seguridad. ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return funtionReturnValue;
      }

    }
}
