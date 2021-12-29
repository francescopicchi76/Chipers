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
using Microsoft.VisualBasic;

namespace NorthwindDBSearchOrders
{
    public partial class Form1 : Form
    {
        SqlConnection northwindConn = new SqlConnection();
        DataTable collectedDataDT = new DataTable();
        DataTable gridSourceDT = new DataTable();
        string queryString, selectedDate, selectedOrderID, selectedShipper, selectedProduct, selectedEmployee;

        public Form1()
        {
            InitializeComponent();
            northwindConn.ConnectionString = Interaction.InputBox("Enter the connection string to your Northern database");
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            selectedOrderID = "";
            selectedDate = "";
            selectedShipper = "";
            selectedProduct = "";
            selectedEmployee = "";

            northwindConn.Open();

            SqlDataReader leggi = null;
            SqlCommand comando = new SqlCommand("", northwindConn);
            comando.CommandText = "select Orders.*, [Order Details].ProductID, Products.ProductName, Shippers.CompanyName, Employees.LastName from Orders inner join [Order Details] on Orders.OrderID = [Order Details].OrderID inner join Products on [Order Details].ProductID = Products.ProductID inner join Shippers on ShipVia = ShipperID inner join Employees on Orders.EmployeeID = Employees.EmployeeID";
            leggi = comando.ExecuteReader();
            collectedDataDT.Load(leggi);

            DataView viewShipperName = new DataView(collectedDataDT);
            DataTable shipperName = viewShipperName.ToTable("viewShipperName", true, "CompanyName");
            shipperNameCB.DataSource = shipperName;
            shipperNameCB.DisplayMember = "CompanyName";
            shipperNameCB.SelectedItem = null;
            shipperNameCB.Text = "--Select--";

            DataView viewProductName = new DataView(collectedDataDT);
            DataTable productName = viewProductName.ToTable("viewProductName", true, "ProductName");
            productNameCB.DataSource = productName;
            productNameCB.DisplayMember = "ProductName";
            productNameCB.SelectedItem = null;
            productNameCB.Text = "--Select--";

            DataView viewEmployeeName = new DataView(collectedDataDT);
            DataTable employeeName = viewProductName.ToTable("viewEmployeeName", true, "LastName");
            employeeNameCB.DataSource = employeeName;
            employeeNameCB.DisplayMember = "LastName";
            employeeNameCB.SelectedItem = null;
            employeeNameCB.Text = "--Select--";

            northwindConn.Close();

        }

        private void orderIDTB_TextChanged(object sender, EventArgs e)
        {
            selectedOrderID = orderIDTB.Text;
        }

        private void orderDateDTP_ValueChanged(object sender, EventArgs e)
        {
            selectedDate = orderDateDTP.Value.Date.ToString();
        }
        private void shipperNameCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedShipper = shipperNameCB.GetItemText(shipperNameCB.SelectedItem);
        }
        private void productNameCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedProduct = productNameCB.GetItemText(productNameCB.SelectedItem);
        }
        private void employeeNameCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedEmployee = employeeNameCB.GetItemText(employeeNameCB.SelectedItem);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            gridSourceDT.Clear();
            SqlDataReader leggi = null;
            SqlCommand comando = new SqlCommand("", northwindConn);
            queryString = "select Orders.*, [Order Details].ProductID, Products.ProductName, Shippers.CompanyName as [Shipper], Employees.LastName as [Employee] from Orders inner join [Order Details] on Orders.OrderID = [Order Details].OrderID inner join Products on [Order Details].ProductID = Products.ProductID inner join Shippers on ShipVia = ShipperID inner join Employees on Orders.EmployeeID = Employees.EmployeeID where Orders.OrderID IS NOT NULL";
            
            if (selectedOrderID != "")
            {
                queryString += " and Orders.OrderID = @OrderID";
                comando.Parameters.AddWithValue("@OrderID", selectedOrderID);
            }
            if (selectedDate != "")
            {
                queryString += " and OrderDate = @OrderDate";
                comando.Parameters.AddWithValue("@OrderDate", orderDateDTP.Value.Date);
            }
            if (selectedShipper != "")
            {
                queryString += " and CompanyName = @CompanyName";
                comando.Parameters.AddWithValue("@CompanyName", selectedShipper);
            }
            if (selectedProduct != "")
            {
                queryString += " and ProductName = @ProductName";
                comando.Parameters.AddWithValue("@ProductName", selectedProduct);
            }
            if (selectedEmployee != "")
            {
                queryString += " and LastName = @LastName";
                comando.Parameters.AddWithValue("@LastName", selectedEmployee);
            }

            comando.CommandText = queryString;
            northwindConn.Open();
            leggi = comando.ExecuteReader();
            gridSourceDT.Load(leggi);
            dataGridView1.DataSource = gridSourceDT;
            northwindConn.Close();

        }
    }
}
