using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using NeverMindEver.Functions;


public class UpdateTextUI : MonoBehaviour
{
    private AddSuffixes addSufix;
    private TMP_Text _text;

    private void Awake() {
        _text = GetComponent<TMP_Text>();
        addSufix = new AddSuffixes();
    }

    public void UpdateUI(double value){
        _text.text = addSufix.DivisionMoney(value);
    }


}
