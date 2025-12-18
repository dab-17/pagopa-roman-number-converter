namespace ConsoleApp1;
/*
# Implementare un traduttore di numeri romani
# Scrivere un programma che accetti in input un numero romano e restituisca la sua rappresentazione decimale.
# Il programma deve essere in grado di gestire i numeri romani validi, utilizzando le seguenti regole:
# - I simboli romani sono rappresentati da sette lettere: I (1), V (5), X (10), L (50), C (100), D (500) e M (1000).
# - I numeri romani sono scritti combinando questi simboli e sommando i loro valori.
# Tuttavia, ci sono alcune eccezioni:
# - Se un simbolo di valore minore viene posto a sinistra di un simbolo di valore maggiore, il suo valore viene sottratto invece di aggiunto. Ad esempio, IV rappresenta 4, XL rappresenta 40 e CM rappresenta 900.
# - Un numero romano non può avere più di tre simboli uguali consecutivi.
# L'obiettivo è implementare una funzione che prenda una stringa rappresentante un numero romano come input e restituisca il suo equivalente decimale 
*/

public static class RomanNumberConverter
{
    public static int ToDecimal(string input) => ToDecimalV2(input);

    private static int ToDecimalV2(string input)
    {
        int output = 0;
        List<int> values = [.. input
            .Select(c => Enum.Parse<RomanNumber>(c.ToString()))
            .Cast<int>()
        ];

        int current;
        for (int i = 0; i < values.Count; i++)
        {
            current = values[i];
            int? next = GetValueOrNull(values, i+1);

            if (next.HasValue && next.Value > current)
                output -= current;
            else
                output += current;
        }


        Console.WriteLine(input + " = " + output);
        return output;
    }

    private static int ToDecimalV1(string input)
    {
        int output = 0;

        int[] values = [.. input
            .Select(c => Enum.Parse<RomanNumber>(c.ToString()))
            .Cast<int>()
        ];

        int current;
        for (int i = 0; i < values.Length; i++)
        {
            current = values[i];
            int? next = GetValueOrNull(values, i + 1);

            if (next.HasValue && next.Value > current)
                output -= current;
            else
                output += current;
        }

        Console.WriteLine(input + " = " + output);
        return output;
    }

    static int? GetValueOrNull(IEnumerable<int> values, int index)
    {
        int? value;
        value = index < values.Count() ? values.ElementAt(index) : null;
        return value;
    }
}