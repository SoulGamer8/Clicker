using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ClickManager : MonoBehaviour
{
    public UnityAction<int> ClickedEvent; 

    [SerializeField] private int _moneyPerClick=1;
    [SerializeField] private int _moneyPerSecond=5;
    
    private void Start() {
        StartCoroutine(MoneyPerSecond());
    }

    public void Click(){
        ClickedEvent?.Invoke(_moneyPerClick);
    }

    IEnumerator MoneyPerSecond(){
        while(true){
            yield return new WaitForSeconds(1);
             ClickedEvent?.Invoke(_moneyPerSecond);
        }
    }
}
