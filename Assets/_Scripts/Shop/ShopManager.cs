using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private Shop _shop;

    public void ShowHideShop(){
        if(!_shop.gameObject.activeSelf)
            _shop.gameObject.SetActive(true);
        else
            _shop.gameObject.SetActive(false);
    }
}
