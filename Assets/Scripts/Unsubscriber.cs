using System;
using System.Collections.Generic;

public class Unsubscriber<T> : IDisposable
{
    List<IObserver<T>> _observers;
    IObserver<T> _observer;

    public Unsubscriber(List<IObserver<T>> observers, IObserver<T> observer)
    {
        _observers = observers;
        _observer = observer;
    }

    public void Dispose()
    {
        if(_observer != null)
            _observers.Remove(_observer);
    }
}