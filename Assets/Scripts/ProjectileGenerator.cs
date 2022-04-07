using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGenerator : MonoBehaviour
{
  [SerializeField] private GameObject Projectile;
  private GameObject[] PlayerObjects;

  private Vector3 ProjectileOffset = new Vector3(0f, -0.75f, 1f);

  private void Update()
  {

    PlayerObjects = GameObject.FindGameObjectsWithTag("Player");

    if (Input.GetKeyDown("space"))
    {
      for (int i = 0; i < PlayerObjects.Length; i++)
      {
        FireProjectile(PlayerObjects[i].transform, Projectile);
      }
    }
  }

  private void FireProjectile(Transform Player, GameObject projectile)
  {
    Instantiate(projectile, Player.position + ProjectileOffset, Quaternion.identity);
  }
}
