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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //string username = textBox1.Text;
            //string password = textBox2.Text;
            //using (PrincipalContext pc = new PrincipalContext(ContextType.Domain))
            //{
            //    // validate the credentials
            //    bool isValid = pc.ValidateCredentials(username, password);
            //    if(isValid)
            //    {
            //        Form2 f2 = new Form2(textBox1.Text);
            //        this.Hide();
            //        f2.ShowDialog();
            //        this.Close();
            //    }
            //    else
            //    {
            //        Form3 f3 = new Form3();
            //        //this.Hide();
            //        //f3.ShowDialog();
            //        //this.Close();
            //        ProcessStartInfo sInfo = new ProcessStartInfo("https://web.powerapps.com/apps/866a9cf3-4104-48e1-ba30-cfebd6a05f74");
            //        Process.Start(sInfo);
            //        this.Close();
            //    }
            //}
















            string user = textBox1.Text;
            string password = textBox2.Text;
            var cb = new SqlConnectionStringBuilder();
            cb.DataSource = "prjserver.database.windows.net";
            cb.UserID = "serveradmin";
            cb.Password = "Azurefinalapp4";
            cb.InitialCatalog = "projectTesting";
            string query = "Select * from users;";
            DataTable results = new DataTable();
            using (var connection = new SqlConnection(cb.ConnectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                dataAdapter.Fill(results);


            foreach (DataRow row in results.Rows)
            {
                string privilege = row.Field<string>(3);
                if (privilege == "admin" && user == row.Field<string>(1)&&password==row.Field<string>(2))
                {
                    Form2 f2 = new Form2(row.Field<string>(1),row.Field<int>(0).ToString(),row.Field<string>(5));
                    this.Hide();
                    f2.ShowDialog();
                    this.Close();
                }
                if (privilege == "client" && user == row.Field<string>(1)&&password == row.Field<string>(2))
                {
                    //Form3 f3 = new Form3();
                    //this.Hide();
                    //f3.ShowDialog();
                    //this.Close();
                    ProcessStartInfo sInfo = new ProcessStartInfo("https://web.powerapps.com/apps/866a9cf3-4104-48e1-ba30-cfebd6a05f74");
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

