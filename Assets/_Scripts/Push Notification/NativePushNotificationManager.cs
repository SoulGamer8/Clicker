using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NativePushNotificationManager : MonoBehaviour
{
    [SerializeField] private AndroidPushNotificationManager androidPushNotificationManager;
    void Start()
    {
        androidPushNotificationManager.RequestAuthorization();
        androidPushNotificationManager.RegisterNotificationChannel();
        androidPushNotificationManager.SendNotification("Text","Text text text",3);
    }

}
