using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatklubbregisterWorkshop2.Model
{
    [Serializable()]
    class Member
    {
        private string name;
        private string personalNumber;
        private int uniqueID;

        private List<Boat> boatList;

        public Member(string name, string personalNumber, int uniqueID)
        {
            this.name = name;
            this.personalNumber = personalNumber;
            this.uniqueID = uniqueID;

            this.boatList = new List<Boat>();
        }
        #region Member
        public string Name
        { 
            get 
            { 
                return name; 
            }
            set 
            {
                name = value; 
            }
        }

        public string PersonalNumber
        {
            get 
            { 
                return personalNumber; 
            }
            set 
            { 
                personalNumber = value; 
            }
        }

        public int UniqueID
        {
            get
            {
                return uniqueID;
            }
        }
        #endregion

        #region Boat

        public IReadOnlyCollection<Boat> BoatList
        {
            get { return boatList.AsReadOnly(); }
        }

        public void AddBoat(Boat boat)
        {
            boatList.Add(boat);
        }

        public void EditBoat(int index, Boat boat)
        {
            boatList[index].Length = boat.Length;
            boatList[index].Type = boat.Type;
        }

        public void RemoveBoat(int index)
        {
            boatList.RemoveAt(index);
        }

        #endregion
    }
}
