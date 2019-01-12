using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DisserMVC.Models
{
    public class TestTask
    {
        [Key]
        public int Id { get; set; }
        public Test Test { get; set; }
        public int FlowStateId { get; set; }

        public int TaskType { get; set; }

        public string Question { get; set; }
        public string UserAnswer { get; set; }

        public List<string> Questions { get; set; }
        public List<int> CorrectAnswersId { get; set; }
        public List<int> AnswersId { get; set; }
    }
}
