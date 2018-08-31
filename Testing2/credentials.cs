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

namespace Testing2
{
    public partial class credentials : Form
    {
        public credentials()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain))
            {
                // validate the credentials
                bool isValid = pc.ValidateCredentials(username, password);
                if (isValid)
                {
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
