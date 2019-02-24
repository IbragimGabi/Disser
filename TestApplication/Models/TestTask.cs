using System.Collections.Generic;

namespace TestApplication.Models
{
    public partial class TestTask
    {
        public TestTask()
        {
            TestQuestion = new HashSet<TestQuestion>();
        }

        public int TestTaskId { get; set; }
        public string FlowStateName { get; set; }

        public virtual Test Test { get; set; }
        public int? TestId { get; set; }

        public virtual ICollection<TestQuestion> TestQuestion { get; set; }
    }
}
