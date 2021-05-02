using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] float speed = 8f;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        LineRenderer lineRenderer = FindObjectOfType<GunScript>().GetComponent<LineRenderer>();
        Vector3 dir = lineRenderer.GetPosition(1) - lineRenderer.GetPosition(0);
        GetComponent<Rigidbody>().velocity = dir.normalized * speed;
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Enemy"){
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        if(other.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
        if(other.gameObject.tag == "Friend")
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            gameManager.GameOver();
        }
    }
}

