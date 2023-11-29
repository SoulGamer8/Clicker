using UnityEngine;

public class Wallet : MonoBehaviour, IDataPersistence
{
    public static Wallet Instance { get; private set; }

    [SerializeField] private ClickManager _clickManager;

    [Header("Money")]
    [SerializeField] private int _money;
    private string _moneyString;
    [SerializeField] private UpdateTextUI _updateTextMoneyUI;
    
    [Header("Diamond")]
    [SerializeField] private int _diamond;
    [SerializeField] private UpdateTextUI _updateTextDiamondUI;


    private void Awake() {
        if (Instance != null && Instance != this) 
            Destroy(this); 
        else 
            Instance = this; 
    }
    

    private void OnEnable() {
        _clickManager.ClickedEvent +=AddMoney;
    }

    private void OnDisable() {
        _clickManager.ClickedEvent -=AddMoney;
    }

    #region Money 
    public int GetMoney(){
        return _money;
    }
    public void AddMoney(int value){
        _money+=value;
        ConvertMoneyToString();
    }

    public bool TakeMoney(int value){
        if(_money-value >=0 ){
            _money-=value;
            ConvertMoneyToString();
            return true;
        }
        else
            return false;
    }

    private void ConvertMoneyToString(){
        _moneyString = _money.ToString();
         UpdateUI();
    }

    private void UpdateUI(){
        _updateTextMoneyUI.UpdateUI(_moneyString);
    }
    
    #endregion

    #region Diamond
    public void AddDiamond(int value){
        _diamond +=value;
    }

    public bool TakeDiamond(int value){
        if(_diamond-value >=0 ){
            _diamond-=value;
            return true;
        }
        else
            return false;
    }
    #endregion

    #region 

    public void LoadData(GameData data){
        _money = data.Money;
        _diamond = data.Diamond;
        UpdateUI();
    }
    public void SaveData(ref GameData data){
        data.Money = _money;
        data.Diamond = _diamond;
    }

    #endregion

}