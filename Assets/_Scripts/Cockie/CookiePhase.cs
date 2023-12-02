using UnityEngine;
using UnityEngine.UI;
using NeverMindEver.Money;

namespace NeverMindEver.Cookie{
    public class CookiePhase : MonoBehaviour
    {
        [Header("Cookie")]
        [SerializeField] private Sprite[] _phaseCookie;
        private int _currentPhase=0;
        [SerializeField] private int _clickToChangePhase;
        private int _currentClick;
        private Image _cookies;
        
        [Header("Reward")]
        [SerializeField] private double _rewardForDestroy;
        [SerializeField] private int _multiple;
        private Wallet wallet;

        private void Awake(){
            _cookies = GetComponent<Image>();
        
        }

        private void Start() {
            wallet = Wallet.Instance;
            
            ChangePhase();
        }

        public void AddClick(){
            _currentClick++;
            if(_currentClick >=_clickToChangePhase){
                _currentPhase++;
                ChangePhase();
                _currentClick=0;
            }
        }

        private void ChangePhase(){
            if(_currentPhase>=_phaseCookie.Length){
                _currentPhase=0;
                GiveReward();
            }
            _cookies.sprite = _phaseCookie[_currentPhase];
        }

        private void GiveReward(){
            wallet.AddMoney(_rewardForDestroy);
            _rewardForDestroy *= _multiple;
        }
    }
}