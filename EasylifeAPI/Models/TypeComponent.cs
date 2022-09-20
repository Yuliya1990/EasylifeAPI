using System;
using System.Collections.Generic;

namespace EasylifeAPI
{
    public partial class TypeComponent
    {
        public int Id { get; set; }
        public int? Typeid { get; set; }
        public int? Componentid { get; set; }

        public virtual CleaningComponent? Component { get; set; }
        public virtual CleaningType? Type { get; set; }
    }
}
