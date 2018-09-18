using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.DirectoryServices.AccountManagement;
using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.Office.Interop.Outlook;

namespace Testing2
{
    public partial class PreviousOrders : Form
    {
        public PreviousOrders(string userID)
        {
            InitializeComponent();
            var connectionBuilder = new SqlConnectionStringBuilder();
            connectionBuilder.DataSource = "prjserver.database.windows.net";
            connectionBuilder.UserID = "serveradmin";
            connectionBuilder.Password = "Azurefinalapp4";
            connectionBuilder.InitialCatalog = "projectTesting";
            DataTable dataTable = new DataTable();

            string query = "select productName, reservationDate from bookings,products where IDuser="+userID+" and IDproduct=productID;";

            using (var connection = new SqlConnection(connectionBuilder.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            using (var dataAdapter = new SqlDataAdapter(command))
                dataAdapter.Fill(dataTable);
            foreach(DataRow row in dataTable.Rows)
            {
                orders.Text += "•  " + row.Field<string>(0)+" "+row.Field<DateTime>(1)+Environment.NewLine+Environment.NewLine;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
