using DataAccess;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyStoreWinApp
{
    public partial class frmLogin : Form
    {
        IMemberRepository MemberRepository = new MemberRepository();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var memberEmail = txtMemberEmail.Text;
            var password = txtPassword.Text;
            var isMember = MemberRepository.IsMember(memberEmail, password);
            if (!isMember)
            {
                MessageBox.Show("Incorrect email or password");
                return;
            }
            Hide();
            frmMemberManagement frmMemberManagement = new frmMemberManagement(memberEmail, password);
            frmMemberManagement.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();
    }
}
