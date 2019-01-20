using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DisserMVC.Models
{
    public partial class Test
    {
        public Test()
        {
            TestTasks = new HashSet<TestTask>();
        }

        public int TestId { get; set; }
        public ApplicationUser User { get; set; }
        public string TestFile { get; set; }

        public virtual ICollection<TestTask> TestTasks { get; set; }
    }
}
