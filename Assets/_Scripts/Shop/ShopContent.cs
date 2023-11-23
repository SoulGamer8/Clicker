using UnityEngine;

public class ShopContent : MonoBehaviour
{
    [SerializeField] private ShopItemSO[] _shopItemSO;
    [SerializeField] private GameObject _shopItemPrefab;
    [SerializeField] private Vector3 _startPosition;
    private Vector3 _currentPosition;
    [SerializeField] private int _merge;

    private void Awake() {
        _currentPosition = _startPosition;
        for(int i=0;i<_shopItemSO.Length;i++){
            GameObject shopItem;
            shopItem = Instantiate(_shopItemPrefab,transform);
            NewPosition(i);
            shopItem.GetComponent<RectTransform>().anchoredPosition  = _currentPosition;

        }
    }

    private void NewPosition(int i){
       _currentPosition.y = -((_shopItemPrefab.GetComponent<RectTransform>().rect.height+_merge)*i);
        Debug.Log(_currentPosition);
    }
}
