using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DatosAcceso;
using System.Runtime.InteropServices;
namespace login
{
	public partial class Create : Form
	{
		public Create()
		{
			InitializeComponent();
		}
        
        private void ID_Enter(object sender, EventArgs e)
        {
            if (ID.Text == "ID")
            {
                ID.Text = "";
                ID.ForeColor = Color.LightGray;
            }
        }

        private void ID_Leave(object sender, EventArgs e)
        {

            if (ID.Text == "ID")
            {
                ID.Text = "";
                ID.ForeColor = Color.DimGray;
            }
        }

        private void Nombre_Enter(object sender, EventArgs e)
        {
            if (Nombre.Text == "Nombre")
            {
                Nombre.Text = "";
                Nombre.ForeColor = Color.LightGray;
            }
        }

        private void Nombre_Leave(object sender, EventArgs e)
        {
            if (Nombre.Text == "Nombre")
            {
                Nombre.Text = "";
                Nombre.ForeColor = Color.DimGray;
            }
        }

        private void Apellido_Enter(object sender, EventArgs e)
        {
            if (Apellido.Text == "Apellido")
            {
                Apellido.Text = "";
                Apellido.ForeColor = Color.LightGray;
            }
        }

        private void Apellido_Leave(object sender, EventArgs e)
        {
            if (Apellido.Text == "Apellido")
            {
                Apellido.Text = "";
                Apellido.ForeColor = Color.DimGray;
            }
        }

        private void Telefono_Enter(object sender, EventArgs e)
        {
            if (Telefono.Text == "Telefono")
            {
                Telefono.Text = "";
                Telefono.ForeColor = Color.LightGray;
            }
        }

        private void Telefono_Leave(object sender, EventArgs e)
        {
            if (Telefono.Text == "Telefono")
            {
                Telefono.Text = "";
                Telefono.ForeColor = Color.DimGray;
            }
        }

        private void Celular_Enter(object sender, EventArgs e)
        {
            if (Celular.Text == "Celular")
            {
                Celular.Text = "";
                Celular.ForeColor = Color.LightGray;
            }
        }

        private void Celular_Leave(object sender, EventArgs e)
        {
            if (Celular.Text == "Celular")
            {
                Celular.Text = "";
                Celular.ForeColor = Color.DimGray;
            }
        }

        private void Direccion_Enter(object sender, EventArgs e)
        {
            if (Direccion.Text == "Direccion")
            {
                Direccion.Text = "";
                Direccion.ForeColor = Color.LightGray;
            }
        }

        private void Direccion_Leave(object sender, EventArgs e)
        {
            if (Direccion.Text == "Direccion")
            {
                Direccion.Text = "";
                Direccion.ForeColor = Color.DimGray;
            }
        }

        private void Email_Enter(object sender, EventArgs e)
        {
            if (Email.Text == "Email")
            {
                Email.Text = "";
                Email.ForeColor = Color.LightGray;
            }
        }

        private void Email_Leave(object sender, EventArgs e)
        {
            if (Email.Text == "Email")
            {
                Email.Text = "";
                Email.ForeColor = Color.DimGray;
            }
        }

        private void Nacimiento_Enter(object sender, EventArgs e)
        {
            if (Nacimiento.Text == "Nacimiento")
            {
                Nacimiento.Text = "";
                Nacimiento.ForeColor = Color.LightGray;
            }
        }

        private void Nacimiento_Leave(object sender, EventArgs e)
        {
            if (Nacimiento.Text == "Nacimiento")
            {
                Nacimiento.Text = "";
                Nacimiento.ForeColor = Color.DimGray;
            }
        }

        private void Observacion_Enter(object sender, EventArgs e)
        {
            if (Observacion.Text == "Observacion")
            {
                Observacion.Text = "";
                Observacion.ForeColor = Color.LightGray;
            }
        }

        private void Observacion_Leave(object sender, EventArgs e)
        {
            if (Observacion.Text == "Observacion")
            {
                Observacion.Text = "";
                Observacion.ForeColor = Color.DimGray;
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string agregar = "INSERT INTO Datos (id,nombre,apellido,teléfono,celular,dirección,email,nacimiento,observaciones) values (@id,@nombre,@apellido,@teléfono,@celular,@dirección,@email,@nacimiento,@observaciones)";
            SqlCommand cmd1 = new SqlCommand(agregar, Conexion.Conectar());
            cmd1.Parameters.AddWithValue("@id", ID.Text);
            cmd1.Parameters.AddWithValue("@nombre", Nombre.Text);
            cmd1.Parameters.AddWithValue("@apellido", Apellido.Text);
            cmd1.Parameters.AddWithValue("@teléfono", Telefono.Text);
            cmd1.Parameters.AddWithValue("@celular", Celular.Text);
            cmd1.Parameters.AddWithValue("@dirección", Direccion.Text);
            cmd1.Parameters.AddWithValue("@email", Email.Text);
            cmd1.Parameters.AddWithValue("@nacimiento", Nacimiento.Text);
            cmd1.Parameters.AddWithValue("@observaciones", Observacion.Text);
            cmd1.ExecuteNonQuery();
            MessageBox.Show("Los datos fueron agregados con exito");
            dataGridView1.DataSource=llenar_grid();
        }

        private void Create_Load(object sender, EventArgs e)
        {
            Conexion.Conectar();
            MessageBox.Show("Conexion Exitosa");

            dataGridView1.DataSource = llenar_grid();
        }
        public DataTable llenar_grid()
        {
            Conexion.Conectar();
            DataTable bd = new DataTable();
            string consulta = "select * from Datos";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conectar());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(bd);
            return bd;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                Nombre.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                Apellido.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                Telefono.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                Celular.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                Direccion.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                Nacimiento.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                Email.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                Observacion.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            }
            catch { }
        }

        private void Modificar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string actualizar = "UPDATE Datos SET id=@id,nombre=@nombre,apellido=@apellido,teléfono=@teléfono,celular=@celular,dirección=@dirección,email=@email,nacimiento=@nacimiento,observaciones=@observaciones WHERE id=@id";
            SqlCommand cmd2 = new SqlCommand(actualizar, Conexion.Conectar());
            cmd2.Parameters.AddWithValue("@id", ID.Text);
            cmd2.Parameters.AddWithValue("@nombre", Nombre.Text);
            cmd2.Parameters.AddWithValue("@apellido", Apellido.Text);
            cmd2.Parameters.AddWithValue("@teléfono", Telefono.Text);
            cmd2.Parameters.AddWithValue("@celular", Celular.Text);
            cmd2.Parameters.AddWithValue("@dirección", Direccion.Text);
            cmd2.Parameters.AddWithValue("@email", Email.Text);
            cmd2.Parameters.AddWithValue("@nacimiento", Nacimiento.Text);
            cmd2.Parameters.AddWithValue("@observaciones", Observacion.Text);
            cmd2.ExecuteNonQuery();
            MessageBox.Show("Los datos fueron actualizado con exito");
            dataGridView1.DataSource = llenar_grid();
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            Conexion.Conectar();
            string eliminar = "DELETE FROM Datos WHERE id=@id";
            SqlCommand cmd3 = new SqlCommand(eliminar, Conexion.Conectar());
            cmd3.Parameters.AddWithValue("@id", ID.Text);
            cmd3.ExecuteNonQuery();
            MessageBox.Show("Los datos fueron eliminado con exito");
            dataGridView1.DataSource = llenar_grid();
        }

        private void Nuevo_Click(object sender, EventArgs e)
        {
            ID.Clear();
            Nombre.Clear();
            Apellido.Clear();
            Telefono.Clear();
            Celular.Clear();
            Direccion.Clear();
            Nacimiento.Clear();
            Email.Clear();
            Observacion.Clear();
            ID.Focus();
        }

        private void ID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
