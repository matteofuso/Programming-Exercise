package com.matteofuso.music;

import com.matteofuso.music.Genere;

public class Brano
{
	public Brano(String titolo, String artista, int durata, Genere genere, int anno, int bpm)
	{
		this.titolo = titolo;
		this.artista = artista;
		this.durata = durata;
		this.genere = genere;
		this.anno = anno;
		this.bpm = bpm;
	}
	
	public String getTitolo()
	{
		return this.titolo;
	}
	
	public String getArtista()
	{
		return this.artista;
	}
	
	public int getDurata()
	{
		return this.durata;
	}
	
	public Genere getGenere()
	{
		return this.genere;
	}
	
	public int getAnno()
	{
		return this.anno;
	}
	
	public int getBpm()
	{
		return this.bpm;
	}
	
	public void setTitolo(String titolo)
	{
		this.titolo = titolo;
	}
	
	public void setArtista(String artista)
	{
		this.artista = artista;
	}
	
	public void setDurata(int durata)
	{
		this.durata = durata;
	}

	public void setGenere(Genere genere)
	{
		this.genere = genere;
	}
	
	public void setAnno(int anno)
	{
		this.anno = anno;
	}
	
	public void setBpm(int bpm)
	{
		this.bpm = bpm;
	}
	
	@Override
	public String toString()
	{
		return "Brano{titolo='" + this.titolo + "', artista='" + this.artista + 
			"', durata=" + this.durata + ", genere='" + this.genere.toString() + "' anno=" + this.anno +
			", bpm=" + this.bpm + "}";
	}
	
	public String analizzaBrano()
	{
		String durata, epoca, tempo, utilizzi;
		Genere confrontoGenere;
		StringBuilder builder = new StringBuilder();
		
		// Confronto della durata
		if (this.durata < 180)
		{
			durata = "Breve (meno di 3 minuti)";
		} else if (this.durata < 300)
		{
			durata = "Media (tra 3 e 5 minuti)";
		} else {
			durata = "Lunga (più di 5 minuti)";
		}
		
		// Confronto dell'epoca
		if (this.anno < 1970)
		{
			epoca = "Classico";
		} else if (this.anno < 1990)
		{
			epoca = "Vintage";
		} else if (this.anno < 2010) {
			epoca = "Moderno";
		} else {
			epoca = "Contemporanea";
		}
		
		// Confronto del tempo
		if (this.bpm < 80)
		{
			tempo = "Lento";
		} else if (this.anno < 120)
		{
			tempo = "Moderato";
		} else if (this.anno < 160) {
			tempo = "Veloce";
		} else {
			tempo = "Molto veloce";
		}
		
		// Suggerimenti utilizzi
        if (this.bpm < 100) {
            utilizzi = "Relax, meditazione";
        } else if (this.bpm < 130) {
            utilizzi = "Ascolto casual, sottofondo per lavoro";
        } else {
            utilizzi = "Allenamento, festa";
        }
		
		// Contfronto genere
		if (this.anno < 1980)
		{
			confrontoGenere = Genere.Rock;
		} else if (this.anno < 1990) {
			confrontoGenere = Genere.Pop;
		} else if (this.anno > 2019 && this.anno < 2030) {
			confrontoGenere = Genere.Grunge;
		} else {
			confrontoGenere = Genere.ND;
		}
		
		builder.append("Durata: ");
		builder.append(durata);
		builder.append("\n\r");
		builder.append("Epoca: ");
		builder.append(epoca);
		builder.append("\n\r");
		builder.append("Tempo: ");
		builder.append(tempo);
		builder.append("\n\r");
		builder.append("Possibili utilizzi: ");
		builder.append(utilizzi);
		builder.append("\n\r");
		if (confrontoGenere == this.genere) {
			builder.append("Confronto con genere popolare del decennio: Il genere del brano corrisponde al genere popolare del decennio (");
			builder.append(this.genere.toString());
			builder.append(")");

		} else {
			builder.append("Confronto con genere popolare del decennio: Il genere del brano (");
			builder.append(this.genere.toString());
			builder.append(") differisce dal genere popolare del decennio (");
			builder.append(confrontoGenere.toString());
			builder.append(")");
		}
		builder.append("\n\r");
		
		return builder.toString();
	}
	
	String titolo;
	String artista;
	int durata;
	Genere genere;
	int anno;
	int bpm;
}