using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    private LineRenderer LineRenderer;
    Vector3 from;
    Vector3 to;
    int index = 0;
    public int ammo = 3;
    void Start()
    {
        LineRenderer = GetComponent<LineRenderer>();
    }

    private void FixedUpdate()
    {
        from = transform.position;
        to = transform.forward;
        LineRenderer.positionCount = 1;
        LineRenderer.SetPosition(0,transform.position);
        index = 0;
        if(GameObject.FindGameObjectWithTag("Bullet")==null)
        DrawLine();
        
    }

    void DrawLine()
    {   
        
        if(index > 5) return;
        RaycastHit hit;
        if(Physics.Raycast(from, to, out hit))
        {
           
            if(hit.collider)
            {
                index = LineRenderer.positionCount++;
                LineRenderer.SetPosition(index, hit.point);
                to =  Vector3.Reflect(to,hit.normal);
                from = hit.point;
                if(hit.transform.gameObject.tag == "Bullet" || hit.transform.gameObject.tag == "Wall" || hit.transform.gameObject.tag == "Enemy" || hit.transform.gameObject.tag=="Friend") return;
                
                DrawLine();
                
                
            }
        }
        else
        {
                index = LineRenderer.positionCount++;

            LineRenderer.SetPosition(index, to * 1000);
            
        }
    }

    public void fireButton()
    {
        if(GameObject.FindGameObjectWithTag("Bullet")==null && ammo > 0)
        Instantiate(bulletPrefab, transform.position, transform.rotation);
        ammo--;
    }
}
