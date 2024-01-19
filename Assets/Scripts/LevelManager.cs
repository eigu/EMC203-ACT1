using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    void Update()
    {
        if (PlayerScript.Instance.playerHealth <= 0) RestartGame();
    }

    void RestartGame()
    {
        SceneManager.LoadScene("GAME");
    }
}
