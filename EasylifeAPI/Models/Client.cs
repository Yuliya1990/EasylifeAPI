using System;
using System.Collections.Generic;

namespace EasylifeAPI
{
    public partial class Client
    {
        public Client()
        {
            RealEstates = new HashSet<RealEstate>();
        }

        public int Clientid { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int? Age { get; set; }
        public byte[]? Photo { get; set; }

        public virtual ICollection<RealEstate> RealEstates { get; set; }
    }
}
