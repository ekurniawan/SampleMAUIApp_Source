using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMAUIApp.Bab6
{
    public class TodoItem
    {
        public int todoId { get; set; }
        public string name { get; set; }
        public string notes { get; set; }
        public bool done { get; set; }
    }
}
