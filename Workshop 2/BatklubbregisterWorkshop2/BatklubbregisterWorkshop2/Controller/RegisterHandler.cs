using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BatklubbregisterWorkshop2.View;
using BatklubbregisterWorkshop2.Model;
using BatklubbregisterWorkshop2.Controller;

namespace BatklubbregisterWorkshop2.Controller
{
    class RegisterHandler
    {
        private MemberHandler mh;

        public RegisterHandler()
        {
            mh = new MemberHandler();
        }

        public bool Run(Menu m)
        {
            switch (HandleMenu(m))
            {
                //Member options.
                case MenuChoices.Add:
                    mh.Add();
                    break;
                case MenuChoices.Edit:
                    mh.Edit();
                    break;
                case MenuChoices.Remove:
                    mh.Remove();
                    break;
                case MenuChoices.ShowMember:
                    mh.ShowSpecificMember();
                    break;
                case MenuChoices.DetailedList:
                    mh.ShowDetailedMemberList();
                    break;
                case MenuChoices.CompactList:
                    mh.ShowCompactMemberList();
                    break;
                //Boat options.
                case MenuChoices.AddBoat:
                    mh.AddBoat();
                    break;
                case MenuChoices.RemoveBoat:
                    mh.RemoveBoat();
                    break;
                case MenuChoices.EditBoat:
                    mh.EditBoat();
                    break;
                default:
                    break;
            }

            return true;
        }

        private MenuChoices HandleMenu(Menu m)
        {
            MenuChoices mc;

            Console.Clear();

            m.DisplayMenu();
            mc = m.GetMenuChoice();

            return mc;
        }
    }
}
