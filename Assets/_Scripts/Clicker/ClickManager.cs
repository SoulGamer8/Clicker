using System.Collections;
using UnityEngine;
using UnityEngine.Events;
public class ClickManager : MonoBehaviour,IDataPersistence
{
    public static ClickManager Instance { get; private set; }

    public UnityAction<int> ClickedEvent; 

    [SerializeField] private int _moneyPerClick=1;
    [SerializeField] private int _moneyPerSecond=5;


    private int _multiple=1;

    
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
    }

    public void AddMoneyPerClick(int value){
        _moneyPerClick +=value * _multiple;
    }

    public void BonusMultipleMoneyPerClick(int multiple){
        _multiple = multiple;
        StartCoroutine(TimeActiveBonusMoneyPerClick(multiple));
    }

    IEnumerator TimeActiveBonusMoneyPerClick(int multiple){
        _moneyPerClick*=multiple;
        Debug.Log(_multiple);
        Debug.Log(_moneyPerClick);
        yield return new WaitForSeconds(30);
        _moneyPerClick/=multiple;
        _multiple =1;
    }
    #endregion

    #region MoneyPerSecond
    public void AddMoneyPerSecond(){

    }

    IEnumerator MoneyPerSecond(){
        while(true){
            yield return new WaitForSeconds(1);
             ClickedEvent?.Invoke(_moneyPerSecond);
        }
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
