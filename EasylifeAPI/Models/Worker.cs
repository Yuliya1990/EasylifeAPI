using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EasylifeAPI
{
    public partial class Worker
    {
        [Key]
        public int Workerid { get; set; }
        public double WorkExperience { get; set; }
        [MaxLength(100)]
        public string FirstName { get; set; } = null!;
        [MaxLength(100)]
        public string LastName { get; set; } = null!;
        [MaxLength(100)]
        public string Email { get; set; } = null!;
        public int Age { get; set; }
        public byte[]? Photo { get; set; }

        public List<Component> Components { get; set; } = new();
        public List<Order> Orders { get; set; } = new();
    }
}
