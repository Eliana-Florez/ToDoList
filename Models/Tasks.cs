using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    public class Tasks
    {
        public string id { get; set; }

        public string taskName { get; set; }

        public bool isComplete { get; set; }

        private string _date() {
            var dateAndTime = DateTime.Now;
            var Date = dateAndTime.ToShortDateString();
            return Date;
        }

        public string TaskDate
        { 
            get => _date();
        }

    }
}
