using UnityEngine;
using UnityEngine.UI;

public class AddBonus : MonoBehaviour
{
    [SerializeField]private ShopItemSO _shopItemSo;
    
    private Wallet _wallet;
    private ClickManager _clickManager;

    private void Awake() {
        _wallet = Wallet.Instance;
        _clickManager = ClickManager.Instance;
    }

    private void Start() {
        _shopItemSo = GetComponent<ControllerShopItem>().GetShopItem();


        Button button;
        button = GetComponent<Button>();
        button.onClick.AddListener(Buy);
    }

    public void Buy(){
        if(_wallet.TakeMoney(_shopItemSo.Price)){
            Bonus();
            PriceUp();
        }
        else
            Debug.Log("No money");
    }

    private void PriceUp(){
        _shopItemSo.Price *= 2;
    }

    private void Bonus(){
        _clickManager.AddMoneyPerClick(_shopItemSo.Bonus);
    }
}
