using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{

    [SerializeField] private Transform Player;
    [SerializeField] private GameObject Obstacle;
    [SerializeField] private float DistanceToNextObstacle = 50f;

    private GameObject LastObstacle;
    private int NumberOfRows = 0;

    // Update is called once per frame
    private void Update()
    {
        if (Player.position.z / (DistanceToNextObstacle * NumberOfRows) > 1)
        {
            NumberOfRows += 1;
            Destroy(LastObstacle, 5f);
            LastObstacle = GenerateObstacle();
        }   
    }

    private GameObject GenerateObstacle()
    {
        GameObject obstacle = Instantiate(
            Obstacle,
            new Vector3(0, 1, Player.position.z + DistanceToNextObstacle),
            Quaternion.identity
        );
        return obstacle;
    }

}
