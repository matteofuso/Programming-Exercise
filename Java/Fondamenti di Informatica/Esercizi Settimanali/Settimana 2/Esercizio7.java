import java.util.Scanner;

public class Esercizio7
{
	public static void main(String[] args)
	{
		/*
		Argomento: divisione intera </> e modulo <%>

		Scrivere un programma che

		definisce due orari nel formato "24 ore", ciascuno di quattro cifre (ad esempio, 0900 oppure 1730)
		visualizza sull'output standard il numero di ore e di minuti (separatamente) che intercorrono fra i
		due orari secondo il seguente esempio:
		   primo orario: 0900
		   secondo orario: 1730
		  Tempo trascorso: 8 ore e 30 minuti

		Modificare poi il programma in modo che funzioni correttamente anche se il secondo orario è 
		inferiore al primo (per intervalli di tempo che comprendono la mezzanotte):
		   primo orario: 1730
		   secondo orario: 0900
		  Tempo trascorso: 15 ore e 30 minuti
		*/
		Scanner in;
		int primo, secondo, 
			minutiPrimo, minutiSecondo,
			orePrimo, oreSecondo,
			oreRisultato, minutiRisultato,
			segno, prestito;
		in = new Scanner(System.in);
		System.out.print("Inserisci il primo orario: ");
		primo = Integer.parseInt(in.nextLine());
		System.out.print("Inserisci il secondo orario: ");
		secondo = Integer.parseInt(in.nextLine());
		in.close();
		
		minutiPrimo = primo % 100;
		orePrimo = primo / 100;
		minutiSecondo = secondo % 100;
		oreSecondo = secondo / 100;
		
		minutiRisultato = minutiSecondo - minutiPrimo;
		segno = (minutiRisultato*2+1)%2;
		prestito = (segno-1)/2;
		oreRisultato = (oreSecondo - orePrimo + prestito + 24) % 24;
		minutiRisultato = (minutiRisultato + 60) % 60;
		
		System.out.println("Tempo trascorso: " + oreRisultato + " ore e " + minutiRisultato + " minuti");
	}
}