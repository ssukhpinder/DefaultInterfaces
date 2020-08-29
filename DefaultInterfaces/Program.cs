using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace DefaultInterfaces
{
    public class SampleCustomer : ICustomer
    {
        private string _name;
        private DateTime _dtCreated;
        private IDictionary<DateTime, string> _reminders;
        private List<IOrder> _pastOrders;

        public SampleCustomer(string name, DateTime dtCreated, IDictionary<DateTime, string> reminders)
        {
            _name = name;
            _dtCreated = dtCreated;
            _reminders = reminders;
            _pastOrders = new List<IOrder>();
        }

        List<IOrder> ICustomer.PastOrders => _pastOrders;
        DateTime ICustomer.DtCreated => _dtCreated;

        DateTime? ICustomer.LastOrder => null;

        string ICustomer.Name => _name;

        IDictionary<DateTime, string> ICustomer.Reminders => _reminders;

        internal void AddOrder(SampleOrder o)
        {
            _pastOrders.Add(o);
        }
    }
    public class SampleOrder : IOrder
    {
        private DateTime _dateTime;
        private decimal _price;

        public SampleOrder(DateTime dateTime, decimal value)
        {
            _dateTime = dateTime;
            _price = value;
        }

        public DateTime DtPurchased => _dateTime;

        public decimal TotalPrice => _price;
    }
    class Program
    {
        static void Main(string[] args)
        {

            IDictionary<DateTime, string> reminders = new Dictionary<DateTime, string>();
            reminders.Add(new DateTime(2010, 08, 12), "childs's birthday");
            reminders.Add(new DateTime(1012, 11, 15), "anniversary");

            SampleCustomer c = new SampleCustomer("customer one", new DateTime(2010, 5, 31),reminders);

            SampleOrder o = new SampleOrder(new DateTime(2012, 6, 1), 5m);
            c.AddOrder(o);

            o = new SampleOrder(new DateTime(2103, 7, 4), 25m);
            c.AddOrder(o);

            // Check the discount:
            ICustomer theCustomer = c;
            Console.WriteLine($"Offer: {theCustomer.ComputeLoyaltyDiscount()}");

            Console.ReadLine();
        }
    }
}
