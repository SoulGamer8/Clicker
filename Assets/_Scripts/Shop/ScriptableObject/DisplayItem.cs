using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayItem : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _textName;
    [SerializeField] private TMP_Text _textDescription;
    [SerializeField] private TMP_Text _textPrice;
    [SerializeField] private TMP_Text _textBonus;

    private ShopItemSO _shopItemSO;
    private AddSuffixes _addSuffixes;



    private void Start(){
        _shopItemSO = GetComponent<ControllerShopItem>().GetShopItem();
        _addSuffixes = new AddSuffixes();
        UpdateUI();
    }

    public void UpdateUI(){
        _image.sprite = _shopItemSO.Image;
        _textName.text = _shopItemSO.Name;
        _textDescription.text = _shopItemSO.Description;
        _textPrice.text = _addSuffixes.DivisionMoney(_shopItemSO.BasePrice);
        _textBonus.text = _addSuffixes.DivisionMoney(_shopItemSO.Bonus*_shopItemSO.Level);
    }
}
