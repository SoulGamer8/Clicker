using UnityEngine;
using UnityEngine.Events;

public class ClickManager : MonoBehaviour
{
    public UnityAction<int> ClickedEvent; 

    [SerializeField] private int _moneyPerClick=1;
    [SerializeField] private float _moneyPerSecond=0;
    
    public void Click(){
        ClickedEvent?.Invoke(_moneyPerClick);
    }
}
