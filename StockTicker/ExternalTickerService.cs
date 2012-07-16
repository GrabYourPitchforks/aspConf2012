using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace StockTicker
{
    // Imagine that this is an external service that can push ticker symbols to us
    public class ExternalTickerService : IObservable<decimal>
    {
        public IDisposable Subscribe(IObserver<decimal> observer)
        {
            return new ExternalTickerServiceSubscription(observer);
        }

        private sealed class ExternalTickerServiceSubscription : IDisposable
        {
            private CancellationTokenSource _cts = new CancellationTokenSource();
            private decimal _currentPrice = 100;

            public ExternalTickerServiceSubscription(IObserver<decimal> observer)
            {
                ThreadPool.QueueUserWorkItem(async _ =>
                {
                    while (true)
                    {
                        if (_cts.IsCancellationRequested)
                        {
                            return;
                        }

                        _currentPrice = Math.Round((decimal)((double)_currentPrice + (new Random().NextDouble() - 0.5) / 20), 2);
                        observer.OnNext(_currentPrice);
                        await Task.Delay(TimeSpan.FromSeconds(new Random().NextDouble() * 2 + 0.5));
                    }
                });
            }

            public void Dispose()
            {
                _cts.Cancel();
            }
        }
    }
}
