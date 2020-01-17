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
using Soporte;

namespace Presentacion
{
    public partial class Ventas : Form
    {
        Productos obVenta = new Productos();
        private string idcliente=null;
        public Ventas()
        {
            InitializeComponent();
        }
       
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Ventas_Load(object sender, EventArgs e)
        {
            ListarProductos();
            ListaDNIclientes();
        }
        //metodo para calcular el total
        private void Total() {
            if (txtkilos.Text == "")
            {
                txttotal.Text = "0";
            }
            if (txtkilos.Text != "") {
                double total;
                double precio = Convert.ToDouble(txtprecio.Text);
                double kilos = Convert.ToDouble(txtkilos.Text);
                total = precio * kilos;
                txttotal.Text = Convert.ToString(total);
            }
        }
        //metodo para mostrar productos en el combobox
        private void ListarProductos()
        {
            Productos objProd = new Productos();
            Cmbprod.DataSource = objProd.ListarProd();
            Cmbprod.DropDownStyle = ComboBoxStyle.DropDownList;
            Cmbprod.DisplayMember = "Nombre";
            Cmbprod.ValueMember = "ID_Prod";
            
        }
        private void ListaDNIclientes()
        {
            //llamado al metodo para mostrar dni de la base de datos en los combo box
            Productos objProd = new Productos();
            cmbdni.DataSource = objProd.ListarDNIcli();
            //cmbdni.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbdni.DisplayMember = "DNI";
            cmbdni.ValueMember = "ID_Cliente";

        }
        //metodo para mostrar precio segun el combo box
        private void Preciotext()
        {
            Productos prod = new Productos();
            if (Cmbprod.Text=="Carne Molida")
            {
                txtprecio.Text=prod.PrecioProd(3);
            }
            if (Cmbprod.Text == "Cadera")
            {
                txtprecio.Text = prod.PrecioProd(10);
            }
            if (Cmbprod.Text == "Filete")
            {
                txtprecio.Text = prod.PrecioProd(11);
            }
        }

        private void Cmbprod_SelectedIndexChanged(object sender, EventArgs e)
        {
            Preciotext();
        }

        private void txtkilos_TextChanged(object sender, EventArgs e)
        {
            Total();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {

        }

        private void btnAgreVenta_Click(object sender, EventArgs e)
        {
            //metodo para insertar registro en las ventas
            if (txtnombre.Text != null && txtapellido.Text != null && cmbdni.Text != null && idcliente != null)
            {
                idcliente = ClienteCache.ID.ToString();
                obVenta.InsertarVenta(Convert.ToInt32(idcliente), Convert.ToInt32(Cmbprod.SelectedValue), Convert.ToDouble(txtkilos.Text), Convert.ToDouble(txttotal.Text));
                MessageBox.Show("Venta Completa!!!");
            }
            else {
                MessageBox.Show("Ingrese Datos del Cliente Para realizar Venta");
            }

        }

        private void txtdni_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //insertar cliente q no este registrado
            if (txtnombre.Text != null && txtapellido.Text != null && cmbdni.Text != null)
            {
                obVenta.InsertarCliente(txtnombre.Text,txtapellido.Text,cmbdni.Text,txtcuenta.Text);
                MessageBox.Show("Cliente registrado correctamente!!");
            }
            else
            {
                MessageBox.Show("Ingrese Datos del Cliente Para Registrar cliente nuevo");
            }
        }

        private void cmbdni_SelectedIndexChanged(object sender, EventArgs e)
        {
            //metodo para mostrar datos del cliente
            Productos obclient = new Productos();
            if (obclient.RegistroClientes(cmbdni.Text) == true)
            {
                idcliente = ClienteCache.ID.ToString();
                txtnombre.Text = ClienteCache.Nombre.ToString();
                txtapellido.Text = ClienteCache.Apellido.ToString();
                txtcuenta.Text = ClienteCache.Cuenta.ToString();
            }
            else
            {
                MessageBox.Show("No se encontro registro");
            }

        }
    }
}
