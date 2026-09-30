import java.io.BufferedWriter;
import java.io.FileWriter;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.util.Scanner;
import java.io.File;

public class Write {
    private enum Permission
    {
        R,W,X
    }

    public static boolean hasPermission(File file, Permission permission)
    {
        File parent = file.getAbsoluteFile();
        while (parent != null && !parent.exists())
        {
            parent = parent.getParentFile();
        }

        if (parent == null) return false;
        
        return switch (permission) {
            case R -> parent.canRead();
            case W -> parent.canWrite();
            case X -> parent.canExecute();
        };
    }
    public static void main(String[] args)
    {
        File file = new File("folder1/folder2/file.txt");
        if (hasPermission(file, Permission.W))
        {
            if (!file.exists())
            {
                if (file.getParentFile().mkdirs()){
                    
                } else {
                    System.err.println("Errore imprevisto nella creazione della cartella");
                    System.exit(-1);
                }
            } else if (file.isDirectory())
            {
                System.err.println("Il path fornito è una cartella");
                System.exit(-1);
            }
        } else {
            System.err.println("Non hai il permesso di scrivere in questo percorso");
            System.exit(-1);
        }

        try (BufferedWriter writer = new BufferedWriter(new FileWriter(file, StandardCharsets.UTF_8, true)); Scanner in = new Scanner(System.in)){
            System.out.print("Inserisci una riga da aggiungere al file e premi invio (O premi ctrl+c per uscire): ");
            while (in.hasNextLine())
            {
                writer.write(in.nextLine() + System.lineSeparator());
                System.out.print("Inserisci una riga da aggiungere al file e premi invio (O premi ctrl+c per uscire): ");
            }
            System.out.println();
            System.out.println("Scrittura effettuata con successo");
        } catch (IOException e)
        {
            System.err.println("Errore generico nella scrittura su file");
            System.exit(-1);
        }
    }
}
