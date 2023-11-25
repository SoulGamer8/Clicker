using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ClickManager : MonoBehaviour
{
    public static ClickManager Instance { get; private set; }

    public UnityAction<int> ClickedEvent; 

    [SerializeField] private int _moneyPerClick=1;
    [SerializeField] private int _moneyPerSecond=5;

    private bool _isMultipleActive= false;
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

    public void BonusMultipleMoneyPerClick(int multiple,float time){
        _multiple = multiple;
        StartCoroutine(TimeActiveBonusMoneyPerClick(multiple,time));
    }

    IEnumerator TimeActiveBonusMoneyPerClick(int multiple,float time){
        _moneyPerClick*=multiple;
        yield return new WaitForSeconds(time);
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
