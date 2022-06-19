using BusinessObject;
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
    public partial class frmMemberManagement : Form
    {
        private string _userEmail;
        private string _password;
        private readonly List<MemberObject> _systemMembers;
        IMemberRepository MemberRepository = new MemberRepository();
        BindingSource source;
        private int memberID;
        public frmMemberManagement(string userEmail, string password)
        {
            InitializeComponent();
            _userEmail = userEmail;
            _password = password;
            lbUser.Text = userEmail;
            _systemMembers = (List<MemberObject>)MemberRepository.GetMembers();
        }
        private void frmMemberManagement_Load(object sender, EventArgs e)
        {
            LoadMemberList(_systemMembers.OrderBy(x => x.MemberID).ToList());
        }
        private void dgvMemberList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MemberRepository.IsAdmin(_userEmail, _password))
            {
                frmMemberDetails frmMemberDetails = new frmMemberDetails();
                frmMemberDetails.Text = "Update Member";
                DataGridViewRow row = new DataGridViewRow();
                row = dgvMemberList.Rows[e.RowIndex];
                var member = new MemberObject
                {
                    MemberID = int.Parse(Convert.ToString(row.Cells["MemberID"].Value)),
                    MemberName = Convert.ToString(row.Cells["MemberName"].Value),
                    Email = Convert.ToString(row.Cells["Email"].Value),
                    Password = Convert.ToString(row.Cells["Password"].Value),
                    City = Convert.ToString(row.Cells["City"].Value),
                    Country = Convert.ToString(row.Cells["Country"].Value)
                };
                frmMemberDetails.updateMember(member);
                frmMemberDetails.FrmMemberManagement = this;
                frmMemberDetails.ShowDialog();
            }
            else
            {
                MessageBox.Show("You need to be admin to update member information!");
            }
        }

        private void dgvMemberList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.Value != null)
            {
                dgvMemberList.Rows[e.RowIndex].Tag = e.Value;
                e.Value = new String('\u25CF', e.Value.ToString().Length);
                return;
            }
        }

        private void dgvMemberList_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dgvMemberList.Rows[e.RowIndex];
            memberID = int.Parse(Convert.ToString(row.Cells["MemberID"].Value));
        }

        public void LoadMemberList(List<MemberObject> members)
        {
            if (members is null)
            {
                throw new ArgumentNullException(nameof(members));
            }

            try
            {
                dgvMemberList.DataSource = null;
                dgvMemberList.DataSource = members;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load car list");
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        private void rdMemberName_CheckedChanged(object sender, EventArgs e)
        {
            if (rdMemberName.Checked && txtSearch.Text == "")
            {
                LoadMemberList(_systemMembers.OrderBy(x => x.MemberName).ToList());
            }
        }

        private void rdMemberID_CheckedChanged(object sender, EventArgs e)
        {
            if (rdMemberID.Checked && txtSearch.Text == "")
            {
                LoadMemberList(_systemMembers.OrderBy(x => x.MemberID).ToList());
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (rdMemberID.Checked)
            {
                LoadMemberList(_systemMembers.Where(m => m.MemberID.ToString().Contains(txtSearch.Text.Trim())).ToList());
            }
            if (rdMemberName.Checked)
            {
                LoadMemberList(_systemMembers.Where(m => m.MemberName.ToLower().ToString().Contains(txtSearch.Text.Trim().ToLower())).ToList());
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            rdMemberID.Checked = true;
            rdMemberName.Checked = false;
            LoadMemberList(_systemMembers.OrderBy(x => x.MemberID).ToList());
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (MemberRepository.IsAdmin(_userEmail, _password))
            {
                frmMemberDetails frmMemberDetails = new frmMemberDetails();
                frmMemberDetails.Text = "Insert Member";
                frmMemberDetails.addMember();
                frmMemberDetails.FrmMemberManagement = this;
                frmMemberDetails.ShowDialog();
            }
            else
            {
                MessageBox.Show("You need to be admin to insert new member to system!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MemberRepository.IsAdmin(_userEmail, _password))
            {
                MemberRepository.DeleteMember(memberID);
                LoadMemberList(_systemMembers.OrderBy(x => x.MemberID).ToList());
            }
            else
            {
                MessageBox.Show("You need to be admin to delete member in system!");
            }
        }
    }
}
