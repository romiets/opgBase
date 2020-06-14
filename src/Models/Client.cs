using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace opg_201910_interview.Models
{
    public class Client
    {
        public string clientId { get; set; }
        public string fileName { get; set; }

        public DateTime fileDate { get; set; }
        public int order { get; set;  }
    }
}
