using System;

namespace Biglietto
{
    internal class Cilindrata
    {
        static void Main(string[] args)
        {
            string tipo;
            int cilindrata;
            const float costoFisso = 20, macchina1000 = 20, macchina2000 = 30, macchinaOltre = 0.1f;
            const float camion2000 = 40, camion3000 = 50, camionOltre = 1;
            float costo;

            Console.Write("Inserisci il tipo di vettura (Autovettura/Camion): ");
            tipo = Console.ReadLine();
            if (tipo == "Autovettura" || tipo == "Camion" || tipo == "autovettura" || tipo == "camion")
            {
                Console.Write("Inserire la cilindrata: ");
                cilindrata = Convert.ToInt32(Console.ReadLine());
                if (tipo == "Autovettura" || tipo == "autovettura")
                {
                    // Macchina
                    if (cilindrata > 2000)
                    {
                        costo = costoFisso * (1 + macchinaOltre);
                    }
                    else
                    {
                        if (cilindrata < 1000)
                        {
                            costo = costoFisso + macchina1000;
                        }
                        else
                        {
                            costo = costoFisso + macchina2000;
                        }
                    }
                    Console.WriteLine("Con la tua macchina devi pagare {0:n2} Euro", costo);
                }
                else
                {
                    // Camion
                    if (cilindrata > 3000)
                    {
                        costo = costoFisso * (1 + camionOltre);
                    }
                    else
                    {
                        if (cilindrata < 2000)
                        {
                            costo = costoFisso + camion2000;
                        }
                        else
                        {
                            costo = costoFisso + camion3000;
                        }
                    }
                    Console.WriteLine("Con il tuo camion devi pagare {0:n2} Euro", costo);
                }
            }
            else
            {
                Console.WriteLine("Tipo non riconosciuto, riavviare il programma...");
            }
            Console.ReadLine();
        }
    }
}