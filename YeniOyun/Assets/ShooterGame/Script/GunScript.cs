using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    private LineRenderer LineRenderer;
    public Text ammoText;

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
        ammoText.text = string.Format("{0}",ammo);
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
                if(hit.transform.gameObject.tag == "Bullet" || hit.transform.gameObject.tag == "Wall" || hit.transform.gameObject.tag == "Enemy" || hit.transform.gameObject.tag=="Friend" || hit.transform.gameObject.tag == "EnemyIsDead") return;
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

        if (GameObject.FindGameObjectWithTag("Bullet") == null && ammo > 0)
        {
            PlayerAnimation.Throw();

            Invoke(nameof(bullet), 0.5f);
        }
    }
    void bullet()
    {
        if (ammo != 0)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            ammo--;
            StartCoroutine(Timer());
        }
    }
     IEnumerator Timer()
    {
        yield return new WaitForSeconds(7f);
        Destroy(GameObject.FindGameObjectWithTag("Bullet"));
    }
        
}
