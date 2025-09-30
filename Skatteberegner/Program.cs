﻿using System;

public class Beregning
{
    private const decimal SkattefriGrænse = 1200m; // Skattefri grænse for gaver i 2021
    private const decimal JulegaveGrænse = 900m; // Skattefri grænse for julegaver

    public double SkatVedJulegave(decimal julegave, decimal andreGaver)
    {
        decimal samletGavebeløb = julegave + andreGaver;
        Console.WriteLine($"Samlet gavebeløb: {samletGavebeløb}");

        if (samletGavebeløb <= SkattefriGrænse)
        {

            Console.WriteLine("Samlet gavebeløb er inden for skattefri grænse.");
            return 0;
        }
        else
        {
            decimal skattepligtigtBeløb = samletGavebeløb - SkattefriGrænse;
            Console.WriteLine($"Skattepligtigt beløb før julegavefradrag: {skattepligtigtBeløb}");

            if (julegave <= JulegaveGrænse)
            {
                skattepligtigtBeløb -= julegave;
                Console.WriteLine($"Skattepligtigt beløb efter julegavefradrag: {skattepligtigtBeløb}");
            }
             double result = (double)Math.Max(skattepligtigtBeløb, 0);
              Console.WriteLine($"Endeligt skattepligtigt beløb: {result}");
            return result;
        }
    }


    public static void Main(string[] args)
    {
        Beregning beregning = new Beregning();
    }
}