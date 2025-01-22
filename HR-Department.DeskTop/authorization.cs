using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HR_Department.DeskTop
{
    public partial class authorization : Form
    {
        public authorization()
        {
            InitializeComponent();

            this.notVisibalePassword.Visible = false;
            this.passwordBox.AutoSize = false;
            this.passwordBox.Size = new Size(this.passwordBox.Size.Width, 47);
        }

        private void authorization_Load(object sender, EventArgs e)
        {

        }

        private void loginBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void visibalePassword_Click(object sender, EventArgs e)
        {
            this.passwordBox.UseSystemPasswordChar = false;
            this.notVisibalePassword.Visible = true;
        }

        private void notVisibalePassword_Click(object sender, EventArgs e)
        {
            this.passwordBox.UseSystemPasswordChar = true;
            this.notVisibalePassword.Visible = false;
        }
    }
}
