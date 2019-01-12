using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DisserMVC.Models
{
    public class Test
    {
        [Key]
        public int Id { get; set; }
        public List<TestTask> Tasks { get; set; }
    }
}
