using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 8f;

    LineRenderer lineRenderer;
    List<Vector3> path = new List<Vector3>(); 
    void Start()
    {
        lineRenderer = FindObjectOfType<LaserScript>().GetComponentInChildren<LineRenderer>();
        for(int i = 0; i<lineRenderer.positionCount; i++){
            path.Add(lineRenderer.GetPosition(i));

        }


        transform.position = path[0];
        StartCoroutine(Move());
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
    }
    IEnumerator Move()
    {
        for(int i = 1; i < path.Count; i++)
        {
            while(transform.position != path[i])
            {
            float distance = Vector3.Distance(transform.position, path[i]);
            float time = distance / speed;
            transform.position = Vector3.MoveTowards(transform.position, path[i], .1f);
            yield return new WaitForEndOfFrame();
            }
        }
        
    }
}

