using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class Notification : MonoBehaviour
{
    [SerializeField] protected Text nameLabel;
    [SerializeField] protected Image icon;
    public abstract IEnumerator NotifyFlow();

    public abstract void PopulateNotificationValues(INotificationData notificationData);
}
