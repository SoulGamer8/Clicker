using UnityEngine;

namespace NeverMindEver.Shop{
    public class ShopManager : MonoBehaviour
    {
        [SerializeField] private GameObject _shop;

        public void ShowHideShop(){
            if(!_shop.activeSelf)
                _shop.SetActive(true);
            else
                _shop.SetActive(false);
        }
    }
}