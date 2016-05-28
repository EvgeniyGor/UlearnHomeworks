using System;
using System.Diagnostics;

namespace MemoryHandling
{
    public class Timer : IDisposable
    {
        private bool _isDisposed;

        private readonly Stopwatch _stopwatch;

        public Timer()
        {
            _stopwatch = new Stopwatch();
        }

        public Timer Start()
        {
            _stopwatch.Start();
            return this;
        }

        public Timer Continue()
        {
            return Start();
        }

        public long ElapsedMilliseconds => _stopwatch.ElapsedMilliseconds;

        ~Timer()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool fromDisposeMethod)
        {
            if (_isDisposed)
            {
                return;
            }

            if (fromDisposeMethod)
            {
                _stopwatch.Stop();
            }

            _isDisposed = true;
        }
    }
}