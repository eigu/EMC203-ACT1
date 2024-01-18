using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    static public GameObject _playerObject;
    [SerializeField, Range(1,100)] private int _playerHealth;

    void Start()
    {
        _playerObject = GameObject.Find("Player");
    }

    void Update()
    {
        
    }    
}
