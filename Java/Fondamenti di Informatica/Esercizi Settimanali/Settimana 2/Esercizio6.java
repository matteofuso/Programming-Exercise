import java.util.Scanner;

public class Esercizio6
{
	public static void main(String[] args)
	{
		/*
		Scrivere un programma che definisca un numero razionale positivo n nell'intervallo [0, 32)
		e ne stampi a standard output la codifica binaria in formato a virgola fissa, usando cinque cifre
		binarie per la parte intera e cinque per quella frazionaria. 
		Esempio: 8.5 in base dieci = 01000.10000 in base due.
		Suggerimento: si usino gli algoritmi di conversione da decimale a binario della parte intera e
		della parte frazionaria presentati a lezione.
		*/
		Scanner in;
		float input, frazionaria;
		int intera;
		in = new Scanner(System.in);
		System.out.print("Inserisci il numero da convertire: ");
		input = Float.parseFloat(in.nextLine());
		in.close();
		intera = (int)input % 32;
		frazionaria = input - intera;
		
		System.out.print("Il numero in virgola fissa è: ");
		// Intera
		System.out.print(intera / 16);
		intera %= 16;
		System.out.print(intera / 8);
		intera %= 8;
		System.out.print(intera / 4);
		intera %= 4;
		System.out.print(intera / 2);
		intera %= 2;
		System.out.print(intera);
		// Frazionaria
		System.out.print(".");
		frazionaria *= 2;
		intera = (int)frazionaria;
		frazionaria = frazionaria - intera;
		System.out.print(intera);
		frazionaria *= 2;
		intera = (int)frazionaria;
		frazionaria = frazionaria - intera;
		System.out.print(intera);
		frazionaria *= 2;
		intera = (int)frazionaria;
		frazionaria = frazionaria - intera;
		System.out.print(intera);
		frazionaria *= 2;
		intera = (int)frazionaria;
		frazionaria = frazionaria - intera;
		System.out.print(intera);
		frazionaria *= 2;
		intera = (int)frazionaria;
		frazionaria = frazionaria - intera;
		System.out.print(intera);
	}
}