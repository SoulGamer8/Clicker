using UnityEngine;

namespace NeverMindEver.Shop{
    [CreateAssetMenu(fileName = "ShopItemSO", menuName = "ScriptableObject/ShopItemSO", order = 0)]
    public class ShopItemSO : ScriptableObject {
        
        public Sprite Image;
        public string Name;
        public string Description;
        public double BasePrice;
        public int Level;

        public enum  TypeBonus{MoneyPerClick, MoneyPerSecond, DamagePerClick};
        public TypeBonus _typeBonus ;  

        public int Bonus;
    }
}