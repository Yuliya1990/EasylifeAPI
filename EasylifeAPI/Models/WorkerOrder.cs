using System;
using System.Collections.Generic;

namespace EasylifeAPI
{
    public partial class WorkerOrder
    {
        public int Id { get; set; }
        public int Workerid { get; set; }
        public int Orderid { get; set; }

        public virtual Order Order { get; set; } = null!;
        public virtual Worker Worker { get; set; } = null!;
    }
}
