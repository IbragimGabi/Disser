using System;
using System.Collections.Generic;

namespace DisserMVC.Models
{
    public partial class TestTasks
    {
        public TestTasks()
        {
            TestQuestion = new HashSet<TestQuestion>();
        }

        public int Id { get; set; }
        public int? TestId { get; set; }
        public string FlowStateName { get; set; }

        public virtual Tests Test { get; set; }
        public virtual ICollection<TestQuestion> TestQuestion { get; set; }
    }
}
