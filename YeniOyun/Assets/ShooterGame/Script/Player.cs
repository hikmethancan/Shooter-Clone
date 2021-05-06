using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class Player : MonoBehaviour
{
    public Transform handPos;
    public List<GameObject> ammoList = new List<GameObject>();
    public GameObject bulletPrefab;
    GameObject Shuriken;
    public LineRenderer LineRenderer;
    int index = 0;
    public int ammo,ShrukenSpeed;
    public bool fire;
    private void Start()
    {
        fire = false;
        ShrukenSpeed = 8;
    }
    void Update()
    {
        Vector3 from = handPos.position;
        Vector3 to = transform.forward;
        LineRenderer.positionCount = 1;
        LineRenderer.SetPosition(0, from);
        index = 0;
        if (!fire)
            DrawLine(from,to);


    }
    void DrawLine(Vector3 from,Vector3 to)
    {
        if (index > 5) return;
        RaycastHit hit;
        if (Physics.Raycast(from, to, out hit))
        {
            if (hit.collider)
            {
                index = LineRenderer.positionCount++;
                LineRenderer.SetPosition(index, hit.point);
                to = Vector3.Reflect(to, hit.normal);
                from = hit.point;
                if(hit.transform.gameObject.CompareTag("Wall"))
                DrawLine(from,to);
            }
        }
       else
        {
            to *= 100;
            to.y = 1;
            index = LineRenderer.positionCount++;
            LineRenderer.SetPosition(index, to);
        }
    }
    public void fireButton()
    {
        
            
            ammoList.Last().SetActive(false);
            ammoList.Remove(ammoList.Last());
            Shuriken = Instantiate(bulletPrefab, handPos.position, transform.rotation);
            Shuriken.GetComponent<Rigidbody>().velocity = Shuriken.transform.forward * ShrukenSpeed;
            ammo--;
            
            StartCoroutine(Timer(Shuriken));
        
    }
    IEnumerator Timer(GameObject shuriken)
    {
        yield return new WaitForSeconds(3f);
        fire = false;
        Destroy(shuriken);
    }
    public void Throw()
    {
        if (!fire && ammo > 0)
        {
            fire = true;
            GetComponent<Animator>().SetTrigger("Throw");
        }
    }
    public void Win()
    {
        GetComponent<Animator>().SetTrigger("Win");
    }

}