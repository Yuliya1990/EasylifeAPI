using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasylifeAPI
{
    public partial class Order
    {
        [Key]
        public int Orderid { get; set; }
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
        [Column(TypeName = "time(0)")]
        public TimeSpan TimeStart { get; set; }
        public double TotalTime { get; set; }
        public double TotalPrice { get; set; }
        public int RealEstateid { get; set; }

        public List<Worker> Workers { get; set; } = new();
        public List<Component> Components { get; set; } = new();
        public RealEstate RealEstate { get; set; } = null!;
    }
}
