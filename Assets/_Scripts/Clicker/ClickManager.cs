using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using NeverMindEver.DataPersistent;

namespace NeverMindEver.Clicker{
    public class ClickManager : MonoBehaviour,IDataPersistence
    {
        public static ClickManager Instance { get; private set; }

        public UnityAction<double> ClickedEvent; 
        public UnityAction<double> DamageEvent;

        [SerializeField] private double _moneyPerClick=1;
        [SerializeField] private double _moneyPerSecond=5;
        [SerializeField] private double _damage;

        private double _multiple=1;
        
        private void Awake() {
            if(Instance != null && Instance != this)
                Debug.LogError("Found more than one Click Manager in the scene");
            else
                Instance = this;

            
        }

        private void Start() {
            StartCoroutine(MoneyPerSecond());
        }

        #region MoneyForClick
        public void Click(){
            ClickedEvent?.Invoke(_moneyPerClick);
            DamageEvent?.Invoke(_damage);
        }

        public void AddMoneyPerClick(double value){
            _moneyPerClick +=value * _multiple;
        }

        public void BonusMultipleMoneyPerClick(double multiple){
            _multiple = multiple;
            StartCoroutine(TimeActiveBonusMoneyPerClick(multiple));
        }

        IEnumerator TimeActiveBonusMoneyPerClick(double multiple){
            _moneyPerClick*=multiple;
            Debug.Log(_multiple);
            Debug.Log(_moneyPerClick);
            yield return new WaitForSeconds(30);
            _moneyPerClick/=multiple;
            _multiple =1;
        }
        #endregion

        #region MoneyPerSecond
        public void AddMoneyPerSecond(double value){
            _moneyPerSecond +=value;
        }

        IEnumerator MoneyPerSecond(){
            while(true){
                yield return new WaitForSeconds(1);
                ClickedEvent?.Invoke(_moneyPerSecond);
            }
        }
        #endregion

        #region  Damage
        public void AddDamage(double value){
            _damage +=value;
        }
        #endregion

        #region SaveLoad
        public void LoadData(GameData data)
        {
            _moneyPerClick = data.MoneyPerClick;
            _moneyPerSecond = data.MoneyPerSecond;
        }

        public void SaveData(ref GameData data)
        {
            data.MoneyPerClick = _moneyPerClick;
            data.MoneyPerSecond = _moneyPerSecond;
        }
        #endregion
    }
}