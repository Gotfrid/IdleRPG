using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    private Rigidbody Bullet;
    private float BulletForce = 30f;

    private void Start() {
        Bullet = GetComponent<Rigidbody>();
        // Bullet.AddForce(0, 0, 50, ForceMode.Impulse);
        Bullet.AddRelativeForce(Vector3.forward * BulletForce, ForceMode.Impulse);

        Destroy(gameObject, 1.5f);
    }

}
