using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DisserMVC.Models
{
    public class TestCase
    {
        public string Question { get; set; }
        public List<string> Questions { get; set; }
        public List<int> CorrectAnswersId { get; set; }
        public List<int> AnswersId { get; set; }
    }
}
