using System;
using System.Collections.Generic;

namespace EasylifeAPI
{
    public partial class Order
    {
        public Order()
        {
            SelectedComponents = new HashSet<SelectedComponent>();
            WorkerOrders = new HashSet<WorkerOrder>();
        }

        public int Orderid { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan TimeStart { get; set; }
        public double TotalTime { get; set; }
        public double TotalPrice { get; set; }
        public int RealEstateid { get; set; }

        public virtual RealEstate RealEstate { get; set; } = null!;
        public virtual ICollection<SelectedComponent> SelectedComponents { get; set; }
        public virtual ICollection<WorkerOrder> WorkerOrders { get; set; }
    }
}
