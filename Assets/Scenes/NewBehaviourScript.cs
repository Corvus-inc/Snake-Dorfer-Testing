using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    [SerializeField] GameObject g1, g2, Sphere;
    [SerializeField] Collider c1, c2;
    GameObject g;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            g = Instantiate(g1, Sphere.transform);
            g.transform.position = Vector3.one;
            Debug.Log(g.transform.localPosition);
            Debug.Log(g.transform.position);
            Debug.Log(g.GetComponent<Collider>().bounds.center);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log(g.GetComponent<Collider>().bounds.center);

        }
        if (Input.GetAxis("Horizontal") != 0)
        {
            g1.transform.localPosition = new Vector3(g1.transform.localPosition.x + Input.GetAxis("Horizontal"), g1.transform.localPosition.y, g1.transform.localPosition.z);
        }
        if (c1.bounds.Intersects(c2.bounds))
        {
            Debug.Log("Crash!");
        }
    }
}
