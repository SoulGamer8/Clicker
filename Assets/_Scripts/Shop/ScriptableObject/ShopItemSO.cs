using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "ShopItemSO", menuName = "ScriptableObject/ShopItemSO", order = 0)]
public class ShopItemSO : ScriptableObject {
    
    public Image Image;
    public string Name;
    public string Description;
    public int Price;

    public int Bonus;
}
