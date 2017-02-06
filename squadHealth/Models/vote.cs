using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace squadHealth.Models
{
    public class vote
    {
        public string sprintId { get; set; }
        public string lastUpdateTime { get; set; }
        public string questionNumber { get; set; }
        public string colour { get; set; }
        public string userId {get; set;}
    
    }

    public class teamResult
    {
        public string sprintId { get; set; }
        public string questionNumber { get; set; }
    }
}