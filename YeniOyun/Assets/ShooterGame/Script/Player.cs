using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    public FixedJoystick variableJoystick;
    public float rotationSpeed;
    public Transform handPos;
    public List<GameObject> ammoList = new List<GameObject>();
    public GameObject shurikenPrefab;
    public LineRenderer lineRenderer;
    private int index;
    public int ammo, shrukenSpeed;
    public bool fire;
    private Vector3 shurikenStartPosition;

    private void Start()
    {
        fire = false;
    }

    private void Update()
    {
        Joystick();
        Vector3 from = handPos.position;
        Vector3 to = transform.forward;
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, from);
        index = 0;
        if (!fire) DrawLine(from, to);



    }

    void DrawLine(Vector3 from, Vector3 to)
    {
        if (index > 5) return;
        if (Physics.Raycast(from, to, out RaycastHit hit))
        {
            if (hit.collider)
            {
                index = lineRenderer.positionCount++;
                lineRenderer.SetPosition(index, hit.point);
                to = Vector3.Reflect(to, hit.normal);
                from = hit.point;
                if (hit.transform.gameObject.CompareTag("Wall"))
                    DrawLine(from, to);
            }
        }
        else
        {
            to *= 100;
            to.y = 1;
            index = lineRenderer.positionCount++;
            lineRenderer.SetPosition(index, to);
        }
    }

    public void FireButton()
    {


        ammoList.Last().SetActive(false);
        ammoList.Remove(ammoList.Last());

        
        shurikenStartPosition.y = 1;
        GameObject shuriken = Instantiate(shurikenPrefab, shurikenStartPosition, transform.rotation);
        shuriken.GetComponent<Rigidbody>().velocity = shuriken.transform.forward * shrukenSpeed;
        ammo--;

        StartCoroutine(Timer(shuriken));

    }

    IEnumerator Timer(GameObject shuriken)
    {
        yield return new WaitForSeconds(5f);
        fire = false;
        Destroy(shuriken);
    }

    public void Throw()
    {
        if (!fire && ammo > 0)
        {
            shurikenStartPosition = handPos.position;
            fire = true;
            GetComponent<Animator>().SetTrigger("Throw");
        }
    }

    public void Win()
    {
        fire = true;
        GetComponent<Animator>().SetTrigger("Win");


    }

    private void Joystick()
    {
        float angle = Mathf.Atan2(variableJoystick.Horizontal, variableJoystick.Vertical) * Mathf.Rad2Deg;
        if(angle!=0){
            angle = Mathf.MoveTowardsAngle(transform.rotation.eulerAngles.y, angle, rotationSpeed);
            transform.rotation = Quaternion.Euler(0,angle,0);

        }
    }
}