using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;   // System.Data.dll 
using System.Diagnostics;
using System.DirectoryServices.AccountManagement;
//using System.Data;  

namespace Testing2
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {            
            string user = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            var connectionBuilder = new SqlConnectionStringBuilder();
            connectionBuilder.DataSource = "prjserver.database.windows.net";
            connectionBuilder.UserID = "serveradmin";
            connectionBuilder.Password = "Azurefinalapp4";
            connectionBuilder.InitialCatalog = "projectTesting";

            string query = "Select * from users;";
            DataTable results = new DataTable();

            using (var connection = new SqlConnection(connectionBuilder.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                dataAdapter.Fill(results);


            foreach (DataRow row in results.Rows)
            {
                string validUserId = row.Field<int>(0).ToString();
                string validUsername = row.Field<string>(1);
                string validPassword = row.Field<string>(2);
                string privilege = row.Field<string>(3);
                string validEmail = row.Field<string>(5);

                if (privilege == "client" &&
                    user == validUsername &&
                    password == validPassword)
                {
                    ProductsForm productsForm = new ProductsForm(validUsername,
                                                validUserId, validEmail);

                    this.Hide();
                    productsForm.ShowDialog();
                    this.Close();
                }

                if (privilege == "admin" &&
                    user == validUsername &&
                    password == validPassword)
                {
                    ProcessStartInfo sInfo = new ProcessStartInfo("https://web.powerapps.com/apps/def3ecb8-7bae-4345-8c2a-dcd9a809fc78");
                    Process.Start(sInfo);
                    this.Close();
                }
            }





            ////    string que = " INSERT INTO users (Username, Password) VALUES ('"+user+"', '"+password+"');" ;
            ////Connectt.Submit_Tsql_NonQuery(connection, "Insert", que);



            //SqlCommand command = connection.CreateCommand();
            //SqlTransaction transaction;

            //// Start a local transaction.
            //transaction = connection.BeginTransaction("SampleTransaction");

            //// Must assign both transaction object and connection
            //// to Command object for a pending local transaction
            //command.Connection = connection;
            //command.Transaction = transaction;

            //    command.CommandText =
            //        " INSERT INTO users (Username, Password) VALUES ('" + user + "', '" + password + "');";
            //    command.ExecuteNonQuery();
            //    // Attempt to commit the transaction.
            //    transaction.Commit();
            //    Console.WriteLine("Both records are written to database.");


            //    //Connectt.Submit_Tsql_NonQuery(connection, "3 - Inserts", query);
        }
         

            private void label4_Click(object sender, EventArgs e)
            {
                Application.Exit();
            }
        }
    }

