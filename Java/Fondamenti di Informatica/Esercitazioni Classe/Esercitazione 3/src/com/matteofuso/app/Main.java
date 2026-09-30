package com.matteofuso.app;

import com.matteofuso.music.Canzone;
import com.matteofuso.music.Playlist;
import com.matteofuso.music.CampoSort;
import com.matteofuso.music.AlgoritmoSort;

public class Main
{
	public static void main(String[] args)
	{
		Playlist playlist = new Playlist(new Canzone[] {
			new Canzone("Time", "Pink Floyd", 408),
			new Canzone("Norvegian wood", "Beatles", 124),
			new Canzone("Lucy in the sky", "Beatles", 220),
			new Canzone("Firth of fifth", "Genesis", 577),
			new Canzone("Tequila Sunrise", "Eagles", 173),
			new Canzone("Free as a bird", "Lynyrd Skynyrd", 552),
		});
		playlist.insert(new Canzone("Maggie's Farm", "Bob Dylan", 237));
		playlist.insert(new Canzone("Here comes the sun", "Beatles", 186));
		System.out.println("Array Base");
		System.out.println(playlist);
		System.out.println("\n\rArray Ordinato con Merge Sort:");
		playlist.sort(AlgoritmoSort.MERGE, CampoSort.TITOLO);
		System.out.println(playlist);
	}
}