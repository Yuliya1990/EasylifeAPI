using System;
using System.Collections.Generic;

namespace EasylifeAPI
{
    public partial class Worker
    {
        public Worker()
        {
            WorkerOrders = new HashSet<WorkerOrder>();
            WorkerSkills = new HashSet<WorkerSkill>();
        }

        public int Workerid { get; set; }
        public double WorkExperience { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int Age { get; set; }
        public byte[]? Photo { get; set; }

        public virtual ICollection<WorkerOrder> WorkerOrders { get; set; }
        public virtual ICollection<WorkerSkill> WorkerSkills { get; set; }
    }
}
