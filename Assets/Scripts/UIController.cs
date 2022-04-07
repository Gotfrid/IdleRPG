using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{

  private TextMeshProUGUI ScoreValueUI;
  private TextMeshProUGUI SpeedValueUI;
  private TextMeshProUGUI DamageValueUI;

  private void Start()
  {
    ScoreValueUI = GameObject
        .FindGameObjectWithTag("ScoreValue")
        .GetComponent<TextMeshProUGUI>();
    
    DamageValueUI = GameObject
        .FindGameObjectWithTag("DamageValue")
        .GetComponent<TextMeshProUGUI>();
    
    SpeedValueUI = GameObject
      .FindGameObjectWithTag("SpeedValue")
      .GetComponent<TextMeshProUGUI>();
  }

  private void Update()
  {
    ScoreValueUI.text = DataContainer.Score.ToString();
    DamageValueUI.text = DataContainer.Damage.ToString();
    SpeedValueUI.text = DataContainer.Speed.ToString();
  }
}
