using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

  private Rigidbody Bullet;
  private float BulletForce;

  private void Start()
  {
    BulletForce = DataContainer.Speed * 2.5f;
    Bullet = GetComponent<Rigidbody>();
    Bullet.AddRelativeForce(Vector3.forward * BulletForce, ForceMode.Impulse);

    Destroy(gameObject, 1.5f);
  }

  private void OnCollisionEnter(Collision other) {
    if (other.gameObject.tag == "Player")
    {
      Physics.IgnoreCollision(
        other.collider,
        GetComponent<SphereCollider>()
      );   
    }
  }
}
