using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataContainer : MonoBehaviour
{
  public static int Damage;
  public static float Speed;
  public static int Score;

  private void Start()
  {
    Damage = 1;
    Speed = 10f;
    Score = 0;
  }
}
