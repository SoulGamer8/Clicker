using UnityEngine.Advertisements;
using UnityEngine;

public class InitializeAds : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] private string _androidGameId;
    [SerializeField] private string _iosGameID;
    [SerializeField] private bool _isTestingMode= true;

    private string gameId;

    private void Awake() {
        InitializeAd();
    }

    private void InitializeAd(){
#if UNITY_IOS
        gameId = _iosGameID;
#elif UNITY_ANDROID
        gameId = _androidGameId;
#elif UNITY_EDITOR
        gameId = _androidGameId;
#endif

        if(!Advertisement.isInitialized && Advertisement.isSupported)
            Advertisement.Initialize(gameId,_isTestingMode,this);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Ads initialized");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log("failed to initialize");
    }

}
