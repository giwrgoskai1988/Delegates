using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    delegate void Profession();
    class ProfessionSpeaker
    {
        public static void StaticSpeaker()
        {
            Console.WriteLine("Medicine");
        }

        public static int doctorIDCounter = 0;
        int doctorID = doctorIDCounter++;

        public void InstanceSpeaker()
        {
            Console.WriteLine("Doctor " + doctorID);
        }

        public int DifferentSignature()
        {
            Console.WriteLine("FireFighter");
            return 0;
        }

    }
}
