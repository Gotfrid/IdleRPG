using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusController : MonoBehaviour
{

  private Rigidbody rb;

  private void Start()
  {
    rb = GetComponent<Rigidbody>();
    rb.mass = 0.1f;
    rb.drag = 50f;
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
    }

    Destroy(gameObject);
  }
}
