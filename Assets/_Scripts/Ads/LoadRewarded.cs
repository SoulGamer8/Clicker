using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Events;
public class LoadRewarded : MonoBehaviour,IUnityAdsLoadListener,IUnityAdsShowListener
{

    public UnityEvent AdComplete;
    public UnityEvent AdFailed;
    [SerializeField] private string _androidAdUnitId;
    [SerializeField] private string _iosAdUnitId;

    private string _adUnitId;

    private Wallet _wallet;
    private ClickManager _clickManager;


    private int _idBonus;
    private double _value;

    private void Awake() {
#if UNITY_IOS
        _adUnitId = _iosAdUnitId;
#elif UNITY_ANDROID
        _adUnitId = _androidAdUnitId;
#endif

    _wallet = Wallet.Instance;
    _clickManager = ClickManager.Instance;
    }

    public void LoadAd(int id,double value){
        _idBonus = id;
        _value = value;
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
        AdFailed?.Invoke();
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
        SendReward();
        if(placementId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsCompletionState.COMPLETED)){
            Debug.Log("Rewarded show complete");
            SendReward();
        }
    }

    private void SendReward(){
        if(_idBonus == 0)
            _clickManager.BonusMultipleMoneyPerClick(_value);
        else
            _wallet.AddMoney(_value);
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.LogError("Rewarded show failure");
        AdFailed?.Invoke();
    }

    public void OnUnityAdsShowStart(string placementId)
    {
         print("Rewarded show start");
    }
}
