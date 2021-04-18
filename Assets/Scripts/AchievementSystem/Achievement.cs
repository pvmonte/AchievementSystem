using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Achievement", fileName = "Achievement")]
public class Achievement : ScriptableObject , IObservable<Achievement> , INotificationData
{
    [SerializeField] protected string _name;
    [SerializeField, TextArea(3, 7)] protected string _description;
    [SerializeField] private Sprite _icon;
    [SerializeField] protected int _goalCount;
    [SerializeField] protected int _currentCount;
    [SerializeField] protected bool _achieved;
    protected List<IObserver<Achievement>> _observers = new List<IObserver<Achievement>>();
    public string Name { get => _name; }
    public Sprite Icon { get => _icon; }

    public void ProgressAndTryAchieve()
    {
        if (_achieved)
            return;

        _currentCount++;
        AchieveByCurrentCount();
    }

    void AchieveByCurrentCount()
    {
        _achieved = _currentCount >= _goalCount;
        Notify();
    }

    void Notify()
    {
        foreach (var observer in _observers)
            observer.OnNext(this);
    }

    public void Reset()
    {
        _currentCount = 0;
    }

    public IDisposable Subscribe(IObserver<Achievement> observer)
    {
        if (_observers.Contains(observer))
            return null;

        _observers.Add(observer);
        return new Unsubscriber<Achievement>(_observers, observer);
    }
}

public interface INotificationData
{
    string Name {get;}
    Sprite Icon {get;}
}
