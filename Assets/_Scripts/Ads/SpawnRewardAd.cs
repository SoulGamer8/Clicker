using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SpawnRewardAd : MonoBehaviour
{
    [SerializeField] private float _timeSpawnBonus;
    [SerializeField] private GameObject[] _bonusButton;
    [SerializeField] private Vector3 _spawnPosition;
    [SerializeField] private LoadRewarded loadRewarded;
    [SerializeField] private float _timeDestroyObject;
    private Wallet _wallet;
    private ClickManager _clickManager;

    private int _idCurrentBonus;

    [Header("Multiple Per click")]
    [SerializeField] private int _baseMultipleCounter;
    [SerializeField] private int _maxMultipleCounter;
    private int _currentMultipleCounter;

    [Header("Money for Ad")]
    [SerializeField] private int _baseMoneyCounter;
    [SerializeField] private int _maxMoneyCounter;
    private int _currentMoneyCounter;
    private int _value;
   
    private void Awake() {
        _currentMultipleCounter = _baseMultipleCounter;
        _currentMoneyCounter = _baseMoneyCounter;
    }

    private void Start() {
        _wallet = Wallet.Instance;
        _clickManager = ClickManager.Instance;

        StartCoroutine(SpawnBonus());
    }

    private void SpawnButton(){
        if(_idCurrentBonus == -1 )
            _idCurrentBonus = Random.Range(0,_bonusButton.Length);
        
        GameObject button;
        button = Instantiate(_bonusButton[_idCurrentBonus],transform);
        button.transform.localPosition = _spawnPosition;
        if(_idCurrentBonus == 0)
            _value = _currentMultipleCounter;
        else 
            _value = _wallet.GetMoney() * _currentMoneyCounter;
        SetBonus(button);
        
        StartCoroutine(DestroyBonus(button));
    }

    private void SetBonus(GameObject button){
        button.GetComponent<Button>().onClick.AddListener(ButtonClick);
    }

    private void ButtonClick(){
        
        loadRewarded.LoadAd(_idCurrentBonus,_value);
        Destroy(transform.GetChild(0).gameObject);
    }

    public void AdComplete(){
        RiseBonus(_idCurrentBonus);
        SpawnButton();
    }

    public void AdFailed(){
       Destroy(transform.GetChild(0).gameObject);
        _idCurrentBonus = -1;
    }

    private void RiseBonus(int id){
        if(id == 1)
            _currentMultipleCounter ++;
        else 
            _currentMoneyCounter++;
    }


    private void Multiple(){
        if(_currentMultipleCounter >= _maxMultipleCounter){
            _currentMultipleCounter = _baseMultipleCounter;
            _idCurrentBonus = -1;
            StartCoroutine(SpawnBonus());
        }
        if(_currentMoneyCounter >=_maxMoneyCounter){
            _currentMoneyCounter =_baseMoneyCounter;
            _idCurrentBonus = -1;
            StartCoroutine(SpawnBonus());
        }
    }

    private IEnumerator SpawnBonus(){
        yield return new WaitForSeconds(_timeSpawnBonus);
            SpawnButton();
    }

    private IEnumerator DestroyBonus(GameObject bonusButton){
        yield return new WaitForSeconds(_timeDestroyObject);
        StartCoroutine(SpawnBonus());
        _idCurrentBonus = -1;
        Destroy(bonusButton);
    }
}
