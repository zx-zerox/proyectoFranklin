using Presentacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SystemaHotel
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }
        private Form activoform = null;
        private void AbrirFromhijo(Form formhijo)
        {
            if (activoform != null)
                activoform.Close(); ;
            activoform = formhijo;
            formhijo.TopLevel = false;
            formhijo.FormBorderStyle = FormBorderStyle.None;
            formhijo.Dock = DockStyle.Fill;
            panelcontenedor.Controls.Add(formhijo);
            panelcontenedor.Tag = formhijo;
            formhijo.BringToFront();
            formhijo.Show();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            maximizar.Visible = false;
            restaurar.Visible = true;
        }

        private void restaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            restaurar.Visible = false;
            maximizar.Visible = true;
        }

        private void minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void menuvertical_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelcontenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFromhijo(new Ventas());
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AbrirFromhijo(new Clientes());
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Inicio_Click(object sender, EventArgs e)
        {
            //AbrirFromhijo(new Inicio());
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("ESTA SEGURO DE CERRAR SECION :","ADVERTENCIA",MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning)==DialogResult.Yes)
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbrirFromhijo(new Reportes());
        }

        private void barratitulo_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
