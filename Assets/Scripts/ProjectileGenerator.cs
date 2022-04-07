using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGenerator : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private GameObject Projectile;

    private Vector3 ProjectileOffset = new Vector3(0f, -0.75f, 1f);

    private void Update() {
        if (Input.GetKeyDown("space"))
        {
            FireProjectile(Projectile);
        }
    }

    private void FireProjectile(GameObject projectile)
    {
        Instantiate(projectile, Player.position + ProjectileOffset, Quaternion.identity);
    }
}
