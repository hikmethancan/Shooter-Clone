using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //[SerializeField] Transform player;
    public GameObject bulletPrefab;
    GameObject[] EnemyList;

    private void Start()
    {

    }
    void Update()
    {
        EnemyList = GameObject.FindGameObjectsWithTag("Enemy");
        if(EnemyList.Length == 0)
        {
            if (SceneManager.GetActiveScene().buildIndex != 3)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    public void fireButton()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
}
