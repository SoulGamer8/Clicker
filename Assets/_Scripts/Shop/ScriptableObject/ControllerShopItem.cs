using UnityEngine;

namespace NeverMindEver.Shop{
    public class ControllerShopItem : MonoBehaviour
    {
        private ShopItemSO _shopItemSO;

        public void SetShopItem(ShopItemSO shopItemSO){
            _shopItemSO = shopItemSO;
        }

        public ShopItemSO GetShopItem(){
            return _shopItemSO;
        }
    }
}