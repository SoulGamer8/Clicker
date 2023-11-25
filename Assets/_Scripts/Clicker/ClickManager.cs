using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ClickManager : MonoBehaviour
{
    public static ClickManager Instance { get; private set; }

    public UnityAction<int> ClickedEvent; 

    [SerializeField] private int _moneyPerClick=1;
    [SerializeField] private int _moneyPerSecond=5;

    private int _multiple=1;
    
    private void Awake() {
        if(Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;

    }

    private void Start() {
        StartCoroutine(MoneyPerSecond());
    }

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

    public void AddMoneyPerSecond(){

    }

    IEnumerator MoneyPerSecond(){
        while(true){
            yield return new WaitForSeconds(1);
             ClickedEvent?.Invoke(_moneyPerSecond);
        }
    }
}
