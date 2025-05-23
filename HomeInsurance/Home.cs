using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

  namespace HomeInsurance
  {
        public class Home : InsuranceItem
        {
            public string Adresa { get; set; }
            public double Suprafata { get; set; }

            public override void DisplayInfo()
            {
                Console.WriteLine($"[Casa] ID: {ID}, Adresa: {Adresa}, Suprafata: {Suprafata} mp");
            }
        }
  }
