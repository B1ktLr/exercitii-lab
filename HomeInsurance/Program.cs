namespace HomeInsurance
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Creare obiecte
            var client1 = new Client { ID = "C1", Nume = "Ion Popescu", Cnp = "1234567890123" };
            var casa1 = new Home { ID = "H1", Adresa = "Str. Lalelelor 10", Suprafata = 120 };

            var client2 = new Client { ID = "C2", Nume = "Maria Ionescu", Cnp = "9876543210987" };
            var casa2 = new Home { ID = "H2", Adresa = "Str. Garoafelor 22", Suprafata = 95 };

            var polita1 = new InsurancePolicy(client1, casa1, 100000) { ID = "P1" };
            var polita2 = new InsurancePolicy(client2, casa2, 80000) { ID = "P2" };

            // Lista pentru polimorfism
            List<InsuranceItem> items = new List<InsuranceItem> { client1, casa1, polita1, client2, casa2, polita2 };

            Console.WriteLine("Afisare informatii");
            foreach (var item in items)
            {
                item.DisplayInfo();
            }

            Console.WriteLine("\nPolite cu suma asigurata peste 90.000 RON");
            foreach (var polita in items.OfType<InsurancePolicy>().Where(p => p.SumaAsigurata > 90000))
            {
                Console.WriteLine($"Polita ID: {polita.ID}, Suma: {polita.SumaAsigurata}, Prima: {polita.CalculeazaPrima()}");
            }
        }
        
    }
}
