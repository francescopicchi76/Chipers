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

namespace NorthwindDBSearchOrders
{
    public partial class Form1 : Form
    {
        SqlConnection northwindConn = new SqlConnection();
        DataTable collectedDataDT = new DataTable();
        DataTable gridSourceDT = new DataTable();
        string queryString, connectionString, selectedDateFrom, selectedDateTo, selectedOrderID, selectedShipper, selectedProduct, selectedEmployee;
        
        void clearData()
        {
            selectedOrderID = "";
            selectedDateFrom = "";
            selectedDateTo = "";
            selectedShipper = "";
            selectedProduct = "";
            selectedEmployee = "";
        }
        void initializeForm1controls()
        {
            orderIDTB.Text = "";
            orderDatefromDTP.Format = DateTimePickerFormat.Custom;
            orderDatefromDTP.CustomFormat = " ";
            orderDateToDTP.Format = DateTimePickerFormat.Custom;
            orderDateToDTP.CustomFormat = " ";
            shipperNameCB.SelectedItem = null;
            shipperNameCB.Text = "--Select--";
            productNameCB.SelectedItem = null;
            productNameCB.Text = "--Select--";
            employeeNameCB.SelectedItem = null;
            employeeNameCB.Text = "--Select--";
        }
        public Form1()
        {
            InitializeComponent();
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            clearData();
            connectionString = "";

            /*Open a dialog form to get the connection string to the database*/
            using (Form2 dialog = new Form2())
            {
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    connectionString = dialog.conString;
                }
                /*If the dialog form is closed with no OK-input, reload the main form*/
                else
                {
                    Form1_Load(sender, e);
                }
                /*If there are exceptions because the connection string is not working, reload the main form*/
                try
                {
                    northwindConn.ConnectionString = connectionString;
                }
                catch
                {
                    MessageBox.Show("Invalid connection string");
                    Form1_Load(sender, e);
                }
            }
            /*Store all relevant data from the database in a DataReader and load them in a DataTable*/
            SqlDataReader leggi = null;
            SqlCommand comando = new SqlCommand("", northwindConn);
            comando.CommandText = "select Orders.*, [Order Details].ProductID, Products.ProductName, Shippers.CompanyName, Employees.LastName from Orders inner join [Order Details] on Orders.OrderID = [Order Details].OrderID inner join Products on [Order Details].ProductID = Products.ProductID inner join Shippers on ShipVia = ShipperID inner join Employees on Orders.EmployeeID = Employees.EmployeeID";
            
            northwindConn.Open();

            leggi = comando.ExecuteReader();
            collectedDataDT.Load(leggi);
            
            /*From the main DataTable get a smaller DataView and then a corresponding DataTable including only the column of shippers' names:
            then use the smaller DataTable to load data into the corresponding ComboBox in the main form*/
            DataView viewShipperName = new DataView(collectedDataDT);
            DataTable shipperName = viewShipperName.ToTable("viewShipperName", true, "CompanyName");
            shipperNameCB.DataSource = shipperName;
            shipperNameCB.DisplayMember = "CompanyName";

            /*From the main DataTable get a smaller DataView and then a corresponding DataTable including only the column of products' names:
             then use the smaller DataTable to load data into the corresponding ComboBox in the main form*/
            DataView viewProductName = new DataView(collectedDataDT);
            DataTable productName = viewProductName.ToTable("viewProductName", true, "ProductName");
            productNameCB.DataSource = productName;
            productNameCB.DisplayMember = "ProductName";

            /*From the main DataTable get a smaller DataView and then a corresponding DataTable including only the column of employees' last names:
             then use the smaller DataTable to load data into the corresponding ComboBox in the main form*/
            DataView viewEmployeeName = new DataView(collectedDataDT);
            DataTable employeeName = viewProductName.ToTable("viewEmployeeName", true, "LastName");
            employeeNameCB.DataSource = employeeName;
            employeeNameCB.DisplayMember = "LastName";

            northwindConn.Close();

            initializeForm1controls();
        }
        /*If any of the search controls in the form is changed by the user, store the inputs in the corresponding string variables*/
        private void orderIDTB_TextChanged(object sender, EventArgs e)
        {
            selectedOrderID = orderIDTB.Text;
        }
        private void orderDateFromDTP_ValueChanged(object sender, EventArgs e)
        {
            selectedDateFrom = orderDatefromDTP.Value.Date.ToString();
            orderDatefromDTP.Format = DateTimePickerFormat.Short;
        }
        private void orderDateToDTP_ValueChanged(object sender, EventArgs e)
        {
            selectedDateTo = orderDateToDTP.Value.Date.ToString();
            orderDateToDTP.Format = DateTimePickerFormat.Short;
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

            /*Initialize the query string through an always-true-condition, so that all records are shown: such a full query is executed when no search criteria are selected*/
            queryString = "select Orders.*, [Order Details].ProductID, Products.ProductName, Shippers.CompanyName as [Shipper], Employees.LastName as [Employee] from Orders inner join [Order Details] on Orders.OrderID = [Order Details].OrderID inner join Products on [Order Details].ProductID = Products.ProductID inner join Shippers on ShipVia = ShipperID inner join Employees on Orders.EmployeeID = Employees.EmployeeID where Orders.OrderID IS NOT NULL";
            
            /*Check if the string variables corresponding to the search criteria have been changed by the user:
            if they have, add a corresponding condition to the query string*/
            if (selectedOrderID != "")
            {
                queryString += " and Orders.OrderID = @OrderID";
                comando.Parameters.AddWithValue("@OrderID", selectedOrderID);
            }
            if (selectedDateFrom != "")
            {
                queryString += " and OrderDate >= @OrderDateFrom";
                comando.Parameters.AddWithValue("@OrderDateFrom", orderDatefromDTP.Value.Date);
            }
            if (selectedDateTo != "") 
            {
                queryString += " and OrderDate <= @OrderDateTo";
                comando.Parameters.AddWithValue("@OrderDateTo", orderDateToDTP.Value.Date);
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

            /*Turn the query string into an SQLCommand, execute it and set the resulting DataTable
            as the data source for the DataGridView in the main form*/
            comando.CommandText = queryString;
            
            northwindConn.Open();
            
            leggi = comando.ExecuteReader();
            gridSourceDT.Load(leggi);
            dataGridView1.DataSource = gridSourceDT;

            northwindConn.Close();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            clearData();
            initializeForm1controls();
            dataGridView1.DataSource = null;
        }
    }
}
