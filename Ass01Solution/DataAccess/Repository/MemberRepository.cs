using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        public void DeleteMember(int memberId) => MemberDAO.Instance.Remove(memberId);

        public MemberObject GetMemberByID(int memberId) => MemberDAO.Instance.GetMemberByID(memberId);

        public IEnumerable<MemberObject> GetMembers() => MemberDAO.Instance.GetMemberList;

        public void InsertMember(MemberObject member) => MemberDAO.Instance.AddNew(member);

        public void UpdateMember(MemberObject member) => MemberDAO.Instance.Update(member);
        public bool IsMember(string username, string password) => MemberDAO.Instance.IsMember(username, password);
        public bool IsAdmin(string username, string password) => MemberDAO.Instance.IsAdmin(username, password);
    }
}
