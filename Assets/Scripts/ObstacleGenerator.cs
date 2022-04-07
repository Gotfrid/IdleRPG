using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{

  [SerializeField] private Transform Player;
  [SerializeField] private GameObject Obstacle;
  [SerializeField] private float DistanceToNextObstacle = 50f;

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

}
