using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 8f;
    GameObject GameOverPanel;
    GameObject Joystick;
    private GOScript GOScript;
    public static int scenenumber;

    void Start()
    {
        GOScript = GetComponent<GOScript>();
        GameOverPanel = GameObject.FindGameObjectWithTag("GameOverPanel");
        
        //GameOverPanel = GameObject.FindGameObjectWithTag("GameOverPanel");
        LineRenderer lineRenderer = FindObjectOfType<LaserScript>().GetComponent<LineRenderer>();
        Vector3 dir = lineRenderer.GetPosition(1) - lineRenderer.GetPosition(0);
        GetComponent<Rigidbody>().velocity = dir.normalized * speed;
    }


    void Update()
    {

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
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            scenenumber = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene("GameOverScene");
           
            
            //Joystick.gameObject.SetActive(false);
            //GameOverPanel.gameObject.SetActive(true);
        }
    }

  /*  public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }*/
}

