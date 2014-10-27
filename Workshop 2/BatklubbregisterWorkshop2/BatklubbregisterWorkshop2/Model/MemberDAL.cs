using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace BatklubbregisterWorkshop2.Model
{
    class MemberDAL
    {
        public void SaveRegister(List<Member> m)
        {
            try
            {
                using (Stream stream = File.Open("MemberRegister.bin", FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, m);
                }
            }
            catch
            {
                throw new Exception();
            }
        }

        public List<Member> LoadRegister()
        {
            List<Member> memberRegister;

            try
            {
                using (Stream stream = File.Open("MemberRegister.bin", FileMode.Open))
                {
                    if (stream.Length <= 0)
                        return null;

                    BinaryFormatter bin = new BinaryFormatter();

                    List<Member> register = (List<Member>)bin.Deserialize(stream);

                    memberRegister = register;
                }
            }
            catch
            {
                return null;
            }
            

            return memberRegister;
        }
    }
}
