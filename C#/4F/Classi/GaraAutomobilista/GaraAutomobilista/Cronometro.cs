using System;

namespace GaraAutomobilista
{
    internal class Cronometro
    {
        TimeSpan _tempo;
        Random _random;
        public Cronometro()
        {
            _random = new Random();
            _tempo = TimeSpan.Zero;
        }
        public TimeSpan Time
        {
            get { return _tempo; }
        }
        public void Simulate()
        {
            _tempo = TimeSpan.FromMilliseconds(_random.Next(60000,240000)); // Da 1:00 minuto a 2:59 minuti
        }
    }
}
