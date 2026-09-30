import java.awt.Rectangle;

public class Esercizio9
{
	public static void main(String[] args)
	{
		/*
		(la classe Rectangle è stata solo accennata in classe. E il suo metodo intersection non è stato presentato in classe. Entrambi sono comunque descritti esaurientemente nella documentazione API di Java)

		Argomento: uso di classi (in particolare uso di classi della libreria standard)

		Il metodo intersection della classe Rectangle calcola l'intersezione di due rettangoli e viene invocato in questo modo 

		  Rectangle r3 = r1.intersection(r2); 

		(si veda anche la Documentazione API).
		Scrivere un programma che 

		costruisca due oggetti rettangolo, definendo per ciascuno di essi le coordinate del vertice in alto a sinistra, altezza e larghezza 
		stampi vertici e dimensioni dei due rettangoli appena costruiti
		stampi vertici e dimensioni della loro intersezione. 
		Cosa succede quando i rettangoli non si sovrappongono?
		*/
		Rectangle r1, r2, r3;
		r1 = new Rectangle(10, 20, 40, 10);
		r2 = new Rectangle(501, 301, 40, 10);
		r3 = r2.intersection(r1);
		System.out.println("Primo rettangolo:");
		System.out.println("Vertice 1:" + r1.getX());
		System.out.println("Vertice 2:" + r1.getY());
		System.out.println("Larghezza:" + r1.getWidth());
		System.out.println("Altezza:" + r1.getHeight());
		System.out.println("Secondo rettangolo:");
		System.out.println("Vertice 1:" + r2.getX());
		System.out.println("Vertice 2:" + r2.getY());
		System.out.println("Larghezza:" + r2.getWidth());
		System.out.println("Altezza:" + r2.getHeight());
		System.out.println("Terzo rettangolo:");
		System.out.println("Vertice 1:" + r3.getX());
		System.out.println("Vertice 2:" + r3.getY());
		System.out.println("Larghezza:" + r3.getWidth());
		System.out.println("Altezza:" + r3.getHeight());
	}
}