using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UgglaGames.Gerals;

namespace UgglaGames.NotificationSystem
{
    public class NotificationPanel : BasePanel, IObserver<AchievementNotification>
    {

        // Start is called before the first frame update
        void Start()
        {

            for (int i = 0; i < 3; i++)
            {
                CreateNotificationObject();
            }
        }

        protected override void CreateNotificationObject()
        {
            Notification notification = Instantiate(_notificationPrefab, transform);
            _notifications.Enqueue(notification);
            notification.gameObject.SetActive(false);
        }

        public override void ShowNotification(INotificationData value)
        {
            StartCoroutine(NotificationFlow(value));
        }

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

        public void OnNext(AchievementNotification value)
        {
            _notifications.Enqueue(value);
        }
    }
}
