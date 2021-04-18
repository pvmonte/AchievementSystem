using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AchievementNotification : Notification , IObservable<AchievementNotification>
{       
    [SerializeField] MultiAnimationFlow animationFlow;

    List<IObserver<AchievementNotification>> _observers = new List<IObserver<AchievementNotification>>();

    protected void Start()
    {
        StartCoroutine(NotifyFlow());
    }

    public override IEnumerator NotifyFlow()
    {
        yield return animationFlow.Play();        
        NotifyEndNotifyFlow();
    }

    public override void PopulateNotificationValues(INotificationData achievement)
    {        
        nameLabel.text = achievement.Name;
        icon.sprite = achievement.Icon;
    }

    public IDisposable Subscribe(IObserver<AchievementNotification> observer)
    {
        if (_observers.Contains(observer))
            return null;

        _observers.Add(observer);
        return new Unsubscriber<AchievementNotification>(_observers, observer);
    }

    void NotifyEndNotifyFlow()
    {
        foreach (var observer in _observers)
            observer.OnNext(this);

        gameObject.SetActive(false);
    }
}


