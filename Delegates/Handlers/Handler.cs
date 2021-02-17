using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates.Handlers
{
    public interface IHandler
    {
        void HandleRequest();
    }

    class ConcreteHandler1:IHandler
    {
        Random r = new Random();

        IHandler successor = new ConcreteHandler2();

        public void HandleRequest()
        {
            if(r.NextDouble() > 0.5)
            {
                Console.WriteLine("CH1 : Handling incomplete!");
                successor.HandleRequest();
            }
            else
                Console.WriteLine("CH1 : Handling Complete!!");
        }
    }


    class ConcreteHandler2:IHandler
    {
        public void HandleRequest()
        {
            Console.WriteLine("CH2 : Handling!");
        }
    }

    class Client
    {
        public delegate void PolyDel();

        public static void AlsoHandler()
        {
            Console.WriteLine("AlsoHandler");
        }
    }
}
