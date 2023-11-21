using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private int _money;
    [SerializeField] private TMP_Text _moneyText;


    public void AddMoney(){
        _money++;
        UpdateUI();
    }

    public void AddMoney(int value){
        _money+=value;
        UpdateUI();
    }

    public void Reward(){
        Debug.Log("Test");
        _money+=500;
        UpdateUI();
    }

    private void UpdateUI(){
        _moneyText.text = _money.ToString();
    }
}
