using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UgglaGames.NotificationSystem
{
    public abstract class BasePanel : MonoBehaviour
    {
        [SerializeField] protected Notification _notificationPrefab;
        protected Queue<Notification> _notifications = new Queue<Notification>();
        protected abstract void CreateNotificationObject();
        public abstract void ShowNotification(INotificationData value);
        public abstract IEnumerator NotificationFlow(INotificationData value);
    }
}
