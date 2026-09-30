public class Esercizio10
{
	public static void main(String[] args)
	{
		/*
		Convertire un numero 'x' (a piacere) di secondi in ore, minuti e secondi.
		*/
		int x, ore, minuti, secondi;
		x = 123456;
		
		minuti = x % 3600;
		ore = x / 3600;
		secondi = minuti % 60;
		minuti /= 60;
		
		System.out.println(x + " secondi corrispondono a " + ore + " ore " + minuti + " minuti " + secondi + " secondi");
	}
}