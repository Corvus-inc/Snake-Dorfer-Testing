using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public List<Transform> bodyParts = new List<Transform>();

    public float minDistance = 1f;

    public int beginSize;

    public float speed = 1;
    public float speedHead = 1000;

    public GameObject bodyPrefab;
    public Rigidbody rigSnakeHead;

    private float dis;
    private Transform curBodyPart;
    private Transform prevBodypart;
    private Vector3 vlocitySnake;

    void Start()
    {
        for (int i = 0; i < beginSize - 1; i++)
        {
            AddBodyPart();
        }
        bodyParts[0].GetComponentInParent<SphereCollider>().enabled = true;
    }

    void Update()
    {
        Move();

        if (Input.GetKey(KeyCode.Q))
        {
            AddBodyPart();
        }
    }

    public void Move()
    {
        float curspeed = speed;
        if (Input.GetKey(KeyCode.W))
        {
            curspeed *= 2;
        }

        bodyParts[0].Translate(bodyParts[0].forward * curspeed * Time.smoothDeltaTime, Space.World);
        
        //Движение по оси с помощью rigidbody.velocity
        vlocitySnake = rigSnakeHead.velocity;
        if (Input.GetAxis("Horizontal") != 0)
        {
            
                vlocitySnake.z = speedHead * Time.deltaTime * -Input.GetAxis("Horizontal");
           
        }
        rigSnakeHead.velocity = vlocitySnake;
        
        for (int i = 1; i < bodyParts.Count; i++)
        {
            curBodyPart = bodyParts[i];
            prevBodypart = bodyParts[i - 1];

            dis = Vector3.Distance(prevBodypart.position, curBodyPart.position);

            Vector3 newpos = prevBodypart.position;

            newpos.y = bodyParts[0].position.y;

            float T = Time.deltaTime * dis / minDistance * curspeed;

            if (T > 0.5f)
            {
                T = 0.5f;
            }

            curBodyPart.position = Vector3.MoveTowards(curBodyPart.position, newpos, T);
            curBodyPart.rotation = Quaternion.Slerp(curBodyPart.rotation, prevBodypart.rotation, T);
        }
    }

    public void AddBodyPart()
    {
        Transform newPart = (Instantiate(bodyPrefab, bodyParts[bodyParts.Count - 1].position, bodyParts[bodyParts.Count - 1].rotation) as GameObject).transform;

        newPart.SetParent(transform);

        bodyParts.Add(newPart);
    }
}
