using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public static void StartGame() {
        SceneManager.LoadScene("Game");
    }

    public static void GameOver() {
        SceneManager.LoadScene("Over");
    }

    public static void MainMenu() {
        SceneManager.LoadScene("Menu");
    }

    public static void QuitGame() {
        Application.Quit();
    }
}
