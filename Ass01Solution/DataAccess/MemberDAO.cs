using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess
{
    public class MemberDAO
    {
        private static List<MemberObject> MemberList = new List<MemberObject>()
        {
            new MemberObject{MemberID=2, MemberName="Nguyen Gian Tuan Anh", Email="tuananh@gmail.com",Password="123456",City="Ha Noi", Country="Viet Nam"},
            new MemberObject{MemberID=3, MemberName="Nguyen Quang Viet", Email="viet@gmail.com",Password="123456",City="Ha Noi", Country="Viet Nam"},
            new MemberObject{MemberID=4, MemberName="Tran Van The", Email="the@gmail.com",Password="123456",City="Ha Noi", Country="Viet Nam"},
            new MemberObject{MemberID=5, MemberName="Nguyen Van Minh Muoi", Email="muoi@gmail.com",Password="123456",City="Hai Phong", Country="Viet Nam"}
        };
        private static MemberDAO instance = null;
        private static readonly object instanceLock = new object();
        private MemberDAO() { }
        public static MemberDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MemberDAO();
                    }
                    return instance;
                }
            }
        }
        public List<MemberObject> GetMemberList => MemberList;
        public MemberObject GetMemberByID(int memberID)
        {
            //using LINQ to Object
            MemberObject member = MemberList.SingleOrDefault(pro => pro.MemberID == memberID);
            return member;
        }
        public void AddNew(MemberObject member)
        {
            MemberObject pro = GetMemberByID(member.MemberID);
            if (pro == null)
            {
                MemberList.Add(member);
            }
            else
            {
                throw new Exception("Member is already exists.");
            }
        }
        //Update a car
        public void Update(MemberObject member)
        {
            MemberObject c = GetMemberByID(member.MemberID);
            if (c != null)
            {
                var index = MemberList.IndexOf(c);
                MemberList[index] = member;
            }
            else
            {
                throw new Exception("Member does not already exists.");
            }
        }
        // Remove a car
        public void Remove(int MemberID)
        {
            MemberObject p = GetMemberByID(MemberID);
            if (p != null)
            {
                MemberList.Remove(p);
            }
            else
            {
                throw new Exception("Member does not already exists.");
            }
        }
        //sort

        //login
        public bool IsMember(string username, string password) => MemberList.Any(pro => pro.Email == username && pro.Password == password);
        public bool IsAdmin(string username, string password)
        {
            if(username == "admin@fstore.com" && password == "admin@@")
            {
                return true;
            }
            return false;
        }
    }
}
