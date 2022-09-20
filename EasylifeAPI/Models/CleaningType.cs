using System;
using System.Collections.Generic;

namespace EasylifeAPI
{
    public partial class CleaningType
    {
        public CleaningType()
        {
            TypeComponents = new HashSet<TypeComponent>();
        }

        public int CleaningTypeid { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<TypeComponent> TypeComponents { get; set; }
    }
}
