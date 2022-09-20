using System;
using System.Collections.Generic;

namespace EasylifeAPI
{
    public partial class WorkerSkill
    {
        public int Id { get; set; }
        public int Workerid { get; set; }
        public int SkillId { get; set; }

        public virtual CleaningComponent Skill { get; set; } = null!;
        public virtual Worker Worker { get; set; } = null!;
    }
}
