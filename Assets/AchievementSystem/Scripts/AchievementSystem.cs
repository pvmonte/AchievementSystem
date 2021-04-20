using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UgglaGames.Gerals;

namespace UgglaGames.AchievementSystem
{
    /// <summary>
    /// The manager of Achievement System
    /// </summary>
    public class AchievementSystem : MonoBehaviour, IObserver<Achievement>
    {
        public static AchievementSystem _instance;
        //[SerializeField] NotificationPosition _notificationPosition; TODO
        string achievementsPath = "Achievements";
        [SerializeField] List<Achievement> _achievements;

        public NotificationEvent OnAchieve;

        [Serializable]
        public class NotificationEvent : UnityEvent<INotificationData>
        {

        }

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else if (_instance != this)
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            LoadAchievementsAndAddToList();
        }

        /// <summary>
        /// Load achievements and add them to list
        /// </summary>
        private void LoadAchievementsAndAddToList()
        {            
            var achievements = Resources.LoadAll<Achievement>(achievementsPath);

            for (int i = 0; i < achievements.Length; i++)
            {
                ListAchievementSubscribeAsObserver(achievements[i]);
            }
        }

        /// <summary>
        /// Lists "achievement" and subscribes this as achievement observer
        /// </summary>
        /// <param name="achievement"></param>
        void ListAchievementSubscribeAsObserver(Achievement achievement)
        {
            achievement.Subscribe(this);
            _achievements.Add(achievement);            
        }

        /// <summary>
        /// Progress the achievement with name "name"
        /// </summary>
        /// <param name="name"></param>
        public void ProgressAchievementWithName(string name)
        {
            Achievement achievement = FindAchievementByName(name);

            //if achievement is null, prevent the error
            if (achievement.Equals(null))
                return;

            achievement.ProgressAndTryAchieve();
        }

        /// <summary>
        /// Search in the list of achievements for the achievement with name "name"
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private Achievement FindAchievementByName(string name)
        {
            //if name is null or empty, prevents the calculation
            if (string.IsNullOrEmpty(name))
                return null;

            return _achievements.Find(a => a.Name.Equals(name));
        }

        /// <summary>
        /// Return all achievements count to 0 (zero)
        /// </summary>
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

        /// <summary>
        /// Called when observable notifies observers
        /// </summary>
        /// <param name="value"></param>
        public void OnNext(Achievement value)
        {
            INotificationData notification = (INotificationData)value;
            OnAchieve?.Invoke(notification);
        }
    }
}


//TODO
/*
public enum NotificationPosition
{
    TopLeft,
    TopCenter,
    TopRight,
    BottomLeft,
    BottomCenter,
    BottomRight
}
*/