using System;
using System.Collections.Generic;

namespace Delegates.Classes
{
    public class SpreadsheetEngineUnsubscriber : IDisposable
    {
        private readonly IObserver<SpreadsheetEngine> _observer; 
        private readonly List<IObserver<SpreadsheetEngine>> _observers;

        public SpreadsheetEngineUnsubscriber(IObserver<SpreadsheetEngine> observer, List<IObserver<SpreadsheetEngine>> observers)
        {
            _observer = observer;
            _observers = observers;
        }

        public void Dispose()
        {
            if (_observer != null && _observers.Contains(_observer))
            {
                _observers.Remove(_observer);
            }
        }
    }
}