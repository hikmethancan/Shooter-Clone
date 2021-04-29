using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bulletPrefab;
    void Update()
    {
        //if(Input.GetMouseButtonDown(0))
        //{
        //    GameObject bulletObject = Instantiate(bulletPrefab, transform.position + Vector3.forward, Quaternion.identity);

        //}
        
    }

    public void method2()
    {
        GameObject bulletObject = Instantiate(bulletPrefab, transform.position + Vector3.forward, Quaternion.identity);
    }
}
