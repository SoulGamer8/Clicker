using System;
using UnityEngine;
using UnityEngine.UI;

public class BuyItem : MonoBehaviour
{
    [Header("Price")]
    [SerializeField] private float _exponential = 1.5f;
    [SerializeField] private float  _coefficient = 1;

    
    private ShopItemSO _shopItemSo;
    
    private Wallet _wallet;
    private ClickManager _clickManager;

    private void Start() {
        _wallet = Wallet.Instance;
        _clickManager = ClickManager.Instance;

        _shopItemSo = GetComponent<ControllerShopItem>().GetShopItem();

        Button button;
        button = GetComponent<Button>();
        button.onClick.AddListener(Buy);
    }

    public void Buy(){
        if(_wallet.TakeMoney(_shopItemSo.BasePrice)){
            Bonus();
            PriceUp();
            GetComponent<DisplayItem>().UpdateUI();
        }
        else
            Debug.Log("No money");
    }

    private void PriceUp(){
        _shopItemSo.BasePrice =Math.Round(_coefficient* Mathf.Pow(_shopItemSo.Level,_exponential) + _shopItemSo.BasePrice);
    }

    private void Bonus(){
        _clickManager.AddMoneyPerClick(_shopItemSo.Bonus);
        _shopItemSo.Level++;
    }
}
