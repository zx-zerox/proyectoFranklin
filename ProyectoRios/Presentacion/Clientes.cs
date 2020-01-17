using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatos;

namespace Presentacion
{
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
        }
        public void listaclientes(){
            Productos objclien = new Productos();
            dataGridView1.DataSource = objclien.Clientes();
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            listaclientes();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Productos obclient = new Productos();
            if (obclient.RegistroClientes(txtdnibuscar.Text) == true)
            {
                dataGridView1.DataSource = obclient.RegisClientes(txtdnibuscar.Text);
            }
            else
            {
                MessageBox.Show("No se encontro registro");
            }
        }
    }
}
