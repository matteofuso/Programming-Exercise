import java.io.BufferedReader;
import java.io.IOException;
import java.util.Scanner;
import java.io.File;
import java.io.FileReader;

public class Read {
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
        if (!file.exists())
        {
            System.err.println("Il file specificato non esiste");
            System.exit(-1);
        }
        if (!hasPermission(file, Permission.R))
        {
            System.err.println("Non hai permesso di lettura in questo file");
            System.exit(-1);
        }

        try (Scanner in = new Scanner(new BufferedReader(new FileReader(file)))){
            System.out.println("Ecco il contenuto del file:");
            while (in.hasNextLine())
            {
                System.out.println(in.nextLine());
            }
            System.out.println();
            System.out.println("Lettura effettuata con successo");
        } catch (IOException e)
        {
            System.err.println("Errore generico nella lettura da file");
            System.exit(-1);
        }
    }
}
