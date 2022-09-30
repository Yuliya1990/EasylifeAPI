using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EasylifeAPI
{
    public partial class RealEstate
    {
        [Key]
        public int RealEstateid { get; set; }
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        public double Area { get; set; }
        [Required]
        [MaxLength(255)]
        public string Address { get; set; } = null!;
        public byte[]? Photo { get; set; }
        public int Clientid { get; set; }

        public Client Client { get; set; } = null!;
        public List<Order> Orders { get; set; } = new();
    }
}
