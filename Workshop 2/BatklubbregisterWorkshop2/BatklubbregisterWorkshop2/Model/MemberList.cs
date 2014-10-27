using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BatklubbregisterWorkshop2.Model;

namespace BatklubbregisterWorkshop2.Model
{
    class MemberList
    {
        private List<Member> memberList;
        private MemberDAL mDAL;

        public MemberList()
        {
            mDAL = new MemberDAL();

            List<Member> m = mDAL.LoadRegister();

            if (m == null)
                memberList = new List<Member>();
            else
                memberList = m;
        }

        public IReadOnlyCollection<Member> GetMemberList()
        {
            return memberList.AsReadOnly();
        }

        public int GetUniqueIdentifier()
        {
            int uniqueID = 0;
            int temp = 0;

            foreach (Member m in memberList)
            {
                temp = m.UniqueID;
                if (temp > uniqueID)
                    uniqueID = temp;
            }

            return uniqueID + 1;
        }
        
        public bool AddToList(Member m)
        {
            if (m == null)
                return false;

            memberList.Add(m);

            return true;
        }

        public Member GetSpecificMember(int index)
        {
            return memberList[index];
        }

        public void RemoveFromList(int index)
        {
            memberList.RemoveAt(index);
        }

        public void EditMember(int index, string[] editedMember)
        {
            memberList[index].Name = editedMember[0];
            memberList[index].PersonalNumber = editedMember[1];
        }

        public void SaveToFile()
        {
            mDAL.SaveRegister(memberList);
        }
    }
}
