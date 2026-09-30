package com.matteofuso.music;

import com.matteofuso.music.Canzone;
import com.matteofuso.music.CampoSort;
import com.matteofuso.music.AlgoritmoSort;

public class Playlist
{
	public Playlist()
	{
		this.playlist = new Canzone[16];
		this.length = 0;
	}
	
	public Playlist(Canzone[] playlist)
	{
		if (playlist == null)
		{
			throw new IllegalArgumentException("Il riferimento non può essere null");
		}
		this.playlist = playlist;
		this.length = playlist.length;
	}
	
	private void _resize(int length)
	{
		if (length < 1)
		{
			throw new IllegalArgumentException("La lunghezza non può essere minore di 1");
		}
		Canzone[] destination = new Canzone[length];
		System.arraycopy(playlist, 0, destination, 0, Math.min(playlist.length, length));
		this.playlist = destination;
	}
	
	private static void _merge(Canzone[] origin, Canzone[] left, Canzone[] right, CampoSort campoSort)
	{
		int i, j, k;
		boolean addLeft;
		addLeft = false;
		i = j = k = 0;
		
		while (j < left.length && k < right.length)
		{
			switch (campoSort)
			{
				case CampoSort.TITOLO:
					addLeft = left[j].getTitolo().compareToIgnoreCase(right[k].getTitolo()) < 0;
					break;
				case CampoSort.ARTISTA:
					addLeft = left[j].getArtista().compareToIgnoreCase(right[k].getArtista()) < 0;
					break;
				case CampoSort.DURATA:
					addLeft = left[j].getDurata() < right[k].getDurata();
					break;
			}
			if (addLeft)
			{
				origin[i++] = left[j++];
			} else {
				origin[i++] = right[k++];
			}
		}
		
		if (j < left.length)
		{
			System.arraycopy(left, j, origin, i, left.length - j);
		}
		else if (k < right.length)
		{
			System.arraycopy(right, k, origin, i, right.length - k);
		}
	}
	
	private static void _mergeSort(Canzone[] origin, int length, CampoSort campoSort)
	{
		int mid;
		Canzone[] left, right;
		if (length < 1 || origin == null)
		{
			throw new IllegalArgumentException();
		}
		
		if (length < 2)
		{
			return;
		}
		
		mid = length / 2;
		left = new Canzone[mid];
		right = new Canzone[length - mid];
		System.arraycopy(origin, 0, left, 0, mid);
		System.arraycopy(origin, mid, right, 0, length - mid);
		
		Playlist._mergeSort(left, mid, campoSort);
		Playlist._mergeSort(right, length - mid, campoSort);
		Playlist._merge(origin, left, right, campoSort);
	}
	
	public void insert(Canzone canzone)
	{
		if (canzone == null)
		{
			throw new IllegalArgumentException("Il riferimento a canzone non può essere vuoto");
		}
		if (this.length == this.playlist.length)
		{
			this._resize(this.playlist.length * 2);
		}
		this.playlist[this.length++] = canzone;
	}
	
	public void sort(AlgoritmoSort algoritmoSort, CampoSort campoSort)
	{
		switch (algoritmoSort)
		{
			case AlgoritmoSort.SELECTION:
				break;
			case AlgoritmoSort.INSERTION:
				break;
			case AlgoritmoSort.MERGE:
				Playlist._mergeSort(this.playlist, this.length, campoSort);
				break;
		}
	}
	
	@Override
	public String toString()
	{
		if (this.length == 0)
		{
			return "Playlist[0]{}";
		}
		StringBuilder s = new StringBuilder("Playlist[");
		s.append(this.length);
		s.append("]{");
		for (int i = 0; i < this.length - 1; i++)
		{
			s.append(this.playlist[i].toString());
			s.append(", ");
		}
		s.append(this.playlist[this.length - 1].toString());
		s.append("}");
		return s.toString();
	}

	int length;
	Canzone[] playlist;
}