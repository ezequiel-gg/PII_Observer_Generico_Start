using System;

namespace Observer
{
    public class TemperatureReporter : IObserver<K>
    {
        private bool first = true;

        private Temperature last;
        
        private IObservable<K> provider;

        public void StartReporting(IObservable<K> provider)
        {
            this.provider = provider;
            this.first = true;
            this.provider.Subscribe(this);
        }

        public void StopReporting()
        {
            this.provider.Unsubscribe(this);
        }

        public void Update(Temperature value)
        {
            Console.WriteLine($"The temperature is {value.Degrees}°C at {value.Date:g}");
            if (first)
            {
                last = value;
                first = false;
            }
            else
            {
                Console.WriteLine($"   Change: {value.Degrees - last.Degrees}° in " +
                    $"{value.Date.ToUniversalTime() - last.Date.ToUniversalTime():g}");
            }
        }
    }
}