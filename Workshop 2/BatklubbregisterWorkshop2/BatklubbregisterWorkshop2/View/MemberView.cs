using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BatklubbregisterWorkshop2.Model;

namespace BatklubbregisterWorkshop2.View
{
    class MemberView
    {
        public string[] GetMemberInfo()
        {
            string[] input = new string[2];

            Console.Write("Name: ");
            input[0] = Console.ReadLine();

            Console.Write("PersonalNumber: ");
            input[1] = Console.ReadLine();

            return input;
        }

        public Tuple<string, int> GetBoatInfo()
        {
            string type;
            int length;
            
            Console.Write("Type: ");
            if (string.IsNullOrWhiteSpace(type = Console.ReadLine()))
            {
                type = "default";
            }

            Console.Write("Boat length: ");
            if (!int.TryParse(Console.ReadLine(), out length))
                length = 10;

            return Tuple.Create(type, length);
        }

        public int GetUserInput(string item, int count)
        {
            int index;
            while (true)
            {
                Console.Write("Choose {0}: ", item);

                if (int.TryParse(Console.ReadLine(), out index) && index > 0 && index <= count)
                    return index - 1; // -1 because we add one in the display, so the index 0 is shown as 1.
            }
            
            throw new Exception();
        }

        public void ShowDetailedMemberList(IReadOnlyCollection<Member> m)
        {
            int index = 1;

            Console.Clear();

            foreach (Member member in m)
            {
                Console.WriteLine("{0}. NAME: {1} PERSONALNUMBER: {2} UNIQUEID: {3}", index, member.Name, member.PersonalNumber, member.UniqueID);

                ShowBoats(member.BoatList);
                Console.WriteLine();
                index++;
            }
        }

        public void ShowCompactMemberList(IReadOnlyCollection<Member> m)
        {           
            int index = 1;

            Console.Clear();

            foreach (Member member in m)
            {
                Console.WriteLine("{0}. NAME: {1} UNIQUEID: {2}", index, member.Name, member.UniqueID);
                Console.WriteLine("{0} has {1} boats.", member.Name, member.BoatList.Count);
                Console.WriteLine();
                index++;
            }
        }

        public void ShowSpecificMember(string name, string personalNumber, int uniqueID, IReadOnlyCollection<Boat> boats)
        {
            Console.Clear();
            Console.WriteLine("{0} {1} {2}", name, personalNumber, uniqueID);

            ShowBoats(boats);
        }

        public void ShowBoats(IReadOnlyCollection<Boat> boats)
        {
            int boatIndex = 1;

            Console.WriteLine("\nBoats\n");

            foreach (Boat boat in boats)
            {
                Console.WriteLine("  {0}. Boat type: {1}\n     Boat length: {2}", boatIndex, boat.Type, boat.Length);
                Console.WriteLine("--------------");

                boatIndex++;
            }
        }
    }
}
