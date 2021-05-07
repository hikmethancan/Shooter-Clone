using UnityEngine;
public class Bullet : MonoBehaviour
{
    GameManager gameManager;
    private Player player;
    public GameObject deadBody;
    private void Start()
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
    void Hit(Transform character)
    {
        player.fire = false;
        Destroy(character.gameObject);
        Instantiate(deadBody, character.position, character.rotation);
        Destroy(gameObject);
    }
}

