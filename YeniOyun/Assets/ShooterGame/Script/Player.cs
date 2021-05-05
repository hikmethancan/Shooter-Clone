using System.Collections;
using UnityEngine;
public class Player : MonoBehaviour
{
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
       Vector3 from = transform.position;
       Vector3 to = transform.forward;
        LineRenderer.positionCount = 1;
        LineRenderer.SetPosition(0, LineRenderer.transform.position);
        index = 0;
        if (!fire)
            DrawLine(from,to);
        if(Shuriken != null)
        Shuriken.transform.position += Shuriken.transform.forward * ShrukenSpeed * Time.deltaTime;
        //Shuriken.transform.rotation = Quaternion.LookRotation((LineRenderer.GetPosition(1) - LineRenderer.GetPosition(0)).normalized * ShrukenSpeed);
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
                if(hit.transform.tag == "Wall")
                DrawLine(from,to);
            }
        }
        else
        {
            index = LineRenderer.positionCount++;
            LineRenderer.SetPosition(index, LineRenderer.transform.forward * 1000);
        }
    }
    public void fireButton()
    {
        if (!fire && ammo > 0)
        {
            Shuriken = Instantiate(bulletPrefab, transform.position, transform.rotation);
            ammo--;
            fire = true;
            StartCoroutine(Timer(Shuriken));
        }
    }
    IEnumerator Timer(GameObject shuriken)
    {
        yield return new WaitForSeconds(3f);
        fire = false;
        Destroy(shuriken);
    }
    public void Throw()
    {
        GetComponent<Animator>().SetTrigger("Throw");
    }
    public void Win()
    {
        GetComponent<Animator>().SetTrigger("Win");
    }

}