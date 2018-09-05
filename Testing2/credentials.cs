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
    public partial class credentials : Form
    {
        public credentials(List<string> objectsReserved, string qs, string email)
        {
            InitializeComponent();
            button1.Click += (sender, EventArgs) => { button_Click(sender, EventArgs, objectsReserved, qs, email); };
        }
        private void button_Click(object sender, EventArgs e, List<string> objectsReserved, string qs, string email)
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
                            using (DbCommand command = new SqlCommand("Insert into bookings (IDuser,IDproduct,reservationDate,deliveryDate,location,confirmation) values ('" + qs + "','" + productName + "',getDate()-4,getDate()-1,'Galati',0);"))
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

                    // Create the Outlook application by using inline initialization.
                    Microsoft.Office.Interop.Outlook.Application oApp = new Microsoft.Office.Interop.Outlook.Application();

                    //Create the new message by using the simplest approach.
                    Microsoft.Office.Interop.Outlook.MailItem oMsg = (MailItem)oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

                    //Add a recipient.
                    // TODO: Change the following recipient where appropriate.
                    Microsoft.Office.Interop.Outlook.Recipient oRecip = (Microsoft.Office.Interop.Outlook.Recipient)oMsg.Recipients.Add("t-stnast@microsoft.com");
                    oRecip.Resolve();

                    //Set the basic properties.
                    oMsg.Subject = "Confirmation";
                    oMsg.Body = "This is a confirmation regarding the reservation of " + System.Environment.NewLine;
                    foreach (string productName in objectsReserved)
                    {

                        using (var connection = new SqlConnection(cb.ConnectionString))
                        {
                            connection.Open();
                            
                            SqlCommand cmd = new SqlCommand("select productName from products where productID='" + productName + "';", connection);
                            SqlDataReader reader = cmd.ExecuteReader();
                            reader.Read();
                            string Message = "- " + reader.GetString(0) + System.Environment.NewLine;
                            oMsg.Body += Message;//to be fixed
                        }
                    }


                    //Add an attachment.
                    // TODO: change file path where appropriate
                    //String sSource = "C:\\setupxlg.txt";
                    //String sDisplayName = "MyFirstAttachment";
                    //int iPosition = (int)oMsg.Body.Length + 1;
                    //int iAttachType = (int)Outlook.OlAttachmentType.olByValue;
                    //Microsoft.Office.Interop.Outlook.Attachment oAttach = oMsg.Attachments.Add(sSource, iAttachType, iPosition, sDisplayName);

                    // If you want to, display the message.
                    // oMsg.Display(true);  //modal

                    //Send the message.
                    oMsg.Save();
                    oMsg.Send();

                    //Explicitly release objects.
                    oRecip = null;
                    //oAttach = null;
                    oMsg = null;
                    oApp = null;




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
