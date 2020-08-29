using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefaultInterfaces
{
    public interface ICustomer
    {
        List<IOrder> PastOrders { get; }
        DateTime DtCreated { get; }
        DateTime? LastOrder { get; }
        string Name { get; }
        IDictionary<DateTime, string> Reminders { get; }
        public decimal ComputeLoyaltyDiscount()
        {
            DateTime TwoYearsAgo = DateTime.Now.AddYears(-2);
            if ((DtCreated < TwoYearsAgo) && (PastOrders.Count() > 1))
            {
                return 0.10m;
            }
            return 0;
        }
    }
}
