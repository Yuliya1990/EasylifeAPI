using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EasylifeAPI
{
    public partial class Client
    {
        [Key]
        public int Clientid { get; set; }
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = null!;
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = null!;
        [Required]
        [MaxLength(100)]
        public string Email { get; set; } = null!;
        public int? Age { get; set; }
        public byte[]? Photo { get; set; }

        public List<RealEstate> RealEstates { get; set; } = new();
    }
}
