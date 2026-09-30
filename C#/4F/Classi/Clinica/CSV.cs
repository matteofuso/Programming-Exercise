using System;
using System.Linq;

namespace Clinica
{
    internal class CSV
    {
        public static string SanitizeValue(string value)
        {
            if (value.Contains(','))
            {
                value.Replace("\"", "\"\"");
                value = "\"" + value + "\"";
            }
            return value;
        }
        public static string[] Load(string row)
        {
            bool inside = false;
            string support = "";
            int times = Count(row, '"');
            if (times == 0)
            {
                return row.Split(',');
            }
            if (times % 2 == 1)
            {
                throw new Exception("Formattazione non valida");
            }
            for (int i = 0; i < row.Length - 1; i++)
            {
                if (row[i] == '"')
                {
                    if (row[i + 1] == '"')
                    {
                        i++;
                        support += '"';
                    }
                    else
                    {
                        inside = !inside;
                    }
                }
                else
                {
                    if (inside && row[i] == ',')
                    {
                        support += '\0';
                    }
                    else
                    {
                        support += row[i];
                    }
                }
            }
            return support.Split(',').Select(e => e.Replace('\0', ',')).ToArray();
        }
        static int Count(string stringa, char carattere)
        {
            int times = 0;
            foreach (char c in stringa)
            {
                if (c == carattere)
                {
                    times++;
                }
            }
            return times;
        }
    }
}
