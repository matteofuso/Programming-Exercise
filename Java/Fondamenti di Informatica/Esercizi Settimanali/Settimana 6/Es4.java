import java.util.Scanner;

public class Es4
{
	public static boolean isSubString(String origin, String subString)
	{
		if (origin == null | subString == null)
		{
			throw new IllegalArgumentException();
		}
		
		if (subString.length() == 0)
		{
			return true;
		}
		
		if (origin.length() == 0)
		{
			return false;
		}
		
		boolean valid = false;
		for(int i = 0; i < origin.length() && !valid; i++)
		{
			if (origin.charAt(i) == subString.charAt(0))
			{
				if (i + subString.length() > origin.length())
				{
					return false;
				}
				valid = true;
				for (int j = 1; j < subString.length() && valid; j++)
				{
					if (subString.charAt(j) != origin.charAt(j+i))
					{
						valid = false;
					}
				}
			}
		}
		return valid;
	}
	
	public static void main(String[] args)
	{
		String s1, s2;
		Scanner in;
		in = new Scanner(System.in);
		
		System.out.print("Inserisci la string principale: ");
		s1 = in.nextLine();
		System.out.print("Inserisci la stringa da cercare: ");
		s2 = in.nextLine();
		in.close();
		
		if (isSubString(s1, s2))
		{
			System.out.println(s2 + " è una sottostring di " + s1);
		} else {
			System.out.println(s2 + " non è una sottostring di " + s1);
		}
	}
}