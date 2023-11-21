using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Events;
public class LoadRewarded : MonoBehaviour,IUnityAdsLoadListener,IUnityAdsShowListener
{

    public UnityEvent AdComplete;

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
        print("Loading Rewarded");
        Advertisement.Load(_adUnitId,this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        if(placementId.Equals(_adUnitId)){
            Debug.Log("Rewarded loaded");
            ShowAd();    
        }
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.LogError("Rewarded failed to load");
    }


    public void ShowAd(){
        print("Showing ad");
        Advertisement.Show(_adUnitId,this);
    }
    public void OnUnityAdsShowClick(string placementId)
    {
       print("Rewarded clicked");
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        AdComplete?.Invoke();
        if(placementId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsCompletionState.COMPLETED)){
            Debug.Log("Rewarded show complete");
            AdComplete?.Invoke();
        }
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.LogError("Rewarded show failure");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
         print("Rewarded show start");
    }
}
