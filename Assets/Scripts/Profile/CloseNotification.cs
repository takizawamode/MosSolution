using UnityEngine;

public class CloseNotification : MonoBehaviour
{
    public GameObject notification;

    public void closeNotification()
    {
        notification.SetActive(false);
    }
}
