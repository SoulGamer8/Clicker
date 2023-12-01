using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using Unity.Notifications.Android;
public class AndroidPushNotificationManager : MonoBehaviour
{
    public static AndroidPushNotificationManager Instance{get;private set;}

    private void Awake() {
        if(Instance != null)
            Debug.LogError("Found more than one Push Notification Manager in the scene");
        Instance = this;
    }

    public void RequestAuthorization(){
        if(!Permission.HasUserAuthorizedPermission("android.permission.POST_NOTIFACATIONS")){
            Permission.RequestUserPermission("android.permission.POST_NOTIFACATIONS");
        }
    }

    public void RegisterNotificationChannel(){
        var channel = new AndroidNotificationChannel()
        {
            Id = "default_channel",
            Name = "Default Channel",
            Importance = Importance.Default,
            Description = "Generic notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }

    public void SendNotification(string title,string text,int fireTimeInSeconds){
        var notification = new AndroidNotification();
        notification.Title = title;
        notification.Text = text;
        notification.FireTime = System.DateTime.Now.AddSeconds(fireTimeInSeconds);

        AndroidNotificationCenter.SendNotification(notification,"default_channel");
    }
}
