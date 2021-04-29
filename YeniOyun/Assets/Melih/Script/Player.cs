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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void fireButton()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
}
