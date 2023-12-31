using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Domain;
using CapaTranversal.Cache;
namespace login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);


        private void txtuser_Enter(object sender, EventArgs e)
        {
            if (txtuser.Text == "Usuario")
            {
                txtuser.Text = "";
                txtuser.ForeColor = Color.LightGray;
            }
        }

        private void txtuser_Leave(object sender, EventArgs e)
        {
            if (txtuser.Text == "Usuario")
            {
                txtuser.Text = "";
                txtuser.ForeColor = Color.DimGray;
            }
        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
            if (txtpass.Text == "Contraseña")
            {
                txtpass.Text = "";
                txtpass.ForeColor = Color.LightGray;
                txtpass.UseSystemPasswordChar = true;
            }
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            if (txtpass.Text == "Contraseña")
            {
                txtpass.Text = "";
                txtpass.ForeColor = Color.DimGray;
                txtpass.UseSystemPasswordChar = false;
            }
        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            /*Conexion con la bd */
            if (txtuser.Text != "Usuario")
            {
                if (txtpass.Text != "Contraseña") {
                    ModeloUsuario user = new ModeloUsuario();
                    var validLogin = user.LoginUser(txtuser.Text, txtpass.Text);

                    if (validLogin == true)
                    {
                        FormPrincipal mainMenu = new FormPrincipal();
                        MessageBox.Show("Bienvenido " + UsuarioCacheLogin.FirsName + ", " + UsuarioCacheLogin.LastName);
                        mainMenu.Show();
                        mainMenu.FormClosed += Logout;
                        this.Hide();
                     }
                    else
                    {
                        msgError("⛔ Usuario incorrecto o contraseña incorrecta.  ");
                        txtuser.Focus();
                        txtpass.Text = "Contraseña";
                    }
                }
                else msgError("⛔ Por favor Ingrese su contraseña");
            }
            else msgError("⛔ Por favor Ingrese su usuario");
        }
            
        private void msgError(string msg)
        {
            lblErrorMessage.Text = "  " + msg;
            lblErrorMessage.Visible = true;
        }
        private void Logout(object sender, FormClosedEventArgs e)
        {
            txtpass.Text = "Contraseña";
            txtpass.UseSystemPasswordChar = false;
            txtuser.Text = "Usuario";
            lblErrorMessage.Visible = false;
            this.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void txtuser_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
