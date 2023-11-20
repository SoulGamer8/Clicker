using UnityEngine;
using UnityEngine.Advertisements;

public class LoadBanners : MonoBehaviour
{
    [SerializeField] private string _androidAdUnitId;
    [SerializeField] private string _iosAdUnitId;
    
    private string _adUnitId;

    BannerPosition bannerPosition = BannerPosition.TOP_CENTER;

    private void Start() {
#if UNITY_IOS
        _adUnitId = _iosAdUnitId;
#elif UNITY_ANDROID
        _adUnitId = _androidAdUnitId;
#endif

        Advertisement.Banner.SetPosition(bannerPosition);
        LoadBanner();
    }

    public void LoadBanner(){
        BannerLoadOptions options = new BannerLoadOptions{
                loadCallback = OnBannerLoaded,
                errorCallback = OnBannerLoadedError
        };

        Advertisement.Banner.Load(_adUnitId,options);
    }

    void OnBannerLoaded(){
        Debug.Log("Banner loaded");
        ShowBannerAd();
    }

    void OnBannerLoadedError(string error){
       Debug.Log("Banner failed to load" + error);
    }

    public void ShowBannerAd(){
        BannerOptions options = new BannerOptions{
                showCallback = OnBannerShown,
                clickCallback = OnBannerClicked,
                hideCallback = OnBannerHidden
        };

        Advertisement.Banner.Show(_adUnitId,options);
    }

    private void OnBannerShown(){

    }

    private void OnBannerClicked(){

    }

    private void OnBannerHidden(){

    } 

    public void HideBannerAd(){
        Advertisement.Banner.Hide();
    }
}
