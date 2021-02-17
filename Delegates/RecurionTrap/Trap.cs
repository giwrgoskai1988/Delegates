using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates.RecurionTrap
{
    delegate void PaymentEvent(object src, BillArgs ea);

    class BillArgs
    {
        public double Cost { get; set; }

        public BillArgs(double c)
        {
            Cost = c;
        }
    }

    abstract class BookKeeper
    {
        public event PaymentEvent Inbox;

        public void Post(object src , double c)
        {
            Inbox(src, new BillArgs(c));
        }
    }


    class UtilityCo:BookKeeper
    {
        public UtilityCo()
        {
            Inbox += new PaymentEvent(this.ReceivePayment);
        }

        public void BeginBilling(BookKeeper bk)
        {
            bk.Post(this, 4.0);
        }

        public void ReceivePayment(object src , BillArgs ea)
        {
            BookKeeper sender = src as BookKeeper;
            Console.WriteLine("Received payment from " + sender);
            sender.Post(this,10.0);
        }
    }


    class HomeOwner : BookKeeper
    {
        public HomeOwner()
        {
            Inbox += new PaymentEvent(ReceiveBill);
        }

        public void ReceiveBill(object src,BillArgs ea)
        {
            BookKeeper sender = src as BookKeeper;
            Console.WriteLine("Paying to " + sender);
            sender.Post(this, ea.Cost);
        }
    }
}
