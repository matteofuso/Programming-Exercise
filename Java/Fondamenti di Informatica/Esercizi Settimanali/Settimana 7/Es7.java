public class Es7 {
    public static String reverse(String s)
    {
        if (s.length() == 1)
        {
            return s;
        }

        return reverse(s.substring(1)) + s.charAt(0);
    }

    public static void main(String[] args)
    {
        String reversed;
        if (args.length < 1)
        {
            System.err.println("Inserisci tutti gli argomenti a linea di comando");
            System.exit(-1);
        }

        reversed = reverse(args[0]);
        System.out.printf("La stringa %s rovescata è %s", args[0], reversed);
    }
}
