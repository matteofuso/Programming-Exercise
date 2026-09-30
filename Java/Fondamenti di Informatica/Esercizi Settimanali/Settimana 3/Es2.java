import java.util.Scanner;

public class Es2
{
	public static void main(String[] args)
	{
		Scanner in;
		String line;
		
		in = new Scanner(System.in);
		System.out.print("Inserisci la stringa da tockenizzare: ");
		line = in.nextLine();
		in.close();
		
		in = new Scanner(line);
		in.useDelimiter("\\\\");
		System.out.println("Stringa tockenizzata:");
		while (in.hasNext())
		{
			System.out.println(in.next());
		}
		System.out.println(System.lineSeparator() + "Fine");
        in.close();
	}
}