using System;

namespace Clinica
{
    internal class Termometro
    {
        double _temperatura;
        // Setters
        public void SetTemperatura(double temperatura)
        {
            if (temperatura < 35 || temperatura > 42)
            {
                throw new Exception("La temperatura non è valida");
            }
            _temperatura = temperatura;
        }
        // Getters
        public double GetTemperatura()
        {
            return _temperatura;
        }
    }
}
