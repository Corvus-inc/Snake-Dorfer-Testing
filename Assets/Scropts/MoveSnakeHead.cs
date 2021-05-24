using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSnakeHead : MonoBehaviour
{
    public Transform transformSnakeHead;


    void Update()
    {
        transformSnakeHead.position = transformSnakeHead.position + (Vector3.right * Time.deltaTime);


    }
}
