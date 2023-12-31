using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace login
{
	public partial class Inicio : Form
	{
		public Inicio()
		{
			InitializeComponent();
		}
		[DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
		private extern static void ReleaseCapture();
		[DllImport("user32.DLL", EntryPoint = "SendMessage")]
		private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

		private void Inicio_Load(object sender, EventArgs e)
        {

        }

        private void Inicio_MouseDown(object sender, MouseEventArgs e)
        {
			ReleaseCapture();
			SendMessage(this.Handle, 0x112, 0xf012, 0);
		}
    }
}
