using System;
using System.Collections.Generic;

namespace EasylifeAPI
{
    public partial class SelectedComponent
    {
        public int SelectedComponentsid { get; set; }
        public int Orderid { get; set; }
        public int CleaningComponentid { get; set; }

        public virtual CleaningComponent CleaningComponent { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
    }
}
