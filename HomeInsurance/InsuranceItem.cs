using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeInsurance
{
    public abstract class InsuranceItem
    {
        public string ID { get; set; }
        public abstract void DisplayInfo();
    }

}
