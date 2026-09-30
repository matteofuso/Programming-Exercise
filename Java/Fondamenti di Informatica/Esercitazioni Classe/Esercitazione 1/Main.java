import java.util.Scanner;
import com.matteofuso.cifrario.Operazioni;

/**
 * Classe di ingresso del programma
 * @author Matteo Fuso
 */
public class Main
{
	/**
	 * Costrutture non utilizzato
	 * @author Matteo Fuso
	 */
	public Main(){}
	
	/**
	 * Chiede di inserire all'utente un numero intero a base variabile finché un numero valido è stato inserito
	 * @param in Stream di input
	 * @param message Messaggio stampato per la richiesta del numero
	 * @param error Messaggio stampato in caso di error
	 * @param base La base in cui è rappresentato il numero
	 * @return L'intero inserito dall'utente
	 * @author Matteo Fuso
	 */
	public static int readInt(Scanner in, String message, String error, int base)
	{
		int result = 0;
		boolean valid = false;
		// Scanner in = new Scanner(System.in);
		// Chiedo di inserire un numero finchè non è valido
		do
		{
			System.out.print(message);
			// Controllo se il numero inserito è valido
			try 
			{
				result = Integer.parseInt(in.nextLine(), base);
				valid = true;
			} catch (NumberFormatException e)
			{
				// Se il valore inserito non è una stringa, cambio il messaggio
				message = error;
			}
		} while (!valid);
		// in.close();
		return result;
	}
	
	/**
	 * Chiede di inserire all'utente un numero intero in base 10 finché un numero valido è stato inserito
	 * @param in Stream di input
	 * @param message Messaggio stampato per la richiesta del numero
	 * @param error Messaggio stampato in caso di error
	 * @return L'intero inserito dall'utente
	 * @author Matteo Fuso
	 */
	public static int readInt(Scanner in, String message, String error)
	{
		return readInt(in, message, error, 10);
	}
	
	/**
	 * Punto di ingresso del programma
	 * @param args Argomenti a linea di comando
	 * @author Matteo Fuso
	 */
	public static void main(String[] args)
	{
		// Dichiarazione delle variabili
		int numero, chiave, 
			cifrato, decifrato;
		Scanner in;
		
		// Chiedo in input il numero e la chiave
		in = new Scanner(System.in);
		numero = readInt(in, "Inserisci il numero da cifrare in binario: ", "Perfavore inserisci un numero binario: ", 2);
		chiave = readInt(in, "Inserisci la chiave di cifratura: ", "Perfavore inserisci un numero intero: ");
		in.close();
		
		// Eseguo le operazioni di cifrazione e decifrazione
		cifrato = Operazioni.cifra(numero, chiave);
		decifrato = Operazioni.decifra(cifrato, chiave);
		
		// Stampo i valori ottenuti
		System.out.println("Il numero cifrato è: " + Integer.toBinaryString(cifrato));
		System.out.println("Il numero decifrato è: " + Integer.toBinaryString(decifrato));
	}
}