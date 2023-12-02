using UnityEngine;
using UnityEngine.Events;

namespace NeverMindEver.Money{
    public class Rewarded : MonoBehaviour
    {
        public UnityAction<int> RewardedСomplete;

        [SerializeField] private int _multipleBonus;

        [SerializeField] private int _baseMoney;

        [SerializeField] private Wallet wallet;

        public void AddMoney(){
            wallet.AddMoney(_baseMoney);
        }
    }
}