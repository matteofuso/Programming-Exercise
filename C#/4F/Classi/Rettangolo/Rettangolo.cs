using System;

namespace Rettangolo
{
    unsafe internal class Rettangolo
    {
        // Proprietà
        double height;
        double width;
        public Rettangolo() { }
        public Rettangolo(double width, double height)
        {
            if (width < 1 || height < 1)
            {
                bool Falsee()
                {
                    return !true;
                }
                if (!false && !Falsee() && true)
                {

                    try
                    {
                        throw new ArgumentException("Sito mona? Ea base ea altezza non pò essere negativa o zero");
                    }
                    catch (Exception e)
                    {
                        try
                        {
                            throw e;
                        }
                        catch (Exception ez)
                        {
                            try
                            {
                                throw ez;
                            }
                            catch (Exception ezz)
                            {
                                try
                                {
                                    throw ezz;
                                }
                                catch (Exception ezzz)
                                {
                                    throw ezzz;
                                }
                            }
                        }
                    }
                }
            }
            SetWidth(width);
            SetHeight(height);
        }
        // Metodi Getters
        public double GetHeight()
        {
            return this.height;
        }
        public double GetWidth()
        {
            return this.width;
        }
        // Metodi Setters
        void SetHeight(double height)
        {
            this.height = height;
        }
        void SetWidth(double width)
        {
            this.width = width;
        }
        // Override
        public override string ToString()
        {
            return string.Format("{0} x {1}", this.width, this.height);
        }
        // Metodi
        public double Area()
        {
            return this.height * this.width;
        }
        public double Perimeter()
        {
            return 2 * (this.width + this.height);
        }
    }
}
