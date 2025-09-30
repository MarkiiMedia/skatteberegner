using System;

public class Beregning
{
    private const decimal SkattefriGrænse = 1200m; // Skattefri grænse for gaver i alt
    private const decimal JulegaveGrænse = 900m;   // Skattefri grænse for julegaver

    public double SkatVedJulegave(decimal julegave, decimal andreGaver)
    {
        Console.WriteLine($"Julegave: {julegave} kr.");
        Console.WriteLine($"Andre gaver: {andreGaver} kr.");

        decimal skattepligtigtBeløb = 0;

        if (julegave <= JulegaveGrænse)
        {
            Console.WriteLine("Julegaven er skattefri.");
            skattepligtigtBeløb = andreGaver;
            Console.WriteLine($"Skattepligtigt beløb = andre gaver: {skattepligtigtBeløb} kr.");
        }
        else
        {
            Console.WriteLine("Julegaven overstiger skattefri grænse og er skattepligtig.");
            decimal samletGavebeløb = julegave + andreGaver;
            Console.WriteLine($"Samlet gavebeløb: {samletGavebeløb} kr.");

            if (samletGavebeløb > SkattefriGrænse)
            {
                skattepligtigtBeløb = samletGavebeløb - SkattefriGrænse;
                Console.WriteLine($"Skattepligtigt beløb: {skattepligtigtBeløb} kr.");
            }
            else
            {
                Console.WriteLine("Samlet gavebeløb er inden for skattefri grænse.");
            }
        }

        double result = (double)Math.Max(skattepligtigtBeløb, 0);
        Console.WriteLine($"Endeligt skattepligtigt beløb: {result} kr.");
        return result;
    }
}

// Tilføjet Main-metode for konsolkørsel
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
