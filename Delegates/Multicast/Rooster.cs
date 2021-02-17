using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates.Multicast
{
    class Rooster
    {
        public void Crow()
        {
            Console.WriteLine("Cock-a-doodle-doo");
        }
    }

    class PaperBoy
    {
        public void DeliverPapers()
        {
            Console.WriteLine("Throw paper in garden");
        }
    }

    class Sun
    {
        public void Rise()
        {
            Console.WriteLine("House of the rising sun");
        }
    }


    class DrawRoutine
    {
        public delegate void DawnBehavior();
        DawnBehavior multicast;

        public DrawRoutine()
        {
            multicast = new DawnBehavior(new Rooster().Crow);
            multicast += new DawnBehavior(new PaperBoy().DeliverPapers);
            multicast += new DawnBehavior(new Sun().Rise);
        }

        public void Break()
        {
            multicast();
            
        }
    }
}
