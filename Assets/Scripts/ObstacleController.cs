using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObstacleController : MonoBehaviour
{
  private int ObstacleHP;
  private TextMeshProUGUI HealthText;

  private void OnCollisionEnter(Collision other)
  {
    if (other.collider.tag == "Projectile")
    {
      Destroy(other.gameObject);
      takeDamage(DataContainer.Damage);
    }

    if (other.collider.tag == "Player")
    {
      Destroy(other.gameObject);
      Destroy(gameObject);
      DataContainer.Units -= 1;
      if (DataContainer.Units < 1)
      {
        GameController.GameOver();
      }
    }
  }

  private void Start()
  {
    HealthText = GetComponentInChildren<TextMeshProUGUI>();
    int PlayerTotalDamage = DataContainer.Damage * DataContainer.Units;
    ObstacleHP = Random.Range(PlayerTotalDamage * 5, PlayerTotalDamage * 15);
    HealthText.text = ObstacleHP.ToString();
  }

  private void Update()
  {
    if (ObstacleHP <= 0)
    {
      Destroy(gameObject);
      DataContainer.Score += 1;
    }
  }

  private void takeDamage(int amount)
  {
    ObstacleHP -= amount;
    HealthText.text = ObstacleHP.ToString();
  }
}
