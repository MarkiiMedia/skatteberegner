using System;

public class Beregning
{
    private const decimal SkattefriGrænse = 1200m; // Samlet skattefri grænse
    private const decimal JulegaveGrænse = 900m;   // Skattefri grænse for julegaver

    public double SkatVedJulegave(decimal julegave, decimal andreGaver)
    {
        Console.WriteLine($"Julegave: {julegave} kr.");
        Console.WriteLine($"Andre gaver: {andreGaver} kr.");

        decimal samletGavebeløb = julegave + andreGaver;
        Console.WriteLine($"Samlet gavebeløb: {samletGavebeløb} kr.");

        decimal skattepligtigtBeløb = 0;

        if (samletGavebeløb <= SkattefriGrænse)
        {
            Console.WriteLine("Samlet gavebeløb er inden for skattefri grænse.");
            skattepligtigtBeløb = 0;
        }
        else
        {
            Console.WriteLine("Samlet gavebeløb overstiger skattefri grænse.");

            if (julegave <= JulegaveGrænse)
            {
                // Julegaven kan holdes ude af beskatningen
                skattepligtigtBeløb = andreGaver;
                Console.WriteLine("Julegaven er skattefri og holdes ude af beskatningen.");
            }
            else
            {
                // Julegaven er skattepligtig og tæller med
                skattepligtigtBeløb = samletGavebeløb - SkattefriGrænse;
                Console.WriteLine("Julegaven overstiger 900 kr. og beskattes.");
            }

            Console.WriteLine($"Skattepligtigt beløb: {skattepligtigtBeløb} kr.");
        }

        double result = (double)Math.Max(skattepligtigtBeløb, 0);
        Console.WriteLine($"Endeligt skattepligtigt beløb: {result} kr.");
        return result;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Beregning beregning = new Beregning();

        // Eksempel: julegave = 900 kr., andre gaver = 500 kr.
        double skat = beregning.SkatVedJulegave(900m, 500m);
        Console.WriteLine($"Skat der skal betales: {skat} kr.");
    }
}
