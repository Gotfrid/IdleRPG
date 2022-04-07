using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour {
    
    private TextMeshProUGUI ScoreValueUI;

    private void Start() {
        ScoreValueUI = GameObject.FindGameObjectWithTag("ScoreValue").GetComponent<TextMeshProUGUI>();
    }

    private void Update() {
        ScoreValueUI.text = DataContainer.Score.ToString();
    }
}
