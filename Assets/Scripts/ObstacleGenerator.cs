using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{

  [SerializeField] private Transform Player;
  [SerializeField] private GameObject Obstacle;
  [SerializeField] private float DistanceToNextObstacle = 50f;

  [SerializeField] private GameObject GroundPrefab;
  // Bad hardcode
  private int GroundLength = 1000;
  private int NumberOfGrounds = 1;
  private float DistanceToNextGround = 900f;

  /*
  Not the best bonus system: attach three different bonuses
  and based on a random integer select the bonus to generate
  */
  [SerializeField] private GameObject BonusDamage;
  [SerializeField] private GameObject BonusSpeed;
  [SerializeField] private GameObject BonusUnit;

  private GameObject LastObstacleOne;
  private GameObject LastObstacleTwo;
  private int NumberOfRows = 0;

  // Update is called once per frame
  private void Update()
  {
    // Generate obstacles
    if (Player.position.z / (DistanceToNextObstacle * NumberOfRows) > 1)
    {
      NumberOfRows += 1;
      Destroy(LastObstacleOne, 5f);
      Destroy(LastObstacleTwo, 5f);
      LastObstacleOne = GenerateObstacle(-2.5f);
      LastObstacleTwo = GenerateObstacle(2.5f);

      // Generate bonuses: only generate a bonus after every second row of obstacles
      if (NumberOfRows % 2 == 0)
      {
        GenerateBonus(Random.Range(0, 3));
      }
    }

    // Generate ground
    if (Player.position.z > (DistanceToNextGround * NumberOfGrounds))
    {
      NumberOfGrounds += 1;
      Instantiate(
        GroundPrefab,
        new Vector3(0, 0, Player.position.z + (GroundLength / 2)),
        Quaternion.identity
      );
    }
  }

  private GameObject GenerateObstacle(float xPos)
  {
    GameObject obstacle = Instantiate(
        Obstacle,
        new Vector3(xPos, 2f, Player.position.z + DistanceToNextObstacle),
        Quaternion.identity
    );
    return obstacle;
  }

  private void GenerateBonus(int BonusType)
  {
    switch (BonusType)
    {
      case 0:
        InstantiateBonus(BonusDamage);
        break;
      case 1:
        InstantiateBonus(BonusSpeed);
        break;
      case 2:
        InstantiateBonus(BonusUnit);
        break;
    }
  }

  private void InstantiateBonus(GameObject BonusObject)
  {
    Instantiate(
      BonusObject,
      new Vector3(0, 2f, Player.position.z + DistanceToNextObstacle * 1.5f),
      Quaternion.identity
    );
  }

}
