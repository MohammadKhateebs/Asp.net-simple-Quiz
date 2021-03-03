using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
  
        public class Quiz
        {
            [Key]
            public string id { get; set; }
            public string qustion { get; set; }
            public string option1 { get; set; }
            public string option2 { get; set; }
            public string option3 { get; set; }
            public string option4 { get; set; }
            public string answer { get; set; }
            public string stuanswer { get; set; }
        }
    

    

}
