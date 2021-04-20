using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UgglaGames.Gerals;

namespace UgglaGames.NotificationSystem
{
    /// <summary>
    /// Base for notification classes
    /// </summary>
    public abstract class Notification : MonoBehaviour
    {
        [SerializeField] protected Text nameLabel;
        [SerializeField] protected Image icon;
        public abstract IEnumerator NotifyFlow();

        /// <summary>
        /// Populate notifiation with INotificationData data
        /// </summary>
        /// <param name="notificationData"></param>
        public abstract void PopulateNotificationValues(INotificationData notificationData);
    }
}
