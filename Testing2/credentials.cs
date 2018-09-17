﻿using System;
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
    public partial class Credentials : Form
    {
        public Credentials(List<string> objectsReserved, string qs, string email)
        {
            InitializeComponent();
            button1.Click += (sender, EventArgs) => { button_Click(sender, EventArgs, objectsReserved, qs, email); };
        }
        private void button_Click(object sender, EventArgs e, List<string> objectsReserved, string qs, string email)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            using (PrincipalContext principalContext = new PrincipalContext(ContextType.Domain))
            {
                // validate the credentials
                bool isValid = principalContext.ValidateCredentials(username, password);
                if (isValid)
                {

                    var connectionBuilder = new SqlConnectionStringBuilder();
                    connectionBuilder.DataSource = "prjserver.database.windows.net";
                    connectionBuilder.UserID = "serveradmin";
                    connectionBuilder.Password = "Azurefinalapp4";
                    connectionBuilder.InitialCatalog = "projectTesting";

                    using (var connection = new SqlConnection(connectionBuilder.ConnectionString))
                    {
                        connection.Open();
                        foreach (string productName in objectsReserved)
                        {
                            using (DbCommand command = new SqlCommand("Insert into bookings (IDuser,IDproduct,reservationDate,deliveryDate,location,confirmation" +/*, username*/")"+
                                " values ('" + qs + "','" + productName + "',getDate(), getDate() + 3,'Galati', 0);"))/* +
                                " (select top 1 username from users where (select top 1 IDuser from bookings order by bookings.reservationDate desc) = users.userID"))*/
                            {
                                command.Connection = connection;
                                command.ExecuteNonQuery();
                            }

                            using (DbCommand command = new SqlCommand("Update products set quantity=quantity-1 where productID='" + productName + "';"))
                            {
                                command.Connection = connection;
                                command.ExecuteNonQuery();
                            }

                        }
                    }
                    this.Close();
                }
                else
                {
                    System.Windows.Forms.Application.Exit();
                }
            }
        }
    }
}
