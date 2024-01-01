using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    static public GameObject player;
    public float speed = 5f;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        transform.Translate(movement * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("End"))
        {
            Destroy(player);
        }
    }
}
