using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObstacleController : MonoBehaviour
{
    public int ObstacleHP = 10;
    
    private TextMeshProUGUI HealthText;

    private void OnCollisionEnter(Collision other) {
        if (other.collider.tag == "Projectile") {
            Destroy(other.gameObject);
            takeDamage(DataContainer.Damage);
        }

        if (other.collider.tag == "Player") {
            GameOver(other.gameObject);
        }
    }

    private void Start() {
        HealthText = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update() {
        if (ObstacleHP <= 0) {
            Destroy(gameObject);
            DataContainer.Score += 1;
        }
    }

    private void takeDamage(int amount) {
        ObstacleHP -= amount;
        HealthText.text = ObstacleHP.ToString();
    }

    private void GameOver(GameObject PlayerObject) {
        Destroy(PlayerObject);
        GameController.GameOver();
    }
}
