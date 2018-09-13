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
    public partial class ProductsForm : Form
    {
        List<ProductInstance> productList = new List<ProductInstance>();
        //List<TextBox> allAmounts = new List<TextBox>();
        List<string> allNames = new List<string>();
        List<CheckBox> checkboxes = new List<CheckBox>();
        public ProductsForm(string username, string userID, string email)
        {
            InitializeComponent();
            welcomeLabel.Text = username + " !";

            var connectionBuilder = new SqlConnectionStringBuilder();
            connectionBuilder.DataSource = "prjserver.database.windows.net";
            connectionBuilder.UserID = "serveradmin";
            connectionBuilder.Password = "Azurefinalapp4";
            connectionBuilder.InitialCatalog = "projectTesting";
            DataTable dataTable = new DataTable();

            string query = "select productName, quantity, productID from products;";

            using (var connection = new SqlConnection(connectionBuilder.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            using (var dataAdapter = new SqlDataAdapter(command))
                dataAdapter.Fill(dataTable);

            int counter = 1;
            int startLeft = 43;
            int startTop = 98;
            int validationOfCheckings = 0;
            loginButton.Click += (sender, EventArgs) => { buttonR_Click(sender, EventArgs, userID, email); };

            foreach (DataRow row in dataTable.Rows)
            {

                connectionBuilder = new SqlConnectionStringBuilder();
                connectionBuilder.DataSource = "prjserver.database.windows.net";
                connectionBuilder.UserID = "serveradmin";
                connectionBuilder.Password = "Azurefinalapp4";
                connectionBuilder.InitialCatalog = "projectTesting";
                connectionBuilder.MultipleActiveResultSets = true;

                using (var connection = new SqlConnection(connectionBuilder.ConnectionString))
                {
                    connection.Open();

                    string productID = row.Field<string>(0);
                    int productsQuantity = row.Field<int>(1);

                    SqlCommand cmd = new SqlCommand("select * from bookings where IDuser='" +
                        userID + "' and IDproduct='" + row.Field<int>(2) + "';", connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    Panel p = new Panel(); //what is this
                    p.BorderStyle = BorderStyle.FixedSingle;
                    p.Name = "panel" + counter;
                    p.Size = new Size(120, 80);
                    p.Location = new Point((startLeft + (counter - 1) * 160), startTop);
                    p.BackColor = Color.Transparent;
                    this.Controls.Add(p);

                    Label productNameLabel = new Label(); //l1
                    Label productsNumberLabel = new Label(); //l2

                    productNameLabel.Text = productID;
                    productsNumberLabel.Text = productsQuantity > 0 ? productsQuantity.ToString() : "Not available";
                    productNameLabel.ForeColor = Color.White;
                    productsNumberLabel.ForeColor = Color.White;
                    p.Controls.Add(productNameLabel);
                    p.Controls.Add(productsNumberLabel);
                    productsNumberLabel.Top = productNameLabel.Top + 25;

                    if (productsQuantity > 0)
                        if (!reader.Read())
                        {
                            // The command returns Row(s)
                            allNames.Add(row.Field<int>(2).ToString());

                            //TextBox t = new TextBox();
                            //t.Size = new Size(23, 23);
                            //t.Location = new Point(28, 53);
                            //t.Text = "0";
                            //allAmounts.Add(t);


                            CheckBox reserve = new CheckBox();
                            reserve.Size = new Size(98, 21);
                            reserve.Location = new Point(3, 52);
                            reserve.Text = "Reserve";
                            reserve.ForeColor = Color.White;
                            p.Controls.Add(reserve);
                            checkboxes.Add(reserve);



                            //Button b1 = new Button();
                            //b1.Size = new Size(23, 23);
                            //b1.Location = new Point(3, 52);
                            //b1.Text = "-";
                            //b1.Name = "but" + counter + "1";
                            //b1.Click += (sender, EventArgs) => { buttonMinus_Click(sender, EventArgs, l2, t); };
                            //Button b2 = new Button();
                            //b2.Size = new Size(23, 23);
                            //b2.Location = new Point(53, 52);
                            //b2.Text = "+";
                            //b2.Name = "but" + counter + "2";
                            //b2.Click += (sender, EventArgs) => { buttonPlus_Click(sender, EventArgs, l2, t); };
                            //b1.Name = "text" + counter;

                            //NumericUpDown nup = new NumericUpDown();
                            //nup.Dock = System.Windows.Forms.DockStyle.Bottom;
                            //nup.ValueChanged += (sender, EventArgs) => {
                            //    int temp = Int32.Parse(l2.Text);
                            //    //if (nup.Value < 0)
                            //    //   return;
                            //    l2.Text = (temp - nup.Value).ToString();

                            //};
                            //p.Controls.Add(nup);




                            //p.Controls.Add(b1);
                            //p.Controls.Add(b2);
                            //p.Controls.Add(t);
                        }
                        else
                        {
                            if (reader.GetDateTime(3) >= DateTime.Now)
                            {

                                MonthCalendar monthCalendar1 = new MonthCalendar();
                                DateTime projectStart = new DateTime(reader.GetDateTime(2).Year, reader.GetDateTime(2).Month, reader.GetDateTime(2).Day);
                                DateTime projectEnd = new DateTime(reader.GetDateTime(3).Year, reader.GetDateTime(3).Month, reader.GetDateTime(3).Day);
                                monthCalendar1.SelectionRange = new SelectionRange(projectStart, projectEnd);
                                monthCalendar1.SelectionStart = projectStart;
                                monthCalendar1.SelectionEnd = projectEnd;
                                monthCalendar1.Left = (this.ClientSize.Width - monthCalendar1.Width) / 2;
                                monthCalendar1.Top = (this.ClientSize.Height - monthCalendar1.Height) / 2;

                                this.Controls.Add(monthCalendar1);
                                monthCalendar1.Hide();
                                productNameLabel.MouseEnter += new EventHandler(Calendar_MouseEnter);
                                productNameLabel.MouseLeave += new EventHandler(Calendar_MouseLeave);


                                Button remove = new Button();
                                remove.Size = new Size(98, 21);
                                remove.Location = new Point(3, 52);
                                remove.Text = "Cancel order";
                                remove.ForeColor = Color.White;
                                remove.BackColor = Color.LightSlateGray;
                                p.Controls.Add(remove);
                                remove.Click += (sender, EventArgs) =>
                                  {
                                      using (var connectionRemove = new SqlConnection(connectionBuilder.ConnectionString))
                                      {
                                          connectionRemove.Open();

                                          using (DbCommand command = new SqlCommand("Delete from bookings where IDuser='" + userID + "' and IDproduct='" + row.Field<int>(2) + "';"))
                                          {
                                              command.Connection = connectionRemove;
                                              command.ExecuteNonQuery();
                                          }

                                          using (DbCommand command = new SqlCommand("Update products set quantity=quantity+1 where productID='" + row.Field<int>(2) + "';"))
                                          {
                                              command.Connection = connectionRemove;
                                              command.ExecuteNonQuery();
                                          }

                                      }


                                  };

                            }
                            else
                            {
                                if (!reader.GetBoolean(5))
                                {
                                    Button confirm = new Button();
                                    confirm.Size = new Size(98, 21);
                                    confirm.Location = new Point(3, 52);
                                    confirm.Text = "Confirm";
                                    confirm.ForeColor = Color.White;
                                    confirm.BackColor = Color.LightSlateGray;
                                    p.Controls.Add(confirm);
                                    confirm.Click += (sender, EventArgs) =>
                                    {

                                        connectionBuilder = new SqlConnectionStringBuilder();
                                        connectionBuilder.DataSource = "prjserver.database.windows.net";
                                        connectionBuilder.UserID = "serveradmin";
                                        connectionBuilder.Password = "Azurefinalapp4";
                                        connectionBuilder.InitialCatalog = "projectTesting";
                                        connectionBuilder.MultipleActiveResultSets = true;

                                        using (var connectionUpdate = new SqlConnection(connectionBuilder.ConnectionString))
                                        {
                                            connectionUpdate.Open();


                                            using (DbCommand commandUpdate = new SqlCommand("update bookings set confirmation='True' where IDuser='" + userID + "' and IDproduct='" + row.Field<int>(2) + "';"))
                                    //using (DbCommand commandUpdate = new SqlCommand("delete from bookings where IDuser='"+nameuser+"' and IDproduct='"+row.Field<int>(2)+"';"))
                                    {
                                                commandUpdate.Connection = connectionUpdate;
                                                commandUpdate.ExecuteNonQuery();
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

                                        using (var connection2 = new SqlConnection(connectionBuilder.ConnectionString))
                                        {
                                            connection2.Open();

                                            SqlCommand cmd2 = new SqlCommand("select productName from products where productID='" + row.Field<int>(2) + "';", connection2);
                                            SqlDataReader reader2 = cmd2.ExecuteReader();
                                            reader2.Read();
                                            string Message = "- " + reader2.GetString(0) + System.Environment.NewLine;
                                            oMsg.Body += Message;//to be fixed
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




                                    };
                                }
                                else
                                {
                                    Label nopermission = new Label();
                                    nopermission.Size = new Size(98, 21);
                                    nopermission.Location = new Point(3, 52);
                                    nopermission.Text = "No permission";
                                    nopermission.ForeColor = Color.White;
                                    nopermission.BackColor = Color.Transparent;
                                    p.Controls.Add(nopermission);
                                }
                            }
                        }


                    counter++;
                }
            }
        }
        private void Calendar_MouseLeave(object sender, EventArgs e)
        {
            foreach (MonthCalendar m in this.Controls.OfType<MonthCalendar>())
                m.Hide();
        }

        private void Calendar_MouseEnter(object sender, EventArgs e)
        {
            foreach (MonthCalendar m in this.Controls.OfType<MonthCalendar>())
                m.Show();
        }
        //private void buttonPlus_Click(object sender, EventArgs eventArgs, Label l2, TextBox t)
        //{
        //    int temp = Int32.Parse(l2.Text);
        //    if (temp <= 0)
        //        return;
        //    int temp1 = Int32.Parse(t.Text);
        //    l2.Text = (temp - 1).ToString();
        //    t.Text = (temp1 + 1).ToString();
        //}

        //private void buttonMinus_Click(object sender, EventArgs eventArgs, Label l2, TextBox t)
        //{
        //    int temp = Int32.Parse(l2.Text);

        //    int temp1 = Int32.Parse(t.Text);
        //    if (temp1 <= 0)
        //        return;
        //    l2.Text = (temp + 1).ToString();
        //    t.Text = (temp1 - 1).ToString();
        //}

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void buttonR_Click(object sender, EventArgs e, string qs, string email)
        {
            //foreach (Label l in allNames)
            //    Console.WriteLine(l.Text);
            //foreach (TextBox ttt in allAmounts)
            //    Console.WriteLine(ttt.Text);


            List<string> objectsReserved = new List<string>();

            var combined = allNames.Zip(checkboxes, (n, w) => new { Name = n, Checked = w.Checked });
            foreach (var iterate in combined)
            {
                if (iterate.Checked)
                {
                    objectsReserved.Add(iterate.Name);
                }
            }
            //if (objectsReserved.Count>0)
            {
                credentials cr = new credentials(objectsReserved, qs, email);
                //this.Hide();
                cr.ShowDialog();


                //  using



                Console.Write("comanda efectuata");
                //this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            LoginForm newLogin = new LoginForm();
            this.Hide();
            newLogin.ShowDialog();
            this.Close();

        }
    }
}




