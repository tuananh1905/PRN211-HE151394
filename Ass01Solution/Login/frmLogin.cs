using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Login
{
    public partial class frmLogin : Form
    {
        private readonly MemberDAO dao;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            var isMember = dao.IsMember(username, password);
            if (!isMember)
            {
                MessageBox.Show("Incorrect email or password");
                return;
            }
            Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();
    }
}
