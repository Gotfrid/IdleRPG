using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public int ObstacleHP = 10;
    
    // TODO: extract into ScriptableObject!
    private int IncomingDamage = 2; 

    private void OnCollisionEnter(Collision other) {
        if (other.collider.tag == "Projectile") {
            Destroy(other.gameObject);
            takeDamage(IncomingDamage);
        }

        if (other.collider.tag == "Player") {
            GameOver(other.gameObject);
        }
    }

    private void Update() {
        if (ObstacleHP <= 0) {
            Destroy(gameObject);
        }
    }

    private void takeDamage(int amount) {
        ObstacleHP -= amount;
    }

    private void GameOver(GameObject PlayerObject) {
        Destroy(PlayerObject);
        // some UI logic here as well
    }
}
