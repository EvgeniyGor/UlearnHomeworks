using System;

namespace Delegates.Classes
{
    public class SpreadsheetApplication : IObserver<SpreadsheetEngine>
    {
        private IDisposable _unsubscriber;

        public void Subscribe(IObservable<SpreadsheetEngine> provider)
        {
            if (provider != null)
            {
                _unsubscriber = provider.Subscribe(this);
            }
        }

        public void Unsubscribe()
        {
            _unsubscriber.Dispose();
        }

        public void OnNext(SpreadsheetEngine value)
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }
    }
}