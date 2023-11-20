using UnityEngine;
using UnityEngine.Advertisements;
// 
public class LoadInterstitial : MonoBehaviour,IUnityAdsLoadListener,IUnityAdsShowListener
{
    [SerializeField] private string _androidAdUnitId;
    [SerializeField] private string _iosAdUnitId;

    private string _adUnitId;

    private void Awake() {
#if UNITY_IOS
        _adUnitId = _iosAdUnitId;
#elif UNITY_ANDROID
        _adUnitId = _androidAdUnitId;
#endif
    }

    public void LoadAd(){
        print("Loading interstitial");
        Advertisement.Load(_adUnitId,this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Interstitial loaded");
        ShowAd();
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log("Interstitial failed to load");
    }


    public void ShowAd(){
        print("Showing ad");
        Advertisement.Show(_adUnitId,this);
    }
    public void OnUnityAdsShowClick(string placementId)
    {
       print("Interstitial clicked");
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        print("Interstitial show complete");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
         print("Interstitial show failure");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
         print("Interstitial show start");
    }
}
