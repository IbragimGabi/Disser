using System;
using System.Collections.Generic;

namespace DisserMVC.Models
{
    public partial class TestQuestion
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public int QuestionType { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
        public string Answer5 { get; set; }
        public string CorrectAnswersId { get; set; }
        public string UserAnswersId { get; set; }
        public string UserFullAnswer { get; set; }
        public int? TestTaskId { get; set; }

        public virtual TestTasks TestTask { get; set; }
    }
}
