import java.util.Scanner;

public class Esercizio5
{
	public static void main(String[] args)
	{
		/*
		Argomento: rappresentazione dei numeri; divisione intera </> e modulo <%>
		Scrivere un programma che

		-definisce un numero intero positivo avente al massimo cinque cifre
		-visualizza sull'output standard le singole cifre del numero, separandole con uno spazio
		
		Ad esempio, il numero 14356 verrà visualizzato come 1 4 3 5 6. Il numero 367 verrà visualizzato come 0 0 3 6 7. 

		Suggerimento: applicare la definizione di notazione posizionale in base 10, studiare le proprietà della divisione intera in Java e del relativo operatore %. Verificare il corretto funzionamento del programma in casi diversi (in particolare, con numeri aventi meno di cinque cifre) e verificare il comportamento del programma in caso di valori di ingresso non ammessi

		-numeri con più di cinque cifre
		-numeri negativi
		-numeri in virgola mobile
		-valore di ingresso non numerico (ad esempio: Ciao)
		*/
		Scanner in;
		int number;
		in = new Scanner(System.in);
		System.out.print("Inserisci il numero da convertire: ");
		number = Integer.parseInt(in.nextLine());
		in.close();
		
		System.out.println(number);
		
		System.out.print("Il numero diviso è: ");
		System.out.print(number / 10000);
		number %= 10000;
		System.out.print(" ");
		System.out.print(number / 1000);
		number %= 1000;
		System.out.print(" ");
		System.out.print(number / 100);
		number %= 100;
		System.out.print(" ");
		System.out.print(number / 10);
		number %= 10;
		System.out.print(" ");
		System.out.print(number);
	}
}