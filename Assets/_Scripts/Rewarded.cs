using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Rewarded : MonoBehaviour
{
    public UnityAction<int> RewardedСomplete;

    [SerializeField] private int _multipleBonus;

    [SerializeField] private int _baseMoney;

    private Money _money;

    private void Awake() {
        _money = GetComponent<Money>();
    }

    public void AddMoney(){
        _money.AddMoney(_baseMoney);
    }
}
