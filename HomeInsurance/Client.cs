using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    namespace HomeInsurance
    {
        public class Client : InsuranceItem
        {
            public string Nume { get; set; }
            public string Cnp { get; set; }

            public override void DisplayInfo()
            {
                Console.WriteLine($"[Client] ID: {ID}, Nume: {Nume}, CNP: {Cnp}");
            }
        }
    }
