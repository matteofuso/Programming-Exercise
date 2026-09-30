import java.util.Locale;
import java.util.Scanner;

public class Es5
{
	public static void main(String[] args)
	{
		Scanner in;
		String line;
		double item, sum;
		Locale locale;
		
		locale = Locale.ITALIAN;
		in = new Scanner(System.in);
		System.out.print("Inserisci la stringa da tockenizzare: ");
		line = in.nextLine();
		in.close();
		
		in = new Scanner(line);
		in.useLocale(locale);
		sum = 0;
		System.out.println("Stringa tockenizzata:");
		while (in.hasNextDouble())
		{
			item = in.nextDouble();
			sum += item;
			System.out.printf(locale, "%.2f", item);
			System.out.println();
		}
		System.out.println();
		System.out.printf(locale, "La somma è: %.2f", sum);
		in.close();
	}
}