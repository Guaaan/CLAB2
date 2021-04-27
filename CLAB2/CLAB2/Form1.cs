using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CLAB2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            String codigo = txtCodigo.Text;
            String nombre = txtNombre.Text;
            String descripcion = txtDescripcion.Text;
            double precio_publico= double.Parse(txtPrecioPublico.Text);
            int existencias = int.Parse(txtExistencias.Text);

            string sql = "INSERT INTO productos (codigo, nombre, descripcion, precio_publico, existencias) VALUES ('" + codigo + "', '" + nombre + "', '" + descripcion + "', '" + precio_publico + "', '" + existencias + "')";

            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                comando.ExecuteNonQuery();
                MessageBox.Show("Registro guardado");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            String codigo = txtCodigo.Text;
            MySqlDataReader reader = null;

            string sql = "SELECT id, codigo, nombre, descripcion, precio_publico, existencias FROM productos WHERE codigo LIKE '" + codigo + "' LIMIT 1";
            MySqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                reader = comando.ExecuteReader();
            }
        }
    }
}
