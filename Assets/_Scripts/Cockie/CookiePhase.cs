using UnityEngine;
using UnityEngine.UI;
using NeverMindEver.Money;
using NeverMindEver.Clicker;

namespace NeverMindEver.Cookie{
    public class CookiePhase : MonoBehaviour
    {
        [Header("Cookie")]
        [SerializeField] private Sprite[] _phaseCookie;
        private int _currentPhase=0;
        [SerializeField] private double _baseHealth;
        private double _currentHealth;
        private Image _cookies;
        
        [Header("Reward")]
        [SerializeField] private double _rewardForDestroy;
        [SerializeField] private int _multiple;
        private Wallet wallet;
        private ClickManager _clickManager;

        private void OnEnable() {
            _clickManager.DamageEvent += TakeDamage;
        }

        private void OnDisable() {
            _clickManager.DamageEvent -= TakeDamage;
        }

        private void Awake(){
            _cookies = GetComponent<Image>();
            _clickManager = ClickManager.Instance;
        }

        private void Start() {
            wallet = Wallet.Instance;
            
            ChangePhase();
        }

        public void TakeDamage(double value){
            Debug.Log(value);
            _currentHealth -= value;
            if(_currentHealth<=0){
                ChangePhase();
            }
        }

        private void ChangePhase(){
            if(_currentPhase>=_phaseCookie.Length){
                _currentPhase=0;
                GiveReward();
            }
            _cookies.sprite = _phaseCookie[_currentPhase];
            _currentPhase++;
            _currentHealth = _baseHealth;
        }

        private void RiseHealth(){
            _baseHealth *=1.5;
        }

        private void GiveReward(){
            wallet.AddMoney(_rewardForDestroy);
            _rewardForDestroy *= _multiple;
            RiseHealth();
        }
    }
}