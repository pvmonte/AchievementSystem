using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UgglaGames.Gerals;

namespace UgglaGames.NotificationSystem
{
    /// <summary>
    /// Base panel panel classes
    /// </summary>
    public abstract class BasePanel : MonoBehaviour
    {
        [SerializeField] protected Notification _notificationPrefab;
        protected Queue<Notification> _notifications = new Queue<Notification>();
        protected abstract void CreateNotificationObjectAndEnqueue();
        public abstract void ShowNotification(INotificationData value);
        public abstract IEnumerator NotificationFlow(INotificationData value);
    }
}
