using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{

  [SerializeField] private Transform Player;
  [SerializeField] private GameObject Obstacle;
  [SerializeField] private float DistanceToNextObstacle = 50f;

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
    if (Player.position.z / (DistanceToNextObstacle * NumberOfRows) > 1)
    {
      NumberOfRows += 1;
      Destroy(LastObstacleOne, 5f);
      Destroy(LastObstacleTwo, 5f);
      LastObstacleOne = GenerateObstacle(-2.5f);
      LastObstacleTwo = GenerateObstacle(2.5f);

      // Only generate a bonus after every second row of obstacles
      if (NumberOfRows % 2 == 0)
      {
        GenerateBonus(Random.Range(0, 3));
      }
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
