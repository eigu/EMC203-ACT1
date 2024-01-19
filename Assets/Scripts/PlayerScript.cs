using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript Instance { get; private set; }

    public GameObject playerObject;
    [Range(1,100)]
    public int playerHealth;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        playerObject = GameObject.Find("Player");
    }
}
