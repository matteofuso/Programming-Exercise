package com.matteofuso.app;

import com.matteofuso.music.Brano;
import com.matteofuso.music.Genere;

public class Main
{
    public static void main(String[] args)
    {
        Brano brano1 = new Brano(
                "Bohemian Rhapsody",
                "Queen",
                354,
                Genere.Rock,
                1975,
                72
        );

        Brano brano2 = new Brano(
                "Billie Jean",
                "Michael Jackson",
                294,
                Genere.Pop,
                1983,
                117
        );

        Brano brano3 = new Brano(
                "Blinding Lights",
                "The Weeknd",
                200,
                Genere.Synth_pop,
                2020,
                171
        );

        System.out.println("Brano 1:");
        System.out.println(brano1);
        System.out.println();

        System.out.println("Brano 2:");
        System.out.println(brano2);
        System.out.println();

        System.out.println("Brano 3:");
        System.out.println(brano3);
        System.out.println();

        System.out.println("Analisi Brano 1:");
        System.out.println(brano1.analizzaBrano());
        System.out.println();

        System.out.println("Analisi Brano 2:");
        System.out.println(brano2.analizzaBrano());
        System.out.println();

        System.out.println("Analisi Brano 3:");
        System.out.println(brano3.analizzaBrano());
        System.out.println();
    }
}
