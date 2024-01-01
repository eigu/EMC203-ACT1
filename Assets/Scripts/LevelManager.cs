using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Transform gameEnd;

    void Update()
    {if (!PlayerScript.player)
        {
            SceneManager.LoadScene("GAME");
        }
    }
}
