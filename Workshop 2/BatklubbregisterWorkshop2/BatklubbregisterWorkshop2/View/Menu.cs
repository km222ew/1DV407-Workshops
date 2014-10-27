using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatklubbregisterWorkshop2.View
{
    enum MenuChoices
    {
        Add,
        Edit,
        Remove,
        ShowMember,
        CompactList,
        DetailedList,
        AddBoat,
        EditBoat,
        RemoveBoat,
        Count
    }

    class Menu
    {
        public void DisplayMenu()
        {
            System.Console.WriteLine("Workshop 2\n");
            System.Console.WriteLine("MEMBER\n");
            System.Console.WriteLine("0. Add new member.");
            System.Console.WriteLine("1. Edit member.");
            System.Console.WriteLine("2. Remove member.");
            System.Console.WriteLine("3. Show specific member.");
            System.Console.WriteLine("4. List members(compact).");
            System.Console.WriteLine("5. List members(full).");

            System.Console.WriteLine();

            System.Console.WriteLine("BOAT\n");
            System.Console.WriteLine("6. Add boat.");
            System.Console.WriteLine("7. Edit boat.");
            System.Console.WriteLine("8. Remove boat.\n");

            System.Console.Write("Choice: ");
        }

        public MenuChoices GetMenuChoice()
        {
            int index;

            if (int.TryParse(Console.ReadLine(), out index) && index >= 0 && index <= (int)MenuChoices.Count)
            {
                switch (index)
                {
                    case (int)MenuChoices.Add:
                        return MenuChoices.Add;

                    case (int)MenuChoices.Edit:
                        return MenuChoices.Edit;

                    case (int)MenuChoices.Remove:
                        return MenuChoices.Remove;

                    case (int)MenuChoices.ShowMember:
                        return MenuChoices.ShowMember;

                    case (int)MenuChoices.CompactList:
                        return MenuChoices.CompactList;

                    case (int)MenuChoices.DetailedList:
                        return MenuChoices.DetailedList;

                    case (int)MenuChoices.AddBoat:
                        return MenuChoices.AddBoat;

                    case (int)MenuChoices.RemoveBoat:
                        return MenuChoices.RemoveBoat;

                    case (int)MenuChoices.EditBoat:
                        return MenuChoices.EditBoat;
                }
            }

            return MenuChoices.Count;
        }
    }
}
