using Delegates.Events;
using Delegates.Handlers;
using Delegates.Multicast;
using Delegates.RecurionTrap;
using System;
using static Delegates.Handlers.Client;
using static System.Net.Mime.MediaTypeNames;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            Profession p;

            p = new Profession(ProfessionSpeaker.StaticSpeaker);

            p();

            ProfessionSpeaker s1 = new ProfessionSpeaker();
            ProfessionSpeaker s2 = new ProfessionSpeaker();

            Profession p1 = new Profession(s1.InstanceSpeaker);
            Profession p2 = new Profession(s2.InstanceSpeaker);

            p1();
            p2();
            Console.WriteLine("----------------------------------------------------------------------");

            //2

            DrawRoutine dr = new DrawRoutine();
            dr.Break();

            Console.WriteLine("----------------------------------------------------------------------");

            //3


            IHandler handler = new ConcreteHandler1();

            PolyDel del = new PolyDel(handler.HandleRequest);
            del += new PolyDel(AlsoHandler);

            del();

            Console.WriteLine("----------------------------------------------------------------------");


            //4

            BookKeeper ho = new HomeOwner();
            UtilityCo uc = new UtilityCo();

            uc.BeginBilling(ho);

        }
    }
}
