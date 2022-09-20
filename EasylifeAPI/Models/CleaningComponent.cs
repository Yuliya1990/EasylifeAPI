using System;
using System.Collections.Generic;

namespace EasylifeAPI
{
    public partial class CleaningComponent
    {
        public CleaningComponent()
        {
            SelectedComponents = new HashSet<SelectedComponent>();
            TypeComponents = new HashSet<TypeComponent>();
            WorkerSkills = new HashSet<WorkerSkill>();
        }

        public int CleaningComponentsid { get; set; }
        public string Name { get; set; } = null!;
        public double TimeMinuts { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<SelectedComponent> SelectedComponents { get; set; }
        public virtual ICollection<TypeComponent> TypeComponents { get; set; }
        public virtual ICollection<WorkerSkill> WorkerSkills { get; set; }
    }
}
