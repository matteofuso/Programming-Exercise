using System;

namespace LoZooDiCasaMia
{
    internal class AnimaleDomestico
    {
        // Proprietà
        string specie;
        string razza;
        string verso;
        string cibo;
        Mangiato mangiato;
        int quantitàCiboPosseduto;
        int quantitàCiboMangiatoPerVolta;
        // Override
        public override string ToString()
        {
            return string.Format("{0,-14} {1,-14} {2,-14} {3,-14} {4,-14} {5,-14} {6}", specie, razza, verso, cibo, mangiato, quantitàCiboPosseduto + "gr", quantitàCiboMangiatoPerVolta + "gr");
        }
        // Costruttore
        public AnimaleDomestico()
        {

        }
        public AnimaleDomestico(string specie, string razza, string verso, string mangiato, string cibo, int quantitàCiboMangiatoPerVolta, int quantitàCiboPosseduto)
        {
            SetSpecie(specie);
            SetRazza(razza);
            SetVerso(verso);
            SetMangiato(mangiato);
            SetCibo(cibo);
            SetQuantitàCiboPosseduto(quantitàCiboPosseduto);
            SetQuantitàCiboMangiatoPerVolta(quantitàCiboMangiatoPerVolta);
        }
        // Metodi
        public void AggiugniCibo(int quantità)
        {
            this.quantitàCiboPosseduto += quantità;
            if (this.quantitàCiboPosseduto < 0)
            {
                this.quantitàCiboPosseduto = 0;
            }
        }
        public void Mangia()
        {
            if (this.mangiato != Mangiato.DeveMangiare)
            {
                throw new Exception("L'animale è sazio");
            }
            else if (this.quantitàCiboPosseduto - this.quantitàCiboMangiatoPerVolta < 0)
            {
                throw new Exception("Non c'è abbastanza cibo");
            }
            this.quantitàCiboPosseduto -= this.quantitàCiboMangiatoPerVolta;
            this.mangiato = Mangiato.GiàMangiato;
        }
        // Getters e Setters
        public void SetSpecie(string specie)
        {
            if (specie == "")
            {
                throw new Exception("La specie non può essere vuota");
            }
            this.specie = specie;
        }
        public string GetSpecie()
        {
            return this.specie;
        }
        public void SetRazza(string razza)
        {
            if (razza == "")
            {
                throw new Exception("La razza non può essere vuota");
            }
            this.razza = razza;
        }
        public string GetRazza()
        {
            return this.razza;
        }
        public void SetVerso(string verso)
        {
            if (verso == "")
            {
                throw new Exception("Il verso non può essere vuoto");
            }
            this.verso = verso;
        }
        public string GetVerso()
        {
            return this.verso;
        }
        public void SetCibo(string cibo)
        {
            if (cibo == "")
            {
                throw new Exception("Il cibo non può essere vuota");
            }
            this.cibo = cibo;
        }
        public string GetCibo()
        {
            return this.cibo;
        }
        public void SetMangiato(string mangiato)
        {
            if (!Enum.TryParse(mangiato, out this.mangiato))
            {
                throw new Exception("Lo stato di nutrizione non può essere vuoto o un valore non listato");
            }
        }
        public Mangiato GetMangiato()
        {
            return this.mangiato;
        }
        public void SetQuantitàCiboPosseduto(int quantitàCiboPosseduto)
        {
            if (quantitàCiboPosseduto < 1)
            {
                throw new Exception("La quantità di cibo posseduto deve essere maggiore di zero");
            }
            this.quantitàCiboPosseduto = quantitàCiboPosseduto;
        }
        public int GetQuantitàCiboPosseduto()
        {
            return this.quantitàCiboPosseduto;
        }
        public void SetQuantitàCiboMangiatoPerVolta(int quantitàCiboMangiatoPerVolta)
        {
            if (quantitàCiboMangiatoPerVolta < 1)
            {
                throw new Exception("La quantità di cibo mangiato per volta deve essere maggiore di zero");
            }
            this.quantitàCiboMangiatoPerVolta = quantitàCiboMangiatoPerVolta;
        }
        public int GetQuantitàCiboMangiatoPerVolta()
        {
            return this.quantitàCiboMangiatoPerVolta;
        }
    }
}
