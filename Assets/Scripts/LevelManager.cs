using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    void Update()
    {
        if (!PlayerScript._playerObject)
            {
                RestartGame();
            }
    }

    void RestartGame()
    {
        SceneManager.LoadScene("GAME");
    }
}
