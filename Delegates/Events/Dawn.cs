using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates.Events
{
    delegate void DawnDelegate(object source, DawnEventArgs dea);

    enum Weather{ Sunny,Rainy}

    class DawnEventArgs:EventArgs
    {
        public Weather MorningWeather { get; set; }
        private DawnEventArgs() : base() { }

        public DawnEventArgs(Weather w)
        {
            MorningWeather = w;
        }
    }

    class DawnBehavior
    {

        public event DawnDelegate DawnEvent1;

        //public DawnDelegate DawnEvent2 { get; set; }

        //public static void Main()
        //{
        //    DawnBehavior db = new DawnBehavior();
        //    db.DawnEvent1 = new DawnDelegate(
        //    new Rooster2().Crow);
        //    db.DawnEvent1 += new DawnDelegate(
        //    new Sun2().Rise);
        //    DawnEventArgs dea =
        //    new DawnEventArgs(Weather.Sunny);
        //    db.DawnEvent1(typeof(DawnBehavior), dea);
        //    dea = new DawnEventArgs(Weather.Rainy);
        //    db.DawnEvent1(typeof(DawnBehavior), dea);
        //}
    }


    class Rooster2
    {
        public void Crow(object src, DawnEventArgs dea)
        {
            if(dea.MorningWeather == Weather.Sunny)
                Console.WriteLine("Cock-a-doodle");
            else
                Console.WriteLine("Sleep in");
        }
    }

    class Sun2
    {
        public void Rise(object src , DawnEventArgs dea)
        {
            if (dea.MorningWeather == Weather.Sunny)
                Console.WriteLine("Rising");
            else
                Console.WriteLine("No sun for you today!");

        }
    }

}
