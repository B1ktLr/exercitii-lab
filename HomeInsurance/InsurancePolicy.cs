using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeInsurance
{
     public class InsurancePolicy : InsuranceItem
     {
            public Client Client { get; set; }
            public Home Casa { get; set; }
            public double SumaAsigurata { get; set; }

            public InsurancePolicy(Client client, Home casa, double suma)
            {
                Client = client;
                Casa = casa;
                SumaAsigurata = suma;
            }

            public double CalculeazaPrima()
            {
                return SumaAsigurata * 0.012; // Exemplu: 1.2% din suma
            }

            public override void DisplayInfo()
            {
                Console.WriteLine($"[Polita] ID: {ID}, Client: {Client.Nume}, Casa: {Casa.Adresa}, Prima: {CalculeazaPrima()}");
            }
     }

}
