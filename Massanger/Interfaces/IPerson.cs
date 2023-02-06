using SelfStudy.Massanger.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfStudy.Massanger.Interfaces
{
    interface  IPerson
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }
        public Gender gender { get; set; }

    }
}
