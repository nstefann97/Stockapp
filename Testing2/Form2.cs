using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Testing2
{
    public partial class Form2 : Form
    {
        List<ProductInstance> prodList = new List<ProductInstance>();
        //List<TextBox> allAmounts = new List<TextBox>();
        List<string> allNames = new List<string>();
        List<CheckBox> check = new List<CheckBox>();
        public Form2(string nameuser, string iduser, string email)
        {
            InitializeComponent();
            label2.Text = nameuser + " !";
            var cb = new SqlConnectionStringBuilder();
            cb.DataSource = "prjserver.database.windows.net";
            cb.UserID = "serveradmin";
            cb.Password = "Azurefinalapp4";
            cb.InitialCatalog = "projectTesting";
            DataTable dt = new DataTable();
            string query = "Select productName, quantity,productID from products;";
            using (var connection = new SqlConnection(cb.ConnectionString))
            using (var command = new SqlCommand(query, connection))
            using (var dataAdapter = new SqlDataAdapter(command))
                dataAdapter.Fill(dt);
            int counter = 1;
            int startleft = 43;
            int starttop = 98;
            int validationOfCheckings = 0;
            button1.Click += (sender, EventArgs) => { buttonR_Click(sender, EventArgs, iduser,email); };
            foreach (DataRow row in dt.Rows)
            {

                cb = new SqlConnectionStringBuilder();
                cb.DataSource = "prjserver.database.windows.net";
                cb.UserID = "serveradmin";
                cb.Password = "Azurefinalapp4";
                cb.InitialCatalog = "projectTesting";
                cb.MultipleActiveResultSets = true;

                using (var connection = new SqlConnection(cb.ConnectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("select * from bookings where IDuser='" + iduser + "' and IDproduct='" + row.Field<int>(2) + "';", connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Panel p = new Panel();
                    p.BorderStyle = BorderStyle.FixedSingle;
                    p.Name = "panel" + counter;
                    p.Size = new Size(120, 80);
                    p.Location = new Point((startleft + (counter - 1) * 160), starttop);
                    p.BackColor = Color.Transparent;
                    this.Controls.Add(p);
                    Label l1 = new Label();
                    Label l2 = new Label();
                    l1.Text = row.Field<string>(0);
                    l2.Text = row.Field<int>(1)>0? row.Field<int>(1).ToString():"Not available";
                    l1.ForeColor = Color.White;
                    l2.ForeColor = Color.White;
                    p.Controls.Add(l1);
                    p.Controls.Add(l2);
                    l2.Top = l1.Top + 25;

                    if (row.Field<int>(1) > 0)
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
                            check.Add(reserve);
                          


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
                                l1.MouseEnter += new EventHandler(Calendar_MouseEnter);
                                l1.MouseLeave += new EventHandler(Calendar_MouseLeave);

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

                                        cb = new SqlConnectionStringBuilder();
                                        cb.DataSource = "prjserver.database.windows.net";
                                        cb.UserID = "serveradmin";
                                        cb.Password = "Azurefinalapp4";
                                        cb.InitialCatalog = "projectTesting";
                                        cb.MultipleActiveResultSets = true;

                                        using (var connectionUpdate = new SqlConnection(cb.ConnectionString))
                                        {
                                            connectionUpdate.Open();


                                            using (DbCommand commandUpdate = new SqlCommand("update bookings set confirmation='True' where IDuser='" + iduser + "' and IDproduct='" + row.Field<int>(2) + "';"))
                                        //using (DbCommand commandUpdate = new SqlCommand("delete from bookings where IDuser='"+nameuser+"' and IDproduct='"+row.Field<int>(2)+"';"))
                                        {
                                                commandUpdate.Connection = connectionUpdate;
                                                commandUpdate.ExecuteNonQuery();
                                            }
                                        }
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
            Application.Exit();
        }

        private void buttonR_Click(object sender, EventArgs e, string qs,string email)
        {
            //foreach (Label l in allNames)
            //    Console.WriteLine(l.Text);
            //foreach (TextBox ttt in allAmounts)
            //    Console.WriteLine(ttt.Text);


            List<string> objectsReserved = new List<string>();

            var combined = allNames.Zip(check, (n, w) => new { Name = n, Checked = w.Checked });
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

            Form1 newLogin = new Form1();
            this.Hide();
            newLogin.ShowDialog();
            this.Close();

        }
    }
}
