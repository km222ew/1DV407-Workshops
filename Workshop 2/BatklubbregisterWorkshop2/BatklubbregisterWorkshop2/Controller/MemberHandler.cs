using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BatklubbregisterWorkshop2.Model;
using BatklubbregisterWorkshop2.View;

namespace BatklubbregisterWorkshop2.Controller
{
    class MemberHandler
    {
        MemberList mList;
        MemberView mv;

        public MemberHandler()
        {
            mList = new MemberList();
            mv = new MemberView();
        }

        public void ShowDetailedMemberList()
        {
            mv.ShowDetailedMemberList(mList.GetMemberList());

            ContinueOnKeyPressed();
        }

        public void ShowCompactMemberList()
        {
            mv.ShowCompactMemberList(mList.GetMemberList());

            ContinueOnKeyPressed();
        }

        public void Add()
        {
            string[] memberInput = mv.GetMemberInfo();
            int uniqueID = mList.GetUniqueIdentifier();
            Member m = new Member(memberInput[0], memberInput[1], uniqueID);

            if (mList.AddToList(m))
                mList.SaveToFile();
        }

        public void Remove()
        {
            mv.ShowDetailedMemberList(mList.GetMemberList());

            mList.RemoveFromList(mv.GetUserInput("member", mList.GetMemberList().Count));

            mList.SaveToFile();
        }

        public void Edit()
        {
            mv.ShowDetailedMemberList(mList.GetMemberList());

            int index = mv.GetUserInput("member", mList.GetMemberList().Count);
            string[] editedMember = mv.GetMemberInfo();

            mList.EditMember(index, editedMember);

            mList.SaveToFile();
        }

        public void ShowSpecificMember()
        {
            mv.ShowCompactMemberList(mList.GetMemberList());

            Member member = mList.GetSpecificMember(mv.GetUserInput("member", mList.GetMemberList().Count));

            mv.ShowSpecificMember(member.Name, member.PersonalNumber, member.UniqueID, member.BoatList);

            ContinueOnKeyPressed();
        }

        public void AddBoat()
        {
            mv.ShowDetailedMemberList(mList.GetMemberList());

            Member member = mList.GetSpecificMember(mv.GetUserInput("member", mList.GetMemberList().Count));

            Tuple<string, int> t = mv.GetBoatInfo();

            member.AddBoat(new Boat(t.Item1, t.Item2));

            mList.SaveToFile();
        }

        public void EditBoat()
        {
            mv.ShowDetailedMemberList(mList.GetMemberList());

            Member member = mList.GetSpecificMember(mv.GetUserInput("member", mList.GetMemberList().Count));

            int index = mv.GetUserInput("boat", member.BoatList.Count);

            Tuple<string, int> t = mv.GetBoatInfo();

            member.EditBoat(index, new Boat(t.Item1, t.Item2));

            mList.SaveToFile();
        }

        public void RemoveBoat()
        {
            mv.ShowCompactMemberList(mList.GetMemberList());

            Member member = mList.GetSpecificMember(mv.GetUserInput("member", mList.GetMemberList().Count));

            mv.ShowSpecificMember(member.Name, member.PersonalNumber, member.UniqueID, member.BoatList);

            int index = mv.GetUserInput("boat", member.BoatList.Count);

            member.RemoveBoat(index);

            mList.SaveToFile();
        }

        private void ContinueOnKeyPressed()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write("\n   Tryck tangent för att fortsätta   ");
            Console.ResetColor();
            Console.CursorVisible = false;
            Console.ReadKey(true);
            Console.Clear();
            Console.CursorVisible = true;
        }
    }
}