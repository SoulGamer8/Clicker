using System;
using UnityEngine;

namespace NeverMindEver.PushNotification{
    public class NativePushNotificationManager : MonoBehaviour
    {
        [SerializeField] private AndroidPushNotificationManager androidPushNotificationManager;
        private void OnApplicationPause() {
            CallNotification("Miss you","Return to game we miss you",10);
            CallNotification("Return to game","Your storage 50% filled",7200);
            CallNotification("Return to game","Your storage is full \n Time to return in game",14400);
            CallNotification("Miss you","Return to game we miss you",28800);
        }
        public void CallNotification(string name,string description,int time){
            try
            {
                androidPushNotificationManager.RequestAuthorization();
                androidPushNotificationManager.RegisterNotificationChannel();
                androidPushNotificationManager.SendNotification(name, description, time);
            }
            catch (Exception e)
            {
                Debug.LogError("Error occurred when trying to save data file:"+e);
            }
        } 

    }
}