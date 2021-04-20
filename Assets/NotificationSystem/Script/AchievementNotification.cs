using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UgglaGames.Gerals;

namespace UgglaGames.NotificationSystem
{
    /// <summary>
    /// Notification used for achievements
    /// </summary>
    public class AchievementNotification : Notification, IObservable<AchievementNotification>
    {
        [SerializeField] MultiAnimationFlow animationFlow;

        List<IObserver<AchievementNotification>> _observers = new List<IObserver<AchievementNotification>>();

        protected void Start()
        {
            StartCoroutine(NotifyFlow());
        }

        /// <summary>
        /// The notify animation flow
        /// </summary>
        /// <returns></returns>
        public override IEnumerator NotifyFlow()
        {
            yield return animationFlow.Play();
            OnEndFlow();
        }

        /// <summary>
        /// Called when the notify flow ends. Used to notify observers
        /// </summary>
        void OnEndFlow()
        {
            foreach (var observer in _observers)
                observer.OnNext(this);

            gameObject.SetActive(false);
        }

        /// <summary>
        /// Populate notifiation with INotificationData data
        /// </summary>
        /// <param name="achievement"></param>
        public override void PopulateNotificationValues(INotificationData achievement)
        {
            nameLabel.text = achievement.Name;
            icon.sprite = achievement.Icon;
        }

        /// <summary>
        /// User to subscribe observers
        /// </summary>
        /// <param name="observer"></param>
        /// <returns></returns>
        public IDisposable Subscribe(IObserver<AchievementNotification> observer)
        {
            if (_observers.Contains(observer))
                return null;

            _observers.Add(observer);
            return new Unsubscriber<AchievementNotification>(_observers, observer);
        }        
    }
}
