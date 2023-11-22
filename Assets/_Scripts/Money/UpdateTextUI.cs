using TMPro;
using UnityEngine;

public class UpdateTextUI : MonoBehaviour
{
    private TMP_Text _text;

    private void Awake() {
        _text = GetComponent<TMP_Text>();
    }

    public void UpdateUI(string value){
        _text.text = value;
    }
}
