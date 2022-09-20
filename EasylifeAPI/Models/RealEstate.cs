using System;
using System.Collections.Generic;

namespace EasylifeAPI
{
    public partial class RealEstate
    {
        public RealEstate()
        {
            Orders = new HashSet<Order>();
        }

        public int RealEstateid { get; set; }
        public string Name { get; set; } = null!;
        public double Area { get; set; }
        public string Address { get; set; } = null!;
        public byte[]? Photo { get; set; }
        public int Clientid { get; set; }

        public virtual Client Client { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; }
    }
}
