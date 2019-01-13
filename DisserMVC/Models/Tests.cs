using System;
using System.Collections.Generic;

namespace DisserMVC.Models
{
    public partial class Tests
    {
        public Tests()
        {
            TestTasks = new HashSet<TestTasks>();
        }

        public int Id { get; set; }
        public ApplicationUser User { get; set; }

        public virtual ICollection<TestTasks> TestTasks { get; set; }
    }
}
