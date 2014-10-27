using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BatklubbregisterWorkshop2.View;
using BatklubbregisterWorkshop2.Model;
using BatklubbregisterWorkshop2.Controller;

namespace BatklubbregisterWorkshop2
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu m = new Menu();
            Controller.RegisterHandler c = new Controller.RegisterHandler();

            while (c.Run(m));
        }
    }
}
