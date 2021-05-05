using UnityEngine;
public class Bullet : MonoBehaviour
{
    GameManager gameManager;
    Player player;
    public GameObject Deadbody;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        player = FindObjectOfType<Player>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Friend")
        {
            if (collision.gameObject.tag == "Friend")
            {
                gameManager.GameOver();
            }
            Hitted(collision.transform);
        }
    }
    void Hitted(Transform Character)
    {
        player.fire = false;
        Destroy(Character.gameObject);
        Instantiate(Deadbody, Character.position, Character.rotation);
        Destroy(gameObject);
    }
}

