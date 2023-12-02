using System;
using UnityEngine;
using NeverMindEver.DataPersistent;
using NeverMindEver.Clicker;

namespace NeverMindEver.Money{
    public class Wallet : MonoBehaviour, IDataPersistence
    {
        public static Wallet Instance { get; private set; }

        [SerializeField] private ClickManager _clickManager;

        [Header("Money")]
        [SerializeField] private double _money;
        private string _moneyString;
        [SerializeField] private UpdateTextUI _updateTextMoneyUI;
        
        [Header("Diamond")]
        [SerializeField] private int _diamond;
        [SerializeField] private UpdateTextUI _updateTextDiamondUI;

        [Header("AFK")]
        [SerializeField] private int _maxSecondAFK;
        private double _timeExitUNIX;


        private void Awake() {
            if (Instance != null && Instance != this) 
                Destroy(this); 
            else 
                Instance = this; 
        }
        

        private void OnEnable() {
            _clickManager.ClickedEvent +=AddMoney;
        }

        private void OnDisable() {
            _clickManager.ClickedEvent -=AddMoney;
        }

        #region Money 
        public double GetMoney(){
            return _money;
        }
        public void AddMoney(double value){
            _money+=value;
            UpdateUI();
        }

        public bool TakeMoney(double value){
            if(_money-value >=0 ){
                _money-=value;
                UpdateUI();
                return true;
            }
            else
                return false;
        }

        private void UpdateUI(){
            _updateTextMoneyUI.UpdateUI(_money);
        }
        
        #endregion

        #region Diamond
        public void AddDiamond(int value){
            _diamond +=value;
        }

        public bool TakeDiamond(int value){
            if(_diamond-value >=0 ){
                _diamond-=value;
                return true;
            }
            else
                return false;
        }
        #endregion

        #region SaveLoad
        public void LoadData(GameData data){
            _money = data.Money;
            _diamond = data.Diamond;
            AFKTime(data.TimeExit,data.MoneyPerSecond);
            UpdateUI();
        }
        public void SaveData(ref GameData data){
            data.Money = _money;
            data.Diamond = _diamond;
            data.TimeExit = GetTimeExit();
        }

        #endregion

        #region AFK
        
        private double GetTimeExit() {
            DateTimeOffset timeExit = new DateTimeOffset(DateTime.UtcNow);
            return timeExit.ToUnixTimeSeconds();
        }

        private void AFKTime(double timeExit,double moneyPerSecond){
            DateTimeOffset currentTime = new DateTimeOffset(DateTime.UtcNow);
            double currentTimeUNIX = currentTime.ToUnixTimeSeconds();
            double _seconds = currentTimeUNIX - timeExit;
            if(_seconds > _maxSecondAFK){
                Debug.Log("Max time 4 hours");
                _seconds = _maxSecondAFK;
            }
            Debug.Log("You give:"+(int)_seconds * moneyPerSecond);
        _money+=(int)_seconds * moneyPerSecond;
        }


        #endregion

    }
}