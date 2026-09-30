package com.matteofuso.music;

public class Canzone
{
	public Canzone(String titolo, String artista, int durata)
	{
		this.durata = durata;
		this.titolo = titolo;
		this.artista = artista;
	}
	
	public int getDurata()
	{
		return this.durata;
	}
	
	public String getTitolo()
	{
		return this.titolo;
	}
	
	public String getArtista()
	{
		return this.artista;
	}
	
	@Override
	public String toString()
	{
		StringBuilder s = new StringBuilder("Canzone{titolo='");
		s.append(this.titolo);
		s.append("', artista='");
		s.append(this.artista);
		s.append("', durata=");
		s.append(durata);
		s.append("}");
		return s.toString();
	}
	
	int durata;
	String titolo;
	String artista;
}