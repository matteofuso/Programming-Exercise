public class Es4 {

    public static boolean isPalindromo(String s)
    {
        String normalised;
        StringBuilder b = new StringBuilder();
        if (s.length() < 2)
        {
            return true;
        }

        for (char c : s.toCharArray())
        {
            if (Character.isAlphabetic(c))
            {
                b.append(Character.toLowerCase(c));
            }
        }

        normalised = b.toString();

        return normalised.charAt(0) == normalised.charAt(normalised.length() - 1) && isPalindromo(normalised.substring(1, normalised.length() - 1));
    }

    public static void tester(String s)
    {
        System.out.printf("La stringa \"%s\" %s palindroma %s", s, isPalindromo(s) ? "è" : "non è", System.lineSeparator());
    }

    public static void main(String[] args)
    {
        tester("ANNA");
        tester("Radar");
        tester("anno");
        tester("taSto");
        tester("è");
        tester("");
        tester("Madam, I'm Adam!");
    }    
}
