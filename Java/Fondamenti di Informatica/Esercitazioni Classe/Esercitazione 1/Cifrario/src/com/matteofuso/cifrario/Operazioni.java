package com.matteofuso.cifrario;

/**
 * Classe che esegue operazioni di cifrazione e decifrazione
 * @author Matteo Fuso
 */
public class Operazioni
{
	/**
	 * Costrutture non utilizzato
	 * @author Matteo Fuso
	 */
	public Operazioni() {}
	
	/**
	 * Cifra un numero con una determinata chiave
	 * @param numero Il numero da cifrare
	 * @param chiave La chiave con cui cifrare il binario
	 * @return Il numero cifrato
	 * @author Matteo Fuso
	 */
	public static int cifra(int numero, int chiave)
	{
		// Cifro
		numero *= 2;
		numero += chiave;
		numero ^= chiave;
		return numero;
	}
	
	/**
	 * Decifra un numero con una determinata chiave
	 * @param numero Il numero da decifrare
	 * @param chiave La chiave con cui decifrare il binario
	 * @return Il numero decifrato
	 * @author Matteo Fuso
	 */
	public static int decifra(int numero, int chiave)
	{
		// Decifro
		numero ^= chiave;
		numero -= chiave;
		numero /= 2;
		return numero;
	}
}