using JBG_CapaDatos;
using JBG_CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//OnceDiez Development 

namespace JBGym
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        private bool ValidarTextbox()
        {
            //Validamos que las cajas de texto no esten vacias
            //Trim Elimina los espacios
            if (txtUsuario.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ingresa tu Usuario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUsuario.Focus();
                return false;
            }
            if (txtContraseña.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ingresa tu Contraseña", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtContraseña.Focus();
                return false;
            }
            return true;
        }

        private void frm_Login_Load(object sender, EventArgs e)
        {
        }
        private void AccederAlSistema()
        {
            //Creamos una instancia de RN Usuario para poder acceder a sus metodos
            RN_Usuario obj = new RN_Usuario();
            DataTable dt = new DataTable();

            //Vamos a dar 3 intentos de acceso, si no cerramos
            int veces = 0;
            if (ValidarTextbox() == false) return;
            string usuario, pass;
            usuario = txtUsuario.Text.Trim();
            pass = txtContraseña.Text.Trim();
            //Verificamos si los datos son correctos
            if (obj.RN_Verificar_Acceso(usuario, pass) == true)
            {
                //Son Correctos
                //Llenar Datatable Con los datos del Usuario

                MessageBox.Show("¡Bienvenido al Sistema!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmPrincipal principal = new frmPrincipal();
                principal.Show();
                this.Hide();
            }
            else
            {
                //Son incorrectos
                MessageBox.Show("El Usuario o Contraseña son incorrectos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUsuario.Text = "";
                txtContraseña.Text = "";
                txtUsuario.Focus();
                veces += 1;

                if (veces == 2)
                {
                    MessageBox.Show("El número de intentos fue superado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Application.Exit();
                }
            }
        }


        private void panel_Top_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Utilitarios u = new Utilitarios();
                u.moverFormulario(this);
            }
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMentira.Focus();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            AccederAlSistema();
        }
    }
}
