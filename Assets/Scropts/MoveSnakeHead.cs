using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSnakeHead : MonoBehaviour
{
    public Transform transformSnakeHead;
    public Rigidbody rigSnakeHead;

    public float speedSnakeUp = 1f;
    public float speedSnakeInput = 1f;

    void Start()
    {
        transformSnakeHead = GetComponent<Transform>();
        rigSnakeHead = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MoveUp();
        MoveInput();
    }
    private void MoveUp()
    {
        //transformSnakeHead.position += (Vector3.right * Time.deltaTime * speedSnakeUp);

        rigSnakeHead.velocity = Vector3.right * speedSnakeUp;
    }
    private void MoveInput()
    {
        Vector3 vlocitySnake = rigSnakeHead.velocity;

        if (Input.GetKey(KeyCode.A))
        {
            vlocitySnake.z = speedSnakeInput;
        }
        if (Input.GetKey(KeyCode.D))
        {
            vlocitySnake.z = -speedSnakeInput;
        }

        rigSnakeHead.velocity = vlocitySnake;
    }
}
