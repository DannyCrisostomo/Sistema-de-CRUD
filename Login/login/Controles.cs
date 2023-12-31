using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using CapaTranversal.Cache;
using System.Linq;

namespace login
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);


        private void Controles_Load(object sender, EventArgs e)
        {
            LoadUserData();
        }

        private void Controles_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void sspanel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void LoadUserData()
        {
            lblName.Text = UsuarioCacheLogin.FirsName+","+ UsuarioCacheLogin.LastName;
            lblposition.Text = UsuarioCacheLogin.Position;
            lblEmail.Text = UsuarioCacheLogin.Email;
        }



        private void Cerrar_sesion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea cerrar sesión?", "Warning",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                this.Close();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea cerrar sesión?", "Warning",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Create>();
            button3.BackColor = Color.FromArgb(12, 61, 92);
            button3.ForeColor = Color.FromArgb(255, 255, 255);
        }


        //METODO PARA ABRIR FORMULARIOS DENTRO DEL PANEL
        private void AbrirFormulario<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = panelformularios.Controls.OfType<MiForm>().FirstOrDefault();//Busca en la colecion el formulario
            //si el formulario/instancia no existe
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panelformularios.Controls.Add(formulario);
                panelformularios.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
                formulario.FormClosed += new FormClosedEventHandler(CloseForms);
            }
            //si el formulario/instancia existe
            else
            {
                formulario.BringToFront();
            }
        }
        private void CloseForms(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms["Create"] == null)
                button3.BackColor = Color.FromArgb(4, 41, 68);
            if (Application.OpenForms["Read"] == null)
                button2.BackColor = Color.FromArgb(4, 41, 68);
            if (Application.OpenForms["Inicio"] == null)
                Inicio.BackColor = Color.FromArgb(4, 41, 68);
        }



        private void Inicio_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Inicio>();
            Inicio.BackColor = Color.FromArgb(12, 61, 92);
            Inicio.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void lblEmail_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void lblName_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Proposito>();
            button2.BackColor = Color.FromArgb(12, 61, 92);
            button2.ForeColor = Color.FromArgb(255,255,255);
        }

        private void lblposition_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
