using UnityEngine;

public class ShopContent : MonoBehaviour
{
    [SerializeField] private ShopItemSO[] _shopItemSO;
    [SerializeField] private GameObject _shopItemPrefab;

    private void Awake() {
        for(int i=0;i<_shopItemSO.Length;i++){
            GameObject shopItem;
            shopItem = Instantiate(_shopItemPrefab,transform);
            shopItem.GetComponent<ControllerShopItem>().SetShopItem(_shopItemSO[i]);
        }
    }
}
