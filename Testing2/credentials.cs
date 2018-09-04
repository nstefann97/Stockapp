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

namespace Testing2
{
    public partial class credentials : Form
    {
        public credentials(List<string> objectsReserved,string qs)
        {
            InitializeComponent();
            button1.Click += (sender, EventArgs) => { button_Click(sender, EventArgs, objectsReserved,qs); };
        }

        private void button_Click(object sender, EventArgs e, List<string> objectsReserved,string qs)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain))
            {
                // validate the credentials
                bool isValid = pc.ValidateCredentials(username, password);
                if (isValid)
                {

                    var cb = new SqlConnectionStringBuilder();
                    cb.DataSource = "prjserver.database.windows.net";
                    cb.UserID = "serveradmin";
                    cb.Password = "Azurefinalapp4";
                    cb.InitialCatalog = "projectTesting";

                    using (var connection = new SqlConnection(cb.ConnectionString))
                    {
                        connection.Open();

                        foreach (string productName in objectsReserved)

                        {
                            using (DbCommand command = new SqlCommand("Insert into bookings (IDuser,IDproduct,reservationDate,deliveryDate,location,confirmation) values ('" + qs + "','" + productName + "',getDate(),getDate()+3,'Galati',0);"))
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
                    Application.Exit();
                }
            }
        }
    }
}
