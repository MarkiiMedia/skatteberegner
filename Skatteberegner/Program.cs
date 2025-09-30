using System;

public class Beregning
{
    private const decimal SkattefriGrænse = 1200m; // Skattefri grænse for gaver i alt
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
                skattepligtigtBeløb = samletGavebeløb - SkattefriGrænse;
                Console.WriteLine($"Skattepligtigt beløb før fradrag for julegave: {skattepligtigtBeløb} kr.");

                skattepligtigtBeløb = Math.Max(skattepligtigtBeløb - julegave, 0);
                Console.WriteLine($"Skattepligtigt beløb efter fradrag for julegave: {skattepligtigtBeløb} kr.");
            }
            else
            {
                // Julegaven er skattepligtig og tæller med
                skattepligtigtBeløb = samletGavebeløb - SkattefriGrænse;
                Console.WriteLine($"Julegaven overstiger grænsen og beskattes. Skattepligtigt beløb: {skattepligtigtBeløb} kr.");
            }
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

        // Eksempel: julegave = 900 kr., andre gaver = 300 kr.
        double skat = beregning.SkatVedJulegave(900m, 300m);
        Console.WriteLine($"Skat der skal betales: {skat} kr.");
    }
}
