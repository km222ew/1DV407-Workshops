using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatklubbregisterWorkshop2.Model
{

    [Serializable()]
    class Boat
    {
        private string type;
        private int length;

        public Boat(string bt, int bl)
        {
            this.type = bt;
            this.length = bl;
        }

        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        public int Length
        {
            get
            {
                return length;
            }
            set
            {
                length = value;
            }
        }
    }
}
