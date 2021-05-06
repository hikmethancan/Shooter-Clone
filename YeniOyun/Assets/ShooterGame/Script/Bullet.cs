using UnityEngine;
public class Bullet : MonoBehaviour
{
    GameManager gameManager;
    private Player player;
    public GameObject Deadbody;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        player = FindObjectOfType<Player>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Hit(collision.transform);
        }
        else if (collision.gameObject.CompareTag("Friend"))
        {
            gameManager.GameOver();
            Destroy(gameObject);
        }
    }
    void Hit(Transform Character)
    {
        player.fire = false;
        Destroy(Character.gameObject);
        Instantiate(Deadbody, Character.position, Character.rotation);
        Destroy(gameObject);
    }
}

