using System;
using Xunit;
using HomeInsurance;

namespace HomeInsuranceTests
{
    public class HomeInsuranceTests
    {
        [Fact]
        public void InsurancePolicy_ShouldAssignClientAndHome()
        {
            
            var client = new Client { ID = "C001", Nume = "Popescu Ana", Cnp = "1234567890123" };
            var home = new Home { ID = "H001", Adresa = "Str. Rozelor 10", Suprafata = 100 };
            var policy = new InsurancePolicy(client, home, 100000) { ID = "P001" };

            
            Assert.Equal(client, policy.Client);
            Assert.Equal(home, policy.Casa);
            Assert.Equal(100000, policy.SumaAsigurata);
        }

        [Fact]
        public void InsurancePolicy_CalculeazaPrima_ShouldReturnCorrectValue()
        {
            
            var policy = new InsurancePolicy(
                new Client { ID = "C002", Nume = "Ionescu Mihai", Cnp = "9876543210987" },
                new Home { ID = "H002", Adresa = "Str. Lalelelor 8", Suprafata = 85 },
                120000
            );

            
            double prima = policy.CalculeazaPrima();

            
            Assert.Equal(1440, prima); // 1.2% din 120000
        }

        [Fact]
        public void ModifyPolicyAmount_ByValue_ShouldNotChangeOriginal()
        {
            
            var policy = new InsurancePolicy(
                new Client { ID = "C003", Nume = "Gheorghe Elena", Cnp = "4567891234567" },
                new Home { ID = "H003", Adresa = "Bd. Republicii 12", Suprafata = 110 },
                90000
            );

            
            ModifyAmount(policy.SumaAsigurata, 150000);

            
            Assert.Equal(90000, policy.SumaAsigurata);
        }

        [Fact]
        public void ModifyPolicyAmount_ByReference_ShouldChangeOriginal()
        {
            
            var policy = new InsurancePolicy(
                new Client { ID = "C004", Nume = "Stan George", Cnp = "7654321098765" },
                new Home { ID = "H004", Adresa = "Str. Independentei 45", Suprafata = 130 },
                80000
            );

            
            double temp = policy.SumaAsigurata;
            ModifyAmountRef(ref temp, 150000);
            policy.SumaAsigurata = temp;

            
            Assert.Equal(150000, policy.SumaAsigurata);
        }

        // Simulare transmitere prin valoare
        private void ModifyAmount(double amount, double newAmount)
        {
            amount = newAmount;
        }

        // Simulare transmitere prin referinta
        private void ModifyAmountRef(ref double amount, double newAmount)
        {
            amount = newAmount;
        }
    }
}
