using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessObject;
using DataAccess.Repository;

namespace MyStoreWinApp
{
    public partial class frmMemberDetails : Form
    {


        IMemberRepository MemberRepository = new MemberRepository();
        public frmMemberManagement FrmMemberManagement { get; set; }
        private MemberObject member;
        private bool InsertOrUpdate;
        public frmMemberDetails()
        {
            InitializeComponent();
        }
        public void updateMember(MemberObject member)
        {
            InsertOrUpdate = false;
            this.member = member;
        }
        public void addMember()
        {
            InsertOrUpdate = true;
            member = null;
        }
        private void frmMemberDetails_Load(object sender, EventArgs e)
        {
            if (member != null)
            {
                txtMemberID.Enabled = InsertOrUpdate;
                txtMemberID.Text = member.MemberID.ToString();
                txtMemberName.Text = member.MemberName;
                txtEmail.Text = member.Email.ToString();
                txtPassword.Text = member.Password.ToString();
                txtCity.Text = member.City.ToString();
                txtCountry.Text = member.Country.ToString();
            }
            else
            {
                txtMemberID.Enabled = InsertOrUpdate;
                txtMemberID.Text = "";
                txtMemberName.Text = "";
                txtEmail.Text = "";
                txtPassword.Text = "";
                txtCity.Text = "";
                txtCountry.Text = "";
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var member = new MemberObject
                {
                    MemberID = int.Parse(txtMemberID.Text),
                    MemberName = txtMemberName.Text,
                    Email = txtEmail.Text,
                    Password = txtPassword.Text,
                    City = txtCity.Text,
                    Country = txtCountry.Text
                };
                if (InsertOrUpdate == false)
                {
                    MemberRepository.UpdateMember(member);
                    FrmMemberManagement.LoadMemberList(((List<MemberObject>)MemberRepository.GetMembers()));
                    Close();
                    return;
                }
                else
                {
                    MemberRepository.InsertMember(member);
                    FrmMemberManagement.LoadMemberList(((List<MemberObject>)MemberRepository.GetMembers()));
                    Close();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add a new Member" : "Update a member");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();


        
    }
}
