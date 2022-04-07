using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusController : MonoBehaviour
{

  [SerializeField] private GameObject PlayerPrefab;
  
  private Rigidbody rb;
  private GameObject PlayerObject;

  private void Start()
  {
    rb = GetComponent<Rigidbody>();
    rb.mass = 0.1f;
    rb.drag = 50f;

    PlayerObject = GameObject.FindGameObjectWithTag("Player");

  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.tag == "Ground")
    {
      Destroy(gameObject);
    }

    if (gameObject.tag == "BonusDamage")
    {
      // Increase global damage
      DataContainer.Damage += 1;
    }
    else if (gameObject.tag == "BonusSpeed")
    {
      // Increase global speed
      DataContainer.Speed += 2f;
    }
    else 
    {
      // Add one more unit
      DataContainer.Units += 1;

      // Add random noise
      Vector3 spawnNoise = new Vector3(
        Random.Range(0.1f, 1f),
        Random.Range(0.1f, 1f),
        Random.Range(0.1f, 1f)
      );

      // Spawn another player object
      Instantiate(
        PlayerPrefab,
        PlayerObject.transform.position + spawnNoise,
        Quaternion.identity
      );
    }

    Destroy(gameObject);
  }
}
