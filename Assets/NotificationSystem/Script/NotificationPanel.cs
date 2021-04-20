using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UgglaGames.Gerals;

namespace UgglaGames.NotificationSystem
{
    /// <summary>
    /// Panel to show visual notifications to player
    /// </summary>
    public class NotificationPanel : BasePanel, IObserver<AchievementNotification>
    {

        // Start is called before the first frame update
        void Start()
        {
            for (int i = 0; i < 3; i++)
            {
                CreateNotificationObjectAndEnqueue();
            }
        }

        /// <summary>
        /// Create UI object to show notification and enqueue it
        /// </summary>
        protected override void CreateNotificationObjectAndEnqueue()
        {
            Notification notification = Instantiate(_notificationPrefab, transform);
            _notifications.Enqueue(notification);
            notification.gameObject.SetActive(false);
        }

        /// <summary>
        /// Shows notification to player
        /// </summary>
        /// <param name="value"></param>
        public override void ShowNotification(INotificationData value)
        {
            StartCoroutine(NotificationFlow(value));
        }

        /// <summary>
        /// Flow to the notification, since is shows up until vanish
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override IEnumerator NotificationFlow(INotificationData value)
        {
            if (_notifications.Count == 0)
                yield break;

            Notification notification = _notifications.Dequeue();
            notification.PopulateNotificationValues(value);
            notification.gameObject.SetActive(true);
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
        /// Called when notified by observable
        /// </summary>
        /// <param name="value"></param>
        public void OnNext(AchievementNotification value)
        {
            _notifications.Enqueue(value);
        }
    }
}
