using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AchievementSystem : MonoBehaviour , IObserver<Achievement>
{
    public static AchievementSystem _instance;
    //[SerializeField] NotificationPosition _notificationPosition;
    string achievementsPath = "Achievements";
    [SerializeField] List<Achievement> _achievements;
    public UnityEvent<INotificationData> onAchieve;

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else if(_instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Achievement[] achievements = Resources.LoadAll<Achievement>(achievementsPath);

        for (int i = 0; i < achievements.Length; i++)
        {
            _achievements.Add(achievements[i]);
            _achievements[i].Subscribe(this);
        }
    }
    
    public void ProgressAchievementWithName(string name)
    {
        Achievement achievement = FindAchievementByName(name);
        achievement.ProgressAndTryAchieve();
        Debug.Log($"Progressing achievement {name}");
    }

    private Achievement FindAchievementByName(string name)
    {
        return _achievements.Find(a => a.Name.Equals(name));
    }

    public void ClearAchievements()
    {
        Achievement[] achievements = Resources.LoadAll<Achievement>(achievementsPath);

        foreach (var item in _achievements)
        {
            item.Reset();
            Debug.Log($"Cleaning achievement {item.Name}");
        }

        Debug.Log($"All achievements clean");
    }

    public void OnCompleted()
    {
        throw new NotImplementedException();
    }

    public void OnError(Exception error)
    {
        throw new NotImplementedException();
    }

    public void OnNext(Achievement value)
    {
        INotificationData notification = (INotificationData)value;
        onAchieve?.Invoke(notification);
    }
}


public enum NotificationPosition
{
    TopLeft,
    TopCenter,
    TopRight,
    BottomLeft,
    BottomCenter,
    BottomRight
}