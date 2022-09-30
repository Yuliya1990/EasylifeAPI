using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasylifeAPI
{
    public partial class Component
    {
        [Key]
        public int Componentsid { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        public double TimeMinuts { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }


        public List<Cleaning> Cleanings { get; set; } = new();
        public List<Order> Orders { get; set; } = new();
        public List<Worker> Workers { get; set; } = new();
    }
}
