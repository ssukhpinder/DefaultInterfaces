using System;
using System.Collections.Generic;
using System.Text;

namespace DefaultInterfaces
{
    public interface IOrder
    {
        DateTime DtPurchased { get; }
        decimal TotalPrice { get; }
    }
}
