// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography;
using Transport;

Console.WriteLine("Mundus første");

//Prøvet leg med namespace, kender ikke C# nok, men det bruges også i min nye Drupal version så den går jeg med.
namespace Transport
{

    public class TransportBeregner
    {
        public int BeregnPris(double afstandKm, double vaegtKg)
        {
            Console.WriteLine($"Beregner pris for afstand: {afstandKm}km og vægt: {vaegtKg}kg");
            if (afstandKm < 5)
            {
                if (vaegtKg < 10)
                {
                    Console.WriteLine("Transporten er gratis.");
                    return 0;
                }
                else
                    Console.WriteLine("Transport pris: 50kr");
                return 50;
            }
            else
            {
                if (vaegtKg < 10)
                {
                    Console.WriteLine("Transport pris: 75kr");
                    return 75;
                }
                else
                    Console.WriteLine("Transport pris: 100kr");
                return 100;
            }
        }
    }
}
